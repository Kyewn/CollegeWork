import java.util.Scanner;

public class Ex3 {
    public static void main(String[] args) {
        int number;
        int counter[] = new int[2];
        
        Scanner input = new Scanner (System.in);
        do {
            do {
                System.out.print("Key in number (1-10): ");
                number = input.nextInt();

                if (number < 0 || number > 10)
                    System.out.println("*Invalid input!*");
            } while (number < 0 || number > 10);

            if (number == 0) break;
            else counter[number%2]++;
        } while (number != 0);

        System.out.println();
        System.out.println("Result\nEven numbers: " + counter[0] + "\nOdd numbers: " + counter[1]);
    }
}
