package at.dotpoint.math.geom;

import at.dotpoint.math.geom.Axis.RelativeAxis;
import at.dotpoint.math.vector.IVector2;
import at.dotpoint.math.vector.IVector3;
import at.dotpoint.math.vector.Vector2;
import at.dotpoint.math.vector.Vector3;


/**
 * ...
 * @author RK
 */
class Cube
{

	public var pivot:IVector3;
	
	// -------------------- //
	
	public var min(default,null):Vector3;
	public var max(default,null):Vector3;
	
	// -------------------- //
	
	public var width	(get,set):Float;
	public var height	(get,set):Float;
	public var length	(get,set):Float;
	
	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	
	
	/**
	 * 
	 * @param	pivot	x, y relative to width, height between 0 (left, top) and 1 (right, bottom)
	 */
	public function new( ?pivot:IVector3 = null ) 
	{
		this.pivot = pivot != null ? pivot : cast RelativeAxis.TOP_LEFT_FRONT;
		
		if( this.min == null )
			this.min = new Vector3();
			
		if( this.max == null )	
			this.max = new Vector3();
	}
	
	/**
	 * 
	 * @return
	 */
	public function clone():Cube
	{
		var clone:Cube 		= new Cube();
			clone.pivot.x 	= this.pivot.x;
			clone.pivot.y 	= this.pivot.y;
			clone.pivot.z 	= this.pivot.z;
			clone.min.x 	= this.min.x;
			clone.min.y 	= this.min.y;
			clone.min.z 	= this.min.z;
			clone.max.x 	= this.max.x;
			clone.max.y 	= this.max.y;
			clone.max.z 	= this.max.z;
		
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
		var center:IVector3 = this.getPivot();
		
		this.min.x = center.x - value * this.pivot.x;
		this.max.x = center.x + value * (1 - this.pivot.x);
		
		return value; 
	}
	
	/**
	 * 
	 * @return
	 */
	private function get_height():Float { return this.max.y - this.min.y; }
	
	private function set_height( value:Float ):Float 
	{ 
		var center:IVector3 = this.getPivot();
		
		this.min.y = center.y - value * this.pivot.y;
		this.max.y = center.y + value * (1 - this.pivot.y);
		
		return value; 
	}
	
	/**
	 * 
	 * @return
	 */
	private function get_length():Float { return this.max.z - this.min.z; }
	
	private function set_length( value:Float ):Float 
	{ 
		var center:IVector3 = this.getPivot();
		
		this.min.z = center.z - value * this.pivot.z;
		this.max.z = center.z + value * (1 - this.pivot.z);
		
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
		this.min.z = 0;
		this.max.x = 0;
		this.max.y = 0;
		this.max.z = 0;
	}
	
	/**
	 * 
	 * @param	x
	 * @param	y
	 */
	public function translate( x:Float, y:Float, z:Float ):Void
	{
		this.min.x += x;
		this.min.y += y;
		this.min.z += z;
		this.max.x += x;
		this.max.y += y;
		this.max.z += z;
	}
	
	/**
	 * 
	 * @param	position
	 * @return
	 */
	public function getPivot<T:IVector3>( ?output:T ):T
	{
		return this.getPoint( this.pivot, output );
	}
	
	/**
	 * 
	 * @param	pivot	x, y relative to width, height between 0 (left, top) and 1 (right, bottom)
	 * @param	output
	 * @return
	 */
	public function getPoint<T:IVector3>( pivot:IVector3, ?output:T ):T
	{
		if( output == null )
			output = cast new Vector3();
		
		output.x = this.min.x + this.width  * pivot.x;
		output.y = this.min.y + this.height * pivot.y;
		output.z = this.min.z + this.length * pivot.z;
		
		return output;
	}
	
	/**
	 * 
	 * @param	x
	 * @param	y
	 * @return
	 */
	public function isInside( x:Float, y:Float, z:Float, ?equal:Bool = false ):Bool
	{
		if( equal )
		{
			if( x <= this.min.x )
				return false;
			
			if( y <= this.min.y )
				return false;
			
			if( z <= this.min.z )
				return false;
			
			if( x >= this.max.x )
				return false;
			
			if( y >= this.max.y )
				return false;
			
			if( z >= this.max.z )
				return false;
		}
		else
		{
			if( x <= this.min.x )
				return false;
			
			if( y <= this.min.y )
				return false;
				
			if( z <= this.min.z )
				return false;	
			
			if( x >= this.max.x )
				return false;
			
			if( y >= this.max.y )
				return false;
			
			if( z >= this.max.z )
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
		return "x:" + this.min.x + " y:" + this.min.y + " w:" + this.width + " h:" + this.height;
	}
}