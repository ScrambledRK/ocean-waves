package at.dotpoint.math;

/**
 * ...
 * @author Gerald Hattensauer
 */

class MathUtil 
{

	/**
	 * Value below <em>ZERO_TOLERANCE</em> is treated as zero.
	 */
	inline public static var ZERO_TOLERANCE = 1e-08;
	
	/**
	 * Multiply value by this constant to convert from radians to degrees (180 / PI).
	 */
	inline public static var RAD_DEG = 57.29577951308232;
	
	/**
	 * Multiply value by this constant to convert from degrees to radians (PI / 180).
	 */
	inline public static var DEG_RAD = 0.017453292519943295;
	
	/**
	* The largest representable number (single-precision IEEE-754).
	*/
	inline public static var FLOAT_MAX = 3.4028234663852886e+37;

	/**
	* The smallest representable number (single-precision IEEE-754).
	*/
	inline public static var FLOAT_MIN = -3.4028234663852886e+37;

	// ************************************************************************ //
	// Methodes
	// ************************************************************************ //	
	
	/**
	 * checks if there is a noticeable difference between the two values using the ZERO_TOLERANCE constant as a threshold
	 * 
	 * @param	a
	 * @param	b
	 * @return	true if there is NO difference, false if there is a difference
	 */
	inline public static function isEqual( a:Float, b:Float ):Bool 
	{
		if( a > b )
			return a - b < MathUtil.ZERO_TOLERANCE;
		else
			return b - a < MathUtil.ZERO_TOLERANCE;
	}
	
	inline public static function getAngle(x1:Float, y1:Float, x2:Float, y2:Float):Float
	{
		var dx:Float = x2 - x1;
		var dy:Float = y2 - y1;
		
		return Math.atan2(dy,dx);
	}
}