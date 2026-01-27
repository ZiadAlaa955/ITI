function fun(obj) {
  let defaultObj = {
    courseName: "ES6",
    courseDuration: "3days",
    courseOwner: "javaScript",
  };

  let objKeys = Object.keys(obj);
  for (let elem of objKeys) {
    if (!(elem in defaultObj)) {
      throw Error(`Invalid property: ${elem}`);
    }
  }

  let result = {
    ...defaultObj,
    ...obj,
  };

  return result;
}

console.log(
  fun({
    courseName: "HTML5",
    courseDuration: "5days",
    courseOwner: "HTML",
  }),
);
console.log(
  fun({
    courseName: "HTML5",
    courseDuration: "5days",
  }),
);
console.log(
  fun({
    courseInstructor: "Arwa",
  }),
);
