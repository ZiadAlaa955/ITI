#include <iostream>
#include <vector>
using namespace std;

int main()
{
    int n;
    cin >> n;

    vector<int> numbers;

    for (int i = 0; i < n; i++)
    {
        int num;
        cin >> num;
        numbers.push_back(num);
    }

    int totalEven = 0;
    int totalOdd = 0;
    for (int i = 0; i < n; i++)
    {
        if (numbers[i] % 2 == 0)
            totalEven++;
        else
            totalOdd++;
    }

    int diffNum;
    if (totalEven == 1)
    {
        for (int i = 0; i < n; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                diffNum = i + 1;
                break;
            }
        }
    }
    else if (totalOdd == 1)
    {
        for (int i = 0; i < n; i++)
        {
            if (numbers[i] % 2 != 0)
            {
                diffNum = i + 1;
                break;
            }
        }
    }
    cout << diffNum << endl;
}

/*
2 4 7 8 10
*/