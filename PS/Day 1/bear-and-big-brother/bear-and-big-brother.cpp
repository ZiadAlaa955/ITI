#include <iostream>
#include <map>
using namespace std;

int main()
{
    int years = 0;
    int limak, bob; // 4, 9
    cin >> limak >> bob;
    while (limak <= bob) // 4,9
    {
        limak *= 3; // 12 36
        bob *= 2;   // 18 36
        years++;
    }
    cout << years << endl;
}