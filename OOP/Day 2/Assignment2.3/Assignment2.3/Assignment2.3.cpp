#include <iostream>

using namespace std;

int main()
{
	int n;
	bool flag;

	cout << "Enter number of rows and columns (ODD): " << endl;
	do {
		flag = false;
		cin >> n;
		if (n % 2 == 0 || n <= 0) {
			cout << "Enter only odd numebr!" << endl;
			flag = true;
		}
	} while (flag);

	system("cls");

	int color = 31;

	int row = 0, col = n / 2;
	for (int i = 1; i <= n * n; i++) {
		if (color == 37)color = 31;
		cout << "\033["<<color<<"m";
		cout << "\033[" << row + 1 << ";" << (col * 4 + 1) <<"H" << i;
		color++;

		int newrow = (row - 1 + n) % n;	 //move one row up
		int newcol = (col + 1) % n; //move column right
		
		if ((i % n) == 0) // when the next cell is filled (i%n is multiple of n)
		{
			row = (row + 1) % n; // go down one cell
		}
		else {
			row = newrow;
			col = newcol;
		}
	}
	cout << "\033[0m";

	return 0;
}