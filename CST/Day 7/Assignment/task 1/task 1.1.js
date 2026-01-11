// window.oncontextmenu = function () {
//   event.preventDefault();
//   this.alert("right click is disabled");
// };

window.addEventListener("contextmenu", function () {
  event.preventDefault();
  this.alert("right click is disabled");
});
