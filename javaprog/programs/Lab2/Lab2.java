public class Lab2 {
	public static void main(String[] args) {
	Circle circle1 = new Circle();
	Circle circle2 = new Circle();

	circle1.setRadius(3);
	circle2.setRadius(6);

	System.out.println( circle1.getRadius() + " " + circle1.getDiameter() + " " + circle1.getArea());
	System.out.println( circle2.getRadius() + " " + circle2.getDiameter() + " " + circle2.getArea());
	}
}