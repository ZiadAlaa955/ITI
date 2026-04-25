let win;
let timerID;
let parentheight = window.screen.availHeight;
const width = 250;
const height = 250;
let button = document.getElementById("btn");
let flag = true;

function startTiming() {
  win = window.open(
    "moveChild.html",
    "",
    "Width=" + width + ",height=" + height
  );
  moveChild();
}

function moveChild() {
  timerID = setTimeout(function () {
    if (flag == true) {
      win.moveBy(10, 10);
      win.resizeTo(width, height);
      win.focus();
      if (win.screenX + height >= parentheight) flag = false;
    } else {
      win.resizeTo(width, height);
      win.moveBy(-10, -10);
      win.focus();
      if (win.screenX == screenTop) flag = true;
    }
    moveChild();
  }, 50);
}

function stopTiming() {
  clearTimeout(timerID);
}

startTiming();
