package at.dotpoint.math.vector;

/**
 * ...
 * @author Gerald Hattensauer
 */

interface IMatrix44 extends IMatrix33 
{
	public var m14:Float;
	public var m24:Float;
	public var m34:Float;
	
	public var m41:Float; public var m42:Float; public var m43:Float; public var m44:Float; 	
	
	/**
	 * takes the same value as the given matrix
	 */
	public function set44( m:IMatrix44 ):Void;
}