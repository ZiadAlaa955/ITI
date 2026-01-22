$("body").css({
  position: "relative",
});

let car = $("<img>");
car.attr("src", "car.gif");
car.css({
  position: "absolute",
  left: "0px",
  top: "40px",
});

$("body").append(car);
///////////////////////////
let speed = $("<div>Left: 0px</div>").css({
  "font-weight": "600",
  "font-size": "50px",
  position: "absolute",
  top: "100px",
});

$("body").append(speed);

car.animate(
  { left: "1300px" },
  {
    duration: 5000,
    easing: "swing",
    step: function (currentStep) {
      speed.text("Left: " + Math.floor(currentStep) + "px");
    },
  },
);
