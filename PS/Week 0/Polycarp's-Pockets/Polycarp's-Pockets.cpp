#include <iostream>
#include <map>
using namespace std;

int main()
{
    int n;
    cin >> n;
    map<int, int> mp;

    for (int i = 1; i <= 100; i++)
        mp[i] = 0;

    for (int i = 0; i < n; i++)
    {
        int coinVal;
        cin >> coinVal;
        mp[coinVal]++;
    }

    int pockets = 0;
    for (int i = 0; i <= 100; i++)
    {
        if (pockets < mp[i])
            pockets = mp[i];
    }

    cout << pockets << endl;
}