let obj = {
  id: "10",
  Location: "asdas",
  address: "asdsa",
  getSetGen: function () {
    let objLength = Object.keys(this).length;
    for (let i = 0; i < objLength; i++) {
      let propertyName = Object.keys(this)[i];
      if (typeof this[propertyName] == "function") {
        continue;
      } else {
        this[propertyName + "Getter"] = function () {
          return this[propertyName];
        };
        this[propertyName + "Setter"] = function (propertyValue) {
          this[propertyName] = propertyValue;
          return true;
        };
      }
    }
    console.log("Getters & setters generated successfully...");
  },
};

obj.getSetGen();
console.log(Object.keys(obj));
console.log(obj["idSetter"](20));
console.log(obj["idGetter"]());
