#include <iostream>
using namespace std;;

struct QNode {
	int data;
	QNode *next = NULL;
};

/*Reason why pointer of pointer is used (**ptr): https://stackoverflow.com/questions/7271647/what-is-the-reason-for-using-a-double-pointer-when-adding-a-node-in-a-linked-lis*/
void enqueueNode(int data, QNode **front, QNode **back);
void dequeueNode(QNode **front, QNode **back);
void displayNodes(QNode *front);
void peek(QNode *front);

int main() {
	int selection;
	QNode *front = NULL, *back = NULL;
	
	while (true) {
		cout << "1. Enqueue node" << endl;
		cout << "2. Dequeue node" << endl;
		cout << "3. Display queue" << endl;
		cout << "4. Peek" << endl;
		cout << "5. Exit" << endl;
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
			enqueueNode(data, &front, &back);
		} else if (selection == 2) {
			dequeueNode(&front, &back);
		} else if (selection == 3) {
			displayNodes(front);
		} else if (selection == 4) {
			peek(front);
		} else break;
	}
	return 0;
}


void enqueueNode(int data, QNode **front, QNode **back) {
	QNode *newNode = new QNode;
	newNode->data = data;
	if (*front == NULL) {
		*front = newNode;
		*back = newNode;
	} else {
		(*back)->next = newNode;
		*back = newNode;
	}
	cout << "Node enqueued successfully!" << endl << endl;
}

void dequeueNode(QNode **front, QNode **back) {
	QNode *temp = *front;
	if (*front != NULL) {
		int deletedData = (*front)->data;
		*front = (*front)->next;
		delete temp;
		cout << "Dequeue successful, deleted node: " << deletedData << endl << endl;
	} else
		cout << "Dequeue failed, queue is empty!" << endl << endl;	
}

void displayNodes(QNode *front) {
	if (front == NULL)
		cout << "Queue is empty!" << endl << endl;
	else {
		cout << "Front-> ";
		while (front != NULL) {
			cout << front->data << " ";
			front = front->next;
		}
		cout << "<-Back" << endl << endl;
	}
}

void peek(QNode *front) {
	if (front == NULL)
		cout << "Queue is empty!" << endl << endl;
	else
		cout << "Front: " << front->data << endl << endl;
}

