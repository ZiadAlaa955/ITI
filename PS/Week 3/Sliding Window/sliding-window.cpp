#include <iostream>

using namespace std;

// Find the maximum sum of 3 consecutive elements
/*
Imagine a literal window frame sliding over a strip of numbers. You only see k numbers at a time.
When the window slides one step to the right, one new number enters, and one old number leaves.
*/

int main()
{
    int arr[6] = {2, 1, 5, 1, 3, 2};
    int k = 3;
    int currentSum = 0;

    for (int i = 0; i < k; i++)
    {
        currentSum += arr[i];
    }

    int maxSum = currentSum;

    for (int i = k; i < 6; i++)
    {
        currentSum += arr[i];
        currentSum -= arr[i - k];
        maxSum = max(maxSum, currentSum);
    }

    cout << maxSum << endl;
}