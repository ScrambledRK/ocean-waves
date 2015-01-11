using UnityEngine;

using System.Collections;
using System.Collections.Generic;

//
public class OceanSpectrum
{	

	/**
	 * ocean settings
	 */
	public OceanParams settings;

	// ------------ //

	/**
	 * 
	 */
	public Vector2[,] spectrum_norm;
	public Vector2[,] spectrum_conj;

	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	
	
	/**
	 * 
	 */
	public OceanSpectrum( OceanParams settings ) 
	{		
		this.settings = settings;
	}

	/**
	 * 
	 */
	public void init()
	{
		Debug.Log( "init spectrum" );

		this.spectrum_norm = new Vector2[ this.settings.N + 1, this.settings.N + 1 ];
		this.spectrum_conj = new Vector2[ this.settings.N + 1, this.settings.N + 1 ];

		this.update();
	}

	// ************************************************************************ //
	// Spectrum
	// ************************************************************************ //

	/**
	 * 
	 */
	public void update()
	{
		Vector2 k_norm 		= new Vector2();
		Vector2 k_conj 		= new Vector2();
		
		for( int n = 0; n < this.settings.N + 1; n++ ) 
		{
			for( int m = 0; m < this.settings.N + 1; m++ ) 
			{
				k_norm = this.settings.getKVector(  n,  m, k_norm );	// h0
				k_conj = this.settings.getKVector( -n, -m, k_conj );	// conjungat of complex h0
				
				Vector2 c_h0_norm = this.spectrum_norm[ n, m ]; 
				Vector2 c_h0_conj = this.spectrum_conj[ n, m ]; 

				this.spectrum_norm[ n, m ] = this.h0( n, m, k_norm, c_h0_norm );
				this.spectrum_conj[ n, m ] = this.h0( n, m, k_conj, c_h0_conj );						
				this.spectrum_conj[ n, m ].y *= -1f;
			}
		}
	}
	
	/**
	 * ( 1 / sqrt(2) ) * ( random() + i * random() ) * sqrt( philips( k ) )
	 */
	private Vector2 h0( int n, int m, Vector2 k, Vector2 output )
	{
		float scale = Mathf.Sqrt( this.phillips( n, m, k ) / 2.0f ); 	// philips( k ) * sqrt(1/2);
		
		Vector2 c_h0 = this.gaussianRandom( output );			// random() + i * random();	
				c_h0.x *= scale;
				c_h0.y *= scale;

		return c_h0;
	}
	
	/**
	 * ( A * exp( -1 / ( k.length * max )^2 ) / k.length^4 ) * (|dot(k,w)|)^2 [* dampening ...]
	 */
	private float phillips( int n, int m, Vector2 k )
	{
		float k_length0 = k.magnitude;
		
		if( k_length0 < 0.000001f )
			return 0.0f;
		
		// ---------- //
		
		Vector2 w = this.settings.getWindVector( n, m );	// wind direction
		
		Vector2 k_unit = k.normalized;		
		Vector2 w_unit = w.normalized;
		
		// ---------- //
		
		float w_length0 = w.magnitude;
		float w_length2 = w_length0 * w_length0;		
		
		float k_length2 = k_length0 * k_length0;
		float k_length4 = k_length2 * k_length2;
		
		float kw_dot0 = k_unit.x * w_unit.x + k_unit.y * w_unit.y;
		float kw_dot2 = kw_dot0 * kw_dot0;
		float kw_dot4 = kw_dot2 * kw_dot2;
		
		float L0 = w_length2 / OceanParams.GRAVITY;
		float L2 = L0 * L0;
		
		float l2 = L2 * 0.001f * 0.001f;
		
		// ---------- //		

		float damping	= Mathf.Exp( -k_length2 * l2 );
		float phillips 	= Mathf.Exp( -1.0f / (k_length2 * L2) ) / k_length4;

		return this.settings.amplitude * phillips * kw_dot2 * damping;
	}

	// ************************************************************************ //
	// Methods ...
	// ************************************************************************ //
	
	/**
	 * gaussian random value between -1 and 1; standard diviation 1
	 */
	private Vector2 gaussianRandom( Vector2 r )
	{
		float w = 0.0f;
		
		do
		{
			r.x = 2.0f * Random.value - 1.0f;
			r.y = 2.0f * Random.value - 1.0f;
			
			w = r.x * r.x + r.y * r.y;
		}
		while( w >= 1.0f );
		
		w = Mathf.Sqrt( ( -2.0f * Mathf.Log(w) ) / w );
		
		r.x *= w;
		r.y *= w;
		
		return r;
	}

}
