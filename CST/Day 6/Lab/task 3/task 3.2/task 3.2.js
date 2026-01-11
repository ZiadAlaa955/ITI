let allMarbels = document.getElementsByClassName("marbels");

let marbelNumber = 0;

let timerID;

function loading() {
  if (!timerID) {
    timerID = setInterval(function () {
      if (marbelNumber <= allMarbels.length - 1) {
        if (marbelNumber == 0) {
          allMarbels[allMarbels.length - 1].src = "marbels/marble1.jpg";
          allMarbels[marbelNumber].src = "marbels/marble3.jpg";
          marbelNumber++;
        } else {
          allMarbels[marbelNumber - 1].src = "marbels/marble1.jpg";
          allMarbels[marbelNumber].src = "marbels/marble3.jpg";
          if (marbelNumber != allMarbels.length - 1) {
            marbelNumber++;
          } else {
            marbelNumber = 0;
          }
        }
      }
      console.log(marbelNumber);
    }, 600);
  }
}

for (let i = 0; i < allMarbels.length; i++) {
  allMarbels[i].onmouseenter = function freez() {
    clearInterval(timerID);
    timerID = false;
  };

  allMarbels[i].onmouseleave = function resume() {
    loading();
  };
}

loading();
