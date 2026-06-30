import 'package:flutter/material.dart';

class CommitButton extends StatelessWidget {
  const CommitButton({super.key});

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      height: 50,
      child: ElevatedButton(
        style: ElevatedButton.styleFrom(
          backgroundColor: Color(0xff4C667F),
        ),
        onPressed: () {
          debugPrint("Commit All Synchronizations");
        },
        child: Text(
          "Commit All Synchronizations",
          style: TextStyle(
            color: Colors.white,
            fontSize: 20,
            fontWeight: FontWeight.w500,
          ),
        ),
      ),
    );
  }
}
