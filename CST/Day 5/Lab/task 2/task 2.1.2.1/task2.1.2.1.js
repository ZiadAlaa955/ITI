let win;
let timerID;
const width = 500;
const height = 250;

function scrollablewindow() {
  win = window.open(
    "scrollableChild.html",
    "",
    "Width=" + width + ",height=" + height
  );

  timerID = setInterval(function () {
    win.window.scrollBy(0, 1);
  }, 20);
}
