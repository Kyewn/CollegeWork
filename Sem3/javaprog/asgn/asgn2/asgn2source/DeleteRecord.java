import javax.swing.*;
import javax.swing.border.EmptyBorder;
import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;

public class DeleteRecord extends JPanel implements ActionListener {

    // String identifiers for main deck cards associated with this function
    private final static String MAIN = "Main Menu Panel";
    // String identifiers for cards of this panel's card deck
    private final static String DELCARD1 = "DEL1 Input Panel";
    private final static String DELCARD2 = "DEL2 Confirmation Panel";
    // Cards for this function
    private JPanel panelDelCard1 = new JPanel(new BorderLayout());
    private JPanel panelDelCard2 = new JPanel(new BorderLayout());

    // -------------------- DELCARD1 PANEL COMPONENTS -------------------- //
    private JPanel panelHeader = new JPanel(new FlowLayout(FlowLayout.LEFT, 20, 10));
    private JPanel panelTitle = new JPanel(new GridLayout(2, 1));
    private JPanel panelInput = new JPanel(new GridLayout(2, 1));
    private JPanel panelButtons1 = new JPanel(new FlowLayout(FlowLayout.CENTER, 52, 15));
    private JPanel panelMargin1 = new JPanel();
    private JPanel panelMargin2 = new JPanel();
    private JLabel lblTitle = new JLabel("DELETE RECORD", JLabel.CENTER);
    private JLabel lblDescription = new JLabel("Enter the Plate Number of the car record to delete.", JLabel.CENTER);
    private JLabel lblPlateNumber1 = new JLabel("Plate Number");
    private JTextField txtPlateNumber1 = new JTextField(10);
    private JButton btnBack = new JButton("< BACK");
    private JButton btnClear = new JButton("CLEAR");
    private JButton btnContinue = new JButton("CONTINUE");
    private Dimension sizeBackBtn = new Dimension(80, 35);
    // -------------------- DELCARD2 PANEL COMPONENTS -------------------- //
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
    private JPanel panelButtons2 = new JPanel(new FlowLayout(FlowLayout.RIGHT, 45, 20));
    private JLabel lblFound = new JLabel("MATCHING CAR RECORD FOUND");
    private JLabel lblPlateNumber2 = new JLabel("Plate Number");
    private JLabel lblBrand = new JLabel("Brand");
    private JLabel lblModel = new JLabel("Model");
    private JLabel lblType = new JLabel("Type");
    private JLabel lblColour = new JLabel("Colour");
    private JLabel lblStatus = new JLabel("Status");
    private JLabel lblPrice = new JLabel("Price");
    private JTextField txtPlateNumber2 = new JTextField(10);
    private JTextField txtBrand = new JTextField(10);
    private JTextField txtModel = new JTextField(10);
    private JTextField txtType = new JTextField(10);
    private JTextField txtColour = new JTextField(10);
    private JTextField txtStatus = new JTextField(10);
    private JTextField txtPrice = new JTextField(10);
    private JButton btnCancel = new JButton("CANCEL");
    private JButton btnDelete = new JButton("DELETE");

    // Function variables
    private ArrayList<Car> carArrayList;
    private int recordIndex;

    public DeleteRecord(ArrayList<Car> cars) {
        carArrayList = cars;
        makePanel();
    }

