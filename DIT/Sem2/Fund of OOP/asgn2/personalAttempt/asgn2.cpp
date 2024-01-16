#include <iostream>
#include <limits>
#include <cctype>
#include <iomanip>
using namespace std;
	
class Product {
	private:
		int productNo, quantity;
		string productName;
		double price;
	public:
		Product();
		Product(int no, string name, double price, int q);
		void setNo(int no);
		void setName(string name);
		void setPrice(double price);
		void setQuantity(int q);
		int getNo();
		string getName();
		double getPrice();
		int getQuantity();
		void display();
};

class Table:public Product {
	private:
		double width, height, length;
		string shape;
	public:
		Table();
		Table(double, double, double, string);
		void setWidth(double nw);
		void setHeight(double nh);
		void setLength(double nl);
		void setShape(string nshape);
		double getWidth();
		double getHeight();
		double getLength();
		string getShape();
		void display();
};

const int SIZE = 100;
Table products[SIZE];
int objCount = 0;

int showMenu() {
	int selection;
	do {	
		cout << "                                    Menu                                    " << endl << endl << endl
			 << "                    1. Create New Table Record" << endl << endl
			 << "                    2. Edit a Table Record" << endl << endl
			 << "                    3. Delete a Table Record" << endl << endl
			 << "                    4. Display Specific Record" << endl << endl
			 << "                    5. Display All Records" << endl << endl 
			 << "                    6. Exit" << endl << endl<< endl
			 << "Selection (1-6): ";
		cin >> selection;
		cout << endl << endl << "============================================================================" << endl << endl;
		if (cin.fail()) {
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			cout << "*** Invalid input! Selection range: 1 ~ 6 ***" << endl << endl;
		} else if (selection < 1 || selection > 6)
			cout << "*** Invalid input! Selection range: 1 ~ 6 ***" << endl << endl;
					 
	} while (selection < 1 || selection > 6);
	
	return selection;
}

int showEditMenu(int targt) {
	int selection;
	do {
		cout << "----------------------------------------------------------------------------" << endl << endl;
		cout << "                                   Result                                   " << endl << endl;	
		cout << "                1. Product no. : " << products[targt].getNo()<< endl << endl
			 << "                2. Product name: " << products[targt].getName()<< endl << endl
			 << "                3. Product price: " << products[targt].getPrice() << endl << endl
			 << "                4. Product quantity: " << products[targt].getQuantity() << endl << endl
			 << "                5. Product width: " << products[targt].getWidth() << endl << endl
			 << "                6. Product height: " << products[targt].getHeight() << endl << endl
			 << "                7. Product length: " << products[targt].getLength() << endl << endl
			 << "                8. Product shape: " << products[targt].getShape() << endl << endl
			 << "                9. Back" << endl << endl;
		cout << "Selection to edit (1-9): ";
		cin >> selection;
		cout << endl << endl << "============================================================================" << endl << endl;
		if (cin.fail()) {       
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			cout << "*** Invalid input! Selection range: 1 ~ 9 ***" << endl << endl;
		} else if (selection < 1 || selection > 9)
			cout << "*** Invalid input! Selection range: 1 ~ 9 ***" << endl << endl;
		
	} while (selection < 1 || selection > 9);
	return selection;
}

double validateCreate(double spec, char spec1) {			//dk if wan merge validate create and edit using another param that specify edit/create 
	bool flag = false;
	
	do {
		if (spec1 == 'p')
			cout << "Enter product price: ";
		else if (spec1 == 'w')
			cout << "Enter width: ";
		else if (spec1 == 'h')
			cout << "Enter height: ";
		else if (spec1 == 'l')
			cout << "Enter length: ";
			
		cin >> spec;
		if(cin.fail()) {
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			cout << "*** Invalid input! It must be a floating value. ***" << endl;
			flag = true;			
		} else if (spec < 0) {
			cout << "*** Invalid input! It cannot be lower than 0. ***" << endl;
			flag = true;
		} else {
			cin.ignore(numeric_limits<streamsize>::max(), '\n');			
			flag = false;
		}
	} while (flag);
	
	return spec;
}

