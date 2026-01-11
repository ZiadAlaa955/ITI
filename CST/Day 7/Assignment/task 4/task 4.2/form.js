let NnumbersButtons = document.getElementsByClassName("inputButton");
let inputField = document.getElementById("txt1");
let clearButton = document.getElementById("clear");
let eraseButton = document.getElementById("erase");

for (let i = 0; i < NnumbersButtons.length; i++) {
  NnumbersButtons[i].onclick = function () {
    let val = this.value;
    inputField.value += val.trim();
  };
}

clearButton.onclick = function () {
  inputField.value = "";
};

eraseButton.onclick = function () {
  let str = "";
  str += inputField.value;
  inputField.value = str.substring(0, str.length - 1);
};
