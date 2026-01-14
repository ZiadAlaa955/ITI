function obj(start, end, step) {
  /*Private */
  let list = [];

  /*Assign values */
  let fillList = function () {
    for (let i = start; i <= end; i += step) {
      list.push(i);
    }
  };
  fillList();

  /*Getter */
  this.getter = function () {
    return list;
  };

  /*Methods */
  this.append = function (val) {
    if (list.length == 0) {
      list.push(val);
    } else if (val == list[list.length - 1] + step) {
      list.push(val);
    } else {
      throw "Wrong Value";
    }
  };
  this.prepend = function (val) {
    if (list.length == 0) {
      list.push(val);
    } else if (val == list[0] - step) {
      list.unshift(val);
    } else {
      throw "Wrong Value";
    }
  };
  this.pop = function () {
    list.pop();
  };
  this.dequeue = function () {
    list.shift();
  };
}

let obj1 = new obj(0, 10, 2);

obj1.pop();
obj1.pop();
obj1.dequeue();

obj1.append(8);
obj1.prepend(0);

console.log(obj1.getter().join(" "));
