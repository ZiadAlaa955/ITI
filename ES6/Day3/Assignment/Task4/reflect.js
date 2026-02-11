let obj = {
  userName: "Ziad",
  address: "123Street",
  age: 22,
};

let handler = {
  has(target, prop) {
    if (target.hasOwnProperty(prop)) {
      console.log("Object has this property");
      return true;
    } else {
      console.log("Object has not this property");
      return false;
    }
  },
  getOwnPropertyDescriptor(target, prop) {
    if (Reflect.has(target, prop)) {
      return Reflect.getOwnPropertyDescriptor(target, prop);
    } else {
      return undefined;
    }
  },
  deleteProperty(target, prop) {
    if (Reflect.has(target, prop)) {
      Reflect.deleteProperty(target, prop);
      return true;
    } else {
      return false;
    }
  },
  defineProperty(target, prop, descriptor) {
    if (Reflect.has(target, prop)) {
      console.log(`This property exist`);
      return false;
    } else {
      return Reflect.defineProperty(target, prop, descriptor);
    }
  },
  ownKeys(target) {
    let keys = Reflect.ownKeys(target);
    if (keys.length == 0) {
      throw "this object has no properties";
    } else {
      return keys;
    }
  },
};

let myProxy = new Proxy(obj, handler);

console.log("userName" in myProxy);

console.log(Object.getOwnPropertyDescriptor(myProxy, "userName"));

console.log(delete myProxy.age);
console.log(Object.getOwnPropertyDescriptor(myProxy, "age"));

Object.defineProperty(myProxy, "email", {
  value: "ziad@gmail.com",
  writable: true,
  enumerable: true,
  configurable: true,
});
console.log(Object.getOwnPropertyDescriptor(myProxy, "email"));

console.log(Reflect.ownKeys(myProxy));
