#include <iostream>
#include <vector>
using namespace std;

int main()
{
    int n, m;
    cin >> n >> m;
    vector<int> freq(101, 0);
    vector<int> studentsGrades;
    vector<int> result;
    for (int i = 0; i < n; i++)
    {
        int x;
        cin >> x;
        freq[x] = 1;
        studentsGrades.push_back(x);
    }
    int count = 0;
    for (int i = 0; i < n; i++)
    {
        if (freq[studentsGrades[i]] == 1)
        {
            freq[studentsGrades[i]] = 0;
            result.push_back(i + 1);
            count++;
        }
        if (count >= m)
            break;
    }
    if (count >= m)
    {
        cout << "YES" << endl;
        for (int i = 0; i < m; i++)
        {
            cout << result[i] << " ";
        }
    }
    else
    {
        cout << "NO" << endl;
    }
}