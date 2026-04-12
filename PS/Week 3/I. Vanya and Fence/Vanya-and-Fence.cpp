#include <iostream>
using namespace std;
int main()
{
    int n, h, minWidth = 0;
    cin >> n >> h;
    for (int i = 0; i < n; i++)
    {
        int x;
        cin >> x;
        if (x > h)
            minWidth += 2;
        else
            minWidth++;
    }

    cout << minWidth << endl;
}