int validateCreate(int spec, char spec1) {
	bool flag = false;

	if (spec1 == 'q') {
		do {
			cout << "Enter product quantity: ";
			cin >> spec;
					
			if(cin.fail()) {
				cin.clear();
				cin.ignore(numeric_limits<streamsize>::max(), '\n');
				cout << "*** Invalid input! It must be an integer value. ***" << endl;
				flag = true;
			} else if (spec1 == 'q' && spec < 0) {
				cout << "*** Invalid input! It cannot be lower than 0. ***" << endl;
				flag = true;
			} else {					
				cin.ignore(numeric_limits<streamsize>::max(), '\n');			
				flag = false;				
			}
		} while (flag);
	} else if (spec1 == 'n'){
		do {
			cout << "Enter product no. : ";
			cin >> spec;
				
			if(cin.fail()) {
				cin.clear();
				cin.ignore(numeric_limits<streamsize>::max(), '\n');
				cout << "*** Invalid input! It must be an integer value. ***" << endl;
				flag = true;
			} else if (spec <= 0) {
				cout << "*** Invalid input! It cannot be lower or equal to 0. ***" << endl;
				flag = true;
			} else {
				cin.ignore(numeric_limits<streamsize>::max(), '\n');			
				flag = false;
				for (int i=0; i<SIZE; i++){
					if (products[i].getNo() == spec) {
						cout << "*** An item is using that product no.! Please try again. ***" << endl;						
						flag = true;
					} 
				}
			}				
		} while (flag);
	}
	return spec;
}

double validateEdit(double spec, char spec1) {			
	bool flag = false;
	do {
		if (spec1 == 'p')
			cout << "Enter new product price: ";
		else if (spec1 == 'w') 
			cout << "Enter new product width: ";
		else if (spec1 == 'h')
			cout << "Enter new product height: ";
		else if (spec1 == 'l')
			cout << "Enter new product length: ";
			
		cin >> spec;
		if(cin.fail()) {
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			cout << "*** Invalid input! It must be a floating value. ***" << endl;
			flag = true;
		} else if (spec < 0) {
			cout << "*** Invalid input! It cannot be lower than 0. ***" << endl;
			flag = true;
		} else {
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			flag = false;
		}
	} while (flag);
	
	return spec;
}

int validateEdit(int spec, char spec1) {
	bool flag = false;

	if (spec1 == 'q') {
		do {
			cout << "Enter new product quantity: ";
			cin >> spec;
					
			if(cin.fail()) {
				cin.clear();
				cin.ignore(numeric_limits<streamsize>::max(), '\n');
				cout << "*** Invalid input! It must be an integer value. ***" << endl;
				flag = true;
			} else if (spec1 == 'q' && spec < 0) {
				cout << "*** Invalid input! It cannot be lower than 0. ***" << endl;
				flag = true;
			} else {					
				cin.ignore(numeric_limits<streamsize>::max(), '\n');			
				flag = false;				
			}
		} while (flag);
	} else if (spec1 == 'n'){
		do {
			cout << "Enter new product no. : ";
			cin >> spec;
				
			if(cin.fail()) {
				cin.clear();
				cin.ignore(numeric_limits<streamsize>::max(), '\n');
				cout << "*** Invalid input! It must be an integer value. ***" << endl;
				flag = true;
			} else if (spec <= 0) {
				cout << "*** Invalid input! It cannot be lower or equal to 0. ***" << endl;
				flag = true;
			} else {
				cin.ignore(numeric_limits<streamsize>::max(), '\n');			
				flag = false;
				for (int i=0; i<SIZE; i++){
					if (products[i].getNo() == spec) {
						cout << "*** An item is using that product no.! Please try again. ***" << endl;						
						flag = true;
					} 
				}
			}				
		} while (flag);
	}
	
	return spec;
}

