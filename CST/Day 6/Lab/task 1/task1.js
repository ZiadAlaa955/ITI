let win;
let timerID;
const width = 800;
const height = 250;
let charNumber;
let letters =
  "This message will appear character by character \nWindow will be colsed after few sceonds...".split(
    ""
  );

let clickElement = document.getElementById("openWindow");

clickElement.onclick = function () {
  win = open("messageChild.html", "", "Width=" + width + ",height=" + height);

  charNumber = 0;
  timerID = setInterval(function () {
    win.resizeTo(width, height);
    win.focus();

    let childElement = win.document.getElementById("message");

    if (charNumber < letters.length) {
      if (letters[charNumber] == "\n") {
        childElement.innerHTML += "<br/>";
        charNumber++;
      } else {
        childElement.innerHTML += letters[charNumber++];
      }
    } else {
      clearInterval(timerID);
      win.close();
    }
  }, 100);
};
