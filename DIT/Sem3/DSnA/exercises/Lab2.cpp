#include <iostream>
using namespace std;

const int SIZE = 5;

struct Student {
	string id;
	double mark;
	char grade;
};

int main() {
	Student stuArr[SIZE];
	string id;
	double mark;
	char grade;
	
	for (int i=0;i<SIZE;i++) {
		cout << "Enter ID for student " << i+1 << ": ";
		cin >> id;
		cout << "Enter mark for student " << i+1 << ": ";
		cin >> mark;
		cout << "Enter grade for student " << i+1 << ": ";
		cin >> grade;
		
		stuArr[i].id = id;
		stuArr[i].mark = mark;
		stuArr[i].grade = grade;
		
		cout << endl;
	}
	
	cout << "=====================" << endl;
	cout << "Print all data" << endl;
	
	for (int i=0;i<SIZE;i++) {
		cout << "Student " << i+1 << endl;
		cout << "ID: " << stuArr[i].id << endl
			 << "Mark: " << stuArr[i].mark << endl 
			 << "Grade: " << stuArr[i].grade << endl << endl;
	}
	
	cout << "=====================" << endl;
	cout << "Print students with grade A" << endl;
	
	for (int i=0;i<SIZE;i++) {
		if (stuArr[i].grade == 'A') {
			cout << "Student " << i+1 << endl;
			cout << "ID: " << stuArr[i].id << endl
			 	 << "Mark: " << stuArr[i].mark << endl 
			 	 << "Grade: " << stuArr[i].grade << endl << endl;
		}
	}
	
	cout << "=====================" << endl;
	cout << "Count students with grade C" << endl;
	
	int ctr = 0;
	for (int i=0;i<SIZE;i++) {
		if (stuArr[i].grade == 'C') {
			ctr++;
		}
	}
	cout << "There are " << ctr << " student(s) who got grade \'C\'" << endl;
	
	return 0;
}
