#include <iostream>
#include <limits>
using namespace std;

struct TreeNode {
	int data;
	TreeNode *left = NULL;
	TreeNode *right = NULL;
	
	/*optional constructor
	  If implemented, all initialized nodes must have a data
	  If not implemented, data needs to be assigned by using member accessor, node->data */
	TreeNode(int d) {
		data = d;
	}
};

struct TreeNode *root;

int memFull = 0;
//recursive insert function
TreeNode* insertNode(TreeNode* current, int data) {
	TreeNode *newNode = new TreeNode(data);
	//if no memory is allocated for newNode, memory is full
	if (!newNode) {
		//sentinel value to check if memory is full
		memFull = 1;
		//return original value
		return current;
	} else if (current == NULL) { 
	// recursion base case, return newNode when current = NULL
		return newNode;
	} else if (data < current->data) 
	// assign to the left child if lower than parent data
		current->left = insertNode(current->left, data); 
	else 
	// assign to right child if greater/equal to parent data
		current->right = insertNode(current->right, data);
	
	//return updated subtree
	return current;
}

TreeNode* findMinNode(TreeNode* rootNode) {
	//loops until deepest leftmost node is found
	while(rootNode->left != NULL) {
		rootNode = rootNode->left;
	}
	return rootNode;
}

int dltFound = 0;
//recursive delete function
TreeNode* deleteNode(TreeNode* current, int data) {
	if (current == NULL)
	//if node is not found, return NULL
		return current;
	else if (data < current->data) 
	//if target node lower than current node, go to left subtree
		current->left = deleteNode(current->left, data);
 	else if (data > current->data)
	//if target node greater than/equal to current node, go to right subtree
		current->right = deleteNode(current->right, data);
 	//Matching node found, processing delete
 	else {
	 	//case 1: no children
		if (current->left == NULL && current->right == NULL) {
	 		delete current;
			current = NULL;
		//case 2: 1 child
		} else if (current->right == NULL) { //1 left child
			TreeNode* temp = current;
			current = current->left;
			delete temp;
		} else if (current->left == NULL) { //1 right child
			TreeNode* temp = current;
			current = current->right;
			delete temp;
		//case 3: 2 children
		} else {
			//find the inorder successor in the right subtree
			TreeNode* temp = findMinNode(current->right);				
			//replace current data with the successor's
			current->data = temp->data;
			//delete the successor(duplicate now) from the right subtree
			//successor is either leaf node/node with right child so we can
			//just call the func recursively
			current->right = deleteNode(current->right,temp->data);
		}
		
		//sentinel value to detect node is found/not found
		dltFound = 1; 
		//return updated subtree after deletion
		return current;
	}
}

//recursive search function
TreeNode* searchNode(TreeNode* rootNode, int data) {
	//if data not found
	if (rootNode == NULL)
		//return NULL
		return rootNode;
	else if (data < rootNode->data) {
	//if data smaller than parent, go to left subtree
		cout << "left->";
		return searchNode(rootNode->left, data); 
	} else if (data > rootNode->data) {
	//if data smaller than parent, go to right subtree
		cout << "right->";
		return searchNode(rootNode->right, data);
	//if data is found
	} else {
		//return the node address 
		return rootNode;
	}
}

//recursive traversal function
void inorderTraverse(TreeNode* rootNode) {
	if (rootNode == NULL) //base case
		return;
	/*Order of printing:
		1. root's left child's data	
		2. root's data
		3. root's right child's data
	Functions will pause when they encounter child nodes that also have children
	and will proceed to work from the deepest, leftmost leaf nodes 
	*/
	inorderTraverse(rootNode->left);
	cout << rootNode->data << " -> ";
	inorderTraverse(rootNode->right);
}

void preorderTraverse(TreeNode* rootNode){
	if (rootNode == NULL)
		return;
	/*similar logic but different order:
		1. root's data 
		2. root's left child's data	
		3. root's right child's data
	*/
	cout << rootNode->data << " -> ";
	preorderTraverse(rootNode->left);
	preorderTraverse(rootNode->right);
}

void postorderTraverse(TreeNode* rootNode){
	if (rootNode == NULL)
		return;
	/*similar logic but different order:
		1. root's left child's data	
		2. root's right child's data
		3. root's data 
	*/
	preorderTraverse(rootNode->left);
	preorderTraverse(rootNode->right);
	cout << rootNode->data << " -> ";
}

int getNumber(string text) {
	int num;
	bool hasError = true;
	
	do {
		cout << text;
		cin >> num;
		cin.ignore(numeric_limits<streamsize>::max(), '\n');
		if (cin.fail()) {
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			cout << "\n* * * Invalid input. Please enter a numeric value * * *\n";
			hasError = true;
		} else {
			hasError = false;
		}
	} while (hasError);
	
	return num;
}

int main() {
	// Variables
	int menuInput, num;
	char exitInput;
	bool isEnded = false;
	
	cout << "WELCOME TO BINARY (SEARCH) TREE DEMO PROGRAM\n";
	
	// Loop program until isEnded is true
	do {
		// Display menu
		cout << "\n1. Add node"
			 << "\n2. Delete node"
			 << "\n3. Search node"
			 << "\n4. Display nodes"
			 << "\n5. Exit\n\n";
			 
		// Prompt user to selection function
		do {
			menuInput = getNumber("Selection: ");
			if (menuInput < 1 || menuInput > 5) {
				cout << "\n* * * Invalid input, please enter 1 - 5 * * *\n";
			}
		} while (menuInput < 1 || menuInput > 5);
		
		// Process user's menu input
		if (menuInput == 1) {
			num = getNumber("\nPlease enter a number to add: ");
			root = insertNode(root, num);
			if (memFull == 1) {
				cout << "Memory full!" << endl;
				memFull = 0;
			} else
				cout << "Node " << num << " has been added" << endl; 
		} else if (menuInput == 2) {
			num = getNumber("\nPlease enter a number to delete: ");
			root = deleteNode(root, num);
			if (dltFound == 1){
				cout << num << " has been deleted" << endl;
				dltFound = 0;
			} else
				cout << num << " does not exist!" << endl;
		} else if (menuInput == 3) {
			TreeNode *temp = root;
			num = getNumber("\nPlease enter a number to search: ");
			cout << "Pathway: root->";
			temp = searchNode(temp, num);
			//display the pathway taken
			if (temp != NULL) {
				cout << "(node)" << endl;
				cout << num << " is found in the tree!" << endl;
			} else {
				cout << "NULL" << endl;
				cout << num << " does not exist!" << endl;
			}
		} else if (menuInput == 4) {
			cout << "Inorder Traversal: ";
			inorderTraverse(root);
			cout << "NULL" << endl;
			cout << "Preorder Traversal: ";
			preorderTraverse(root);
			cout << "NULL" << endl;
			cout << "Postorder Traversal: ";
			postorderTraverse(root);
			cout << "NULL" << endl;
		} else if (menuInput == 5) {
			isEnded = true;
		}
	} while (!isEnded);
	
	return 0;
}

