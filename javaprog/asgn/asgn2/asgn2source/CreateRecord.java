import javax.swing.*;
import javax.swing.border.EmptyBorder;
import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;

public class CreateRecord extends JPanel implements ActionListener, KeyListener {

    // String identifiers for main deck cards associated with this function
    private final static String MAIN = "Main Menu Panel";

    // -------------------- "CREATE RECORD" PANEL COMPONENTS -------------------- //
    private JPanel panelHeader = new JPanel(new FlowLayout(FlowLayout.LEFT, 20, 10));
    private JPanel panelTitle = new JPanel(new GridLayout(2, 1));
    private JPanel panelInput = new JPanel(new GridLayout(4, 2));
    private JPanel panelPlateNumber = new JPanel(new GridLayout(3, 1));
    private JPanel panelBrand = new JPanel(new GridLayout(3, 1));
    private JPanel panelModel = new JPanel(new GridLayout(3, 1));
    private JPanel panelType = new JPanel(new GridLayout(3, 1));
    private JPanel panelColour = new JPanel(new GridLayout(3, 1));
    private JPanel panelStatus = new JPanel(new GridLayout(3, 1));
    private JPanel panelPrice = new JPanel(new GridLayout(3, 1));
    private JPanel panelButtons = new JPanel(new FlowLayout(FlowLayout.CENTER, 170, 0));
    private JLabel lblTitle = new JLabel("CREATE RECORD", JLabel.CENTER);
    private JLabel lblDescription = new JLabel("Enter the details of the new car record.", JLabel.CENTER);
    private JLabel lblPlateNumber = new JLabel("Plate Number");
    private JLabel lblBrand = new JLabel("Brand");
    private JLabel lblModel = new JLabel("Model");
    private JLabel lblType = new JLabel("Type");
    private JLabel lblColour = new JLabel("Colour");
    private JLabel lblStatus = new JLabel("Status");
    private JLabel lblPrice = new JLabel("Price");
    private JLabel lblErrorPlateNumber = new JLabel();
    private JLabel lblErrorBrand = new JLabel();
    private JLabel lblErrorModel = new JLabel();
    private JLabel lblErrorType = new JLabel();
    private JLabel lblErrorColour = new JLabel();
    private JLabel lblErrorStatus = new JLabel();
    private JLabel lblErrorPrice = new JLabel();
    private JTextField txtPlateNumber = new JTextField(10);
    private JTextField txtBrand = new JTextField(10);
    private JTextField txtModel = new JTextField(10);
    private JTextField txtType = new JTextField(10);
    private JTextField txtColour = new JTextField(10);
    private JTextField txtStatus = new JTextField(10);
    private JTextField txtPrice = new JTextField(10);
    private JButton btnBack = new JButton("< BACK");
    private JButton btnClear = new JButton("CLEAR");
    private JButton btnCreate = new JButton("CREATE");
    private Font fontError = new Font("Sans-serif", Font.PLAIN, 11);
    private Dimension sizeBackBtn = new Dimension(80, 35);
    private Dimension sizeActionBtn = new Dimension(130, 40);

    // Function variables
    ArrayList<Car> carArrayList;

    public CreateRecord(ArrayList<Car> cars) {
        carArrayList = cars;
        makePanel();
    }

