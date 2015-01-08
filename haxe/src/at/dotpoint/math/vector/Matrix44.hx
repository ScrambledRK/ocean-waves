package at.dotpoint.math.vector;

import at.dotpoint.math.MathUtil;

/**
 * 4x4 Matrix; 3D Math is column-based (Translation: m14-m44)
 * @author Gerald Hattensauer
 */
class Matrix44 implements IMatrix44
{

	public var m11:Float; public var m12:Float; public var m13:Float; public var m14:Float;
	public var m21:Float; public var m22:Float; public var m23:Float; public var m24:Float;
	public var m31:Float; public var m32:Float; public var m33:Float; public var m34:Float;
	public var m41:Float; public var m42:Float; public var m43:Float; public var m44:Float; 
	
	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	
	
	public function new( ?m:IMatrix44 ) 
	{
		if ( m != null)	this.set44( m );
		else 			this.toIdentity();
	}	
	
	public function clone():Matrix44
	{
		return new Matrix44( this );
	}
	
	// ************************************************************************ //
	// Methodes
	// ************************************************************************ //	
	
	/**
	 * takes the same value as the given matrix
	 */
	public function set44( m:IMatrix44 ):Void 
	{
		this.m11 = m.m11;
		this.m12 = m.m12;
		this.m13 = m.m13;
		this.m14 = m.m14;
		
		this.m21 = m.m21;
		this.m22 = m.m22;
		this.m23 = m.m23;
		this.m24 = m.m24;
		
		this.m31 = m.m31;
		this.m32 = m.m32;
		this.m33 = m.m33;
		this.m34 = m.m34;
		
		this.m41 = m.m41;
		this.m42 = m.m42;
		this.m43 = m.m43;
		this.m44 = m.m44;
	}
	
	/**
	 * takes the same value as the given matrix, but just the upper 3x3
	 * the rest will be set to identity
	 */
	public function set33( m:IMatrix33 ):Void
	{
		m11 = m.m11; m12 = m.m12; m13 = m.m13; m14 = 0;
		m21 = m.m21; m22 = m.m22; m23 = m.m23; m24 = 0;
		m31 = m.m31; m32 = m.m32; m33 = m.m33; m34 = 0;
		m41 = 0;     m42 = 0;     m43 = 0;     m44 = 1;
	}
	
	/**
	 * Diagonal will be set to 1, rest to 0
	 */
	public function toIdentity():Void
	{
		m11 = 1; m12 = 0; m13 = 0; m14 = 0;
		m21 = 0; m22 = 1; m23 = 0; m24 = 0;
		m31 = 0; m32 = 0; m33 = 1; m34 = 0;
		m41 = 0; m42 = 0; m43 = 0; m44 = 1;
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
		t = m41; m41 = m14; m14 = t;
		t = m42; m42 = m24; m24 = t;
		t = m43; m43 = m34; m34 = t;
	}
	
	/**
	 * Determinante
	 */
	public function determinant():Float
	{
		return		(m11 * m22 - m21 * m12) * (m33 * m44 - m43 * m34)- (m11 * m32 - m31 * m12) * (m23 * m44 - m43 * m24)
				 + 	(m11 * m42 - m41 * m12) * (m23 * m34 - m33 * m24)+ (m21 * m32 - m31 * m22) * (m13 * m44 - m43 * m14)
				 - 	(m21 * m42 - m41 * m22) * (m13 * m34 - m33 * m14)+ (m31 * m42 - m41 * m32) * (m13 * m24 - m23 * m14);
	}
	
