// Descriptors: (data-descripor & accessor-descriptor)
/**
 *
 * 1-data descriptor
 * {
 * value:
 * writable:
 * enumurable:
 * configurable:
 * }
 *
 * 2-accessor descriptor
 * {
 * get:
 * set:
 * enumurable:
 * configurable:
 * }
 *
 * *defineProperties => objName, PropertyName, Object(include property-descriptor)
 */
/*
let myObj = {
  id: 123,
};

//Data-descriptor
Object.defineProperty(myObj, "userName", {
  value: "Ziad",
  writable: false, //edit (default = false)
  enumerable: false, //iterate (default = false)
  configurable: false, //delete (default = false)
});

for (let elem in myObj) {
  console.log(elem);
}

//Accessor-descriptor
let myAge = 22;
Object.defineProperty(myObj, "age", {
    get: function () {
        return myAge;
    },
    set: function (val) {
        myAge = val;
    },
    enumerable: true,
    configurable: false,
});
for (let elem in myObj) {
    console.log(elem);
}

*/
////////////////////////////////////////////////////
/*
let myFun = function () {
  return this.id;
};
function Employee(name, age, id) {
  let Id = id;
  Object.defineProperty(this, "userName", {
    value: name,
    writable: true,
  });
  Object.defineProperty(this, "age", {
    value: age,
  });
  Object.defineProperty(this, "id", {
    get: function () {
      return Id;
    },
    set: function (val) {
      Id = val;
    },
  });
  this.display = myFun;
}
let emp = new Employee("Ziad", 22, 123);
// Object.preventExtensions(emp);
// Object.seal(emp); //No add properties & No delete properties
Object.freeze(emp); //Non-writable, Non-configurable, No Add new properties
// function Employee(name, age, id) {
//   let Id = id;
//   Object.defineProperties(this, {
//     userName: {
//       value: name,
//       writable: true,
//     },
//     age: {
//       value: age,
//     },
//     id: {
//       get: function () {
//         return Id;
//       },
//       set: function (val) {
//         Id = val;
//       },
//     },
//   });
// }
*/
////////////////////////////////////////////////////
/**
 * Prototype is a shared area over the object
 * all functions can be implemented on Object-prototype except global accessables
 * protoype like static-method (shared over the object)
 */
function user(name, age) {
  this.name = name;
  this.age = age;
}

function Employee(name, age, id) {
  //1)Chaining parent constructor
  user.call(this, name, age);
  this.name = name;
  this.age = age;
  this.id = id;
}
//2)Prototype chain
Employee.prototype = Object.create(user.prototype);
//3)constructor
Employee.prototype.constructor = Employee;

Employee.prototype.display = function () {
  return this.id;
};
Employee.prototype.toString = function () {
  return this.name;
};
Employee.prototype.valueOf = function () {
  return this.age;
};

let emp = new Employee("Ziad", 22, 132);
