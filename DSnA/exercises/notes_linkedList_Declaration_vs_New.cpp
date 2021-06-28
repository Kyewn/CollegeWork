/*		
	- ref: https://stackoverflow.com/questions/25954344/why-create-heap-when-creating-a-linked-list-when-we-can-simply-do-this
		   https://stackoverflow.com/questions/79923/what-and-where-are-the-stack-and-heap?noredirect=1&lq=1
		   https://stackoverflow.com/questions/5836309/stack-memory-vs-heap-memory
			   
		- HEAP VS STACK
		- declare newNode vs allocate memory using new and point a ptr to it (why use "new" instead of declaration?)
		
		- Lets say we want to use a function to add a new node into the linked list:
		- Sure we can use basic declaration "node newNode", assign its values "newNode.data = data; newNode.next = NULL", point the head to its ADDRESS "head = &newNode"
		- This works perfectly fine, however after the function finishes executing, this node would be deleted (it would be replaced with a garbage value in the linked list)
		- Why?: Function calls are added to the STACK, once the function finishes executing, it is REMOVED from the STACK (STACK holds parameters of function calls, and stores local variables)
				If you declare new node using "node newNode", this node variable is assigned a memory space in the STACK as well
				Since this node variable is inside the function instance (it is a local variable in this function)
				What happens when the function call ends? Yes, the newNode variable gets removed from the stack (it no longer exists)
				So, if you try to access this node in the linked list from the MAIN function, you'd get unexpected values / errors (to be determined upon further research)
				
				OF COURSE: If you do this method in the MAIN function, there should be no problems, however if you dont know how many nodes you need,
						   or if you need many many nodes, it is pointless. Imagine declaring node1 node2 node3 node4 node5 and so on (which brings us
						   back to the point of using functions, which also brings us back to the point that declaring it as "node newNode" in a function
						   is not recommended as it is removed from the stack when the function finishes executing
		
		- OOOH SO THATS WHY WE USE "node *newNode = new node", but why exactly?:
		- "new" allocates memory in the HEAP
		- HEAP is dynamic memory in which its data exists THROUGHOUT the runtime of the program
		- So if you want to use a function to add nodes, use the "new" keyword instead of a basic declaration
		- Why?:	As previously mentioned, "node *newNode = new node" will allocate memory for a node in the HEAP
				This means the node would exist and be accessible from anywhere in the program even after the function ends
			  	However, do note that "node newNode = new node" wouldnt work, since "new" ALLOCATES memory and RETURNS a POINTER to that memory
			  	thus, you would need to a pointer to assign the value of the pointer returned by new (which is the address of that memory in HEAP)
	
	*/
		
	/* THUS: this code below wont work in a function		
	node newNode;
	newNode.data = data;
	newNode.next = head;
	head = &newNode;
	*/
