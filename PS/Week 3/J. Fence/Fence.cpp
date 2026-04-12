#include <iostream>
#include <vector>
using namespace std;
int main()
{
    int n, k;
    cin >> n >> k;

    vector<int> v;
    for (int i = 0; i < n; i++)
    {
        int x;
        cin >> x;
        v.push_back(x);
    }

    int currentMinSum = 0;
    int firstIndex = 0;
    for (int i = 0; i < k; i++)
    {
        currentMinSum += v[i];
    }

    int minSum = currentMinSum;
    int result = 0;
    for (int i = k; i < n; i++)
    {
        firstIndex++;
        currentMinSum += v[i];
        currentMinSum -= v[i - k];
        if (minSum > currentMinSum)
        {
            minSum = currentMinSum;
            result = firstIndex;
        }
    }

    cout << result + 1 << endl;
}