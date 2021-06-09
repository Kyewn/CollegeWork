public class FanClass {
	final private int SLOW = 1, MEDIUM = 2, FAST = 3;
	private int speed;
	private boolean on;
	private double radius;
	private String color;

	public FanClass(){
		speed = SLOW;
		on = false;
		radius = 5;
		color = "blue";
	}

	public FanClass(int s, boolean o, double r, String c) {
		speed = s;
		on = o;
		radius = r;
		color = c;
	}

	public void setSpeed(int s){
		speed = s;
	}

	public void setOn(boolean o){
		on = o;
	}

	public void setRad(double r){
		radius = r;
	}

	public void setColor(String c){
		color = c;
	}

	public int getSpeed(){ return speed; }
	public boolean getOn(){ return on; }
	public double getRad(){ return radius; }
	public String getColor(){ return color; }

	public String toString() {
		if (on) {
			return "Fan speed: " + speed
				+ "\nFan colour: " + color
				+ "\nFan Radius: " + radius;
		} else {
			return "Fan colour: " + color
				+ "\nFan radius: " + radius
				+ "\nfan is off";
		}
	}
}