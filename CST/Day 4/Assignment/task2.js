var b = true;
while (b) {
  var s = prompt("Enter a string:");
  if (!isNaN(s)) {
    alert("Enter a valid string");
    continue;
  }

  var isSenstive = confirm("Do you want to consider case senstivity?");
  if (isSenstive == true) {
    var s2 = "";
    //reverse
    for (var i = s.length - 1; i >= 0; i--) {
      s2 += s.charAt(i);
    }
    var isPlaindrome = true;
    for (var i = 0; i < s.length; i++) {
      if (!(s.charAt(i) == s2.charAt(i))) {
        isPlaindrome = false;
        break;
      }
    }
  } else if (isSenstive == false) {
    s = s.toUpperCase();
    var s2 = "";
    //reverse
    for (var i = s.length - 1; i >= 0; i--) {
      s2 += s.charAt(i);
    }

    var isPlaindrome = true;
    for (var i = 0; i < s.length; i++) {
      if (s.charAt(i) != s2.charAt(i)) {
        isPlaindrome = false;
        break;
      }
    }
  } else {
    alert("Just enter Yes or No !");
    continue;
  }

  if (isPlaindrome == true) console.log("is plaindrome");
  else console.log("is not plaindrome");

  b = false;
}
