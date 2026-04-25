#include <iostream>

using namespace std;

int main()
{
    int a, h;
    cin >> a >> h;
    if (a > h)
        cout << "A" << endl;
    else if (a < h)
        cout << "H" << endl;
    else
        cout << "D" << endl;
}