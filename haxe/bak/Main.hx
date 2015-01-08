package ;

import at.dotpoint.math.color.ColorFormat;
import at.dotpoint.math.color.ColorUtil;
import at.dotpoint.math.vector.Vector2;
import at.dotpoint.math.vector.Vector3;
import flash.display.Bitmap;
import flash.display.BitmapData;
import flash.display.Shape;
import flash.events.Event;
import flash.Lib;
import flash.display.Sprite;

/**
 * ...
 * 2.718281828
 * @author RK
 */

class Main extends Sprite 
{
	
	private var field:Array<Array<Vector2>>;
	
	private var w:Int;
	private var h:Int;
	
	private var plot:Bitmap;
	private var sketch:Shape;
	
	// *********************************************************** //
	// *********************************************************** //
	
	static function main() 
	{
		Lib.current.addChild(new Main());
	}
	
	public function new() 
	{
		super();
		
		this.field = new Array<Array<Vector2>>();
		
		this.w = 512;
		this.h = 512;
		
		this.plot = new Bitmap( new BitmapData( 512, 512 ) );
		this.addChild( this.plot );
		
		this.sketch = new Shape();
		this.addChild( this.sketch );
		
		this.init();
	}
	
	// *********************************************************** //
	// *********************************************************** //
	
	/**
	 * 
	 */
	private function init():Void
	{
		this.calculate();
		
		this.drawPlot();
		
		if( this.w <= 32 && this.h <= 32 )
			this.drawSketch();				
	}	
	
	// --------------------------------------------------------- //
	// --------------------------------------------------------- //
	
	/**
	 * 
	 */
	private function calculate():Void
	{
		for( x in 0...this.w + 1)
		{
			this.field[x] = new Array<Vector2>();
			
			for( y in 0...this.h + 1)
			{
				this.field[x][y] = this.vF2( x, y );
			}
		}
	}
	
	/**
	 * 
	 * @param	x
	 * @param	y
	 * @return
	 */
	private function vF( x:Float, y:Float ):Vector2
	{		
		var nx:Float = x - this.w * 0.5;
		var ny:Float = y - this.h * 0.5;
		
		// ---------------- //
		
		return new Vector2( -ny, nx );		
	}
	
	/**
	 * 
	 * @param	x
	 * @param	y
	 * @return
	 */
	private function vF2( x:Float, y:Float ):Vector2
	{
		var nx:Float = 2 * Math.PI - (x/this.w) * Math.PI;
		var ny:Float = 2 * Math.PI - (y/this.h) * Math.PI;
		
		nx = Math.cos( nx * nx + ny);
		ny = nx - ny * ny + 1;
		
		var v:Vector2 = new Vector2( nx, ny );
		/*	v.x *= this.w;
			v.y *= this.h;*/
		
		return v;
	}
	
	// --------------------------------------------------------- //
	// --------------------------------------------------------- //
	
	/**
	 * 
	 */
	private function drawPlot():Void
	{
		var plot_w:Float = this.plot.bitmapData.width;
		var plot_h:Float = this.plot.bitmapData.height;
		
		for( x in 0...this.w + 1 )
		{
			for( y in 0...this.h + 1 )
			{
				var vector:Vector2 = this.field[x][y].clone();				
				
				var nx:Float = x - this.w * 0.5;
				var ny:Float = y - this.h * 0.5;
				
				var sx:Int = Std.int( (nx / this.w) * plot_w + plot_w * 0.5 );
				var sy:Int = Std.int( (ny / this.h) * plot_h + plot_h * 0.5 );
				
				// ------------------- //				
				
				vector.x = nx - vector.x;
				vector.y = ny - vector.y;
				
				var magnitude:Float = vector.length() / 512;						
					magnitude = 0;
					
				if( magnitude > 1 )
					magnitude = 1;
				
				vector.normalize();				
				vector.x = (vector.x + 1) * 0.5;
				vector.y = (vector.y + 1) * 0.5;
				
				if( vector.x < 0 || vector.y < 0 || vector.x > 1 || vector.y > 1 )				
					trace( x, y, vector );
				
				// ------------------- //
				
				var color:Int = ColorUtil.toInt( new Vector3( vector.x, vector.y, magnitude, 1 ), ColorFormat.RGB );
					
				this.plot.bitmapData.setPixel( sx, sy, color );
			}
		}		
	}
	
