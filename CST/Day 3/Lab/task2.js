//Task 2
var valuesNumber = Number(prompt("Enter number of values", "2"));

function sum(valuesNumber) {
  var n;
  var i = 0;
  var sum = 0;

  while (i < valuesNumber && sum <= 100) {
    n = Number(prompt("Enter a value"));

    if (isFinite(n)) {
      if (n == 0) break;
      sum += n;
    } else {
      continue;
    }
    i++;
  }

  return sum;
}

console.log("Total sum: " + sum(valuesNumber));
