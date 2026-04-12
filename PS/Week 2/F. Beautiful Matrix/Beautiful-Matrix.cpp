#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    int center_row = 3, center_col = 3, steps = 0;
    for (int i = 1; i <= 5; i++)
    {
        for (int j = 1; j <= 5; j++)
        {
            int x;
            cin >> x;
            if (x == 1)
            {
                steps += abs(i - center_row);
                steps += abs(j - center_col);
            }
        }
    }
    cout << steps << endl;
}