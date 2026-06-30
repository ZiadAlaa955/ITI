extension VerifyStringLength on String {
  bool get isValidName {
    return trim().length >= 3;
  }
}

class CustomData {
  final String id;

  CustomData(this.id);

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) {
      return other is CustomData && other.id == id;
    } else {
      return false;
    }
  }

  @override
  int get hashCode => id.hashCode;
}
