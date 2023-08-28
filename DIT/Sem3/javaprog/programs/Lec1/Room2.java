import java.util.Scanner;

public class Room2 {
	public static void main(String [] args) {
        //Declaring an object of class Scanner as a
        //new Scanner object that reads input from keyboard (System.in)
        Scanner input = new Scanner(System.in);

        int width, length;
        System.out.print("Enter width: ");
        width = input.nextInt();
        System.out.print("Enter length: ");
        length = input.nextInt();

        System.out.println("The area is " + width*length);
	}
}