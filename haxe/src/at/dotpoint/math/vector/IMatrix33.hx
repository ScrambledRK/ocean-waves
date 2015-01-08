package at.dotpoint.math.vector;

/**
 * ...
 * @author Gerald Hattensauer
 */

interface IMatrix33
{

	public var m11:Float; public var m12:Float; public var m13:Float;
	public var m21:Float; public var m22:Float; public var m23:Float;
	public var m31:Float; public var m32:Float; public var m33:Float;
	
	/**
	 * Diagonal will be set to 1, rest to 0
	 */
	public function toIdentity():Void;
	
	/**
	 * switches rows to colums and vice versa
	 */
	public function transpose():Void;
	
	/**
	 * Determinante
	 */
	public function determinant():Float;
	
	/**
	 * takes the same value as the given matrix
	 */
	public function set33( m:IMatrix33 ):Void;
	
}