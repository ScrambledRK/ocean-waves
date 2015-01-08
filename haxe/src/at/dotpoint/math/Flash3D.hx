package at.dotpoint.math;

import at.dotpoint.math.vector.Matrix44;
import at.dotpoint.math.vector.Vector3;
import flash.geom.Matrix;
import flash.geom.Matrix3D;
import flash.geom.Vector3D;
import flash.Vector;

/**
 * ...
 * @author Gerald Hattensauer
 */

class Flash3D
{
	/*
	 * 
	 */
	static public function toMatrix3D( matrix:Matrix44, ?output:Matrix3D ):Matrix3D
	{
		if( output == null ) 
			output = new Matrix3D();
		
		var list:Array<Float> = [ 	matrix.m11, matrix.m21, matrix.m31, matrix.m41,
									matrix.m12, matrix.m22, matrix.m32, matrix.m42,
									matrix.m13, matrix.m23, matrix.m33, matrix.m43,
									matrix.m14, matrix.m24, matrix.m34, matrix.m44		];
									
		output.rawData = flash.Vector.ofArray( list );	
		return output;
	}
	
	/*
	 * 
	 */
	static public function toMatrix2D( matrix:Matrix44, ?output:Matrix ):Matrix
	{
		if( output == null ) 
			output = new Matrix();
			
		output.a 	= matrix.m11;
		output.c 	= matrix.m12;
		output.tx 	= matrix.m14;
		
		output.b 	= matrix.m21;
		output.d 	= matrix.m22;
		output.ty 	= matrix.m24;
		
		return output;
	}
	
	/**
	 * 
	 * @param	matrix
	 * @param	output
	 * @return
	 */
	static public function toMatrix44( matrix:Matrix3D, ?output:Matrix44 ):Matrix44
	{
		if( output == null ) 
			output = new Matrix44();
		
		output.m11 = matrix.rawData[0];
		output.m21 = matrix.rawData[1];
		output.m31 = matrix.rawData[2];
		output.m41 = matrix.rawData[3];
		
		output.m12 = matrix.rawData[4];
		output.m22 = matrix.rawData[5];
		output.m32 = matrix.rawData[6];
		output.m42 = matrix.rawData[7];
		
		output.m13 = matrix.rawData[8];
		output.m23 = matrix.rawData[9];
		output.m33 = matrix.rawData[10];
		output.m43 = matrix.rawData[11];
		
		output.m14 = matrix.rawData[12];
		output.m24 = matrix.rawData[13];
		output.m34 = matrix.rawData[14];
		output.m44 = matrix.rawData[15];
		
		return output;
	}
	
	/**
	 * 
	 * @param	vector
	 * @param	output
	 * @return
	 */
	static public function toVector3D( vector:Vector3, ?output:Vector3D ):Vector3D
	{
		if( output == null )
			output = new Vector3D();
		
		output.x = vector.x;
		output.y = vector.y;
		output.z = vector.z;
		output.w = vector.w;
		
		return output;
	}
	
	/**
	 * 
	 * @param	vector
	 * @param	output
	 * @return
	 */
	static public function toVector3( vector:Vector3D, ?output:Vector3 ):Vector3
	{
		if( output == null )
			output = new Vector3();
		
		output.x = vector.x;
		output.y = vector.y;
		output.z = vector.z;
		output.w = vector.w;
		
		return output;
	}
}