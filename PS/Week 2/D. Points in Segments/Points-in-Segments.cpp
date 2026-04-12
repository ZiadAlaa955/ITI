#include <iostream>
#include <vector>
using namespace std;

int main()
{
    int n, m;
    cin >> n >> m;
    vector<int> v(m + 1, 0);
    vector<int> result;

    for (int i = 0; i < n; i++)
    {
        int x, y;
        cin >> x >> y;

        for (int j = x; j <= y; j++)
        {
            v[j]++;
        }
    }

    for (int i = 1; i <= m; i++)
    {
        if (v[i] == 0)
        {
            result.push_back(i);
        }
    }

    if (result.size() == 0)
    {
        cout << 0 << endl;
    }
    else
    {
        cout << result.size() << endl;
        for (int n : result)
        {
            cout << n << " ";
        }
    }
}