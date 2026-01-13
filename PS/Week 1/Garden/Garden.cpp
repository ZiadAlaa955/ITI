
#include <iostream>
using namespace std;
int main()
{
    int numOfBuck, gSize;
    cin >> numOfBuck;
    int *arr = new int[numOfBuck];

    cin >> gSize;
    for (int i = 0; i < numOfBuck; i++)
    {
        cin >> arr[i];
    }
    int max = 0;
    for (int i = 0; i < numOfBuck; i++)
    {
        if (gSize % arr[i] == 0)
        {
            if (max < arr[i])
                max = arr[i];
        }
    }
    cout << gSize / max << endl;
}

// 3 buckets => 2L, 3L, 5L
// 3 6
// 2 3 5

/*
6 buckets =>
6 7
1 2 3 4 5 6
*/