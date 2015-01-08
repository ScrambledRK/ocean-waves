using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.root {
	public class Std {
		
		public Std() {
		}
		
		
		public static bool @is(object v, object t) {
			if (global::haxe.lang.Runtime.eq(v, null)) {
				return global::haxe.lang.Runtime.eq(t, typeof(object));
			}
			
			if (global::haxe.lang.Runtime.eq(t, null)) {
				return false;
			}
			
			global::System.Type clt = ((global::System.Type) (t) );
			if (global::haxe.lang.Runtime.typeEq(clt, null)) {
				return false;
			}
			
			string name = global::haxe.lang.Runtime.toString(clt);
			switch (name) {
				case "System.Double":
				{
					return v is double || v is int;
				}
				
				
				case "System.Int32":
				{
					return haxe.lang.Runtime.isInt(v);
				}
				
				
				case "System.Boolean":
				{
					return v is bool;
				}
				
				
				case "System.Object":
				{
					return true;
				}
				
				
			}
			
			return clt.IsAssignableFrom(((global::System.Type) (global::cs.Lib.nativeType(v)) ));
		}
		
		
		public static string @string(object s) {
			if (global::haxe.lang.Runtime.eq(s, null)) {
				return "null";
			}
			
			if (( s is bool )) {
				if (global::haxe.lang.Runtime.toBool(s)) {
					return "true";
				}
				else {
					return "false";
				}
				
			}
			
			return s.ToString();
		}
		
		
	}
}


