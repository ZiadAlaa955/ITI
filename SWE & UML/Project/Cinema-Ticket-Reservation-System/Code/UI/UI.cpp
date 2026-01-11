#include "UI.hpp"
#include "../UserUI/UserUI.hpp"
#include "../AdminUI/AdminUI.hpp"
#include <iostream>
#include <cstdlib>
#include <conio.h>
#include <limits>
using namespace std;
UI *UI::login()
{
    cout << "\033[38m" << "Login" << "\033[0m" << endl;
    cout << "-----------" << endl;

    cout << "Username: ";
    string username;
    cin >> username;
    while (username != "admin" && username != "user")
    {
        cout << "\033[31m" << "Invalid username. Please try again." << "\033[0m" << endl;
        cout << "Username: ";
        cin >> username;
    }
    system("cls");

    cout << "Welcome, " << username << "!" << endl;
    cout << "--------------" << endl;

    cout << "Password: ";
    string password;
    cin >> password;

    while (password != "password")
    {
        cout << "\033[31m" << "Invalid password. Please try again." << "\033[0m" << endl;
        cout << "Password: ";
        cin >> password;
    }

    if (username == "admin" && password == "password")
    {
        system("cls");
        cout << "\033[32m" << "Login successful!" << "\033[0m" << endl;
        cout << "Press any key to continue..." << endl;
        _getch();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
        return new AdminUI();
    }
    else if (username == "user" && password == "password")
    {
        system("cls");
        cout << "\033[32m" << "Login successful!" << "\033[0m" << endl;
        cout << "Press any key to continue..." << endl;
        _getch();
        return new UserUI();
    }
    else
    {
        cout << "\033[31m" << "Login failed! Invalid username or password." << "\033[0m" << endl;
        return nullptr;
    }
}

void UI::printMenu() {}