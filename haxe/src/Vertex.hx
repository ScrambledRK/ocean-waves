package ;
import at.dotpoint.math.vector.Vector2;
import at.dotpoint.math.vector.Vector3;

/**
 * ...
 * @author RK
 */
class Vertex
{

	public var c_h0_norm:Vector2;
	public var c_h0_conj:Vector2;
	
	public var position:Vector3;
	public var normal:Vector3;
	
	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	
	
	public function new() 
	{
		this.c_h0_norm = new Vector2();
		this.c_h0_conj = new Vector2();
		
		this.position = new Vector3();
	}
	
	// ************************************************************************ //
	// Methods
	// ************************************************************************ //	
}