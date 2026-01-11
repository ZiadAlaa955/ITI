let myObj = {
  name: "Ziad",
  age: 22,
};

function dispVal(obj, str) {
  //check str
  if (str != "name" && str != "age") {
    return "Wrong key...";
  } else return obj[str];
}

console.log(dispVal(myObj, "name"));
