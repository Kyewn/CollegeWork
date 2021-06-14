import java.util.Scanner;
public class Ex5 {
    public static void main(String[] args){
        Scanner input = new Scanner(System.in);
        int size;
        int best;

        System.out.print("Enter number of students: ");
        size = input.nextInt();

        int marks[] = new int[size];
        for (int i=0; i<marks.length; i++) {
            do {
                System.out.print("Enter mark for student " + (i+1) + ": ");
                marks[i] = input.nextInt();

                if (marks[i] < 0 || marks[i] > 100)
                    System.out.println("*Invalid input!*");
            } while(marks[i] < 0 || marks[i] > 100);
        }
        
        best = marks[0];
        for(int mark : marks){
            if(mark > best) best = mark;
        }

        System.out.println();
        for (int i=0; i<marks.length; i++) {
            System.out.print("Student " + (i+1) + ": " + marks[i] + " ");
            if (marks[i] >= best-5)
                System.out.print("(Grade A)\n");
            else if (marks[i] >= best-10)
                System.out.print("(Grade B)\n");
            else if (marks[i] >= best-15)
                System.out.print("(Grade C)\n");
            else if (marks[i] >= best-20)
                System.out.print("(Grade D)\n");
            else 
                System.out.print("(Grade F)\n");
        }
        System.out.println("Best score: " + best);
    }
}
