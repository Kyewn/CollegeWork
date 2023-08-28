#include <iostream>
using namespace std;

struct node {
	int info;
	struct node *link;
} *top = NULL;

void push(int newInfo) {
	struct node *newNode = new node;
	newNode->info = newInfo;
	newNode->link = top;
	top = newNode;
}

// display function cannot directly use top:
// We need to make a new ptr that imitates top, so top wont change positions (need to let it keep pointing to the first element)
void display() {
	struct node *current = top;
	while (current != NULL) {
		cout << current->info << " -> ";
		current = current->link;
	}
	cout << "NULL" << endl;
}

int pop() {
	if (top == NULL) {
		cout << "Stack Underflow" << endl;
	} else {
		int poppedInfo = top->info;
		top = top->link;
		return poppedInfo;
	}
}

bool isEmpty() {
	if (top == NULL) return true;
	else return false;
}

int main() {
	cout << "initial content: ";
	display();
	push(2);
	push(3);
	push(1);
	cout << "after adding content: ";
	display();
	pop();
	pop();
	cout << "after popping 2 elems: ";
	display();
	cout << "isEmpty? " << isEmpty() << endl;
	pop();
	cout << "isEmpty? " << isEmpty();
	return 0;
}
