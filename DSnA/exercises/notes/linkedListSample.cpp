#include <iostream>
using namespace std;

struct Node {
	int data;
	Node *link = NULL;
};

Node *head = NULL;
	
/* Linked lists:
Let system directly access actual memory location by **head,
it is probably used since it is passed as parameter in a func, making it a local parameter 
that does not refer to the original head. stackSample works since origin isn't passed as 
a parameter to its functions

Modification (insert, delete) operations should check for 
	- List is empty or not
	- Position of operation
		- at the beginning
		- in the middle
		- at the end
	- Having a 'prev' ptr when traversing to get the previous node
		(to be used for switching node addresses later on)
	
Deletion should check if 
	-the deletion is successful or not
	
All operations don't forget system messages.
*/	
	
void insertNode(int data, Node **head) {
	Node *newNode = new Node;
	Node *temp = *head;
	newNode->data = data;
	
	if (*head == NULL)
		//if linked list is empty
		*head = newNode;
	else {
		Node *prev = temp;
		//else if have nodes
		while (temp != NULL) { // loop until a position is found (3,5,6 | insert 4, so between 3,5)
			if (data > temp->data) {//if the upcoming node's value is larger, reference deeper nodes (3,5 | 5 is larger, so temp stays at 3)
				prev = temp;
				temp = temp->link;
			} else
				break;
		}
		//once done
		if (temp == NULL)
			prev->link = newNode;
		else if (temp == *head) {
			newNode->link = temp;
			*head = newNode;
		} else {
			newNode->link = temp; //assign the link addresses
			prev->link = newNode;
		}
	}
	cout << "Node added successfully!" << endl << endl;
}

void deleteNode(int data, Node **head) {
	Node *prev, *current = *head;
	
	if (*head == NULL) {
		cout << "List is empty!" << endl << endl;
		return;
	}

	while (current != NULL) {
		if (current->data != data) {
			prev = current;
			current = current->link;
		} else break;
	}
	
	if (current == NULL)
		cout << "Target node not found!" << endl << endl;
	else {
		if (current == *head) { //Case 1: deletion at head
			*head = (*head)->link;
		} else {		//Case 2,3: deletion in between nodes and at the end of list
			prev->link = current->link;
		}
		cout << "Node "<< data << " deleted successfully!" << endl << endl;	
	}
}

void displayNodes(Node *head) {
	cout << "Linked list: ";
	while (head != NULL) {
		cout << head->data << " ";
		head = head->link;
	}
	cout << "NULL" << endl << endl;
}

int main() {
	int selection;
	
	while (true) {
		cout << "1. Insert node" << endl;
		cout << "2. Delete node" << endl;
		cout << "3. Display node" << endl;
		cout << "4. Exit" << endl;
		do {
			cout << "Enter your selection: ";
			cin >> selection;
			if (selection < 1 || selection > 5)
				cout << "Invalid input" << endl << endl;
		} while (selection < 1 || selection > 5);
		
		if (selection == 1) {
			int data;
			cout << "\nEnter new node's value: ";
			cin >> data;
			insertNode(data, &head);
		} else if (selection == 2) {
			int data;
			cout << "\nEnter target node's value: ";
			cin >> data;
			deleteNode(data, &head);
		} else if (selection == 3) {
			displayNodes(head);
		} else break;
	}	
	return 0;
}
