import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class GUIEx2 extends JFrame implements ActionListener {
	JLabel movie = new JLabel("Movie:");
	JLabel qty = new JLabel("Quantity:");
	JLabel total = new JLabel("Total:");
	JTextField movieInput = new JTextField(10);
	JTextField qtyInput = new JTextField(10);
	JTextField totalInput = new JTextField(10);
	JButton calcBtn = new JButton("Calculate");
	JButton clearBtn = new JButton("Clear");

	public GUIEx2(){
		super("Movie Ticketing");
		makeFrame();
		showFrame();
	}

	public void makeFrame() {
		//display
		setLayout(new GridLayout(4,2));

		add(movie);
		add(movieInput);
		add(qty);
		add(qtyInput);
		add(total);
		add(totalInput);
		add(calcBtn);
		add(clearBtn);

		totalInput.setEditable(false);
		totalInput.setText("RM");

		//events/functions
		calcBtn.addActionListener(this);
		qtyInput.addActionListener(this);
		clearBtn.addActionListener(this);
	}

	public void showFrame() {
		setSize(450, 200); //set window size
		setLocationRelativeTo(null); //centerize
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);//set default close operation
		setVisible(true); //change val from 0 to 1
	}


	public void actionPerformed(ActionEvent ae){
		Object source = ae.getSource();

		if (source == clearBtn) {
			movieInput.setText("");
			qtyInput.setText("");
			totalInput.setText("RM");
		} else {
			int totalPrice = Integer.parseInt(qtyInput.getText()) * 8;
			totalInput.setText(String.format("RM%.2f", totalPrice + totalPrice * 0.06));
		}
	}

	public static void main(String[] args){
		new GUIEx2();
	}
}