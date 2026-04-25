let images = document.getElementsByTagName("img");
let h1 = document.getElementById("h1");
let image1, image2;
let flag = false;
let CompleteCounter = 0;

for (let i = 0; i < images.length; i++) {
  images[i].onclick = function flip() {
    if (flag == false) {
      images[i].src = "memory Game/" + images[i].className + ".gif";
      image1 = images[i];
      flag = true;
    } else {
      images[i].src = "memory Game/" + images[i].className + ".gif";
      image2 = images[i];

      if (image1.className != image2.className) {
        setTimeout(function () {
          image1.src = "memory Game/Moon.gif";
          image2.src = "memory Game/Moon.gif";
          flag = false;
          image1 = image2 = null;
        }, 800);
      } else {
        flag = false;
        image1 = image2 = null;
        CompleteCounter++;
      }
      if (CompleteCounter == 6) {
        setTimeout(function () {
          h1.innerHTML = "Congratulations!";
        }, 800);
      }
    }
  };
}
