package at.dotpoint.math.vector;

import at.dotpoint.math.MathUtil;


/**
 * Vector with 3 Components (x,y,z) + Homogenous (w: 0 = Direction; 1 = Point)
 * @author Gerald Hattensauer
 */
class Vector3 implements IVector3 
{

	@:isVar public var x(get, set):Float;
	@:isVar public var y(get, set):Float;
	@:isVar public var z(get, set):Float;	
	@:isVar public var w(get, set):Float; // Homogenous: 0 = Direction; 1 = Point;
	
	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	
	
	public function new( x:Float = 0, y:Float = 0, z:Float = 0, w:Float = 1 ) 
	{
		this.x = x;
		this.y = y;
		this.z = z;
		this.w = w;
	}
	
	/**
	 * typical clone, but optional instance param which will be used
	 */
	public function clone( ?output:Vector3 ):Vector3
	{
		if( output == null )
			output = new Vector3();
		
		output.x = this.x;
		output.y = this.y;
		output.z = this.z;
		output.w = this.w;
		
		return output;
	}
	
	// ************************************************************************ //
	// getter / setter
	// ************************************************************************ //	
	
	/**
	 * X
	 */
	private function get_x():Float { return this.x; }
	
	private function set_x( value:Float ):Float 
	{ 
		return this.x = value; 
	}
	
	/**
	 * Y
	 */
	private function get_y():Float { return this.y; }
	
	private function set_y( value:Float ):Float 
	{ 
		return this.y = value; 
	}
	
	/**
	 * Z
	 */
	private function get_z():Float { return this.z; }
	
	private function set_z( value:Float ):Float 
	{ 
		return this.z = value; 
	}
	
	/**
	 * W
	 */
	private function get_w():Float { return this.w; }
	
	private function set_w( value:Float ):Float 
	{ 
		return this.w = value; 
	}
	
	// ************************************************************************ //
	// Methodes
	// ************************************************************************ //	
	
	/**
	 * 
	 * @param	x
	 * @param	y
	 * @param	z
	 * @param	w
	 */
	public function set( x:Float, y:Float, z:Float, ?w:Float ):Void
	{
		this.x = x;
		this.y = y;
		this.z = z;
		
		if( w != null )
			this.w = w;
	}
	
	/**
	 * rescales each component between 0 and 1 without changing its ratio to each other
	 * [ignores the homogenous component]
	 */
	public function normalize():Void
	{
		var l:Float = this.length();
		
		if( l == 0 ) return;
		
		var k:Float = 1. / l;
		
		this.x *= k;
		this.y *= k;
		this.z *= k;
	}
	
	/** 
	 * @return length of the Vector
	 */
	public function length():Float
	{
		return Math.sqrt( this.x * this.x + this.y * this.y + this.z * this.z );
	}
	
	/** 
	 * @return squared length of the Vector
	 */
	public function lengthSq():Float
	{
		return this.x * this.x + this.y * this.y + this.z * this.z;
	}	
	
	// ************************************************************************ //
	// static Operations
	// ************************************************************************ //	
	
	/**
	 * adds the x,y and z components (a+b)
	 * outcome will be stored into output; [ignores the homogenous component]
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	public static function add<T:IVector3>( a:IVector3, b:IVector3, ?output:T = null ):T
	{
		if( output == null )
			output = cast new Vector3();
		
		output.x = a.x + b.x;
		output.y = a.y + b.y;
		output.z = a.z + b.z;	
		
		return output;
	}
	
	/**
	 * substracts the x,y and z components (a-b) 
	 * outcome will be stored into output; [ignores the homogenous component]
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	public static function subtract<T:IVector3>( a:IVector3, b:IVector3, ?output:T = null ):T
	{
		if( output == null )
			output = cast new Vector3();
		
		output.x = a.x - b.x;
		output.y = a.y - b.y;
		output.z = a.z - b.z;
		
		return output;
	}
	
	/**
	 * scales the x,y and z components by a scalar 
	 * outcome will be stored into output; [ignores the homogenous component]
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	public static function scale<T:IVector3>( a:IVector3, scalar:Float, ?output:T = null ):T
	{
		if( output == null )
			output = cast new Vector3();
		
		output.x = a.x * scalar;
		output.y = a.y * scalar;
		output.z = a.z * scalar;
		
		return output;
	}
	
	/**
	 * crossproduct between a and b; calculates the normal of the plane spanned between a and b
	 * outcome will be stored into output; not communtative (a*b != b*a); [ignores the homogenous component]
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	public static function cross<T:IVector3>( a:IVector3, b:IVector3, ?output:T = null ):T
	{
		if( output == null )
			output = cast new Vector3();
		
		#if debug
			if ( a == output || b == output ) throw "you can't use input as output for this methode";
		#end
		
		output.x = a.y * b.z - a.z * b.y;
		output.y = a.z * b.x - a.x * b.z;
		output.z = a.x * b.y - a.y * b.x;
		
		return output;
	}
	
	/**
	 * dotproduct between a and b; calculates the cosine angle between a and b
	 * [ignores the homogenous component]
	 */
	public static function dot( a:IVector3, b:IVector3 ):Float
	{
		return a.x * b.x + a.y * b.y + a.z * b.z;
	}
	
