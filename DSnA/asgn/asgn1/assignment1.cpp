#include <iostream>
#include <iomanip>
#include <cctype>
#include <limits>
#include <string>
using namespace std;

// Constant variables
const int INVENTORY_SIZE = 50;
const int HIRING_LIMIT = 100;
const int BRAND_SIZE = 3;

// Equipment structure
struct Equipment {
	string category;
	string item;
	string brand[BRAND_SIZE];
	string startDate;
	string returnDate;
	int quantity[BRAND_SIZE];
	double price[BRAND_SIZE];
};

// Function prototypes
void generateInventory();
int showMenu();
void viewCustomerDetails(string name, string email, string phoneNo);
void editCustomerDetails(string &name, string &email, string &phoneNo);
void createHiring();
void searchEquipment();
void countHiring();
void listAllEquipment();

// Global scope variables
Equipment equipmentInventory[INVENTORY_SIZE];
Equipment hiredEquipment[HIRING_LIMIT];
int hireCount = 0;

int main() {
	// Variable declarations
	string customerName, email, phoneNo;
	int menuInput;
	char exitInput;
	bool isEnded = false;
	
	// Welcome user
	cout.fill('-');
	cout << setw(60) << "-" << endl;
	cout << "   Welcome to Equipment Hiring Information System (EHIS)\n";
	cout << setw(60) << "-" << endl;
	cout << "* * * PLEASE MAXIMIZE CONSOLE WINDOW FOR BEST EXPERIENCE * * *\n";
	
	// Prompt user for customer's details
	cout << "\nPlease enter the customer's details.\n";
	cout << setw(40) << right << "-\n";
	cout << "Customer Name: ";
	getline(cin, customerName);
	cout << "Email: ";
	cin >> email;
	cout << "Phone Number: ";
	cin >> phoneNo;
	cout << "\n- - - Customer successfully registered - - -\n";
	
	// Generate the firm's equipment inventory
	generateInventory();
	// testprintinv();
	
	// Main menu
	do {
		// Get menu input
		menuInput = showMenu();
		// Process input, redirect user to selected function
		if (menuInput == 1) {
			viewCustomerDetails(customerName, email, phoneNo);
		} else if (menuInput == 2) {
			editCustomerDetails(customerName, email, phoneNo);
		} else if (menuInput == 3) {
			createHiring();
		} else if (menuInput == 4) {
			searchEquipment();
		} else if (menuInput == 5) {
			countHiring();
		} else if (menuInput == 6) {
			listAllEquipment();
		} else if (menuInput == 7) {
			// Exit confirmation
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


void generateInventory() {
	// NOTE: brands, prices, and quantity are fixed for purpose of assignment
	int eqCount = 0;
	
	string categoryList[] = {"Gardening", "Building", "Decorating", "Car Maintenance", "Miscellaneous"};
	string toolList[][10] = {
		{"Fork", "Gardening Gloves", "Garden Hose", "Hand Trowel", "Hoe", "Rake", "Saw", "Secateurs", "Shovel", "Spade"}, //Gardening
		{"Brick Hammer", "Concrete Mixer", "Cordless Drill", "Crowbar", "Cement Bags", "Pickaxe", "Safety Helmet", "Sledge Hammer", "Wheelbarrow", "Trowel"}, //Building
		{"Cordless Screwdriver", "Curved Claw Hammer", "Corded Circular Saw","Gluegun", "Multipurpose Pliers", "Nailgun", "Paint Buckets", "Rollers with tray", "Sander", "Tape Measure"}, //Deco
		{"Air Ratchet", "Automotive Stethoscope", "Battery Carrier", "Car Lift", "Extension Bar", "Impact Wrench", "Jumpers", "Out-Of-Sight Pliers", "Pneumatic Wrench", "Vacuum Pump"}, //Car Maint.
		{"Conductive Wires", "DIY Cutting Board", "Files", "Float", "Hex Key Set", "Ladder", "Magnets", "Nail Set", "Switches", "Tapes"}  //Misc	
	};
	
	// For each category
	for (int i = 0; i < 5; i++) {
		// For each tool item
		for (int j = 0; j < 10; j++) {
			// Set the values of equipment attributes
			equipmentInventory[eqCount].category = categoryList[i];
			equipmentInventory[eqCount].item = toolList[i][j];
			equipmentInventory[eqCount].brand[0] = "Mr. DIY";
			equipmentInventory[eqCount].brand[1] = "Daiso";
			equipmentInventory[eqCount].brand[2] = "Young Ones";
			equipmentInventory[eqCount].quantity[0] = 50;
			equipmentInventory[eqCount].quantity[1] = 40;
			equipmentInventory[eqCount].quantity[2] = 30;
			equipmentInventory[eqCount].price[0] = 40;
			equipmentInventory[eqCount].price[1] = 70;
			equipmentInventory[eqCount].price[2] = 100;
			
			eqCount++;
		}
	}
}


int showMenu() {
	int menuOption;
	
	// Print menu header
	cout << endl;
	cout.fill('=');
	cout << setw(55) << "=" << endl;
	cout.fill(' ');
	cout << setw(30) << right << "MAIN MENU" << endl;
	cout.fill('=');
	cout << setw(55) << "=" << endl;
	// Print menu options
	cout.fill(' ');
	cout << setw(10) << ' ' << "1. View customer's details\n";
	cout << setw(10) << ' ' << "2. Edit customer's details\n";
	cout << setw(10) << ' ' << "3. Create new hiring\n";
	cout << setw(10) << ' ' << "4. Search equipment by specified date\n";
	cout << setw(10) << ' ' << "5. Count number of hiring for each category\n";
	cout << setw(10) << ' ' << "6. List all equipment by category\n";
	cout << setw(10) << ' ' << "7. Exit\n\n";
	
	// Get user's input
	do {
		cout << "Selection: ";
		cin >> menuOption;
		cin.ignore(numeric_limits<streamsize>::max(), '\n');
		if (cin.fail()) {
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
		}
		if (menuOption < 1 || menuOption > 7)
			cout << "* Invalid input, please choose from 1 - 7 *\n";
	} while (menuOption < 1 || menuOption > 7);
	cout << endl;
	
	return menuOption;
}


void viewCustomerDetails(string name, string email, string phoneNo) {
	cout << "Customer Details:\n";
	cout.fill('-');
	cout << setw(40) << "-" << endl;
	cout << "Name: " << name << endl;
	cout << "Email: " << email << endl;
	cout << "Phone Number: " << phoneNo << endl;
}


void editCustomerDetails(string &name, string &email, string &phoneNo) {
	// Variables
	int editInput;
	bool isStopped = false;
	
	do {
		// Print submenu for editing customer data
		cout << "\nPlease select the data that you want to edit.\n";
		cout.fill('-');
		cout << setw(50) << "-" << endl;
		cout << "1. Customer Name\n"
			 << "2. Email\n"
			 << "3. Phone Number\n"
			 << "4. Back to main menu\n\n";
		// Get user's selection input
		do {
			cout << "Selection: ";
			cin >> editInput;
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			if (cin.fail()) {
				cin.clear();
				cin.ignore(numeric_limits<streamsize>::max(), '\n');
			}
			if (editInput < 1 || editInput > 4)
				cout << "* Invalid input, please choose from 1 - 4 *\n";
		} while (editInput < 1 || editInput > 4);
		cout << endl;
		// Process user's choice
		if (editInput == 1) {
			cout << "Enter new Name: ";
			getline(cin, name);
			cout << "\n+ + + Name successfully changed + + +\n";
		} else if (editInput == 2) {
			cout << "Enter new Email: ";
			cin >> email;
			cout << "\n+ + + Email successfully changed + + +\n";
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
		} else if (editInput == 3) {
			cout << "Enter new Phone Number: ";
			cin >> phoneNo;
			cout << "\n+ + + Phone Number successfully changed + + +\n";
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
		} else if (editInput == 4) {
			isStopped = true;
		}
	} while (!isStopped);
}


void createHiring() {
	// Variable declarations
	int categoryOption, toolOption, brandOption, quantity;
	string startDate, returnDate;
	bool isEnded = false, isUnique = true;
	// Category array for referencing the inventory
	string categoryList[] = {"Gardening", "Building", "Decorating", "Car Maintenance", "Miscellaneous"};
	
	// If hiring limit has been reached: exit from function; else: proceed
	if (hireCount >= HIRING_LIMIT) {
		cout << "* HIRING LIMIT HAS BEEN REACHED, UNABLE TO CREATE NEW HIRING *\n";
		return;
	}
	
	// Display Create Hiring submenu
	cout.fill('-');
	cout << setw(60) << "-" << endl;
	cout.fill(' ');
	cout << setw(36) << "CREATE HIRING" << endl;
	cout.fill('-');
	cout << setw(60) << "-" << endl;
	
	// Category menu
	while (true) {
		// Print categories
		cout.fill('-');
		cout << "\nPlease select a category:\n";
		cout << setw(40) << "-" << endl;
		
		int i = 1; // used for numbering only
		for (string category : categoryList) {
			cout << " " << i << ".\t" << category << endl;
			i++;
		}
		cout << " " << i << ".\tBack to main menu" << endl << endl;
		
		// Prompt user to select category
		do {
			cout << "Selection: ";
			cin >> categoryOption;
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			if (cin.fail()) {
				cin.clear();
				cin.ignore(numeric_limits<streamsize>::max(), '\n');
			}
			if (categoryOption < 1 || categoryOption > 6)
				cout << "* Invalid input, please choose from 1 - 6 *\n";
		} while (categoryOption < 1 || categoryOption > 6);
		
		// Process category input
		if (categoryOption == 6) {
			break;
		} else if (categoryOption > 0 && categoryOption < 6) {
			// Initialize tools menu based on selected category
			string category = categoryList[categoryOption - 1];
			
			// Tools menu
			while (true) {
				int printCount = 0, matchedIndex = 0;
									// index of first element of selected category
				cout.fill('-');
				cout << "\nSELECTED CATEGORY: " << category << endl;
				cout << setw(40) << "-" << endl;
				// Print tools
				cout.fill('-');
				cout << "Please select a tool:\n";
				cout << setw(40) << "-" << endl;
				for (int i = 0; i < INVENTORY_SIZE; i++) {
					if (equipmentInventory[i].category == category) {
						cout << " " << printCount+1 << ".\t" << equipmentInventory[i].item << endl;
						printCount++;
						
						// Set first index of selected category
						if (printCount == 1)
							matchedIndex = i;
					}
					if (printCount == 10)
							break;
				}
				cout << " " << printCount+1 << ".\tBack" << endl << endl;
				
				// Prompt user to select tool
				do {
					cout << "Selection: ";
					cin >> toolOption;
					cin.ignore(numeric_limits<streamsize>::max(), '\n');
					if (cin.fail()) {
						cin.clear();
						cin.ignore(numeric_limits<streamsize>::max(), '\n');
					}
					if (toolOption < 1 || toolOption > 11)
						cout << "* Invalid input, please choose from 1 - 11 *\n";
				} while (toolOption < 1 || toolOption > 11);
				
				// Process tool input
				if (toolOption == 11) {
					break;
				} else if (toolOption > 0 && toolOption < 11) {
					// Initialize brands menu based on selected tool
					int toolIndex = matchedIndex + (toolOption - 1); // index of selected tool
					string tool = equipmentInventory[toolIndex].item; // name of selected tool
					
					// Brands menu
					while (true) {
						cout.fill('-');
						cout << "\nSELECTED TOOL: " << tool << endl;
						cout << setw(40) << "-" << endl;
						// Print brands, quantity, and price
						cout << "Please select a brand:\n";
						cout << setw(60) << "-" << endl;
						cout.fill(' ');
						cout << " \t" << setw(14) << left << "BRAND";
						cout << setw(12) << left << "QUANTITY";
						cout << setw(22) << left << "PRICE PER UNIT(RM)" << endl;
						cout.fill('-');
						cout << setw(60) << "-" << endl;
						
						i = 1;
						cout.fill(' ');
						cout << fixed << showpoint << setprecision(2);
						for (string brand : equipmentInventory[toolIndex].brand) {
							cout << " " << i << ".\t" << setw(14) << left << brand;
							cout << setw(12) << left << equipmentInventory[toolIndex].quantity[i-1];
							cout << setw(10) << left << equipmentInventory[toolIndex].price[i-1] << endl;
							i++;
						}
						cout << " " << i << ".\tBack" << endl << endl;
						
						// Prompt user to select brand
						do {
							cout << "Selection: ";
							cin >> brandOption;
							cin.ignore(numeric_limits<streamsize>::max(), '\n');
							if (cin.fail()) {
								cin.clear();
								cin.ignore(numeric_limits<streamsize>::max(), '\n');
							}
							if (brandOption == 4)
								break;
							if (brandOption < 1 || brandOption > 4)
								cout << "* Invalid input, please choose from 1 - 4 *\n";
							else if (equipmentInventory[toolIndex].quantity[brandOption - 1] <= 0)
								cout << "* This brand is out of stock, please choose another one *\n";
						} while (brandOption < 1 || brandOption > 4 || equipmentInventory[toolIndex].quantity[brandOption - 1] <= 0);
						
						// Process brand input
						if (brandOption == 4) {
							break;
						} else if (brandOption > 0 && brandOption < 5) {
							int brandIndex = brandOption - 1; // index of selected brand
							string brand = equipmentInventory[toolIndex].brand[brandIndex]; // name of selected brand
							
							// Get quantity
							do {
								cout << "\nEnter quantity: ";
								cin >> quantity;
								cin.ignore(numeric_limits<streamsize>::max(), '\n');
								if (cin.fail()) {
									cin.clear();
									cin.ignore(numeric_limits<streamsize>::max(), '\n');
								}
								if (quantity <= 0)
									cout << "* Invalid input, please enter a positive number *";
								else if (quantity > equipmentInventory[toolIndex].quantity[brandIndex])
									cout << "* Invalid input, the quantity you entered is more than the quantity in the inventory *";
							} while (quantity <= 0 || quantity > equipmentInventory[toolIndex].quantity[brandIndex]);
							
							// Get start date
							do {
								cout << "\nEnter hiring start date (Format: DD-MM-YYYY): ";
								getline(cin, startDate);
								if (startDate.length() > 10 || startDate.empty())
									cout << "* Invalid input, please follow the date format *";
							} while (startDate.length() > 10 || startDate.empty());
							
							// Get return date
							do {
								cout << "Enter return date (Format: DD-MM-YYYY): ";
								getline(cin, returnDate);
								if (returnDate.length() > 10 || returnDate.empty())
									cout << "* Invalid input, please follow the date format *";
							} while (returnDate.length() > 10 || returnDate.empty());
														
							// Display summary of hiring details	
							double price = equipmentInventory[toolIndex].price[brandIndex];
										
							cout << "\nCheck Hiring Details:\n";
							cout << setfill('-') << setw(90) << "-" << endl;
							cout.fill(' ');
							cout << "Category:\t\t" << setw(24) << left << category << "Tool:\t\t" << tool << endl
								 << "Brand:\t\t\t" << setw(24) << left << brand << "Quantity:\t" << quantity << endl
								 << "Price Per Unit(RM):\t" << setw(24) << left << price << "Total Price:\t" <<  (quantity * price) << endl
								 << "Start Date:\t\t" << setw(24) << left << startDate << "Return Date:\t" << returnDate << endl;
							
							// New hiring confirmation
							char confInput;
							cout << endl;
							do {
								cout << "Confirm new hiring? (Y/N): ";
								cin >> confInput;
								confInput = toupper(confInput);
								cin.ignore(numeric_limits<streamsize>::max(), '\n');
								if (confInput != 'Y' && confInput != 'N')
									cout << "* Invalid input, please enter 'Y' or 'N' *\n";
							} while (confInput != 'Y' && confInput != 'N');
							
							// Process confirmation input
							if (confInput == 'N') {
								cout << "\n* Tool hiring cancelled, returning to menu *\n";
								isEnded = true;
								break;
							} else if (confInput == 'Y') {
								// Check if new hiring is a duplicate
								for (int i = 0; i < HIRING_LIMIT; i++) {
									if (category == hiredEquipment[i].category && tool == hiredEquipment[i].item &&
										brand == hiredEquipment[i].brand[brandIndex] && quantity == hiredEquipment[i].quantity[brandIndex] &&
										startDate == hiredEquipment[i].startDate && returnDate == hiredEquipment[i].returnDate) {
										isUnique = false;
										break;
									} else {
										isUnique = true;
									}
								}
								
								// If it is a duplicate, end process
								if (!isUnique) {
									cout << "* There is a duplicate of this hiring, cancelling hiring process *\n";
									isEnded = true;
								} else {
									isEnded = true;
									// Add new hiring into hiredEquipment array
									hiredEquipment[hireCount].category = category;
									hiredEquipment[hireCount].item = tool;
									hiredEquipment[hireCount].brand[0] = brand;
									hiredEquipment[hireCount].quantity[0] = quantity;
									hiredEquipment[hireCount].price[0] = price;
									hiredEquipment[hireCount].startDate = startDate;
									hiredEquipment[hireCount].returnDate = returnDate;
									
									hireCount++;
									cout << "\n+ + + New hiring successfully added + + +\n";
									
									// Decrease quantity of selected tool from its current quantity in the inventory
									equipmentInventory[toolIndex].quantity[brandIndex] -= quantity;
									
									// Notify user if hiring limit is reached
									if (hireCount >= HIRING_LIMIT)
										cout << "\n* HIRING LIMIT HAS BEEN REACHED *\n";
								}
							}
						}
						// Break out of brands menu
						if (isEnded)
							break;
					}
				}
				// Break out of tools menu
				if (isEnded)
					break;
			}
		}
		// Break out of category menu
		if (isEnded)
			break;
	}
}


void searchEquipment() {
	// Variable
	string returnDate;
	int printCount = 0;
	bool isFound = false, isStopped = false;
	char contInput;
	
	// If no existing hirings: exit from function; else: proceed
	if (hireCount == 0) {
		cout << "* There are currently no existing hirings in the system. Returning to main menu *\n";
		return;
	}
	
	// Loop the searching process until user enters 'N'
	do {
		printCount = 0;
		isFound = false;
		// Prompt user to enter return date
		cout << "Please enter the return date of the hiring that you are searching for:\n";
		cout << setfill('-') << setw(74) << "-" << endl;
		cout << "Enter return date: ";
		cin >> returnDate;
		
		// Check hirings for matching return date
		for (int i = 0; i < hireCount; i++) {
			if (hiredEquipment[i].returnDate == returnDate) {
				printCount++;
				// Only print table header the first time a matching date is found
				if (printCount == 1) {
					cout << "\n- - - Hiring(s) with specified return date found - - -\n\n";
					
					cout << setfill('-') << setw(132) << "-" << endl;
					cout << setfill(' ') << " No." << "\t";
					cout << setw(19) << left << "CATEGORY"
						 << setw(26) << left << "TOOL"
						 << setw(14) << left << "BRAND"
						 << setw(12) << left << "QUANTITY"
					     << setw(22) << left << "PRICE PER UNIT(RM)"
					     << setw(19) << left << "TOTAL PRICE(RM)"
					     << setw(14) << left << "START DATE"
					     << endl;
					cout << setfill('-') << setw(132) << "-" << endl;
					
					isFound = true;
				}
				// Print table row (with data)
				cout << setfill(' ') << " " << printCount << ".\t";
				cout << setw(19) << left << hiredEquipment[i].category
					 << setw(26) << left << hiredEquipment[i].item
					 << setw(14) << left << hiredEquipment[i].brand[0]
					 << setw(12) << left << hiredEquipment[i].quantity[0]
				     << setw(22) << left << hiredEquipment[i].price[0]
				     << setw(19) << left << (hiredEquipment[i].quantity[0] * hiredEquipment[i].price[0])
				     << setw(14) << left << hiredEquipment[i].startDate
				     << endl;
			}
		}
		cout << endl;
		
		// If return date not found: notify user
		if (!isFound)
			cout << "* There are no hirings with the specified return date *\n";
		
		// Ask if user wants to search again
		do {
			cout << "\nDo you want to search again? (Y/N): ";
			cin >> contInput;
			contInput = toupper(contInput);
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			if (contInput != 'Y' && contInput != 'N')
				cout << "* Invalid input, please enter 'Y' or 'N' *\n";
		} while (contInput != 'Y' && contInput != 'N');
		cout << endl;
			
		if (contInput == 'N')
			isStopped = true;
		else
			isStopped = false;
				
	} while (!isStopped);
}


void countHiring() {
	// Variable
	int gardeningCount = 0, buildingCount = 0, decorCount = 0, carMaintCount = 0, miscCount = 0;
	
	// If at least 1 hiring: check inventory and count; else: leave counts at 0
	if (hireCount > 0) {
		// Count number of hiring in each category
		for (int i = 0; i < hireCount; i++) {
			if (hiredEquipment[i].category == "Gardening")
				gardeningCount++;
			else if (hiredEquipment[i].category == "Building")
				buildingCount++;
			else if (hiredEquipment[i].category == "Decorating")
				decorCount++;
			else if (hiredEquipment[i].category == "Car Maintenance")
				carMaintCount++;
			else if (hiredEquipment[i].category == "Miscellaneous")
				miscCount++;
		}
	}
	
	// Print out number of hiring in each category
	cout << "NUMBER OF HIRING IN EACH CATEGORY:" << endl;
	cout << setfill('-') << setw(50) << "-" << endl;
	cout << "Gardening: " << gardeningCount << endl;
	cout << "Building: " << buildingCount << endl;
	cout << "Decorating: " << decorCount << endl;
	cout << "Car Maintenance: " << carMaintCount << endl;
	cout << "Miscellaneous: " << miscCount << endl;
}


void listAllEquipment() {
	// Variables
	string categoryList[] = {"Gardening", "Building", "Decorating", "Car Maintenance", "Miscellaneous"};
	int printCount;
	
	// If no hire records: print "NO RECORDS", else: print all records
	if (hireCount == 0) {
		cout << setfill('=') << setw(101) << "=" << endl;
		cout << setfill(' ') << setw(59) << right << "NO HIRING RECORDS" << endl;
		cout << setfill('=') << setw(101) << "=" << endl;
	} else {
		// For every category
		for (int i = 0; i < 5; i++) {
			printCount = 0;
			// Table header
			// formula for centering (((total length - word) / 2) + word)
			cout << setfill('=') << setw(128) << "=" << endl;
			cout << setfill(' ') << setw(((128 - (categoryList[i].length() + 10)) / 2) + categoryList[i].length() + 10)
								 << right << categoryList[i] + " Equipment\n";
			cout << setfill('=') << setw(128) << "=" << endl;
			
			cout.fill(' ');
			cout << "No.\t" << setw(26) << left << "TOOL"
						    << setw(14) << left << "BRAND"
						    << setw(12) << left << "QUANTITY"
						    << setw(22) << left << "PRICE PER UNIT(RM)"
						    << setw(19) << left << "TOTAL PRICE(RM)"
						    << setw(14) << left << "START DATE"
						    << setw(14) << left << "END DATE"
						    << endl;
			cout << setfill('-') << setw(128) << "-" << endl;
			// Print out any tool hiring under current category
			for (int j = 0; j < hireCount; j++) {
				// Table contents
				if (hiredEquipment[j].category == categoryList[i]) {
					cout.fill(' ');
					cout << printCount+1 << ".\t";
					cout << setw(26) << left << hiredEquipment[j].item
					     << setw(14) << left << hiredEquipment[j].brand[0]
				 	     << setw(12) << left << hiredEquipment[j].quantity[0]
				 	     << setw(22) << left << hiredEquipment[j].price[0]
				 	     << setw(19) << left << (hiredEquipment[j].quantity[0] * hiredEquipment[j].price[0])
				 	     << setw(14) << left << hiredEquipment[j].startDate
				 	     << setw(14) << left << hiredEquipment[j].returnDate
				  	     << endl;
				  	     
					printCount++;
				}
				
				if ((j == hireCount - 1) && printCount == 0)
					cout << setfill(' ') << setw(78) << right << "----- NO HIRING RECORDS -----" << endl;
			}
			cout << endl;
		}
	}	
}