//create new table function (done)
bool createTable() {
	string pname, s;
	double pprice, w, h, l;
	int pno, pqty;
	char confirm;
	
	if (objCount > SIZE) {
		cout << "          List is full! Please clear some space to add more items." << endl;
		cout << "============================================================================" << endl << endl;
		return true;		
	} else {
		cout << "                          Create New Table Record                          " << endl << endl;
		
		pno = validateCreate(pno, 'n');
		cout << endl;
		
		do {
			cout << "Enter product name: ";
			getline(cin, pname);
			
			if (pname == "" || pname == " ")
				cout << "*** Please specify a product name! ***" << endl;
		} while (pname == "" || pname == " ");
		cout << endl;
		
		pprice = validateCreate(pprice, 'p');
		cout << endl;
		
		pqty =  validateCreate(pqty, 'q');
		cout << endl;
		
		w = validateCreate(w, 'w');
		cout << endl;
		
		h =  validateCreate(h, 'h');
		cout << endl;
		
		l = validateCreate(l, 'l');
		cout << endl;
		
		do {
			cout << "Enter product shape: ";
			getline(cin, s);
			
			if (s == "" || s == " ")
				cout << "*** Please specify a product shape! ***" << endl;
		} while (s == "" || s == " ");
		cout << endl;
	
		cout << "----------------------------------------------------------------------------" << endl << endl;
		cout << "                                   Result                                   " << endl << endl	
		 	 << "  Product no. : " << pno << endl << endl
			 << "  Product name: " << pname << endl << endl
			 << "  Product price: " << pprice << endl << endl
			 << "  Product quantity: " << pqty << endl << endl
			 << "  Product width: " << w << endl << endl
			 << "  Product height: " << h << endl << endl
			 << "  Product length: " << l << endl << endl
			 << "  Product shape: " << s << endl << endl;
		
		cout << "============================================================================" << endl << endl;
		
		do {
			cout << "Confirm table creation? (Y/N): ";
			cin >> confirm;
			
			if (toupper(confirm) == 'Y'){
				products[objCount].setNo(pno);
				products[objCount].setName(pname);
				products[objCount].setPrice(pprice);
				products[objCount].setQuantity(pqty);
				products[objCount].setWidth(w);
				products[objCount].setHeight(h);
				products[objCount].setLength(l);
				products[objCount].setShape(s);
				
				objCount++;
				
				cout << endl << "----------------------------------------------------------------------------" << endl << endl;
				cout << "                       -Table creation successful-" << endl;
				cout << "                       -Bringing you back to menu-" << endl << endl;
				cout << "============================================================================" << endl << endl;
	
				return true;
			
			} else if (toupper(confirm) == 'N') {
				cout << endl << "----------------------------------------------------------------------------" << endl << endl;
				cout << "                       -Table creation cancelled-" << endl;
				cout << "                       -Bringing you back to menu-" << endl << endl;
				cout << "============================================================================" << endl << endl;
				
				return true;
			} else {
				cin.ignore(numeric_limits<streamsize>::max(), '\n');
			}
		
		} while (toupper(confirm) != 'Y' && toupper(confirm) != 'N');
	}
}

