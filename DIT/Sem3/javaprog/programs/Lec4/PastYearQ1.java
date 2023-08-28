import java.util.Scanner;
import java.util.InputMismatchException;

public class PastYearQ1 {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int numbers[] = new int[5];
        int number;

        for (int i=0;i<7;i++) {
        	while(true){
            	try {
                    do {
                        System.out.print("Please enter a value: ");
                        number = input.nextInt();

                        if (number < 1 || number > 5)
                            System.out.println("Value is out of range (1-5)!");
                    } while (number < 1 || number > 5);
                    numbers[number-1]++;
                    break;
                } catch (InputMismatchException e) {
	                System.out.println("Invalid data . Please enter number only.");
	                input.nextLine();
            	} catch (Exception e) {
                	System.out.println("Program encountered an unknown error.");
            	}
        	}
        }

        System.out.println();
        System.out.println("Result:");

        for (int i=0;i<5;i++) {
	        System.out.println("Counter for " + (i+1) + " is " + numbers[i] + " time(s)");
        }
    }
}