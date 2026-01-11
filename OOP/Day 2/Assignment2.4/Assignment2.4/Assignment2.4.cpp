#include <iostream>

using namespace std;

int main()
{
	int score;
	cout << "------------ITI Grading system------------" << endl;
	cout << "enter your score:" << endl;
	cin >> score;

	if (score <= 100 && score >= 85) {
		cout << "You got A" << endl;
	}
	else if(score < 85 && score >= 75)
	{
		cout << "You got B" << endl;
	}
	else if (score < 75 && score >= 65)
	{
		cout << "You got C" << endl;
	}
	else if (score < 65 && score >= 60)
	{
		cout << "You got D" << endl;
	}
	else if (score < 60 )
	{
		cout << "You got F" << endl;
	}
	else
	{
		cout << "not a valid score !" << endl;
	}
}