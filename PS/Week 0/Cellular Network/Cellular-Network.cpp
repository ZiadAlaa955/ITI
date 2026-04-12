#include <iostream>
#include <map>
#include <vector>
using namespace std;

int main()
{
    int cities, towers;
    cin >> cities >> towers;

    vector<int> citiesVector;

    for (int i = 0; i < cities; i++)
    {
        int x;
        cin >> x;
        citiesVector.push_back(x);
    }
    for (int i = 0; i < towers; i++)
    {
    }
    // map<int, int> citiesmp;
    // vector<int> towersvector;

    // int minCity = INT_MAX, maxCity = INT_MIN;

    // int x;
    // cin >> x;
    // if (x < minCity)
    //     minCity = x;
    // if (x > maxCity)
    //     maxCity = x;
    // citiesmp[x] = 0;
    // }

    // for (int i = 0; i < towers; i++)
    // {
    //     int x;
    //     cin >> x;
    //     towersvector.push_back(x);
    // }

    // int i =0;
    // for(auto it : citiesmp){

    // }
}

/*
3 2
-2 2 4

-3 0
*/