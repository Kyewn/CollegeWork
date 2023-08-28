import java.util.Scanner;
import java.util.Random;

public class Ex4 {
    public static void main (String[] args) {
        final int SIZE = 200;
        int randomNo[] = new int[SIZE];
        int counter[] = new int[10];
        Random random = new Random();

        for(int elem : randomNo) {
            elem = random.nextInt(10);
            counter[elem]++;
        }
        
        for (int i=0;i<counter.length;i++){
            System.out.println("Number of " + i + ": " + counter[i]);
        }
    }
}
