function fun1() {
  return [].reverse.call(arguments);
}

function fun2() {
  return [].reverse.apply(arguments);
}

function fun3() {
  let res = [].reverse.bind(arguments);
  return res();
}

console.log(fun1(5, 10, 30));
console.log(fun2(5, 10, 30));
console.log(fun3(5, 10, 30));
