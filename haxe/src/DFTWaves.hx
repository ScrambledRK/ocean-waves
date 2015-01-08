package ;

import at.dotpoint.math.Limit;
import at.dotpoint.math.vector.Vector2;

/**
 * ...
 * @author RK
 */
class DFTWaves
{

	
	/**
	 * 
	 */
	public var vertices:Array<Array<Vertex>>;
	
	/**
	 * 
	 */
	public var windField:VectorField;
	
	// ----------- //
	
	/**
	 * sample dimension
	 */
	private var N:Int		= 64;
	private var M:Int		= 64;
	
	/**
	 * simulation dimension
	 */
	private var LN:Float 	= 64;		
	private var LM:Float 	= 64;
	
	// ----------- //
	
	private var gravity:Float 		= 9.81;
	private var frequency:Float 	= 200;
	
	private var maxAmplitude:Float 	= 0.0005;
	
	// ----------- //
	// shortcut:
	
	private var N05:Int;
	private var M05:Int;
	
	private var LN1:Float;
	private var LM1:Float;
	
	// -------------------------- //
	// -------------------------- //
	
	/**
	 * reusable vector instance
	 */
	private var tmpVector2_1:Vector2;
	private var tmpVector2_2:Vector2;
	private var tmpVector2_3:Vector2;
	private var tmpVector2_4:Vector2;
	
	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	
	
	public function new( wind:VectorField ) 
	{
		this.windField = wind;
		
		this.tmpVector2_1 = new Vector2();
		this.tmpVector2_2 = new Vector2();
		this.tmpVector2_3 = new Vector2();
		this.tmpVector2_4 = new Vector2();
	}
	
	// ************************************************************************ //
	// Initial
	// ************************************************************************ //	
	
	/**
	 * 
	 */
	public function init():Void
	{
		this.N = Std.int( this.windField.plotRange.width  );
		this.M = Std.int( this.windField.plotRange.height );
		
		this.N05 = Std.int( this.N * 0.5 );
		this.M05 = Std.int( this.M * 0.5 );
		
		this.LN1 = 1 / this.LN;
		this.LM1 = 1 / this.LM;		
		
		// ----------------- //
		
		this.vertices = new Array<Array<Vertex>>();		
		
		var NL:Float = this.LN / this.N;
		var ML:Float = this.LM / this.M;
		
		var k_norm:Vector2 = new Vector2();
		var k_conj:Vector2 = new Vector2();
		
		// ----------------- //
		
		var min_n:Vector2 = new Vector2( Limit.FLOAT_MAX, Limit.FLOAT_MAX );
		var min_c:Vector2 = new Vector2( Limit.FLOAT_MAX, Limit.FLOAT_MAX );
		
		var max_n:Vector2 = new Vector2( Limit.FLOAT_MIN, Limit.FLOAT_MIN );
		var max_c:Vector2 = new Vector2( Limit.FLOAT_MIN, Limit.FLOAT_MIN );
		
		for( n in 0...this.N + 1 )
		{		
			this.vertices[n] = new Array<Vertex>();
			
			for( m in 0...this.M + 1 )
			{
				k_norm = this.getK(  n,  m, k_norm );
				k_conj = this.getK( -n, -m, k_conj );
				
				var vertex:Vertex = new Vertex();
					vertex.position.x = (n - this.N05) * NL; // -0.5 ... 0.5
					vertex.position.y = (m - this.M05) * ML;				
				
				this.h0( n, m, k_norm, 	vertex.c_h0_norm );
				this.h0( n, m, k_conj, 	vertex.c_h0_conj );	
				
				vertex.c_h0_conj.y *= -1; // complex conjungate again
				
				this.vertices[n][m] = vertex;
				
				if( vertex.c_h0_norm.x < min_n.x || vertex.c_h0_norm.y < min_n.y )
				{
					min_n = vertex.c_h0_norm;
				}
				
				if( vertex.c_h0_conj.x < min_c.x || vertex.c_h0_conj.y < min_c.y )
				{
					min_c = vertex.c_h0_conj;
				}
				
				if( vertex.c_h0_norm.x > max_n.x || vertex.c_h0_norm.y > max_n.y )
				{
					max_n = vertex.c_h0_norm;
				}
				
				if( vertex.c_h0_conj.x > max_c.x || vertex.c_h0_conj.y > max_c.y )
				{
					max_c = vertex.c_h0_conj;
				}
			}
		}
		
		trace( min_n, min_c );
		trace( max_n, max_c );
	}
	
