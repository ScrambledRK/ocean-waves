using UnityEngine;
using System.Collections;

public class FFT
{
	private int m_size;
	private int m_passes;

	private float 	m_fsize;
	private float[] m_butterflyLookupTable = null;

	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	

	public FFT()
	{	
		//
	}

	public void init( int size )
	{
		if( !Mathf.IsPowerOfTwo(size) )
		{
			Debug.Log("FourierCPU::FourierCPU - fourier grid size must be pow2 number, changing to nearest pow2 number");
			size = Mathf.NextPowerOfTwo(size);
		}
		
		this.m_size 	= size; 
		this.m_fsize 	= (float) this.m_size;
		this.m_passes 	= (int) ( Mathf.Log( this.m_fsize ) / Mathf.Log( 2.0f ) );
		
		this.ComputeButterflyLookupTable();
	}

	// ************************************************************************ //
	// Initial
	// ************************************************************************ //	

	/**
	 * 
	 */
	private void ComputeButterflyLookupTable()
	{
		this.m_butterflyLookupTable = new float[ this.m_size * this.m_passes * 4 ];
		
		for( int i = 0; i < this.m_passes; i++ ) 
		{
			int nBlocks  = (int) Mathf.Pow( 2, this.m_passes - 1 - i );
			int nHInputs = (int) Mathf.Pow( 2, i );
			
			for( int j = 0; j < nBlocks; j++ )
			{
				for( int k = 0; k < nHInputs; k++ ) 
				{
					int i1, i2, j1, j2;

					if (i == 0) 
					{
						i1 = j * nHInputs * 2 + k;
						i2 = j * nHInputs * 2 + nHInputs + k;
						j1 = this.BitReverse(i1);
						j2 = this.BitReverse(i2);
					} 
					else 
					{
						i1 = j * nHInputs * 2 + k;
						i2 = j * nHInputs * 2 + nHInputs + k;
						j1 = i1;
						j2 = i2;
					}

					// ------------- //

					float omega = 2.0f * Mathf.PI * (float)( k * nBlocks ) / this.m_fsize;

					float wr = Mathf.Cos( omega );
					float wi = Mathf.Sin( omega );
					
					int offset1 = 4 * (i1 + i * this.m_size);
					this.m_butterflyLookupTable[offset1 + 0] = j1; 
					this.m_butterflyLookupTable[offset1 + 1] = j2;
					this.m_butterflyLookupTable[offset1 + 2] = wr;
					this.m_butterflyLookupTable[offset1 + 3] = wi;
					
					int offset2 = 4 * (i2 + i * this.m_size);
					this.m_butterflyLookupTable[offset2 + 0] = j1;
					this.m_butterflyLookupTable[offset2 + 1] = j2;
					this.m_butterflyLookupTable[offset2 + 2] = -wr;
					this.m_butterflyLookupTable[offset2 + 3] = -wi;
					
				}
			}
		}
	}

	/**
	 * 
	 */
	private int BitReverse( int i )
	{
		int j 	= i;
		int Sum = 0;
		int W 	= 1;
		int M 	= this.m_size / 2;

		while( M != 0 ) 
		{
			j = ((i&M) > M-1) ? 1 : 0;

			Sum += j * W;

			W *= 2;
			M /= 2;
		}

		return Sum;
	}

	// ************************************************************************ //
	// Initial
	// ************************************************************************ //	

