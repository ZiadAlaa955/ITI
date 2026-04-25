#include <iostream>

using namespace std;


int main()
{
	int arr[4] ;
	int* ptrArr = arr;
	for (int i = 0; i < 4; i++) {
		cout << "Enter Element " << i << " : " << endl;
		cin >> *(ptrArr + i);
	}
	for (int i = 0; i < 4; i++) {
		cout << "Element " << i << ": " << *(ptrArr + i) << endl;
	}
}