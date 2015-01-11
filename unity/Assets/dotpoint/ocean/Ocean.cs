using UnityEngine;
using System.Collections;

public class Ocean : MonoBehaviour 
{
	/**
	 * ocean settings
	 */
	public OceanParams settings = new OceanParams();

	// -------------- //

	private OceanDispertion m_dispertion;		// more or less speed of water for or each sample point
	private OceanSpectrum	m_spectrum;			// amplitude spectrum for each sample point

	private FFT m_fourier;

	// -------------- //

	private Vector2[,] m_spectrumBuffer;		// ht vector2 buffer for each sample point

	private Vector2[,] m_heightBuffer;
	private Vector4[,] m_slopeBuffer;
	private Vector4[,] m_displaceBuffer;

	// -------------- //

	private OceanGrid	m_grid;

	// ************************************************************************ //
	// Initialization
	// ************************************************************************ //	

	/**
	 * 
	 */
	void Start() 
	{
		this.m_dispertion 	= new OceanDispertion( this.settings );
		this.m_spectrum 	= new OceanSpectrum( this.settings );
		this.m_fourier 		= new FFT();
	}

	/**
	 * 
	 */
	private void initBuffers()
	{
		int N1 = this.settings.N;
		int N2 = (int)(this.settings.N * this.settings.N);

		// --------------------- //
		// spectrum:

		this.m_spectrumBuffer 	= new Vector2[N1,N1];

		// --------------------- //

		this.m_heightBuffer 	= new Vector2[2, N2];
		this.m_slopeBuffer 		= new Vector4[2, N2];
		this.m_displaceBuffer 	= new Vector4[2, N2];

		// --------------------- //

		this.m_dispertion.init();
		this.m_spectrum.init();

		this.m_fourier.init( N1 );

		// --------------------- //

		this.m_grid = new OceanGrid( 8, 8, this.settings.N + 1, this.settings );
	}

	// ************************************************************************ //
	// Update
	// ************************************************************************ //	

	/**
	 * 
	 */
	void Update() 
	{
		if( this.settings.isDimensionDirty )
		{
			this.initBuffers();	// allocates and updates everything
			this.settings.isDimensionDirty  = false;

		}
		else
		{
			if( this.settings.isDispertionDirty )
			{
				this.m_dispertion.update();
				this.settings.isDispertionDirty = false;
			}

			if( this.settings.isSpectrumDirty )
			{
				this.m_spectrum.update();
				this.settings.isSpectrumDirty = false;
			}
				
		}

		// -------------- //

		this.evaluateWaves( Time.realtimeSinceStartup );
		this.applyWave();
	}

	/**
	 * 
	 */
	private void evaluateWaves( float t )
	{
		this.initWave( t );

		this.m_fourier.PeformFFT2( 0, this.m_heightBuffer 	);
		this.m_fourier.PeformFFT4( 0, this.m_slopeBuffer 	);
		this.m_fourier.PeformFFT4( 0, this.m_displaceBuffer );
	}

	/**
	 * 
	 */
	private void applyWave()
	{
		int N0 = this.settings.N;
		int N1 = this.settings.N + 1;

		// -------------------- //

		Vector3[] vertices = this.m_grid.mesh.vertices;
		Vector3[] normals  = this.m_grid.mesh.normals;

		// -------------------- //

		Vector3 norm  = new Vector3();
		float[] signs = new float[]{ 1.0f, -1,0f };

		int sign;
		int index0, index1, indexNN;

		float lambda 	= -1.0f;
		float sharpness = 1.0f;

		// -------------------- //

		for( int n = 0; n < N0; n++ ) 
		{
			for( int m = 0; m < N0; m++ ) 
			{
				index0 = n * N0 + m;	// buffer index
				index1 = n * N1 + m;	// vertex index

				sign = (int)signs[(n + m) & 1];

				// ------------ //
				// position:

				vertices[index1].y = this.m_heightBuffer[1, index0].x * sign;

				vertices[index1].x = this.m_grid.positions[index1].x + this.m_displaceBuffer[1, index0].x * lambda * sign * sharpness;
				vertices[index1].z = this.m_grid.positions[index1].y + this.m_displaceBuffer[1, index0].z * lambda * sign * sharpness;

				// ------------ //
				// normal:

				norm.x = -this.m_slopeBuffer[1, index0].x * sign;
				norm.z = -this.m_slopeBuffer[1, index0].z * sign;
				norm.y = 1.0f;

				norm.Normalize();

				normals[index1].x = norm.x;
				normals[index1].y = norm.y;
				normals[index1].z = norm.z;

				// ------------ //
				// tiling

				if( n == 0 && m == 0) 
				{
					indexNN = index1 + N0 + N1 * N0;

					vertices[indexNN].y = this.m_heightBuffer[1, index0].x * sign;	

					vertices[indexNN].x = this.m_grid.positions[indexNN].x + this.m_displaceBuffer[1, index0].x * lambda * sign * sharpness;
					vertices[indexNN].z = this.m_grid.positions[indexNN].y + this.m_displaceBuffer[1, index0].z * lambda * sign * sharpness;
					
					normals[indexNN].x =  norm.x;
					normals[indexNN].y =  norm.y;
					normals[indexNN].z =  norm.z;
				}

				if( n == 0 ) 
				{
					indexNN = index1 + N1 * N0;
						
					vertices[indexNN].y = this.m_heightBuffer[1, index0].x * sign;	
					
					vertices[indexNN].x = this.m_grid.positions[indexNN].x + this.m_displaceBuffer[1, index0].x * lambda * sign * sharpness;
					vertices[indexNN].z = this.m_grid.positions[indexNN].y + this.m_displaceBuffer[1, index0].z * lambda * sign * sharpness;
					
					normals[indexNN].x =  norm.x;
					normals[indexNN].y =  norm.y;
					normals[indexNN].z =  norm.z;
				}

				if( m == 0) 
				{
					indexNN = index1 + N0;

					vertices[indexNN].y = this.m_heightBuffer[1, index0].x * sign;	
					
					vertices[indexNN].x = this.m_grid.positions[indexNN].x + this.m_displaceBuffer[1, index0].x * lambda * sign * sharpness;
					vertices[indexNN].z = this.m_grid.positions[indexNN].y + this.m_displaceBuffer[1, index0].z * lambda * sign * sharpness;
					
					normals[indexNN].x =  norm.x;
					normals[indexNN].y =  norm.y;
					normals[indexNN].z =  norm.z;
				}
			}
		}

		// -------------------- //

		this.m_grid.mesh.vertices = vertices;
		this.m_grid.mesh.normals  = normals;
		this.m_grid.mesh.RecalculateBounds();
	}

