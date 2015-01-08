using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace cs {
	public class Lib : global::haxe.lang.HxObject {
		
		public Lib(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Lib() {
			global::cs.Lib.__hx_ctor_cs_Lib(this);
		}
		
		
		public static void __hx_ctor_cs_Lib(global::cs.Lib __temp_me23) {
		}
		
		
		public static string decimalSeparator;
		
		public static void applyCultureChanges() {
			global::System.Globalization.CultureInfo ci = new global::System.Globalization.CultureInfo(((string) (global::System.Threading.Thread.CurrentThread.CurrentCulture.Name) ), global::haxe.lang.Runtime.toBool(true));
			global::cs.Lib.decimalSeparator = ci.NumberFormat.NumberDecimalSeparator;
			ci.NumberFormat.NumberDecimalSeparator = ((string) (".") );
			global::System.Threading.Thread.CurrentThread.CurrentCulture = ((global::System.Globalization.CultureInfo) (ci) );
		}
		
		
		public static global::System.Type nativeType(object obj) {
			return obj.GetType();
		}
		
		
		public static global::haxe.root.Array<T> array<T>(T[] native) {
			return global::haxe.root.Array<object>.ofNative<T>(native);
		}
		
		
		public static new object __hx_createEmpty() {
			return new global::cs.Lib(global::haxe.lang.EmptyObject.EMPTY);
		}
		
		
		public static new object __hx_create(global::haxe.root.Array arr) {
			return new global::cs.Lib();
		}
		
		
	}
}


