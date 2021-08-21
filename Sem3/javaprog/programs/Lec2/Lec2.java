import java.util.Scanner;

public class RLab1 {
public static void main(String[] args) {
   	Scanner input = new Scanner(System.in);
   	int years, months, sent;

	do {
     	System.out.println("Enter your age in:-");
     	System.out.print("Years: ");
     	years = input.nextInt();
	do{
		System.out.print("Months: ");
		months = input.nextInt();
     	if (months >= 12 || months < 0)
         	System.out.println("Months cannot be >= 12 or < 0!");
         	System.out.println();
    	} while(months>=12 || months < 0);

	    months += years*12;
		    if (months > 500)
		     	System.out.println("Your age in months: " + months + "...");
		    else
		        System.out.println("Your age in months: " + months);

		    System.out.println();
		    System.out.print("Enter any integer to continue (9999 to quit): ");
		    sent = input.nextInt();
		    System.out.println("---------------------------");
   		} while (sent!= 9999);
	}
}