#include <iostream>
#include <vector>
using namespace std;

int main()
{
    int n, t;
    cin >> n >> t;
    vector<int> books;
    for (int i = 0; i < n; i++)
    {
        int x;
        cin >> x;
        books.push_back(x);
    }

    int L = 0, R = 0;
    int maxT = 0;
    int numOfBooks = 0;
    while (R != n)
    {
        maxT += books[R];
        while (maxT > t)
        {
            maxT -= books[L];
            L++;
        }

        numOfBooks = max(numOfBooks, (R - L + 1));

        R++;
    }
    cout << numOfBooks << endl;
}

// 3 1 2 1
