import javax.swing.*;
import javax.swing.border.EmptyBorder;
import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;

public class EditRecord extends JPanel implements ActionListener {

    // String identifiers for main deck cards associated with this function
    private final static String MAIN = "Main Menu Panel";
    // String identifiers for cards of this panel's card deck
    private final static String EDITCARD1 = "EDIT1 Input Panel";
    private final static String EDITCARD2 = "EDIT2 Record Info Panel";
    // Cards for this function
    private JPanel panelEditCard1 = new JPanel(new BorderLayout());
    private JPanel panelEditCard2 = new JPanel(new BorderLayout());

    // -------------------- EDITCARD1 PANEL COMPONENTS -------------------- //
    private JPanel panelHeader = new JPanel(new FlowLayout(FlowLayout.LEFT, 20, 10));
    private JPanel panelTitle = new JPanel(new GridLayout(2, 1));
    private JPanel panelInput = new JPanel(new GridLayout(2, 1));
    private JPanel panelButtons1 = new JPanel(new FlowLayout(FlowLayout.CENTER, 52, 15));
    private JPanel panelMargin1 = new JPanel();
    private JPanel panelMargin2 = new JPanel();
    private JLabel lblTitle = new JLabel("EDIT RECORD", JLabel.CENTER);
    private JLabel lblDescription = new JLabel("Enter the Plate Number of the car record to edit.", JLabel.CENTER);
    private JLabel lblPlateNumber1 = new JLabel("Plate Number");
    private JTextField txtPlateNumber1 = new JTextField(10);
    private JButton btnBack = new JButton("< BACK");
    private JButton btnClear = new JButton("CLEAR");
    private JButton btnContinue = new JButton("CONTINUE");
    private Dimension sizeBackBtn = new Dimension(80, 35);
    // -------------------- EDITCARD2 PANEL COMPONENTS -------------------- //
    private JPanel panelFound = new JPanel(new FlowLayout(FlowLayout.LEFT, 40, 20));
    private JPanel panelContent = new JPanel(new GridLayout(1, 2));
    private JPanel panelLeftCol = new JPanel(new GridLayout(4, 1));
    private JPanel panelRightCol = new JPanel(new GridLayout(4, 1));
    private JPanel panelPlateNumber = new JPanel(new GridLayout(2, 1));
    private JPanel panelBrand = new JPanel(new GridLayout(2, 1));
    private JPanel panelModel = new JPanel(new GridLayout(2, 1));
    private JPanel panelType = new JPanel(new GridLayout(2, 1));
    private JPanel panelColour = new JPanel(new GridLayout(2, 1));
    private JPanel panelStatus = new JPanel(new GridLayout(2, 1));
    private JPanel panelPrice = new JPanel(new GridLayout(2, 1));
    private JPanel editPlateNumber = new JPanel(new FlowLayout(FlowLayout.LEFT, 0, 0));
    private JPanel editBrand = new JPanel(new FlowLayout(FlowLayout.LEFT, 0, 0));
    private JPanel editModel = new JPanel(new FlowLayout(FlowLayout.LEFT, 0, 0));
    private JPanel editType = new JPanel(new FlowLayout(FlowLayout.LEFT, 0, 0));
    private JPanel editColour = new JPanel(new FlowLayout(FlowLayout.LEFT, 0, 0));
    private JPanel editStatus = new JPanel(new FlowLayout(FlowLayout.LEFT, 0, 0));
    private JPanel editPrice = new JPanel(new FlowLayout(FlowLayout.LEFT, 0, 0));
    private JPanel panelButtons2 = new JPanel(new FlowLayout(FlowLayout.RIGHT, 55, 20));
    private JLabel lblFound = new JLabel("MATCHING CAR RECORD FOUND");
    private JLabel lblPlateNumber2 = new JLabel("Plate Number");
    private JLabel lblBrand = new JLabel("Brand");
    private JLabel lblModel = new JLabel("Model");
    private JLabel lblType = new JLabel("Type");
    private JLabel lblColour = new JLabel("Colour");
    private JLabel lblStatus = new JLabel("Status");
    private JLabel lblPrice = new JLabel("Price");
    private final static int sizeTextField = 13;
    private JTextField txtPlateNumber2 = new JTextField(sizeTextField);
    private JTextField txtBrand = new JTextField(sizeTextField);
    private JTextField txtModel = new JTextField(sizeTextField);
    private JTextField txtType = new JTextField(sizeTextField);
    private JTextField txtColour = new JTextField(sizeTextField);
    private JTextField txtStatus = new JTextField(sizeTextField);
    private JTextField txtPrice = new JTextField(sizeTextField);
    private JButton btnPlateNumber = new JButton("EDIT");
    private JButton btnBrand = new JButton("EDIT");
    private JButton btnModel = new JButton("EDIT");
    private JButton btnType = new JButton("EDIT");
    private JButton btnColour = new JButton("EDIT");
    private JButton btnStatus = new JButton("EDIT");
    private JButton btnPrice = new JButton("EDIT");
    private JButton btnDone = new JButton("DONE");