    public void makePanel() {
        setLayout(new CardLayout());

        // -------------------- CARD 1 (DEL1 INPUT PANEL) -------------------- //
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

        // Add sub-panels into DEL1 card
        panelDelCard1.add(panelHeader, BorderLayout.NORTH);
        panelDelCard1.add(panelMargin1, BorderLayout.WEST);
        panelDelCard1.add(panelInput, BorderLayout.CENTER);
        panelDelCard1.add(panelMargin2, BorderLayout.EAST);
        panelDelCard1.add(panelButtons1, BorderLayout.SOUTH);

        // -------------------- CARD 2 (DEL2 CONFIRMATION PANEL) -------------------- //
        // Make title panel (panelFound)
        lblFound.setFont(new Font("Helvetica", Font.BOLD, 16));
        panelFound.setPreferredSize(Main.HEADER_SIZE);
        panelFound.add(lblFound);

        // Make left column panel (panelLeftCol)
        txtPlateNumber2.setEditable(false);
        txtBrand.setEditable(false);
        txtModel.setEditable(false);
        txtType.setEditable(false);
        panelPlateNumber.add(lblPlateNumber2);
        panelPlateNumber.add(txtPlateNumber2);
        panelBrand.add(lblBrand);
        panelBrand.add(txtBrand);
        panelModel.add(lblModel);
        panelModel.add(txtModel);
        panelType.add(lblType);
        panelType.add(txtType);
        panelLeftCol.add(panelPlateNumber);
        panelLeftCol.add(panelBrand);
        panelLeftCol.add(panelModel);
        panelLeftCol.add(panelType);
        panelLeftCol.setBorder(new EmptyBorder(0, 40, 0, 45));

        // Make right column panel (panelRightCol)
        txtColour.setEditable(false);
        txtStatus.setEditable(false);
        txtPrice.setEditable(false);
        panelColour.add(lblColour);
        panelColour.add(txtColour);
        panelStatus.add(lblStatus);
        panelStatus.add(txtStatus);
        panelPrice.add(lblPrice);
        panelPrice.add(txtPrice);
        panelRightCol.add(panelColour);
        panelRightCol.add(panelStatus);
        panelRightCol.add(panelPrice);
        panelRightCol.setBorder(new EmptyBorder(0, 40, 0, 45));

        // Make content panel (panelContent)
        panelContent.add(panelLeftCol);
        panelContent.add(panelRightCol);

        // Make buttons2 panel (panelButtons2)
        btnCancel.addActionListener(this);
        btnDelete.addActionListener(this);
        panelButtons2.setPreferredSize(Main.HEADER_SIZE);
        panelButtons2.add(btnCancel);
        panelButtons2.add(btnDelete);

        // Add sub-panels into DEL2 card
        panelDelCard2.add(panelFound, BorderLayout.NORTH);
        panelDelCard2.add(panelContent, BorderLayout.CENTER);
        panelDelCard2.add(panelButtons2, BorderLayout.SOUTH);

        // ----- Add both cards into card deck ----- //
        add(panelDelCard1, DELCARD1);
        add(panelDelCard2, DELCARD2);
    }

    @Override
    public void actionPerformed(ActionEvent event) {
        Object source = event.getSource();
        CardLayout mainCardLayout = (CardLayout) Main.panelContainer.getLayout();
        CardLayout delCardLayout = (CardLayout) this.getLayout();

        Window window = (Window) this.getTopLevelAncestor(); // sauce: https://stackoverflow.com/questions/25346547/display-different-panel-size-in-cardlayout

        // Event Handling for CARD 1 (DEL1 INPUT PANEL)
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

            // Display error message if not found; else proceed to delete confirmation screen
            if (!isFound) {
                JOptionPane.showMessageDialog(null, "No car record with the entered Plate Number was found.",
                        "Invalid Plate Number", JOptionPane.ERROR_MESSAGE);
            } else {
                // show delete confirmation screen
                delCardLayout.show(this, DELCARD2);
                window.setSize(600, 400);

                // populate the disabled text fields
                txtPlateNumber2.setText(carArrayList.get(matchedIndex).getPlateNumber());
                txtBrand.setText(carArrayList.get(matchedIndex).getBrand());
                txtModel.setText(carArrayList.get(matchedIndex).getModel());
                txtType.setText(carArrayList.get(matchedIndex).getType());
                txtColour.setText(carArrayList.get(matchedIndex).getColour());
                txtStatus.setText(carArrayList.get(matchedIndex).getStatus());
                txtPrice.setText(String.format("RM %.2f", carArrayList.get(matchedIndex).getPrice()));

                // store the matched index for use in DEL2 screen
                recordIndex = matchedIndex;
            }
        }

        // Event Handling for CARD 2 (DEL2 CONFIRMATION PANEL)
        if (source == btnCancel) {
            txtPlateNumber1.setText("");
            // Return to main menu
            JOptionPane.showMessageDialog(null, "Deletion process cancelled. Returning to menu.",
                    "Deletion Cancelled", JOptionPane.OK_OPTION);
            delCardLayout.show(this, DELCARD1);
            mainCardLayout.show(Main.panelContainer, MAIN);
            window.setSize(Main.WIDTH, Main.HEIGHT);
        } else if (source == btnDelete) {
            // prompt user to confirm deletion
            int response = JOptionPane.showConfirmDialog(null, "        ARE YOU SURE?",
                    "Delete Confirmation", JOptionPane.YES_NO_OPTION);
            // process response
            if (response == JOptionPane.YES_OPTION) {
                JOptionPane.showMessageDialog(null, "Car record with Plate Number [" +
                                carArrayList.get(recordIndex).getPlateNumber() + "] has been deleted.",
                        "Deletion Successful", JOptionPane.INFORMATION_MESSAGE);
                carArrayList.remove(recordIndex);
                delCardLayout.show(this, DELCARD1);
                mainCardLayout.show(Main.panelContainer, MAIN);
                window.setSize(Main.WIDTH, Main.HEIGHT);
            }

            txtPlateNumber1.setText("");
        }
    }

}