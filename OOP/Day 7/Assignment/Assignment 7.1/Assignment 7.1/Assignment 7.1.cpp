#include <iostream>

using namespace std;

string redColor = "\033[31m";
string greenColor = "\033[32m";
string defaultANSI = "\033[0m";

class stack {
	int top;
	int size;
	int* stp;

public:
	static int count;
	stack() {
		count++;
		cout << "default constructor is called..." << endl;
		top = 0; //empty stack
		size = 10;
		stp = new int[size];
	}
	stack(int size) {
		count++;
		cout << "Parametarized constructor is called..." << endl;
		top = 0;
		this->size = size;
		stp = new int[size];
	}

	stack& push(int value) {
		if (top >= size) {
			cout << "Stack overflow" << endl;
		}
		else {
			stp[top] = value;
			top++;
			cout << value << " pushed to stack..." << endl;
		}
		return *this;
	}

	stack& pop() {
		int value = -1;
		if (top == 0) {
			cout << "stack is empty..." << endl;
		}
		else {
			top--;
			value = stp[top];
		}
		cout << value << " has been popped" << endl;
		return *this;
	}

	stack& getTop() {
		if (top == 0) {
			cout << "stack is empty..." << endl;
		}
		else {
			cout << "top: " << stp[top - 1] << endl;
		}
		return *this;
	}

	stack& showElements() {
		if (top == 0) {
			cout << "stack is empty..." << endl;
		}
		else {
			cout << "Elements: ";
			for (int i = 0; i < top; i++) {
				cout << stp[i] << " ";
			}
			cout << endl;
		}
		return *this;
	}

	static void showCount() {
		cout << "Active stacks: " << count << endl;
	}

	~stack() {
		delete[] stp;
		count--;
	}

};


int stack:: count = 0;


int main()
{

	stack s1 = stack(2);
	s1.push(10).push(20).push(30).pop().getTop().showElements(); 
	stack::showCount();
	cout << "---------------------------------------" << endl;
	stack s2 ;
	s2.push(10).push(20).push(30).pop().getTop().showElements();
	cout << "---------------------------------------" << endl;
	stack::showCount();
}

/*
* 1)=> Stack:
------------
1. Implement a Stack class using raw pointers.
2. Add methods to demonstrate method chaining.
3. Implement a function showElements() to display the contents of the stack.
4. Create the following constructors:
-Default constructor
-Parameterized constructor
5. Create a destructor to properly delete dynamically allocated memory (raw pointer).
6. Add a static counter to track the number of Stack objects created.
7. Create a static method to display this counter.
----------------------------------------------------------------------------------------
size,array,top
*/