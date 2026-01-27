function minMax(...arr) {
  let minVal = Math.min(...arr);
  let maxVal = Math.max(...arr);

  let result = {
    minVal,
    maxVal,
  };

  return result;
}

let myArr = [50, 10, 20, 30];

console.log(`Min value: ${minMax(...myArr).minVal}`);
console.log(`Max value: ${minMax(...myArr).maxVal}`);
