import java.util.Scanner;
public class Lab1Q1 {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		double marks[] = new double[3];
		double average = 0.0;

		for (int i=0; i<3; i++){
			boolean flag = false;
			do {

				System.out.print("Enter mark " + (i+1) + ": ");
				double mark = input.nextDouble();

				if (!(mark >= 0 && mark <= 100)) {
					System.out.println("Mark out of range.");
					System.out.println();
					flag = true;
				} else {
					marks[i] = mark;
					flag = false;
				}
			} while (flag);
		}

		for (int i=0; i<3; i++) {
			average += marks[i];
		}
		average /= 3.0;

		System.out.println();

		if (average >= 50)
			System.out.println("You have passed.");
		else
			System.out.println("You have failed.");
	}
}