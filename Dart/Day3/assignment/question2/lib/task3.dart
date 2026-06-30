Stream<int> outputInteger() async* {
  for (int i = 1; i <= 5; i++) {
    yield i;
    await Future.delayed(Duration(seconds: 1));
  }
}

void task3() async {
  await for (final i in outputInteger()) {
    print(i);
  }
}
