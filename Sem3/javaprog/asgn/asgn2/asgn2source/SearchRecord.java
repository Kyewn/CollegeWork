import javax.swing.*;
import javax.swing.border.EmptyBorder;
import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;

public class SearchRecord extends JPanel implements ActionListener {

    // String identifiers for main deck cards associated with this function
    private final static String MAIN = "Main Menu Panel";
    // String identifiers for cards of this panel's card deck
    private final static String SEARCHCARD1 = "SEARCH1 Input Panel";
    private final static String SEARCHCARD2 = "SEARCH2 Record Info Panel";
    // Cards for this function
    private JPanel panelSearchCard1 = new JPanel(new BorderLayout());
    private JPanel panelSearchCard2 = new JPanel(new BorderLayout());

    // -------------------- SEARCHCARD1 PANEL COMPONENTS --------------------//
    private JPanel panelHeader = new JPanel(new FlowLayout(FlowLayout.LEFT, 20, 10));
    private JPanel panelTitle = new JPanel(new GridLayout(2, 1));
    private JPanel panelInput = new JPanel(new GridLayout(2, 1));
    private JPanel panelButtons1 = new JPanel(new FlowLayout(FlowLayout.CENTER, 75, 15));
    private JPanel panelMargin1 = new JPanel();
    private JPanel panelMargin2 = new JPanel();
    private JLabel lblTitle = new JLabel("SEARCH RECORD", JLabel.CENTER);
    private JLabel lblDescription = new JLabel("Enter the Plate Number of the car record to search.", JLabel.CENTER);
    private JLabel lblPlateNumber1 = new JLabel("Plate Number");
    private JTextField txtPlateNumber1 = new JTextField(10);
    private JButton btnBack = new JButton("< BACK");
    private JButton btnClear = new JButton("CLEAR");
    private JButton btnSearch = new JButton("SEARCH");
    private Dimension sizeBackBtn = new Dimension(80, 35);
    // -------------------- SEARCHCARD2 PANEL COMPONENTS --------------------//
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
    private JButton btnSearchAgain = new JButton("SEARCH AGAIN");
    private JButton btnBackToMenu = new JButton("BACK TO MENU");

    // Function variables
    private ArrayList<Car> carArrayList;

    public SearchRecord(ArrayList<Car> cars) {
        carArrayList = cars;
        makePanel();
    }

    public void makePanel() {
        setLayout(new CardLayout());

        // -------------------- CARD 1 (SEARCH1 INPUT PANEL) -------------------- //
        // Make header bar (panelHeader)
        btnBack.setPreferredSize(sizeBackBtn);
        btnBack.addActionListener(this);
        lblTitle.setFont(new Font("Helvetica", Font.BOLD, 16));
        lblTitle.setForeground(Color.WHITE);
        lblDescription.setFont(new Font("Helvetica", Font.PLAIN, 11));
        lblDescription.setForeground(Color.WHITE);
        panelTitle.setBackground(Color.DARK_GRAY);
        panelTitle.add(lblTitle);
        panelTitle.add(lblDescription);
        panelHeader.setBackground(Color.DARK_GRAY);
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
        btnClear.setPreferredSize(btnSearch.getPreferredSize());
        btnClear.addActionListener(this);
        btnSearch.addActionListener(this);
        panelButtons1.setPreferredSize(new Dimension(0, 70));
        panelButtons1.add(btnClear);
        panelButtons1.add(btnSearch);

        // Add sub-panels into SEARCH1 card
        panelSearchCard1.add(panelHeader, BorderLayout.NORTH);
        panelSearchCard1.add(panelMargin1, BorderLayout.WEST);
        panelSearchCard1.add(panelInput, BorderLayout.CENTER);
        panelSearchCard1.add(panelMargin2, BorderLayout.EAST);
        panelSearchCard1.add(panelButtons1, BorderLayout.SOUTH);

        // -------------------- CARD 2 (SEARCH2 RECORD INFO PANEL) -------------------- //
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
        btnSearchAgain.addActionListener(this);
        btnBackToMenu.addActionListener(this);
        panelButtons2.setPreferredSize(Main.HEADER_SIZE);
        panelButtons2.add(btnSearchAgain);
        panelButtons2.add(btnBackToMenu);

        // Add sub-panels into SEARCH2 card
        panelSearchCard2.add(panelFound, BorderLayout.NORTH);
        panelSearchCard2.add(panelContent, BorderLayout.CENTER);
        panelSearchCard2.add(panelButtons2, BorderLayout.SOUTH);

        // ----- Add both cards into card deck ----- //
        add(panelSearchCard1, SEARCHCARD1);
        add(panelSearchCard2, SEARCHCARD2);
    }

    @Override
    public void actionPerformed(ActionEvent event) {
        Object source = event.getSource();
        CardLayout mainCardLayout = (CardLayout) Main.panelContainer.getLayout();
        CardLayout searchCardLayout = (CardLayout) this.getLayout();

        Window window = (Window) this.getTopLevelAncestor();

        // Event Handling for CARD 1 (SEARCH1 INPUT PANEL)
        if (source == btnBack) {
            txtPlateNumber1.setText("");
            // return to main menu
            mainCardLayout.show(Main.panelContainer, MAIN);
            window.setSize(Main.WIDTH, Main.HEIGHT);
        } else if (source == btnClear) {
            // clear plate number input
            txtPlateNumber1.setText("");
        } else if (source == txtPlateNumber1 || source == btnSearch) {
            String plateNumber = txtPlateNumber1.getText();
            int matchedIndex = 0;
            boolean isFound = false;

            // Check if there is a record with entered plateNumber
            for (int i = 0; i < carArrayList.size(); i++) {
                if (carArrayList.get(i).getPlateNumber().compareToIgnoreCase(plateNumber) == 0) {
                    matchedIndex = i;
                    isFound = true;
                    break;
                }
            }

            // Display error message if not found; else proceed to next screen
            if (!isFound) {
                JOptionPane.showMessageDialog(null, "No car record with the entered Plate Number was found.",
                        "Invalid Plate Number", JOptionPane.OK_OPTION);
            } else {
                // show next screen
                searchCardLayout.show(this, SEARCHCARD2);
                window.setSize(600, 400);

                // populate the disabled text fields
                txtPlateNumber2.setText(carArrayList.get(matchedIndex).getPlateNumber());
                txtBrand.setText(carArrayList.get(matchedIndex).getBrand());
                txtModel.setText(carArrayList.get(matchedIndex).getModel());
                txtType.setText(carArrayList.get(matchedIndex).getType());
                txtColour.setText(carArrayList.get(matchedIndex).getColour());
                txtStatus.setText(carArrayList.get(matchedIndex).getStatus());
                txtPrice.setText(String.format("RM %.2f", carArrayList.get(matchedIndex).getPrice()));
            }
        }

        // Event Handling for CARD 2 (SEARCH2 RECORD INFO PANEL)
        if (source == btnSearchAgain) {
            txtPlateNumber1.setText("");
            searchCardLayout.show(this, SEARCHCARD1);
            window.setSize(500, 250);
        } else if (source == btnBackToMenu) {
            txtPlateNumber1.setText("");
            searchCardLayout.show(this, SEARCHCARD1);
            mainCardLayout.show(Main.panelContainer, MAIN);
            window.setSize(Main.WIDTH, Main.HEIGHT);
        }
    }

}