#include <iostream>
using namespace std;

string redColor = "\033[31m";
string greenColor = "\033[32m";
string defaultANSI = "\033[0m";

class Complex {
	float real{ 0.0 };
	float image{ 0.0 };
public:
	static int count;

	/*Constructors*/
	Complex() = default;
	Complex(float x) {
		real = x;
		image = 0;
		count++;
		//cout << greenColor << "Parameterized constructor (float) called" << defaultANSI << endl;
	}
	Complex(float x, float y) {
		real = x;
		image = y;
		count++;
		//cout << greenColor << "Parameterized constructor (float, float) called" << defaultANSI << endl;
	}
	/*operators overload*/
	Complex operator+(const Complex& c) {
		Complex res;
		res.real = this->real + c.real;
		res.image = this->image + c.image;
		return res;
	}
	Complex operator-(const Complex& c) {
		Complex res;
		res.real = this->real - c.real;
		res.image = this->image - c.image;
		return res;
	}
	Complex operator*(const Complex& c) {
		Complex res;
		res.real = this->real * c.real;
		res.image = this->image * c.image;
		return res;
	}
	Complex operator/(const Complex& c) {
		Complex res;
		res.real = this->real / c.real;
		res.image = this->image / c.image;
		return res;
	}
	/*increment & decrement overload*/
	Complex& operator++() {
		this->real++;
		this->image++;
		return *this;
	}
	Complex operator++(int) {
		Complex temp = *this;
		this->real++;
		this->image++;
		return temp;
	}
	Complex& operator--() {
		this->real--;
		this->image -- ;
		return *this;
	}
	Complex operator--(int) {
		Complex temp = *this;
		this->real--;
		this->image--;
		return temp;
	}
	/*comparison operators overload*/
	bool operator<(const Complex& c) {
		return this->real < c.real && this->image < c.image;
	}
	bool operator>(const Complex& c) {
		return this->real > c.real && this->image > c.image;
	}
	/*type casting*/
	/*operator float() {
		return this->real;
	}
	operator int() {
		return this->real;
	}
	operator double() {
		return this->real;
	}*/

	/*cout overload*/
	friend ostream& operator<<(ostream& os,const Complex& c);

	static void showCount() {
		cout << "active objects: " << count << endl;
	}

	~Complex() {
		count--;
		//cout << redColor << "destructor called" << defaultANSI << endl;
	}
};

ostream& operator<<(ostream& os,const Complex& c) {
	if (c.real == 0) {
		if (c.image == 1) os << "i";
		else if (c.image == -1)os << "-i";
		else os << c.image << "i";
	}
	else if (c.image == 0) {
		os << c.real;

	}
	else if (c.image > 0) {
		os << c.real;
		if (c.image == 1)os << " + i";
		else os << " + " << c.image << "i";
	}
	else if (c.image < 0) {
		os << c.real;
		if (c.image == -1)os << "- i";
		else os << " - " << -c.image << "i";
	}
	return os;
}

int Complex::count{ 0 };


template<class T> 
class Stack {
	int top;
	int size;
	T* stp;

public:
	static int count;
	/*constructors*/
	Stack() {
		top = 0;
		size = 5;
		count++;
		stp = new T[size];
	};
	Stack(int size = 5) {
		count++;
		this->top = 0;
		this->size = size;
		stp = new T[size];
	}
	Stack(Stack& other) {
		this->top = other.top;
		this->size = other.size;
		this->stp = new T[size];
		for (int i = 0; i < other.top; i++) {
			this->stp[i] = other.stp[i];
		}
		count++;
	}
	Stack(Stack&& other) noexcept
	{
		this->top = other.top;
		this->size = other.size;
		this->stp = other.stp;

		other.top = 0;
		other.size = 0;
		other.stp = nullptr;

		count++;
	}
	/*bracets operator*/
	T operator[](int index) {
		if (index < 0 || index >= top) {
			cout << redColor << "this index is out of stack boundary" << defaultANSI << endl;
			return T();
		}
		else {
			return this->stp[index];
		}
	}
	/*=operator*/
	Stack& operator= (Stack& other)
	{
		delete[] this->stp;
		this->top = other.top;
		this->size = other.size;
		this->stp = new T[this->size];

		for (int i = 0; i < this->top; i++) {
			this->stp[i] = other.stp[i];
		}

		return *this;
	}
	/*=move operator*/
	Stack& operator= (Stack&& other)  noexcept
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
	Stack& push(T value) {
		if (top >= size) {
			cout << redColor << "Stack overflow" << defaultANSI << endl;
		}
		else {
			stp[top] = value;
			top++;
			cout << value << " pushed to stack..." << endl;
		}
		return *this;
	}

	Stack& pop();

	Stack& getTop() {
		if (top == 0) {
			cout << redColor << "stack is empty..." << defaultANSI << endl;
		}
		else {
			cout << "top: " << stp[top - 1] << endl;
		}
		return *this;
	}

	Stack& showElements() {
		if (top == 0) {
			cout << redColor << "stack is empty..." << defaultANSI << endl;
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

	bool isEmpty() {
		return top == 0;
	}

	bool isFull() {
		return top == size;
	}

	T sum(T n1, T n2);

	~Stack() {
		delete[] stp;
		count--;
		//cout << redColor << "Destructor called" << defaultANSI << endl;
	}

};

template<class T>
T  Stack<T>::sum(T n1, T n2) {
	return n1 + n2;
}

template<class T>
Stack<T>& Stack<T>::pop() {
	if (top == 0) {
		cout << redColor << "stack is empty..." << defaultANSI << endl;
	}
	else {
		top--;
	}
	//cout << value << " has been popped" << endl;
	return *this;
}

template<class T>
int Stack<T>::count = 0;


int main()
{
	Stack<int> s1(10);
	Stack<float> s2(10);
	Stack<char> sChars(10);
	Stack<Complex> sComplex(10), sComplex2(10);

	s1.push(10);
	s1.push(20);
	s1.pop();
	s2.push(10.5);
	s2.push(20.5);
	sChars.push('A');
	sChars.push('B');
	sComplex.push(Complex(10.5,20));
	sComplex.push(Complex(11.2, 5.6));
	sComplex.push(Complex(21.3, 56.1));
	sComplex.pop();
	sComplex2.push(Complex(15.5, 30.2));
	sComplex2.push(Complex(11, 6.6));

	cout << sComplex[0] << endl;

	cout << "--------int stack--------------" << endl;
	s1.showElements();
	cout << "--------flaot stack--------------" << endl;
	s2.showElements();
	cout << "--------char stack--------------" << endl;
	sChars.showElements();
	cout << "--------char stack--------------" << endl;
	sComplex.showElements();
	cout << "-----------------------------" << endl;
	cout << "Sum two complex numbers: " << sComplex.sum(sComplex[0], sComplex[1]) << endl;

}
