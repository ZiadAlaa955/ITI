let nextElement = document.getElementById("nextButton");
let preElement = document.getElementById("prevButton");
let slideElement = document.getElementById("slideButton");
let stopElement = document.getElementById("stopButton");
let imageElement = document.getElementById("images");

//              0          1        2       3        4        5
imageNames = ["1.jpg", "2.jpg", "3.jpg", "4.jpg", "5.jpg", "6.jpg"];

let imagesCounter = 0;
imageElement.src = "Images/" + imageNames[imagesCounter];

//Next
let nextfun = function () {
  if (imagesCounter < imageNames.length - 1)
    imageElement.src = "Images/" + imageNames[++imagesCounter];
};
nextElement.onclick = nextfun;

// //Previous
let prevfun = function () {
  if (imagesCounter > 0)
    imageElement.src = "Images/" + imageNames[--imagesCounter];
};
preElement.onclick = prevfun;

//SlideShow
let timerID;
slideElement.onclick = function () {
  if (!timerID) {
    timerID = setInterval(function () {
      if (imagesCounter == imageNames.length - 1) {
        imagesCounter = 0;
        imageElement.src = "Images/" + imageNames[imagesCounter];
      } else {
        nextfun();
      }
    }, 1000);
  }
};

//Stop slideSow
stopElement.onclick = function () {
  clearInterval(timerID);
  timerID = undefined;
};
