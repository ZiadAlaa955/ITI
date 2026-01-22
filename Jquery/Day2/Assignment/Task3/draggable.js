let blackHole = $("<img>");
blackHole.attr("src", "images/31.jpg");
blackHole.css({
  position: "absolute",
  top: "100px",
  left: "50px",
  width: "400px",
  height: "400px",
});
$("body").append(blackHole);

let dragBox = $("<div>");
dragBox.css({
  width: "100px",
  height: "120px",
  "background-color": "yellow",
  border: "1px solid gray",
  "text-align": "center",
  padding: "5px",
  position: "absolute",
  top: "200px",
  left: "500px",
  cursor: "move",
});

let bunnyImage = $("<img>");
bunnyImage.attr("src", "images/21.jpg");
bunnyImage.css({ width: "80px", height: "80px" });

dragBox.append(bunnyImage);
dragBox.append("<div>Drag Me</div>");

$("body").append(dragBox);

dragBox.draggable({
  revert: "invalid",
  containment: "document",
});

blackHole.droppable({
  accept: dragBox,

  drop: function (event, ui) {
    ui.draggable.hide("scale", { percent: 0 }, 800);
  },
});
