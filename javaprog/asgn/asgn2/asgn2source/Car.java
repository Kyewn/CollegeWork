public class Car {
	private String plateNumber;
	private String brand;
	private String model;
	private String type;
	private String colour;
	private String status;
	private double price;

	public Car() {
		plateNumber = "";
		brand = "";
		model = "";
		type = "";
		colour = "";
		status = "";
		price = 0.00;
		price = 0;
	}

	public Car(String pn, String br, String mo, String ty, String co, String st, double pr) {
		plateNumber = pn;
		brand = br;
		model = mo;
		type = ty;
		colour = co;
		status = st;
		price = pr;
	}

	public void setPlateNumber(String pn) {
		plateNumber = pn;
	}

	public void setBrand(String br) {
		brand = br;
	}

	public void setModel(String mo) {
		model = mo;
	}

	public void setType(String ty) {
		type = ty;
	}

	public void setColour(String co) {
		colour = co;
	}

	public void setStatus(String st) {
		status = st;
	}

	public void setPrice(double pr) {
		price = pr;
	}

	public String getPlateNumber() {
		return plateNumber;
	}

	public String getBrand() {
		return brand;
	}

	public String getModel() {
		return model;
	}

	public String getType() {
		return type;
	}

	public String getColour() {
		return colour;
	}

	public String getStatus() {
		return status;
	}

	public double getPrice() {
		return price;
	}

	public String toString() {
		return "Plate number: " + plateNumber
				+ "\nBrand: " + brand
				+ "\nModel: " + model
				+ "\nType: " + type
				+ "\nColour: " + colour
				+ "\nStatus: " + status
				+ "\nPrice: " + price;
	}
}