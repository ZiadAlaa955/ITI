#ifndef UI_FILE
#define UI_FILE

#include <iostream>
#include"../Person/Person.hpp"

using namespace std;
class UI{

    public:
    UI* login();
    virtual void printMenu();
};

#endif