let win;
let timerID;
let parentheight = window.screen.availHeight;
const width = 250;
const height = 250;

function startTiming() {
  let flag = true;

  win = window.open(
    "moveChild.html",
    "",
    "Width=" + width + ",height=" + height
  );

  timerID = setInterval(function () {
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
  }, 50);
}

function stopTiming() {
  clearInterval(timerID);
}

startTiming();
