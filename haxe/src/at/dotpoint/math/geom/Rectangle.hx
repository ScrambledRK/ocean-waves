package at.dotpoint.math.geom;

import at.dotpoint.math.geom.Axis.RelativeAxis;
import at.dotpoint.math.vector.IVector2;
import at.dotpoint.math.vector.IVector3;
import at.dotpoint.math.vector.Vector2;

/**
 * ...
 * @author RK
 */
class Rectangle
{

	public var pivot:IVector2;
	
	// -------------------- //
	
	public var min(default,null):Vector2;
	public var max(default,null):Vector2;
	
	// -------------------- //
	
	public var width	(get,set):Float;
	public var height	(get,set):Float;
	
	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	
	
	/**
	 * 
	 * @param	pivot	x, y relative to width, height between 0 (left, top) and 1 (right, bottom)
	 */
	public function new( ?pivot:IVector2 = null ) 
	{
		this.pivot = pivot != null ? pivot : cast RelativeAxis.TOP_LEFT;
		
		if( this.min == null )
			this.min = new Vector2();
		
		if( this.max == null )	
			this.max = new Vector2();
	}
	
	/**
	 * 
	 * @return
	 */
	public function clone():Rectangle
	{
		var clone:Rectangle = new Rectangle();
			clone.pivot.x 	= this.pivot.x;
			clone.pivot.y 	= this.pivot.y;
			clone.min.x 	= this.min.x;
			clone.min.y 	= this.min.y;
			clone.max.x 	= this.max.x;
			clone.max.y 	= this.max.y;
		
		return clone;
	}
	
	// ************************************************************************ //
	// getter / setter
	// ************************************************************************ //
	
	/**
	 * 
	 * @return
	 */
	private function get_width():Float { return this.max.x - this.min.x; }
	
	private function set_width( value:Float ):Float 
	{ 
		var center:IVector2 = this.getPivot();
		
		this.min.x = center.x - value * this.pivot.x.value;
		this.max.x = center.x + value * (1 - this.pivot.x.value);
		
		return value; 
	}
	
	/**
	 * 
	 * @return
	 */
	private function get_height():Float { return this.max.y - this.min.y; }
	
	private function set_height( value:Float ):Float 
	{ 
		var center:IVector2 = this.getPivot();
		
		this.min.y = center.y - value * this.pivot.y.value;
		this.max.y = center.y + value * (1 - this.pivot.y.value);
		
		return value; 
	}
	
	// ************************************************************************ //
	// Methodes
	// ************************************************************************ //
	
	/**
	 * 
	 */
	public function setZero():Void
	{
		this.min.x = 0;
		this.min.y = 0;
		this.max.x = 0;
		this.max.y = 0;
	}
	
	/**
	 * 
	 * @param	x
	 * @param	y
	 */
	public function translate( x:Float, y:Float ):Void
	{
		this.min.x += x;
		this.min.y += y;
		this.max.x += x;
		this.max.y += y;
	}
	
	/**
	 * 
	 * @param	position
	 * @return
	 */
	public function getPivot<T:IVector2>( ?output:T ):T
	{
		return this.getPoint( this.pivot, output );
	}
	
	/**
	 * 
	 * @param	pivot	x, y relative to width, height between 0 (left, top) and 1 (right, bottom)
	 * @param	output
	 * @return
	 */
	public function getPoint<T:IVector2>( pivot:IVector2, ?output:T ):T
	{
		if( output == null )
			output = cast new Vector2();
		
		output.x = this.min.x + this.width * pivot.x.value;
		output.y = this.min.y + this.height * pivot.y.value;
		
		return output;
	}
	
	/**
	 * 
	 * @param	x
	 * @param	y
	 * @return
	 */
	public function isInside( x:Float, y:Float, ?equal:Bool = false ):Bool
	{
		if( equal )
		{
			if( x <= this.min.x )
				return false;
			
			if( y <= this.min.y )
				return false;
			
			if( x >= this.max.x )
				return false;
				
			if( y >= this.max.y )
				return false;
		}
		else
		{
			if( x <= this.min.x )
				return false;
			
			if( y <= this.min.y )
				return false;
			
			if( x >= this.max.x )
				return false;
				
			if( y >= this.max.y )
				return false;
		}
		
		return true;
	}
	
	/**
	 * 
	 * @return
	 */
	public function toString():String
	{
		return "x:" + this.x + " y:" + this.y + " w:" + this.width + " h:" + this.height;
	}
}