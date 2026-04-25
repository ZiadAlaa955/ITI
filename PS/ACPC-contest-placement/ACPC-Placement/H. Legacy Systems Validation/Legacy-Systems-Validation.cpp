#include <iostream>
#include <map>
#include <string>
using namespace std;

int main()
{
    int year;
    cin >> year;
    string s = to_string(year);

    map<char, int> mp;
    for (int i = 0; i < 4; i++)
    {
        mp[s[i]]++;
    }

    bool printable = false;
    for (auto it : mp)
    {
        if (it.second > 1)
        {
            printable = true;
        }
    }

    if (printable)
    {
        cout << "YES" << endl;
    }
    else
    {
        cout << "NO" << endl;
    }
}