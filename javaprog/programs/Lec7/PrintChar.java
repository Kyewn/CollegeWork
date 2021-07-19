public class PrintChar implements Runnable{
	char charToPrint;
	int times;

	public PrintChar(char c, int t) {
		charToPrint = c;
		times = t;
	}

	public void run() {
		for (int i=0; i<times; i++) {
			System.out.print(charToPrint);
		}
	}
}