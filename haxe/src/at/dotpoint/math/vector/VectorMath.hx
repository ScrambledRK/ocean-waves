package at.dotpoint.math.vector;

/**
 * ...
 * @author Gerald Hattensauer
 */
class VectorMath
{

	/**
	 * 
	 * @param	point x0
	 * @param	lineA 
	 * @param	lineB
	 * @return
	 */
	inline static public function distancePointToLine3( point:Vector3, lineA:Vector3, lineB:Vector3 ):Float
	{
		var x0:Vector3 = point;
		var x1:Vector3 = lineA;
		var x2:Vector3 = lineB;
		
		var a:Vector3 = Vector3.subtract( x0, x1, new Vector3() );
		var b:Vector3 = Vector3.subtract( x0, x2, new Vector3() );
		var c:Vector3 = Vector3.subtract( x2, x1, new Vector3() );
		
		return Vector3.cross( a, b, new Vector3() ).length() / c.length();
	}
	
}