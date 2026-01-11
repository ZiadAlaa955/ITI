let win;
let timerID;
const width = 500;
const height = 250;

function openWindow() {
  win = window.open(
    "scrollableChild.html",
    "",
    "Width=" + width + ",height=" + height
  );
  scrollablewindow();
}

function scrollablewindow() {
  timerID = setTimeout(function () {
    win.scrollBy(0, 1);
    scrollablewindow();
  }, 20);
}
