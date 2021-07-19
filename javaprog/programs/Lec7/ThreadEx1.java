public class ThreadEx1 {
	public static void main(String[] args) {
		Runnable obj1 = new PrintChar('A', 500);
		Runnable obj2 = new PrintChar('B', 100);
		Thread t1 = new Thread(obj1);
		Thread t2 = new Thread(obj2);
		t1.start();
		t2.start();
	}
}
