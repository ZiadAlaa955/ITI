#include <iostream>
using namespace std;

int main()
{
    int testCases;
    cin >> testCases;
    while (testCases--)
    {
        int i1, i1Indx, j1, i2, i2Indx, j2;
        cin >> i1Indx >> i1;
        cin >> i2Indx >> i2;
        if (i1 != 90)
        {
            j1 = 90 - i1;
        }
        else
        {
            cout << -1 << endl;
            break;
        }

        if (i2 != 30)
        {
            j2 = 150 - i2;
        }
        else
        {
            cout << -1 << endl;
            break;
        }

        if (i1Indx == 1)
        {
            cout << i1 << " " << j1 << " ";
        }
        else
        {
            cout << j1 << " " << i1 << " ";
        }
        if (i2Indx == 3)
        {

            cout << i2 << " " << j2;
        }
        else
        {
            cout << j2 << " " << i2;
        }
        cout << endl;
    }
}