using UnityEngine;

using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
//
public class ocean : MonoBehaviour 
{

	/**
	 * sample dimension
	 */
	[Range(4, 256)] 
	public int N = 64;

	[Range(4, 256)] 
	public int M = 64;

	// ------------ //

	private float 	gravity 		= 9.81f;
	private float 	maxAmplitude 	= 0.0005f;

	public Vector2 	wind 			= new Vector2( 32.3f, 0.3f );

	// ------------ //

	/**
	 * simulation dimension
	 */
	[Range(4, 256)] 
	public int LN = 64;

	[Range(4, 256)] 
	public int LM = 64;

	// ************************************************************************ //
	// Initial
	// ************************************************************************ //	

	/**
	 * 
	 */
	void Start () 
	{
		Mesh 		mesh 		= GetComponent<MeshFilter>().mesh;

		Vector3[] 	vertices 	= mesh.vertices;
		Vector3[] 	pos_ver		= new Vector3[vertices.Length];
	
		// ------------------------ //

		float w = mesh.bounds.extents.x * 2;
		float h = mesh.bounds.extents.y * 2;


		if( this.N == 0 )
			this.N = (int)( w );

		if( this.N == 0 )
			this.M = (int)( h );

		if( this.LN == 0 )
			this.LN = this.N;
	
		if( this.LM == 0 )
			this.LM = this.M;

		// ------------------------ //

		Texture2D 	texture = new Texture2D( this.N * 2, this.M * 2 );
					texture.filterMode = FilterMode.Point;
					texture.anisoLevel = 1;

		this.renderer.material.mainTexture = texture;

		// ------------------------ //

		Vector2 k_norm 		= new Vector2();
		Vector2 k_conj 		= new Vector2();

		for( int i = 0; i < vertices.Length; i++ ) 
		{
			Vector3 position = vertices[i];

			int n = (int)( ((position.x / w) + 0.5f ) * this.N );
			int m = (int)( ((position.y / h) + 0.5f ) * this.M );
			
			// ----------------------- //

			k_norm = this.getK(  n,  m, k_norm );	// h0
			k_conj = this.getK( -n, -m, k_conj );	// conjungat of complex h0

			Vector2 c_h0_norm = this.h0( n, m, k_norm );
			Vector2 c_h0_conj = this.h0( n, m, k_conj );
					c_h0_conj.y *= -1f;

			// ----------------------- //

			this.encodeH0Signed( n, m, c_h0_norm, c_h0_conj, texture );

			// ----------------------- //

			float x = (n - this.N * 0.5f) * this.LN / this.N;
			float y = (m - this.M * 0.5f) * this.LM / this.M;

			pos_ver[i] = new Vector3( x, y );
		}

		// ------------------------ //

		//mesh.vertices = pos_ver;
		texture.Apply(false);
	}

	/**
	 * 
	 */
	private Vector2 getK( int n, int m, Vector2 k )
	{
		k.x = 6.28318530718f * (n - this.N * 0.5f) / this.LN;
		k.y = 6.28318530718f * (m - this.M * 0.5f) / this.LM;

		return k;
	}

	/**
	 * ( 1 / sqrt(2) ) * ( random() + i * random() ) * sqrt( philips( k ) )
	 */
	private Vector2 h0( int n, int m, Vector2 k )
	{
		float scale = Mathf.Sqrt( this.phillips( n, m, k ) / 2.0f ); 	// philips( k ) * sqrt(1/2);
		
		Vector2 c_h0 = this.gaussianRandom( new Vector2() );			// random() + i * random();	
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
		
		Vector2 w = this.getWind( n, m );	// wind direction
		
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
		
		float L0 = w_length2 / this.gravity;
		float L2 = L0 * L0;
		
		float l2 = L2 * 0.001f * 0.001f;

		// ---------- //		
		
		return this.maxAmplitude * ( Mathf.Exp( -1.0f / (k_length2 * L2) ) / k_length4 ) * kw_dot4 * Mathf.Exp( -k_length2 * l2 );
	}

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

	/**
	 * direction and magnitude of the wind on the current position
	 */
	private Vector2 getWind( int n, int m )
	{
		return this.wind;
	}

	// ************************************************************************ //
	// ENCODING
	// ************************************************************************ //	

