#include <iostream>
#include <math.h>
using namespace std;

int main()
{
    int posX, posY;
    int n;
    for (int i = 1; i <= 5; i++)
    {
        for (int j = 1; j <= 5; j++)
        {
            cin >> n;
            if (n == 1)
            {
                posX = i;
                posY = j;
            }
        }
    }
    cout << abs(posX - 3) + abs(posY - 3);
}
