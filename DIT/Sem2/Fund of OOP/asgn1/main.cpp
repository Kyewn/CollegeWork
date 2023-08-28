#include <iostream>
#include <iomanip>		// For input handling and menu output customization
#include <string>		// For using string functions
#include <cctype>		// For toupper()
#include <limits>		// For numeric_limits<streamsize>::max() in cin.ignore()
#include <vector>		// For using vectors - candidates and candidateInfo
using namespace std;

// Function declarations
int showMenu();
void addCandidate();
void checkRecords();
int getMarks(string criterion);

// Vector initialization
vector< vector<string> > candidates;
vector<string> candidateInfo;

int main() {
	// Declare menu variables
	int menuInput;
	char exitInput;
	bool isEnded = false;
	
	// Print welcome message
	cout << "Welcome to Practical Music Examination Grading System\n\n";
	
	// Flag-controlled do...while loop, ends if isEnded == true
	do {
		// Show the menu and assign selection value to menuInput
		menuInput = showMenu();
		
		// Redirect user to selected function
		if (menuInput == 1) {
			addCandidate();
			isEnded = false;
		} else if (menuInput == 2) {
			checkRecords();
			isEnded = false;
		} else if (menuInput == 3) {
			// Exit
			do {
				cout << "Are you sure? (Y/N): ";
				cin >> exitInput;
				// Flush input stream incase user types more than one char,
				// which may result in the extra input going into the next cin -> SELECTION input
				cin.ignore(numeric_limits<streamsize>::max(), '\n');
				exitInput = toupper(exitInput);
				
				if (exitInput == 'Y') {
					isEnded = true;
				} else if (exitInput == 'N') {
					isEnded = false;
				}
			} while (exitInput != 'Y' && exitInput != 'N');
		}
	} while (isEnded == false);
	
	return 0;
}

int showMenu() {
	// Declare variables
	int selection;
	bool menuBool = true;
	
	do {
		// Display the menu
		cout.fill('_');
		cout << endl << setw(46) << right << "_\n";
		cout.fill(' ');
		cout << setw(23) << right << "Menu\n";
		cout.fill('_');
		cout << setw(46) << right << "_\n";
		cout << "\n          " << "1. Add candidate\n"
			 << "          " << "2. Check records\n"
			 << "          " << "3. Exit\n";
		
		// Handle user input
		cout << "\nSelection: ";
		cin >> selection;
		// If user input does not match datatype of variable, cin will enter fail state (do...while loops infinitely)
		// this if block below clears fail state and flushes "bad input" from input stream
		if (cin.fail()) {
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
		} else {
			// Flush input stream regardless of fail state
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
		}
		
		// Check input
		if (selection < 1 || selection > 3) {
			cout << "\n* * * Invalid input. Please input 1, 2, or 3. * * *\n";
			menuBool = true;
		} else {
			menuBool = false;
		}
		
	} while (menuBool == true);
	
	return selection;
}

