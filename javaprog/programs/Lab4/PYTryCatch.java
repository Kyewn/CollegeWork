//April 2019 Q4

import java.util.Scanner;
import java.util.InputMismatchException;

public class PYTryCatch {
	public static void main(String[] args){
		final int SIZE = 5;
		Scanner input = new Scanner(System.in);
		int nums[] = new int[SIZE];

		for (int i=0; i<SIZE; i++) {
			while (true) {
				try {
					System.out.print("Please enter a value: ");
					nums[i] = input.nextInt();

					if(nums[i] < 1 || nums[i] > 20)
						System.out.println("Please enter a number from 1-20.");
					else break;
				} catch (InputMismatchException e) {
					System.out.println("Invalid data. Please enter number only.");
					input.nextLine();
				}
			}
		}
		System.out.println();
		System.out.println("Output: ");
		for (int no: nums) {
			System.out.print(no + ": ");
			for(int i=0;i<no;i++){
				System.out.print('*');
			}
			System.out.println();
		}
	}
}