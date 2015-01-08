using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace cs {
	public class Boot : global::haxe.lang.HxObject {
		
		public Boot(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Boot() {
			global::cs.Boot.__hx_ctor_cs_Boot(this);
		}
		
		
		public static void __hx_ctor_cs_Boot(global::cs.Boot __temp_me22) {
		}
		
		
		public static void init() {
			global::cs.Lib.applyCultureChanges();
		}
		
		
		public static new object __hx_createEmpty() {
			return new global::cs.Boot(global::haxe.lang.EmptyObject.EMPTY);
		}
		
		
		public static new object __hx_create(global::haxe.root.Array arr) {
			return new global::cs.Boot();
		}
		
		
	}
}


