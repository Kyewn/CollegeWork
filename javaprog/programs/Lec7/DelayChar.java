public class DelayChar extends Thread {
	private char myChar;

	public DelayChar(char c) {
		myChar = c;
	}

	public void run() {
		for (int i=0;i<100;i++) {
			System.out.println(myChar);
			try {
				if (i ==  19) {
					this.sleep(3000);
				} else if (i == 74) {
					this.sleep(5000);
				}
			} catch (InterruptedException e) {
				System.out.print("");
			}
		}
	}
}