//Task 5
var beginRange = Number(prompt("Enter begin range:"));
var endRange = Number(prompt("Enter end range:"));
var sum = 0;

var output3 = [];
for (var i = beginRange; i <= endRange; i++) {
  if (i % 3 == 0) {
    output3.push(i);
    sum += i;
  }
}

var output5 = [];
for (var i = beginRange; i <= endRange; i++) {
  if (i % 5 == 0) {
    output5.push(i);
    sum += i;
  }
}

console.log("Number multiple of 3: " + output3);
console.log("Number multiple of 5: " + output5);
console.log("Total sum = " + sum);
