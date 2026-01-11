#include <iostream>

using namespace std;

int main()
{
	int n1, n2;
	
	bool flag;
	

	char choice;
	cout << "------------Calculator----------" << endl;
	cout << "Enter first number:" << endl;
	cin >> n1;
	cout << "Enter second number:" << endl;
	cin >> n2;
	system("cls");

	do {
		

	flag = true;
	cout << "A-Add" << endl;
	cout << "B-Subtract" << endl;
	cout << "C-Multiply" << endl;
	cout << "D-Divide" << endl;
	cout << "E-Exit" << endl;

	cin >> choice;

	switch (choice)
	{
	case 'A':
	case 'a':
		cout << n1 + n2 << endl;
		break;
	case 'B':
	case 'b':
		cout << n1 - n2 << endl;
		break;
	case 'C':
	case 'c':
		cout << n1 * n2 << endl;
		break;
	case 'D':
	case 'd':
		cout << n1 / n2 << endl;
		break;
	case 'E':
	case 'e':
		cout << "Exit..." << endl;
		flag = false;
		break;
	default:
		cout << "Enter a valid choice !" << endl;
		break;
	}

	} while (flag);

}