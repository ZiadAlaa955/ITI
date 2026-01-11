//Task 1
var message = prompt("Please enter your message:", "Default mesasge");

for (var i = 0; i < 6; i++) {
  document.writeln(
    "<h" + (i + 1) + ">" + message + " " + (i + 1) + "</h" + (i + 1) + ">"
  );
}