    // Function variables
    private ArrayList<Car> carArrayList;
    private int recordIndex;
    private final String INPUT_CANCEL = "THE PROCESS WAS CANCELLED";

    public EditRecord(ArrayList<Car> cars) {
        carArrayList = cars;
        makePanel();
    }

    public void makePanel() {
        setLayout(new CardLayout());

        // -------------------- CARD 1 (EDIT1 INPUT PANEL) -------------------- //
        // Make header bar (panelHeader)
        btnBack.setPreferredSize(sizeBackBtn);
        btnBack.addActionListener(this);
        lblTitle.setFont(new Font("Helvetica", Font.BOLD, 16));
        lblTitle.setForeground(Color.WHITE);
        lblDescription.setForeground(Color.WHITE);
        lblDescription.setFont(new Font("Helvetica", Font.PLAIN, 11));
        panelTitle.setBackground(Color.DARK_GRAY);
        panelTitle.add(lblTitle);
        panelTitle.add(lblDescription);
        panelHeader.setBackground(Color.DARK_GRAY);
        panelHeader.setPreferredSize(new Dimension(0, 60));
        panelHeader.add(btnBack);
        panelHeader.add(panelTitle);

        // Make margin panels (panelMargin#)
        panelMargin1.setPreferredSize(new Dimension(120, 0));
        panelMargin2.setPreferredSize(new Dimension(120, 0));

        // Make input panel (panelInput)
        txtPlateNumber1.addActionListener(this);
        panelInput.add(lblPlateNumber1);
        panelInput.add(txtPlateNumber1);

        // Make buttons panel (panelButtons)
        btnClear.setPreferredSize(btnContinue.getPreferredSize());
        btnClear.addActionListener(this);
        btnContinue.addActionListener(this);
        panelButtons1.setPreferredSize(new Dimension(0, 70));
        panelButtons1.add(btnClear);
        panelButtons1.add(btnContinue);

        // Add sub-panels into EDIT1 card
        panelEditCard1.add(panelHeader, BorderLayout.NORTH);
        panelEditCard1.add(panelMargin1, BorderLayout.WEST);
        panelEditCard1.add(panelInput, BorderLayout.CENTER);
        panelEditCard1.add(panelMargin2, BorderLayout.EAST);
        panelEditCard1.add(panelButtons1, BorderLayout.SOUTH);

        // -------------------- CARD 2 (EDIT2 RECORD INFO PANEL) -------------------- //
        // Make title panel (panelFound)
        lblFound.setFont(new Font("Helvetica", Font.BOLD, 16));
        panelFound.setPreferredSize(Main.HEADER_SIZE);
        panelFound.add(lblFound);

        // Make left column panel (panelLeftCol)
        txtPlateNumber2.setEditable(false);
        txtPlateNumber2.setMargin(new Insets(3, 0, 3, 0));
        btnPlateNumber.addActionListener(this);
        editPlateNumber.add(txtPlateNumber2);
        editPlateNumber.add(btnPlateNumber);
        panelPlateNumber.add(lblPlateNumber2);
        panelPlateNumber.add(editPlateNumber);

        txtBrand.setEditable(false);
        txtBrand.setMargin(new Insets(3, 0, 3, 0));
        btnBrand.addActionListener(this);
        editBrand.add(txtBrand);
        editBrand.add(btnBrand);
        panelBrand.add(lblBrand);
        panelBrand.add(editBrand);

        txtModel.setEditable(false);
        txtModel.setMargin(new Insets(3, 0, 3, 0));
        btnModel.addActionListener(this);
        editModel.add(txtModel);
        editModel.add(btnModel);
        panelModel.add(lblModel);
        panelModel.add(editModel);

        txtType.setEditable(false);
        txtType.setMargin(new Insets(3, 0, 3, 0));
        btnType.addActionListener(this);
        editType.add(txtType);
        editType.add(btnType);
        panelType.add(lblType);
        panelType.add(editType);

        panelLeftCol.add(panelPlateNumber);
        panelLeftCol.add(panelBrand);
        panelLeftCol.add(panelModel);
        panelLeftCol.add(panelType);
        panelLeftCol.setBorder(new EmptyBorder(0, 40, 0, 45));

        // Make right column panel (panelRightCol)
        txtColour.setEditable(false);
        txtColour.setMargin(new Insets(3, 0, 3, 0));
        btnColour.addActionListener(this);
        editColour.add(txtColour);
        editColour.add(btnColour);
        panelColour.add(lblColour);
        panelColour.add(editColour);

        txtStatus.setEditable(false);
        txtStatus.setMargin(new Insets(3, 0, 3, 0));
        btnStatus.addActionListener(this);
        editStatus.add(txtStatus);
        editStatus.add(btnStatus);
        panelStatus.add(lblStatus);
        panelStatus.add(editStatus);

        txtPrice.setEditable(false);
        txtPrice.setMargin(new Insets(3, 0, 3, 0));
        btnPrice.addActionListener(this);
        editPrice.add(txtPrice);
        editPrice.add(btnPrice);
        panelPrice.add(lblPrice);
        panelPrice.add(editPrice);

        panelRightCol.add(panelColour);
        panelRightCol.add(panelStatus);
        panelRightCol.add(panelPrice);
        panelRightCol.setBorder(new EmptyBorder(0, 40, 0, 45));

        // Make content panel (panelContent)
        panelContent.add(panelLeftCol);
        panelContent.add(panelRightCol);

        // Make buttons2 panel (panelButtons2)
        btnDone.addActionListener(this);
        panelButtons2.setPreferredSize(Main.HEADER_SIZE);
        panelButtons2.add(btnDone);

        // Add sub-panels into DEL2 card
        panelEditCard2.add(panelFound, BorderLayout.NORTH);
        panelEditCard2.add(panelContent, BorderLayout.CENTER);
        panelEditCard2.add(panelButtons2, BorderLayout.SOUTH);

        // ----- Add both cards into card deck ----- //
        add(panelEditCard1, EDITCARD1);
        add(panelEditCard2, EDITCARD2);
    }

