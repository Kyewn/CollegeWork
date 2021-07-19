public class ThreadEx4 {
	public static void main(String[] args){
		DelayChar obj1 = new DelayChar('A');
		DelayChar obj2 = new DelayChar('B');
		Thread t1 = new Thread(obj1);
		Thread t2 = new Thread(obj2);

		t1.start();
		t2.start();
	}
}