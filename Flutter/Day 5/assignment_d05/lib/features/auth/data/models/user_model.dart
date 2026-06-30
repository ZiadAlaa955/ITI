class UserModel {
  final String id;
  final String username;
  final String email;

  const UserModel({
    required this.username,
    required this.email,
    required this.id,
  });

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'username': username,
      "email": email,
    };
  }

  factory UserModel.fromMap(Map<String, dynamic> map) {
    return UserModel(
      username: map['username'],
      email: map['email'],
      id: map['id'],
    );
  }
}
