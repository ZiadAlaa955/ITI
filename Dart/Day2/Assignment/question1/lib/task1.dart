void task1() {
  final List<int> list = [1, 2, 3, 4, 5];
  list.add(6);

  const List<int> constList = [1, 2, 3, 4, 5];
  // constList.add(6);
  //unhandeled exception => unmodifiabel list
}
