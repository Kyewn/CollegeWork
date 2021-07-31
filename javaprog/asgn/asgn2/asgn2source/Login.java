import javax.swing.*;
import javax.swing.border.EmptyBorder;
import java.awt.*;
import java.awt.event.*;
import java.util.Arrays;

public class Login extends JPanel implements ActionListener {

    // String identifiers for main deck cards associated with this function
    private final static String MAIN = "Main Menu Panel";

    // -------------------- "LOGIN" PANEL COMPONENTS -------------------- //
    private JPanel panelSystemTitle = new JPanel(new GridBagLayout());
    private JPanel panelInput = new JPanel(new GridLayout(3, 1));
    private JPanel panelUsername = new JPanel(new FlowLayout(FlowLayout.CENTER));
    private JPanel panelPassword = new JPanel(new FlowLayout(FlowLayout.CENTER));
    private JPanel panelOptions = new JPanel(new BorderLayout());
    private JPanel panelButtons = new JPanel(new FlowLayout(FlowLayout.CENTER));
    private JLabel lblSystemTitle = new JLabel("Car Record Management System", JLabel.CENTER);
    private JLabel lblUsername = new JLabel("USERNAME");
    private JLabel lblPassword = new JLabel("PASSWORD");
    private JTextField txtUsername = new JTextField(22);
    private JPasswordField passwordField = new JPasswordField(22);
    private JCheckBox showPassword = new JCheckBox("Show password");
    private JButton btnClear = new JButton("CLEAR");
    private JButton btnLogin = new JButton("LOGIN");

    // Function variables
    private static final String USERNAME = "HelloWorld";
    private static final char[] PASSWORD = {'1', '2', '3'};

    public Login() {
        makePanel();
    }

    public void makePanel() {
        setLayout(new BorderLayout());

        // Make system title (lblSystemTitle)
        lblSystemTitle.setFont(new Font("Helvetica", Font.BOLD, 20));
        panelSystemTitle.setPreferredSize(new Dimension(0, 70));
        panelSystemTitle.add(lblSystemTitle);

        // Make input panel (panelInput)
        txtUsername.setPreferredSize(new Dimension(0, 30));
        txtUsername.addActionListener(this);
        panelUsername.add(lblUsername);
        panelUsername.add(txtUsername);
        passwordField.setPreferredSize(new Dimension(0, 30));
        passwordField.addActionListener(this);
        panelPassword.add(lblPassword);
        panelPassword.add(passwordField);
        showPassword.setFont(new Font("Sans-serif", Font.PLAIN, 11));
        showPassword.setHorizontalAlignment(SwingConstants.CENTER);
        showPassword.setBorder(new EmptyBorder(0, 0, 0, 54));
        showPassword.addActionListener(this);
        panelOptions.add(showPassword, BorderLayout.NORTH);
        panelInput.add(panelUsername);
        panelInput.add(panelPassword);
        panelInput.add(panelOptions);

        // Make button panel (panelButtons)
        btnLogin.addActionListener(this);
        btnClear.addActionListener(this);
        panelButtons.setPreferredSize(new Dimension(0, 70));
        panelButtons.add(btnClear);
        panelButtons.add(btnLogin);

        // Add all sub-panels into parent panel
        add(panelSystemTitle, BorderLayout.NORTH);
        add(panelInput, BorderLayout.CENTER);
        add(panelButtons, BorderLayout.SOUTH);
    }

    @Override
    public void actionPerformed(ActionEvent event) {
        Object source = event.getSource();
        CardLayout mainCardLayout = (CardLayout) Main.panelContainer.getLayout();
        Window window = (Window) this.getTopLevelAncestor();

        String username = txtUsername.getText();
        char[] password = passwordField.getPassword();

        if (source == txtUsername || source == passwordField || source == btnLogin) {
            // Move user to the main menu if username and password are correct; else show error messages
            if (username.equals(USERNAME) && Arrays.equals(password, PASSWORD)) {
                JOptionPane.showMessageDialog(null, "You have successfully logged in.",
                        "Login successful", JOptionPane.INFORMATION_MESSAGE);
                mainCardLayout.show(Main.panelContainer, MAIN);
                window.setSize(Main.WIDTH, Main.HEIGHT);
            } else if (username.trim().isEmpty() || password.length == 0) {
                JOptionPane.showMessageDialog(null, "Please ensure that there are no empty input fields.",
                        "Empty input field detected", JOptionPane.ERROR_MESSAGE);
            } else if (!username.equals(USERNAME) || !Arrays.equals(password, PASSWORD)) {
                JOptionPane.showMessageDialog(null, "Invalid username or password.",
                        "Login Failed", JOptionPane.ERROR_MESSAGE);
            }
        } else if (source == showPassword) {
            // Show the password characters if "Show Password" is checked
            if (showPassword.isSelected())
                passwordField.setEchoChar((char) 0); // reveals characters
            else
                passwordField.setEchoChar('\u2022'); // \u2022: unicode char "BULLET"
        } else if (source == btnClear) {
            // Clear all input fields
            txtUsername.setText("");
            passwordField.setText("");
        }
    }

}