	/**
	 * ( 1 / sqrt(2) ) * ( random() + i * random() ) * sqrt( philips( k ) )
	 * 
	 * @param	n
	 * @param	m
	 * @param	output
	 * @return
	 */
	private function h0( n:Int, m:Int, k:Vector2, output:Vector2 ):Vector2
	{
		var scale:Float = Math.sqrt( this.phillips( n, m, k ) / 2.0 ); 	// philips( k ) * sqrt(1/2);
		
		var c_r:Vector2 = this.gaussianRandom( output );				// random() + i * random();				
			c_r.x *= scale;
			c_r.y *= scale;
			
		if( Math.isNaN( c_r.x ) || Math.isNaN( c_r.y ) )
			trace( c_r, scale );
		
		return c_r;
	}
	
	/**
	 * ( A * exp( -1 / ( k.length * max )^2 ) / k.length^4 ) * (|dot(k,w)|)^2 [* dampening ...]
	 * 
	 * @param	k
	 * @return
	 */
	private function phillips( n:Int, m:Int, k:Vector2 ):Float
	{
		var k_length0:Float = k.length();
		
		if( k_length0 < 0.000001 )
			return 0.0;
		
		// ---------- //
		
		var w:Vector2 = this.getWind( n, m );	// wind direction
		
		var k_unit:Vector2 = k.clone();
			k_unit.normalize();
			
		var w_unit:Vector2 = w.clone();
			w_unit.normalize();
			
		// ---------- //
		
		var w_length0:Float = w.length();
		var w_length2:Float = w_length0 * w_length0;		
		
		var k_length2:Float = k_length0 * k_length0;
		var k_length4:Float = k_length2 * k_length2;
		
		var kw_dot0:Float = k_unit.x * w_unit.x + k_unit.y * w_unit.y;
		var kw_dot2:Float = kw_dot0 * kw_dot0;
		
		var L0:Float = w_length2 / this.gravity;
		var L2:Float = L0 * L0;
		
		var l2:Float = L2 * 0.001 * 0.001;
		
		// ---------- //		
		
		return this.maxAmplitude * ( Math.exp( -1.0 / (k_length2 * L2) ) / k_length4 ) * kw_dot2 * Math.exp( -k_length2 * l2 );
	}
	
	// ************************************************************************ //
	// Calculation
	// ************************************************************************ //	
	
	/**
	 * h( x, t ) = sum(k,N,M){ h0(k) * exp( i * w(k) * t ) + h0*(-k) * exp( -i * w(k) * t ) };
	 * 
	 * @param	x position
	 * @param	t time
	 */
	public function calculate( c:Vector2, t:Float, output:WaveOutput ):WaveOutput
	{
		var k:Vector2 	= this.tmpVector2_1;
		var x:Vector2 	= this.tmpVector2_2;
		
		var h:Vector2 	= output.height;
		var d:Vector2 	= output.displacement;
		var n:Vector2 	= output.normal;
		
		x.x = this.vertices[Std.int(c.x)][Std.int(c.y)].position.x;
		x.y = this.vertices[Std.int(c.x)][Std.int(c.y)].position.y;
		
		h.set( 0, 0 );
		
		// ------------- //
		
		for( n in 0...this.N )
		{				
			for( m in 0...this.M )
			{
				k = this.getK( n, m, k );
				
				// ---------------- //
				
				var dot_kx:Float = k.x * x.x + k.y * x.y;		// dot( k, x );
				
				var c_cos:Float  = Math.cos( dot_kx );			// exp( i * dot(k,x) ); ... euler sin/cos
				var c_sin:Float  = Math.sin( dot_kx );
				
				var c_ht:Vector2 = this.ht( n, m, k, t );		// h0(k) * exp( i * w(k) * t ) + h0*(-k) * exp( -i * w(k) * t );
				
				// ---------------- //
				
				h.x += c_ht.x * c_cos - c_ht.y * c_sin;			// h~(k,t) * exp( i * dot(k,x) );
				h.y += c_ht.x * c_sin + c_ht.y * c_cos; 		// complex( x1*x2 - y1*y2, x1*y2 + y1*x2 );				
				
			}
		}
		
		return output;
	}
	
