let userData = document.location.search;
let userDataElement = document.getElementById("userData");
let recommendationElement = document.getElementById("recommendMessage");

userData = userData.substring(1).split("&");

let userObj = {};

for (let i = 0; i < userData.length; i++) {
  userObj[userData[i].split("=")[0]] = userData[i].split("=")[1];
}

for (let i in userObj) {
  userObj[i] = userObj[i].replace(/\%40/g, "@");
  userDataElement.innerHTML += i + ": " + userObj[i] + "</br>";
}
// console.log(navigator.userAgent);
if (navigator.userAgent.indexOf("Chrome") == -1) {
  recommendationElement.innerHTML = "It's better to use Chrome ;)";
}
