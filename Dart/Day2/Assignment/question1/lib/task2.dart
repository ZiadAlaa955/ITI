void task2() {
  final List<int> list1 = [10, 20, 30];
  final List<int> list2 = [10, 20, 30];
  print(identical(list1, list2));
  //false => different memory location

  const List<int> constList1 = [10, 20, 30];
  const List<int> constList2 = [10, 20, 30];
  print(identical(constList1, constList2));
  //true => same memory location => same list values
}
