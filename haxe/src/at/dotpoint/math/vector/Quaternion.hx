package at.dotpoint.math.vector;

import at.dotpoint.math.MathUtil;

/**
 * Unit-Quaternion is a Vector4 like Object for interpolateable and gimbal-lock-free rotations;
 * note - this class does not guarantee to be a unit quaternion but some methodes may rely on it.
 * 
 * @author Gerald Hattensauer
 */
class Quaternion
{

	@:isVar public var x(get, set):Float; // imaginary
	@:isVar public var y(get, set):Float; // imaginary
	@:isVar public var z(get, set):Float; // imaginary	
	@:isVar public var w(get, set):Float; // real
	
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
	
	public function clone():Quaternion
	{
		return new Quaternion( this.x, this.y, this.z, this.w );
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
	 * [x:0,y:0,z:0,w:1]
	 */
	public function toIdentity():Void
	{
		this.x = 0;
		this.y = 0;
		this.z = 0;
		this.w = 1;
	}
	
	/**
	 * conjungates the quaternion the imaginary components x,y,z
	 */
	public function conjugate():Void
	{
		this.x = -this.x;
		this.y = -this.y;
		this.z = -this.z;
	}
	
	/**
	 * 
	 */
	public function invert():Void
	{
		var k:Float = 1. / this.lengthSq(); 
		
		this.conjugate();
		
		this.x *= k;
		this.y *= k;
		this.z *= k;
		this.w *= k;	
	}
	
	/**
	 * rescales each component between 0 and 1 without changing its ratio to each other
	 * [ignores the homogenous component]
	 */
	public function normalize():Void
	{
		var k:Float = 1. / this.length();
		
		this.x *= k;
		this.y *= k;
		this.z *= k;
		this.w *= k;
	}
	
	/** 
	 * @return length of the Vector
	 */
	inline public function length():Float
	{
		return Math.sqrt( this.lengthSq() );
	}
	
	/** 
	 * @return squared length of the Vector
	 */
	inline public function lengthSq():Float
	{
		return this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w;
	}
	
	// ************************************************************************ //
	// Axis (Euler)
	// ************************************************************************ //
        
	/**
	 * Creates a {@link Vector3} which represents the x axis of this {@link Quaternion}.
	 * 
	 * @return {@link Vector3} The x axis of this {@link Quaternion}.
	 */
	public function getAxisX( ?output:Vector3 ):Vector3 
	{
		output = output != null ? output : new Vector3();
		
		var fTy = 2.0 * y;
		var fTz = 2.0 * z;
		
		var fTwy = fTy * w;
		var fTwz = fTz * w;
		var fTxy = fTy * x;
		var fTxz = fTz * x;
		var fTyy = fTy * y;
		var fTzz = fTz * z;
		
		output.set(1 - (fTyy + fTzz), fTxy + fTwz, fTxz - fTwy);
		
		return output;
	}

	/**
	 * Creates a {@link Vector3} which represents the y axis of this {@link Quaternion}.
	 * 
	 * @return {@link Vector3} The y axis of this {@link Quaternion}.
	 */
	public function getAxisY( ?output:Vector3 ):Vector3 
	{
		output = output != null ? output : new Vector3();
		
		var fTx = 2.0 * x;
		var fTy = 2.0 * y;
		var fTz = 2.0 * z;
		
		var fTwx = fTx * w;
		var fTwz = fTz * w;
		var fTxx = fTx * x;
		var fTxy = fTy * x;
		var fTyz = fTz * y;
		var fTzz = fTz * z;
		
		output.set(fTxy - fTwz, 1 - (fTxx + fTzz), fTyz + fTwx);
		
		return output;
	}

	/**
	 * Creates a {@link Vector3} which represents the z axis of this {@link Quaternion}.
	 * 
	 * @return {@link Vector3} The z axis of this {@link Quaternion}.
	 */
	public function getAxisZ( ?output:Vector3 ):Vector3 
	{
		output = output != null ? output : new Vector3();
		
		var fTx = 2.0 * x;
		var fTy = 2.0 * y;
		var fTz = 2.0 * z;
		
		var fTwx = fTx * w;
		var fTwy = fTy * w;
		var fTxx = fTx * x;
		var fTxz = fTz * x;
		var fTyy = fTy * y;
		var fTyz = fTz * y;
		
		output.set(fTxz + fTwy, fTyz - fTwx, 1 - (fTxx + fTyy));
		
		return output;
	}
	
	/**
	 * 
	 * @return
	 */
	public function toString():String
	{
		return "[Quaternion;" + this.x + ", " + this.y + ", " + this.z + ", " + this.w + "]";
	}
	
	// ************************************************************************ //
	// static Operations
	// ************************************************************************ //	
	
	/**
	 * adds the x,y,z and w components (a+b)
	 * outcome will be stored into output; 
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	inline public static function add( a:Quaternion, b:Quaternion, output:Quaternion ):Quaternion
	{
		output.x = a.x + b.x;
		output.y = a.y + b.y;
		output.z = a.z + b.z;	
		output.w = a.w + b.w;	
		
		return output;
	}
	
	/**
	 * substracts the x,y,z and w components (a-b) 
	 * outcome will be stored into output;
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	inline public static function subtract( a:Quaternion, b:Quaternion, output:Quaternion ):Quaternion
	{
		output.x = a.x - b.x;
		output.y = a.y - b.y;
		output.z = a.z - b.z;
		output.w = a.w - b.w;
		
		return output;
	}
	
	/**
	 * scales the x,y,z and w components by a scalar; 
	 * outcome will be stored into output; 
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	inline public static function scale( a:Quaternion, scalar:Float, output:Quaternion ):Quaternion
	{
		output.x = a.x * scalar;
		output.y = a.y * scalar;
		output.z = a.z * scalar;
		output.w = a.w * scalar;
		
		return output;
	}
	
	/**
	 * calculates the product of 2 quaternions; use to compose quaternions together;
	 * outcome will be stored into output; not communtative (a*b != b*a); 
	 * 
	 * @param	output 	object the outcome will be stored to (does not change the current object)
	 * @return			given output object
	 */
	inline public static function multiply( a:Quaternion, b:Quaternion, output:Quaternion ):Quaternion
	{
		#if debug
			if ( a == output || b == output ) throw "you can't use input as output for this methode";
		#end
		
		output.x = a.w * b.x + a.x * b.w + a.y * b.z - a.z * b.y; // cross - dot (to remove real)
		output.y = a.w * b.y - a.x * b.z + a.y * b.w + a.z * b.x; // short version
		output.z = a.w * b.z + a.x * b.y - a.y * b.x + a.z * b.w;
		output.w = a.w * b.w - a.x * b.x - a.y * b.y - a.z * b.z;
		
		return output; 
	}
	
	/**
	 * dotproduct between a and b; calculates the cosine angle between a and b;
	 * [ignores the homogenous component]
	 */
	inline public static function dot( a:Quaternion, b:Quaternion ):Float
	{
		return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
	}
	
	// ************************************************************************ //
	// Rotation specific:
	// ************************************************************************ //	
	
	/**
	 * final double m00 = xx, m01 = xy, m02 = xz;
		final double m10 = yx, m11 = yy, m12 = yz;
		final double m20 = zx, m21 = zy, m22 = zz;
		final double t = m00 + m11 + m22;
	 * 
	 * @param	x
	 * @param	y
	 * @param	z
	 * @param	?output
	 * @return
	 */
	public static function setAxis( x:Vector3, y:Vector3, z:Vector3, ?output:Quaternion ):Quaternion
	{
		output = output != null ? output : new Quaternion();
		
		var matrix:Matrix44 = new Matrix44();
		
		matrix.m11 = x.x;
		matrix.m21 = y.x;
		matrix.m31 = z.x;
		
		matrix.m12 = x.y;
		matrix.m22 = y.y;
		matrix.m32 = z.y;
		
		matrix.m13 = x.z;
		matrix.m23 = y.z;
		matrix.m33 = z.z;
		
		return Quaternion.setMatrix( matrix, output );		
	}
	
	/**
	 * set rotation around a vector.
	 * 
	 * @param 	axis	The vector in space it rotates around 
	 * @param	angle	The angle in radians of the rotation.
	 */
	inline public static function setAxisAngle( axis:Vector3, radians:Float, output:Quaternion ):Quaternion
	{
		axis.normalize();
		
		radians = radians * 0.5;
		
		var sin_a:Float = Math.sin( radians );
		var cos_a:Float = Math.cos( radians );
		
		output.x = axis.x * sin_a;
		output.y = axis.y * sin_a;
		output.z = axis.z * sin_a;
		output.w = cos_a;
		
		output.normalize();
		
		return output;
	}
	
	/**
	 * 
	 * @param	euler
	 * @param	output
	 * @return
	 */
	inline public static function setEuler( euler:IVector3, output:Quaternion ):Quaternion
	{
		var fSinPitch:Float       = Math.sin( euler.x * 0.5 );
		var fCosPitch:Float       = Math.cos( euler.x * 0.5 );
		var fSinYaw:Float         = Math.sin( euler.y * 0.5 );
		var fCosYaw:Float         = Math.cos( euler.y * 0.5 );
		var fSinRoll:Float        = Math.sin( euler.z * 0.5 );
		var fCosRoll:Float        = Math.cos( euler.z * 0.5 );
		var fCosPitchCosYaw:Float = fCosPitch * fCosYaw;
		var fSinPitchSinYaw:Float = fSinPitch * fSinYaw;
		
		output.x = fSinRoll * fCosPitchCosYaw     - fCosRoll * fSinPitchSinYaw;
		output.y = fCosRoll * fSinPitch * fCosYaw + fSinRoll * fCosPitch * fSinYaw;
		output.z = fCosRoll * fCosPitch * fSinYaw - fSinRoll * fSinPitch * fCosYaw;
		output.w = fCosRoll * fCosPitchCosYaw     + fSinRoll * fSinPitchSinYaw;
		
		return output;
	}
	
	/**
	 * 
	 * @param	input
	 * @param	output
	 * @return
	 */
	inline public static function toEuler( input:Quaternion, output:IVector3 ):IVector3
	{
		var test:Float = input.x * input.y + input.z * input.w;
		
		if (test > 0.499) 	// singularity at north pole
		{ 
			output.x = 2 * Math.atan2(input.x, input.w);
			output.y = Math.PI / 2;
			output.z = 0;
		}
		if (test < -0.499) 	// singularity at south pole
		{ 
			output.x = -2 * Math.atan2(input.x, input.w);
			output.y = -Math.PI / 2;
			output.z = 0;
		}
		else
		{
			var sqx:Float = input.x * input.x;
			var sqy:Float = input.y * input.y;
			var sqz:Float = input.z * input.z;
			
			output.x = Math.atan2(2 * input.y * input.w - 2 * input.x * input.z , 1 - 2 * sqy - 2 * sqz);			
			output.z = Math.atan2(2 * input.x * input.w - 2 * input.y * input.z , 1 - 2 * sqx - 2 * sqz);
			output.y = Math.asin(2 * test);
		}
		
		return output;
	}
	
	/**
	 * 
	 * @param	input
	 * @param	output
	 * @return
	 */
	inline public static function toMatrix( input:Quaternion, output:IMatrix33 ):IMatrix33 
	{
		var xx:Float = input.x * input.x;
		var xy:Float = input.x * input.y;
		var xz:Float = input.x * input.z;
		var xw:Float = input.x * input.w;
		
		var yy:Float = input.y * input.y;
		var yz:Float = input.y * input.z;
		var yw:Float = input.y * input.w;
		
		var zz:Float = input.z * input.z;
		var zw:Float = input.z * input.w;		
		
		output.m11 = 1 - 2 * ( yy + zz );
		output.m21 =     2 * ( xy + zw );
		output.m31 =     2 * ( xz - yw );
		
		output.m12 =     2 * ( xy - zw );
		output.m22 = 1 - 2 * ( xx + zz );
		output.m32 =     2 * ( yz + xw );
		
		output.m13 =     2 * ( xz + yw );
		output.m23 =     2 * ( yz - xw );
		output.m33 = 1 - 2 * ( xx + yy );
		
		return output;
	}
	
	/**
	 * 
	 * @param	input
	 * @param	output
	 * @return
	 */
	inline public static function setMatrix( input:IMatrix44, output:Quaternion ):Quaternion 
	{
		var m00 = input.m11;
		var m01 = input.m12; 
		var m02 = input.m13;
		
		var m10 = input.m21; 
		var m11 = input.m22; 
		var m12 = input.m23;
		
		var m20 = input.m31; 
		var m21 = input.m32; 
		var m22 = input.m33;
		
		var t = m00 + m11 + m22;
		
		//Protect the division by s by ensuring that s >= 1
		var x;
		var y;
		var z;
		var w;
		
		if (t >= 0) 
		{ 
			var s = Math.sqrt(t + 1); // |s| >= 1			
			
			w = 0.5 * s; // |w| >= 0.5
			s = 0.5 / s; //<- This division cannot be bad
			
			x = (m21 - m12) * s;
			y = (m02 - m20) * s;
			z = (m10 - m01) * s;
		} 
		else if ((m00 > m11) && (m00 > m22)) 
		{
			var s = Math.sqrt(1.0 + m00 - m11 - m22); // |s| >= 1
			
			x = s * 0.5; // |x| >= 0.5
			s = 0.5 / s;
			
			y = (m10 + m01) * s;
			z = (m02 + m20) * s;
			w = (m21 - m12) * s;
		} 
		else if (m11 > m22) 
		{
			var s = Math.sqrt(1.0 + m11 - m00 - m22); // |s| >= 1
			
			y = s * 0.5; // |y| >= 0.5
			s = 0.5 / s;
			
			x = (m10 + m01) * s;
			z = (m21 + m12) * s;
			w = (m02 - m20) * s;
		} 
		else 
		{
			var s = Math.sqrt(1.0 + m22 - m00 - m11); // |s| >= 1
			
			z = s * 0.5; // |z| >= 0.5
			s = 0.5 / s;
			
			x = (m02 + m20) * s;
			y = (m21 + m12) * s;
			w = (m10 - m01) * s;
		}
		
		output.x = x;
		output.y = y;
		output.z = z;
		output.w = w;
		
		return output;
	}
	
	// ---------------------------------- //
	// ---------------------------------- //
	
	/**
	* Returns the Yaw (pan) in Radians. Yaw, pitch and roll values of a Quaternion are
	* arbitrary compared to input.
	*
	* @return Yaw value in radians.
	*/
	inline public function getYaw( q:Quaternion ):Float 
	{
		return Math.asin( -2. * (q.x * q.z - q.y * q.w) );
	}
	
	/**
	* Returns the pitch in radians. Yaw, pitch and roll values of a Quaternion are
	* arbitrary compared to input.
	*
	* @return Pitch value in radians
	*/
	inline public function getPitch( q:Quaternion ):Float
	{
		return Math.atan2( 2.*(q.y * q.z + q.x * q.w), q.w * q.w - q.x * q.x - q.y * q.y + q.z * q.z );
	}

	/**
	* Returns the roll in radians. Yaw, pitch and roll values of a Quaternion are
	* arbitrary compared to input.
	*
	* @return Roll value in radians.
	*/
	inline public function getRoll( q:Quaternion ):Float
	{
		return Math.atan2( 2.*(q.x * q.y + q.z * q.w), q.w * q.w + q.x * q.x - q.y * q.y - q.z * q.z );
	}
	
	/**
	 * compares each component for equality using ZERO_TOLERANCE
	 * 
	 * @param	output 	true when all components are equal
	 * @return			given output object
	 */
	inline public static function isEqual( a:Quaternion, b:Quaternion ):Bool
	{
		if ( !MathUtil.isEqual(a.x, b.x) ) return false;		
		if ( !MathUtil.isEqual(a.y, b.y) ) return false;
		if ( !MathUtil.isEqual(a.z, b.z) ) return false;
		if ( !MathUtil.isEqual(a.w, b.w) ) return false;		
		
		return true;
	}	
	
}