let arrSize = Number(prompt("Enter array size: "));
let arr = [];

for (let i = 0; i < arrSize; i++) {
  let num = Number(prompt("Enter a number :"));
  arr[i] = num;
}

console.log("Array: " + arr);
console.log("Array after sorting Ascending: " + arr.sort((a, b) => a - b));
console.log("Array after sorting Descending: " + arr.sort((a, b) => b - a));
