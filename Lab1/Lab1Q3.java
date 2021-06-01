import java.util.Scanner;
public class Lab1Q3 {
	public static void main(String[] args){
		Scanner input = new Scanner(System.in);
		int number;

		System.out.print("Enter a number for factorial calculation: ");
		number = input.nextInt();

		int total = number;
		while (number > 1) {
			total *= number-1;
			number--;
		}

		System.out.println("Your number's factorial: " + total);

	}
}