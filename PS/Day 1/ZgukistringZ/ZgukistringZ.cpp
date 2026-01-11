#include <iostream>
#include <vector>
#include <climits>
using namespace std;

int main()
{
    // create freq array for each string & initialize every char = zero
    vector<int> charactersA(26, 0), charactersB(26, 0), charactersC(26, 0);

    // count frequencey of every character in each string
    string a, b, c;
    cin >> a >> b >> c;
    for (char x : a)
    {
        charactersA[x - 'a']++;
    }
    for (char x : b)
    {
        charactersB[x - 'a']++;
    }
    for (char x : c)
    {
        charactersC[x - 'a']++;
    }

    // get max possible count of b-string could be extracted from a
    int maxPossibleB = INT_MAX;
    bool bHasChars = false;
    for (int i = 0; i < 26; i++)
    {
        if (charactersB[i] > 0)
        {
            bHasChars = true;
            int possible = charactersA[i] / charactersB[i];
            if (maxPossibleB > possible)
            {
                maxPossibleB = possible;
            }
        }
    }
    if (bHasChars == false)
        maxPossibleB = 0;

    int maxB = 0;
    int maxC = 0;
    int total = 0;

    for (int i = 0; i <= maxPossibleB; i++)
    {
        int currentPossibleMaxC = INT_MAX;
        bool cHasChars = false;
        for (int j = 0; j < 26; j++)
        {
            if (charactersC[j] > 0)
            {
                cHasChars = true;
                int remains = charactersA[j] - (i * charactersB[j]);
                int possibleC = remains / charactersC[j];
                if (currentPossibleMaxC > possibleC)
                {
                    currentPossibleMaxC = possibleC;
                }
            }
        }

        if (cHasChars == false)
            currentPossibleMaxC = 0;

        if (total < i + currentPossibleMaxC)
        {
            total = i + currentPossibleMaxC;
            maxB = i;
            maxC = currentPossibleMaxC;
        }
    }

    // output
    for (int i = 0; i < maxB; i++)
    {
        cout << b;
    }
    for (int i = 0; i < maxC; i++)
    {
        cout << c;
    }
    for (int i = 0; i < 26; i++)
    {
        int waste = charactersA[i] - (maxB * charactersB[i]) - (maxC * charactersC[i]);
        for (int j = 0; j < waste; j++)
        {
            cout << (char)('a' + i);
        }
    }
}

/*
// get the max possible number of b-strign can be extracted from a-string
    int maxPossibleB = INT_MAX;
    for (int i = 0; i < 26; i++)
    {
        if (charactersB[i] > 0)
        {
            int bestB = charactersA[i] / charactersB[i];
            if (maxPossibleB > bestB)
                maxPossibleB = bestB;
        }
    }

    int bestCountOfB = 0;
    int bestCountOfC = 0;
    int maxTotal = 0;

    // Iterate through every count of b-string from 0 to maxPossibleB
    for (int i = 0; i <= maxPossibleB; i++)
    {
        int currentMaxPossibleC = INT_MAX;
        // Iterate through C-string in every case of b-string possible count
        for (int j = 0; j < 26; j++)
        {
            if (charactersC[j] > 0)
            {
                // remainsFromcharacters in a = characters in a - (countOfB in this case * number of characters that B could take)
                int remainsFormA = charactersA[j] - (i * charactersB[j]);
                int possible = remainsFormA / charactersC[j];
                if (currentMaxPossibleC > possible)
                    currentMaxPossibleC = possible;
            }
        }
        if (i + currentMaxPossibleC > maxTotal)
        {
            maxTotal = i + currentMaxPossibleC;
            bestCountOfB = i;
            bestCountOfC = currentMaxPossibleC;
        }
    }

    // the output
    for (int i = 0; i < bestCountOfB; i++)
    {
        cout << b;
    }
    for (int i = 0; i < bestCountOfC; i++)
    {
        cout << c;
    }
    for (int i = 0; i < 26; i++)
    {
        int wasteOfB_AND_C = charactersA[i] - (bestCountOfB * charactersB[i]) - (bestCountOfC * charactersC[i]);
        for (int j = 0; j < wasteOfB_AND_C; j++)
        {
            cout << (char)('a' + i);
        }
    }
*/
