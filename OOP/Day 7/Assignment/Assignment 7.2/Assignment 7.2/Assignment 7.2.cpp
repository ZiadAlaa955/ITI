#include <iostream>

using namespace std;

class complex {
	float real;
	float image;
public:
	static int count;
	complex() = default;
	complex(float x) {
		real = x;
		image = 0;
		count++;
		cout << "Parameterized constructor (float) called" << endl;
	}
	complex(float x, float y) {
		real = x;
		image = y;
		count++;
		cout << "Parameterized constructor (float, float) called" << endl;
	}

	void printComplex() {
		 
		if (real == 0) {
			if (image == 1) cout << "i" << endl;
			else if (image == -1)cout << "-i" << endl;
			else cout << image << "i" << endl;
		}
		else if (image == 0) {
			cout << real << endl;
			
		}
		else if (image > 0) {
			cout << real;
			if (image == 1)cout << " + i" << endl;
			else cout <<" + " <<image << "i" << endl;
		}
		else if (image < 0) {
			cout << real;
			if (image == -1)cout << "- i" << endl;
			else cout << " - " <<  -image << "i" << endl;
		}
	}

	static void showCount() {
		cout << "active objects: " << count << endl;
	}

	~complex() {
		count--;
		cout << "destructor called" << endl;
	}
};

int complex::count = 0;

int main()
{
	complex c1 = complex(5, 7);
	complex c2 = complex(-3, -3);
	complex c3 = complex(0,-8);
	complex c4 = complex(0, 8);
	complex c5 = complex(0, -9);
	complex c6 = complex(-9, 3);
	complex c7 = complex(8, 1);
	complex c8 = complex(-9);

	c1.printComplex();
	c2.printComplex();
	c3.printComplex();
	c4.printComplex();
	c5.printComplex();
	c6.printComplex();
	c7.printComplex();
	c8.printComplex();


}

/*
2)=> Complex Class:
-------------------
1. Create a Complex class to represent complex numbers.  [done]
2. Add data members: real, image  [done]
3. Add a counter to track how many objects are created.  [done]
4. Implement the following constructors:
Default constructor  [done]
Overloaded constructor: Complex(float), Complex(float, float) [done]
5. Implement a destructor that decrements the counter.  [done]
6. Add a method showCounter() to display the number of active objects.  [done]
7. Add a method printComplex() to display the number in a readable format, showing different cases
- 5+7i
- -3-3i
- -8i
- 8i
- 8i
- -9i
- -9+3i
- 8+i
8. Print which constructor or destructor is being called at runtime.  [done]
*/