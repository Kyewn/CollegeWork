// Circle class declaration
public class Circle {
	final static double pi = 3.142;
	private double radius, diameter, area;

	public Circle() {
		radius = 1.0;
		diameter = 2.0;
		area = pi;
	}

	public void setRadius(double r) {
		radius = r;
		diameter = r*2;
		area = r*r* pi;
	}

	public double getRadius() { return radius; }
	public double getDiameter() { return diameter; }
	public double getArea() { return area; }

}
