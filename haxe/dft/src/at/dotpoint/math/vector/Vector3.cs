using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace at.dotpoint.math.vector {
	public class Vector3 : global::haxe.lang.HxObject, global::at.dotpoint.math.vector.IVector3 {
		
		public Vector3(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Vector3(global::haxe.lang.Null<double> x, global::haxe.lang.Null<double> y, global::haxe.lang.Null<double> z, global::haxe.lang.Null<double> w) {
			global::at.dotpoint.math.vector.Vector3.__hx_ctor_at_dotpoint_math_vector_Vector3(this, x, y, z, w);
		}
		
		
		public static void __hx_ctor_at_dotpoint_math_vector_Vector3(global::at.dotpoint.math.vector.Vector3 __temp_me21, global::haxe.lang.Null<double> x, global::haxe.lang.Null<double> y, global::haxe.lang.Null<double> z, global::haxe.lang.Null<double> w) {
			unchecked {
				double __temp_w20 = ( ( ! (w.hasValue) ) ? (((double) (1) )) : ((w).@value) );
				double __temp_z19 = ( ( ! (z.hasValue) ) ? (((double) (0) )) : ((z).@value) );
				double __temp_y18 = ( ( ! (y.hasValue) ) ? (((double) (0) )) : ((y).@value) );
				double __temp_x17 = ( ( ! (x.hasValue) ) ? (((double) (0) )) : ((x).@value) );
				__temp_me21.set_x(__temp_x17);
				__temp_me21.set_y(__temp_y18);
				__temp_me21.set_z(__temp_z19);
				__temp_me21.set_w(__temp_w20);
			}
		}
		
		
		public static T @add<T>(global::at.dotpoint.math.vector.IVector3 a, global::at.dotpoint.math.vector.IVector3 b, global::haxe.lang.Null<T> output) {
			if ( ! (output.hasValue) ) {
				output = new global::haxe.lang.Null<T>(global::haxe.lang.Runtime.genericCast<T>(((object) (new global::at.dotpoint.math.vector.Vector3(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>))) )), true);
			}
			
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_x", 2049940315, new global::haxe.root.Array<object>(new object[]{( a.get_x() + b.get_x() )}));
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_y", 2049940316, new global::haxe.root.Array<object>(new object[]{( a.get_y() + b.get_y() )}));
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_z", 2049940317, new global::haxe.root.Array<object>(new object[]{( a.get_z() + b.get_z() )}));
			return (output).@value;
		}
		
		
		public static T subtract<T>(global::at.dotpoint.math.vector.IVector3 a, global::at.dotpoint.math.vector.IVector3 b, global::haxe.lang.Null<T> output) {
			if ( ! (output.hasValue) ) {
				output = new global::haxe.lang.Null<T>(global::haxe.lang.Runtime.genericCast<T>(((object) (new global::at.dotpoint.math.vector.Vector3(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>))) )), true);
			}
			
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_x", 2049940315, new global::haxe.root.Array<object>(new object[]{( a.get_x() - b.get_x() )}));
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_y", 2049940316, new global::haxe.root.Array<object>(new object[]{( a.get_y() - b.get_y() )}));
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_z", 2049940317, new global::haxe.root.Array<object>(new object[]{( a.get_z() - b.get_z() )}));
			return (output).@value;
		}
		
		
		public static T scale<T>(global::at.dotpoint.math.vector.IVector3 a, double scalar, global::haxe.lang.Null<T> output) {
			if ( ! (output.hasValue) ) {
				output = new global::haxe.lang.Null<T>(global::haxe.lang.Runtime.genericCast<T>(((object) (new global::at.dotpoint.math.vector.Vector3(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>))) )), true);
			}
			
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_x", 2049940315, new global::haxe.root.Array<object>(new object[]{( a.get_x() * scalar )}));
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_y", 2049940316, new global::haxe.root.Array<object>(new object[]{( a.get_y() * scalar )}));
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_z", 2049940317, new global::haxe.root.Array<object>(new object[]{( a.get_z() * scalar )}));
			return (output).@value;
		}
		
		
		public static T cross<T>(global::at.dotpoint.math.vector.IVector3 a, global::at.dotpoint.math.vector.IVector3 b, global::haxe.lang.Null<T> output) {
			if ( ! (output.hasValue) ) {
				output = new global::haxe.lang.Null<T>(global::haxe.lang.Runtime.genericCast<T>(((object) (new global::at.dotpoint.math.vector.Vector3(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>))) )), true);
			}
			
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_x", 2049940315, new global::haxe.root.Array<object>(new object[]{( ( a.get_y() * b.get_z() ) - ( a.get_z() * b.get_y() ) )}));
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_y", 2049940316, new global::haxe.root.Array<object>(new object[]{( ( a.get_z() * b.get_x() ) - ( a.get_x() * b.get_z() ) )}));
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_z", 2049940317, new global::haxe.root.Array<object>(new object[]{( ( a.get_x() * b.get_y() ) - ( a.get_y() * b.get_x() ) )}));
			return (output).@value;
		}
		
		
		public static double dot(global::at.dotpoint.math.vector.IVector3 a, global::at.dotpoint.math.vector.IVector3 b) {
			return ( ( ( a.get_x() * b.get_x() ) + ( a.get_y() * b.get_y() ) ) + ( a.get_z() * b.get_z() ) );
		}
		
		
		public static T multiplyMatrix<T>(global::at.dotpoint.math.vector.IVector3 a, global::at.dotpoint.math.vector.IMatrix44 b, global::haxe.lang.Null<T> output) {
			if ( ! (output.hasValue) ) {
				output = new global::haxe.lang.Null<T>(global::haxe.lang.Runtime.genericCast<T>(((object) (new global::at.dotpoint.math.vector.Vector3(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>))) )), true);
			}
			
			double x = a.get_x();
			double y = a.get_y();
			double z = a.get_z();
			double w = a.get_w();
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_x", 2049940315, new global::haxe.root.Array<object>(new object[]{( ( ( ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m11", 5431437, true)) ) * ((double) (x) ) ) + ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m12", 5431438, true)) ) * ((double) (y) ) ) ) + ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m13", 5431439, true)) ) * ((double) (z) ) ) ) + ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m14", 5431440, true)) ) * ((double) (w) ) ) )}));
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_y", 2049940316, new global::haxe.root.Array<object>(new object[]{( ( ( ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m21", 5431660, true)) ) * ((double) (x) ) ) + ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m22", 5431661, true)) ) * ((double) (y) ) ) ) + ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m23", 5431662, true)) ) * ((double) (z) ) ) ) + ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m24", 5431663, true)) ) * ((double) (w) ) ) )}));
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_z", 2049940317, new global::haxe.root.Array<object>(new object[]{( ( ( ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m31", 5431883, true)) ) * ((double) (x) ) ) + ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m32", 5431884, true)) ) * ((double) (y) ) ) ) + ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m33", 5431885, true)) ) * ((double) (z) ) ) ) + ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m34", 5431886, true)) ) * ((double) (w) ) ) )}));
			global::haxe.lang.Runtime.callField((output).toDynamic(), "set_w", 2049940314, new global::haxe.root.Array<object>(new object[]{( ( ( ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m41", 5432106, true)) ) * ((double) (x) ) ) + ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m42", 5432107, true)) ) * ((double) (y) ) ) ) + ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m43", 5432108, true)) ) * ((double) (z) ) ) ) + ( ((double) (global::haxe.lang.Runtime.getField_f(b, "m44", 5432109, true)) ) * ((double) (w) ) ) )}));
			return (output).@value;
		}
		
		
		public static T project<T>(global::at.dotpoint.math.vector.IVector3 a, global::at.dotpoint.math.vector.IVector3 b, global::haxe.lang.Null<T> output) {
			if ( ! (output.hasValue) ) {
				output = new global::haxe.lang.Null<T>(global::haxe.lang.Runtime.genericCast<T>(((object) (new global::at.dotpoint.math.vector.Vector3(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>))) )), true);
			}
			
			double l = ( ( ( a.get_x() * a.get_x() ) + ( a.get_y() * a.get_y() ) ) + ( a.get_z() * a.get_z() ) );
			if (( l == 0 )) {
				throw global::haxe.lang.HaxeException.wrap("undefined result");
			}
			
			double d = global::at.dotpoint.math.vector.Vector3.dot(a, b);
			double div = ( d / l );
			return global::at.dotpoint.math.vector.Vector3.scale<T>(a, div, output);
		}
		
		
		public static void orthoNormalize(global::haxe.root.Array<object> vectors) {
			int _g1 = 0;
			int _g = vectors.length;
			while (( _g1 < _g )) {
				int i = _g1++;
				global::at.dotpoint.math.vector.Vector3 sum = new global::at.dotpoint.math.vector.Vector3(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
				{
					int _g2 = 0;
					while (( _g2 < i )) {
						int j = _g2++;
						global::at.dotpoint.math.vector.Vector3 projected = ((global::at.dotpoint.math.vector.Vector3) (global::at.dotpoint.math.vector.Vector3.project<object>(((global::at.dotpoint.math.vector.IVector3) (vectors[i]) ), ((global::at.dotpoint.math.vector.IVector3) (vectors[j]) ), new global::haxe.lang.Null<object>(null, false))) );
						global::at.dotpoint.math.vector.Vector3.@add<object>(sum, projected, new global::haxe.lang.Null<object>(sum, true));
					}
					
				}
				
				((global::at.dotpoint.math.vector.IVector3) (global::at.dotpoint.math.vector.Vector3.subtract<object>(((global::at.dotpoint.math.vector.IVector3) (vectors[i]) ), sum, new global::haxe.lang.Null<object>(((global::at.dotpoint.math.vector.IVector3) (vectors[i]) ), true))) ).normalize();
			}
			
		}
		
		
		public static bool isEqual(global::at.dotpoint.math.vector.IVector3 a, global::at.dotpoint.math.vector.IVector3 b) {
			bool __temp_stmt42 = default(bool);
			{
				double a1 = a.get_x();
				double b1 = b.get_x();
				__temp_stmt42 = ( (( a1 > b1 )) ? (( ( a1 - b1 ) < 1e-08 )) : (( ( b1 - a1 ) < 1e-08 )) );
			}
			
			if ( ! (__temp_stmt42) ) {
				return false;
			}
			
			bool __temp_stmt43 = default(bool);
			{
				double a2 = a.get_y();
				double b2 = b.get_y();
				__temp_stmt43 = ( (( a2 > b2 )) ? (( ( a2 - b2 ) < 1e-08 )) : (( ( b2 - a2 ) < 1e-08 )) );
			}
			
			if ( ! (__temp_stmt43) ) {
				return false;
			}
			
			bool __temp_stmt44 = default(bool);
			{
				double a3 = a.get_z();
				double b3 = b.get_z();
				__temp_stmt44 = ( (( a3 > b3 )) ? (( ( a3 - b3 ) < 1e-08 )) : (( ( b3 - a3 ) < 1e-08 )) );
			}
			
			if ( ! (__temp_stmt44) ) {
				return false;
			}
			
			return true;
		}
		
		
		public static new object __hx_createEmpty() {
			return new global::at.dotpoint.math.vector.Vector3(global::haxe.lang.EmptyObject.EMPTY);
		}
		
		
		public static new object __hx_create(global::haxe.root.Array arr) {
			unchecked {
				return new global::at.dotpoint.math.vector.Vector3(global::haxe.lang.Null<object>.ofDynamic<double>(arr[0]), global::haxe.lang.Null<object>.ofDynamic<double>(arr[1]), global::haxe.lang.Null<object>.ofDynamic<double>(arr[2]), global::haxe.lang.Null<object>.ofDynamic<double>(arr[3]));
			}
		}
		
		
		public double x;
		
		public double y;
		
		public double z;
		
		public double w;
		
		public virtual global::at.dotpoint.math.vector.Vector3 clone(global::at.dotpoint.math.vector.Vector3 output) {
			if (( output == null )) {
				output = new global::at.dotpoint.math.vector.Vector3(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
			}
			
			output.set_x(this.get_x());
			output.set_y(this.get_y());
			output.set_z(this.get_z());
			output.set_w(this.get_w());
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
		
		
		public virtual double get_z() {
			return this.z;
		}
		
		
		public virtual double set_z(double @value) {
			return this.z = @value;
		}
		
		
		public virtual double get_w() {
			return this.w;
		}
		
		
		public virtual double set_w(double @value) {
			return this.w = @value;
		}
		
		
		public virtual void @set(double x, double y, double z, global::haxe.lang.Null<double> w) {
			this.set_x(x);
			this.set_y(y);
			this.set_z(z);
			if (w.hasValue) {
				this.set_w((w).@value);
			}
			
		}
		
		
		public virtual void normalize() {
			double l = this.length();
			if (( l == 0 )) {
				return;
			}
			
			double k = ( 1.0 / l );
			{
				global::at.dotpoint.math.vector.Vector3 _g = this;
				_g.set_x(( _g.get_x() * k ));
			}
			
			{
				global::at.dotpoint.math.vector.Vector3 _g1 = this;
				_g1.set_y(( _g1.get_y() * k ));
			}
			
			{
				global::at.dotpoint.math.vector.Vector3 _g2 = this;
				_g2.set_z(( _g2.get_z() * k ));
			}
			
		}
		
		
		public virtual double length() {
			{
				double v = ( ( ( this.get_x() * this.get_x() ) + ( this.get_y() * this.get_y() ) ) + ( this.get_z() * this.get_z() ) );
				return global::System.Math.Sqrt(((double) (v) ));
			}
			
		}
		
		
		public virtual double lengthSq() {
			return ( ( ( this.get_x() * this.get_x() ) + ( this.get_y() * this.get_y() ) ) + ( this.get_z() * this.get_z() ) );
		}
		
		
		public virtual global::haxe.root.Array<double> toArray(global::haxe.lang.Null<bool> w, global::haxe.root.Array<double> output) {
			unchecked {
				global::haxe.lang.Null<bool> __temp_w16 = ( ( ! (w.hasValue) ) ? (new global::haxe.lang.Null<bool>(false, true)) : (w) );
				if (( output != null )) {
					output = new global::haxe.root.Array<double>();
				}
				
				output[0] = this.get_x();
				output[1] = this.get_y();
				output[2] = this.get_z();
				if (((__temp_w16)).@value) {
					output[3] = this.get_w();
				}
				
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
					
					
					case 2:
					{
						return this.get_z();
					}
					
					
					case 3:
					{
						return this.get_w();
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
					
					
					case 2:
					{
						this.set_z(@value);
						break;
					}
					
					
					case 3:
					{
						this.set_w(@value);
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
			return global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("[Vector3;", global::haxe.lang.Runtime.toString(this.get_x())), ", "), global::haxe.lang.Runtime.toString(this.get_y())), ", "), global::haxe.lang.Runtime.toString(this.get_z())), ", "), global::haxe.lang.Runtime.toString(this.get_w())), "]");
		}
		
		
		public override double __hx_setField_f(string field, int hash, double @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 119:
					{
						if (handleProperties) {
							this.set_w(@value);
							return @value;
						}
						else {
							this.w = ((double) (@value) );
							return @value;
						}
						
					}
					
					
					case 122:
					{
						if (handleProperties) {
							this.set_z(@value);
							return @value;
						}
						else {
							this.z = ((double) (@value) );
							return @value;
						}
						
					}
					
					
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
					case 119:
					{
						if (handleProperties) {
							this.set_w(((double) (global::haxe.lang.Runtime.toDouble(@value)) ));
							return @value;
						}
						else {
							this.w = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
							return @value;
						}
						
					}
					
					
					case 122:
					{
						if (handleProperties) {
							this.set_z(((double) (global::haxe.lang.Runtime.toDouble(@value)) ));
							return @value;
						}
						else {
							this.z = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
							return @value;
						}
						
					}
					
					
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
					
					
					case 2049940314:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "set_w", 2049940314)) );
					}
					
					
					case 291546446:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get_w", 291546446)) );
					}
					
					
					case 2049940317:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "set_z", 2049940317)) );
					}
					
					
					case 291546449:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get_z", 291546449)) );
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
					
					
					case 119:
					{
						if (handleProperties) {
							return this.get_w();
						}
						else {
							return this.w;
						}
						
					}
					
					
					case 122:
					{
						if (handleProperties) {
							return this.get_z();
						}
						else {
							return this.z;
						}
						
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
					case 119:
					{
						if (handleProperties) {
							return this.get_w();
						}
						else {
							return this.w;
						}
						
					}
					
					
					case 122:
					{
						if (handleProperties) {
							return this.get_z();
						}
						else {
							return this.z;
						}
						
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
						return this.toArray(global::haxe.lang.Null<object>.ofDynamic<bool>(dynargs[0]), ((global::haxe.root.Array<double>) (global::haxe.root.Array<object>.__hx_cast<double>(((global::haxe.root.Array) (dynargs[1]) ))) ));
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
						this.@set(((double) (global::haxe.lang.Runtime.toDouble(dynargs[0])) ), ((double) (global::haxe.lang.Runtime.toDouble(dynargs[1])) ), ((double) (global::haxe.lang.Runtime.toDouble(dynargs[2])) ), global::haxe.lang.Null<object>.ofDynamic<double>(dynargs[3]));
						break;
					}
					
					
					case 2049940314:
					{
						return this.set_w(((double) (global::haxe.lang.Runtime.toDouble(dynargs[0])) ));
					}
					
					
					case 291546446:
					{
						return this.get_w();
					}
					
					
					case 2049940317:
					{
						return this.set_z(((double) (global::haxe.lang.Runtime.toDouble(dynargs[0])) ));
					}
					
					
					case 291546449:
					{
						return this.get_z();
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
						return this.clone(((global::at.dotpoint.math.vector.Vector3) (dynargs[0]) ));
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
			baseArr.push("w");
			baseArr.push("z");
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


