"use strict";
//Datatypes: String, Numebr, Boolean
let a1 = 1;
// a1 = true
// a1 = "str"
a1 = 6;
console.log(a1);
function add(arg1, arg2) {
    return arg1 + arg2;
}
// console.log(add(true, true));
// console.log(add("str", true));
console.log(add(1, 2));
let a2 = 1;
// a2 = "str";
//Any datatype
let x;
x = 1;
x = "test";
x = true;
//function return type
function varCheck(arg) {
    if (arg < 10)
        return true;
    return "false";
}
let o1 = varCheck(1);
//Array
let arr = [1, 2, 3];
arr = [1, 2, 5];
// arr = [1, 2, ""];
arr = ["asdas", "bfgd"];
function printArray(arg) {
    console.log(arg);
}
printArray(arr);
// printArray(123);
//Fixed size array
// let myArr: [number, number, number] = [1, 2, 3,4];
let myArr = [1, 2, 3];
//Object
// user: { name: string; age: number; courses: string[] }
let user = {
    name: "ahmed",
    age: 20,
    courses: ["c#", "C++"],
};
console.log(user);
console.log(user.name);
user.age = 10;
console.log(user.age);
// user.address = "123street";
function printUser(user) {
    console.log(user);
}
printUser(user);
// printUser("user");
