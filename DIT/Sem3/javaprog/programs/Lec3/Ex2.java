import java.util.Scanner;

public class Ex2 {
    public static void main (String[] args) {
        final int SIZE = 10;
        Scanner input = new Scanner(System.in);
        double marks[] = new double[SIZE];

        for (int i=0;i<marks.length;i++) {
            System.out.println("Enter mark for student " + (i+1));
            marks[i] = input.nextDouble();
        }

        System.out.println();
        System.out.println("Result: ");
        for (int i=0;i<marks.length;i++){
            System.out.print("Grade for student " + (i+1));
            if (marks[i] >= 0 && marks[i] <= 49)
                System.out.println("\tFailed");
            else if (marks[i] >= 50 && marks[i] <= 59)
                System.out.println("\tGrade D");
            else if (marks[i] >= 60 && marks[i] <= 69)
                System.out.println("\tGrade C");
            else if (marks[i] >= 70 && marks[i] <= 79)
                System.out.println("\tGrade B");
            else if (marks[i] >= 80 && marks[i] <= 100)
                System.out.println("\tGrade A");
        }
    }
}