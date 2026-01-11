#include <iostream>
using namespace std;

string redColor = "\033[31m";
string greenColor = "\033[32m";
string defaultANSI = "\033[0m";

class complex {
	float real{0.0};
	float image{0.0};
public:
	static int count;

	/*Constructors*/
	complex() = default;
	/*complex() {
		real = 0.0;
		image = 0.0;
		count++;
		cout << "default constructor (float) called" << endl;
	};*/
	complex(float x) {
		real = x;
		image = 0;
		count++;
		cout << greenColor << "Parameterized constructor (float) called" << defaultANSI << endl;
	}
	complex(float x, float y) {
		real = x;
		image = y;
		count++;
		cout << greenColor << "Parameterized constructor (float, float) called" << defaultANSI << endl;
	}
	/*operators overload*/
	complex operator+(const complex& c){
		complex res;
		res.real = this->real + c.real;
		res.image = this->image + c.image;
		return res;
	}
	complex operator-(const complex& c) {
		complex res;
		res.real = this->real - c.real;
		res.image = this->image - c.image;
		return res;
	}
	complex operator*(const complex& c) {
		complex res;
		res.real = this->real * c.real;
		res.image = this->image * c.image;
		return res;
	}
	complex operator/(const complex& c) {
		complex res;
		res.real = this->real / c.real;
		res.image = this->image / c.image;
		return res;
	}
	/*increment & decrement overload*/
	complex& operator++() {
		this->real++;
		return *this;
	}
	complex operator++(int) {
		complex temp = *this;
		this->real++;
		return temp;
	}
	complex& operator--() {
		this->real--;
		return *this;
	}
	complex operator--(int) {
		complex temp = *this;
		this->real--;
		return temp;
	}
	/*comparison operators overload*/
	bool operator<(const complex& c) {
		return this->real < c.real;
	}
	bool operator>(const complex& c) {
		return this->real > c.real;
	}
	/*type casting*/
	operator float() {
		return this->real;
	}
	operator int() {
		return this->real;
	}
	operator double() {
		return this->real;
	}

	/*cout overload*/
	friend ostream& operator<<(ostream& os, complex& c);

	/*void printComplex() {
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
			else cout << " + " << image << "i" << endl;
		}
		else if (image < 0) {
			cout << real;
			if (image == -1)cout << "- i" << endl;
			else cout << " - " << -image << "i" << endl;
		}
	}*/

	static void showCount() {
		cout << "active objects: " << count << endl;
	}

	~complex() {
		count--;
		cout << redColor << "destructor called" << defaultANSI << endl;
	}
};

ostream& operator<<(ostream& os, complex& c) {
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

int complex::count{0};

int main()
{
	complex c1(10.1, 5.0);
	complex c2(7.0, 3.0);
	cout << "c1: " << c1 << endl;
	cout << "c2: " << c2 << endl;
	cout << "----------------------------------------" << endl;
	complex res_add = c1 + c2;
	cout << "c1 + c2 = " << res_add << endl;
	complex res_sub = c1 - c2;
	cout << "c1 - c2 = " << res_sub << endl;
	complex res_mul = c1 * c2;
	cout << "c1 * c2 = " << res_mul << endl;
	complex prefix = c1++;
	cout << "++c1 = " << prefix << endl;
	complex greater = c1 > c2;
	cout << "is c1 > c2 ?  " << greater ? cout << "Yes" << endl : cout << "No" << endl;
	complex i = (int)c1;
	cout << "c1 as int : " << i << endl;
	cout << "-------------------------------------------" << endl;
	complex::showCount();
}


/*
complex c1(5.5,7);
	complex c2(10, 3);
	complex res = c1 + c2;
	cout << res << endl;
	res++;
	cout << res << endl;
	bool less = c1 < c2;
	less == 1 ? cout << "true" << endl : cout << "false" << endl;
	int x = (int)c1;
	cout << x << endl;
*/
