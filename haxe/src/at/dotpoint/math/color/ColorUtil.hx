package at.dotpoint.math.color;

import at.dotpoint.math.vector.Vector3;

/**
 * ...
 * @author Gerald Hattensauer
 */
class ColorUtil
{

	public static function getRandomColorInt():Int
	{
		var vector:Vector3 = new Vector3();
			vector.x = Math.floor( Math.random() * 255 );
			vector.y = Math.floor( Math.random() * 255 );
			vector.z = Math.floor( Math.random() * 255 );
		
		return ColorUtil.toInt( vector, ColorFormat.RGB );
	}
	
	/**
	 * 
	 */
	public static function toVector( value:Int, format:ColorFormat, ?output:Vector3 ):Vector3
	{
		if ( output == null ) output = new Vector3();
		
		var a:Float = ((value >> 24 ) 	& 0xFF) / 255;
		var r:Float = ((value >> 16 ) 	& 0xFF) / 255;
		var g:Float = ((value >> 8  ) 	& 0xFF) / 255;
		var b:Float = ((value  	 ) 		& 0xFF) / 255;
		
		switch( format )
		{
			case ColorFormat.ARGB:
			{
				output.x = a;
				output.y = r;
				output.z = g;
				output.w = b;
			}
			
			case ColorFormat.RGBA:
			{
				output.x = r;
				output.y = g;
				output.z = b;
				output.w = a;
			}
			
			case ColorFormat.RGB:
			{
				output.x = r;
				output.y = g;
				output.z = b;
			}
		}
		
		return output;
	}
	
	/**
	 * 
	 */
	public static function toInt( value:Vector3, format:ColorFormat ):Int
	{
		var x:Int = Std.int(value.x * 255);
		var y:Int = Std.int(value.y * 255);
		var z:Int = Std.int(value.z * 255);
		var w:Int = Std.int(value.w * 255);
		
		switch( format )
		{
			case ColorFormat.ARGB:
			{
				return (x << 24) | (y << 16) | (z << 8) | w;
			}
			
			case ColorFormat.RGBA:
			{
				return (w << 24) | (x << 16) | (y << 8) | z;
			}
			
			case ColorFormat.RGB:
			{
				return (x << 16) | (y << 8) | z;
			}
		}
		
		return -1;
	}
	
	/**
	 * 
	 * @param	value
	 * @param	alpha
	 * @return
	 */
	public static function toString( value:Int, alpha:Bool = true ):String
	{
		return StringTools.hex( value, alpha ? 8 : 6 );
	}
}