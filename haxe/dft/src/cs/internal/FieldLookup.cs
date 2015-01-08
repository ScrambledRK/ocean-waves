using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.lang {
	public sealed class FieldLookup {
		
		public FieldLookup() {
		}
		
		
		public static global::haxe.root.Array<int> fieldIds = new global::haxe.root.Array<int>(new int[]{77, 78, 105, 119, 120, 121, 122, 17025, 17026, 23240, 23308, 3796624, 3796847, 3839890, 3889619, 4745537, 4849249, 5393365, 5431437, 5431438, 5431439, 5431440, 5431660, 5431661, 5431662, 5431663, 5431883, 5431884, 5431885, 5431886, 5432106, 5432107, 5432108, 5432109, 5442204, 5541879, 5594513, 5741474, 5790298, 25064959, 38537191, 76061764, 87367608, 90871142, 251995742, 291546446, 291546447, 291546448, 291546449, 295397041, 302979532, 328878574, 359333139, 407283053, 452737314, 488854231, 501039929, 501983900, 520590566, 532898596, 561717374, 589796196, 731985805, 812216871, 946786476, 1005224604, 1041537810, 1067353468, 1103412149, 1147273973, 1169898256, 1181037546, 1204816148, 1214452573, 1224901875, 1247875546, 1257939113, 1279853584, 1280845662, 1282943179, 1352786672, 1472420579, 1474198947, 1532710347, 1547539107, 1564266267, 1594406711, 1620824029, 1621420777, 1623148745, 1648581351, 1664341738, 1664341739, 1664341740, 1664341741, 1705629508, 1728706141, 1744813180, 1779810297, 1830310359, 1836776262, 1913895454, 1915412854, 1916009602, 1955029599, 1981972957, 2013228622, 2025055113, 2049940314, 2049940315, 2049940316, 2049940317, 2082663554, 2084789794, 2127021138});
		
		public static global::haxe.root.Array<object> fields = new global::haxe.root.Array<object>(new object[]{"M", "N", "i", "w", "x", "y", "z", "LM", "LN", "h0", "ht", "LM1", "LN1", "M05", "N05", "__a", "arr", "len", "m11", "m12", "m13", "m14", "m21", "m22", "m23", "m24", "m31", "m32", "m33", "m34", "m41", "m42", "m43", "m44", "map", "obj", "pop", "set", "tag", "maxAmplitude", "height", "remove", "filter", "calculate", "gaussianRandom", "get_w", "get_x", "get_y", "get_z", "GetHashCode", "methodName", "iterator", "lastIndexOf", "hasNext", "reverse", "displacement", "insert", "getIndex", "length", "lengthSq", "getWind", "getTag", "normalize", "normal", "toString", "frequency", "index", "splice", "copy", "getK", "init", "join", "concat", "clone", "next", "push", "position", "setIndex", "sort", "quicksort", "spliceVoid", "c_h0_conj", "dispertion", "concatNative", "className", "phillips", "c_h0_norm", "__unsafe_get", "__unsafe_set", "indexOf", "fileName", "tmpVector2_1", "tmpVector2_2", "tmpVector2_3", "tmpVector2_4", "toDynamic", "$do_not_check_interf", "constructs", "vertices", "customParams", "params", "toArray", "__get", "__set", "Equals", "lineNumber", "gravity", "unshift", "set_w", "set_x", "set_y", "set_z", "shift", "__hx_createEmpty", "slice"});
		
		public static int doHash(string s) {
			unchecked {
				int acc = 0;
				{
					int _g1 = 0;
					int _g = s.Length;
					while (( _g1 < _g )) {
						int i = _g1++;
						acc = ( ( ( 223 * (( acc >> 1 )) ) + ((int) (s[i]) ) ) << 1 );
					}
					
				}
				
				return ((int) (( ((uint) (acc) ) >> 1 )) );
			}
		}
		
		
		public static string lookupHash(int key) {
			unchecked {
				global::haxe.root.Array<int> ids = global::haxe.lang.FieldLookup.fieldIds;
				int min = 0;
				int max = ids.length;
				while (( min < max )) {
					int mid = ( min + ( (( max - min )) / 2 ) );
					int imid = ids[mid];
					if (( key < imid )) {
						max = mid;
					}
					else if (( key > imid )) {
						min = ( mid + 1 );
					}
					else {
						return global::haxe.lang.Runtime.toString(global::haxe.lang.FieldLookup.fields[mid]);
					}
					
				}
				
				throw global::haxe.lang.HaxeException.wrap(global::haxe.lang.Runtime.concat("Field not found for hash ", global::haxe.lang.Runtime.toString(key)));
			}
		}
		
		
		public static int hash(string s) {
			unchecked {
				if (string.Equals(s, null)) {
					return 0;
				}
				
				int key = default(int);
				{
					int acc = 0;
					{
						int _g1 = 0;
						int _g = s.Length;
						while (( _g1 < _g )) {
							int i = _g1++;
							acc = ( ( ( 223 * (( acc >> 1 )) ) + ((int) (s[i]) ) ) << 1 );
						}
						
					}
					
					key = ((int) (( ((uint) (acc) ) >> 1 )) );
				}
				
				global::haxe.root.Array<int> ids = global::haxe.lang.FieldLookup.fieldIds;
				int min = 0;
				int max = ids.length;
				while (( min < max )) {
					int mid = ((int) (( min + ( ((double) ((( max - min ))) ) / 2 ) )) );
					int imid = ids[mid];
					if (( key < imid )) {
						max = mid;
					}
					else if (( key > imid )) {
						min = ( mid + 1 );
					}
					else {
						string field = global::haxe.lang.Runtime.toString(global::haxe.lang.FieldLookup.fields[mid]);
						if ( ! (string.Equals(field, s)) ) {
							return  ~ (key) ;
						}
						
						return key;
					}
					
				}
				
				ids.insert(min, key);
				global::haxe.lang.FieldLookup.fields.insert(min, s);
				return key;
			}
		}
		
		
		public static int findHash(int hash, global::haxe.root.Array<int> hashs) {
			unchecked {
				int min = 0;
				int max = hashs.length;
				while (( min < max )) {
					int mid = ( (( max + min )) / 2 );
					int imid = hashs[mid];
					if (( hash < imid )) {
						max = mid;
					}
					else if (( hash > imid )) {
						min = ( mid + 1 );
					}
					else {
						return mid;
					}
					
				}
				
				return  ~ (min) ;
			}
		}
		
		
	}
}


