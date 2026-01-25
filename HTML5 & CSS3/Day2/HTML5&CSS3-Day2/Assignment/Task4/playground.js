var canvas = document.getElementById("myCanvas");
var ctx = canvas.getContext("2d");

var skyGrad = ctx.createLinearGradient(0, 0, 0, 150);
skyGrad.addColorStop(0, "#00BFFF");
skyGrad.addColorStop(1, "white");

ctx.fillStyle = skyGrad;
ctx.fillRect(0, 0, 400, 150);

var grassGrad = ctx.createLinearGradient(0, 150, 0, 300);
grassGrad.addColorStop(0, "#32CD32");
grassGrad.addColorStop(1, "white");

ctx.fillStyle = grassGrad;
ctx.fillRect(0, 150, 400, 150);

ctx.beginPath();
ctx.lineWidth = 5;
ctx.strokeStyle = "black";

ctx.moveTo(120, 220);
ctx.lineTo(120, 100);
ctx.lineTo(280, 100);
ctx.lineTo(280, 220);

ctx.stroke();
