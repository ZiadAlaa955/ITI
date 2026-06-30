void task2() {
  int score = 50;
  score = score++ + ++score; //50 + 52
  print(score); //102
  //score++ => return current value and then increments
  //++score => increments and then return the value
}
