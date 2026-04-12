#include <iostream>
#include <map>
using namespace std;

int main()
{
    map<char, int> alphabets;
    for (int i = 97; i <= 122; i++)
    {
        alphabets[i] = 0;
    }
    int n, total = 0;
    cin >> n;
    string s;
    cin >> s;
    if (n < 26)
    {
        cout << "NO" << endl;
    }
    else
    {
        for (int i = 0; i < n; i++)
        {
            char ch = tolower(s[i]);
            if (alphabets[ch] == 0)
            {
                alphabets[ch] = 1;
                total++;
            }
        }
        if (total < 26)
        {
            cout << "NO" << endl;
        }
        else
        {
            cout << "YES" << endl;
        }
    }
}