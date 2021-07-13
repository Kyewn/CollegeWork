import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class GUIEx1 extends JFrame  implements ActionListener {
	JLabel us = new JLabel("US Dollar");
	JLabel cnd = new JLabel("Canadian Dollar");
	JTextField usInput = new JTextField(10);
	JTextField cndInput = new JTextField(10);
	JButton convertBtn = new JButton("Convert");
	JButton clearBtn = new JButton("Clear");

	JPanel inputPanel = new JPanel(new GridLayout(2,2));
	FlowLayout flow = new FlowLayout();
	JPanel btnPanel = new JPanel(flow);

	public GUIEx1() {
		super("Convert US Dollars to Canadian Dollars");//set window title
		makeFrame();
		showFrame();
	}

	public void makeFrame() {
		setLayout(new GridLayout(2,1));
		flow.setAlignment(flow.RIGHT);
		cndInput.setEditable(false);

		inputPanel.add(us);
		inputPanel.add(usInput);
		inputPanel.add(cnd);
		inputPanel.add(cndInput);


		btnPanel.add(convertBtn);
		btnPanel.add(clearBtn);

		add(inputPanel);
		add(btnPanel);

		convertBtn.addActionListener(this);
		clearBtn.addActionListener(this);
	}

	public void showFrame() {
		/*IMPORTANT*/
		setSize(400,120); //set window size
		setLocationRelativeTo(null); //centerize window
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); //set default close operation
		setVisible(true); //set frame visibility
	}

	public void actionPerformed(ActionEvent ae){
		Object source = ae.getSource();
		if (source == clearBtn) {
			usInput.setText("");
			cndInput.setText("");
		} else
		cndInput.setText(String.format("%.2f", Integer.parseInt(usInput.getText()) * 1.5));
	}

	public static void main(String[] args) {
		new GUIEx1();
	}
}