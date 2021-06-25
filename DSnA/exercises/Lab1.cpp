#include <iostream>
using namespace std;

const int SIZE = 5;

int menu();
void displayAll(int arr[SIZE]);
void countLess50(int arr[SIZE]);
void displayHigh(int arr[SIZE]);
void displayAvg(int arr[SIZE]);
void displayMTAvg(int arr[SIZE]);

int main() {
	int marks[SIZE], input;
	double average = 0;
	
	for(int i=0; i<SIZE; i++ ) {
		do {
			cout << "Enter mark " << i+1 << ": ";
			cin >> input;
			if (input > 100 || input < 0)
				cout << "Range of marks is (0-100)!" << endl;
			else
				marks[i] = input;
		} while(input > 100 || input < 0);
	};
	
	int choice;
	do{
		choice = menu();
		if (choice == 1) {
			displayAll(marks);
		} else if (choice == 2) {
			countLess50(marks);
		} else if (choice == 3) {
			displayHigh(marks);
		} else if (choice == 4) {
			displayAvg(marks);
		} else if (choice == 5) {
			displayMTAvg(marks);
		} else if (choice == 6) {
			break;
		} else {
			cout << "Invalid choice! Try again" << endl << endl;
		}
	} while(true);
	/*
	high = marks[4];
	low = marks[0];
	
	for (int i=0; i<SIZE; i++) {
		if (marks[i] >= high) 
			high = marks[i];
		else if (marks[i] <= low)
			low = marks[i];
	}
	
	for (int i=0; i<SIZE; i++) {
		average += marks[i];
	}
	average/=5.0;
	
	cout << endl << "Average mark: " << average << endl
		 << "Highest mark: " << high << endl
		 << "Lowest mark: " << low << endl;
	*/
	
	
	
	return 0;
}

int menu() {
	int input;
	cout << endl << "Results are out" << endl << endl
		<< "1. Display all numbers" << endl
		<< "2. Count numbers less than 50" << endl
		<< "3. Display highest number" << endl
		<< "4. Calculate average" << endl
		<< "5. Display numbers more than average" << endl
		<< "6. Exit" << endl << endl;
	cout << "Selection: ";
	cin >> input;
	cout << endl;
	return input;
}

void displayAll(int arr[SIZE]) {
	for (int i=0; i<SIZE; i++) {
		cout << arr[i] << " ";
	}
	cout << endl << "================================" << endl;
}

void countLess50(int arr[SIZE]) {
	int ctr = 0;
	for (int i=0; i<SIZE; i++) {
		if(arr[i] < 50)
			ctr++;		
	}
	cout << "Numbers less than 50: " << ctr << endl;
	cout << "================================" << endl;
}

void displayHigh(int arr[SIZE]){
	int high = arr[0];
	for (int i=1; i<SIZE; i++) {
		if (arr[i] > high)
			high = arr[i]; 
	}
	cout << "Highest number: " << high << endl;
	cout << "================================" << endl;
	
}

void displayAvg(int arr[SIZE]) {
	double avg;
	for (int i=0; i<SIZE; i++) {
		avg += arr[i];
	}
	avg/=5.0;
	cout << "Total average: " << avg << endl;
	cout << "================================" << endl;
}

void displayMTAvg(int arr[SIZE]){ 
	double avg;
	for (int i=0; i<SIZE; i++) {
		avg += arr[i];
	}
	avg/=5.0;
	
	int arr2[SIZE];
	for (int i=0; i<SIZE; i++) {
		if (arr[i] > avg)
			arr2[i] = arr[i]; 
	}
	
	cout << "Numbers more than average: ";
	for(int i=0;i<SIZE; i++) {
		if (arr2[i] == arr[i])
			cout << arr2[i] << " ";
	}
	cout << endl << "================================" << endl;
}
