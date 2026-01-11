#include <iostream>

using namespace std;

string redColor = "\033[31m";
string greenColor = "\033[32m";
string defaultANSI = "\033[0m";

class bankAccount {
	string accountHolder;
	int accountNumber;
	double balance;
	static int count;

public:
	bankAccount() {
		accountHolder = "Unkown";
		balance = 0;
		count++;
		accountNumber = count;
	}
	bankAccount(string name,double balance) {
		accountHolder = name;
		this->balance = balance;
		count++;
		accountNumber = count;
	}

	bankAccount& deposite (double amount){
		balance += amount;
		cout << greenColor << "depoiste done successfuly..." << defaultANSI << endl;
		return *this;
	}

	bankAccount& withdraw(double amount) {
		if (amount < 0) {
			cout << redColor << "cannot withdraw, this amount is less than your zero" << defaultANSI << endl;
		}
		else if (amount <= balance) {
			balance -= amount;
		}
		else {
			cout << redColor << "cannot withdraw, this amount is larger than your balance" << defaultANSI << endl;
		}
		return *this;
	}

	bankAccount& showAccount() {
		cout << "-------------------------------------" << endl;
		cout << "Account " << accountNumber << " info:" << endl;
		cout << "-------------------------------------" << endl;
		cout << "Name: " << accountHolder << endl;
		cout << "Account number: " << accountNumber << endl;
		cout << "Balance: " << balance << endl;
		return *this;
	}
	bankAccount& getBalance() {
		cout << "Your balance is: " << balance << endl;
		return *this;
	}

	static void showCounter() {
		cout << "Count of account: " << count << endl;
	}

};

int bankAccount::count = 0;

int main()
{
	bankAccount b1 = bankAccount("Ziad", 1000);
	b1.deposite(2000).getBalance().withdraw(-1000).getBalance().showAccount();

	bankAccount b2 = bankAccount("Ahmed", 1000);

	bankAccount::showCounter();
}


/*
3) = > Design a BankAccount Class :
--------------------------------

Simulate a simple banking system using classes.
1. Design a BankAccount class with the following data members :
-accountHolder(name) [done]
- accountNumber(auto - generated(incremented) using nextID) [done]
- balance [done]
- counter(to count total accounts created) [done]
2. Implement constructors :
Default constructor [done]
Parameterized constructor[done]
3. Implement methods :
deposit → increases balance and returns a reference to the object(to support chaining).[done]
withdraw → decreases balance.[done]
showAccount() → displays all account information.[done]
getBalance() → returns the current balance.
showCounter() → to display how many accounts were created.



*/