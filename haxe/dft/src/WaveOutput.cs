using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.root {
	public class WaveOutput : global::haxe.lang.HxObject {
		
		public WaveOutput(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public WaveOutput() {
			global::haxe.root.WaveOutput.__hx_ctor__WaveOutput(this);
		}
		
		
		public static void __hx_ctor__WaveOutput(global::haxe.root.WaveOutput __temp_me11) {
			__temp_me11.height = new global::at.dotpoint.math.vector.Vector2(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
			__temp_me11.displacement = new global::at.dotpoint.math.vector.Vector2(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
			__temp_me11.normal = new global::at.dotpoint.math.vector.Vector2(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
		}
		
		
		public static new object __hx_createEmpty() {
			return new global::haxe.root.WaveOutput(global::haxe.lang.EmptyObject.EMPTY);
		}
		
		
		public static new object __hx_create(global::haxe.root.Array arr) {
			return new global::haxe.root.WaveOutput();
		}
		
		
		public global::at.dotpoint.math.vector.Vector2 height;
		
		public global::at.dotpoint.math.vector.Vector2 displacement;
		
		public global::at.dotpoint.math.vector.Vector2 normal;
		
		public override object __hx_setField(string field, int hash, object @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 812216871:
					{
						this.normal = ((global::at.dotpoint.math.vector.Vector2) (@value) );
						return @value;
					}
					
					
					case 488854231:
					{
						this.displacement = ((global::at.dotpoint.math.vector.Vector2) (@value) );
						return @value;
					}
					
					
					case 38537191:
					{
						this.height = ((global::at.dotpoint.math.vector.Vector2) (@value) );
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
					
					
					case 488854231:
					{
						return this.displacement;
					}
					
					
					case 38537191:
					{
						return this.height;
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
			baseArr.push("displacement");
			baseArr.push("height");
			{
				base.__hx_getFields(baseArr);
			}
			
		}
		
		
	}
}


