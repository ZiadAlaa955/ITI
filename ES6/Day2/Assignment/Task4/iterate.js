let iterateObj = {
  name: "Ziad",
  age: 22,
  country: "Egypt",
  [Symbol.iterator]: function* () {
    let keys = Object.keys(iterateObj);

    for (let key of keys) {
      yield { key: key, value: iterateObj[key] };
    }
  },
};

for (let elem of iterateObj) {
  console.log(elem);
}
