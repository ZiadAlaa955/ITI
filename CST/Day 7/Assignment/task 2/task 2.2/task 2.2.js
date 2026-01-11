//create custom event
let cusEvent = new Event("wait");

let myForm = document.forms[0];
let div = document.getElementById("divID");

//typing listener
let type = false;
myForm.addEventListener("input", function () {
  type = true;
});

//firing event
setTimeout(function () {
  if (type == false) {
    alert("You did not type anything!");
  } else {
    myForm.dispatchEvent(cusEvent);
  }
}, 10000);
