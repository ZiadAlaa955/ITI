void configureAlert({String level = "INFO", required String message}) {
  print("level:$level, message:$message");
}

void task1() {
  configureAlert(message: "messsageeeeeeeee");
  configureAlert(level: "Levelllllll", message: "messsageeeeeeeee222");
}