	/**
	 * Returns the inverse of a Matrix4 matrix using cramer formula (devide by determinant, multiply by inverse)
	 */
	public function inverse():Void
	{
		var d:Float = this.determinant();
		
		if( Math.abs(d) < MathUtil.ZERO_TOLERANCE )	// cannot invert with a null determinant
			return;
		
		d = 1 / d;
		
		var m11:Float = this.m11; var m21:Float = this.m21; var m31:Float = this.m31; var m41:Float = this.m41;		
		var m12:Float = this.m12; var m22:Float = this.m22; var m32:Float = this.m32; var m42:Float = this.m42;		
		var m13:Float = this.m13; var m23:Float = this.m23; var m33:Float = this.m33; var m43:Float = this.m43;		
		var m14:Float = this.m14; var m24:Float = this.m24; var m34:Float = this.m34; var m44:Float = this.m44;	
		
		/*var m11:Float = this.m11; var m21:Float = this.m12; var m31:Float = this.m13; var m41:Float = this.m14;		
		var m12:Float = this.m21; var m22:Float = this.m22; var m32:Float = this.m23; var m42:Float = this.m24;		
		var m13:Float = this.m31; var m23:Float = this.m32; var m33:Float = this.m33; var m43:Float = this.m34;		
		var m14:Float = this.m41; var m24:Float = this.m42; var m34:Float = this.m43; var m44:Float = this.m44;*/	
		
		this.m11 = d * ( m22*(m33*m44 - m43*m34) - m32*(m23*m44 - m43*m24) + m42*(m23*m34 - m33*m24) );
		this.m12 = -d* ( m12*(m33*m44 - m43*m34) - m32*(m13*m44 - m43*m14) + m42*(m13*m34 - m33*m14) );
		this.m13 = d * ( m12*(m23*m44 - m43*m24) - m22*(m13*m44 - m43*m14) + m42*(m13*m24 - m23*m14) );
		this.m14 = -d* ( m12*(m23*m34 - m33*m24) - m22*(m13*m34 - m33*m14) + m32*(m13*m24 - m23*m14) );
		this.m21 = -d* ( m21*(m33*m44 - m43*m34) - m31*(m23*m44 - m43*m24) + m41*(m23*m34 - m33*m24) );
		this.m22 = d * ( m11*(m33*m44 - m43*m34) - m31*(m13*m44 - m43*m14) + m41*(m13*m34 - m33*m14) );
		this.m23 = -d* ( m11*(m23*m44 - m43*m24) - m21*(m13*m44 - m43*m14) + m41*(m13*m24 - m23*m14) );
		this.m24 = d * ( m11*(m23*m34 - m33*m24) - m21*(m13*m34 - m33*m14) + m31*(m13*m24 - m23*m14) );
		this.m31 = d * ( m21*(m32*m44 - m42*m34) - m31*(m22*m44 - m42*m24) + m41*(m22*m34 - m32*m24) );
		this.m32 = -d* ( m11*(m32*m44 - m42*m34) - m31*(m12*m44 - m42*m14) + m41*(m12*m34 - m32*m14) );
		this.m33 = d * ( m11*(m22*m44 - m42*m24) - m21*(m12*m44 - m42*m14) + m41*(m12*m24 - m22*m14) );
		this.m34 = -d* ( m11*(m22*m34 - m32*m24) - m21*(m12*m34 - m32*m14) + m31*(m12*m24 - m22*m14) );
		this.m41 = -d* ( m21*(m32*m43 - m42*m33) - m31*(m22*m43 - m42*m23) + m41*(m22*m33 - m32*m23) );
		this.m42 = d * ( m11*(m32*m43 - m42*m33) - m31*(m12*m43 - m42*m13) + m41*(m12*m33 - m32*m13) );
		this.m43 = -d* ( m11*(m22*m43 - m42*m23) - m21*(m12*m43 - m42*m13) + m41*(m12*m23 - m22*m13) );
		this.m44 = d * ( m11*(m22*m33 - m32*m23) - m21*(m12*m33 - m32*m13) + m31*(m12*m23 - m22*m13) );
	}

	// ************************************************************************ //
	// static binary Operations
	// ************************************************************************ //
	
