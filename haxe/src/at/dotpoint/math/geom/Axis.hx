package at.dotpoint.math.geom;
import at.dotpoint.math.vector.Vector3;

/**
 * @author RK
 */

enum Axis 
{
	X; 
	Y; 
	Z;
}

class RelativeAxis
{
	
	public static var CENTER:Vector3 				= new Vector3( 0.5,	0.5, 0.5 );
	
	// --------------------------- //
	
	public static var TOP:Vector3 					= new Vector3( 0.5,	0.0, 0.5 );
	public static var LEFT:Vector3 					= new Vector3( 0.0, 0.5, 0.5 );
	public static var RIGHT:Vector3 				= new Vector3( 1.0, 0.5, 0.5 );
	public static var BOTTOM:Vector3 				= new Vector3( 0.5, 1.0, 0.5 );

	// --------------------------- //
	// FRONT, BACK
	
	public static var TOP_LEFT:Vector3 				= new Vector3( 0.0,	0.0, 0.5 );
	public static var TOP_RIGHT:Vector3 			= new Vector3( 1.0,	0.0, 0.5 );	
	
	public static var BOTTOM_LEFT:Vector3 			= new Vector3( 0.0,	1.0, 0.5 );
	public static var BOTTOM_RIGHT:Vector3 			= new Vector3( 1.0,	1.0, 0.5 );
	
	// --------------------------- //
	// FRONT, BACK
	
	public static var TOP_LEFT_FRONT:Vector3 		= new Vector3( 0.0,	0.0, 0.0 );
	public static var TOP_LEFT_BACK:Vector3 		= new Vector3( 0.0,	0.0, 1.0 );
	
	public static var TOP_RIGHT_FRONT:Vector3 		= new Vector3( 1.0,	0.0, 0.0 );	
	public static var TOP_RIGHT_BACK:Vector3 		= new Vector3( 1.0,	0.0, 1.0 );	
	
	public static var BOTTOM_LEFT_FRONT:Vector3 	= new Vector3( 0.0,	1.0, 0.0 );
	public static var BOTTOM_LEFT_BACK:Vector3 		= new Vector3( 0.0,	1.0, 1.0 );
	
	public static var BOTTOM_RIGHT_FRONT:Vector3 	= new Vector3( 1.0,	1.0, 0.0 );
	public static var BOTTOM_RIGHT_BACK:Vector3 	= new Vector3( 1.0,	1.0, 1.0 );
	
}