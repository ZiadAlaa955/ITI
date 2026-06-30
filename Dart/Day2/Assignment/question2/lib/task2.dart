void evaluateIncomingData(Object payload) {
  var res = switch (payload) {
    (String name, int age) => print("User name: $name, Age: $age"),
    [int a, int b] => print("a + b = ${a + b}"),
    int x when x % 5 == 0 => print("Multiple of 5 : $x"),
    _ => print("Unmatched obkect structures"),
  };
}

void task2() {
  evaluateIncomingData(10);
}
