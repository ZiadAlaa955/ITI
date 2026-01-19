//Box
let boxElement = document.getElementById("d");
boxElement.style.border = "solid";
boxElement.style.borderColor = "red";
boxElement.style.borderWidth = "2px";
boxElement.style.width = "400px";
boxElement.style.height = "400px";
boxElement.style.position = "relative";

//computerd style for box
var boxTop = parseInt(getComputedStyle(boxElement).top);
var boxLeft = parseInt(getComputedStyle(boxElement).left);
var boxRight = parseInt(getComputedStyle(boxElement).right);
var boxBottom = parseInt(getComputedStyle(boxElement).bottom);

//Image1
let image1 = document.getElementById("image1");
image1.style.position = "absolute";
let left1 = boxLeft + 10;
let top1 = boxTop + 150;
let end1 = boxLeft + 360;
image1.style.top = top1 + "px";
image1.style.left = left1 + "px";

//Image2
let image2 = document.getElementById("image2");
image2.style.position = "absolute";
let topImage2 = boxTop + 150;
image2.style.top = topImage2 + "px";
let startImage2 = boxLeft + 360;
image2.style.left = startImage2 + "px";
let endImage2 = boxLeft + 10;

//Image3
let Image3 = document.getElementById("image3");
image3.style.position = "absolute";
let endImage3 = boxTop + 10;
let startImage3 = boxTop + 380;
image3.style.top = startImage3 + "px";
let centerImage3 = boxLeft + 190;
image3.style.left = centerImage3 + "px";

let yellowImageTimer, pinkImageTimer, blueImageTimer;

//go
let goButton = document.getElementById("goBtn");
goButton.addEventListener("click", function () {
  moveYellowImage();
  movePinkImage();
  moveBlueImage();
});

//stop
let stopButton = document.getElementById("stopBtn");
stopButton.addEventListener("click", function () {
  clearInterval(yellowImageTimer);
  clearInterval(blueImageTimer);
  clearInterval(pinkImageTimer);
});

//reset
let resetButton = document.getElementById("resetBtn");
resetButton.addEventListener("click", function () {
  image1.style.left = left1 + "px";
  image2.style.left = startImage2 + "px";
  image3.style.top = startImage3 + "px";
});

//move functions
function moveYellowImage() {
  let image1Start = left1;
  let flag = false;
  yellowImageTimer = setInterval(function () {
    if (flag == true) {
      image1Start -= 10;
      image1.style.left = image1Start + "px";
      if (image1Start <= 0) {
        flag = false;
      }
    }
    if (flag == false) {
      image1Start += 10;
      image1.style.left = image1Start + "px";
      if (image1Start >= end1) flag = true;
    }
  }, 100);
}

function movePinkImage() {
  let image2Start = startImage2;
  let flag = false;
  pinkImageTimer = setInterval(function () {
    if (flag == true) {
      image2Start += 10;
      image2.style.left = image2Start + "px";
      if (image2Start >= startImage2) {
        flag = false;
      }
    }
    if (flag == false) {
      image2Start -= 10;
      image2.style.left = image2Start + "px";
      if (image2Start <= endImage2) {
        flag = true;
      }
    }
  }, 100);
}

function moveBlueImage() {
  let image3Start = startImage3;
  let flag = false;
  blueImageTimer = setInterval(function () {
    if (flag == true) {
      image3Start += 10;
      image3.style.top = image3Start + "px";
      if (image3Start >= startImage3) {
        flag = false;
      }
    }
    if (flag == false) {
      image3Start -= 10;
      image3.style.top = image3Start + "px";
      if (image3Start <= endImage3) {
        flag = true;
      }
    }
  }, 100);
}
