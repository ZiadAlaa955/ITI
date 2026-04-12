#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int main()
{
    int n;
    cin >> n;

    vector<int> v;
    for (int i = 0; i < n; i++)
    {
        int x;
        cin >> x;
        v.push_back(x);
    }

    // 1 2 3 5 7
    int g, a, b;
    int num1 = 0, num2 = 0, num3 = 0;
    bool flag = false;
    for (int i = 0; i < v.size(); i++) // 1 2
    {
        g = v[i];
        // cout << "g = " << v[i] << endl;    // 3
        for (int j = 0; j < v.size(); j++) // 1 2 3 5 7
        {
            // cout << "a = " << v[j] << endl;    // 3
            a = v[j];                          // 1
            for (int k = 0; k < v.size(); k++) // 1 2 3 5 7
            {
                // cout << "b = " << v[k] << endl; // 3
                b = v[k]; // 1
                if ((i != j && i != k && j != k) && (b + a == g))
                {
                    num1 = i + 1;
                    num2 = j + 1;
                    num3 = k + 1;
                    flag = true;
                }
                if (flag == true)
                    break;
            }
            if (flag == true)
                break;
        }
        if (flag == true)
            break;
    }
    if (num1 == 0 && num2 == 0 && num3 == 0)
    {
        cout << -1 << endl;
    }
    else
    {
        cout << num1 << " " << num2 << " " << num3 << endl;
    }
}
/*
5
1 2 3 5 7

n = 7

    -a = 5
    b = 3
    if(5+3 == 7)false
    b = 2
    if(5+2 == 7) true, break

*/

// 1 2 3 5 7
// 1+2 = 3
// 5+2 = 7
// 3+2 = 5
