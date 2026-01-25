let line = document.getElementById("lineId");

function Animate() {
  let timeId = setInterval(function () {
    let currentX = parseInt(line.getAttribute("x2"));
    let currentY = parseInt(line.getAttribute("y2"));

    if (currentX >= 500) {
      clearInterval(timeId);
      alert("Animation End...");
    }

    line.setAttribute("x2", currentX + 10);
    line.setAttribute("y2", currentY + 10);
  }, 50);
}

Animate();
