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
	array<student, 3> students;
	array<int, 3> subject_sums = { 0, 0, 0 };

	int sum = 0;
	for (int i = 0; i < 3; i++) {
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
			subject_sums.at(i) += students.at(i).std_subjects.at(j).score;
		}
		cout << "Your total Grades: " << sum << endl;
		
		system("pause");
		system("cls");
	}
	
	for (int i = 0; i < 3; i++) {
		cout << "Average scores of subject " << i + 1 << " : " << subject_sums.at(i) / 3 << endl;
	}


	return 0;
}

