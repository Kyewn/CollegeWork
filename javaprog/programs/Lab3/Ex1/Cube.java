public class Cube extends Square{
	private double depth;

	public Cube(double h, double w, double d) {
		super(h,w);
		depth = d;
	}

	public double computeSurfaceArea() {
		return super.computeSurfaceArea() * 6;
	}
}