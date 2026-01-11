let answer = document.getElementById("Answer");
let str = "";

function EnterEqual() {
  let total = 0; //number
  let temp = ""; //string
  let lastOperator = "";

  for (let i = 0; i < str.length; i++) {
    let char = str[i];
    if (isFinite(char) || char == ".") {
      temp += char; //3 -> 33 -> 335 -> 335.6
    } else {
      lastOperator = char;
      if (char == "+") {
        total += Number(temp);
      } else if (char == "-") {
        if (total == 0) {
          total += Number(temp);
        } else {
          total -= Number(temp);
        }
      } else if (char == "*") {
        if (total == 0) total = 1;
        total *= Number(temp);
      } else if (char == "/") {
        if (total == 0) {
          total += Number(temp);
        } else {
          total /= Number(temp);
        }
      }
      temp = "";
    }
  }
  console.log("temp: " + temp);
  console.log("lastOperator: " + lastOperator);
  if (temp != "") {
    if (lastOperator == "+") {
      total += Number(temp);
    } else if (lastOperator == "-") {
      total -= Number(temp);
    } else if (lastOperator == "*") {
      total *= Number(temp);
    } else if (lastOperator == "/") {
      total /= Number(temp);
    }
  }
  // console.log(total);
  answer.value = total;
}

function EnterNumber(num) {
  str += num;
  answer.value = str;
}

function EnterOperator(operator) {
  str += operator;
  answer.value = str;
}

function EnterClear() {
  str = "";
  answer.value = str;
}
