#include <iostream>

using namespace std;

/*
Use Case: Usually requires a sorted array.
Great for finding two numbers that sum up to a target X.
*/

int main()
{
    int arr[5] = {1, 3, 5, 7, 10};
    int target = 8;
    int L = 0, R = 4;

    bool flag = false;
    while (L < R)
    {
        int currentSum = arr[L] + arr[R];
        if (currentSum == target)
        {
            cout << "Found: " << arr[L] << " + " << arr[R] << endl;
            flag = true;
            break;
        }
        else if (currentSum > target)
        {
            R--;
        }
        else
        {
            L++;
        }
    }
    if (flag == false)
    {
        cout << "Not found..." << endl;
    }
}