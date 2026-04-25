let h3 = document.getElementById("message");

function _5seconds() {
  let curretnSecond = new Date().getTime();
  let after5Sec = curretnSecond + 5000;

  console.log("Start");
  while (new Date().getTime() < after5Sec) {}
  console.log("End");
  h3.innerHTML = "message after 5 seconds";
}

_5seconds();
