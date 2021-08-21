//try catch ex1

import java.util.Scanner;
import java.util.InputMismatchException;

public class NumException {
  public static void main(String[] args) {
    Scanner input = new Scanner(System.in);
    int nums[] = new int[8];
    for (int i=0; i<8; i++){
      while(true){
        try {
          System.out.print("Enter number " + (i+1) + ": ");
          nums[i] = input.nextInt();
          break;
        } catch (InputMismatchException e) {
          System.out.println("Please key in an integer!");
          input.nextLine();
        }
      }
    }

    int max = nums[0];
    for (int no : nums) {
        if (no > max)
            max = no;
    }
    System.out.println();

    System.out.println("The array: ");
    for (int no: nums) {
    	System.out.print(no + " ");
    }
    System.out.println();
    System.out.println("The maximum value of the 8 numbers: " + max);
  }
}