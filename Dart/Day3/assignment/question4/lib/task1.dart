class Transaction {
  double _balance = 0;

  double get balance => _balance;

  set deposite(double amount) {
    if (amount <= 0) {
      print("amount must be positive");
    } else {
      _balance += amount;
    }
  }
}

void task1() {
  Transaction transaction = Transaction();
  transaction.deposite = 1000;
  print(transaction.balance);
}
