//keyPress: fires only with character key (a,b,5,8) NOT control key (alt, ctrl, shift)
//keydown: can be used with control keys

let input = document.getElementById("txt");
let ctrl = null;
input.addEventListener("keydown", function (event) {
  console.log("You pressed: " + event.key);
  if (event.key == "Control") {
    ctrl = "Control";
    console.log(ctrl);
  }
  if (event.key == "a" && ctrl == "Control") {
    event.preventDefault();
    console.log("ctrl+a is disabled");
  }
});

let input2 = document.getElementById("txt2");
input2.addEventListener("keypress", function (event) {
  console.log("You pressed: " + event.key);
});
