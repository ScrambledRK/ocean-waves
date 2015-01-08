package at.dotpoint.math.vector;

import at.dotpoint.core.ICloneable;

/**
 * 4x4 Matrix; 3D Math is column-based (Translation: m14-m44)
 * @author Gerald Hattensauer
 */
class Matrix33 implements IMatrix33
{

	public var m11:Float; public var m12:Float; public var m13:Float;
	public var m21:Float; public var m22:Float; public var m23:Float;
	public var m31:Float; public var m32:Float; public var m33:Float;
	
	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	
	
	public function new( ?m:IMatrix33 ) 
	{
		if ( m != null)	this.set33( m );
		else 			this.toIdentity();
	}		
	
	public function clone( ?output:Matrix33 ):Matrix33
	{
		return new Matrix33( this );
	}
	
	// ************************************************************************ //
	// Methodes
	// ************************************************************************ //	
	
	/**
	 * takes the same value as the given matrix, but just the upper 3x3
	 * the rest will be set to identity
	 */
	public function set33( m:IMatrix33 ):Void
	{
		m11 = m.m11; m12 = m.m12; m13 = m.m13; 
		m21 = m.m21; m22 = m.m22; m23 = m.m23;
		m31 = m.m31; m32 = m.m32; m33 = m.m33; 
	}
	
	/**
	 * Diagonal will be set to 1, rest to 0
	 */
	public function toIdentity():Void
	{
		m11 = 1; m12 = 0; m13 = 0; 
		m21 = 0; m22 = 1; m23 = 0; 
		m31 = 0; m32 = 0; m33 = 1;
	}
	
	/**
	 * switches rows to colums and vice versa
	 */
	public function transpose():Void
	{
		var t:Float;
		t = m21; m21 = m12; m12 = t;
		t = m31; m31 = m13; m13 = t;
		t = m32; m32 = m23; m23 = t;
	}
	
	/**
	 * Determinante
	 */
	public function determinant():Float
	{
		var cf0:Float = m22 * m33 - m23 * m32;
		var cf3:Float = m13 * m32 - m12 * m33;
		var cf6:Float = m12 * m23 - m13 * m22;
		
		return m11 * cf0 + m21 * cf3 + m31 * cf6;
	}
	
}