//Task 4
var x = prompt("Enter 1st value: ");
var y = prompt("Enter 2nd value: ");
var z = prompt("Enter 3rd value: ");

if (x % y == 0 && x % z == 0) {
  console.log("Both " + y + " And " + z + " are divisible by " + x);
} else if (x % y == 0) {
  console.log("Only " + y + " is divisible by " + x);
} else if (x % z == 0) {
  console.log("Only " + z + " is divisible by " + x);
} else {
  console.log("Nothing is divisible by " + x);
}
