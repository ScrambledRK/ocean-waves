package ;
import at.dotpoint.math.color.ColorFormat;
import at.dotpoint.math.color.ColorUtil;
import at.dotpoint.math.geom.Cube;
import at.dotpoint.math.vector.Vector2;
import at.dotpoint.math.vector.Vector3;
import flash.display.BitmapData;

/**
 * ...
 * @author RK
 */
class VectorField
{

	/**
	 * the 2D vector field 
	 */
	public var field:Array<Array<Vector2>>;	
	
	// -------------------------- //
	// -------------------------- //
	
	/**
	 * w/h of the plot
	 */
	public var plotRange:Cube;
	
	/**
	 * w/h of the vector field (function range)
	 */
	public var functionRange:Cube;
	
	/**
	 * function to use to calculate vectorfield
	 */
	private var vectorFunction:Vector3->Vector2;
	
	// -------------------------- //
	// -------------------------- //
	
	/**
	 * reusable vector instance
	 */
	private var tmpVector2_1:Vector2;
	private var tmpVector2_2:Vector2;
	
	private var tmpVector3_1:Vector3;
	private var tmpVector3_2:Vector3;
	
	// *********************************************************** //
	// Constructor
	// *********************************************************** //
	
	/**
	 * 
	 */
	public function new( fnc_vector:Vector3->Vector2, ?plotWH:Float = 512, ?funcWH:Float = 3  ) 
	{		
		this.plotRange 		= this.createRange( 0, 0, plotWH, plotWH, 0, 0 );
		this.functionRange 	= this.createRange( -funcWH, -funcWH, funcWH, funcWH, 0.5, 0.5 );	
		
		this.vectorFunction = fnc_vector;
	}	
	
	/**
	 * 
	 */
	private function init():Void
	{
		this.field = new Array<Array<Vector2>>();	
		
		this.tmpVector2_1 = new Vector2();
		this.tmpVector2_2 = new Vector2();
		
		this.tmpVector3_1 = new Vector3();
		this.tmpVector3_2 = new Vector3();	
	}	
	
	// *********************************************************** //
	// getter / setter
	// *********************************************************** //
	
	/**
	 * 
	 * @param	minX
	 * @param	minY
	 * @param	maxX
	 * @param	maxY
	 * @param	relCenterX
	 * @param	relCenterY
	 * @return
	 */
	private function createRange( minX:Float, minY:Float, maxX:Float, maxY:Float, relCenterX:Float, relCenterY:Float ):Cube
	{
		var range:Cube = new Cube( new Vector3( relCenterX, relCenterY, 0 ) );
			range.min.set( minX, minY, 0 );
			range.max.set( maxX, maxY, 0 );
		
		return range;
	}
	
	/**
	 * converts coordinates from plotSpace to functionSpace.
	 * 
	 * 
	 * @param	x	0...plotW -> xRange.x...xRange.y
	 * @param	y	0...plotH -> yRange.x...yRange.y
	 */
	private function toFunctionCoordinate( x:Int, y:Int, ?output:Vector3 ):Vector3
	{
		this.tmpVector3_1.set( x / this.plotRange.width,  y / this.plotRange.height, 0 );		
		return this.functionRange.getPoint( this.tmpVector3_1, output );
	}
	
	/**
	 * 
	 */
	private function toColor( fnc:Vector2, output:Vector2 ):Vector2
	{
		output.set( fnc.x, fnc.y );		
		output.normalize();		
		
		output.x = (output.x + 1) * 0.5;
		output.y = (output.y + 1) * 0.5;
		
		return output;
	}
	
	// *********************************************************** //
	// caclulations
	// *********************************************************** //	
	
	/**
	 * 
	 */
	public function calculateVectorField():Void
	{
		if( this.field == null )
			this.init();	
		
		var w:Int = Std.int( this.plotRange.width )  + 1;
		var h:Int = Std.int( this.plotRange.height ) + 1;
		
		for( x in 0...w )
		{
			this.field[x] = new Array<Vector2>();
			
			for( y in 0...h )
			{
				var fnc:Vector3 = this.toFunctionCoordinate( x, y, this.tmpVector3_2 );
				this.field[x][y] = this.vectorFunction( fnc );
			}
		}
	}	
	
	// *********************************************************** //
	// plot
	// *********************************************************** //	
	
	/**
	 * 
	 */
	public function plotVectorField():BitmapData
	{
		if( this.field == null )
			this.calculateVectorField();
		
		// ------------- //	
		
		var plot:BitmapData = new BitmapData( Std.int( this.plotRange.width ), Std.int( this.plotRange.height ) );
		
		var w:Int = Std.int( this.plotRange.width )  + 1;
		var h:Int = Std.int( this.plotRange.height ) + 1;
		
		for( x in 0...w )
		{
			for( y in 0...h )
			{
				var vec:Vector2 = this.field[x][y].clone( this.tmpVector2_1 );
				var col:Vector2 = this.toColor( vec, this.tmpVector2_2 );
				
				var color:Int = ColorUtil.toInt( new Vector3( col.x, col.y, 0, 1 ), ColorFormat.RGB );
				
				plot.setPixel( x, y, color );
			}
		}
		
		return plot;
	}
	
}