	/**
	 * 
	 */
	private void encodeH0Unsigned( int n, int m, Vector2 c_h0_norm, Vector2 c_h0_conj, Texture2D texture )
	{
		float[] h_nx = this.EncodeFloatRGBA( 0.5f + c_h0_norm.x * 0.5f );
		float[] h_ny = this.EncodeFloatRGBA( 0.5f + c_h0_norm.y * 0.5f );
		float[] h_cx = this.EncodeFloatRGBA( 0.5f + c_h0_conj.x * 0.5f );
		float[] h_cy = this.EncodeFloatRGBA( 0.5f + c_h0_conj.y * 0.5f );
		
		// ------------------------ //
		// top left: h0_norm.x
		
		Color 	h0_nx_color = new Color();
		h0_nx_color.r = h_nx[0];
		h0_nx_color.g = h_nx[1];
		h0_nx_color.b = h_nx[2];
		h0_nx_color.a = h_nx[3];
		
		texture.SetPixel( n, m, h0_nx_color );
		
		// ------------------------ //
		// top right: h0_norm.y
		
		Color 	h0_ny_color = new Color();
		h0_ny_color.r = h_ny[0];
		h0_ny_color.g = h_ny[1];
		h0_ny_color.b = h_ny[2];
		h0_ny_color.a = h_ny[3];
		
		texture.SetPixel( n + this.N, m, h0_ny_color );
		
		// ------------------------ //
		// bottom left: h0_conj.x
		
		Color 	h0_cx_color = new Color();
		h0_cx_color.r = h_cx[0];
		h0_cx_color.g = h_cx[1];
		h0_cx_color.b = h_cx[2];
		h0_cx_color.a = h_cx[3];
		
		texture.SetPixel( n, m + this.M, h0_cx_color );
		
		// ------------------------ //
		// bottom right: h0_conj.y
		
		Color 	h0_cy_color = new Color();
		h0_cy_color.r = h_cy[0];
		h0_cy_color.g = h_cy[1];
		h0_cy_color.b = h_cy[2];
		h0_cy_color.a = h_cy[3];
		
		texture.SetPixel( n + this.N, m + this.M, h0_cy_color );
	}
	
	/**
	 * 
	 */
	private void encodeH0Signed( int n, int m, Vector2 c_h0_norm, Vector2 c_h0_conj, Texture2D texture )
	{
		// ------------------------ //
		// top left: h0_norm.x		
		
		texture.SetPixel( n, m, this.EncodeFloatInColor( c_h0_norm.x ) );
		
		// ------------------------ //
		// top right: h0_norm.y		
		
		texture.SetPixel( n + this.N, m, this.EncodeFloatInColor( c_h0_norm.y ) );
		
		// ------------------------ //
		// bottom left: h0_conj.x		
		
		texture.SetPixel( n, m + this.M, this.EncodeFloatInColor( c_h0_conj.x ) );
		
		// ------------------------ //
		// bottom right: h0_conj.y
		
		texture.SetPixel( n + this.N, m + this.M, this.EncodeFloatInColor( c_h0_conj.y ) );
	}

	/**
	 * 
	 */
	float[] EncodeFloatRGBA( float val )
	{
		float[] kEncodeMul = new float[]{ 1.0f, 255.0f, 65025.0f, 160581375.0f };
		float kEncodeBit = 1.0f / 255.0f; 

		for( int i = 0; i < kEncodeMul.Length; ++i )
		{
			kEncodeMul[i] *= val;
			kEncodeMul[i] = ( float )( kEncodeMul[i] - (int)( kEncodeMul[i] ) );
		}
		
		// enc -= enc.yzww * kEncodeBit;
		float[] yzww = new float[] { kEncodeMul[1], kEncodeMul[2], kEncodeMul[3], kEncodeMul[3] };

		for( int i = 0; i < kEncodeMul.Length; ++i )
		{
			kEncodeMul[i] -= yzww[i] * kEncodeBit;
		}
		
		return kEncodeMul;
	}

	/**
	 * 
	 */
	private Color EncodeFloatInColor(float scalar)
	{
		byte[] floatBytes = System.BitConverter.GetBytes(scalar);
		return new Color32(floatBytes[3], floatBytes[2], floatBytes[1], floatBytes[0]);
	}
	
	/**
	 * 
	 */
	void Update () 
	{
		
	}
}
