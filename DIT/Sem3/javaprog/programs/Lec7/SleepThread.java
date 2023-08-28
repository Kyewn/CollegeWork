public class SleepThread extends Thread {
	public void run() {
		for (int i=0;i<50;i++) {
			System.out.println("Awake");
			if (i < 20)
				try{
					this.sleep(340);
				}catch (InterruptedException e) {
					System.out.print("");
				}
		}
	}
}