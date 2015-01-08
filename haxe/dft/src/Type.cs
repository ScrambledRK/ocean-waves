using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.root {
	public class ValueType : global::haxe.lang.Enum {
		
		static ValueType() {
			global::haxe.root.ValueType.constructs = new global::haxe.root.Array<object>(new object[]{"TNull", "TInt", "TFloat", "TBool", "TObject", "TFunction", "TClass", "TEnum", "TUnknown"});
			global::haxe.root.ValueType.TNull = new global::haxe.root.ValueType(0, new global::haxe.root.Array<object>(new object[]{}));
			global::haxe.root.ValueType.TInt = new global::haxe.root.ValueType(1, new global::haxe.root.Array<object>(new object[]{}));
			global::haxe.root.ValueType.TFloat = new global::haxe.root.ValueType(2, new global::haxe.root.Array<object>(new object[]{}));
			global::haxe.root.ValueType.TBool = new global::haxe.root.ValueType(3, new global::haxe.root.Array<object>(new object[]{}));
			global::haxe.root.ValueType.TObject = new global::haxe.root.ValueType(4, new global::haxe.root.Array<object>(new object[]{}));
			global::haxe.root.ValueType.TFunction = new global::haxe.root.ValueType(5, new global::haxe.root.Array<object>(new object[]{}));
			global::haxe.root.ValueType.TUnknown = new global::haxe.root.ValueType(8, new global::haxe.root.Array<object>(new object[]{}));
		}
		
		
		public ValueType(global::haxe.lang.EmptyObject empty) : base(global::haxe.lang.EmptyObject.EMPTY) {
		}
		
		
		public ValueType(int index, global::haxe.root.Array<object> @params) : base(index, @params) {
		}
		
		
		public static global::haxe.root.Array<object> constructs;
		
		public static global::haxe.root.ValueType TNull;
		
		public static global::haxe.root.ValueType TInt;
		
		public static global::haxe.root.ValueType TFloat;
		
		public static global::haxe.root.ValueType TBool;
		
		public static global::haxe.root.ValueType TObject;
		
		public static global::haxe.root.ValueType TFunction;
		
		public static global::haxe.root.ValueType TClass(global::System.Type c) {
			unchecked {
				return new global::haxe.root.ValueType(6, new global::haxe.root.Array<object>(new object[]{c}));
			}
		}
		
		
		public static global::haxe.root.ValueType TEnum(global::System.Type e) {
			unchecked {
				return new global::haxe.root.ValueType(7, new global::haxe.root.Array<object>(new object[]{e}));
			}
		}
		
		
		public static global::haxe.root.ValueType TUnknown;
		
		public static new object __hx_createEmpty() {
			return new global::haxe.root.ValueType(global::haxe.lang.EmptyObject.EMPTY);
		}
		
		
		public static new object __hx_create(global::haxe.root.Array arr) {
			unchecked {
				return new global::haxe.root.ValueType(((int) (global::haxe.lang.Runtime.toInt(arr[0])) ), ((global::haxe.root.Array<object>) (global::haxe.root.Array<object>.__hx_cast<object>(((global::haxe.root.Array) (arr[1]) ))) ));
			}
		}
		
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.root {
	public class Type : global::haxe.lang.HxObject {
		
		public Type(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Type() {
			global::haxe.root.Type.__hx_ctor__Type(this);
		}
		
		
		public static void __hx_ctor__Type(global::haxe.root.Type __temp_me9) {
		}
		
		
		public static global::System.Type getClass<T>(T o) {
			
		if (o == null || o is haxe.lang.DynamicObject || o is System.Type)
			return null;

		return o.GetType();
	
		}
		
		
		public static global::System.Type getEnum(object o) {
			
		if (o is System.Enum || o is haxe.lang.Enum)
			return o.GetType();
		return null;
	
		}
		
		
		public static global::System.Type getSuperClass(global::System.Type c) {
			global::System.Type t = ((global::System.Type) (c) );
			global::System.Type @base = t.BaseType;
			if (( ( global::haxe.lang.Runtime.typeEq(@base, null) || string.Equals(global::haxe.lang.Runtime.concat(global::haxe.root.Std.@string(@base), ""), "haxe.lang.HxObject") ) || string.Equals(global::haxe.lang.Runtime.concat(global::haxe.root.Std.@string(@base), ""), "System.Object") )) {
				return null;
			}
			
			return ((global::System.Type) (@base) );
		}
		
		
		public static string getClassName(global::System.Type c) {
			unchecked {
				string ret = global::haxe.lang.Runtime.toString(((global::System.Type) (c) ));
				if (( ( ret.Length > 10 ) && ret.StartsWith("haxe.root.") )) {
					ret = global::haxe.lang.StringExt.substr(ret, 10, default(global::haxe.lang.Null<int>));
				}
				
				switch (ret) {
					case "System.Int32":
					{
						return "Int";
					}
					
					
					case "System.Double":
					{
						return "Float";
					}
					
					
					case "System.String":
					{
						return "String";
					}
					
					
					case "System.Object":
					{
						return "Dynamic";
					}
					
					
					case "System.Type":
					{
						return "Class";
					}
					
					
					default:
					{
						return global::haxe.lang.Runtime.toString(global::haxe.lang.StringExt.split(ret, "`")[0]);
					}
					
				}
				
			}
		}
		
		
		public static string getEnumName(global::System.Type e) {
			unchecked {
				string ret = global::haxe.lang.Runtime.toString(((global::System.Type) (e) ));
				if (( ( ret.Length > 10 ) && ret.StartsWith("haxe.root.") )) {
					ret = global::haxe.lang.StringExt.substr(ret, 10, default(global::haxe.lang.Null<int>));
				}
				
				if (( ( ret.Length == 14 ) && string.Equals(ret, "System.Boolean") )) {
					return "Bool";
				}
				
				return ret;
			}
		}
		
		
		public static global::System.Type resolveClass(string name) {
			unchecked {
				if (( global::haxe.lang.StringExt.indexOf(name, ".", default(global::haxe.lang.Null<int>)) == -1 )) {
					name = global::haxe.lang.Runtime.concat("haxe.root.", name);
				}
				
				global::System.Type t = global::System.Type.GetType(((string) (name) ));
				if (global::haxe.lang.Runtime.typeEq(t, null)) {
					global::System.Collections.IEnumerator all = ( global::System.AppDomain.CurrentDomain.GetAssemblies() as global::System.Array ).GetEnumerator();
					while (all.MoveNext()) {
						global::System.Reflection.Assembly t2 = ((global::System.Reflection.Assembly) (all.Current) );
						t = t2.GetType(((string) (name) ));
						if ( ! (global::haxe.lang.Runtime.typeEq(t, null)) ) {
							break;
						}
						
					}
					
				}
				
				if (global::haxe.lang.Runtime.typeEq(t, null)) {
					switch (name) {
						case "haxe.root.Int":
						{
							return ((global::System.Type) (typeof(int)) );
						}
						
						
						case "haxe.root.Float":
						{
							return ((global::System.Type) (typeof(double)) );
						}
						
						
						case "haxe.root.Class":
						{
							return ((global::System.Type) (typeof(global::System.Type)) );
						}
						
						
						case "haxe.root.Dynamic":
						{
							return ((global::System.Type) (typeof(object)) );
						}
						
						
						case "haxe.root.String":
						{
							return ((global::System.Type) (typeof(string)) );
						}
						
						
						default:
						{
							return null;
						}
						
					}
					
				}
				else if (( t.IsInterface && (((global::System.Type) (typeof(global::haxe.lang.IGenericObject)) )).IsAssignableFrom(((global::System.Type) (t) )) )) {
					t = null;
					int i = 0;
					string ts = "";
					while (( global::haxe.lang.Runtime.typeEq(t, null) && ( i < 18 ) )) {
						i++;
						ts = global::haxe.lang.Runtime.concat(ts, global::haxe.lang.Runtime.concat((( (( i == 1 )) ? ("") : (",") )), "System.Object"));
						t = global::System.Type.GetType(((string) (global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(name, "`"), global::haxe.lang.Runtime.toString(i)), "["), ts), "]")) ));
					}
					
					return ((global::System.Type) (t) );
				}
				else {
					return ((global::System.Type) (t) );
				}
				
			}
		}
		
		
		public static global::System.Type resolveEnum(string name) {
			
		if (name == "Bool") return typeof(bool);
		System.Type t = resolveClass(name);
		if (t != null && (t.BaseType.Equals(typeof(System.Enum)) || t.BaseType.Equals(typeof(haxe.lang.Enum))))
			return t;
		return null;
	
		}
		
		
		public static T createInstance<T>(global::System.Type cl, global::haxe.root.Array args) {
			if (global::haxe.lang.Runtime.refEq(cl, typeof(string))) {
				return global::haxe.lang.Runtime.genericCast<T>(args[0]);
			}
			
			global::System.Type t = ((global::System.Type) (cl) );
			if (t.IsInterface) {
				global::System.Type cl1 = global::haxe.root.Type.resolveClass(global::haxe.root.Type.getClassName(cl));
				t = cl1;
			}
			
			global::System.Reflection.ConstructorInfo[] ctors = t.GetConstructors();
			return global::haxe.lang.Runtime.genericCast<T>(global::haxe.lang.Runtime.callMethod(null, ((global::System.Reflection.MethodBase[]) (ctors) ), ( ctors as global::System.Array ).Length, args));
		}
		
		
		public static T createEmptyInstance<T>(global::System.Type cl) {
			unchecked {
				global::System.Type t = ((global::System.Type) (cl) );
				if (t.IsInterface) {
					global::System.Type cl1 = global::haxe.root.Type.resolveClass(global::haxe.root.Type.getClassName(cl));
					t = cl1;
				}
				
				if (global::haxe.root.Reflect.hasField(cl, "__hx_createEmpty")) {
					return global::haxe.lang.Runtime.genericCast<T>(global::haxe.lang.Runtime.callField(cl, "__hx_createEmpty", 2084789794, null));
				}
				
				if (global::haxe.lang.Runtime.refEq(cl, typeof(string))) {
					return global::haxe.lang.Runtime.genericCast<T>(((object) ("") ));
				}
				
				global::System.Type t1 = ((global::System.Type) (cl) );
				global::System.Reflection.ConstructorInfo[] ctors = t1.GetConstructors();
				{
					int _g1 = 0;
					int _g = ( ctors as global::System.Array ).Length;
					while (( _g1 < _g )) {
						int c = _g1++;
						if (( ( ( ctors[c] as global::System.Reflection.MethodBase ).GetParameters() as global::System.Array ).Length == 0 )) {
							global::System.Reflection.ConstructorInfo[] arr = new global::System.Reflection.ConstructorInfo[1];
							arr[0] = ctors[c];
							return global::haxe.lang.Runtime.genericCast<T>(global::haxe.lang.Runtime.callMethod(null, ((global::System.Reflection.MethodBase[]) (arr) ), ( arr as global::System.Array ).Length, new global::haxe.root.Array<object>(new object[]{})));
						}
						
					}
					
				}
				
				return global::haxe.lang.Runtime.genericCast<T>(global::System.Activator.CreateInstance(((global::System.Type) (t1) )));
			}
		}
		
		
		public static T createEnum<T>(global::System.Type e, string constr, global::haxe.root.Array @params) {
			
		if (@params == null || @params[0] == null)
		{
			object ret = haxe.lang.Runtime.slowGetField(e, constr, true);
			if (ret is haxe.lang.Function)
				throw haxe.lang.HaxeException.wrap("Constructor " + constr + " needs parameters");
			return (T) ret;
		} else {
			return (T) haxe.lang.Runtime.slowCallField(e, constr, @params);
		}
	
		}
		
		
		public static T createEnumIndex<T>(global::System.Type e, int index, global::haxe.root.Array @params) {
			global::haxe.root.Array<object> constr = global::haxe.root.Type.getEnumConstructs(e);
			return global::haxe.root.Type.createEnum<T>(e, global::haxe.lang.Runtime.toString(constr[index]), @params);
		}
		
		
		public static global::haxe.root.Array<object> getInstanceFields(global::System.Type c) {
			unchecked {
				if (global::haxe.lang.Runtime.refEq(c, typeof(string))) {
					return global::haxe.lang.StringRefl.fields;
				}
				
				global::System.Type c1 = ((global::System.Type) (c) );
				global::haxe.root.Array<object> ret = new global::haxe.root.Array<object>(new object[]{});
				global::System.Reflection.BindingFlags bindingFlags = default(global::System.Reflection.BindingFlags);
				bindingFlags = ((global::System.Reflection.BindingFlags) (((object) (( ( ((int) (global::haxe.lang.Runtime.toInt(((object) (global::System.Reflection.BindingFlags.Public) ))) ) | ((int) (global::haxe.lang.Runtime.toInt(((object) (global::System.Reflection.BindingFlags.Instance) ))) ) ) | ((int) (global::haxe.lang.Runtime.toInt(((object) (global::System.Reflection.BindingFlags.FlattenHierarchy) ))) ) )) )) );
				global::System.Reflection.MemberInfo[] mis = c1.GetMembers(((global::System.Reflection.BindingFlags) (bindingFlags) ));
				{
					int _g1 = 0;
					int _g = ( mis as global::System.Array ).Length;
					while (( _g1 < _g )) {
						int i = _g1++;
						global::System.Reflection.MemberInfo i1 = mis[i];
						if (( i1 is global::System.Reflection.PropertyInfo )) {
							continue;
						}
						
						string n = i1.Name;
						if ((  ! (n.StartsWith("__hx_"))  && ( (( (( ((uint) (0) ) < n.Length )) ? (((int) (n[0]) )) : (-1) )) != 46 ) )) {
							switch (n) {
								case "Equals":
								case "ToString":
								case "GetHashCode":
								case "GetType":
								{
									break;
								}
								
								
								default:
								{
									ret.push(n);
									break;
								}
								
							}
							
						}
						
					}
					
				}
				
				return ret;
			}
		}
		
		
		public static global::haxe.root.Array<object> getClassFields(global::System.Type c) {
			
		Array<object> ret = new Array<object>();

		if (c == typeof(string))
		{
			ret.push("fromCharCode");
			return ret;
		}

        System.Reflection.MemberInfo[] mis = c.GetMembers(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
        for (int i = 0; i < mis.Length; i++)
        {
            string n = mis[i].Name;
			if (!n.StartsWith("__hx_"))
				ret.push(mis[i].Name);
        }

        return ret;
	
		}
		
		
		public static global::haxe.root.Array<object> getEnumConstructs(global::System.Type e) {
			if (global::haxe.root.Reflect.hasField(e, "constructs")) {
				return ((global::haxe.root.Array<object>) (global::haxe.root.Array<object>.__hx_cast<object>(((global::haxe.root.Array) (global::haxe.lang.Runtime.callField(global::haxe.lang.Runtime.getField(e, "constructs", 1744813180, true), "copy", 1103412149, null)) ))) );
			}
			
			return global::cs.Lib.array<object>(((object[]) (global::System.Enum.GetNames(((global::System.Type) (e) ))) ));
		}
		
		
		public static global::haxe.root.ValueType @typeof(object v) {
			
		if (v == null) return ValueType.TNull;

        System.Type t = v as System.Type;
        if (t != null)
        {
            //class type
            return ValueType.TObject;
        }

        t = v.GetType();
        if (t.IsEnum)
            return ValueType.TEnum(t);
        if (t.IsValueType)
        {
            System.IConvertible vc = v as System.IConvertible;
            if (vc != null)
            {
                switch (vc.GetTypeCode())
                {
                    case System.TypeCode.Boolean: return ValueType.TBool;
                    case System.TypeCode.Double:
						double d = vc.ToDouble(null);
						if (d >= int.MinValue && d <= int.MaxValue && d == vc.ToInt32(null))
							return ValueType.TInt;
						else
							return ValueType.TFloat;
                    case System.TypeCode.Int32:
                        return ValueType.TInt;
                    default:
                        return ValueType.TClass(t);
                }
            } else {
                return ValueType.TClass(t);
            }
        }

        if (v is haxe.lang.IHxObject)
        {
            if (v is haxe.lang.DynamicObject)
                return ValueType.TObject;
            else if (v is haxe.lang.Enum)
                return ValueType.TEnum(t);
            return ValueType.TClass(t);
        } else if (v is haxe.lang.Function) {
            return ValueType.TFunction;
        } else {
            return ValueType.TClass(t);
        }
	
		}
		
		
		public static bool enumEq<T>(T a, T b) {
			
			if (a is haxe.lang.Enum)
				return a.Equals(b);
			else
				return haxe.lang.Runtime.eq(a, b);
	
		}
		
		
		public static string enumConstructor(object e) {
			
		if (e is System.Enum)
			return e + "";
		else
			return ((haxe.lang.Enum) e).getTag();
	
		}
		
		
		public static global::haxe.root.Array enumParameters(object e) {
			
		return ( e is System.Enum ) ? new Array<object>() : ((haxe.lang.Enum) e).@params;
	
		}
		
		
		public static int enumIndex(object e) {
			
		if (e is System.Enum)
		{
			System.Array values = System.Enum.GetValues(e.GetType());
			return System.Array.IndexOf(values, e);
		} else {
			return ((haxe.lang.Enum) e).index;
		}
	
		}
		
		
		public static global::haxe.root.Array<T> allEnums<T>(global::System.Type e) {
			global::haxe.root.Array<object> ctors = global::haxe.root.Type.getEnumConstructs(e);
			global::haxe.root.Array<T> ret = new global::haxe.root.Array<T>(new T[]{});
			{
				int _g = 0;
				while (( _g < ctors.length )) {
					string ctor = global::haxe.lang.Runtime.toString(ctors[_g]);
					 ++ _g;
					T v = global::haxe.lang.Runtime.genericCast<T>(global::haxe.root.Reflect.field(e, ctor));
					if (global::haxe.root.Std.@is(v, e)) {
						ret.push(v);
					}
					
				}
				
			}
			
			return ret;
		}
		
		
		public static new object __hx_createEmpty() {
			return new global::haxe.root.Type(global::haxe.lang.EmptyObject.EMPTY);
		}
		
		
		public static new object __hx_create(global::haxe.root.Array arr) {
			return new global::haxe.root.Type();
		}
		
		
	}
}


