using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace at.dotpoint.math {
	public class MathUtil : global::haxe.lang.HxObject {
		
		static MathUtil() {
			global::at.dotpoint.math.MathUtil.ZERO_TOLERANCE = 1e-08;
			global::at.dotpoint.math.MathUtil.RAD_DEG = 57.29577951308232;
			global::at.dotpoint.math.MathUtil.DEG_RAD = 0.017453292519943295;
			global::at.dotpoint.math.MathUtil.FLOAT_MAX = 3.4028234663852886e+37;
			global::at.dotpoint.math.MathUtil.FLOAT_MIN = -3.4028234663852886e+37;
		}
		
		
		public MathUtil(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public MathUtil() {
			global::at.dotpoint.math.MathUtil.__hx_ctor_at_dotpoint_math_MathUtil(this);
		}
		
		
		public static void __hx_ctor_at_dotpoint_math_MathUtil(global::at.dotpoint.math.MathUtil __temp_me12) {
		}
		
		
		public static double ZERO_TOLERANCE;
		
		public static double RAD_DEG;
		
		public static double DEG_RAD;
		
		public static double FLOAT_MAX;
		
		public static double FLOAT_MIN;
		
		public static bool isEqual(double a, double b) {
			if (( a > b )) {
				return ( ( a - b ) < 1e-08 );
			}
			else {
				return ( ( b - a ) < 1e-08 );
			}
			
		}
		
		
		public static double getAngle(double x1, double y1, double x2, double y2) {
			double dx = ( x2 - x1 );
			double dy = ( y2 - y1 );
			return global::System.Math.Atan2(((double) (dy) ), ((double) (dx) ));
		}
		
		
		public static new object __hx_createEmpty() {
			return new global::at.dotpoint.math.MathUtil(global::haxe.lang.EmptyObject.EMPTY);
		}
		
		
		public static new object __hx_create(global::haxe.root.Array arr) {
			return new global::at.dotpoint.math.MathUtil();
		}
		
		
	}
}


