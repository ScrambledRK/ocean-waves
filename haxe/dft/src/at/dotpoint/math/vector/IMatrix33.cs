using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace at.dotpoint.math.vector {
	public interface IMatrix33 : global::haxe.lang.IHxObject {
		
		void toIdentity();
		
		void transpose();
		
		double determinant();
		
		void set33(global::at.dotpoint.math.vector.IMatrix33 m);
		
	}
}


