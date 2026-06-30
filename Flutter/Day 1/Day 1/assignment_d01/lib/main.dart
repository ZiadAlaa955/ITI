import 'package:assignment_d01/pages/home_page.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(AssignmentOne());
}

class AssignmentOne extends StatelessWidget {
  const AssignmentOne({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      debugShowCheckedModeBanner: false,
      home: HomePage(),
    );
  }
}

