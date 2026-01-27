function* fibo1(numOfElements) {
  let x = 0;
  let y = 1;
  z = x + y;

  for (let i = 0; i < numOfElements; i++) {
    yield x;
    x = y;
    y = z;
    z = x + y;
  }
}

for (let elem of fibo1(7)) {
  console.log(elem);
}

console.log("------------------------------");

//////////////////////////////////
function* fibo2(maxNumber) {
  let x = 0;
  let y = 1;
  z = x + y;

  while (x <= maxNumber) {
    yield x;
    x = y;
    y = z;
    z = x + y;
  }
}

for (let elem of fibo2(10)) {
  console.log(elem);
}
