var obj = {
  id: "10",
  Location: "asdas",
  address: "asdsa",
  getSetGen: function () {
    var objLength = Object.keys(this).length;
    for (var i = 0; i < objLength; i++) {
      var propertyName = Object.keys(this)[i];
      if (typeof this[propertyName] == "function") {
        continue;
      } else {
        (function (propertyName) {
          this[propertyName + "Getter"] = function () {
            return this[propertyName];
          };
          this[propertyName + "Setter"] = function (propertyValue) {
            this[propertyName] = propertyValue;
            return true;
          };
        }).call(this, propertyName);
      }
    }
    console.log("Getters & setters generated successfully...");
  },
};

obj.getSetGen();
console.log(obj["idSetter"](20));
console.log(obj["idGetter"]());
