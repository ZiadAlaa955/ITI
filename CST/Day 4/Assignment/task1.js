var b = true;
while (b) {
  var s = prompt("Enter a string");
  if (!isNaN(s)) {
    alert("Enter a valid string");
    continue;
  }

  var chr = prompt("Enter only one character to search");
  if (chr.length != 1) {
    alert("Enter only one character!");
    continue;
  }

  var num = 0;
  var isSenstive = prompt("Do you want to consider case senstivity?"); //Yes , No

  if (isSenstive.toUpperCase() == "YES") {
    for (var i = 0; i < s.length; i++) {
      if (s.charAt(i) == chr) num++;
    }
  } else if (isSenstive.toUpperCase() == "NO") {
    s.toUpperCase();
    chr.toUpperCase();
    for (var i = 0; i < s.length; i++) {
      if (s.charAt(i) == chr) num++;
    }
  } else {
    alert("Just enter Yes or No !");
    continue;
  }

  console.log('count of "' + chr + '" is: ' + num);
  b = false;
}
