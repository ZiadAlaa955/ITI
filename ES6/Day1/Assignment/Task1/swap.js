var x = 50;
var y = 100;

console.log(`Before: x = ${x}, y= ${y}`);

var arr = [x, y]; // [50,100]
var [y, x] = arr; // [100,50]

console.log(`After: x = ${x}, y= ${y}`);
