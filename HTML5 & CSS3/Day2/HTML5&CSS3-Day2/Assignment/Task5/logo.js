var c = document.getElementById("myCanvas");
var ctx = c.getContext("2d");

var centerX = 200;
var centerY = 200;
var radius = 150;

var grad1 = ctx.createRadialGradient(
  centerX - 50,
  centerY - 50,
  30,
  centerX,
  centerY,
  radius,
);
grad1.addColorStop(0, "#5b9aff");
grad1.addColorStop(0.9, "#0033cc");
grad1.addColorStop(1, "#002080");

ctx.beginPath();
ctx.arc(centerX, centerY, radius, 0, 2 * Math.PI);
ctx.fillStyle = grad1;
ctx.fill();
ctx.closePath();

ctx.beginPath();
ctx.arc(centerX, centerY, radius * 0.7, 0, 2 * Math.PI);
ctx.fillStyle = "#3366cc";
ctx.fill();
ctx.closePath();

ctx.font = "200px Arial";
ctx.fillStyle = "white";
ctx.textAlign = "center";
ctx.textBaseline = "middle";

ctx.fillText("N", centerX, centerY + 10);
