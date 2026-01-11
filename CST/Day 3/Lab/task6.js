// task 6
var row = Number(prompt("Enter number of rows:"));

for (var i = 1; i <= row; i++) {
  var stars = "";
  for (var j = 1; j <= i; j++) {
    stars += "*";
  }

  console.log(stars);
}
