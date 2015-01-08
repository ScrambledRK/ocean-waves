package ;

import at.dotpoint.math.color.ColorFormat;
import at.dotpoint.math.color.ColorUtil;
import at.dotpoint.math.geom.Cube;
import at.dotpoint.math.vector.Vector2;
import at.dotpoint.math.vector.Vector3;
import flash.display.Bitmap;
import flash.display.BitmapData;
import flash.display.Shape;
import flash.display.Sprite;
import flash.events.Event;
import flash.Lib;
import haxe.Timer;

/**
 * ...
 * 2.718281828
 * @author RK
 */

class Main extends Sprite 
{
	
	/**
	 * 
	 */
	private var vector:VectorField;
	
	/**
	 * 
	 */
	private var waves:DFTWaves;
	
	/**
	 * 
	 */
	private var simulation:Bitmap;
	
	// *********************************************************** //
	// Constructor
	// *********************************************************** //
	
	/**
	 * 
	 */
	static function main() 
	{
		Lib.current.addChild( new Main() );
	}
	
	/**
	 * 
	 */
	public function new() 
	{
		super();			
		
		this.vector = new VectorField( this.fnc_circle, 64 );
		this.waves	= new DFTWaves( this.vector );
		
		this.calculate();		
	}		
	
	// *********************************************************** //
	// Methods
	// *********************************************************** //
	
	/**
	 * 
	 */
	private function calculate():Void
	{
		var windmap:BitmapData = this.vector.plotVectorField();		
		this.addChild( new Bitmap( windmap ) );
		
		// ---------- //
		
		this.waves.init();
		
		var wavemap:Bitmap = new Bitmap( this.plotFFT() );
			wavemap.x += wavemap.width;
		
		this.addChild( wavemap );
		
		// ---------- //
		
		this.simulation = new Bitmap( wavemap.bitmapData.clone() );
		this.simulation.x += wavemap.width * 2;
		
		this.addChild( this.simulation );
		
		this.time = Timer.stamp();
		
		this.addEventListener( Event.ENTER_FRAME, this.onEnterFrame );
	}
	
	/**
	 * 
	 * @return
	 */
	private function plotFFT():BitmapData
	{
		var w:Int = Std.int( this.vector.plotRange.width  ) + 1;
		var h:Int = Std.int( this.vector.plotRange.height ) + 1;
		
		var plot:BitmapData = new BitmapData( w - 1, h -1 );		
		
		// --------------------- //
		
		var c:Vector3 = new Vector3();
		
		for( x in 0...w )
		{
			for( y in 0...h )
			{
				var vertex:Vertex = this.waves.vertices[x][y];
				
				if( vertex.c_h0_norm.x > 0 )
				{
					c.x = vertex.c_h0_norm.x;
					c.y = 0;
					//c.z = vertex.c_h0_conj.x;
				}
				else
				{
					c.x = 0;
					c.y = vertex.c_h0_norm.x * -1;
					//c.z = vertex.c_h0_conj.x;
				}
				
				c.x *= 100;
				c.y *= 100;
				c.z *= 100;
				
				plot.setPixel( x, y, ColorUtil.toInt( c, ColorFormat.RGB ) );
			}
		}
		
		return plot;
	}
	
	// *********************************************************** //
	// *********************************************************** //
	
	/**
	 * 
	 */
	private var count:Vector2 = new Vector2();
	private var time:Float;
	
	private var output:WaveOutput = new WaveOutput();
	private var col:Vector3 = new Vector3();
	
	/**
	 * 
	 * @param	event
	 */
	private function onEnterFrame( event:Event ):Void
	{
		var n:Float = Timer.stamp();
		var t:Float = this.time + 0.05;	
		
		this.time = t;
		
		while( (Timer.stamp() - n) < 0.3 )
		{
			this.count.x++;
			
			if( this.count.x >= this.vector.plotRange.width )
			{
				this.count.x = 0;
				this.count.y++;
			}
			
			if( this.count.y >= this.vector.plotRange.height )
			{
				this.count.x = 0;
				this.count.y = 0;
			}
			
			// -------------------- //
			
			this.waves.calculate( this.count, t, this.output );
			
			var sc:Float = 1 / 7.2;
			
			if( this.output.height.x > 0 )
			{
				col.x = 0.5 + this.output.height.x * sc * 0.5;
			}
			else
			{
				col.x = 0.5 - this.output.height.x * sc * 0.5 * -1;			
			}
				
			col.y = col.z = col.x;
			
			if( col.x > 1 || col.x < 0 )
				trace( this.output.height.x, "\t", col.x );
			
			var color:Int = ColorUtil.toInt( col, ColorFormat.RGB );
			
			var x:Int = Std.int( this.count.x );
			var y:Int = Std.int( this.count.y );
			
			this.simulation.bitmapData.setPixel( x, y, color );
		}		
	}
	
	// *********************************************************** //
	// Vector-Functions
	// *********************************************************** //
	
	/**
	 * 
	 * @param	coordinate in function space
	 * @return
	 */
	private function fnc_liniar( coordinate:Vector3 ):Vector2
	{
		return new Vector2( 0.3, 0.3 );	
	}
	
	/**
	 * 
	 * @param	coordinate in function space
	 * @return
	 */
	private function fnc_circle( coordinate:Vector3 ):Vector2
	{
		return new Vector2( -coordinate.y, 3 * coordinate.x );	
	}
	
	/**
	 * 
	 * @param	coordinate in function space
	 * @return
	 */
	private function fnc_wildstar( coordinate:Vector3 ):Vector2
	{
		var x:Float = Math.cos( coordinate.x * coordinate.x + coordinate.y);
		var y:Float = coordinate.x - coordinate.y * coordinate.y + 1;
		
		return new Vector2( x, y );	
	}
	
	/**
	 * 
	 * @param	coordinate in function space
	 * @return
	 */
	private function fnc_sin( coordinate:Vector3 ):Vector2
	{
		var x:Float = Math.sin( coordinate.y );
		var y:Float = Math.sin( coordinate.x );
		
		return new Vector2( x, y );	
	}
	
}