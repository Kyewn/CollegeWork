#include <iostream>
#include <iomanip>		// For fixed, showpoint, setprecision, to show values with decimal points
#include <cctype>		// For toupper
#include <limits>		// For using numeric_limits in cin.ignore
#include "Table.h"		// includes Table header file, which also includes Product header file
using namespace std;

// Function prototypes
int showMenu();
void addRecord(Table tables[]);
void editRecord(Table tables[]);
void searchRecord(Table tables[]);
void checkRecords(Table tables[]);
int checkCinState();

// Global variables
const int SIZE = 100;
int index = 0;

int main() {
	// Initialize Table array
	Table tableArr[SIZE];
	for (int i = 0; i < SIZE; i++) {
		tableArr[i].setProductNumber(0);
	}
	
	// Variables
	int menuInput;
	char exitInput;
	bool isEnded = false;
	
	cout << "Welcome to Product Management System\n\n";
	cout << "* * * PLEASE MAXIMIZE CONSOLE WINDOW FOR BEST EXPERIENCE * * *\n\n";
	do {
		// Show menu and get menu input
		menuInput = showMenu();
		// Check menu input and redirect to selected function
		if (menuInput == 1) {
			addRecord(tableArr);
		} else if (menuInput == 2) {
			editRecord(tableArr);
		} else if (menuInput == 3) {
			searchRecord(tableArr);
		} else if (menuInput == 4) {
			checkRecords(tableArr);
		} else if (menuInput == 5) {
			// Exit
			do {
				cout << "Are you sure? (Y/N): ";
				cin >> exitInput;
				exitInput = toupper(exitInput);
				cin.ignore(numeric_limits<streamsize>::max(), '\n');
				
				if (exitInput == 'Y')
					isEnded = true;
			} while (exitInput != 'Y' && exitInput != 'N');
		}
	} while (!isEnded);
	
	return 0;
}

int showMenu() {
	// Variables
	int input;
	bool menuBool = true;
	
	do {
		// Print menu
		cout << endl;
		cout.fill('=');
		cout << setw(50) << right << "=\n";
		cout.fill(' ');
		cout << setw(27) << right << "MENU\n";
		cout.fill('=');
		cout << setw(50) << right << "=\n";
		cout.fill(' ');
		cout << "\n               " << "1. Add record\n"
			 << "               " << "2. Edit record\n"
			 << "               " << "3. Search record\n"
			 << "               " << "4. Check records\n"
			 << "               " << "5. Exit\n\n";
		// Get selection input
		cout << "Selection: ";
		cin >> input;
		cin.ignore(numeric_limits<streamsize>::max(), '\n');
		// Check cin state
		if (cin.fail()) {
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
		}
		// Check selection input
		if (input < 1 || input > 5) {
			cout << "\n* * * Invalid input. Valid inputs: 1, 2, 3, 4, 5 * * * \n";
			menuBool = true;
		} else {
			menuBool = false;
		}
	} while (menuBool);
	
	return input;
}

