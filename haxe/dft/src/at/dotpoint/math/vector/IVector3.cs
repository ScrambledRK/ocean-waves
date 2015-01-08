using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace at.dotpoint.math.vector {
	public interface IVector3 : global::haxe.lang.IHxObject, global::at.dotpoint.math.vector.IVector2 {
		
		double get_z();
		
		double set_z(double @value);
		
		double get_w();
		
		double set_w(double @value);
		
	}
}


