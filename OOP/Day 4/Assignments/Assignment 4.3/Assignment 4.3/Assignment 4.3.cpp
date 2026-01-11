#include <iostream>
#include <string>
using namespace std;

int fibonacci(int n) {
	if (n == 0) {
		return 0;
	}
	else if (n == 1) {
		return 1;
	}
	else {
		return fibonacci(n - 1) + fibonacci(n - 2);
	}
}


/*
res => string

10%2 = 0
res += 0 
10/2 = 5

5%2 = 1
5/2 = 2

2%2 = 0
2/2 = 1

1%2 = 1
1/2 = 0

0 => result

*/
string decimalToBinary(int n, string& res) {
	if (n == 0) {
		return res;
	}
	else {
		decimalToBinary(n / 2, res);
		res += to_string(n % 2);
		return res;
	}
}

int main()
{
	cout << "-------------Fibonacci----------------" << endl;
	int n;
	cout << "Enter a number: " << endl;
	cin >> n;
	cout << fibonacci(n) << endl;

	system("pause");
	system("cls");

	cout << "------------------Binary to decimal--------------" << endl;
	cin.clear(n);
	cout << "Enter a decimal number: " << endl;
	cin >> n;
	string s = "";
	cout << "Binary representation is: " << decimalToBinary(n, s) << endl;

}
