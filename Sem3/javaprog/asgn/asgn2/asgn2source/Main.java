import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;

public class Main extends JFrame implements ActionListener {

    // Main variables
    private ArrayList<Car> carArrayList = new ArrayList<Car>();
    // Static constant variables
    static final int WIDTH = 700;
    static final int HEIGHT = 550;
    static final Dimension HEADER_SIZE = new Dimension(0, 70);
    // String identifiers for every card(panel objects of main functions)
    private static final String LOGIN = "Login Panel";
    private static final String MAIN = "Main Menu Panel";
    private static final String CREATE = "Create Record Panel";
    private static final String DELETE = "Delete Record Panel";
    private static final String EDIT = "Edit Record Panel";
    private static final String SEARCH = "Search Record Panel";
    private static final String DISPLAY = "Display All Records Panel";
    // Panel objects representing the GUI pages of the main system functions
    private Login panelLogin = new Login();
    private CreateRecord panelCreate = new CreateRecord(carArrayList);
    private DeleteRecord panelDelete = new DeleteRecord(carArrayList);
    private EditRecord panelEdit = new EditRecord(carArrayList);
    private SearchRecord panelSearch = new SearchRecord(carArrayList);
    private DisplayRecords panelDisplay = new DisplayRecords(carArrayList);

    // -------------------- "MAIN" FRAME COMPONENTS -------------------- //
    static JPanel panelContainer = new JPanel(new CardLayout());
    private JPanel panelMain = new JPanel(new BorderLayout());
    private JPanel panelHeader = new JPanel(new GridBagLayout());
    private JPanel panelButtons = new JPanel();
    private JLabel lblMainMenu = new JLabel("MAIN MENU");
    private JButton btnCreate = new JButton("Create Record");
    private JButton btnDelete = new JButton("Delete Record");
    private JButton btnEdit = new JButton("Edit Record");
    private JButton btnSearch = new JButton("Search Record");
    private JButton btnDisplay = new JButton("Display All Records");
    private Dimension sizeBtn = new Dimension(300, 50);
    private Dimension marginBtn = new Dimension(0, 20);

    public Main() {
        super("Car Record Management System");
        makeFrame();
        showFrame();
    }

    public void makeFrame() {
        // Make header bar (panelHeader)
        lblMainMenu.setForeground(Color.WHITE);
        lblMainMenu.setFont(new Font("Helvetica", Font.BOLD, 20));
        panelHeader.setBackground(Color.DARK_GRAY);
        panelHeader.setPreferredSize(HEADER_SIZE);
        panelHeader.add(lblMainMenu);

        // Make buttons panel (panelButtons)
        panelButtons.setLayout(new BoxLayout(panelButtons, BoxLayout.Y_AXIS));
        btnCreate.setMaximumSize(sizeBtn);
        btnDelete.setMaximumSize(sizeBtn);
        btnSearch.setMaximumSize(sizeBtn);
        btnEdit.setMaximumSize(sizeBtn);
        btnDisplay.setMaximumSize(sizeBtn);
        btnCreate.setAlignmentX(Component.CENTER_ALIGNMENT);
        btnDelete.setAlignmentX(Component.CENTER_ALIGNMENT);
        btnEdit.setAlignmentX(Component.CENTER_ALIGNMENT);
        btnSearch.setAlignmentX(Component.CENTER_ALIGNMENT);
        btnDisplay.setAlignmentX(Component.CENTER_ALIGNMENT);
        btnCreate.addActionListener(this);
        btnDelete.addActionListener(this);
        btnEdit.addActionListener(this);
        btnSearch.addActionListener(this);
        btnDisplay.addActionListener(this);
        panelButtons.add(Box.createRigidArea(marginBtn));
        panelButtons.add(btnCreate);
        panelButtons.add(Box.createRigidArea(marginBtn));
        panelButtons.add(btnDelete);
        panelButtons.add(Box.createRigidArea(marginBtn));
        panelButtons.add(btnEdit);
        panelButtons.add(Box.createRigidArea(marginBtn));
        panelButtons.add(btnSearch);
        panelButtons.add(Box.createRigidArea(marginBtn));
        panelButtons.add(btnDisplay);

        // Make main menu panel (panelMain)
        panelMain.add(panelHeader, BorderLayout.PAGE_START);
        panelMain.add(panelButtons, BorderLayout.CENTER);

        // Add all function panels to card deck (panelContainer)
        panelContainer.add(panelLogin, LOGIN);
        panelContainer.add(panelMain, MAIN);
        panelContainer.add(panelCreate, CREATE);
        panelContainer.add(panelDelete, DELETE);
        panelContainer.add(panelEdit, EDIT);
        panelContainer.add(panelSearch, SEARCH);
        panelContainer.add(panelDisplay, DISPLAY);

        // Add card deck to frame
        add(panelContainer);
    }

    public void showFrame() {
        setResizable(false);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        // Set 500 x 300 for login panel
        setSize(500, 300);
        setVisible(true);
    }

    public static void main(String[] args) {
        Main frame = new Main();

        // Exit confirmation dialog box
        frame.addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent windowEvent) {
                int response = JOptionPane.showConfirmDialog(frame,
                        "        ARE YOU SURE?", "Exit System",
                        JOptionPane.YES_NO_OPTION);
                if (response == JOptionPane.YES_OPTION)
                    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
                else if (response == JOptionPane.NO_OPTION)
                    frame.setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
            }
        });
    }

    @Override
    public void actionPerformed(ActionEvent event) {
        Object source = event.getSource();
        CardLayout cardLayout = (CardLayout) panelContainer.getLayout();

        // Show the panel (card) of the selected function
        if (source == btnCreate) {
            cardLayout.show(panelContainer, CREATE);
            this.setSize(WIDTH, HEIGHT + 100);
        } else if (source == btnDelete) {
            cardLayout.show(panelContainer, DELETE);
            this.setSize(500, 250);
        } else if (source == btnEdit) {
            cardLayout.show(panelContainer, EDIT);
            this.setSize(500, 250);
        } else if (source == btnSearch) {
            cardLayout.show(panelContainer, SEARCH);
            this.setSize(500, 250);
        } else if (source == btnDisplay) {
            panelDisplay.updateTable(false);
            // Only move to display panel if there are existing records
            if (panelDisplay.tableIsEmpty()) {
                JOptionPane.showMessageDialog(null, "There are currently no records in the system.",
                        "Function Not Available", JOptionPane.INFORMATION_MESSAGE);
            } else {
                cardLayout.show(panelContainer, DISPLAY);
                this.setSize(WIDTH + 50, HEIGHT);
            }
        }
    }

}