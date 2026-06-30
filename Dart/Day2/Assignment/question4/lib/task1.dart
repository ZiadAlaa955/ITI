void task1() {
  List<int> list = [10, 20, 30, 45, 55];
  List<int> filteredList = list.where((n) => n < 50).toList();
  List.unmodifiable(filteredList);
  List<int> reversedList = filteredList.reversed.toList();

  print(reversedList);
}
