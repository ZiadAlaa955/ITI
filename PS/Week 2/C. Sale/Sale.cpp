#include <iostream>
#include <vector>
#include <algorithm>
#include <cmath>
using namespace std;

int main()
{
    int n, m, sum = 0;
    cin >> n >> m;
    vector<int> v;
    for (int i = 0; i < n; i++)
    {
        int x;
        cin >> x;
        v.push_back(x);
    }
    sort(v.begin(), v.end());
    for (int i = 0; i < n; i++)
    {
        if (v[i] < 0)
        {
            sum += abs(v[i]);
            m--;
        }
        if (m <= 0)
            break;
    }
    cout << sum << endl;
}