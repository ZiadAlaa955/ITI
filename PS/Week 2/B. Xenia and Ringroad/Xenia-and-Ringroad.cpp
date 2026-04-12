#include <iostream>
#include <vector>
using namespace std;

int main()
{
    int n, m, currentHouse = 1, steps;
    long long count = 0;
    vector<int> v;
    cin >> n >> m;
    for (int i = 1; i <= m; i++)
    {
        int taskInHouse;
        cin >> taskInHouse;
        if (currentHouse <= taskInHouse)
        {
            steps = taskInHouse - currentHouse;
        }
        else
        {
            steps = n - currentHouse + taskInHouse;
        }
        v.push_back(steps);
        currentHouse = taskInHouse;
    }
    for (int i = 0; i < v.size(); i++)
    {
        count += v[i];
    }
    cout << count << endl;
}