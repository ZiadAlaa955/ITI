abstract class NotificationChannel {
  void method();
}

class PushNotificationChannel extends NotificationChannel {
  @override
  void method() {
    print("pushing notification");
  }
}

class Independent {
  void independentMethod() {}
}

class PureInterface implements Independent {
  @override
  void independentMethod() {
    print("from pure interface");
  }
}
