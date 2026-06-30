import 'package:assignment_d04/pages/employee_directory_page.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(AssignmentOne());
}

class AssignmentOne extends StatelessWidget {
  const AssignmentOne({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Color(0xff4C667F)),
        useMaterial3: true,
      ),

      home: EmployeeDirectoryPage(),
    );
  }
}
