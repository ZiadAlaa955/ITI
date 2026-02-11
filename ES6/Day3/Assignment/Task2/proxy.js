let obj = {
  userName: "Ziad",
  address: "123Street",
  age: 22,
};

let handler = {
  set(target, prop, value) {
    if (prop == "userName") {
      if (value.length == 7) {
        target[prop] = value;
      } else {
        throw "wrong value";
      }
    } else if (prop == "address") {
      if (typeof value == "string") {
        target[prop] = value;
      } else {
        throw "Wrong data type";
      }
    } else if (prop == "age") {
      if (value >= 25 && value <= 60) {
        target[prop] = value;
      } else {
        throw "wrong age range";
      }
    }
  },
};

let myProxy = new Proxy(obj, handler);

try {
  myProxy.userName = "ziad";
} catch (e) {
  console.log(e);
}

try {
  myProxy.address = 132;
} catch (e) {
  console.log(e);
}

try {
  myProxy.age = 22;
} catch (e) {
  console.log(e);
}
