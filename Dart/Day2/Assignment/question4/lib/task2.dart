void task2() {
  Map<String, int> stock = {'PRD-A01': 150, 'PRD-B02': 45, 'PRD-C03': 0};
  stock.putIfAbsent('PRD-A52', () => 50);

  for (var code in stock.keys) {
    print(code);
  }
  print("------------");
  for (var val in stock.values) {
    print(val);
  }
}