    public void makePanel() {
        setLayout(new BorderLayout());

        // Make header panel (panelHeader)
        btnBack.setPreferredSize(sizeBackBtn);
        btnBack.addActionListener(this);
        lblTitle.setFont(new Font("Helvetica", Font.BOLD, 16));
        lblTitle.setForeground(Color.WHITE);
        lblDescription.setFont(new Font("Helvetica", Font.PLAIN, 11));
        lblDescription.setForeground(Color.WHITE);
        panelTitle.setBorder(new EmptyBorder(0, Main.WIDTH / 6, 0, 0));
        panelTitle.setBackground(Color.DARK_GRAY);
        panelTitle.add(lblTitle);
        panelTitle.add(lblDescription);
        panelHeader.setBackground(Color.DARK_GRAY);
        panelHeader.add(btnBack);
        panelHeader.add(panelTitle);

        // Make input panel (panelInput)
        GridLayout inputGridLayout = (GridLayout) panelInput.getLayout();
        inputGridLayout.setHgap(50);

        lblErrorPlateNumber.setFont(fontError);
        lblErrorPlateNumber.setForeground(Color.RED);
        txtPlateNumber.addKeyListener(this);
        panelPlateNumber.add(lblPlateNumber);
        panelPlateNumber.add(txtPlateNumber);
        panelPlateNumber.add(lblErrorPlateNumber);

        lblErrorBrand.setFont(fontError);
        lblErrorBrand.setForeground(Color.RED);
        txtBrand.addKeyListener(this);
        panelBrand.add(lblBrand);
        panelBrand.add(txtBrand);
        panelBrand.add(lblErrorBrand);

        lblErrorModel.setFont(fontError);
        lblErrorModel.setForeground(Color.RED);
        txtModel.addKeyListener(this);
        panelModel.add(lblModel);
        panelModel.add(txtModel);
        panelModel.add(lblErrorModel);

        lblErrorType.setFont(fontError);
        lblErrorType.setForeground(Color.RED);
        txtType.addKeyListener(this);
        panelType.add(lblType);
        panelType.add(txtType);
        panelType.add(lblErrorType);

        lblErrorColour.setFont(fontError);
        lblErrorColour.setForeground(Color.RED);
        txtColour.addKeyListener(this);
        panelColour.add(lblColour);
        panelColour.add(txtColour);
        panelColour.add(lblErrorColour);

        lblErrorStatus.setFont(fontError);
        lblErrorStatus.setForeground(Color.RED);
        txtStatus.addKeyListener(this);
        panelStatus.add(lblStatus);
        panelStatus.add(txtStatus);
        panelStatus.add(lblErrorStatus);

        lblErrorPrice.setFont(fontError);
        lblErrorPrice.setForeground(Color.RED);
        txtPrice.addKeyListener(this);
        panelPrice.add(lblPrice);
        panelPrice.add(txtPrice);
        panelPrice.add(lblErrorPrice);

        panelInput.add(panelPlateNumber);
        panelInput.add(panelBrand);
        panelInput.add(panelModel);
        panelInput.add(panelType);
        panelInput.add(panelColour);
        panelInput.add(panelStatus);
        panelInput.add(panelPrice);
        panelInput.setBorder(new EmptyBorder(0, Main.WIDTH / 6, 0, Main.WIDTH / 6));

        // Make buttons panel (panelButtons)
        btnClear.setPreferredSize(sizeActionBtn);
        btnCreate.setPreferredSize(sizeActionBtn);
        btnClear.addActionListener(this);
        btnCreate.addActionListener(this);
        panelButtons.setPreferredSize(new Dimension(0, 100));
        panelButtons.add(btnClear);
        panelButtons.add(btnCreate);

        // Add all sub-panels into parent panel (this)
        add(panelHeader, BorderLayout.NORTH);
        add(panelInput, BorderLayout.CENTER);
        add(panelButtons, BorderLayout.SOUTH);
    }

    @Override
    public void actionPerformed(ActionEvent actionEvent) {
        Object source = actionEvent.getSource();
        CardLayout mainCardLayout = (CardLayout) Main.panelContainer.getLayout();
        Window window = (Window) this.getTopLevelAncestor();

        // Event Handling
        if (source == btnBack) {
            // Prompt user to confirm if they want to return to menu
            int response = JOptionPane.showConfirmDialog(null, "Are you sure you want to return to the menu?\n" +
                    "All data that you have entered will be discarded.", "Back To Menu", JOptionPane.YES_NO_OPTION);

            // Return to menu if response is YES; else cancel
            if (response == JOptionPane.YES_OPTION) {
                // Clear all input fields
                clearInputFields();

                // Return to menu
                mainCardLayout.show(Main.panelContainer, MAIN);
                window.setSize(Main.WIDTH, Main.HEIGHT);
            }
        } else if (source == btnClear) {
            // Clear all input fields
            clearInputFields();
        } else if (source == btnCreate) {
            boolean hasError = false;
            boolean isNumeric = false;

            trimAllInput();
            // Get input from all input fields
            String plateNumber = txtPlateNumber.getText();
            String brand = txtBrand.getText();
            String model = txtModel.getText();
            String type = txtType.getText();
            String colour = txtColour.getText();
            String status = txtStatus.getText();
            String strPrice = txtPrice.getText();
            double dblPrice = 0;

            // - - - - - Validate all input - - - - - //
            // Additional validation for plate number
            if (!isValid(plateNumber, 12, lblErrorPlateNumber)) {
                hasError = true;
            } else {
                // Check for duplicate plate number
                for (int i = 0; i < carArrayList.size(); i++) {
                    if (carArrayList.get(i).getPlateNumber().compareToIgnoreCase(plateNumber) == 0) {
                        lblErrorPlateNumber.setText("This plate number already exists.");
                        hasError = true;
                    }
                }
            }
            // This here is not redundancy, it's necessary because of the way isValid is designed
            if (!isValid(brand, 16, lblErrorBrand))
                hasError = true;
            if (!isValid(model, 16, lblErrorModel))
                hasError = true;
            if (!isValid(type, 16, lblErrorType))
                hasError = true;
            if (!isValid(colour, 16, lblErrorColour))
                hasError = true;
            if (!isValid(status, 16, lblErrorStatus))
                hasError = true;
            // Additional validation for price input
            if (!isValid(strPrice, 9, lblErrorPrice)) {
                hasError = true;
            } else {
                // Attempt to parse string input into double
                try {
                    dblPrice = Double.parseDouble(strPrice);
                    isNumeric = true;
                } catch (NumberFormatException e) {
                    isNumeric = false;
                    lblErrorPrice.setText("Must be numeric value only.");
                }
            }

            // If all input pass their respective checks, add new record; else notify user of errors
            if (!hasError && isNumeric) {
                // Prompt user for confirmation
                int response = JOptionPane.showConfirmDialog(null, "Confirm New Car Record",
                        "Create Record", JOptionPane.YES_NO_OPTION);

                // Add new car record if user clicks "YES"
                if (response == JOptionPane.YES_NO_OPTION) {
                    Car newCarObj = new Car(plateNumber, brand, model, type, colour, status, dblPrice);
                    carArrayList.add(newCarObj);

                    // Notify user
                    JOptionPane.showMessageDialog(null, "New car record added successfully!",
                            "Record Creation Successful", JOptionPane.INFORMATION_MESSAGE);

                    // Return to menu
                    clearInputFields();
                    mainCardLayout.show(Main.panelContainer, MAIN);
                    window.setSize(Main.WIDTH, Main.HEIGHT);
                }
            } else {
                JOptionPane.showMessageDialog(null, "There are invalid inputs, please check all the data.",
                        "Invalid input detected", JOptionPane.ERROR_MESSAGE);
            }

        }
    }