	// -------------------------------------------------- //
	// -------------------------------------------------- //
	// 

	/**
	 * 
	 */
	private void initWave( float t )
	{
		int N1 = this.settings.N;

		// -------------------- //

		float 	kx, ky, k_length;
		int 	index;

		Vector2 c_ht;

		// -------------------- //

		for( int n = 0; n < N1; n++ ) 
		{
			kx = this.settings.getKComponent( n );

			for( int m = 0; m < N1; m++ ) 
			{
				ky = this.settings.getKComponent( m );

				// -------------- //
				// h(t)

				c_ht = this.ht( t, n, m );

				// -------------- //

				index = n * N1 + m;

				this.m_heightBuffer[ 1, index ].x 	=  c_ht.x;
				this.m_heightBuffer[ 1, index ].y 	=  c_ht.y;

				this.m_slopeBuffer[ 1, index ].x 	= -c_ht.y * kx;
				this.m_slopeBuffer[ 1, index ].y 	=  c_ht.x * kx;
				this.m_slopeBuffer[ 1, index ].z 	= -c_ht.y * ky;
				this.m_slopeBuffer[ 1, index ].w 	=  c_ht.x * ky;

				// -------------- //

				k_length = Mathf.Sqrt( kx * kx + ky * ky );

				if( k_length < 0.00001f ) 
				{
					this.m_displaceBuffer[ 1, index ].x = 0.0f;
					this.m_displaceBuffer[ 1, index ].y = 0.0f;
					this.m_displaceBuffer[ 1, index ].z = 0.0f;
					this.m_displaceBuffer[ 1, index ].w = 0.0f;
				} 
				else 
				{
					float kx_scale = -(kx / k_length);
					float ky_scale = -(ky / k_length);

					this.m_displaceBuffer[ 1, index ].x = -c_ht.y * kx_scale;
					this.m_displaceBuffer[ 1, index ].y =  c_ht.x * kx_scale;
					this.m_displaceBuffer[ 1, index ].z = -c_ht.y * ky_scale;
					this.m_displaceBuffer[ 1, index ].w =  c_ht.x * ky_scale;
				}
			}
		}
	}

	/**
	 * h~(x,t) = h0(k) * exp( i * w(k) * t ) + h0'(-k) * exp( -i * w(k) * t );
	 */
	private Vector2 ht( float t, int n, int m )
	{
		float w = this.m_dispertion.dispertion[ n, m ] * t;

		float c_cos = Mathf.Cos( w );
		float c_sin = Mathf.Sin( w );

		Vector2 h01 = this.m_spectrum.spectrum_norm[ n, m ];
		Vector2 h02 = this.m_spectrum.spectrum_conj[ n, m ];

		Vector2 c_ht = this.m_spectrumBuffer[ n, m ];
				c_ht.x = ( h01.x * c_cos - h01.y * c_sin ) + ( h02.x * c_cos - h02.y * -c_sin ); 	// h0 * exp(i * w * t) + h0' * exp(-i * w * t)  ... -i!
				c_ht.y = ( h01.x * c_sin + h01.y * c_cos ) + ( h02.x * -c_sin + h02.y * c_cos ); 	// complex( x1*x2 - y1*y2, x1*y2 + y1*x2 ); ... euler sin/cos

		return c_ht;
	}
}
