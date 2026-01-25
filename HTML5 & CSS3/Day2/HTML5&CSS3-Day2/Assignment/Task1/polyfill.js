if (!window.localStorage) {
  window.localStorage = {
    setItem: function (key, value) {
      let myDate = new Date();
      myDate.setFullYear(myDate.getFullYear() + 1);

      setCookie(key, value, myDate.toUTCString());
    },

    getItem: function (key) {
      return getCookie(key);
    },

    removeItem: function (key) {
      deleteCookie(key);
    },

    clear: function () {
      let allCookies = allCookieList();

      for (let i = 0; i < allCookies.length; i++) {
        let cookieParts = allCookies[i].split("=");
        let key = cookieParts[0].trim();

        deleteCookie(key);
      }
    },
  };
}
//------------------------------------------------------------------------
function getColor() {
  let userColor = document.getElementById("Colors");
  return userColor.value;
}
//------------------------------------------------------------------------
function getGender() {
  let userGender = document.getElementsByName("gender");
  for (let i = 0; i < userGender.length; i++) {
    if (userGender[i].checked) {
      return userGender[i].value;
    }
  }
}
//------------------------------------------------------------------------
function setCookie(cookieName, cookValue, expireDate) {
  try {
    if (arguments.length == 0) {
      throw "No arguments added";
    } else if (typeof cookieName != "string" || cookieName == undefined) {
      throw "Wrong cookieName type";
    } else if (cookValue == undefined) {
      throw "empty cookie value";
    } else {
      if (expireDate) {
        document.cookie =
          cookieName + "=" + cookValue + ";expires=" + expireDate;
      } else {
        document.cookie = cookieName + "=" + cookValue;
      }
    }
  } catch (err) {
    console.log(err);
  }
}
//------------------------------------------------------------------------
function getCookie(cookieName) {
  try {
    if (arguments.length == 0) {
      throw "there are no arguments...";
    } else if (typeof cookieName != "string") {
      throw "Invalid argument type...";
    } else {
      let newCookie = document.cookie;
      let cookiesList = newCookie.split(";");

      for (let i = 0; i < cookiesList.length; i++) {
        let cookieParts = cookiesList[i].split("=");
        if (cookieParts[0].trim() == cookieName) {
          return cookieParts[1];
        }
      }
      return "wrong cookie name..";
    }
  } catch (err) {
    console.log(err);
  }
}
//------------------------------------------------------------------------
function deleteCookie(cookieName) {
  try {
    if (typeof cookieName != "string" || cookieName == undefined) {
      throw "wrong cookieName";
    } else {
      let newDate = new Date();
      newDate.setTime(newDate.getTime() - 86400000);

      document.cookie = cookieName + "=;expires=" + newDate.toUTCString();
    }
  } catch (err) {
    console.log(err);
  }
}
//------------------------------------------------------------------------
function allCookieList() {
  let cookiesList = document.cookie.split(";");
  let myList = [];
  for (let i = 0; i < cookiesList.length; i++) {
    let cookieParts = cookiesList[i].trim();
    myList.push(cookieParts);
  }
  return myList;
}
//------------------------------------------------------------------------
function hasCookie(cookieName) {
  try {
    if (cookieName == undefined) {
      throw "wrong cookieName";
    } else {
      let newCookie = document.cookie;
      let cookiesList = newCookie.split(";");
      for (let i = 0; i < cookiesList.length; i++) {
        let cookieParts = cookiesList[i].split("=");
        if (cookieParts[0].trim() == cookieName) {
          return true;
        }
      }
      return false;
    }
  } catch (err) {
    console.log(err);
    return false;
  }
}
//------------------------------------------------------------------------
let submitButton = document.getElementById("submitButton");
if (submitButton) {
  submitButton.onclick = function () {
    let userName = document.getElementById("inputName").value;
    let userAge = document.getElementById("inputAge").value;
    let gender = getGender();
    let color = getColor();

    localStorage.setItem("name", userName);
    localStorage.setItem("age", userAge);
    localStorage.setItem("gender", gender);
    localStorage.setItem("color", color);

    if (!localStorage.getItem("visits")) {
      localStorage.setItem("visits", "0");
    }

    location.assign("welcome.html");
  };
}
//------------------------------------------------------------------------
let genderImage = document.getElementById("genderImage");
if (genderImage) {
  function welcome() {
    let welcomeName = document.getElementById("welcomeName");
    let welcomeVisits = document.getElementById("welcomeVisits");

    let username = localStorage.getItem("name");
    let gender = localStorage.getItem("gender");
    let color = localStorage.getItem("color");
    let visits = parseInt(localStorage.getItem("visits"));

    if (isNaN(visits)) visits = 0;
    visits++;

    localStorage.setItem("visits", visits);

    if (gender == "male") genderImage.src = "cookies/1.jpg";
    else genderImage.src = "cookies/2.jpg";

    welcomeName.innerHTML = username;
    welcomeName.style.color = color;
    welcomeVisits.innerHTML = visits;
    welcomeVisits.style.color = color;
  }
  welcome();
}
