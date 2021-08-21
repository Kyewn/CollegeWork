import java.util.Scanner;
public class Ex6 {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        final int SIZE = 10;
        double numberArr[] = new double[SIZE];

        for (int i=0; i<numberArr.length; i++) {
            System.out.print("Enter number "+ (i+1) + ": ");
            numberArr[i] = input.nextDouble();
        }
        System.out.println();
        System.out.println("Total of all numbers: " + total(numberArr));
    }

    public static double total(double[] array) {
        double total=0;
        for (double num : array) {
            total += num;
        }
        return total;
    }
}
