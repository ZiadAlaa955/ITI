#include <iostream>

using namespace std;

int main()
{
    int n;
    cin >> n;

    int firstDigit = n % 10;
    n /= 10;
    int secondDigit = n;

    if (firstDigit % 2 == 0 && secondDigit % 2 == 0)
    {
        cout << "YES" << endl;
    }
    else
    {
        cout << "NO" << endl;
    }
}