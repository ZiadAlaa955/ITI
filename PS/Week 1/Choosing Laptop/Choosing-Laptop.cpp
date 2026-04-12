#include <iostream>
#include <vector>
#include <limits.h>
using namespace std;

struct laptop
{
    int speed;
    int ram;
    int hdd;
    int cost;
    bool isOutdated = false;
};

int main()
{
    int n;
    cin >> n;

    vector<laptop> laptops(n);

    for (int i = 0; i < n; i++)
    {
        int speed, ram, hdd, cost;
        cin >> speed >> ram >> hdd >> cost;

        laptops[i].speed = speed;
        laptops[i].ram = ram;
        laptops[i].hdd = hdd;
        laptops[i].cost = cost;
    }

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            int total = 0;
            if (i != j)
            {
                if (laptops[i].speed < laptops[j].speed)
                    total++;
                if (laptops[i].ram < laptops[j].ram)
                    total++;
                if (laptops[i].hdd < laptops[j].hdd)
                    total++;
            }
            if (total >= 3)
            {
                laptops[i].isOutdated = true;
                break;
            }
        }
    }

    int minCost = INT_MAX;
    int choosenLaptop;
    for (int i = 0; i < n; i++)
    {
        if (!laptops[i].isOutdated)
        {
            if (minCost > laptops[i].cost)
            {
                choosenLaptop = i + 1;
                minCost = laptops[i].cost;
            }
        }
    }

    cout << choosenLaptop << endl;
}

// for (int i = 0; i < n; i++)
// {
//     cout << i + 1 << ": " << endl;
//     cout << "Speed: " << laptops[i].speed << endl;
//     cout << "ram: " << laptops[i].ram << endl;
//     cout << "hdd: " << laptops[i].hdd << endl;
//     cout << "cost: " << laptops[i].cost << endl;
//     cout << "outdated: " << laptops[i].isOutdated << endl;
//     cout << "-------------------------------" << endl;
// }

/*
5
2100 512 150 200   X
2000 2048 240 350
2300 1024 200 320
2500 2048 80 300
2000 512 180 150  X
*/