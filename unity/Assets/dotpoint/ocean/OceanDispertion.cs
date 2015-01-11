using UnityEngine;
using System.Collections;

/**
 * more or less the speed of water on a given point based on depth/shallowness, gravity and frequency
 */
public class OceanDispertion
{

	/**
	 * ocean settings
	 */
	public OceanParams settings;

	/**
	 * lookup
	 */
	public float[,] dispertion;

	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	
	
	public OceanDispertion( OceanParams settings ) 
	{		
		this.settings = settings;
	}

	/**
	 * 
	 */
	public void init()
	{
		Debug.Log( "init dispertion" );

		this.dispertion = new float[ this.settings.N + 1, this.settings.N + 1 ];
		this.update();
	}

	// ************************************************************************ //
	// Calculate
	// ************************************************************************ //	

	/**
	 * 
	 */
	public void update()
	{
		float w0 = 2.0f * Mathf.PI / this.settings.frequency;
		
		// ------------ //
		
		for( int n = 0; n < this.settings.N + 1; n++ ) 
		{
			for( int m = 0; m < this.settings.N + 1; m++ ) 
			{
				this.dispertion[ n, m ] = Mathf.Floor( this.calculate( n, m ) / w0 ) * w0;
			}
		}
	}

	/**
	 * 
	 */
	private float calculate( int n, int m ) 
	{
		float kx = this.settings.getKComponent( n );
		float ky = this.settings.getKComponent( m );

		float depth = this.getDepth( n, m );

		return Mathf.Sqrt( OceanParams.GRAVITY * Mathf.Sqrt(kx * kx + ky * ky) * depth );
	}

	/**
	 * 
	 */
	private float getDepth( int n, int m )
	{
		return 1.0f;		
	}

}
