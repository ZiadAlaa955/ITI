import 'package:assignment_d05/features/auth/presentation/pages/signup_page.dart';
import 'package:flutter/material.dart';

class SignupClickableMessage extends StatelessWidget {
  const SignupClickableMessage({super.key});

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        Navigator.pushReplacement(
          context,
          MaterialPageRoute(
            builder: (context) => const SignupPage(),
          ),
        );
      },
      child:  const Row(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Icon(
            Icons.person_add_alt_1,
            color: Color(0xff324655),
          ),
          SizedBox(width: 8),
           Text(
            "Create New account",
            style: TextStyle(
              fontSize: 16,
              fontWeight: FontWeight.bold,
              color: Color(0xff334655),
            ),
          ),
        ],
      ),
    );
  }
}
