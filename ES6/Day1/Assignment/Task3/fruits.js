let fruits = ["apple", "strawberry", "banana", "orange", "mango"];

//a) test that every element in the given array is a string
let isString = (currentValue) => typeof currentValue == "string";
console.log(
  `Is every element in this arr is a stirng: ${fruits.every(isString)}`,
);

console.log("");

//b) test that some of array elements starts with "a"
let isStartWith_a = (currentValue) => currentValue[0] == "a";
console.log(
  `some of array elements starts with "a": ${fruits.some(isStartWith_a)}`,
);

console.log("");

//c) generate new array filtered from the given array with only elements that starts with "b" or "s"
let filter_b_or_s = fruits.filter(
  (element) => element[0] == "b" || element[0] == "s",
);
console.log(
  `Filtered array with elements start with "b" OR "s": ${filter_b_or_s}`,
);

console.log("");

//d) generate new array, each element of the new array contains a string declaring that you like the give fruit element
let newArr = fruits.map((x) => `I like ${x}`);
console.log(newArr);

console.log("");

//e) use forEach to display all elements of the new array from previouse point
newArr.forEach((element) => console.log(element));
