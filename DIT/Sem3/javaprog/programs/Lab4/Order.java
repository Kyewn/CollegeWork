import java.util.Scanner;
import java.util.InputMismatchException;
//try catch ex2

public class Order {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		char confirmation;
		char size;
		int qty = 0;
		double total = 0;
		boolean hasSize = false;

		do {
			//prompting input process loop infinitely
			while (true){
				//Handle size
				System.out.print("Please enter your size: ");
				size = input.next().charAt(0);

				//if size is not inputted correctly, direct user to confirmation msg
				if (Character.toUpperCase(size) != 'S' && Character.toUpperCase(size) != 'M' && Character.toUpperCase(size) != 'L') {
					System.out.println("Please enter S/M/L");
					hasSize = false;
					break;
				} else hasSize = true;

				//Handle qty
				try {
					System.out.print("Please enter your quantity: ");
					qty = input.nextInt();

					//if qty smaller than 1, direct user to confirmation
					if (qty <= 0){
						System.out.println("Please enter at least 1");
						break;
					}
				} catch (InputMismatchException e) {
					System.out.println("Invalid data. Please enter number only");
					input.nextLine();
					//show error msg and since there is no break, continue looping from the start
				}

				//in normal cases, if both inputs are correct, end the loop and process it
				if (hasSize && qty > 0) break;
			}

			//process
			if (hasSize && qty > 0) {
				if (size == 'S')
					total += 1.50 * qty;
				else if (size == 'M')
					total += 2.50 * qty;
				else if (size == 'L')
					total += 3.0 * qty;
			}

			//confirmation msg
			do {
				System.out.print("Do you want to continue? (y/n)");
				confirmation = Character.toUpperCase(input.next().charAt(0));

				if (Character.toUpperCase(confirmation) != 'Y' && Character.toUpperCase(confirmation) != 'N')
					System.out.println("Invalid input, please enter Y or N");
			} while(Character.toUpperCase(confirmation) != 'Y' && Character.toUpperCase(confirmation) != 'N');

			if (Character.toUpperCase(confirmation) == 'Y')
				continue;
			else if (Character.toUpperCase(confirmation) == 'N');
				break;
		} while (true);

		//display here
		System.out.println();
		System.out.println("The total price is RM" + total);
	}
}