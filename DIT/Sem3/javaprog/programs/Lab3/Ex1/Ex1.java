public class Ex1 {
	public static void main(String[] args) {
		Square sqrObj = new Square(3.3,4.4);
		Cube cubeObj = new Cube(5.5,6.6,7.0);

		System.out.println("Square object surface area: " + sqrObj.computeSurfaceArea());
		System.out.println("Cube object surface area: " + cubeObj.computeSurfaceArea());
	}
}