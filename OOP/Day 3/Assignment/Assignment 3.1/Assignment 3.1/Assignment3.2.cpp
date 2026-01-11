#include <iostream>
#include <array>
using namespace std;

struct subject {
	string title;
	int score;
};

struct student {
	string name;
	int age;
	array<subject, 3> std_subjects;
};

int main()
{

	array<student, 5> students;
	int sum = 0;
	for (int i = 0; i < 5; i++) {
		sum = 0;
		cout << "Student #" << i + 1 << endl;
		cout << "Enter name:" << endl;
		cin >> students.at(i).name;
		cout << "Enter age: " << endl;
		cin >> students.at(i).age;
		for (int j = 0; j < 3; j++) {
			cout << "Subject #" << j + 1 << endl;
			cout << "Enter subject name:" << endl;
			cin >> students.at(i).std_subjects.at(j).title;
			cout << "Enter subject score:" << endl;
			cin >> students.at(i).std_subjects.at(j).score;
			sum += students.at(i).std_subjects.at(j).score;
		}
		cout << "Your total Grades: " << sum;
		cout << "Your avg Grades: " << sum / 3;
		//system("cls");
	}


	return 0;
}

