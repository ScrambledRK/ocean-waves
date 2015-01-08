using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.root {
	public class Math {
		
		static Math() {
			{
				global::haxe.root.Math.PI = global::System.Math.PI;
				global::haxe.root.Math.NaN = global::System.Double.NaN;
				global::haxe.root.Math.NEGATIVE_INFINITY = global::System.Double.NegativeInfinity;
				global::haxe.root.Math.POSITIVE_INFINITY = global::System.Double.PositiveInfinity;
				global::haxe.root.Math.rand = new global::System.Random();
			}
			
		}
		
		
		public Math() {
		}
		
		
		public static global::System.Random rand;
		
		public static double PI;
		
		public static double NaN;
		
		public static double NEGATIVE_INFINITY;
		
		public static double POSITIVE_INFINITY;
		
	}
}


