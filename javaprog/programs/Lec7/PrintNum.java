public class PrintNum implements Runnable {
	private int max;

	public PrintNum(int n) {
		max = n;
	}
	public void run(){
		for (int i=0; i<max; i++) {
			System.out.println(i);
		}
	}
}