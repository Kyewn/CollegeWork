public class ThreadEx1_Driver {
	public static void main(String[] args){

		Runnable obj = new ThreadEx1(100000);
		Thread objThr = new Thread(obj);
		Runnable obj1 = new ThreadEx1(5100);
		Thread obj1Thr = new Thread(obj1);

		objThr.start();
		obj1Thr.start();
	}
}