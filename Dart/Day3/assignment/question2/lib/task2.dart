Future<String> fetchFirstOperations() async {
  await Future.delayed(Duration(seconds: 2));
  return "Data 1";
}

Future<String> fetchSecondOperations() async {
  await Future.delayed(Duration(seconds: 2));
  return "Data 2";
}

void task2() async {
  final legacyMethod = await Future.wait([
    fetchFirstOperations(),
    fetchSecondOperations(),
  ]).timeout(const Duration(seconds: 2));
  print(legacyMethod);

  final modernMethod = await ([
    fetchFirstOperations(),
    fetchSecondOperations(),
  ]).wait.timeout(const Duration(seconds: 2));
  print(modernMethod);
}
