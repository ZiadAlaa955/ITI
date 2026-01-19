let imageElement = document.getElementById("header");

imageElement.addEventListener("click", function () {
  imageElement.style.textAlign = "right";

  let imageElement2 = imageElement.cloneNode(true);
  imageElement2.style.textAlign = "left";
  document.body.appendChild(imageElement2);

  //   let listDiv = document.getElementById("navigation");
  //   listDiv;

  let listElement = document.getElementById("nav");
  listElement.style.listStyleType = "circle";
});
