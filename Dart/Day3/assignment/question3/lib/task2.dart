class Account {
  final String username;
  final String password;
  final bool isAdmin;

  Account({
    this.username = "guest",
    this.password = "123",
    this.isAdmin = false,
  });
  Account.user(this.username, this.password) : isAdmin = false;
  Account.admin(this.username, this.password) : isAdmin = true;

  factory Account.fromRawData(Map<String, dynamic> rawData) {
    final userName = rawData["username"] as String;
    final password = rawData["password"] as String;
    final isAdmin = rawData["isAdmin"] as bool;

    if (isAdmin == true) {
      return Account.admin(userName, password);
    } else {
      return Account.user(userName, password);
    }
  }
}

void task2() {
  final json = {'username': 'Ziad', 'password': '123465', 'isAdmin': false};

  final myAccount = Account.fromRawData(json);
  print(myAccount.username);
  print(myAccount.password);
  print(myAccount.isAdmin);
}