void addRecord(Table tables[]) {
	// Variables
	int num, quantity, error;
	string name, shape;
	double price, length, width, height;
	
	// Check if Table array is full
	if (index == SIZE) {
		cout << "\n\n* * * MAXIMUM AMOUNT OF RECORDS REACHED, UNABLE TO ADD NEW RECORD * * *\n";
		cout << "\n* * * RETURNING TO MENU * * *\n";
	}
	else {
		// Get input from user
		cout << "\n\nPlease key in details of the Table.\n";
		cout.fill('_');
		cout << setw(70) << "_\n";
		// Get Product Number
		do {
			cout << "Product Number: ";
			cin >> num;
			error = checkCinState();
			// Check if product already exists in array
			for (int i = 0; i < SIZE; i++) {
				if (num == tables[i].getProductNumber() && tables[i].getProductNumber() > 0) {
					cout << "* * * Table record already exists in the system. * * *\n";
					error = 69;
					break;
				}
			}
			// Check for valid product number
			if ((num < 1 || num > 9999) && error == 0)
				cout << "* * * Product numbers range from 1 to 9999 only. * * *\n";
		} while (num < 1 || num > 9999 || error == 69);
		// Get Product Name
		do {
			cout << "Product Name: ";
			getline(cin, name);
			if (name == "" || name == " ")
				cout << "* * * Name input cannot be empty. * * *\n";
		} while (name == "" || name == " ");
		// Get Price
		do {
			cout << "Price: ";
			cin >> price;
			error = checkCinState();
			if (price < 0)
				cout << "* * * Only positive numbers allowed. * * *\n";
		} while (price < 0 || error == 69);
		// Get Quantity
		do {
			cout << "Quantity: ";
			cin >> quantity;
			error = checkCinState();
			if (quantity < 0)
				cout << "* * * Only positive numbers allowed. * * *\n";
		} while (quantity < 0 || error == 69);
		// Get Shape
		do {
			cout << "Shape: ";
			getline(cin, shape);
			if (shape == "" || shape == " ")
				cout << "* * * Shape input cannot be empty. * * *\n";
		} while (shape == "" || shape == " ");
		// Get Length
		do {
			cout << "Length: ";
			cin >> length;
			error = checkCinState();
			if (length < 1 && error == 0)
				cout << "* * * Length must be greater than 0. * * *\n";
		} while (length < 1 || error == 69);
		// Get Width
		do {
			cout << "Width: ";
			cin >> width;
			error = checkCinState();
			if (width < 1 && error == 0)
				cout << "* * * Width must be greater than 0. * * *\n";
		} while (width < 1 || error == 69);
		// Get Height
		do {
			cout << "Height: ";
			cin >> height;
			error = checkCinState();
			if (height < 1 && error == 0)
				cout << "* * * Height must be greater than 0. * * *\n";
		} while (height < 1 || error == 69);
		
		// Confirm if user really wants to add new Table
		char conf;
		cout << endl;
		do {
			cout << "Confirm new Table? (Y/N): ";
			cin >> conf;
			conf = toupper(conf);
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
		} while (conf != 'Y' && conf != 'N');
		
		// If Yes, add Table record; if No, do nothing and return to menu
		if (conf == 'Y') {
			cout << "\n+ + + New Table record has been added. + + +\n";
			
			/* Create new Table object with assigned values using constructor,
			   then assign Table object to corresponding index in tables array */
			Table tableObj(num, name, price, quantity, shape, length, width, height);
			tables[index] = tableObj;
			
			// Increase index
			index++;
			
			// Notify user if Table array is full
			if (index == SIZE)
				cout << "\n* * * MAXIMUM AMOUNT OF RECORDS REACHED * * *\n\n";
		} else if (conf == 'N') {
			cout << "\n* * * Process cancelled. Returning to menu. * * *\n\n";
		}
	}
}

void editRecord(Table tables[]) {
	// Variables
	int num, error, matchedIndex;
	double length, width, height;
	
	// Prompt user for product number
	cout << "\n\nPlease key in the product number.\n";
	cout.fill('_');
	cout << setw(70) << right << "_\n";
	do {
		cout << "Product Number: ";
		cin >> num;
		error = checkCinState();
		if ((num < 1 || num > 9999) && error == 0)
			cout << "* * * Invalid product number. Product number ranges from 1 - 9999. * * *\n";
	} while (num < 1 || num > 9999 || error == 69);
	
	// Check if product exists in records
	for (int i = 0; i < SIZE; i++) {
		if (num == tables[i].getProductNumber()) {
			matchedIndex = i;
			break;
		}
		if (i == 99) {
			cout << "\n* * * No matching product found. Returning to menu.* * *\n\n";
			return;
		}
	}
	
	// Show current values of selected product
	cout << "\nCurrent values of PRODUCT " << tables[matchedIndex].getProductNumber() << ":\n";
	cout << setw(70) << right << "_\n";
	tables[matchedIndex].display();
	
	// Prompt user to key in new values
	cout << "\nPlease key in new length, width and height values for PRODUCT " << tables[matchedIndex].getProductNumber() << ".\n";
	cout << setw(70) << right << "_\n";
	do {
		cout << "Length: ";
		cin >> length;
		error = checkCinState();
		if (length < 1 && error == 0)
			cout << "* * * Length must be greater than 0. * * *\n";
	} while (length < 1 || error == 69);
	do {
		cout << "Width: ";
		cin >> width;
		error = checkCinState();
		if (width < 1 && error == 0)
			cout << "* * * Length must be greater than 0. * * *\n";
	} while (width < 1 || error == 69);
	do {
		cout << "Height: ";
		cin >> height;
		error = checkCinState();
		if (height < 1 && error == 0)
			cout << "* * * Length must be greater than 0. * * *\n";
	} while (height < 1 || error == 69);
	
	// Confirm if user really wants to change value
	char conf;
	cout << endl;
	do {
		cout << "Confirm new values? (Y/N): ";
		cin >> conf;
		conf = toupper(conf);
		cin.ignore(numeric_limits<streamsize>::max(), '\n');
	} while (conf != 'Y' && conf != 'N');
	
	// If Yes, change values; if No, do nothing and return to menu
	if (conf == 'Y') {
		cout << "\n+ + + New values have been applied. + + +\n\n";
		tables[matchedIndex].setLength(length);
		tables[matchedIndex].setWidth(width);
		tables[matchedIndex].setHeight(height);
	} else if (conf == 'N') {
		cout << "\n* * * Process cancelled. Returning to menu. * * *\n\n";
	}
}

