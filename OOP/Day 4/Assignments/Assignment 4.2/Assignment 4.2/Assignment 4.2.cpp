#include <iostream>

using namespace std;

int swap(int& x, int& y) {
	int temp = x;
	x = y;
	y = temp;

	return x, y;
}

int main()
{
	int x = 5;
	int y = 10;

	cout << "before:" << endl;
	cout << "X = " << x << "  Y = " << y << endl;
	
	swap(x, y);
	cout << "After :" << endl;
	cout << "X = " << x << "  Y = " << y << endl;

}