	/**
	 * h~(x,t) = h0(k) * exp( i * w(k) * t ) + h0'(-k) * exp( -i * w(k) * t );
	 * 
	 * @param	k
	 * @param	t
	 * @return
	 */
	private function ht( n:Int, m:Int, k:Vector2, t:Float ):Vector2
	{
		var c_h:Vector2 = this.tmpVector2_3;
		
		// ------------ //
		
		var h01:Vector2 = this.vertices[n][m].c_h0_norm;		// h0(k);
		var h02:Vector2 = this.vertices[n][m].c_h0_conj;		// h0'(-k) ... conjungat of h0;
		
		var w:Float = this.dispertion( k ) * t;					// w(k) * t;
		
		// ------------ //
		
		var cos:Float = Math.cos( w );
		var sin:Float = Math.sin( w );
		
		var mcos:Float = Math.cos( -w );
		var msin:Float = Math.sin( -w );
		
		c_h.x = ( h01.x * cos - h01.y * sin ) + ( h02.x * mcos - h02.y * msin ); // h0 * exp(i * w * t) + h0' * exp(-i * w * t)  ... -i!
		c_h.y = ( h01.x * sin + h01.y * cos ) + ( h02.x * msin + h02.y * mcos ); // complex( x1*x2 - y1*y2, x1*y2 + y1*x2 ); ... euler sin/cos
		
		/*if( Math.isNaN( c_h.x ) || Math.isNaN( c_h.y ) )
			trace( h01, h02, w );*/
		
		return c_h;
	}	
	
	/**
	 * 
	 * @param	k
	 * @return
	 */
	private function dispertion( k:Vector2 ):Float
	{
		var w0:Float = 6.28318530718 / this.frequency;
		var wk:Float = Math.sqrt( this.gravity * Math.sqrt( k.x * k.x + k.y * k.y ) );
		
		return Std.int( wk / w0 ) * w0;
	}
	
	// ************************************************************************ //
	// Helper
	// ************************************************************************ //	
	
	/**
	 * 
	 * @param	n
	 * @param	m
	 * @param	k
	 * @return
	 */
	inline private function getK( n:Int, m:Int, k:Vector2 ):Vector2
	{
		k.x = 6.28318530718 * (n - this.N05) * this.LN1;
		k.y = 6.28318530718 * (m - this.M05) * this.LM1;
		
		return k;
	}
	
	/**
	 * 
	 * @return
	 */
	private function gaussianRandom( r:Vector2 ):Vector2
	{
		var w:Float = 0;
		
		do
		{
			r.x = 2.0 * Math.random() - 1.0;
			r.y = 2.0 * Math.random() - 1.0;
			
			w = r.x * r.x + r.y * r.y;
		}
		while( w >= 1.0 );
		
		w = Math.sqrt( ( -2.0 * Math.log(w) ) / w );
		
		r.x *= w;
		r.y *= w;
		
		return r;
	}

	/**
	 * 
	 * @param	n
	 * @param	m
	 * @return
	 */
	private function getWind( n:Int, m:Int ):Vector2
	{
		this.tmpVector2_4.x = this.windField.field[n][m].x * 32;
		this.tmpVector2_4.y = this.windField.field[n][m].y * 32;
		
		/*this.tmpVector2_4.x = 32.0;
		this.tmpVector2_4.y = 0.0;*/
		
		return this.tmpVector2_4; //;
	}	
	
}