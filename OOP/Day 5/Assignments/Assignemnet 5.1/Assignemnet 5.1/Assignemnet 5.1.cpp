#include <iostream>

using namespace std;

void swapByAddress(int* ptrx, int* ptry) {
	int temp;
	temp = *ptrx;
	*ptrx = *ptry;
	*ptry = temp;
}

void swapByRefrence(int& x, int& y) {
	int temp;
	temp = x;
	x = y;
	y = temp;
}

int main()
{
	int x = 5, y = 10;
	cout << "Values before swapping: x = " << x << " , y = " << y << endl;
	
	swapByAddress(&x, &y);
	cout<<"Valutes after swapping by address:  x = " << x << " , y = " << y << endl;

	swapByRefrence(x, y);
	cout << "Valutes after swapping by reference:  x = " << x << " , y = " << y << endl;

	return 0;
}