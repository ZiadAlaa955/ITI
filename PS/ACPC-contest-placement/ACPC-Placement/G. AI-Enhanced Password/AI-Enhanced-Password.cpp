#include <iostream>
#include <string>
using namespace std;

int main()
{
    string s;
    cin >> s;

    int passlen = s.length();
    string passLength = to_string(passlen);

    int totalLen = passlen + passLength.length();
    string total = to_string(totalLen);
    if (total[total.length() - 1] == '0')
    {
        total[total.length() - 1] = '1';
    }

    cout << s + total << endl;
}