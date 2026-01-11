#include <iostream>
#include <conio.h>
#include <array>

using namespace std;

int main()
{
    cout << "----------Employee Form-------------" << endl;

    int choice = 1;
    string red = "\033[31m", white = "\033[0m";
    int key ;

   do{
       system("cls");
        if (choice == 1) {
            cout << red << "New" << white << endl;
            cout << "Display" << endl;
            cout << "Display all" << endl;
            cout << "Exit" << endl;
        }
        else if (choice == 2) {
            cout << "New" << endl;
            cout << red << "Display" << white << endl;
            cout << "Display all" << endl;
            cout << "Exit" << endl;
        }
        else if (choice == 3) {
            cout << "New" << endl;
            cout << "Display" << endl;
            cout << red << "Display all" << white << endl;
            cout << "Exit" << endl;
        }
        else if (choice == 4) {
            cout << "New" << endl;
            cout << "Display" << endl;
            cout << "Display all" << endl;
            cout << red << "Exit" << white << endl;
        }
        
        key = _getch();
        if (key == 224) {
            key = _getch();
            if (key == 72) //up
            {
                choice--;
            }
            else if(key == 80) //down 
            {
                choice++;
            }
            else if (key == 71) {
                choice = 1;
            }
            else if (key == 79) {
                choice = 4;
            }
        }
        else if (key == 13) {
            system("cls");
            if (choice == 1) {
                cout << "You are in New Page..." << endl;
            }
            else if(choice == 2)
            {

                cout << "You are in Display Page..." << endl;
            }
            else if (choice == 3)
            {

                cout << "You are in Display all Page..." << endl;
            }
            else if (choice == 4)
            {

                cout << "Bye Bye" << endl;
                key = 27;
            }
            system("pause");
        }

        if (choice == 0) choice = 4;
        if (choice == 5) choice = 1;
   } while (key != 27);
 
    return 0;
}