//edit table details (done)
bool editTable() {
	int target, editSelection;
	bool flag = false, menuBool = false;
	
	cout << "                             Edit Table Record                             " << endl << endl;

	do {
		cout << "Enter target product no. (-1 to quit): ";
		cin >> target;
		

		if (target == -1) {
			cout << endl << "============================================================================" << endl << endl;
			return true;
		} else if (cin.fail()) {
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			cout << "*** Invalid input! Product no. must be an integer (1-100). ***" << endl;
			flag = true;			
		} else {
			int index = -1;
			for (int i = 0; i < SIZE; i++) {
				 if (products[i].getNo() == target) {
					if (target == 0) 
						break;
					else
						index = i;
				}
			}

			if (index == -1){
				cout << "*** No record found for targetted product no. ! ***" << endl << endl;
				cin.ignore(numeric_limits<streamsize>::max(), '\n');
				flag = true;
			} else {
				target = index;
				flag = false;				
			}
		}		
	} while (flag);

	//display details
	do {
		editSelection = showEditMenu(target);
		cin.ignore(numeric_limits<streamsize>::max(), '\n');
		
		if (editSelection == 1) { 
			int newNo;
			newNo= validateEdit(newNo, 'n');
			cout << endl;
			
			products[target].setNo(newNo);
			
			menuBool = true;
		} else if (editSelection == 2) {
			string newName;
			do {
				cout << "Enter new product name: ";
				getline(cin, newName);
				
				if (newName == "" || newName == " ")
					cout << "*** Please specify a product name! ***" << endl;
			} while (newName == "" || newName == " ");
			cout << endl;
			
			products[target].setName(newName);
			
			menuBool = true;
		} else if (editSelection == 3) {
			double newPrice;
			newPrice = validateEdit(newPrice, 'p');
			cout << endl;
			
			products[target].setPrice(newPrice);
			
			menuBool = true;
		} else if (editSelection == 4) {
			int newQuantity;
			newQuantity= validateEdit(newQuantity, 'q');
			cout << endl;
			
			products[target].setQuantity(newQuantity);
			
			menuBool = true;
		} else if (editSelection == 5) {
			double newWidth;
			newWidth = validateEdit(newWidth, 'w');
			cout << endl;
			
			products[target].setWidth(newWidth);
			
			menuBool = true;
		} else if (editSelection == 6) {
			double newHeight;
			newHeight = validateEdit(newHeight, 'h');
			cout << endl;
			
			products[target].setHeight(newHeight);
			
			menuBool = true;
		} else if (editSelection == 7) {
			double newLength;
			newLength = validateEdit(newLength, 'l');
			cout << endl;
			
			products[target].setLength(newLength);
			
			menuBool = true;
		} else if (editSelection == 8){
			string newShape;
			do {
				cout << "Enter new product shape: ";
				getline(cin, newShape);
				
				if (newShape == "" || newShape == " ")
					cout << "*** Please specify a product shape! ***" << endl;
			} while (newShape == "" || newShape == " ");
			cout << endl;
			
			products[target].setShape(newShape);
			
			menuBool = true;
		} else if (editSelection == 9) {
			menuBool = false;
		}
	} while (menuBool);

	return true;
}

bool deleteTable() {
	int target;
	bool flag = false;
	char confirm;
	
	do {
		cout << "Enter product no. to delete (-1 to quit): ";
		cin >> target;
		

		if (target == -1) {
			cout << endl << "============================================================================" << endl << endl;
			return true;
		} else if (cin.fail()) {
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			cout << "*** Invalid input! Product no. must be an integer (1-100). ***" << endl;
			flag = true;			
		} else {
			int index = -1;
			for (int i = 0; i < SIZE; i++) {
				 if (products[i].getNo() == target) {
					if (target == 0) 
						break;
					else
						index = i;
				}
			}

			if (index == -1){
				cout << "*** No record found for targetted product no. ! ***" << endl << endl;
				cin.ignore(numeric_limits<streamsize>::max(), '\n');
				flag = true;
			} else {
				target = index;
				flag = false;				
			}
		}		
	} while (flag);

	cout << "----------------------------------------------------------------------------" << endl << endl;
	cout << "                                   Result                                   " << endl << endl	
	 	 << "  Product no. : " << products[target].getNo() << endl << endl
		 << "  Product name: " << products[target].getName()  << endl << endl
		 << "  Product price: " << products[target].getPrice()  << endl << endl
		 << "  Product quantity: " << products[target].getQuantity()  << endl << endl
		 << "  Product width: " << products[target].getWidth()  << endl << endl
		 << "  Product height: " << products[target].getHeight()  << endl << endl
		 << "  Product length: " << products[target].getLength()  << endl << endl
		 << "  Product shape: " << products[target].getShape()  << endl << endl;
	
	cout << "============================================================================" << endl << endl;
	
	do {
		cout << "Confirm table deletion? (Y/N): ";
		cin >> confirm;
	
	//delete that entry & shift array elem to left
	//delete by replacing with the next elem until the end
		if (toupper(confirm) == 'Y'){
		
			for (int i = target; i<objCount; i++) {
				products[i].setNo(products[i+1].getNo());	
				products[i].setName(products[i+1].getName());
				products[i].setPrice(products[i+1].getPrice());
				products[i].setQuantity(products[i+1].getQuantity());
				products[i].setWidth(products[i+1].getWidth());
				products[i].setHeight(products[i+1].getHeight());
				products[i].setLength(products[i+1].getLength());
				products[i].setShape(products[i+1].getShape());	
			}
			objCount--;
			
			cout << endl << "----------------------------------------------------------------------------" << endl << endl;
			cout << "                       -Table deletion successful-" << endl;
			cout << "                       -Bringing you back to menu-" << endl << endl;
			cout << "============================================================================" << endl << endl;

			return true;
			
		} else if (toupper(confirm) == 'N') {
			cout << endl << "----------------------------------------------------------------------------" << endl << endl;
			cout << "                       -Table deletion cancelled-" << endl;
			cout << "                       -Bringing you back to menu-" << endl << endl;
			cout << "============================================================================" << endl << endl;
			
			return true;
		} else {
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
		}
		
	} while (toupper(confirm) != 'Y' && toupper(confirm) != 'N');
}

