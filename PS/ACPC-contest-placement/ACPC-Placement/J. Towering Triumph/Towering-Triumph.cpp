#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    int x, y, z;
    cin >> x >> y >> z;

    int tallest = max(x, y);

    tallest = max(tallest, z);

    cout << tallest << endl;
}