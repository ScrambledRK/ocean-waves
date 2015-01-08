using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace at.dotpoint.math.vector {
	public class Vector2 : global::haxe.lang.HxObject, global::at.dotpoint.math.vector.IVector2 {
		
		public Vector2(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Vector2(global::haxe.lang.Null<double> x, global::haxe.lang.Null<double> y) {
			global::at.dotpoint.math.vector.Vector2.__hx_ctor_at_dotpoint_math_vector_Vector2(this, x, y);
		}
		
		
		public static void __hx_ctor_at_dotpoint_math_vector_Vector2(global::at.dotpoint.math.vector.Vector2 __temp_me15, global::haxe.lang.Null<double> x, global::haxe.lang.Null<double> y) {
			double __temp_y14 = ( ( ! (y.hasValue) ) ? (((double) (0) )) : ((y).@value) );
			double __temp_x13 = ( ( ! (x.hasValue) ) ? (((double) (0) )) : ((x).@value) );
			__temp_me15.set_x(__temp_x13);
			__temp_me15.set_y(__temp_y14);
		}
		
		
		public static T @add<T>(global::at.dotpoint.math.vector.IVector2 a, global::at.dotpoint.math.vector.IVector2 b, global::haxe.lang.Null<T> output) {
			if ( ! (output.hasValue) ) {
				output = new global::haxe.lang.Null<T>(global::haxe.lang.Runtime.genericCast<T>(((object) (new global::at.dotpoint.math.vector.Vector2(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>))) )), true);
			}
			
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_x", 2049940315, new global::haxe.root.Array<object>(new object[]{( a.get_x() + b.get_x() )}));
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_y", 2049940316, new global::haxe.root.Array<object>(new object[]{( a.get_y() + b.get_y() )}));
			return (output).@value;
		}
		
		
		public static T subtract<T>(global::at.dotpoint.math.vector.IVector2 a, global::at.dotpoint.math.vector.IVector2 b, global::haxe.lang.Null<T> output) {
			if ( ! (output.hasValue) ) {
				output = new global::haxe.lang.Null<T>(global::haxe.lang.Runtime.genericCast<T>(((object) (new global::at.dotpoint.math.vector.Vector2(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>))) )), true);
			}
			
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_x", 2049940315, new global::haxe.root.Array<object>(new object[]{( a.get_x() - b.get_x() )}));
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_y", 2049940316, new global::haxe.root.Array<object>(new object[]{( a.get_y() - b.get_y() )}));
			return (output).@value;
		}
		
		
		public static T scale<T>(global::at.dotpoint.math.vector.IVector2 a, double scalar, global::haxe.lang.Null<T> output) {
			if ( ! (output.hasValue) ) {
				output = new global::haxe.lang.Null<T>(global::haxe.lang.Runtime.genericCast<T>(((object) (new global::at.dotpoint.math.vector.Vector2(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>))) )), true);
			}
			
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_x", 2049940315, new global::haxe.root.Array<object>(new object[]{( a.get_x() * scalar )}));
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_y", 2049940316, new global::haxe.root.Array<object>(new object[]{( a.get_y() * scalar )}));
			return (output).@value;
		}
		
		
		public static bool isEqual(global::at.dotpoint.math.vector.IVector2 a, global::at.dotpoint.math.vector.IVector2 b) {
			bool __temp_stmt40 = default(bool);
			{
				double a1 = a.get_x();
				double b1 = b.get_x();
				__temp_stmt40 = ( (( a1 > b1 )) ? (( ( a1 - b1 ) < 1e-08 )) : (( ( b1 - a1 ) < 1e-08 )) );
			}
			
			if ( ! (__temp_stmt40) ) {
				return false;
			}
			
			bool __temp_stmt41 = default(bool);
			{
				double a2 = a.get_y();
				double b2 = b.get_y();
				__temp_stmt41 = ( (( a2 > b2 )) ? (( ( a2 - b2 ) < 1e-08 )) : (( ( b2 - a2 ) < 1e-08 )) );
			}
			
			if ( ! (__temp_stmt41) ) {
				return false;
			}
			
			return true;
		}
		
		
		public static new object __hx_createEmpty() {
			return new global::at.dotpoint.math.vector.Vector2(global::haxe.lang.EmptyObject.EMPTY);
		}
		
		
		public static new object __hx_create(global::haxe.root.Array arr) {
			unchecked {
				return new global::at.dotpoint.math.vector.Vector2(global::haxe.lang.Null<object>.ofDynamic<double>(arr[0]), global::haxe.lang.Null<object>.ofDynamic<double>(arr[1]));
			}
		}
		
		
		public double x;
		
		public double y;
		
		public virtual global::at.dotpoint.math.vector.Vector2 clone(global::at.dotpoint.math.vector.Vector2 output) {
			if (( output != null )) {
				output = output;
			}
			else {
				output = new global::at.dotpoint.math.vector.Vector2(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
			}
			
			output.set_x(this.get_x());
			output.set_y(this.get_y());
			return output;
		}
		
		
		public virtual double get_x() {
			return this.x;
		}
		
		
		public virtual double set_x(double @value) {
			return this.x = @value;
		}
		
		
		public virtual double get_y() {
			return this.y;
		}
		
		
		public virtual double set_y(double @value) {
			return this.y = @value;
		}
		
		
		public virtual void @set(double x, double y) {
			this.set_x(x);
			this.set_y(y);
		}
		
		
		public virtual void normalize() {
			double l = this.length();
			if (( l == 0 )) {
				this.set_x(((double) (0) ));
				this.set_y(((double) (0) ));
			}
			else {
				double k = ( 1.0 / this.length() );
				{
					global::at.dotpoint.math.vector.Vector2 _g = this;
					_g.set_x(( _g.get_x() * k ));
				}
				
				{
					global::at.dotpoint.math.vector.Vector2 _g1 = this;
					_g1.set_y(( _g1.get_y() * k ));
				}
				
			}
			
		}
		
		
		public virtual double length() {
			{
				double v = ( ( this.get_x() * this.get_x() ) + ( this.get_y() * this.get_y() ) );
				return global::System.Math.Sqrt(((double) (v) ));
			}
			
		}
		
		
		public virtual double lengthSq() {
			return ( ( this.get_x() * this.get_x() ) + ( this.get_y() * this.get_y() ) );
		}
		
		
		public virtual global::haxe.root.Array<double> toArray(global::haxe.root.Array<double> output) {
			unchecked {
				if (( output != null )) {
					output = new global::haxe.root.Array<double>();
				}
				
				output[0] = this.get_x();
				output[1] = this.get_y();
				return output;
			}
		}
		
		
		public virtual double getIndex(int index) {
			unchecked {
				switch (index) {
					case 0:
					{
						return this.get_x();
					}
					
					
					case 1:
					{
						return this.get_y();
					}
					
					
					default:
					{
						throw global::haxe.lang.HaxeException.wrap("out of bounds");
					}
					
				}
				
			}
		}
		
		
		public virtual void setIndex(int index, double @value) {
			unchecked {
				switch (index) {
					case 0:
					{
						this.set_x(@value);
						break;
					}
					
					
					case 1:
					{
						this.set_y(@value);
						break;
					}
					
					
					default:
					{
						throw global::haxe.lang.HaxeException.wrap("out of bounds");
					}
					
				}
				
			}
		}
		
		
		public virtual string toString() {
			return global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("[Vector2;", global::haxe.lang.Runtime.toString(this.get_x())), ", "), global::haxe.lang.Runtime.toString(this.get_y())), "]");
		}
		
		
		public override double __hx_setField_f(string field, int hash, double @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 121:
					{
						if (handleProperties) {
							this.set_y(@value);
							return @value;
						}
						else {
							this.y = ((double) (@value) );
							return @value;
						}
						
					}
					
					
					case 120:
					{
						if (handleProperties) {
							this.set_x(@value);
							return @value;
						}
						else {
							this.x = ((double) (@value) );
							return @value;
						}
						
					}
					
					
					default:
					{
						return base.__hx_setField_f(field, hash, @value, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_setField(string field, int hash, object @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 121:
					{
						if (handleProperties) {
							this.set_y(((double) (global::haxe.lang.Runtime.toDouble(@value)) ));
							return @value;
						}
						else {
							this.y = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
							return @value;
						}
						
					}
					
					
					case 120:
					{
						if (handleProperties) {
							this.set_x(((double) (global::haxe.lang.Runtime.toDouble(@value)) ));
							return @value;
						}
						else {
							this.x = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
							return @value;
						}
						
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
					case 946786476:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "toString", 946786476)) );
					}
					
					
					case 1279853584:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "setIndex", 1279853584)) );
					}
					
					
					case 501983900:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "getIndex", 501983900)) );
					}
					
					
					case 1913895454:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "toArray", 1913895454)) );
					}
					
					
					case 532898596:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "lengthSq", 532898596)) );
					}
					
					
					case 520590566:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "length", 520590566)) );
					}
					
					
					case 731985805:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "normalize", 731985805)) );
					}
					
					
					case 5741474:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "set", 5741474)) );
					}
					
					
					case 2049940316:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "set_y", 2049940316)) );
					}
					
					
					case 291546448:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get_y", 291546448)) );
					}
					
					
					case 2049940315:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "set_x", 2049940315)) );
					}
					
					
					case 291546447:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get_x", 291546447)) );
					}
					
					
					case 1214452573:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "clone", 1214452573)) );
					}
					
					
					case 121:
					{
						if (handleProperties) {
							return this.get_y();
						}
						else {
							return this.y;
						}
						
					}
					
					
					case 120:
					{
						if (handleProperties) {
							return this.get_x();
						}
						else {
							return this.x;
						}
						
					}
					
					
					default:
					{
						return base.__hx_getField(field, hash, throwErrors, isCheck, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 121:
					{
						if (handleProperties) {
							return this.get_y();
						}
						else {
							return this.y;
						}
						
					}
					
					
					case 120:
					{
						if (handleProperties) {
							return this.get_x();
						}
						else {
							return this.x;
						}
						
					}
					
					
					default:
					{
						return base.__hx_getField_f(field, hash, throwErrors, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_invokeField(string field, int hash, global::haxe.root.Array dynargs) {
			unchecked {
				switch (hash) {
					case 946786476:
					{
						return this.toString();
					}
					
					
					case 1279853584:
					{
						this.setIndex(((int) (global::haxe.lang.Runtime.toInt(dynargs[0])) ), ((double) (global::haxe.lang.Runtime.toDouble(dynargs[1])) ));
						break;
					}
					
					
					case 501983900:
					{
						return this.getIndex(((int) (global::haxe.lang.Runtime.toInt(dynargs[0])) ));
					}
					
					
					case 1913895454:
					{
						return this.toArray(((global::haxe.root.Array<double>) (global::haxe.root.Array<object>.__hx_cast<double>(((global::haxe.root.Array) (dynargs[0]) ))) ));
					}
					
					
					case 532898596:
					{
						return this.lengthSq();
					}
					
					
					case 520590566:
					{
						return this.length();
					}
					
					
					case 731985805:
					{
						this.normalize();
						break;
					}
					
					
					case 5741474:
					{
						this.@set(((double) (global::haxe.lang.Runtime.toDouble(dynargs[0])) ), ((double) (global::haxe.lang.Runtime.toDouble(dynargs[1])) ));
						break;
					}
					
					
					case 2049940316:
					{
						return this.set_y(((double) (global::haxe.lang.Runtime.toDouble(dynargs[0])) ));
					}
					
					
					case 291546448:
					{
						return this.get_y();
					}
					
					
					case 2049940315:
					{
						return this.set_x(((double) (global::haxe.lang.Runtime.toDouble(dynargs[0])) ));
					}
					
					
					case 291546447:
					{
						return this.get_x();
					}
					
					
					case 1214452573:
					{
						return this.clone(((global::at.dotpoint.math.vector.Vector2) (dynargs[0]) ));
					}
					
					
					default:
					{
						return base.__hx_invokeField(field, hash, dynargs);
					}
					
				}
				
				return null;
			}
		}
		
		
		public override void __hx_getFields(global::haxe.root.Array<object> baseArr) {
			baseArr.push("y");
			baseArr.push("x");
			{
				base.__hx_getFields(baseArr);
			}
			
		}
		
		
		public override string ToString(){
			return this.toString();
		}
		
		
	}
}


