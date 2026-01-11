//task 7
var b = true;
while (b) {
  var n1 = Number(prompt("task 7: Enter first value: "));
  if (isNaN(n1)) {
    alert("Re-enter a valid value");
    continue;
  }

  var n2 = Number(prompt("Enter second value: "));
  if (isNaN(n2)) {
    alert("Re-enter a valid value");
    continue;
  }

  var s = prompt("Enter a string value: ");
  if (!isNaN(s)) {
    alert("Re-enter a valid value");
    continue;
  }

  var sum = 0;
  var outputvalues = [];

  if (s == "odd") {
    if (n1 > n2) {
      for (var i = n1; i >= n1; i--) {
        if (i % 2 != 0) {
          outputvalues.push(i);
          sum += i;
        }
      }
    } else {
      for (var i = n1; i <= n2; i++) {
        if (i % 2 != 0) {
          outputvalues.push(i);
          sum += i;
        }
      }
    }
  } else if (s == "even") {
    if (n1 > n2) {
      for (var i = n1; i >= n1; i--) {
        if (i % 2 == 0) {
          outputvalues.push(i);
          sum += i;
        }
      }
    } else {
      for (var i = n1; i <= n2; i++) {
        if (i % 2 == 0) {
          outputvalues.push(i);
          sum += i;
        }
      }
    }
  } else {
    if (n1 > n2) {
      for (var i = n1; i >= n1; i--) {
        outputvalues.push(i);
        sum += i;
      }
    } else {
      for (var i = n1; i <= n2; i++) {
        outputvalues.push(i);
        sum += i;
      }
    }
  }
  console.log("%cOutput: " + outputvalues, "color: blue; font_weight: bold;");
  console.log("%cTotal sum: " + sum, "color: red; font_weight: bold;");

  b = false;
}