	/**
	 * adds each component together (a+b)
	 * outcome will be stored into output; 
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	public static function add<T:IMatrix44>( a:IMatrix44, b:IMatrix44, ?output:T ):T
	{
		if( output == null )
			output = cast new Matrix44();
		
		output.m11 = a.m11 + b.m11;
		output.m12 = a.m12 + b.m12;
		output.m13 = a.m13 + b.m13;
		output.m14 = a.m14 + b.m14;
		
		output.m21 = a.m21 + b.m21;
		output.m22 = a.m22 + b.m22;
		output.m23 = a.m23 + b.m23;
		output.m24 = a.m24 + b.m24;
		
		output.m31 = a.m31 + b.m31;
		output.m32 = a.m32 + b.m32;
		output.m33 = a.m33 + b.m33;
		output.m34 = a.m34 + b.m34;
		
		output.m41 = a.m41 + b.m41;
		output.m42 = a.m42 + b.m42;
		output.m43 = a.m43 + b.m43;
		output.m44 = a.m44 + b.m44;	
		
		return output;
	}
	
	/**
	 * substracts each component from each other (a-b) 
	 * outcome will be stored into output;
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	public static function subtract<T:IMatrix44>( a:IMatrix44, b:IMatrix44, output:T ):T
	{
		if( output == null )
			output = cast new Matrix44();
		
		output.m11 = a.m11 - b.m11;
		output.m12 = a.m12 - b.m12;
		output.m13 = a.m13 - b.m13;
		output.m14 = a.m14 - b.m14;
		
		output.m21 = a.m21 - b.m21;
		output.m22 = a.m22 - b.m22;
		output.m23 = a.m23 - b.m23;
		output.m24 = a.m24 - b.m24;
		
		output.m31 = a.m31 - b.m31;
		output.m32 = a.m32 - b.m32;
		output.m33 = a.m33 - b.m33;
		output.m34 = a.m34 - b.m34;
		
		output.m41 = a.m41 - b.m41;
		output.m42 = a.m42 - b.m42;
		output.m43 = a.m43 - b.m43;
		output.m44 = a.m44 - b.m44;	
		
		return output;
	}
	
	/**
	 * scales each component of a by a scalar 
	 * outcome will be stored into output; 
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	public static function scale<T:IMatrix44>( a:IMatrix44, scalar:Float, output:T ):T
	{
		if( output == null )
			output = cast new Matrix44();
		
		output.m11 = a.m11 * scalar;
		output.m12 = a.m12 * scalar;
		output.m13 = a.m13 * scalar;
		output.m14 = a.m14 * scalar;
		
		output.m21 = a.m21 * scalar;
		output.m22 = a.m22 * scalar;
		output.m23 = a.m23 * scalar;
		output.m24 = a.m24 * scalar;
		
		output.m31 = a.m31 * scalar;
		output.m32 = a.m32 * scalar;
		output.m33 = a.m33 * scalar;
		output.m34 = a.m34 * scalar;
		
		output.m41 = a.m41 * scalar;
		output.m42 = a.m42 * scalar;
		output.m43 = a.m43 * scalar;
		output.m44 = a.m44 * scalar;	
		
		return output;
	}
	
	/**
	 * calculates the matrix product of 2 matrices; use to compose matrix together;
	 * outcome will be stored into output; not communtative (a*b != b*a); rows of a are multiplied with columns of b;
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	public static function multiply<T:IMatrix44>( a:IMatrix44, b:IMatrix44, output:T ):T
	{
		if( output == null )
			output = cast new Matrix44();
		
		#if debug
			if ( a == output || b == output ) throw "you can't use input as output for this methode";
		#end
		
		var b11 = b.m11; var b12 = b.m12; var b13 = b.m13; var b14 = b.m14;
		var b21 = b.m21; var b22 = b.m22; var b23 = b.m23; var b24 = b.m24;
		var b31 = b.m31; var b32 = b.m32; var b33 = b.m33; var b34 = b.m34;
		var b41 = b.m41; var b42 = b.m42; var b43 = b.m43; var b44 = b.m44;
		var t1, t2, t3, t4;
		
		// ------------------ //
		
		t1 = a.m11;
		t2 = a.m12;
		t3 = a.m13;
		t4 = a.m14;
		
		output.m11 = t1 * b11 + t2 * b21 + t3 * b31 + t4 * b41;
		output.m12 = t1 * b12 + t2 * b22 + t3 * b32 + t4 * b42;
		output.m13 = t1 * b13 + t2 * b23 + t3 * b33 + t4 * b43;
		output.m14 = t1 * b14 + t2 * b24 + t3 * b34 + t4 * b44;
		
		// ------------------ //
		
		t1 = a.m21;
		t2 = a.m22;
		t3 = a.m23;
		t4 = a.m24;
		
		output.m21 = t1 * b11 + t2 * b21 + t3 * b31 + t4 * b41;
		output.m22 = t1 * b12 + t2 * b22 + t3 * b32 + t4 * b42;
		output.m23 = t1 * b13 + t2 * b23 + t3 * b33 + t4 * b43;
		output.m24 = t1 * b14 + t2 * b24 + t3 * b34 + t4 * b44;
		
		// ------------------ //
		
		t1 = a.m31;
		t2 = a.m32;
		t3 = a.m33;
		t4 = a.m34;
		
		output.m31 = t1 * b11 + t2 * b21 + t3 * b31 + t4 * b41;
		output.m32 = t1 * b12 + t2 * b22 + t3 * b32 + t4 * b42;
		output.m33 = t1 * b13 + t2 * b23 + t3 * b33 + t4 * b43;
		output.m34 = t1 * b14 + t2 * b24 + t3 * b34 + t4 * b44;
		
		// ------------------ //
		
		t1 = a.m41;
		t2 = a.m42;
		t3 = a.m43;
		t4 = a.m44;
		
		output.m41 = t1 * b11 + t2 * b21 + t3 * b31 + t4 * b41;
		output.m42 = t1 * b12 + t2 * b22 + t3 * b32 + t4 * b42;
		output.m43 = t1 * b13 + t2 * b23 + t3 * b33 + t4 * b43;
		output.m44 = t1 * b14 + t2 * b24 + t3 * b34 + t4 * b44;
		
		return output;
	}	
	
	/**
	 * compares each component for equality using ZERO_TOLERANCE
	 * 
	 * @param	output 	true when all components are equal
	 * @return			given output object
	 */
	public static function isEqual( a:IMatrix44, b:IMatrix44 ):Bool
	{
		var success:Bool = true;
		
		if(( !MathUtil.isEqual(a.m11, b.m11) ) 	
		|| ( !MathUtil.isEqual(a.m12, b.m12) )
		|| ( !MathUtil.isEqual(a.m13, b.m13) ) 
		|| ( !MathUtil.isEqual(a.m14, b.m14) ) 
		
		|| ( !MathUtil.isEqual(a.m21, b.m21) )	
		|| ( !MathUtil.isEqual(a.m22, b.m22) ) 
		|| ( !MathUtil.isEqual(a.m23, b.m23) ) 
		|| ( !MathUtil.isEqual(a.m24, b.m24) ) 
		
		|| ( !MathUtil.isEqual(a.m31, b.m31) ) 	
		|| ( !MathUtil.isEqual(a.m32, b.m32) )
		|| ( !MathUtil.isEqual(a.m33, b.m33) ) 
		|| ( !MathUtil.isEqual(a.m34, b.m34) ) 
		
		|| ( !MathUtil.isEqual(a.m41, b.m41) ) 	
		|| ( !MathUtil.isEqual(a.m42, b.m42) ) 
		|| ( !MathUtil.isEqual(a.m43, b.m43) ) 
		|| ( !MathUtil.isEqual(a.m44, b.m44) ))
		{
			success = false;
		}
		
		return success;
	}
	
