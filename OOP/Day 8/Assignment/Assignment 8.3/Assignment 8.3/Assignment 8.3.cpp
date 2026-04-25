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
	/*constructors*/
	bankAccount() {
		accountHolder = "Unkown";
		balance = 0;
		count++;
		accountNumber = count;
	}
	bankAccount(string name, double balance) {
		accountHolder = name;
		this->balance = balance;
		count++;
		accountNumber = count;
	}
	bankAccount(bankAccount& other){
		this->accountHolder = other.accountHolder;
		this->balance = other.balance;
		count++;
		this->accountNumber = count;
		cout << greenColor << "copy constructor called..." << defaultANSI << endl;
	}
	bankAccount(bankAccount&& other) noexcept
	{
		this->accountHolder = other.accountHolder;
		this->accountNumber = other.accountNumber;
		this->balance = other.balance;

		other.accountHolder = "";
		other.accountNumber = 0;
		other.balance = 0;

		cout << greenColor << "move constructor called..." << defaultANSI << endl;
	}
	/*=operators*/
	bankAccount& operator=(bankAccount& b) = delete;
	bankAccount& operator=(bankAccount&& other) noexcept
	{
		this->accountHolder = other.accountHolder;
		this->accountNumber = other.accountNumber;
		this->balance = other.balance;

		other.accountHolder = "";
		other.accountNumber = 0;
		other.balance = 0;

		return *this;
	}
	/*bankAccount methods*/
	bankAccount& deposite(double amount) {
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

	/*cout & cin operators*/
	friend ostream& operator<<(ostream& os, bankAccount& bank);
	friend istream& operator>>(istream& os, bankAccount& bank);

};

ostream& operator<<(ostream& os, bankAccount& bank){
	os << "-------------------------------------" << endl;
	os << "Account " << bank.accountNumber << " info:" << endl;
	os << "-------------------------------------" << endl;
	os << "Name: " << bank.accountHolder << endl;
	os << "Account number: " << bank.accountNumber << endl;
	os << "Balance: " << bank.balance << endl;
	return os;
}

istream& operator>>(istream& in, bankAccount& bank) {
	cout << "Enter account name:" << endl;
	in >> bank.accountHolder;
	cout << "Enter balance: " << endl;
	in >> bank.balance;

	return in;
}


int bankAccount::count = 0;

int main()
{
	bankAccount b1("Ziad", 1000); 
	cout << "b1: " << endl << b1; 

	bankAccount b2 = b1; 
	cout << "b2: " << endl << b2;

	b1.deposite(200).withdraw(50).getBalance().showAccount();   

	bankAccount b3("Ahmed", 5000);
	cout << "b3 before move: " << endl << b3;
	b1 = std::move(b3);
	cout << "b1 : " << endl << b1; 
	cout << "b3: " << endl << b3;   

	bankAccount b4 = bankAccount();
	std::cin >> b4;

	bankAccount::showCounter();
}