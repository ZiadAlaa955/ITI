class Coordinates {
  final double x;
  final double y;

  const Coordinates(this.x, this.y);
}

void task3() {
  const coordinates1 = Coordinates(10, 20);
  const coordinates2 = Coordinates(10, 20);

  print(identical(coordinates1, coordinates2));
}
