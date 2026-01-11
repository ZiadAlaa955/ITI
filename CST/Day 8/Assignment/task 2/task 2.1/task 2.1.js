function TwoParameters(n1, n2) {
  try {
    if (arguments.length != 2) {
      throw "You should enter exactly 2 parameters";
    } else {
      console.log("successful");
    }
  } catch (err) {
    console.log(err);
  }
}

TwoParameters(10, 10);
TwoParameters(10);
TwoParameters(10, 10, 10);
