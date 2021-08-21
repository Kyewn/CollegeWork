//BorderLayout example

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class GUIEx3 extends JFrame implements ActionListener{
	JLabel r = new JLabel("Radius:", JLabel.CENTER);
	JLabel h = new JLabel("Height:", JLabel.CENTER);
	JLabel v = new JLabel("Volume:", JLabel.CENTER);
	JTextField rInput = new JTextField(10);
	JTextField hInput = new JTextField(10);
	JTextField vInput = new JTextField(10);
	JButton calcBtn = new JButton("Calculate");
	JButton clearBtn = new JButton("Clear");
	JPanel top = new JPanel(new GridLayout(3,2));
	JPanel bottom = new JPanel();

	public GUIEx3() {
		super("Volume of Cone");
		makeFrame();
		showFrame();
	}

	public void makeFrame() {
		top.add(r);
		top.add(rInput);
		top.add(h);
		top.add(hInput);
		top.add(v);
		top.add(vInput);
		bottom.add(calcBtn);
		bottom.add(clearBtn);

		add(top, BorderLayout.CENTER);
		add(bottom, BorderLayout.SOUTH);

		vInput.setEditable(false);

		calcBtn.addActionListener(this);
		hInput.addActionListener(this);
		clearBtn.addActionListener(this);
	}

	public void showFrame() {
		setSize(350, 160);
		setLocationRelativeTo(null);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
	}

	public void actionPerformed(ActionEvent ae) {
		Object source =  ae.getSource();
		if (source == clearBtn) {
			rInput.setText("");
			hInput.setText("");
			vInput.setText("");
		} else {
			double rad = Double.parseDouble(rInput.getText());
			double he = Double.parseDouble(hInput.getText());
			vInput.setText(String.format("%.3f", Math.PI * rad * rad * he / 3));
		}

	}

	public static void main(String[] args) {
		new GUIEx3();
	}
}