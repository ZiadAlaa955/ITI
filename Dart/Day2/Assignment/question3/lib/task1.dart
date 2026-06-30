void task1() {
  String? companyName;
  print(companyName?.length);
  companyName ??= "Default Corporate";
  print(companyName);

  String? str;
  str ??= "Lazy state";
  str ??= "Lzay State2";
  print(str);
}
