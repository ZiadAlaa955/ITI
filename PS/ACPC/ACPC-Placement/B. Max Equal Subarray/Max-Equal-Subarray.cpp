#include <iostream>
#include <map>
#include <vector>
using namespace std;
int main()
{
    int testCases;
    cin >> testCases;

    while (testCases--)
    {
        int n;
        cin >> n;
        vector<int> elements;
        for (int i = 0; i < n; i++)
        {
            int x;
            cin >> x;
            elements.push_back(x);
        }

        // Count first & last zeroes
        int firstZero = -1, lastZero = -1;
        int numOfZeroes = 0;
        for (int i = 0; i < n; i++)
        {

            if (elements[i] == 0 && firstZero == -1)
            {
                firstZero = i;
                numOfZeroes++;
            }
            if (elements[i] == 0 && firstZero != -1)
            {
                lastZero = i;
            }
        }

        /*
        2 4 0 3 0 0 3 0 4

        */
        // max length between to equal numbers
        // int max_len = 0;
        map<int, int> mp;
        for (int i = firstZero; i < lastZero; i++)
        {
            if (elements[i] == 0)
                numOfZeroes++;
            for (int j = i; j <= lastZero; j++)
            {
                if (elements[i] == elements[j])
                {
                    mp[elements[i]] = 0;
                    mp[elements[i]]++;
                }
            }
        }
        cout << "NumOfZeros: " << numOfZeroes << endl;

        // get the higer redundent element within first and last zero
        int maxIterate = 0, maxIterateNum = -1;
        for (auto it : mp)
        {
            if ((it.second > maxIterate) && it.first != 0)
            {
                maxIterate = it.second;
                maxIterateNum = it.first;
            }
        }

        cout << numOfZeroes << endl;
        cout << maxIterate << endl;
    }
}