    @Override
    public void actionPerformed(ActionEvent event) {
        Object source = event.getSource();
        CardLayout mainCardLayout = (CardLayout) Main.panelContainer.getLayout();
        CardLayout editCardLayout = (CardLayout) this.getLayout();

        Window window = (Window) this.getTopLevelAncestor(); // sauce: https://stackoverflow.com/questions/25346547/display-different-panel-size-in-cardlayout

        // Event Handling for CARD 1 (EDIT1 INPUT PANEL)
        if (source == btnBack) {
            // return to main menu
            txtPlateNumber1.setText("");
            mainCardLayout.show(Main.panelContainer, MAIN);
            window.setSize(Main.WIDTH, Main.HEIGHT);
        } else if (source == btnClear) {
            // clear plate number input
            txtPlateNumber1.setText("");
        } else if (source == txtPlateNumber1 || source == btnContinue) {
            String plateNumber = txtPlateNumber1.getText();
            int matchedIndex = 0;
            boolean isFound = false;

            // Check if there is a record with entered plateNumber
            for (int i = 0;i < carArrayList.size(); i++) {
                if (carArrayList.get(i).getPlateNumber().compareToIgnoreCase(plateNumber) == 0) {
                    matchedIndex = i;
                    isFound = true;
                    break;
                }
            }

            // Display error message if not found; else proceed to edit record screen
            if (!isFound) {
                JOptionPane.showMessageDialog(null, "No car record with the entered Plate Number was found.",
                        "Invalid Plate Number", JOptionPane.ERROR_MESSAGE);
            } else {
                // show edit record screen
                editCardLayout.show(this, EDITCARD2);
                window.setSize(600, 430);

                // populate the disabled text fields
                txtPlateNumber2.setText(carArrayList.get(matchedIndex).getPlateNumber());
                txtBrand.setText(carArrayList.get(matchedIndex).getBrand());
                txtModel.setText(carArrayList.get(matchedIndex).getModel());
                txtType.setText(carArrayList.get(matchedIndex).getType());
                txtColour.setText(carArrayList.get(matchedIndex).getColour());
                txtStatus.setText(carArrayList.get(matchedIndex).getStatus());
                txtPrice.setText(String.format("RM %.2f", carArrayList.get(matchedIndex).getPrice()));

                // store the matched index for use in EDIT2 screen
                recordIndex = matchedIndex;
            }
        }

        // Event Handling for CARD 2 (EDIT2 PANEL)
        String input;
        if (source == btnPlateNumber) {
            // Get input for Plate Number
            input = getInput("Plate Number", 12);

            // Update Plate Number data if user clicked "OK"
            if (!input.equals(INPUT_CANCEL)) {
                boolean isUnique = true;

                // Check for duplicate
                for (int i = 0; i < carArrayList.size(); i++) {
                    if (carArrayList.get(i).getPlateNumber().compareToIgnoreCase(input) == 0) {
                        isUnique = false;
                        break;
                    }
                }

                // Display error message if duplicate plate number exists; else update plate number
                if (!isUnique) {
                    JOptionPane.showMessageDialog(null, "The Plate Number you entered already exists in the system.\n" +
                            "                              Please try again.",
                            "Duplicate Plate Number detected", JOptionPane.ERROR_MESSAGE);
                } else {
                    carArrayList.get(recordIndex).setPlateNumber(input);
                    txtPlateNumber2.setText(input);
                }
            }
        } else if (source == btnBrand) {
            // Get input for Brand
            input = getInput("Brand", 16);

            // Update Brand data if user clicked "OK"
            if (!input.equals(INPUT_CANCEL)) {
                carArrayList.get(recordIndex).setBrand(input);
                txtBrand.setText(input);
            }
        } else if (source == btnModel) {
            // Get input for Model
            input = getInput("Model", 16);

            // Update Model data if user clicked "OK"
            if (!input.equals(INPUT_CANCEL)) {
                carArrayList.get(recordIndex).setModel(input);
                txtModel.setText(input);
            }
        } else if (source == btnType) {
            // Get input for Type
            input = getInput("Type", 16);

            // Update Type data if user clicked "OK"
            if (!input.equals(INPUT_CANCEL)) {
                carArrayList.get(recordIndex).setType(input);
                txtType.setText(input);
            }
        } else if (source == btnColour) {
            // Get input for Colour
            input = getInput("Colour", 16);

            // Update Colour data if user clicked "OK"
            if (!input.equals(INPUT_CANCEL)) {
                carArrayList.get(recordIndex).setColour(input);
                txtColour.setText(input);
            }
        } else if (source == btnStatus) {
            // Get input for Status
            input = getInput("Status", 16);

            // Update Status data if user clicked "OK"
            if (!input.equals(INPUT_CANCEL)) {
                carArrayList.get(recordIndex).setStatus(input);
                txtStatus.setText(input);
            }
        } else if (source == btnPrice) {
            boolean isNumeric = false;
            double price = 0;

            // Get input for Price
            do {
                input = getInput("Price", 9);

                if (input.equals(INPUT_CANCEL))
                    break;

                try {
                    price = Double.parseDouble(input);
                    isNumeric = true;
                } catch (NumberFormatException e) {
                    JOptionPane.showMessageDialog(null, "Please enter a numeric value for Price.",
                            "Invalid input", JOptionPane.ERROR_MESSAGE);
                    isNumeric = false;
                }
            } while (!isNumeric);

            // Update Price data if user clicked "OK"
            if (!input.equals(INPUT_CANCEL)) {
                carArrayList.get(recordIndex).setPrice(price);
                txtPrice.setText(String.format("RM %.2f", price));
            }

        } else if (source == btnDone) {
            txtPlateNumber1.setText("");
            editCardLayout.show(this, EDITCARD1);
            mainCardLayout.show(Main.panelContainer, MAIN);
            window.setSize(Main.WIDTH, Main.HEIGHT);
        }

    }

    // Helper method for displaying input dialog and handling input to edit record
    public String getInput(String attribute, int limit) {
        boolean hasError = false;
        String response;

        do {
            response = JOptionPane.showInputDialog(null, "Enter new " + attribute,
                    "Edit " + attribute, JOptionPane.QUESTION_MESSAGE);
            if (response == null) {
                return INPUT_CANCEL;
            } else if (response.isBlank()) {
                JOptionPane.showMessageDialog(null, "Input cannot be empty.",
                        "Empty input detected", JOptionPane.OK_OPTION);
                hasError = true;
            } else if (response.trim().length() > limit) {
                JOptionPane.showMessageDialog(null, attribute + " input cannot be more than " + limit + " characters.",
                        "Input limit exceeded", JOptionPane.OK_OPTION);
                hasError = true;
            } else {
                hasError = false;
            }
        } while (hasError);

        return response.trim();
    }

}