var b = true;
while (b) {
  var userName = prompt("Enter your name: ");
  if (!isNaN(userName)) {
    alert("Enter only characters...");
    continue;
  }

  var phoneNumber = prompt("Enter your phone number (length = 8): ");
  if (phoneNumber.length != 8) {
    alert("Enter only 8 numbers...");
    continue;
  }

  var mobileNumber = prompt(
    "Enter your mobile number (11 numbers, starts with 010/011/012)"
  );
  var mobileRegExp = /^(010|011|012)[0-9]{8}$/;
  if (mobileRegExp.test(mobileNumber) == false) {
    alert("Enter a vaild number...");
    continue;
  }

  var email = prompt("Enter your email (abc@123.com)");
  var emailRegExp = /[a-zA-Z-0-9]+@[a-zA-Z]+\.[a-zA-Z]{2,3}/;
  if (emailRegExp.test(email) == false) {
    alert("Enter a vaild number...");
    continue;
  }

  var color = prompt("Enter one of these colors (red, blue, grees): ");
  color = color.toLowerCase();
  if (color != "red" && color != "blue" && color != "green") {
    alert("Enter a color from choices...");
    continue;
  }

  console.log("Welcome %c" + userName + " !", "color:" + color);
  console.log("Email: %c" + email, "color:" + color);
  console.log("phone number: %c" + phoneNumber, "color:" + color);
  console.log("mobile number: %c" + mobileNumber, "color:" + color);
  b = false;
}
