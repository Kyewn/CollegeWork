import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
								   //add event listener
public class GUIEx1 extends JFrame implements ActionListener{
	//get content pane so changes will be visible (since if not then adding items will be applied to jframe which is order at the most back)
	private Container ctn = getContentPane();
	//set default layout? maybe can change
	private FlowLayout layout = new FlowLayout();

	//objects to be added to a panel (for now, content pane)
	private JLabel lblFah = new JLabel("Fahrenheit");
	private JLabel lblCel = new JLabel("Celsius");
	private JTextField txtFah = new JTextField(20);
	private JTextField txtCel = new JTextField(20);
	private JButton btnConvert = new JButton("Convert");


	//where we call the function to setup window from the source code (constructor)
	public GUIEx1() {
		super("Convert Fahrenheit to Celsius");
		showFrame();
		makeFrame();
	}

	//show frame - where we setup the window
	public void showFrame(){
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setLocationRelativeTo(null); //supposedly set window to center on open, but doesnt work
		setSize(480,240);
		setVisible(true);
	}

	//make frame - where we add the components to a window
	public void makeFrame() {
		ctn.setLayout(layout); //set layout to flowlayout, default is borderlayout
		//now .add() uses flowlayout instead of borderlayout
		add(lblFah);
		add(txtFah);
		add(btnConvert);
		add(lblCel);
		add(txtCel);
		txtCel.setEditable(false);

		//add ev listeners
		btnConvert.addActionListener(this);
		txtFah.addActionListener(this);
	}

	//event handlers
	public void actionPerformed(ActionEvent ev) {
		try {
			txtCel.setText(String.format("%.3f", (Double.parseDouble(txtFah.getText()) - 32) * 5 / 9));
		} catch (NumberFormatException e) {
			txtCel.setText("Invalid data type");
		}
	}

	public static void main(String[] args) {
		new GUIEx1(); //call the construct
	}
}