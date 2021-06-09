public class Algebra {
	private int a,b,c;

	public Algebra(int x, int y, int z) {
		a = x;
		b = y;
		c = z;
	}

	public int getA() { return a; }
	public int getB() { return b; }
	public int getC() { return c; }

	public double getDiscriminant() {
		return Math.sqrt(Math.pow(b, 2) - (4 * a * c));
	}

	public double getRoot1() {
		if (this.getDiscriminant() < 0)
			return 0;
		else
			return (-b + this.getDiscriminant()) / (2*a);
	}

	public double getRoot2() {
		if (this.getDiscriminant() < 0)
			return 0;
		else
			return (-b - this.getDiscriminant()) / (2*a);
	}
}