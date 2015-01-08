using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.root {
	public class DFTWaves : global::haxe.lang.HxObject {
		
		public static void Main(){
			global::cs.Boot.init();
			main();
		}
		public DFTWaves(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public DFTWaves() {
			global::haxe.root.DFTWaves.__hx_ctor__DFTWaves(this);
		}
		
		
		public static void __hx_ctor__DFTWaves(global::haxe.root.DFTWaves __temp_me6) {
			unchecked {
				__temp_me6.maxAmplitude = 0.0005;
				__temp_me6.frequency = ((double) (((int) (200) )) );
				__temp_me6.gravity = 9.81;
				__temp_me6.LM = ((double) (((int) (64) )) );
				__temp_me6.LN = ((double) (((int) (64) )) );
				__temp_me6.M = 64;
				__temp_me6.N = 64;
				__temp_me6.tmpVector2_1 = new global::at.dotpoint.math.vector.Vector2(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
				__temp_me6.tmpVector2_2 = new global::at.dotpoint.math.vector.Vector2(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
				__temp_me6.tmpVector2_3 = new global::at.dotpoint.math.vector.Vector2(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
				__temp_me6.tmpVector2_4 = new global::at.dotpoint.math.vector.Vector2(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
			}
		}
		
		
		public static void main() {
			new global::haxe.root.DFTWaves();
		}
		
		
		public static new object __hx_createEmpty() {
			return new global::haxe.root.DFTWaves(global::haxe.lang.EmptyObject.EMPTY);
		}
		
		
		public static new object __hx_create(global::haxe.root.Array arr) {
			return new global::haxe.root.DFTWaves();
		}
		
		
		public global::haxe.root.Array<object> vertices;
		
		public int N;
		
		public int M;
		
		public double LN;
		
		public double LM;
		
		public double gravity;
		
		public double frequency;
		
		public double maxAmplitude;
		
		public int N05;
		
		public int M05;
		
		public double LN1;
		
		public double LM1;
		
		public global::at.dotpoint.math.vector.Vector2 tmpVector2_1;
		
		public global::at.dotpoint.math.vector.Vector2 tmpVector2_2;
		
		public global::at.dotpoint.math.vector.Vector2 tmpVector2_3;
		
		public global::at.dotpoint.math.vector.Vector2 tmpVector2_4;
		
		public virtual void init() {
			unchecked {
				this.N05 = ((int) (( this.N * 0.5 )) );
				this.M05 = ((int) (( this.M * 0.5 )) );
				this.LN1 = ( 1 / this.LN );
				this.LM1 = ( 1 / this.LM );
				this.vertices = new global::haxe.root.Array<object>();
				double NL = ( this.LN / this.N );
				double ML = ( this.LM / this.M );
				global::at.dotpoint.math.vector.Vector2 k_norm = new global::at.dotpoint.math.vector.Vector2(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
				global::at.dotpoint.math.vector.Vector2 k_conj = new global::at.dotpoint.math.vector.Vector2(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
				{
					int _g1 = 0;
					int _g = ( this.N + 1 );
					while (( _g1 < _g )) {
						int n = _g1++;
						this.vertices[n] = new global::haxe.root.Array<object>();
						{
							int _g3 = 0;
							int _g2 = ( this.M + 1 );
							while (( _g3 < _g2 )) {
								int m = _g3++;
								{
									k_norm.set_x(( ( 6.28318530718 * (( n - this.N05 )) ) * this.LN1 ));
									k_norm.set_y(( ( 6.28318530718 * (( m - this.M05 )) ) * this.LM1 ));
									k_norm = k_norm;
								}
								
								{
									k_conj.set_x(( ( 6.28318530718 * ((  - (n)  - this.N05 )) ) * this.LN1 ));
									k_conj.set_y(( ( 6.28318530718 * ((  - (m)  - this.M05 )) ) * this.LM1 ));
									k_conj = k_conj;
								}
								
								global::haxe.root.Vertex vertex = new global::haxe.root.Vertex();
								vertex.position.set_x(( (( n - this.N05 )) * NL ));
								vertex.position.set_y(( (( m - this.M05 )) * ML ));
								this.h0(n, m, k_norm, vertex.c_h0_norm);
								this.h0(n, m, k_conj, vertex.c_h0_conj);
								{
									global::at.dotpoint.math.vector.Vector2 _g4 = vertex.c_h0_conj;
									_g4.set_y(( _g4.get_y() * -1 ));
								}
								
								((global::haxe.root.Array<object>) (global::haxe.root.Array<object>.__hx_cast<object>(((global::haxe.root.Array) (this.vertices[n]) ))) )[m] = vertex;
							}
							
						}
						
					}
					
				}
				
			}
		}
		
		
		public virtual global::at.dotpoint.math.vector.Vector2 h0(int n, int m, global::at.dotpoint.math.vector.Vector2 k, global::at.dotpoint.math.vector.Vector2 output) {
			unchecked {
				double scale = default(double);
				{
					double v = ( this.phillips(n, m, k) / 2.0 );
					scale = global::System.Math.Sqrt(((double) (v) ));
				}
				
				global::at.dotpoint.math.vector.Vector2 c_r = this.gaussianRandom(output);
				{
					global::at.dotpoint.math.vector.Vector2 _g = c_r;
					_g.set_x(( _g.get_x() * scale ));
				}
				
				{
					global::at.dotpoint.math.vector.Vector2 _g1 = c_r;
					_g1.set_y(( _g1.get_y() * scale ));
				}
				
				bool __temp_stmt31 = default(bool);
				{
					double f = c_r.get_x();
					__temp_stmt31 = global::System.Double.IsNaN(((double) (f) ));
				}
				
				bool __temp_boolv32 = false;
				if ( ! (__temp_stmt31) ) {
					{
						double f1 = c_r.get_y();
						__temp_boolv32 = global::System.Double.IsNaN(((double) (f1) ));
					}
					
				}
				
				bool __temp_stmt30 = ( __temp_stmt31 || __temp_boolv32 );
				if (__temp_stmt30) {
					global::haxe.Log.trace.__hx_invoke2_o(default(double), c_r, default(double), new global::haxe.lang.DynamicObject(new global::haxe.root.Array<int>(new int[]{302979532, 1547539107, 1648581351, 1830310359}), new global::haxe.root.Array<object>(new object[]{"h0", "DFTWaves", "DFTWaves.hx", new global::haxe.root.Array<object>(new object[]{scale})}), new global::haxe.root.Array<int>(new int[]{1981972957}), new global::haxe.root.Array<double>(new double[]{((double) (156) )})));
				}
				
				return c_r;
			}
		}
		
		
		public virtual double phillips(int n, int m, global::at.dotpoint.math.vector.Vector2 k) {
			double k_length0 = k.length();
			if (( k_length0 < 0.000001 )) {
				return 0.0;
			}
			
			global::at.dotpoint.math.vector.Vector2 w = this.getWind(n, m);
			global::at.dotpoint.math.vector.Vector2 k_unit = k.clone(null);
			k_unit.normalize();
			global::at.dotpoint.math.vector.Vector2 w_unit = w.clone(null);
			w_unit.normalize();
			double w_length0 = w.length();
			double w_length2 = ( w_length0 * w_length0 );
			double k_length2 = ( k_length0 * k_length0 );
			double k_length4 = ( k_length2 * k_length2 );
			double kw_dot0 = ( ( k_unit.get_x() * w_unit.get_x() ) + ( k_unit.get_y() * w_unit.get_y() ) );
			double kw_dot2 = ( kw_dot0 * kw_dot0 );
			double L0 = ( w_length2 / this.gravity );
			double L2 = ( L0 * L0 );
			double l2 = ( ( L2 * 0.001 ) * 0.001 );
			return ( ( ( this.maxAmplitude * (( global::System.Math.Exp(((double) (( -1.0 / (( k_length2 * L2 )) )) )) / k_length4 )) ) * kw_dot2 ) * global::System.Math.Exp(((double) ((  - (k_length2)  * l2 )) )) );
		}
		
		
		public virtual global::haxe.root.WaveOutput calculate(global::at.dotpoint.math.vector.Vector2 c, double t, global::haxe.root.WaveOutput output) {
			global::at.dotpoint.math.vector.Vector2 k = this.tmpVector2_1;
			global::at.dotpoint.math.vector.Vector2 x = this.tmpVector2_2;
			global::at.dotpoint.math.vector.Vector2 h = output.height;
			global::at.dotpoint.math.vector.Vector2 d = output.displacement;
			global::at.dotpoint.math.vector.Vector2 n = output.normal;
			int __temp_stmt34 = default(int);
			{
				double x1 = c.get_x();
				__temp_stmt34 = ((int) (x1) );
			}
			
			object __temp_stmt33 = global::haxe.root.Array<object>.__hx_cast<object>(((global::haxe.root.Array) (this.vertices[__temp_stmt34]) ));
			int __temp_stmt35 = default(int);
			{
				double x2 = c.get_y();
				__temp_stmt35 = ((int) (x2) );
			}
			
			x.set_x(((global::haxe.root.Vertex) (((global::haxe.root.Array<object>) (__temp_stmt33) )[__temp_stmt35]) ).position.get_x());
			int __temp_stmt37 = default(int);
			{
				double x3 = c.get_x();
				__temp_stmt37 = ((int) (x3) );
			}
			
			object __temp_stmt36 = global::haxe.root.Array<object>.__hx_cast<object>(((global::haxe.root.Array) (this.vertices[__temp_stmt37]) ));
			int __temp_stmt38 = default(int);
			{
				double x4 = c.get_y();
				__temp_stmt38 = ((int) (x4) );
			}
			
			x.set_y(((global::haxe.root.Vertex) (((global::haxe.root.Array<object>) (__temp_stmt36) )[__temp_stmt38]) ).position.get_y());
			h.@set(((double) (0) ), ((double) (0) ));
			{
				int _g1 = 0;
				int _g = this.N;
				while (( _g1 < _g )) {
					int n1 = _g1++;
					{
						int _g3 = 0;
						int _g2 = this.M;
						while (( _g3 < _g2 )) {
							int m = _g3++;
							{
								k.set_x(( ( 6.28318530718 * (( n1 - this.N05 )) ) * this.LN1 ));
								k.set_y(( ( 6.28318530718 * (( m - this.M05 )) ) * this.LM1 ));
								k = k;
							}
							
							double dot_kx = ( ( k.get_x() * x.get_x() ) + ( k.get_y() * x.get_y() ) );
							double c_cos = global::System.Math.Cos(((double) (dot_kx) ));
							double c_sin = global::System.Math.Sin(((double) (dot_kx) ));
							global::at.dotpoint.math.vector.Vector2 c_ht = this.ht(n1, m, k, t);
							{
								global::at.dotpoint.math.vector.Vector2 _g4 = h;
								_g4.set_x(( _g4.get_x() + (( ( c_ht.get_x() * c_cos ) - ( c_ht.get_y() * c_sin ) )) ));
							}
							
							{
								global::at.dotpoint.math.vector.Vector2 _g41 = h;
								_g41.set_y(( _g41.get_y() + (( ( c_ht.get_x() * c_sin ) + ( c_ht.get_y() * c_cos ) )) ));
							}
							
						}
						
					}
					
				}
				
			}
			
			return output;
		}
		
		
		public virtual global::at.dotpoint.math.vector.Vector2 ht(int n, int m, global::at.dotpoint.math.vector.Vector2 k, double t) {
			global::at.dotpoint.math.vector.Vector2 c_h = this.tmpVector2_3;
			global::at.dotpoint.math.vector.Vector2 h01 = ((global::haxe.root.Vertex) (((global::haxe.root.Array<object>) (global::haxe.root.Array<object>.__hx_cast<object>(((global::haxe.root.Array) (this.vertices[n]) ))) )[m]) ).c_h0_norm;
			global::at.dotpoint.math.vector.Vector2 h02 = ((global::haxe.root.Vertex) (((global::haxe.root.Array<object>) (global::haxe.root.Array<object>.__hx_cast<object>(((global::haxe.root.Array) (this.vertices[n]) ))) )[m]) ).c_h0_conj;
			double w = ( this.dispertion(k) * t );
			double cos = global::System.Math.Cos(((double) (w) ));
			double sin = global::System.Math.Sin(((double) (w) ));
			double mcos = global::System.Math.Cos(((double) ( - (w) ) ));
			double msin = global::System.Math.Sin(((double) ( - (w) ) ));
			c_h.set_x(( ( ( h01.get_x() * cos ) - ( h01.get_y() * sin ) ) + (( ( h02.get_x() * mcos ) - ( h02.get_y() * msin ) )) ));
			c_h.set_y(( ( ( h01.get_x() * sin ) + ( h01.get_y() * cos ) ) + (( ( h02.get_x() * msin ) + ( h02.get_y() * mcos ) )) ));
			return c_h;
		}
		
		
		public virtual double dispertion(global::at.dotpoint.math.vector.Vector2 k) {
			double w0 = ( 6.28318530718 / this.frequency );
			double wk = default(double);
			{
				double v = default(double);
				double __temp_stmt39 = default(double);
				{
					double v1 = ( ( k.get_x() * k.get_x() ) + ( k.get_y() * k.get_y() ) );
					__temp_stmt39 = global::System.Math.Sqrt(((double) (v1) ));
				}
				
				v = ( this.gravity * __temp_stmt39 );
				wk = global::System.Math.Sqrt(((double) (v) ));
			}
			
			return ( ((int) (( wk / w0 )) ) * w0 );
		}
		
		
		public global::at.dotpoint.math.vector.Vector2 getK(int n, int m, global::at.dotpoint.math.vector.Vector2 k) {
			k.set_x(( ( 6.28318530718 * (( n - this.N05 )) ) * this.LN1 ));
			k.set_y(( ( 6.28318530718 * (( m - this.M05 )) ) * this.LM1 ));
			return k;
		}
		
		
		public virtual global::at.dotpoint.math.vector.Vector2 gaussianRandom(global::at.dotpoint.math.vector.Vector2 r) {
			double w = ((double) (0) );
			do {
				r.set_x(( ( 2.0 * global::haxe.root.Math.rand.NextDouble() ) - 1.0 ));
				r.set_y(( ( 2.0 * global::haxe.root.Math.rand.NextDouble() ) - 1.0 ));
				w = ( ( r.get_x() * r.get_x() ) + ( r.get_y() * r.get_y() ) );
			}
			while (( w >= 1.0 ));
			{
				double v = ( ( -2.0 * global::System.Math.Log(((double) (w) )) ) / w );
				w = global::System.Math.Sqrt(((double) (v) ));
			}
			
			{
				global::at.dotpoint.math.vector.Vector2 _g = r;
				_g.set_x(( _g.get_x() * w ));
			}
			
			{
				global::at.dotpoint.math.vector.Vector2 _g1 = r;
				_g1.set_y(( _g1.get_y() * w ));
			}
			
			return r;
		}
		
		
		public virtual global::at.dotpoint.math.vector.Vector2 getWind(int n, int m) {
			this.tmpVector2_4.set_x(32.0);
			this.tmpVector2_4.set_y(0.0);
			return this.tmpVector2_4;
		}
		
		
		public override double __hx_setField_f(string field, int hash, double @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 3796624:
					{
						this.LM1 = ((double) (@value) );
						return @value;
					}
					
					
					case 3796847:
					{
						this.LN1 = ((double) (@value) );
						return @value;
					}
					
					
					case 3839890:
					{
						this.M05 = ((int) (@value) );
						return @value;
					}
					
					
					case 3889619:
					{
						this.N05 = ((int) (@value) );
						return @value;
					}
					
					
					case 25064959:
					{
						this.maxAmplitude = ((double) (@value) );
						return @value;
					}
					
					
					case 1005224604:
					{
						this.frequency = ((double) (@value) );
						return @value;
					}
					
					
					case 2013228622:
					{
						this.gravity = ((double) (@value) );
						return @value;
					}
					
					
					case 17025:
					{
						this.LM = ((double) (@value) );
						return @value;
					}
					
					
					case 17026:
					{
						this.LN = ((double) (@value) );
						return @value;
					}
					
					
					case 77:
					{
						this.M = ((int) (@value) );
						return @value;
					}
					
					
					case 78:
					{
						this.N = ((int) (@value) );
						return @value;
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
					case 1664341741:
					{
						this.tmpVector2_4 = ((global::at.dotpoint.math.vector.Vector2) (@value) );
						return @value;
					}
					
					
					case 1664341740:
					{
						this.tmpVector2_3 = ((global::at.dotpoint.math.vector.Vector2) (@value) );
						return @value;
					}
					
					
					case 1664341739:
					{
						this.tmpVector2_2 = ((global::at.dotpoint.math.vector.Vector2) (@value) );
						return @value;
					}
					
					
					case 1664341738:
					{
						this.tmpVector2_1 = ((global::at.dotpoint.math.vector.Vector2) (@value) );
						return @value;
					}
					
					
					case 3796624:
					{
						this.LM1 = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
						return @value;
					}
					
					
					case 3796847:
					{
						this.LN1 = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
						return @value;
					}
					
					
					case 3839890:
					{
						this.M05 = ((int) (global::haxe.lang.Runtime.toInt(@value)) );
						return @value;
					}
					
					
					case 3889619:
					{
						this.N05 = ((int) (global::haxe.lang.Runtime.toInt(@value)) );
						return @value;
					}
					
					
					case 25064959:
					{
						this.maxAmplitude = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
						return @value;
					}
					
					
					case 1005224604:
					{
						this.frequency = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
						return @value;
					}
					
					
					case 2013228622:
					{
						this.gravity = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
						return @value;
					}
					
					
					case 17025:
					{
						this.LM = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
						return @value;
					}
					
					
					case 17026:
					{
						this.LN = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
						return @value;
					}
					
					
					case 77:
					{
						this.M = ((int) (global::haxe.lang.Runtime.toInt(@value)) );
						return @value;
					}
					
					
					case 78:
					{
						this.N = ((int) (global::haxe.lang.Runtime.toInt(@value)) );
						return @value;
					}
					
					
					case 1779810297:
					{
						this.vertices = ((global::haxe.root.Array<object>) (global::haxe.root.Array<object>.__hx_cast<object>(((global::haxe.root.Array) (@value) ))) );
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
					case 561717374:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "getWind", 561717374)) );
					}
					
					
					case 251995742:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "gaussianRandom", 251995742)) );
					}
					
					
					case 1147273973:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "getK", 1147273973)) );
					}
					
					
					case 1474198947:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "dispertion", 1474198947)) );
					}
					
					
					case 23308:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "ht", 23308)) );
					}
					
					
					case 90871142:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "calculate", 90871142)) );
					}
					
					
					case 1564266267:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "phillips", 1564266267)) );
					}
					
					
					case 23240:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "h0", 23240)) );
					}
					
					
					case 1169898256:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "init", 1169898256)) );
					}
					
					
					case 1664341741:
					{
						return this.tmpVector2_4;
					}
					
					
					case 1664341740:
					{
						return this.tmpVector2_3;
					}
					
					
					case 1664341739:
					{
						return this.tmpVector2_2;
					}
					
					
					case 1664341738:
					{
						return this.tmpVector2_1;
					}
					
					
					case 3796624:
					{
						return this.LM1;
					}
					
					
					case 3796847:
					{
						return this.LN1;
					}
					
					
					case 3839890:
					{
						return this.M05;
					}
					
					
					case 3889619:
					{
						return this.N05;
					}
					
					
					case 25064959:
					{
						return this.maxAmplitude;
					}
					
					
					case 1005224604:
					{
						return this.frequency;
					}
					
					
					case 2013228622:
					{
						return this.gravity;
					}
					
					
					case 17025:
					{
						return this.LM;
					}
					
					
					case 17026:
					{
						return this.LN;
					}
					
					
					case 77:
					{
						return this.M;
					}
					
					
					case 78:
					{
						return this.N;
					}
					
					
					case 1779810297:
					{
						return this.vertices;
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
					case 3796624:
					{
						return this.LM1;
					}
					
					
					case 3796847:
					{
						return this.LN1;
					}
					
					
					case 3839890:
					{
						return ((double) (this.M05) );
					}
					
					
					case 3889619:
					{
						return ((double) (this.N05) );
					}
					
					
					case 25064959:
					{
						return this.maxAmplitude;
					}
					
					
					case 1005224604:
					{
						return this.frequency;
					}
					
					
					case 2013228622:
					{
						return this.gravity;
					}
					
					
					case 17025:
					{
						return this.LM;
					}
					
					
					case 17026:
					{
						return this.LN;
					}
					
					
					case 77:
					{
						return ((double) (this.M) );
					}
					
					
					case 78:
					{
						return ((double) (this.N) );
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
					case 561717374:
					{
						return this.getWind(((int) (global::haxe.lang.Runtime.toInt(dynargs[0])) ), ((int) (global::haxe.lang.Runtime.toInt(dynargs[1])) ));
					}
					
					
					case 251995742:
					{
						return this.gaussianRandom(((global::at.dotpoint.math.vector.Vector2) (dynargs[0]) ));
					}
					
					
					case 1147273973:
					{
						return this.getK(((int) (global::haxe.lang.Runtime.toInt(dynargs[0])) ), ((int) (global::haxe.lang.Runtime.toInt(dynargs[1])) ), ((global::at.dotpoint.math.vector.Vector2) (dynargs[2]) ));
					}
					
					
					case 1474198947:
					{
						return this.dispertion(((global::at.dotpoint.math.vector.Vector2) (dynargs[0]) ));
					}
					
					
					case 23308:
					{
						return this.ht(((int) (global::haxe.lang.Runtime.toInt(dynargs[0])) ), ((int) (global::haxe.lang.Runtime.toInt(dynargs[1])) ), ((global::at.dotpoint.math.vector.Vector2) (dynargs[2]) ), ((double) (global::haxe.lang.Runtime.toDouble(dynargs[3])) ));
					}
					
					
					case 90871142:
					{
						return this.calculate(((global::at.dotpoint.math.vector.Vector2) (dynargs[0]) ), ((double) (global::haxe.lang.Runtime.toDouble(dynargs[1])) ), ((global::haxe.root.WaveOutput) (dynargs[2]) ));
					}
					
					
					case 1564266267:
					{
						return this.phillips(((int) (global::haxe.lang.Runtime.toInt(dynargs[0])) ), ((int) (global::haxe.lang.Runtime.toInt(dynargs[1])) ), ((global::at.dotpoint.math.vector.Vector2) (dynargs[2]) ));
					}
					
					
					case 23240:
					{
						return this.h0(((int) (global::haxe.lang.Runtime.toInt(dynargs[0])) ), ((int) (global::haxe.lang.Runtime.toInt(dynargs[1])) ), ((global::at.dotpoint.math.vector.Vector2) (dynargs[2]) ), ((global::at.dotpoint.math.vector.Vector2) (dynargs[3]) ));
					}
					
					
					case 1169898256:
					{
						this.init();
						break;
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
			baseArr.push("tmpVector2_4");
			baseArr.push("tmpVector2_3");
			baseArr.push("tmpVector2_2");
			baseArr.push("tmpVector2_1");
			baseArr.push("LM1");
			baseArr.push("LN1");
			baseArr.push("M05");
			baseArr.push("N05");
			baseArr.push("maxAmplitude");
			baseArr.push("frequency");
			baseArr.push("gravity");
			baseArr.push("LM");
			baseArr.push("LN");
			baseArr.push("M");
			baseArr.push("N");
			baseArr.push("vertices");
			{
				base.__hx_getFields(baseArr);
			}
			
		}
		
		
	}
}


