#include <iostream>
#include <conio.h>

using namespace std;

class employee {
public:
    string name = "Unknown";
    int age = 20;
    int salary = 1000;
    int id = 0;
};

void displayAllEmployees(const unique_ptr <employee[]>& emp, int number_of_employees) {
    if (number_of_employees == 0) {
        cout << "\033[31mNo employees to display!\033[0m\n";
        return;
    }

    cout << "-------------Display all employees-----------" << endl;
    cout << "number of employees:" << number_of_employees << endl;
    for (int i = 0; i < number_of_employees; i++) {
        cout << "\033[1;34mEmployee " << i + 1 << ":\033[1;37m" << endl;
        cout << "Name: " << emp[i].name << endl;
        cout << "Age: " << emp[i].age << endl;
        cout << "Salary: " << emp[i].salary << endl;
        cout << "ID: " << emp[i].id << endl;
        cout << "----------------------------------" << endl;
    }
}

void displayEmployee(const unique_ptr <employee[]>& emp, int number_of_employees) {
    int index;

    if (number_of_employees == 0) {
        cout << "\033[31mNo employees added yet!\033[0m\n";
        return;
    }

    cout << "-------------Display employee-----------" << endl;
    cout << "enter employee index: " << endl;
    cin >> index;

    if (index < 0 || index >= number_of_employees) {
        cout << "\033[31mInvalid index!\033[0m" << endl;;
        return;
    }

    cout << "\033[1;34mEmployee Data:\033[1;37m" << endl;
    cout << "Name: " << emp[index].name << endl;
    cout << "Age: " << emp[index].age << endl;
    cout << "Salary: " << emp[index].salary << endl;
    cout << "ID: " << emp[index].id << endl;
}

void addNewEmp(employee& emp) {
    cout << "-----------Add new Employee----------" << endl;
    cout << "Enter employee name: " << endl;
    cin >> emp.name;
    cout << "Enter employee age: " << endl;
    cin >> emp.age;
    cout << "Enter employee ID: " << endl;
    cin >> emp.id;
    cout << "Enter employee Salary: " << endl;
    cin >> emp.salary;
    cout << "\033[0;32mEmployee added successfuly... \033[0;37m" << endl;
};

int takeChoices(int& choice, int& number_of_employees, unique_ptr <employee[]>& employees, int size) {
    int key;

    key = _getch();
    if (key == 224) {
        key = _getch();
        if (key == 72) //up
        {
            choice--;
        }
        else if (key == 80) //down 
        {
            choice++;
        }
        else if (key == 71) //home
        {
            choice = 1;
        }
        else if (key == 79) //end
        {
            choice = 4;
        }
    }
    else if (key == 13) {
        system("cls");
        if (choice == 1) {
            if (number_of_employees >= size) {
                cout << "\033[31mEmployee limit reached!\033[0m\n";
            }
            else {
                addNewEmp(employees[number_of_employees]);
                number_of_employees++;
            }
        }
        else if (choice == 2)
        {
            displayEmployee(employees, number_of_employees);
        }
        else if (choice == 3)
        {
            displayAllEmployees(employees, number_of_employees);
        }
        else if (choice == 4)
        {

            cout << "Bye Bye" << endl;
            key = 27;
        }
        system("pause");
    }

    return key;
}

void printMenu() {
    cout << "----------Employee Form-------------" << endl;

    string red = "\033[31m", white = "\033[0m";
    int key, number_of_employees = 0, choice = 1, size;
    cout << "Enter number of employees:" << endl;
    cin >> size;
    unique_ptr<employee[]> employees = make_unique<employee[]>(size);

    do {
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

        key = takeChoices(choice, number_of_employees, employees, size);

        if (choice == 0) choice = 4;
        if (choice == 5) choice = 1;

    } while (key != 27);
}

int main()
{
    printMenu();

    return 0;
}