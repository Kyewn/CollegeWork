import java.util.*;
public class DivisionMistakeCaught3
{
    public static void main(String[] args)
    {
        Scanner input = new Scanner(System.in);
        int numerator, denominator, result;
        while (true) {
            try
            {
                System.out.print("Enter numerator >> ");
                numerator = input.nextInt();
                System.out.print("Enter denominator >> ");
                denominator = input.nextInt();
                result = numerator / denominator;
                System.out.println(numerator + " / " + denominator +
                " = " + result);
                break;
            }
            catch(ArithmeticException mistake)
            {
                System.out.println(mistake.getMessage());
            }
            catch(InputMismatchException mistake)
            {
                System.out.println("Wrong data type");
                input.nextLine();
            }
        }
    }
}