void addCandidate() {
	// Declare variables to store candidate info and marks for criteria
	string name, icNumber, grade;
	int gradeLevel, pitch, time, tone, shape, performance, totalMarks;
	
	// Variables used for the condition of outer do...while loop
	bool isStopped = false;
	char confirmation;
	
	do {
		// Prompt for and record candidate details into temporary vector
		cout << "\n\nPlease key in the candidate's details.\n";
		cout.fill('_');
		cout << setw(84) << right << "_\n";
		
		// Prompt for name
		do {
			cout << "Name: ";
			getline(cin, name);
			if (name.length() > 30)
				cout << "* * * Name cannot be longer than 30 characters * * *\n";
		} while (name.length() > 30);
		candidateInfo.push_back(name);
		
		// Prompt for I/C Number
		do {
			cout << "Identity Card Number: ";
			getline(cin, icNumber);
			if (icNumber.length() > 12)
				cout << "* * * I/C Number cannot be more than 12 characters * * *\n";
		} while (icNumber.length() > 12);
		candidateInfo.push_back(icNumber);
		
		// Prompt for Grade Level
		do {
			cout << "Grade level: ";
			cin >> gradeLevel;
			if (cin.fail()) {
				cout << "* * * Invalid input * * *\n";
				cin.clear();
				cin.ignore(numeric_limits<streamsize>::max(), '\n');
			} else {
				if (gradeLevel < 1 || gradeLevel > 8)
					cout << "* * * Grade level ranges from 1 to 8 * * *\n";
				cin.ignore(numeric_limits<streamsize>::max(), '\n');
			}
		} while (gradeLevel < 1 || gradeLevel > 8);
		candidateInfo.push_back(to_string(gradeLevel));
		
		// Prompt for candidate's marks for each criterion
		cout << "\nPlease key in the marks for each marking criterion. (0 - 30 marks per criterion)\n";
		cout.fill('_');
		cout << setw(84) << right << "_\n";
		
		pitch = getMarks("Pitch");
		time = getMarks("Time");
		tone = getMarks("Tone");
		shape = getMarks("Shape");
		performance = getMarks("Performance");
		
		// Calculate total marks and store in temporary vector
		totalMarks = pitch + time + tone + shape + performance;
		candidateInfo.push_back(to_string(totalMarks));
		
		// Determine grade and store in temp vector
		if (totalMarks >= 130) {
			grade = "Distinction";
		} else if (totalMarks >= 120 && totalMarks <= 129) {
			grade = "Merit";
		} else if (totalMarks >= 100 && totalMarks <= 119) {
			grade = "Pass";
		} else if (totalMarks < 100) {
			grade = "Fail";
		}
		candidateInfo.push_back(grade);
		
		// Display final marks and grade
		cout.fill('_');
		cout << setw(84) << right << "_";
		cout << "\n| Total marks: " << totalMarks
			 << " | Grade: " << grade << " |\n\n";
		
		// Add this candidate's info, marks, and grade (in temp vector) into 2D vector "candidates"
		// Then clear the temporary vector used for this current candidate
		candidates.push_back(candidateInfo);
		candidateInfo.clear();
		
		// Ask user if they want to continue or return to menu
		do {
			cout << "Do you want to grade another candidate? (Y/N): ";
			cin >> confirmation;
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			
			confirmation = toupper(confirmation);
			if (confirmation == 'Y') {
				isStopped = false;
			} else if (confirmation == 'N') {
				isStopped = true;
			}
		} while (confirmation != 'Y' && confirmation != 'N');
		
	} while (isStopped == false);
}

void checkRecords() {
	// Check if candidates vector is empty
	if (candidates.empty()) {
		cout << endl;
		cout.fill('=');
		cout << setw(116) << right << "=\n";
		cout.fill(' ');
		cout << setw(63) << right << "NO RECORDS";
		cout.fill('=');
		cout << setw(116) << left << "\n=";
		cout << endl;
	} else {
		// Print table if candidates vector is not empty
		// Print table header
		cout << endl;
		cout.fill('=');
		cout << setw(116) << right << "=\n";
		cout.fill(' ');
		cout << setw(6) << left << "No.";
		cout << setw(34) << left << "Name";
		cout << setw(19) << left << "I/C Number";
		cout << setw(19) << left << "Grade Level";
		cout << setw(19) << left << "Total Marks";
		cout << setw(19) << "Grade";
		cout.fill('=');
		cout << setw(116) << left << "\n=";
		cout << endl;
		
		// Print table contents
		cout.fill(' ');
		for (int i = 0; i < candidates.size(); i++) {
			cout << i + 1 << ".    ";
			
			for (int j = 0; j < candidates[i].size(); j++) {
				// Larger space for Name column, smaller space for subsequent columns
				if (j == 0) {
					cout << setw(34) << left << candidates[i][j];
				} else {
					cout << setw(19) << left << candidates[i][j];
				}
			}
			cout << endl;
		}
	}
}

int getMarks(string criterion) {
	int marks;
	
	// Prompt user for marks
	do {
		cout << criterion << ": ";
		cin >> marks;
		// Catch invalid inputs that may cause cin fail state
		// Then check if marks is valid
		if (cin.fail()) {
			cout << "* * * Invalid input * * *\n";
			marks = 69;
			// Clear fail state
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
		} else {
			if (marks < 0 || marks > 30) {
				cout << "* * * Marks must be within "
					 << "the range of 0 - 30 * * *\n";
			}
			// Flush input stream to get rid of any excess input
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
		}
	} while (marks < 0 || marks > 30);
	
	return marks;
}
