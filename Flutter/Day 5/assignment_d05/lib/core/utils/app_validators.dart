import 'package:flutter/material.dart';

class AppValidators {
  static String? emailValidator(String? value) {
    final email = value?.trim() ?? "";
    if (email.isEmpty) {
      return "Email is required";
    }
    final hasAtSymbol = email.contains("@");
    final hasDot = email.contains(".");
    if (!hasAtSymbol || !hasDot) {
      return "Enter a valid email";
    }
    return null;
  }

  static String? passwordValidator(String? value) {
    final password = value ?? "";
    if (password.isEmpty) {
      return "Password is required";
    }
    if (password.length < 8) {
      return "Password must be at least 8 characters";
    }
    final RegExp passwordRegex = RegExp(
      r'^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^a-zA-Z0-9]).+$',
    );
    if (!passwordRegex.hasMatch(password)) {
      return "Password must include an uppercase letter, a number, and a special character";
    }
    return null;
  }

  static String? confirmPasswordValidator(
    String? value,
    TextEditingController passwordController,
  ) {
    final confirmPassword = value ?? "";
    if (confirmPassword.isEmpty) {
      return "Please confirm your password";
    }
    if (confirmPassword != passwordController.text) {
      return "Passowrds do not match";
    }
    return null;
  }

  static String? nameValidator(String? value) {
    if (value == null || value.trim().isEmpty) {
      return 'Required, please enter a name.';
    }
    if (value.trim().length < 3) {
      return 'Required, minimum 3 characters.';
    }
    return null;
  }

  static String? imageValidator(String? value) {
    if (value == null || value.trim().isEmpty) {
      return 'Required, please enter an image URL.';
    }
    if (!value.trim().startsWith('http')) {
      return 'Please enter a valid URL starting with http/https.';
    }
    return null;
  }

  static String? hoursValidator(String? value) {
    if (value == null || value.trim().isEmpty) {
      return 'Required, please enter weekly hours.';
    }
    final int? hours = int.tryParse(value.trim());

    if (hours == null) {
      return 'Must be a valid integer.';
    }
    if (hours <= 0 || hours > 80) {
      return 'Required, must be a valid integer within logical range.';
    }
    return null;
  }

  static String? salaryValidator(String? value) {
    if (value == null || value.trim().isEmpty) {
      return 'Please enter salary.';
    }
    final double? salary = double.tryParse(value.trim());

    if (salary == null) {
      return 'Must be a valid number.';
    }
    if (salary <= 0) {
      return 'Must be greater than zero';
    }
    return null;
  }
}
