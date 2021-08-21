import java.util.Scanner;

public class AlgebraDriver {
	public static void main(String[] args){
		Scanner input = new Scanner(System.in);

		int a,b,c;
		System.out.print("Enter a,b,c: ");
		a = input.nextInt();
		b = input.nextInt();
		c = input.nextInt();

		Algebra obj = new Algebra(a,b,c);

		if(obj.getDiscriminant() > 0)
			System.out.println("The equation has 2 roots: " + obj.getRoot1() + ", " + obj.getRoot2());
		else if (obj.getDiscriminant() == 0 )
			System.out.println("The equation has 1 root: " + obj.getRoot1());
		else
			System.out.println("The equation has no roots.");
	}
}