    @Override
    public void keyPressed(KeyEvent keyEvent) { /* not used */ }

    @Override
    public void keyTyped(KeyEvent keyEvent) { /* not used */ }

    @Override
    public void keyReleased(KeyEvent keyEvent) { // For basic real-time error-checking
        Object source = keyEvent.getSource();

        // Return values of isValid will not be used here
        if (source == txtPlateNumber)
            isValid(txtPlateNumber.getText().trim(), 12, lblErrorPlateNumber);
        else if (source == txtBrand)
            isValid(txtBrand.getText().trim(), 16, lblErrorBrand);
        else if (source == txtModel)
            isValid(txtModel.getText().trim(), 16, lblErrorModel);
        else if (source == txtType)
            isValid(txtType.getText().trim(), 16, lblErrorType);
        else if (source == txtColour)
            isValid(txtColour.getText().trim(), 16, lblErrorColour);
        else if (source == txtStatus)
            isValid(txtStatus.getText().trim(), 16, lblErrorStatus);
        else if (source == txtPrice)
            isValid(txtPrice.getText().trim(), 9, lblErrorPrice);
    }

    // Helper method for validating input
    public boolean isValid(String attribute, int limit, JLabel lblError) {
        // Validate input for each condition and set appropriate error messages accordingly
        if (attribute.isBlank()) {
            lblError.setText("Cannot be empty.");
            return false;
        } else if (attribute.length() > limit) {
            lblError.setText("Cannot be more than " + limit + " characters.");
            return false;
        } else {
            lblError.setText("");
            // Return true if input passes all checks
            return true;
        }
    }

    // Helper method for trimming input
    public void trimAllInput() {
        txtPlateNumber.setText(txtPlateNumber.getText().trim());
        txtBrand.setText(txtBrand.getText().trim());
        txtModel.setText(txtModel.getText().trim());
        txtType.setText(txtType.getText().trim());
        txtColour.setText(txtColour.getText().trim());
        txtStatus.setText(txtStatus.getText().trim());
        txtPrice.setText(txtPrice.getText().trim());
    }

    // Helper method for clearing all input fields and their error messages
    public void clearInputFields() {
        txtPlateNumber.setText("");
        txtBrand.setText("");
        txtModel.setText("");
        txtType.setText("");
        txtColour.setText("");
        txtStatus.setText("");
        txtPrice.setText("");
        lblErrorPlateNumber.setText("");
        lblErrorBrand.setText("");
        lblErrorModel.setText("");
        lblErrorType.setText("");
        lblErrorColour.setText("");
        lblErrorStatus.setText("");
        lblErrorPrice.setText("");
    }

}