	/**
	 * FFT with Vector2
	 */
	public int PeformFFT2( int startIdx, Vector2[,] data )
	{
		int x; 
		int y; 
		int i;

		int idx = 0; 
		int idx1; 
		int bftIdx;

		int X; 
		int Y;

		Vector2 w;
		
		int j = startIdx;

		// -------------------- //

		for( i = 0; i < this.m_passes; i++, j++ ) 
		{
			idx 	= j%2;
			idx1 	= ( j + 1 )%2;
			
			for( x = 0; x < this.m_size; x++ )
			{
				for( y = 0; y < this.m_size; y++ )
				{
					bftIdx = 4 * ( x + i * this.m_size );
					
					X 	= (int) this.m_butterflyLookupTable[ bftIdx + 0] ;
					Y 	= (int) this.m_butterflyLookupTable[ bftIdx + 1 ];
					w.x = this.m_butterflyLookupTable[ bftIdx + 2 ];
					w.y = this.m_butterflyLookupTable[ bftIdx + 3 ];
					
					data[ idx, x + y * this.m_size ] = this.setFFT2( w, data[ idx1, X + y * this.m_size ], data[ idx1, Y + y * this.m_size ] );
				}
			}
		}

		// -------------------- //

		for( i = 0; i < this.m_passes; i++, j++ ) 
		{
			idx 	= j % 2;
			idx1 	= ( j + 1 ) % 2;
			
			for( x = 0; x < this.m_size; x++ )
			{
				for( y = 0; y < this.m_size; y++ )
				{
					bftIdx = 4 * ( y + i * this.m_size );
					
					X 	= (int) this.m_butterflyLookupTable[ bftIdx + 0 ];
					Y 	= (int) this.m_butterflyLookupTable[ bftIdx + 1 ];
					w.x = this.m_butterflyLookupTable[ bftIdx + 2 ];
					w.y = this.m_butterflyLookupTable[ bftIdx + 3 ];
					
					data[ idx, x + y * this.m_size ] = this.setFFT2( w, data[ idx1, x + X * this.m_size ], data[ idx1, x + Y * this.m_size ] );
				}
			}
		}
		
		return idx;
	}

	/**
	 * FFT with Vector4 (2x Vector2 at once ...)
	 */
	public int PeformFFT4(int startIdx, Vector4[,] data)
	{
		int x; 
		int y; 
		int i;
		
		int idx = 0; 
		int idx1; 
		int bftIdx;
		
		int X; 
		int Y;
		
		Vector2 w;
		
		int j = startIdx;
		
		// -------------------- //
		
		for( i = 0; i < this.m_passes; i++, j++ ) 
		{
			idx 	= j%2;
			idx1 	= ( j + 1 )%2;
			
			for( x = 0; x < this.m_size; x++ )
			{
				for( y = 0; y < this.m_size; y++ )
				{
					bftIdx = 4 * ( x + i * this.m_size );
					
					X 	= (int) this.m_butterflyLookupTable[ bftIdx + 0] ;
					Y 	= (int) this.m_butterflyLookupTable[ bftIdx + 1 ];
					w.x = this.m_butterflyLookupTable[ bftIdx + 2 ];
					w.y = this.m_butterflyLookupTable[ bftIdx + 3 ];
					
					data[ idx, x + y * this.m_size ] = this.setFFT4( w, data[ idx1, X + y * this.m_size ], data[ idx1, Y + y * this.m_size ] );
				}
			}
		}
		
		// -------------------- //
		
		for( i = 0; i < this.m_passes; i++, j++ ) 
		{
			idx 	= j % 2;
			idx1 	= ( j + 1 ) % 2;
			
			for( x = 0; x < this.m_size; x++ )
			{
				for( y = 0; y < this.m_size; y++ )
				{
					bftIdx = 4 * ( y + i * this.m_size );
					
					X 	= (int) this.m_butterflyLookupTable[ bftIdx + 0 ];
					Y 	= (int) this.m_butterflyLookupTable[ bftIdx + 1 ];
					w.x = this.m_butterflyLookupTable[ bftIdx + 2 ];
					w.y = this.m_butterflyLookupTable[ bftIdx + 3 ];
					
					data[ idx, x + y * this.m_size ] = this.setFFT4( w, data[ idx1, x + X * this.m_size ], data[ idx1, x + Y * this.m_size ] );
				}
			}
		}
		
		return idx;
	}

	/**
	 * Performs two FFTs on two complex numbers packed in a vector4
	 */
	private Vector4 setFFT4(Vector2 w, Vector4 input1, Vector4 input2) 
	{
		input1.x += w.x * input2.x - w.y * input2.y;
		input1.y += w.y * input2.x + w.x * input2.y;
		input1.z += w.x * input2.z - w.y * input2.w;
		input1.w += w.y * input2.z + w.x * input2.w;
		
		return input1;
	}

	/**
	 * Performs one FFT on a complex number
	 */
	private Vector2 setFFT2(Vector2 w, Vector2 input1, Vector2 input2) 
	{
		input1.x += w.x * input2.x - w.y * input2.y;
		input1.y += w.y * input2.x + w.x * input2.y;
		
		return input1;
	}
	
}
