#include <iostream>
#include <map>
using namespace std;

int main()
{
    int n;
    cin >> n;
    string s;
    cin >> s;
    map<char, int> mp;
    for (int i = 0; i < n; i++)
    {
        mp[s[i]]++;
    }

    int result = 0;
    for (auto it : mp)
    {
        result += it.second / 2;
    }
    cout << result << endl;
}