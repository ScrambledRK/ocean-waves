package ;
import at.dotpoint.math.vector.Vector2;

/**
 * ...
 * @author RK
 */
class WaveOutput
{

	public var height:Vector2; 			// complex
	
	public var displacement:Vector2;	
	public var normal:Vector2;			
	
	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	
	
	public function new() 
	{
		this.height 		= new Vector2();
		this.displacement 	= new Vector2();
		this.normal 		= new Vector2();
	}
	
	// ************************************************************************ //
	// Methods
	// ************************************************************************ //	
}