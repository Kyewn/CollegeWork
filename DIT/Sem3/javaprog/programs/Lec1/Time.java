import java.util.Scanner;

public class Time {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		System.out.print("Enter minutes: ");
		int minutes = input.nextInt();

		System.out.println();

		if(minutes >= 60) {
			int hours = (minutes-(minutes%60))/60;
			minutes %= 60;
			System.out.println("Time: " + hours + " hrs " + minutes + " mins");
		} else
			System.out.println("Time: " + minutes + " mins");
	}
}