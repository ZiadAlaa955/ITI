Function(int) trackVelocity() {
  int displacement = 0;
  return (int step) {
    displacement += step;
    print('Accumulated balance history: $displacement ');
  };
}

void task2() {
  var updateDisplacement = trackVelocity();

  updateDisplacement(15);
  updateDisplacement(20);
  updateDisplacement(-5);
}
