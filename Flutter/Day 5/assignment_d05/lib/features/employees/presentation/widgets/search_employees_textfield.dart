import 'package:flutter/material.dart';

class SearchEmployeesTextField extends StatelessWidget {
  const SearchEmployeesTextField({super.key, required this.controller});
  final TextEditingController controller;

  @override
  Widget build(BuildContext context) {
    final isDark = Theme.of(context).brightness == Brightness.dark;
    return TextField(
      onTapOutside: (event) {
        FocusManager.instance.primaryFocus?.unfocus();
      },
      controller: controller,
      style: TextStyle(color: isDark ? Colors.white : Colors.black87),
      cursorColor: const Color(0xff0D7A8F),
      decoration: InputDecoration(
        prefixIcon: Icon(
          Icons.search,
          color: isDark ? Colors.grey.shade400 : Colors.grey.shade600,
          size: 24,
        ),

        filled: true,
        fillColor: isDark ? const Color(0xFF2A2D32) : Colors.white,
        border: OutlineInputBorder(
          borderRadius: BorderRadius.circular(12),
          borderSide: BorderSide(color: Colors.grey.shade300),
        ),
        enabledBorder: OutlineInputBorder(
          borderRadius: BorderRadius.circular(12),
          borderSide: BorderSide(color: Colors.grey.shade300),
        ),
        focusedBorder: OutlineInputBorder(
          borderRadius: BorderRadius.circular(12),
          borderSide: const BorderSide(
            color: Color(0xff0D7A8F),
            width: 1.2,
          ),
        ),
        hintText: "Search employees",
        hintStyle: TextStyle(
          color: isDark ? Colors.grey.shade400 : Colors.grey.shade600,
        ),
        contentPadding: const EdgeInsets.symmetric(vertical: 10),
      ),
    );
  }
}
