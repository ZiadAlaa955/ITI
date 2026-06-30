import 'package:flutter/material.dart';

class SignupTitle extends StatelessWidget {
  const SignupTitle({super.key});

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Center(
          child: Text(
            textAlign: TextAlign.center,
            "Task Analytics\nWorkspace",
            style: TextStyle(
              fontWeight: FontWeight.bold,
              fontSize: 28,
            ),
          ),
        ),
        SizedBox(height: 8),
        Center(
          child: Text(
            "OPERATOR REGISTRATION",
            style: TextStyle(
              fontWeight: FontWeight.w600,
              fontSize: 12,
              color: Colors.grey[600],
              letterSpacing: 1.5,
            ),
          ),
        ),
      ],
    );
  }
}