	/**
	 * 
	 */
	private function drawSketch():Void
	{
		var offset_x:Float = 0;
		var offset_y:Float = 0;
		
		var plot_w:Float = this.plot.bitmapData.width;
		var plot_h:Float = this.plot.bitmapData.height;
		
		for( x in 0...this.w + 1 )
		{
			for( y in 0...this.h + 1 )
			{
				var vector:Vector2 = this.field[x][y].clone();				
				
				var nx:Float = x - this.w * 0.5;
				var ny:Float = y - this.h * 0.5;
				
				// ------------------- //
				
				var sx:Float = (nx / this.w) * plot_w + plot_w * 0.5;
				var sy:Float = (ny / this.h) * plot_h + plot_h * 0.5;
					
				vector.x = nx - vector.x;
				vector.y = ny - vector.y;
				
				var magnitude:Float = vector.length();
					magnitude *= 1;
					
				vector.normalize();				
				
				var ex:Float = sx + vector.x * magnitude;
				var ey:Float = sy + vector.y * magnitude;
				
				vector.x = (vector.x + 1) * 0.5;
				vector.y = (vector.y + 1) * 0.5;
				
				// ------------------- //
				
				var color:Int = ColorUtil.toInt( new Vector3( vector.x, vector.y, magnitude, 1 ), ColorFormat.RGB );
				
				this.sketch.graphics.lineStyle( 2, color, 0.8 );
				this.sketch.graphics.moveTo( offset_x + sx, offset_y + sy );
				this.sketch.graphics.lineTo( offset_x + ex, offset_y + ey );
			}
		}
	}
	
	/**
	 * 
	 */
	private function drawPhase( sx:Float, sy:Float ):Void
	{
		var plot_w:Float = this.plot.bitmapData.width;
		var plot_h:Float = this.plot.bitmapData.height;
		
		var ox:Float = sx;
		var oy:Float = sy;
		
		for( t in 0...100 )
		{			
			var nv:Vector2 = new Vector2( -sy, sx );
			
			nv.x = sx - nv.x;
			nv.y = sy - nv.y;	
			
			nv.normalize();
			//nv.x * 0.015;
			//nv.y * 0.015;
			
			
			ox = sx;
			oy = sy;
			sx = sx - nv.x;
			sy = sy - nv.y;
			
			var opx:Float = (ox / this.w) * plot_w + plot_w * 0.5;
			var opy:Float = (oy / this.h) * plot_h + plot_h * 0.5;
			var npx:Float = (sx / this.w) * plot_w + plot_w * 0.5;
			var npy:Float = (sy / this.h) * plot_h + plot_h * 0.5;
			
			this.sketch.graphics.lineStyle( 1, 0, 1 );
			this.sketch.graphics.moveTo( opx, opy );
			this.sketch.graphics.lineTo( npx, npy );
		}
	}
	
	/*private function drawCirle():Void
	{
		var offset_x:Float = 0;
		var offset_y:Float = 0;
		
		var plot_w:Float = this.plot.bitmapData.width;
		var plot_h:Float = this.plot.bitmapData.height;
		
		var center:Vector2 = new Vector2( plot_w * 0.5, plot_h * 0.5 ); 
		var steps:Int = 32;
		
		for( x in 0...this.w + 1 )
		{
			for( y in 0...this.h + 1 )
			{
				var nx:Float = x - this.w * 0.5;
				var ny:Float = y - this.h * 0.5;
				
				// ------------------- //
				
				var sx:Float = (nx / this.w) * plot_w + plot_w * 0.5;
				var sy:Float = (ny / this.h) * plot_h + plot_h * 0.5;
				
				var rx:Float = sx - center.x;
				var ry:Float = sy - center.y;
				
				var radius:Float = Math.sqrt( rx * rx + ry * ry );
				
				for( t in 0...steps )
				{					
					var s:Float = (t / steps) * (2 * Math.PI);
					
					var ex:Float = center.x + radius * Math.cos(s);
					var ey:Float = center.y + radius * Math.sin(s);					
					
					//if( t > 1 )
					//{
						//this.sketch.graphics.lineStyle( 2, 0, 0.5 );
						//this.sketch.graphics.moveTo( offset_x + sx, offset_y + sy );
						//this.sketch.graphics.lineTo( offset_x + ex, offset_y + ey );		
					//}
					//sx = ex;
					//sy = ey;					
				}
			}
		}
	}*/
	
}