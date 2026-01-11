#include <iostream>
#include<array>
using namespace std;

struct employee {
	string name;
	int age;
	int id;
	string department;
};

int main()
{
	array<employee, 50> employees;
	int n;
	cout << "Enter number of employees:" << endl;
	cin >> n;
	for (int i = 0; i < n; i++) {
		cout << "\033[3;1H" << "Emp " << i+1 ;
		cout << "\033[4;1H" << "name: ";
		cout << "\033[4;15H" << "age: ";
		cout << "\033[5;1H" <<"ID: ";
		cout << "\033[5;15H" << "department: " << endl;
		
		cout << "\033[4;7H";
		cin >> employees.at(i).name;
		cout << "\033[4;20H" ;
		cin >> employees.at(i).age;
		cout << "\033[5;5H" ;
		cin >> employees.at(i).id;
		cout << "\033[5;27H" ;
		cin >> employees.at(i).department;

		system("cls");

	}
	cout << "\033[1;1H"<<"------ Employees Data-----";  

	for (int i = 0; i < n; i++) {
		cout << "\033[" << i + 3 << ";1H" << employees.at(i).name;  
		cout << "\033[" << i + 3 << ";6H" << employees.at(i).age;
		cout << "\033[" << i + 3 << ";11H" << employees.at(i).id;
		cout << "\033[" << i + 3 << ";16H" << employees.at(i).department;
	}

}

