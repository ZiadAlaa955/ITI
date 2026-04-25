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
	/*constructors*/
	stack() = delete;
	//stack() {
	//	count++;
	//	cout << "default constructor is called..." << endl;
	//	top = 0; //empty stack
	//	size = 10;
	//	stp = new int[size];
	//}
	stack(int top, int size = 5) {
		count++;
		cout << greenColor << "Parametarized constructor is called..." << defaultANSI << endl;
		this->top = top;
		this->size = size;
		stp = new int[size];
	}
	stack(const stack& other){
		this->top = other.top;
		this->size = other.size;
		this->stp = new int[size];
		for (int i = 0; i < other.top; i++) {
			this->stp[i] = other.stp[i];
		}
		count++;
		cout << greenColor << "Copy constructor" << defaultANSI << endl;
	}
	stack(stack&& other) noexcept 
	{
		this->top = other.top;
		this->size = other.size;
		this->stp = other.stp;

		other.top = 0;
		other.size = 0;
		other.stp = nullptr;
		
		count++;
		cout << greenColor << "Move constructor" << defaultANSI << endl;
	}
	/*bracets operator*/
	int operator[](int index) {
		if (index < 0 || index >= top) {
			cout << redColor << "this index is out of stack boundary" << defaultANSI << endl;
			return this->stp[0];
		}
		else {
			return this->stp[index];
		}
	}
	/*=operator*/
	stack& operator= (stack& other)
	{
		delete[] this->stp;
		this->top = other.top;
		this->size = other.size;
		this->stp = new int[this->size];

		for (int i = 0; i < this->top; i++) {
			this->stp[i] = other.stp[i];
		}

		return *this;
	}
	/*=move operator*/
	stack& operator= (stack&& other)  noexcept
	{
		delete[] this->stp;
		
		this->top = other.top;
		this->size = other.size;
		this->stp = other.stp;

		other.top = 0;
		other.size = 0;
		other.stp = nullptr;

		return *this;
	}
	/*stack methods (push, pop, getTop, showElements)*/
	stack& push(int value) {
		if (top >= size) {
			cout << redColor << "Stack overflow" << defaultANSI << endl;
		}
		else {
			stp[top] = value;
			top++;
			cout << value << " pushed to stack..." <<endl;
		}
		return *this;
	}

	stack& pop() {
		int value = -1;
		if (top == 0) {
			cout << redColor << "stack is empty..." << defaultANSI << endl;
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
			cout << redColor << "stack is empty..." << defaultANSI << endl;
		}
		else {
			cout << "top: " << stp[top - 1] << endl;
		}
		return *this;
	}

	stack& showElements() {
		if (top == 0) {
			cout << redColor << "stack is empty..." << defaultANSI <<  endl;
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
		cout << greenColor << "Active stacks: " << defaultANSI;
		cout << count << endl;
	}

	~stack() {
		delete[] stp;
		count--;
		cout << redColor << "Destructor called" << defaultANSI <<  endl;
	}

};


int stack::count = 0;

int main()
{
	stack s1(0);
	s1.push(10).push(20);
	s1.showElements();

	stack s2 = s1;
	s2.push(30);

	cout << "s1: " << endl;
	s1.showElements();
	cout << "s2: ";
	s2.showElements(); 
	stack::showCount();

	cout << "--------------------------------------" << endl;
	s1 = std::move(s2);
	cout << "s2 after move: ";
	s2.showElements(); 
	cout << "s1 after move: ";
	s1.showElements(); 

	cout << "s1[0]: "<< s1[0] << endl;
	s1.pop(); 

	return 0;
}