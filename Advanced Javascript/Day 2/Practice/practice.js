//Object-oriented JS
/*
=> is the use of classes to create objects
=> Inheritance, Encpsulation, Polymorphism, Abstraction

*custom object: that I who create & use
-->is a constructor with methods & properties
-->Ways: literal-function, factory-function, constructor-function
*/

/*Literal-function*/
// let obj = {
//   name: "Ziad",
//   click: function () {
//     alert("Hello " + this.name);
//   },
//   details: {
//     myColor: "Red",
//     myAge: 22,
//   },
// };
// console.log(obj instanceof Object);

// let emp1 = { name: "Ziad", age: 22 };
// let emp2 = { name: "Ali", age: 22 };

// emp2.salary = 10000;

////////////////////////////////////////

/*factory-function*/
// let Employee = function (eName, eAge) {
//   return {
//     name: eName,
//     age: eAge,
//   };
// };

// let emp1 = Employee("Ziad", 22);
// let emp2 = Employee("Ahmed", 22);

////////////////////////////////////////

/*Constructor-function*/
// function Employee(name = "", age = 0) {
//   this.name = name;
//   this.age = age;
// }
// let emp1 = new Employee("Ziad", 22);
// let emp2 = new Employee("Ahmed", 22);
// let emp3 = new Employee();

//Adding methods to constructor-function --> shared function
// function displayAll() {
//   alert("Employee " + this.name + " is " + this.age + " years old");
// }
// function Employee(name, age, salary = 2000) {
//   this.name = name;
//   this.age = age;
//   this.salary = salary;
//   this.display = displayAll;
// }

// let emp1 = new Employee("Ziad", 22);
// emp1.display();

/*This & Colsure */
// function Employee(name, age) {
//   this.name = name;
//   this.age = age;
//   this.show = function () {
//     let that = this;
//     setTimeout(function () {
//       alert("Employee " + that.name + " is " + that.age + " years");
//     }, 3000);
//   };
// }

// let me = new Employee("Ziad", 22);
// me.show();

/*Default Binding*/
// function func() {
//   console.log(this);
// }
// func(); //Window object

/*Implicit Binding*/
// let obj = {
//   objName: "myObj",
//   fun: func,
// };
// console.log(obj.fun());

// function myFunc() {
//   console.log(this.val);
// }
// var val = "myVal";

// var obj1 = {
//   val: "obj1Val",
//   myFunc: myFunc,
// };
// var obj2 = {
//   val: "obj1Va2",
//   myFunc: myFunc,
// };

// myFunc();
// obj1.myFunc();
// obj2.myFunc();

/*Explicit Binding */
// var myObj = {
//   name: "myObj Object",
//   myFunc: function () {
//     alert(this.name);
//   },
//   myFuncArgs: function (x, y) {
//     alert(this.name + " " + x + " " + y);
//   },
// };
// var obj1 = {
//   name: "obj1 Object",
// };
// // myObj.myFuncArgs(1, 2);
// myObj.myFuncArgs.bind(obj1, 5, 6)();

/*this & closure */

/*Privileged methods */
let user = function (name) {
  let age = 22;
  this.getAge = function () {
    return age;
  };
};
let user1 = new user("Ziad");
console.log(user1.age);
