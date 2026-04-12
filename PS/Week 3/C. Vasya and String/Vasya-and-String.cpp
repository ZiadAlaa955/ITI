#include <iostream>
using namespace std;
int main()
{
    int n, k;
    cin >> n >> k;
    string s;
    cin >> s;

    int L = 0, R = 0;
    int maxLength = 0;

    // aab aabaa
    int count_b = 0;
    while (R < n)
    {
        if (s[R] == 'b')
        {
            count_b++;
        }

        while (count_b > k)
        {
            if (s[L] == 'b')
            {
                count_b--;
            }
            L++;
        }

        maxLength = max(maxLength, R - L + 1); // 3 5
        R++;
    }

    L = 0;
    R = 0;
    int count_a = 0;
    while (R < n)
    {
        if (s[R] == 'a')
        {
            count_a++;
        }

        while (count_a > k)
        {
            if (s[L] == 'a')
            {
                count_a--;
            }
            L++;
        }
        maxLength = max(maxLength, R - L + 1); //

        R++;
    }

    cout << maxLength << endl;
}