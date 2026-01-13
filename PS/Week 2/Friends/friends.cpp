#include <iostream>
using namespace std;

int main()
{
    int friends[6][6];
    for (int i = 1; i <= 5; i++)
    {
        for (int j = 1; j <= 5; j++)
        {
            friends[i][j] = 0;
        }
    }

    int n;
    cin >> n;
    for (int i = 0; i < n; i++)
    {
        int x, y;
        cin >> x >> y;
        friends[x][y] = 1;
        friends[y][x] = 1;
    }

    for (int i = 1; i <= 5; i++)
    {
        for (int j = i + 1; j <= 5; j++)
        {
            for (int k = j + 1; k <= 5; k++)
            {
                if (friends[i][j] && friends[j][k] && friends[i][k])
                {
                    cout << "WIN" << endl;
                    return 0;
                }
                if (!friends[i][j] && !friends[k][j] && !friends[i][k])
                {
                    cout << "WIN" << endl;
                    return 0;
                }
            }
        }
    }
    cout << "FAIL" << endl;
    // for (int i = 1; i <= 5; i++)
    // {
    //     for (int j = 1; j <= 5; j++)
    //     {
    //         cout << i << "," << j << ": " << friends[i][j] << endl;
    //     }
    // }
}
/*
        1  2              2  3              1  3
friends[i][j] AND friends[j][k] AND friends[i][k]
4
1 3
2 3
1 4
5 3
=>1,2 2,3, 3,1

WIN

5
1 2
2 3
3 4
4 5
5 1
FAIL
*/