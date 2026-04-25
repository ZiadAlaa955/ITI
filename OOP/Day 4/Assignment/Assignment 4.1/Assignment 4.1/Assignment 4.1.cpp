#include <iostream>
#include <span>

using namespace std;

void replaceToZeroes(span<int> zeroes) {
	for (auto& i : zeroes) {
		i = 0;
	}
}

void replaceToOnes(span<int> ones) {
	for (auto& i : ones) {
		i = 1;
	}
}

void subspans (span<int> s) {
	int mid = s.size() / 2; 

	span<int> zeroes = s.subspan(0, mid);
	replaceToZeroes(zeroes);

	span<int> ones = s.subspan(mid);
	replaceToOnes(ones);	
}


int main()
{
	int arr[6] = { 1,2,3,4,5,6 };
	
	cout << "Array before:" << endl;
	for (auto i : arr) {
		cout << i << " ";
	}
	cout << endl;
	
	subspans(arr);
	
	cout << "Array after:" << endl;
	for (auto i : arr) {
		cout << i << " ";
	}
}