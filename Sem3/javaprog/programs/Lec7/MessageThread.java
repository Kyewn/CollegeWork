import java.util.Random;
public class MessageThread extends Thread {
	private Random r = new Random();
	private int option;

	public void run() {
		String optionArr[] = new String[3];
		optionArr[0]="Thank you";
		optionArr[1]="Smile";
		optionArr[2]="Bye";

		for (int i=0; i<100; i++) {
			option = r.nextInt(3);
			System.out.println(optionArr[option]);
			try {
				//stop thread for 5 secs (5000msecs)
				this.sleep(5000);
			} catch (InterruptedException e) {
				//error caused by stopping thread, do nothing
				System.out.print("");
			}
		}
	}
}