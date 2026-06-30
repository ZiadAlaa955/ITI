import 'dart:async';

void task1() {
  //synchronous
  print("1-Alpha");

  //deffered
  Future(() {
    print("5-Beta");
  });

  //microstack
  scheduleMicrotask(() {
    print("3-Gamma");
  });

  //microstack
  Future.microtask(() {
    print("4-Delta");
  });

  //synchronous
  print("2-Epsilon");
}
