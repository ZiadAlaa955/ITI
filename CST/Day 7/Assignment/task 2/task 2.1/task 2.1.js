let myform = document.forms[0];
myform.onsubmit = function () {
  let confirmation = confirm("Are you sure you need to submit?");
  if (confirmation == false) {
    myform.action = "javascript:void(0)";
  } else {
    myform.action = "welcome.html";
  }
};
