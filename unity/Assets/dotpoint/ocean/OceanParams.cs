using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class OceanParams 
{

	/**
	 * 9.81f
	 */
	public const float GRAVITY = 9.81f;

	/**
	 * 
	 */
	public Material material;

	// --------------------- //
	// --------------------- //
	
	public bool isDimensionDirty;
	
	private int m_N;
	private int m_L;
	
	private float m_N05;	// this.N * 0.5;
	private float m_L01;	// 1 / this.L;
	
	// ---------- //
	// dispertion:
	
	public bool isDispertionDirty;
	
	private float m_frequency;
	
	// ---------- //
	// spectrum:
	
	public bool isSpectrumDirty;
	
	private Vector2 m_wind;
	private float 	m_amplitude;

	// --------------------- //
	// --------------------- //
	// Dimension:

	/**
	 * sample dimension
	 */
	public int N
	{
		get
		{ 
			return this.m_N; 
		} 

		set
		{ 
			this.m_N 	= value;
			this.m_N05 	= value * 0.5f;

			this.isDimensionDirty = true;
		} 
	}

	/**
	 * simulation dimension
	 */
	public int L
	{
		get
		{ 
			return this.m_L; 
		} 
		
		set
		{ 
			this.m_L 	= value;
			this.m_L01 	= 1.0f / value;

			this.isDispertionDirty 	= true;
			this.isSpectrumDirty	= true;
		} 
	}

	// --------------------- //
	// --------------------- //
	// Dispertion:

	/**
	 * frequency
	 */
	public float frequency
	{
		get
		{ 
			return this.m_frequency; 
		} 
		
		set
		{ 
			this.m_frequency 	= value;
			this.isDispertionDirty = true;
		} 
	}

	// --------------------- //
	// --------------------- //
	// Spectrum:

	/**
	 * wind direction and magnitude
	 */
	public Vector2 wind
	{
		get
		{ 
			return this.m_wind; 
		} 
		
		set
		{ 
			this.m_wind = value;
			this.isSpectrumDirty = true;
		} 
	}

	/**
	 * maximum amplitude of a wave
	 */
	public float amplitude
	{
		get
		{ 
			return this.m_amplitude; 
		} 
		
		set
		{ 
			this.m_amplitude = value;
			this.isSpectrumDirty = true;
		} 
	}

	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	

	public OceanParams()
	{
		this.N = 64;
		this.L = 64;

		this.frequency = 200.0f;

		this.wind = new Vector2( 12.3f, 0.0f );
		this.amplitude = 0.0002f;
	}

	// ************************************************************************ //
	// Methods
	// ************************************************************************ //	

	/**
	 * 
	 */
	public Vector2 getKVector( int n, int m, Vector2 k )
	{
		k.x = this.getKComponent( n );
		k.y = this.getKComponent( m );
		
		return k;
	}

	/**
	 * 
	 */
	public float getKComponent( int n )
	{
		return 6.28318530718f * (n - this.m_N05) * this.m_L01;
	}

	/**
	 * direction and magnitude of the wind on the current position
	 */
	public Vector2 getWindVector( int n, int m )
	{
		return this.wind;
	}
}
