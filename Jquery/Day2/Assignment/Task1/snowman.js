$(document).ready(function () {
  $("body").css({
    "margin-top": "30px",
    "text-align": "center",
    "font-family": "cursive",
  });

  //Menu Buttons//////////////////////////////
  $(".spanButton").css({
    color: "white",
    "font-size": "30px",
    "background-color": "rgb(245, 131, 174)",
    padding: "10px 15px",
    "text-align": "center",
    width: "100px",
    "border-radius": "5px",
    "box-shadow": "3px 5px 10px gray",
    cursor: "pointer",
  });

  let buttonName = ["About", "Galary", "Services", "Complain"];
  $(".spanButton").each(function (idx) {
    $(this).text(buttonName[idx]);
  });

  //About Button//////////////////////////////
  let AboutBox = $("<div>");
  AboutBox.text("A story about snow man...");
  AboutBox.css({
    border: "solid 5px gray",
    width: "300px",
    height: "150px",
    margin: "auto",
    "margin-top": "100px",
    "box-shadow": "0px 5px 10px gray",
    "text-align": "center",
    "line-height": "150px",
    display: "none",
  });
  $("body").append(AboutBox);
  $(".spanButton")
    .eq(0)
    .on("click", function () {
      AboutBox.slideToggle();
    });

  //Galary Button////////////////////////////
  //1-galaryBox
  let galaryBox = $("<div>");
  galaryBox.css({
    border: "solid 5px gray",
    width: "300px",
    height: "150px",
    margin: "auto",
    "margin-top": "100px",
    "box-shadow": "0px 5px 10px gray",
    "text-align": "center",
    "line-height": "150px",
    position: "relative",
    display: "none",
  });
  $("body").append(galaryBox);

  //2-Arrows
  let rightArrow = createArrow("images/right.png", "300px");
  let leftArrow = createArrow("images/left.png", "-50px");
  function createArrow(iconPath, verticalPosition) {
    let arrow = $("<img>");
    arrow.attr("src", iconPath);
    arrow.css({
      width: "50px",
      position: "absolute",
      top: "50px",
      left: verticalPosition,
      cursor: "pointer",
    });
    $(galaryBox).append(arrow);
    return arrow;
  }

  //3-Images
  let imageIndex = 1;
  let image = $("<img>");
  image.attr("src", "images/" + imageIndex + ".jpg");
  image.css({
    width: "290px",
    height: "140px",
    position: "absolute",
    left: "5px",
    top: "5px",
  });
  $(galaryBox).append(image);

  //4-Arrow click
  rightArrow.on("click", function () {
    imageIndex++;
    if (imageIndex > 8) imageIndex = 1;
    image.attr("src", "images/" + imageIndex + ".jpg");
  });

  leftArrow.on("click", function () {
    imageIndex--;
    if (imageIndex < 1) imageIndex = 8;
    image.attr("src", "images/" + imageIndex + ".jpg");
  });

  $(".spanButton")
    .eq(1)
    .on("click", function () {
      galaryBox.slideToggle();
    });

  //5-Services button//////////////////////////////////
  for (let i = 0; i < 3; i++) {
    let menuBox = $("<div>");
    menuBox.text("Item#" + (i + 1));
    let currentTop = 85 + i * 35;

    menuBox.css({
      "border-radius": "5px",
      padding: "10px 15px",
      "text-align": "center",
      color: "white",
      "background-color": "rgb(245, 131, 174)",
      width: "100px",
      "box-shadow": "3px 3px 5px gray",
      position: "absolute",
      left: "750px",
      top: currentTop + "px",
      display: "none",
    });

    menuBox.addClass("serviceMenu");

    $("body").append(menuBox);
  }
  $(".spanButton")
    .eq(2)
    .on("click", function () {
      $(".serviceMenu").slideToggle();
    });

  //complain button///////////////////////
  let formBox = $("<div>");
  formBox.css({
    border: "solid 5px gray",
    width: "400px",
    height: "280px",
    margin: "auto",
    "margin-top": "100px",
    "box-shadow": "0px 5px 10px gray",
    "text-align": "center",
    "line-height": "150px",
    position: "relative",
    display: "none",
  });

  let nameField = $("<input>").attr("type", "text").attr("id", "nameId").css({
    position: "absolute",
    top: "30px",
    left: "150px",
  });

  let nameLabel = $("<label>").text("Name:").attr("for", "nameId").css({
    position: "absolute",
    top: "30px",
    left: "100px",
    color: "black",
    "line-height": "normal",
  });

  let emailField = $("<input>").attr("type", "email").attr("id", "mailId").css({
    position: "absolute",
    top: "70px",
    left: "150px",
  });

  let emailLabel = $("<label>").text("Email:").attr("for", "mailId").css({
    position: "absolute",
    top: "70px",
    left: "100px",
    color: "black",
    "line-height": "normal",
  });

  let phoneField = $("<input>")
    .attr("type", "number")
    .attr("id", "numlId")
    .css({
      position: "absolute",
      top: "110px",
      left: "150px",
    });

  let phoneLabel = $("<label>").text("Phone:").attr("for", "numId").css({
    position: "absolute",
    top: "110px",
    left: "100px",
    color: "black",
    "line-height": "normal",
  });

  let complain = $("<span>").text("Complain:").css({
    position: "absolute",
    top: "140px",
    left: "160px",
    color: "black",
    "line-height": "normal",
  });

  let complainTextarea = $("<textarea>")
    .attr("cols", "25")
    .attr("rows", "5")
    .css({
      position: "absolute",
      top: "165px",
      left: "100px",
      color: "black",
    });

  let sendButton = $("<input>")
    .attr("type", "button")
    .attr("value", "Send")
    .css({
      position: "absolute",
      top: "255px",
      left: "170px",
      color: "black",
    });

  formBox.append(
    nameField,
    nameLabel,
    emailField,
    emailLabel,
    phoneField,
    phoneLabel,
    complain,
    complainTextarea,
    sendButton,
  );
  $("body").append(formBox);
  /////////////////////////////
  let summaryBox = $("<div>").css({
    border: "solid 5px gray",
    width: "400px",
    height: "280px",
    margin: "auto",
    "margin-top": "100px",
    "box-shadow": "0px 5px 10px gray",
    "text-align": "center",
    "line-height": "150px",
    position: "relative",
    display: "none",
  });
  let comp = $("<span>").css({
    position: "absolute",
    top: "-30px",
    left: "100px",
  });

  let name = $("<span>").css({
    position: "absolute",
    top: "10px",
    left: "100px",
  });

  let email = $("<span>").css({
    position: "absolute",
    top: "50px",
    left: "100px",
  });

  let phone = $("<span>").css({
    position: "absolute",
    top: "90px",
    left: "100px",
  });

  let backButton = $("<input>")
    .attr("type", "button")
    .attr("value", "Back to edit")
    .css({
      position: "absolute",
      top: "220px",
      left: "150px",
    });

  summaryBox.append(comp, name, email, phone, backButton);
  $("body").append(summaryBox);

  $(".spanButton")
    .eq(3)
    .on("click", function () {
      summaryBox.hide();
      formBox.slideToggle();
    });

  $(sendButton).on("click", function () {
    comp.html("Your complain is <b>" + complainTextarea.val() + "</b>");
    name.html("Your name is <b>" + nameField.val() + "</b>");
    email.html("Your email is <b>" + emailField.val() + "</b>");
    phone.html("Your phone is <b>" + phoneField.val() + "</b>");

    formBox.hide();
    summaryBox.show();
  });

  backButton.on("click", function () {
    summaryBox.hide();
    formBox.show();
  });
});
