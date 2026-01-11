function add(n1, n2) {
  try {
    if (typeof n1 != "number" || typeof n2 != "number") {
      throw "Enter only numbers";
    } else if (arguments.length == 0) {
      throw "Enter numbers to add ";
    } else {
      let add = n1 + n2;
      console.log("add = " + add);
    }
  } catch (err) {
    console.log(err);
  }
}

add(5, 5);
add();
add("", 5);