void searchRecord(Table tables[]) {
	// Variables
	int num, error;
	
	// Get product number from user
	cout << "\n\nPlease key in the product number.\n";
	cout.fill('_');
	cout << setw(70) << "_\n";
	do {
		cout << "Product Number: ";
		cin >> num;
		error = checkCinState();
		if ((num < 1 || num > 9999) && error == 0)
			cout << "* * * Invalid product number. Product number ranges from 1 - 9999. * * *\n";
	} while (num < 1 || num > 9999 || error == 69);
	
	// Search for product in tables array
	for (int i = 0; i < SIZE; i++) {
		if (num == tables[i].getProductNumber()) {
			cout << "\nProduct found. Displaying product details: \n";
			cout.fill('_');
			cout << setw(70) << "_\n";
			tables[i].display();
			break;
		}
		if (i == 99)
			cout << "\n* * * No matching product found. Returning to menu. * * *\n\n";
	}
}

void checkRecords(Table tables[]) {
	// Variables
	bool isEmpty = false;
	
	// Check if tables array is empty
	if (tables[0].getProductNumber() == 0)
		isEmpty = true;
	
	if (isEmpty) {
		// Indicate empty records
		cout << endl;
		cout.fill('=');
		cout << setw(126) << "=\n";
		cout.fill(' ');
		cout << setw(73) << "NO RECORDS";
		cout.fill('=');
		cout << setw(126) << left << "\n=";
		cout << endl;
	} else {
		// Print table header
		cout << endl;
		cout.fill('=');
		cout << setw(182) << right << "=\n";
		cout.fill(' ');
		cout << setw(6) << left << "No.";
		cout << setw(20) << left << "Product Number";
		cout << setw(36) << left << "Product Name";
		cout << setw(20) << left << "Price";
		cout << setw(20) << left << "Quantity";
		cout << setw(20) << left << "Shape";
		cout << setw(20) << left << "Length";
		cout << setw(20) << left << "Width";
		cout << setw(20) << left << "Height";
		cout << endl;
		cout.fill('=');
		cout << setw(182) << right << "=\n";
		// Print table contents
		cout.fill(' ');
		cout << fixed << showpoint << setprecision(2);
		for (int i = 0; i < SIZE; i++) {
			if (tables[i].getProductNumber() > 0) {
				cout << i + 1 << ".    ";
				cout << setw(20) << left << tables[i].getProductNumber();
				cout << setw(36) << left << tables[i].getProductName();
				cout << setw(20) << left << tables[i].getPrice();
				cout << setw(20) << left << tables[i].getQuantity();
				cout << setw(20) << left << tables[i].getShape();
				cout << setw(20) << left << tables[i].getLength();
				cout << setw(20) << left << tables[i].getWidth();
				cout << setw(20) << left << tables[i].getHeight();
			} else {
				break;
			}
			cout << endl;
		}
		cout << endl;
	}
}

int checkCinState() {
	// Used for checking cin fail state
	// Returns 69 if cin failed, returns 0 if no error
	if (cin.fail()) {
		cout << "* * * Invalid input * * *" << endl;
		cin.clear();
		cin.ignore(numeric_limits<streamsize>::max(), '\n');
		return 69;
	} else {
		cin.ignore(numeric_limits<streamsize>::max(), '\n');
		return 0;
	}
}
