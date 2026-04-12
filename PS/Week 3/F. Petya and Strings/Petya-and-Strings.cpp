#include <iostream>
#include <string>
using namespace std;
int main()
{
    string s1, s2;
    cin >> s1 >> s2;

    int result = 0;
    for (int i = 0; i < s1.length(); i++)
    {

        if (tolower(s1[i]) < tolower(s2[i]))
        {
            result = -1;
            break;
        }
        else if (tolower(s1[i]) > tolower(s2[i]))
        {
            result = 1;
            break;
            ;
        }
    }
    cout << result << endl;
}