bool printRecord() {
	int target;
	bool flag = false;
	
	do {
		cout << "Enter target product no. (-1 to quit): ";
		cin >> target;
		

		if (target == -1) {
			cout << endl << "============================================================================" << endl << endl;
			return true;
		} else if (cin.fail()) {
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			cout << "*** Invalid input! Product no. must be an integer (1-100). ***" << endl;
			flag = true;			
		} else {
			int index = -1;
			for (int i = 0; i < SIZE; i++) {
				 if (products[i].getNo() == target) {
					if (target == 0) 
						break;
					else
						index = i;
				}
			}

			if (index == -1){
				cout << "*** No record found for targetted product no. ! ***" << endl << endl;
				cin.ignore(numeric_limits<streamsize>::max(), '\n');
				flag = true;
			} else {
				target = index;
				flag = false;				
			}
		}		
	} while (flag);
	// confirm input end
	
	//display info
	cout << "----------------------------------------------------------------------------" << endl << endl;
	cout << "                                   Result                                   " << endl << endl;	
	products[target].display();
	cout << "============================================================================" << endl << endl;
	return true;
}

bool printAllRecords(){
	

	if (objCount > 0) {
			//rearrange ascending before listing
		for(int i = 0; i<objCount-1; i++) {
			if (products[i+1].getNo() < products[i].getNo()){
				Table temp;
					temp.setNo(products[i+1].getNo());	
					temp.setName(products[i+1].getName());
					temp.setPrice(products[i+1].getPrice());
					temp.setQuantity(products[i+1].getQuantity());
					temp.setWidth(products[i+1].getWidth());
					temp.setHeight(products[i+1].getHeight());
					temp.setLength(products[i+1].getLength());
					temp.setShape(products[i+1].getShape());	
			
				products[i+1].setNo(products[i].getNo());	
				products[i+1].setName(products[i].getName());
				products[i+1].setPrice(products[i].getPrice());
				products[i+1].setQuantity(products[i].getQuantity());
				products[i+1].setWidth(products[i].getWidth());
				products[i+1].setHeight(products[i].getHeight());
				products[i+1].setLength(products[i].getLength());
				products[i+1].setShape(products[i].getShape());	
				
				products[i].setNo(temp.getNo());	
				products[i].setName(temp.getName());
				products[i].setPrice(temp.getPrice());
				products[i].setQuantity(temp.getQuantity());
				products[i].setWidth(temp.getWidth());
				products[i].setHeight(temp.getHeight());
				products[i].setLength(temp.getLength());
				products[i].setShape(temp.getShape());	
			}
		}
		
		cout << "                                   Result                                   " << endl << endl;	
		cout << "----------------------------------------------------------------------------" << endl
			 << "No.  Name            Price    Qty     Width    Height   Length   Shape      " << endl
			 << "----------------------------------------------------------------------------" << endl;
			 
		for (int i=0; i<objCount; i++) {
			cout << setw(5) << left;
			cout << products[i].getNo();
			
			cout << setw(16) << left;
			cout << products[i].getName();
		
			cout << setw(9) << left;
			cout << products[i].getPrice();
		
			cout << setw(8) << left;
			cout << products[i].getQuantity();
		
			cout << setw(9) << left;
			cout << products[i].getWidth();
		
			cout << setw(9) << left;
			cout << products[i].getHeight();
		
			cout << setw(9) << left;
			cout << products[i].getLength();
		
			cout << setw(11) << left;
			cout << products[i].getShape();
			
			cout << endl;
		}
		
		cout << endl << "============================================================================" << endl << endl;
		
		return true;
	} else {
		cout << "                                   Result                                   " << endl << endl;	
		cout << "----------------------------------------------------------------------------" << endl
			 << "No.  Name            Price    Qty     Width    Height   Length   Shape      " << endl
			 << "----------------------------------------------------------------------------" << endl
			 << "                                  NO RECORD                                 " << endl
		     << endl << "============================================================================" << endl << endl;	 
		
		return true;
	}
}

