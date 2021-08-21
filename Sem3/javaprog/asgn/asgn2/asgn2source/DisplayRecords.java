import javax.swing.*;
import javax.swing.table.*;
import javax.swing.border.EmptyBorder;
import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;

public class DisplayRecords extends JPanel implements ActionListener, KeyListener {

    // String identifiers for main deck cards associated with this panel
    private static final String MAIN = "Main Menu Panel";

    // Column names to be inserted in table model
    private final String[] columnNames = {"No.", "Plate Number", "Brand", "Model", "Type", "Colour", "Status", "Price (RM)"};

    // -------------------- "DISPLAY RECORDS" PANEL COMPONENTS --------------------//
    private JPanel panelHeader = new JPanel(new FlowLayout(FlowLayout.LEFT, 20, 10));
    private JPanel panelTitle = new JPanel(new GridLayout(2, 1));
    private JPanel panelContent = new JPanel(new BorderLayout());
    private JPanel panelSearchBar = new JPanel(new FlowLayout(FlowLayout.RIGHT, 5, 10));
    private JPanel panelMargin1 = new JPanel();
    private JPanel panelMargin2 = new JPanel();
    private JPanel panelMargin3 = new JPanel();
    private JTextField searchBox = new JTextField(10);
    private DefaultTableModel tableModel = new DefaultTableModel(columnNames, 0) {
        @Override // sets all cells to be not editable
        public boolean isCellEditable(int row, int column) {
            return false;
        }
    };
    private JTable recordTable = new JTable(tableModel);
    private JScrollPane scrollTable = new JScrollPane(recordTable, JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED, JScrollPane.HORIZONTAL_SCROLLBAR_NEVER);
    private JLabel lblTitle = new JLabel("DISPLAY RECORDS", JLabel.CENTER);
    private JLabel lblDescription = new JLabel("Search for specific keyword using the search box to filter table data.", JLabel.CENTER);
    private JLabel lblSearch = new JLabel("SEARCH:");
    private JButton btnBack = new JButton("< BACK");
    private JButton btnClear = new JButton("CLEAR");
    private Dimension sizeBackBtn = new Dimension(80, 35);

    // Function variables
    private ArrayList<Car> carArrayList;

    public DisplayRecords(ArrayList<Car> cars) {
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
        panelTitle.setBorder(new EmptyBorder(0, 80, 0, 0));
        panelTitle.setBackground(Color.DARK_GRAY);
        panelTitle.add(lblTitle);
        panelTitle.add(lblDescription);
        panelHeader.setBackground(Color.DARK_GRAY);
        panelHeader.add(btnBack);
        panelHeader.add(panelTitle);

        // Make search bar (panelSearchBar)
        searchBox.setPreferredSize(new Dimension(150, 27));
        searchBox.addKeyListener(this);
        btnClear.addActionListener(this);
        panelSearchBar.setBorder(new EmptyBorder(0, 10, 0, 0));
        panelSearchBar.add(lblSearch);
        panelSearchBar.add(searchBox);
        panelSearchBar.add(btnClear);

        // Make scrollable table (scrollTable)
        recordTable.getColumnModel().getColumn(0).setPreferredWidth(8); // Numbering col.
        recordTable.getColumnModel().getColumn(1).setPreferredWidth(100); // Plate Number col.
        recordTable.getTableHeader().setReorderingAllowed(false);

        // Add search bar and scroll pane
        panelContent.add(panelSearchBar, BorderLayout.NORTH);
        panelContent.add(scrollTable, BorderLayout.CENTER);

        // Make margin panels (panelMargin#)
        panelMargin1.setPreferredSize(new Dimension(40, 0));
        panelMargin2.setPreferredSize(new Dimension(40, 0));
        panelMargin3.setPreferredSize(new Dimension(0, 40));

        // Add sub-panels into parent panel (this)
        add(panelHeader, BorderLayout.NORTH);
        add(panelContent, BorderLayout.CENTER);
        add(panelMargin1, BorderLayout.EAST);
        add(panelMargin2, BorderLayout.WEST);
        add(panelMargin3, BorderLayout.SOUTH);
    }

    @Override
    public void actionPerformed(ActionEvent event) {
        Object source = event.getSource();

        CardLayout mainCardLayout = (CardLayout) Main.panelContainer.getLayout();
        Window window = (Window) this.getTopLevelAncestor();

        if (source == btnBack) {
            searchBox.setText("");
            // Back to main menu
            mainCardLayout.show(Main.panelContainer, MAIN);
            window.setSize(Main.WIDTH, Main.HEIGHT);
        } else if (source == btnClear) {
            // Clear search box
            searchBox.setText("");
            updateTable(false);
        }
    }

    @Override
    public void keyPressed(KeyEvent keyEvent) {/* not used */}

    @Override
    public void keyTyped(KeyEvent keyEvent) {/* not used */}

    @Override
    public void keyReleased(KeyEvent keyEvent) { // For filtering table data
        Object source = keyEvent.getSource();

        if (source == searchBox)
            updateTable(true);
    }

    // Keeps data in the table up-to-date
    public void updateTable(boolean withKeyword) {
        // Clear all rows
        tableModel.setRowCount(0);

        // Determine source of function call
        if (!withKeyword) {
            // Get data from every car object to be stored in rows
            for (int i = 0; i < carArrayList.size(); i++) {
                Object[] data = {
                        i+1,
                        carArrayList.get(i).getPlateNumber(),
                        carArrayList.get(i).getBrand(),
                        carArrayList.get(i).getModel(),
                        carArrayList.get(i).getType(),
                        carArrayList.get(i).getColour(),
                        carArrayList.get(i).getStatus(),
                        String.format("%.2f", carArrayList.get(i).getPrice())
                };

                tableModel.addRow(data);
            }
        } else {
            // Search for keyword
            String keyword = searchBox.getText().toUpperCase();

            for (int i = 0; i < carArrayList.size(); i++) {
                // If any column of a record contains the keyword
                if (carArrayList.get(i).getPlateNumber().toUpperCase().contains(keyword) ||
                    carArrayList.get(i).getBrand().toUpperCase().contains(keyword) ||
                    carArrayList.get(i).getModel().toUpperCase().contains(keyword) ||
                    carArrayList.get(i).getType().toUpperCase().contains(keyword) ||
                    carArrayList.get(i).getColour().toUpperCase().contains(keyword) ||
                    carArrayList.get(i).getStatus().toUpperCase().contains(keyword) ||
                    String.valueOf(carArrayList.get(i).getPrice()).toUpperCase().contains(keyword)) {

                    Object[] data = {
                            i+1,
                            carArrayList.get(i).getPlateNumber(),
                            carArrayList.get(i).getBrand(),
                            carArrayList.get(i).getModel(),
                            carArrayList.get(i).getType(),
                            carArrayList.get(i).getColour(),
                            carArrayList.get(i).getStatus(),
                            String.format("%.2f", carArrayList.get(i).getPrice())
                    };

                    tableModel.addRow(data);
                }
            }
        }
    }

    // For checking if table is empty
    public boolean tableIsEmpty() {
        if (tableModel.getRowCount() == 0)
            return true;
        else
            return false;
    }

}