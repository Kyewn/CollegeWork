import java.util.Scanner;

public class Ex1 {
    public static void main(String[] args) {
        final int SIZE = 10;
        Scanner input = new Scanner(System.in);
        int numbers[] = new int[SIZE];
        int even=0,odd=0,zero=0;

        for(int i=0;i<numbers.length;i++){
            System.out.print("Enter number " + (i+1) + ": ");
            numbers[i] = input.nextInt();
        }

        for(int i=0;i<numbers.length;i++){
            if (numbers[i]==0)
                zero++;
            else if (numbers[i]%2 == 0)
                even++;
            else if (numbers[i]%2==1)
                odd++;   
        }

        System.out.println();
        System.out.println("Result: \nEven numbers: " + even + "\nOdd numbers: " + odd + "\nZeros: " + zero);
        
    }
}