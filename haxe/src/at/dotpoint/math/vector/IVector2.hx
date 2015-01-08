package at.dotpoint.math.vector;

/**
 * ...
 * @author Gerald Hattensauer
 */

interface IVector2 
{

	public var x(get, set):Float;
	public var y(get, set):Float;
	
	public function normalize():Void;
	public function length():Float;
}