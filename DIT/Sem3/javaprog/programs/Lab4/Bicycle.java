//April 2019 Q1b

public class Bicycle extends Vehicle {
	private String type;

	public Bicycle(String m, int y, String t) {
		super(m,y);
		type = t;
	}

	public String toString() {
		return super.toString() +
			"\nType: " + type;
	}
}