	/**
	 * Colomn Vector Multiplication (matrix * vector = vector)
	 * outcome will be stored into output
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	public static function multiplyMatrix<T:IVector3>( a:IVector3, b:IMatrix44, ?output:T = null ):T
	{
		if( output == null )
			output = cast new Vector3();
		
		var x:Float = a.x;
		var y:Float = a.y;
		var z:Float = a.z;
		var w:Float = a.w;
		
		output.x = b.m11 * x + b.m12 * y + b.m13 * z + b.m14 * w;
		output.y = b.m21 * x + b.m22 * y + b.m23 * z + b.m24 * w;
		output.z = b.m31 * x + b.m32 * y + b.m33 * z + b.m34 * w;
		output.w = b.m41 * x + b.m42 * y + b.m43 * z + b.m44 * w;
		
		return output;
	}
	
	/**
	 * 
	 */
	public static function project<T:IVector3>( a:IVector3, b:IVector3, ?output:T ):T
	{
		if( output == null )
			output = cast new Vector3();
		
		var l:Float = a.x * a.x + a.y * a.y + a.z * a.z;
		if( l == 0 ) throw "undefined result";
		
		var d:Float = Vector3.dot( a, b );
		var div:Float = d / l;
		
		return Vector3.scale( a, div, output );
	}
	 
	/**
	 * Applies Gram-Schmitt Ortho-normalization to the given set of input objects.	
	 */
	public static function orthoNormalize( vectors:Array<IVector3> ):Void 
	{
		for( i in 0...vectors.length )
		{
			var sum:Vector3 = new Vector3(); 
			
			for( j in 0...i )
			{
				var projected:Vector3 = Vector3.project( vectors[i], vectors[j] );
				Vector3.add( sum, projected, sum );
			}
			
			Vector3.subtract( vectors[i], sum, vectors[i] ).normalize();			
		}	
	}
	
	/**
	 * compares each component for equality using ZERO_TOLERANCE
	 * ignores homogenous component (just x-z)
	 * 
	 * @param	output 	true when all components are equal
	 * @return			given output object
	 */
	public static function isEqual( a:IVector3, b:IVector3 ):Bool
	{
		if ( !MathUtil.isEqual(a.x, b.x) ) return false;		
		if ( !MathUtil.isEqual(a.y, b.y) ) return false;
		if ( !MathUtil.isEqual(a.z, b.z) ) return false;
		
		return true;
	}
	
	// ************************************************************************ //
	// Array
	// ************************************************************************ //
	
	/**
	 * 
	 * @param	w
	 * @return
	 */
	public function toArray( ?w:Bool = false, ?output:Array<Float> ):Array<Float>
	{
		if( output != null )
			output = new Array<Float>();	
		
		output[0] = this.x;
		output[1] = this.y;
		output[2] = this.z;
		
		if( w )
			output[3] = this.w;
		
		return output;
	}
	
	/**
	 * 
	 * @param	index
	 * @return
	 */
	public function getIndex( index:Int ):Float
	{
		switch( index )
		{
			case 0: return this.x;
			case 1: return this.y;
			case 2: return this.z;
			case 3: return this.w;
			
			default:
				throw "out of bounds";
		}
	}
	
	/**
	 * 
	 * @param	index
	 * @param	value
	 */
	public function setIndex( index:Int, value:Float )
	{
		switch( index )
		{
			case 0: this.x = value;
			case 1: this.y = value;
			case 2: this.z = value;
			case 3: this.w = value;
			
			default:
				throw "out of bounds";
		}
	}
	
	
	// ************************************************************************ //
	// toString
	// ************************************************************************ //
	
	public function toString():String
	{
		return "[Vector3;" + this.x + ", " + this.y + ", " + this.z + ", " + this.w + "]";
	}
}