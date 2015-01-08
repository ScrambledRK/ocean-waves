package at.dotpoint.math.vector;


/**
 * Vector with 2 Components (x,y)
 * @author Gerald Hattensauer
 */
class Vector2 implements IVector2 
{

	@:isVar public var x(get, set):Float;
	@:isVar public var y(get, set):Float;
	
	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	
	
	public function new( x:Float = 0, y:Float = 0 ) 
	{
		this.x = x;
		this.y = y;
	}
	
	/**
	 * typical clone, but optional instance param which will be used
	 */
	public function clone( ?output:Vector2 ):Vector2
	{
		output = output != null ? output : new Vector2();
		
		output.x = this.x;
		output.y = this.y;
		
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
	
	// ************************************************************************ //
	// Methodes
	// ************************************************************************ //	
	
	/**
	 * 
	 * @param	x
	 * @param	y
	 * @param	z
	 * @param	?w
	 */
	public function set( x:Float, y:Float ):Void
	{
		this.x = x;
		this.y = y;
	}
	
	/**
	 * rescales each component between 0 and 1 without changing its ratio to each other
	 * [ignores the homogenous component]
	 */
	public function normalize():Void
	{
		var l:Float = this.length();
		
		if( l == 0 )
		{
			this.x = 0;
			this.y = 0;
		}
		else
		{
			var k:Float = 1. / this.length();
			
			this.x *= k;
			this.y *= k;
		}	
	}
	
	/** 
	 * @return length of the Vector
	 */
	public function length():Float
	{
		return Math.sqrt( this.x * this.x + this.y * this.y );
	}
	
	/** 
	 * @return squared length of the Vector
	 */
	public function lengthSq():Float
	{
		return this.x * this.x + this.y * this.y;
	}
	
	// ************************************************************************ //
	// static Operations
	// ************************************************************************ //	
	
	/**
	 * adds the x,y components (a+b)
	 * outcome will be stored into output;
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	public static function add<T:IVector2>( a:IVector2, b:IVector2, ?output:T = null ):T
	{
		if( output == null ) 
			output = cast new Vector2();
		
		output.x = a.x + b.x;
		output.y = a.y + b.y;
		
		return output;
	}
	
	/**
	 * substracts the x,y components (a-b) 
	 * outcome will be stored into output;
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	public static function subtract<T:IVector2>( a:IVector2, b:IVector2, ?output:T = null ):T
	{
		if( output == null ) 
			output = cast new Vector2();
		
		output.x = a.x - b.x;
		output.y = a.y - b.y;
		
		return output;
	}
	
	/**
	 * scales the x,y components by a scalar 
	 * outcome will be stored into output;
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	public static function scale<T:IVector2>( a:IVector2, scalar:Float, ?output:T = null ):T
	{
		if( output == null ) 
			output = cast new Vector2();
		
		output.x = a.x * scalar;
		output.y = a.y * scalar;
		
		return output;
	}
	
	/**
	 * compares each component for equality using ZERO_TOLERANCE
	 * ignores homogenous component (just x-z)
	 * 
	 * @param	output 	true when all components are equal
	 * @return			given output object
	 */
	public static function isEqual( a:IVector2, b:IVector2 ):Bool
	{
		if ( !MathUtil.isEqual(a.x, b.x) ) return false;		
		if ( !MathUtil.isEqual(a.y, b.y) ) return false;
		
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
	public function toArray( ?output:Array<Float> ):Array<Float>
	{
		if( output != null )
			output = new Array<Float>();	
		
		output[0] = this.x;
		output[1] = this.y;
		
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
			
			default:
				throw "out of bounds";
		}
	}
	
	// ************************************************************************ //
	// toString
	// ************************************************************************ //	
	
	/**
	 * 
	 * @return
	 */
	public function toString():String
	{
		return "[Vector2;" + this.x + ", " + this.y + "]";
	}
}