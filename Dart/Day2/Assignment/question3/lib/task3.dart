void task3() {
  bool isProduction = true;
  List<String> list = ["Build", "Test", "Deploy"];
  List<String> pipeline = [
    "initialize",
    if (isProduction) "Security clean",
    ...list,
    "clean",
  ];
  List<String> upperCase = [for (var p in pipeline) p.toUpperCase()];

  print(upperCase);
}
