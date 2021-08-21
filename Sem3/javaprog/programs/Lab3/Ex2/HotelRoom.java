public class HotelRoom {
	private int roomNo;
	private double rentalRate;

	public HotelRoom(int rn) {
		roomNo = rn;
		if (rn <= 299)
			rentalRate = 69.95;
		else
			rentalRate = 89.95;
	}

	public void setRN(int rn) {
		roomNo = rn;
	}

	public void setRR(double rr){
		rentalRate = rr;
	}

	public int getRN() { return roomNo; }
	public double getRR() { return rentalRate; }

	public String toString() {
		return "Room No: " + roomNo
			+ "\nNightly Rental Rate: " + rentalRate + "\n";
	}
}