#include <iostream>
#include <math.h>
using namespace std;

int main()
{
    int n, m, total = 0;
    cin >> n >> m;
    int maxNum = max(n, m);
    for (int i = 0; i <= maxNum; i++)
    {
        for (int j = 0; j <= maxNum; j++)
        {
            int equation1 = pow(i, 2) + j;
            int equation2 = pow(j, 2) + i;
            if (equation1 == n && equation2 == m)
            {
                total++;
            }
        }
    }
    cout << total << endl;
}
/*
9 3
3^2 + 0 = 9
3 + 0^2 = 3

14 28

*/