#include <iostream>

using namespace std;

void sum(int x,int y) {
	cout << "integer sum: "  << x + y << endl;
}

void sum(float x, float y) {
	cout << "float sum: " << x + y << endl;
}

void sum(float x, int y) {
	cout << "float-int sum: " << x + y << endl;
}

void sum(int x, double y) {
	cout << "float-int sum: " << x + y << endl;
}

int main()
{
	float x, y;
	cout << "Enter first number: " << endl;
	cin >> x;
	cout << "Enter second number: " << endl;
	cin >> y;

	sum((int)x,(int) y);
	sum(x, y);
	sum(x,(int) y);
	sum((int)x, (double)y);


}