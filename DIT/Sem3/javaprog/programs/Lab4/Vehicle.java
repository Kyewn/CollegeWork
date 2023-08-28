//April 2019 Q1a

public class Vehicle {
	private String model;
	private int year;

	public Vehicle(String m, int y) {
		model = m;
		year = y;
	}

	public Vehicle() {
		this("Honda", 2018);
	}

	public void setYear(int y) {
		if (y >= 1980 && y <= 2018)
			year = y;
		else year = 2018;
	}
	public int getYear() {
		return year;
	}

	public String toString() {
		return "Model: " + model
			+ "\nYear: " + year;
	}
}
