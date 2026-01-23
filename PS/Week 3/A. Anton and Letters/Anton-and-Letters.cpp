#include <iostream>
#include <string>
using namespace std;

int main()
{
    int letters[26] = {0};

    string s;
    getline(cin, s);

    for (int i = 0; i < s.length(); i++)
    {
        if (s[i] != ',' && s[i] != ' ' && s[i] != '{' && s[i] != '}')
        {
            letters[s[i] - 'a']++;
        }
    }

    int count = 0;
    for (int i = 0; i < 26; i++)
    {
        if (letters[i] >= 1)
            count++;
    }
    cout << count << endl;
}