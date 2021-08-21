public class ThreadEx1 implements Runnable{
	private int max;
	public ThreadEx1(int num){
		max = num;
	}

	public void run() {
		for (int i=0;i<max;i++) {
			System.out.print(i + " ");
		}
		System.out.print(max);
	}
}