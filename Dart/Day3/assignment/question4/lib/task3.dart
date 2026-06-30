mixin Logging {
  void log() {
    print("logging");
  }
}

abstract class AuthService {}

mixin AdvancedMixin on AuthService {
  void advancedMethod() {
    print("from advanced mixin");
  }
}
