using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace at.dotpoint.math.vector {
	public interface IVector2 : global::haxe.lang.IHxObject {
		
		double get_x();
		
		double set_x(double @value);
		
		double get_y();
		
		double set_y(double @value);
		
		void normalize();
		
		double length();
		
	}
}


