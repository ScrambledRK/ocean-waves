using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.lang {
	public class Runtime {
		
		
	public static object getField(haxe.lang.HxObject obj, string field, int fieldHash, bool throwErrors)
	{
		if (obj == null && !throwErrors) return null;
		return obj.__hx_getField(field, (fieldHash == 0) ? haxe.lang.FieldLookup.hash(field) : fieldHash, throwErrors, false, false);
	}

	public static double getField_f(haxe.lang.HxObject obj, string field, int fieldHash, bool throwErrors)
	{
		if (obj == null && !throwErrors) return 0.0;
		return obj.__hx_getField_f(field, (fieldHash == 0) ? haxe.lang.FieldLookup.hash(field) : fieldHash, throwErrors, false);
	}

	public static object setField(haxe.lang.HxObject obj, string field, int fieldHash, object value)
	{
		return obj.__hx_setField(field, (fieldHash == 0) ? haxe.lang.FieldLookup.hash(field) : fieldHash, value, false);
	}

	public static double setField_f(haxe.lang.HxObject obj, string field, int fieldHash, double value)
	{
		return obj.__hx_setField_f(field, (fieldHash == 0) ? haxe.lang.FieldLookup.hash(field) : fieldHash, value, false);
	}

	public static object callField(haxe.lang.HxObject obj, string field, int fieldHash, Array args)
	{
		return obj.__hx_invokeField(field, (fieldHash == 0) ? haxe.lang.FieldLookup.hash(field) : fieldHash, args);
	}
		static Runtime() {
			global::haxe.lang.Runtime.undefined = ((object) (new global::haxe.lang.DynamicObject(new global::haxe.root.Array<int>(new int[]{}), new global::haxe.root.Array<object>(new object[]{}), new global::haxe.root.Array<int>(new int[]{}), new global::haxe.root.Array<double>(new double[]{}))) );
		}
		
		
		public Runtime() {
		}
		
		
		public static object undefined;
		
		public static object closure(object obj, int hash, string field) {
			
		return new haxe.lang.Closure(obj, field, hash);
	
		}
		
		
		public static bool eq(object v1, object v2) {
			if (global::System.Object.ReferenceEquals(((object) (v1) ), ((object) (v2) ))) {
				return true;
			}
			
			if (( global::System.Object.ReferenceEquals(((object) (v1) ), ((object) (null) )) || global::System.Object.ReferenceEquals(((object) (v2) ), ((object) (null) )) )) {
				return false;
			}
			
			global::System.IConvertible v1c = ( v1 as global::System.IConvertible );
			if (( v1c != null )) {
				global::System.IConvertible v2c = ( v2 as global::System.IConvertible );
				if (( v2c == null )) {
					return false;
				}
				
				global::System.TypeCode t1 = v1c.GetTypeCode();
				global::System.TypeCode t2 = v2c.GetTypeCode();
				if (( t1 == t2 )) {
					return global::System.Object.Equals(((object) (v1c) ), ((object) (v2c) ));
				}
				
				if (( ( t1 == global::System.TypeCode.String ) || ( t2 == global::System.TypeCode.String ) )) {
					return false;
				}
				
				switch (t1) {
					case global::System.TypeCode.Decimal:
					{
						return v1c.ToDecimal(((global::System.IFormatProvider) (null) )).Equals(v2c.ToDecimal(((global::System.IFormatProvider) (null) )));
					}
					
					
					case global::System.TypeCode.UInt64:
					case global::System.TypeCode.Int64:
					{
						if (( t2 == global::System.TypeCode.Decimal )) {
							return v1c.ToDecimal(((global::System.IFormatProvider) (null) )).Equals(v2c.ToDecimal(((global::System.IFormatProvider) (null) )));
						}
						else {
							return ( v1c.ToUInt64(((global::System.IFormatProvider) (null) )) == v2c.ToUInt64(((global::System.IFormatProvider) (null) )) );
						}
						
					}
					
					
					default:
					{
						switch (t2) {
							case global::System.TypeCode.Decimal:
							{
								return v1c.ToDecimal(((global::System.IFormatProvider) (null) )).Equals(v2c.ToDecimal(((global::System.IFormatProvider) (null) )));
							}
							
							
							case global::System.TypeCode.UInt64:
							case global::System.TypeCode.Int64:
							{
								if (( t2 == global::System.TypeCode.Decimal )) {
									return v1c.ToDecimal(((global::System.IFormatProvider) (null) )).Equals(v2c.ToDecimal(((global::System.IFormatProvider) (null) )));
								}
								else {
									return ( v1c.ToUInt64(((global::System.IFormatProvider) (null) )) == v2c.ToUInt64(((global::System.IFormatProvider) (null) )) );
								}
								
							}
							
							
							default:
							{
								return ( v1c.ToDouble(((global::System.IFormatProvider) (null) )) == v2c.ToDouble(((global::System.IFormatProvider) (null) )) );
							}
							
						}
						
					}
					
				}
				
			}
			
			global::System.ValueType v1v = ( v1 as global::System.ValueType );
			if (( v1v != null )) {
				return v1.Equals(v2);
			}
			else {
				global::System.Type v1t = ( v1 as global::System.Type );
				if (( v1t != null )) {
					global::System.Type v2t = ( v2 as global::System.Type );
					if (( v2t != null )) {
						return global::haxe.lang.Runtime.typeEq(v1t, v2t);
					}
					
					return false;
				}
				
			}
			
			return false;
		}
		
		
		public static bool refEq(object v1, object v2) {
			if (( v1 is global::System.Type )) {
				return global::haxe.lang.Runtime.typeEq(( v1 as global::System.Type ), ( v2 as global::System.Type ));
			}
			
			return global::System.Object.ReferenceEquals(((object) (v1) ), ((object) (v2) ));
		}
		
		
		public static double toDouble(object obj) {
			if (global::haxe.lang.Runtime.eq(obj, null)) {
				return .0;
			}
			else if (( obj is double )) {
				return ((double) (obj) );
			}
			else {
				return ( obj as global::System.IConvertible ).ToDouble(((global::System.IFormatProvider) (null) ));
			}
			
		}
		
		
		public static int toInt(object obj) {
			if (global::haxe.lang.Runtime.eq(obj, null)) {
				return 0;
			}
			else if (( obj is int )) {
				return ((int) (obj) );
			}
			else {
				return ( obj as global::System.IConvertible ).ToInt32(((global::System.IFormatProvider) (null) ));
			}
			
		}
		
		
		public static bool isInt(object obj) {
			global::System.IConvertible cv1 = ( obj as global::System.IConvertible );
			if (( cv1 != null )) {
				global::System.TypeCode _g = cv1.GetTypeCode();
				switch (_g) {
					case global::System.TypeCode.Double:
					{
						double d = ((double) (obj) );
						return ( ( ( d >= global::System.Int32.MinValue ) && ( d <= global::System.Int32.MaxValue ) ) && ( d == ((int) (d) ) ) );
					}
					
					
					case global::System.TypeCode.UInt32:
					case global::System.TypeCode.Int32:
					{
						return true;
					}
					
					
					default:
					{
						return false;
					}
					
				}
				
			}
			
			return false;
		}
		
		
		public static bool isUInt(object obj) {
			global::System.IConvertible cv1 = ( obj as global::System.IConvertible );
			if (( cv1 != null )) {
				global::System.TypeCode _g = cv1.GetTypeCode();
				switch (_g) {
					case global::System.TypeCode.Double:
					{
						double d = ((double) (obj) );
						return ( ( ( d >= global::System.UInt32.MinValue ) && ( d <= global::System.UInt32.MaxValue ) ) && ( d == ((uint) (d) ) ) );
					}
					
					
					case global::System.TypeCode.UInt32:
					{
						return true;
					}
					
					
					default:
					{
						return false;
					}
					
				}
				
			}
			
			return false;
		}
		
		
		public static int compare(object v1, object v2) {
			unchecked {
				if (global::System.Object.ReferenceEquals(((object) (v1) ), ((object) (v2) ))) {
					return 0;
				}
				
				if (global::System.Object.ReferenceEquals(((object) (v1) ), ((object) (null) ))) {
					return -1;
				}
				
				if (global::System.Object.ReferenceEquals(((object) (v2) ), ((object) (null) ))) {
					return 1;
				}
				
				global::System.IConvertible cv1 = ( v1 as global::System.IConvertible );
				if (( cv1 != null )) {
					global::System.IConvertible cv2 = ( v2 as global::System.IConvertible );
					if (( cv2 == null )) {
						throw new global::System.ArgumentException(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("Cannot compare ", ( global::cs.Lib.nativeType(v1) as global::System.Reflection.MemberInfo ).ToString()), " and "), ( global::cs.Lib.nativeType(v2) as global::System.Reflection.MemberInfo ).ToString()));
					}
					
					{
						global::System.TypeCode _g = cv1.GetTypeCode();
						switch (_g) {
							case global::System.TypeCode.String:
							{
								if (( cv2.GetTypeCode() != global::System.TypeCode.String )) {
									throw new global::System.ArgumentException(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("Cannot compare ", ( global::cs.Lib.nativeType(v1) as global::System.Reflection.MemberInfo ).ToString()), " and "), ( global::cs.Lib.nativeType(v2) as global::System.Reflection.MemberInfo ).ToString()));
								}
								
								string s1 = ( v1 as string );
								string s2 = ( v2 as string );
								return string.Compare(((string) (s1) ), ((string) (s2) ), ((global::System.StringComparison) (global::System.StringComparison.Ordinal) ));
							}
							
							
							case global::System.TypeCode.Double:
							{
								double d1 = ((double) (v1) );
								double d2 = cv2.ToDouble(((global::System.IFormatProvider) (null) ));
								if (( d1 < d2 )) {
									return -1;
								}
								else if (( d1 > d2 )) {
									return 1;
								}
								else {
									return 0;
								}
								
							}
							
							
							default:
							{
								double d1d = cv1.ToDouble(((global::System.IFormatProvider) (null) ));
								double d2d = cv2.ToDouble(((global::System.IFormatProvider) (null) ));
								if (( d1d < d2d )) {
									return -1;
								}
								else if (( d1d > d2d )) {
									return 1;
								}
								else {
									return 0;
								}
								
							}
							
						}
						
					}
					
				}
				
				global::System.IComparable c1 = ( v1 as global::System.IComparable );
				global::System.IComparable c2 = ( v2 as global::System.IComparable );
				if (( ( c1 == null ) || ( c2 == null ) )) {
					throw new global::System.ArgumentException(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("Cannot compare ", ( global::cs.Lib.nativeType(v1) as global::System.Reflection.MemberInfo ).ToString()), " and "), ( global::cs.Lib.nativeType(v2) as global::System.Reflection.MemberInfo ).ToString()));
				}
				
				return c1.CompareTo(((object) (c2) ));
			}
		}
		
		
		public static object plus(object v1, object v2) {
			if (( ( v1 is string ) || ( v2 is string ) )) {
				return global::haxe.lang.Runtime.concat(global::haxe.root.Std.@string(v1), global::haxe.root.Std.@string(v2));
			}
			
			global::System.IConvertible cv1 = ( v1 as global::System.IConvertible );
			if (( cv1 != null )) {
				global::System.IConvertible cv2 = ( v2 as global::System.IConvertible );
				if (( cv2 == null )) {
					throw new global::System.ArgumentException(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("Cannot dynamically add ", ( global::cs.Lib.nativeType(v1) as global::System.Reflection.MemberInfo ).ToString()), " and "), ( global::cs.Lib.nativeType(v2) as global::System.Reflection.MemberInfo ).ToString()));
				}
				
				return ( cv1.ToDouble(((global::System.IFormatProvider) (null) )) + cv2.ToDouble(((global::System.IFormatProvider) (null) )) );
			}
			
			throw new global::System.ArgumentException(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("Cannot dynamically add ", global::haxe.root.Std.@string(v1)), " and "), global::haxe.root.Std.@string(v2)));
		}
		
		
		public static object slowGetField(object obj, string field, bool throwErrors) {
			

		if (obj == null)
			if (throwErrors)
				throw new System.NullReferenceException("Cannot access field '" + field + "' of null.");
			else
				return null;

		System.Type t = obj as System.Type;
		System.Reflection.BindingFlags bf;
        if (t == null)
		{
			string s = obj as string;
			if (s != null)
				return haxe.lang.StringRefl.handleGetField(s, field, throwErrors);
			t = obj.GetType();
			bf = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.FlattenHierarchy;
		} else {
			if (t == typeof(string) && field.Equals("fromCharCode"))
				return new haxe.lang.Closure(typeof(haxe.lang.StringExt), field, 0);

			obj = null;
			bf = System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public;
		}

		System.Reflection.FieldInfo f = t.GetField(field, bf);
		if (f != null)
		{
			return haxe.lang.Runtime.unbox(f.GetValue(obj));
		} else {
			System.Reflection.PropertyInfo prop = t.GetProperty(field, bf);
			if (prop == null)
			{
				System.Reflection.MemberInfo[] m = t.GetMember(field, bf);
				if (m.Length > 0)
				{
					return new haxe.lang.Closure(obj != null ? obj : t, field, 0);
				} else {
					if (throwErrors)
						throw HaxeException.wrap("Cannot access field '" + field + "'.");
					else
						return null;
				}
			}
			return haxe.lang.Runtime.unbox(prop.GetValue(obj, null));
		}

	
		}
		
		
		public static bool slowHasField(object obj, string field) {
			
		if (obj == null) return false;
		System.Type t = obj as System.Type;
		System.Reflection.BindingFlags bf;
        if (t == null)
		{
			string s = obj as string;
			if (s != null)
				return haxe.lang.StringRefl.handleGetField(s, field, false) != null;
			t = obj.GetType();
			bf = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.FlattenHierarchy;
		} else {
			if (t == typeof(string))
				return field.Equals("fromCharCode");
			obj = null;
			bf = System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public;
		}

		System.Reflection.MemberInfo[] mi = t.GetMember(field, bf);
		return mi != null && mi.Length > 0;
	
		}
		
		
		public static object slowSetField(object obj, string field, object @value) {
			
		if (obj == null)
			throw new System.NullReferenceException("Cannot access field '" + field + "' of null.");

		System.Type t = obj as System.Type;
		System.Reflection.BindingFlags bf;
        if (t == null)
		{
			t = obj.GetType();
			bf = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.FlattenHierarchy;
		} else {
			obj = null;
			bf = System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public;
		}

		System.Reflection.FieldInfo f = t.GetField(field, bf);
		if (f != null)
		{
			if (f.FieldType.ToString().StartsWith("haxe.lang.Null"))
			{
				@value = haxe.lang.Runtime.mkNullable(@value, f.FieldType);
			}

			f.SetValue(obj, @value);
			return @value;
		} else {
			System.Reflection.PropertyInfo prop = t.GetProperty(field, bf);
			if (prop == null)
			{
				throw haxe.lang.HaxeException.wrap("Field '" + field + "' not found for writing from Class " + t);
			}

			if (prop.PropertyType.ToString().StartsWith("haxe.lang.Null"))
			{
				@value = haxe.lang.Runtime.mkNullable(@value, prop.PropertyType);
			}
			prop.SetValue(obj, @value, null);

			return @value;
		}

	
		}
		
		
		public static object callMethod(object obj, global::System.Reflection.MethodBase[] methods, int methodLength, global::haxe.root.Array args) {
			unchecked {
				if (( methodLength == 0 )) {
					throw global::haxe.lang.HaxeException.wrap("No available methods");
				}
				
				int length = ((int) (global::haxe.lang.Runtime.getField_f(args, "length", 520590566, true)) );
				object[] oargs = new object[length];
				global::System.Type[] ts = new global::System.Type[length];
				int[] rates = new int[( methods as global::System.Array ).Length];
				{
					int _g = 0;
					while (( _g < length )) {
						int i = _g++;
						oargs[i] = args[i];
						if (( ! (global::haxe.lang.Runtime.eq(args[i], null)) )) {
							ts[i] = global::cs.Lib.nativeType(args[i]);
						}
						
					}
					
				}
				
				int last = 0;
				if (( methodLength > 1 )) {
					{
						int _g1 = 0;
						while (( _g1 < methodLength )) {
							int i1 = _g1++;
							global::System.Reflection.ParameterInfo[] @params = methods[i1].GetParameters();
							if (( ( @params as global::System.Array ).Length != length )) {
								continue;
							}
							else {
								bool fits = true;
								int crate = 0;
								{
									int _g2 = 0;
									int _g11 = ( @params as global::System.Array ).Length;
									while (( _g2 < _g11 )) {
										int i2 = _g2++;
										global::System.Type param = @params[i2].ParameterType;
										string strParam = global::haxe.lang.Runtime.concat(global::haxe.root.Std.@string(param), "");
										if (( param.IsAssignableFrom(((global::System.Type) (ts[i2]) )) || ( ( ts[i2] == null ) &&  ! (param.IsValueType)  ) )) {
											continue;
										}
										else if (( strParam.StartsWith("haxe.lang.Null") || ( (( global::haxe.lang.Runtime.eq(oargs[i2], null) || ( oargs[i2] is global::System.IConvertible ) )) && (((global::System.Type) (typeof(global::System.IConvertible)) )).IsAssignableFrom(((global::System.Type) (param) )) ) )) {
											crate++;
											continue;
										}
										else if ( ! (param.ContainsGenericParameters) ) {
											fits = false;
											break;
										}
										
									}
									
								}
								
								if (fits) {
									rates[last] = crate;
									methods[last++] = methods[i1];
								}
								
							}
							
						}
						
					}
					
					methodLength = last;
				}
				else if (( ( methodLength == 1 ) && ( ( methods[0].GetParameters() as global::System.Array ).Length != length ) )) {
					methodLength = 0;
				}
				
				if (( methodLength == 0 )) {
					throw global::haxe.lang.HaxeException.wrap(global::haxe.lang.Runtime.concat("Invalid calling parameters for method ", ( methods[0] as global::System.Reflection.MemberInfo ).Name));
				}
				
				double best = global::haxe.root.Math.POSITIVE_INFINITY;
				int bestMethod = 0;
				{
					int _g3 = 0;
					while (( _g3 < methodLength )) {
						int i3 = _g3++;
						if (( rates[i3] < best )) {
							bestMethod = i3;
							best = ((double) (rates[i3]) );
						}
						
					}
					
				}
				
				methods[0] = methods[bestMethod];
				global::System.Reflection.ParameterInfo[] params1 = methods[0].GetParameters();
				{
					int _g12 = 0;
					int _g4 = ( params1 as global::System.Array ).Length;
					while (( _g12 < _g4 )) {
						int i4 = _g12++;
						global::System.Type param1 = params1[i4].ParameterType;
						string strParam1 = global::haxe.lang.Runtime.concat(global::haxe.root.Std.@string(param1), "");
						object arg = oargs[i4];
						if (strParam1.StartsWith("haxe.lang.Null")) {
							oargs[i4] = global::haxe.lang.Runtime.mkNullable(arg, param1);
						}
						else if ((((global::System.Type) (typeof(global::System.IConvertible)) )).IsAssignableFrom(((global::System.Type) (param1) ))) {
							if (global::haxe.lang.Runtime.eq(arg, null)) {
								if (param1.IsValueType) {
									oargs[i4] = global::System.Activator.CreateInstance(((global::System.Type) (param1) ));
								}
								
							}
							else if ( ! (global::cs.Lib.nativeType(arg).IsAssignableFrom(((global::System.Type) (param1) ))) ) {
								oargs[i4] = (((global::System.IConvertible) (arg) )).ToType(((global::System.Type) (param1) ), ((global::System.IFormatProvider) (null) ));
							}
							
						}
						
					}
					
				}
				
				if (( methods[0].ContainsGenericParameters && ( methods[0] is global::System.Reflection.MethodInfo ) )) {
					global::System.Reflection.MethodInfo m = ((global::System.Reflection.MethodInfo) (methods[0]) );
					global::System.Type[] tgs = ( m as global::System.Reflection.MethodBase ).GetGenericArguments();
					{
						int _g13 = 0;
						int _g5 = ( tgs as global::System.Array ).Length;
						while (( _g13 < _g5 )) {
							int i5 = _g13++;
							tgs[i5] = typeof(object);
						}
						
					}
					
					m = m.MakeGenericMethod(((global::System.Type[]) (tgs) ));
					object retg = ( m as global::System.Reflection.MethodBase ).Invoke(((object) (obj) ), ((object[]) (oargs) ));
					return global::haxe.lang.Runtime.unbox(retg);
				}
				
				global::System.Reflection.MethodBase m1 = methods[0];
				if (( global::haxe.lang.Runtime.eq(obj, null) && ( m1 is global::System.Reflection.ConstructorInfo ) )) {
					object ret = (((global::System.Reflection.ConstructorInfo) (m1) )).Invoke(((object[]) (oargs) ));
					return global::haxe.lang.Runtime.unbox(ret);
				}
				
				object ret1 = m1.Invoke(((object) (obj) ), ((object[]) (oargs) ));
				return global::haxe.lang.Runtime.unbox(ret1);
			}
		}
		
		
		public static object unbox(object dyn) {
			if (( ( ! (global::haxe.lang.Runtime.eq(dyn, null)) ) && (global::haxe.lang.Runtime.concat(global::haxe.root.Std.@string(global::cs.Lib.nativeType(dyn)), "")).StartsWith("haxe.lang.Null") )) {
				return ((object) (global::haxe.lang.Runtime.callField(dyn, "toDynamic", 1705629508, null)) );
			}
			else {
				return dyn;
			}
			
		}
		
		
		public static object mkNullable(object obj, global::System.Type nullableType) {
			
		if (nullableType.ContainsGenericParameters)
			return haxe.lang.Null<object>.ofDynamic<object>(obj);
		return nullableType.GetMethod("_ofDynamic").Invoke(null, new object[] { obj });
	
		}
		
		
		public static object slowCallField(object obj, string field, global::haxe.root.Array args) {
			
		if (field == "toString")
		{
			if (args == null)
				return obj.ToString();
			field = "ToString";
		}
		if (args == null) args = new Array<object>();

		System.Reflection.BindingFlags bf;
		System.Type t = obj as System.Type;
		if (t == null)
		{
			string s = obj as string;
			if (s != null)
				return haxe.lang.StringRefl.handleCallField(s, field, args);
			t = obj.GetType();
			bf = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.FlattenHierarchy;
		} else {
			if (t == typeof(string) && field.Equals("fromCharCode"))
				return haxe.lang.StringExt.fromCharCode(toInt(args[0]));
			obj = null;
			bf = System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public;
		}

		System.Reflection.MethodInfo[] mis = t.GetMethods(bf);
		int last = 0;
		for (int i = 0; i < mis.Length; i++)
		{
			if (mis[i].Name.Equals(field))
			{
				mis[last++] = mis[i];
			}
		}

		if (last == 0)
		{
			throw haxe.lang.HaxeException.wrap("Method '" + field + "' not found on type " + t);
		}

		return haxe.lang.Runtime.callMethod(obj, mis, last, args);
	
		}
		
		
		public static object callField(object obj, string field, int fieldHash, global::haxe.root.Array args) {
			
		haxe.lang.HxObject hxObj = obj as haxe.lang.HxObject;
		if (hxObj != null)
			return hxObj.__hx_invokeField(field, (fieldHash == 0) ? haxe.lang.FieldLookup.hash(field) : fieldHash, args);

		return slowCallField(obj, field, args);
	
		}
		
		
		public static object getField(object obj, string field, int fieldHash, bool throwErrors) {
			

		haxe.lang.HxObject hxObj = obj as haxe.lang.HxObject;
		if (hxObj != null)
			return hxObj.__hx_getField(field, (fieldHash == 0) ? haxe.lang.FieldLookup.hash(field) : fieldHash, throwErrors, false, false);

		return slowGetField(obj, field, throwErrors);

	
		}
		
		
		public static double getField_f(object obj, string field, int fieldHash, bool throwErrors) {
			

		haxe.lang.HxObject hxObj = obj as haxe.lang.HxObject;
		if (hxObj != null)
			return hxObj.__hx_getField_f(field, (fieldHash == 0) ? haxe.lang.FieldLookup.hash(field) : fieldHash, throwErrors, false);

		return toDouble(slowGetField(obj, field, throwErrors));

	
		}
		
		
		public static object setField(object obj, string field, int fieldHash, object @value) {
			

		haxe.lang.HxObject hxObj = obj as haxe.lang.HxObject;
		if (hxObj != null)
			return hxObj.__hx_setField(field, (fieldHash == 0) ? haxe.lang.FieldLookup.hash(field) : fieldHash, value, false);

		return slowSetField(obj, field, value);

	
		}
		
		
		public static double setField_f(object obj, string field, int fieldHash, double @value) {
			

		haxe.lang.HxObject hxObj = obj as haxe.lang.HxObject;
		if (hxObj != null)
			return hxObj.__hx_setField_f(field, (fieldHash == 0) ? haxe.lang.FieldLookup.hash(field) : fieldHash, value, false);

		return toDouble(slowSetField(obj, field, value));

	
		}
		
		
		public static string toString(object obj) {
			if (global::haxe.lang.Runtime.eq(obj, null)) {
				return null;
			}
			
			if (( obj is bool )) {
				if (global::haxe.lang.Runtime.toBool((obj))) {
					return "true";
				}
				else {
					return "false";
				}
				
			}
			
			return obj.ToString();
		}
		
		
		public static bool typeEq(global::System.Type t1, global::System.Type t2) {
			
			if (t1 == null || t2 == null)
				return t1 == t2;
			string n1 = Type.getClassName(t1);
			string n2 = Type.getClassName(t2);
			return n1.Equals(n2);
	
		}
		
		
		public static To genericCast<To>(object obj) {
			
		if (obj is To)
			return (To) obj;
		else if (obj == null)
			return default(To);
		if (typeof(To) == typeof(double))
			return (To)(object) toDouble(obj);
		else if (typeof(To) == typeof(int))
			return (To)(object) toInt(obj);
		else if (typeof(To) == typeof(float))
			return (To)(object)(float)toDouble(obj);
		else if (typeof(To) == typeof(long))
			return (To)(object)(long)toDouble(obj);
		else
			return (To) obj;
	
		}
		
		
		public static string concat(string s1, string s2) {
			
		return (s1 == null ? "null" : s1) + (s2 == null ? "null" : s2);
	
		}
		
		
		public static bool toBool(object dyn) {
			
		return dyn == null ? false : ((bool) dyn);
	
		}
		
		
	}
}



namespace haxe.lang{
	public enum EmptyObject{
		EMPTY
	}
}