int main() {
	char exitInput;
	bool conti = false;
	

	cout << endl << endl << "-----===*         Welcome to the Product Management System         *===-----" << endl << endl;
	do {
		int choice = showMenu();
		
		//dev note: for each choices, at the end must determine conti bool value, usually prolly true
		if (choice == 1) {
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			conti = createTable();
		} else if (choice == 2) {
			conti = editTable();
		} else if (choice == 3) {
			conti = deleteTable();
		} else if (choice == 4) {
			conti = printRecord();
		} else if (choice == 5) {
			conti = printAllRecords();
		} else if (choice == 6) {
			do{
				cout << "Are you sure? (Y/N): ";
				cin >> exitInput;
				
				if (toupper(exitInput) == 'Y') {
				
					cout << endl << "*** See you next time, Goodbye! ***" << endl;
					cout << endl << "============================================================================";				
					conti = false;
				} else if (toupper(exitInput) == 'N') {
					conti = true;
					cout << endl << "============================================================================" << endl << endl;
				} else 
					cin.ignore(numeric_limits<streamsize>::max(), '\n');
					
			} while (toupper(exitInput) != 'Y' && toupper(exitInput) != 'N');
		}
	} while (conti == true);
	
	return 0;
}

Table::Table() {
	width = 1.0;
	height = 1.0;
	length = 1.0;
	shape = "Unknown";
}

Table::Table(double w, double h, double l, string s) {
	width = w;
	height = h;
	length = l;
	shape = s;
}

void Table::setWidth(double nw) {
	width = nw;
}

void Table::setHeight(double nh) {
	height = nh;
}

void Table::setLength(double nl) {
	length = nl;
}

void Table::setShape(string nshape) {
	shape = nshape;
}

double Table::getWidth() {
	return width;
}

double Table::getHeight() {
	return height;
}

double Table::getLength() {
	return length;
}

string Table::getShape() {
	return shape;
}

void Table::display() {
	cout << "  Product No.: " << getNo() << endl << endl
		 << "  Product Name: " << getName() << endl << endl
		 << "  Price: " << getPrice() << endl << endl
		 << "  Quantity: " << getQuantity() << endl << endl
		 << "  Width: " << width << endl << endl
		 << "  Height: " << height << endl << endl
		 << "  Length: " << length << endl << endl
		 << "  Shape: " << shape << endl << endl;
}

Product::Product() {
	productNo = 0;
	productName = "Name Unknown";
	price = 0.0;
	quantity = 0;
}

Product::Product(int no, string name, double p, int q) {
	productNo = no;
	productName = name;
	price = p;
	quantity = q;
}

void Product::setNo(int no) {
	productNo = no;
}

void Product::setName(string name) {
	productName = name;
}

void Product::setPrice(double p) {
	price = p;
}

void Product::setQuantity(int q) {
	quantity = q;
}

int Product::getNo() {
	return productNo;
}

string Product::getName() {
	return productName;
}

double Product::getPrice() {
	return price;
}

int Product::getQuantity() {
 	return quantity;
}

void Product::display() {
	cout << "Product No.: " << productNo << endl << endl
		 << "Product Name: " << productName << endl << endl
		 << "Price: " << price << endl << endl
		 << "Quantity: " << quantity << endl << endl;
}
