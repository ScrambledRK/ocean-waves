using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.root {
	public class Vertex : global::haxe.lang.HxObject {
		
		public Vertex(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Vertex() {
			global::haxe.root.Vertex.__hx_ctor__Vertex(this);
		}
		
		
		public static void __hx_ctor__Vertex(global::haxe.root.Vertex __temp_me10) {
			__temp_me10.c_h0_norm = new global::at.dotpoint.math.vector.Vector2(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
			__temp_me10.c_h0_conj = new global::at.dotpoint.math.vector.Vector2(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
			__temp_me10.position = new global::at.dotpoint.math.vector.Vector3(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
		}
		
		
		public static new object __hx_createEmpty() {
			return new global::haxe.root.Vertex(global::haxe.lang.EmptyObject.EMPTY);
		}
		
		
		public static new object __hx_create(global::haxe.root.Array arr) {
			return new global::haxe.root.Vertex();
		}
		
		
		public global::at.dotpoint.math.vector.Vector2 c_h0_norm;
		
		public global::at.dotpoint.math.vector.Vector2 c_h0_conj;
		
		public global::at.dotpoint.math.vector.Vector3 position;
		
		public global::at.dotpoint.math.vector.Vector3 normal;
		
		public override object __hx_setField(string field, int hash, object @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 812216871:
					{
						this.normal = ((global::at.dotpoint.math.vector.Vector3) (@value) );
						return @value;
					}
					
					
					case 1257939113:
					{
						this.position = ((global::at.dotpoint.math.vector.Vector3) (@value) );
						return @value;
					}
					
					
					case 1472420579:
					{
						this.c_h0_conj = ((global::at.dotpoint.math.vector.Vector2) (@value) );
						return @value;
					}
					
					
					case 1594406711:
					{
						this.c_h0_norm = ((global::at.dotpoint.math.vector.Vector2) (@value) );
						return @value;
					}
					
					
					default:
					{
						return base.__hx_setField(field, hash, @value, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 812216871:
					{
						return this.normal;
					}
					
					
					case 1257939113:
					{
						return this.position;
					}
					
					
					case 1472420579:
					{
						return this.c_h0_conj;
					}
					
					
					case 1594406711:
					{
						return this.c_h0_norm;
					}
					
					
					default:
					{
						return base.__hx_getField(field, hash, throwErrors, isCheck, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override void __hx_getFields(global::haxe.root.Array<object> baseArr) {
			baseArr.push("normal");
			baseArr.push("position");
			baseArr.push("c_h0_conj");
			baseArr.push("c_h0_norm");
			{
				base.__hx_getFields(baseArr);
			}
			
		}
		
		
	}
}