	// ************************************************************************ //
	// Array
	// ************************************************************************ //	
	
	/**
	 * 
	 * @param	output
	 * @return
	 */
	public function toArray( ?output:Array<Float> ):Array<Float>
	{
		if( output == null )
			output = new Array<Float>();
		
		output[0]  = this.m11;
		output[1]  = this.m21;
		output[2]  = this.m31;
		output[3]  = this.m41; 
		output[4]  = this.m12;
		output[5]  = this.m22;
		output[6]  = this.m32;
		output[7]  = this.m42; 
		output[8]  = this.m13;
		output[9]  = this.m23;
		output[10] = this.m33;
		output[11] = this.m43;
		output[12] = this.m14;
		output[13] = this.m24;
		output[14] = this.m34;
		output[15] = this.m44; 
		
		return output;
	}
	
	/**
	 * 
	 * @param	output
	 * @return
	 */
	public function setArray( input:Array<Float> ):Void
	{
		this.m11 = input[0];
		this.m21 = input[1];
		this.m31 = input[2];
		this.m41 = input[3]; 
		this.m12 = input[4];
		this.m22 = input[5];
		this.m32 = input[6];
		this.m42 = input[7]; 
		this.m13 = input[8];
		this.m23 = input[9];
		this.m33 = input[10];
		this.m43 = input[11];
		this.m14 = input[12];
		this.m24 = input[13];
		this.m34 = input[14];
		this.m44 = input[15]; 
	}
}