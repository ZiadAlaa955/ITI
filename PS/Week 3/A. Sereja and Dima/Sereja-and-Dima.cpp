#include <iostream>
#include <vector>
using namespace std;

int main()
{
    int sereja = 0, dima = 0;
    bool serejaTurn = true, dimaTurn = false;

    int n;
    cin >> n;

    vector<int> v;
    for (int i = 0; i < n; i++)
    {
        int x;
        cin >> x;
        v.push_back(x);
    }

    int L = 0, R = n - 1;
    while (L <= R)
    {
        int maxNum;
        if (v[L] > v[R])
        {
            maxNum = v[L];
            L++;
        }
        else
        {
            maxNum = v[R];
            R--;
        }

        if (serejaTurn)
        {
            sereja += maxNum;
            serejaTurn = false;
            dimaTurn = true;
        }
        else
        {
            dima += maxNum;
            dimaTurn = false;
            serejaTurn = true;
        }
    }

    cout << sereja << " " << dima << endl;
}