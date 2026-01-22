let redColor = document.getElementById("redRange");
let greenColor = document.getElementById("greenRange");
let blueColor = document.getElementById("blueRange");
let text = document.getElementById("textId");

let redVal = redColor.value;
let greenVal = greenColor.value;
let blueVal = blueColor.value;

function updateColor() {
  text.style.color = "rgb(" + redVal + "," + greenVal + "," + blueVal + ")";
}

redColor.addEventListener("input", (event) => {
  redVal = event.target.value;
  updateColor();
});

greenColor.addEventListener("input", (event) => {
  greenVal = event.target.value;
  updateColor();
});

blueColor.addEventListener("input", (event) => {
  blueVal = event.target.value;
  updateColor();
});
