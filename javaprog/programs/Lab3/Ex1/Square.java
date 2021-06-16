public class Square {
	private double height, width, surfaceArea;

	public Square(double h, double w) {
		height = h;
		width = w;
	}

	public double computeSurfaceArea() {
		surfaceArea = height * width;
		return surfaceArea;
	}
}