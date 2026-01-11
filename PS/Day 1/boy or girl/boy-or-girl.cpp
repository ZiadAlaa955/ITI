#include <iostream>
#include <map>
using namespace std;

int main()
{
    map<char, int> mp;
    string s;
    cin >> s;
    int counter = 0;

    for (int i = 0; i < s.length(); i++)
    {
        mp[s[i]]++;
    }

    for (auto it : mp)
    {
        counter++;

        // if (mp[s[i]] == 1)
        // {
        //     counter++;
        // }
        // else
        // {
        //     counter++;
        //     mp[s[i]] = 0;
        // }
    }

    if (counter % 2 == 0)
    {
        cout << "CHAT WITH HER!" << endl;
    }
    else
    {
        cout << "IGNORE HIM!" << endl;
    }

    return 0;
}

// if the number of distinct characters in one's user name is odd, then he is a male, otherwise she is a female
// wjmzbmr => 6 =>chat
// xiaodao=> 5 =>ignore
// sevenkplus=>8 =>chat