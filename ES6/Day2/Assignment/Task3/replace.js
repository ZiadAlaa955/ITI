let replaceObj = {
  [Symbol.replace]: function (str) {
    if (str.length > 15) {
      str = str.slice(0, 15);
      str += "...";
      return str;
    } else {
      return str;
    }
  },
};

let myStr = "Ziad Alaa Ezzat Yahia";
myStr = myStr.replace(replaceObj);
console.log(myStr);

console.log("------------------");

let myStr2 = "Ziad";
myStr2 = myStr2.replace(replaceObj);
console.log(myStr2);
