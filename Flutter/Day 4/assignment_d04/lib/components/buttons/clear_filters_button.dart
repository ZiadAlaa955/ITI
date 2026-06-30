import 'package:flutter/material.dart';

class ClearFiltersButton extends StatelessWidget {
  const ClearFiltersButton({super.key, this.onPressed});

  final void Function()? onPressed;

  @override
  Widget build(BuildContext context) {
    return ElevatedButton(
      style: ElevatedButton.styleFrom(
        backgroundColor: Color(0xff0D7A8F),
      ),
      onPressed: onPressed,
      child: Text(
        "Clear Filters",
        style: TextStyle(color: Colors.white),
      ),
    );
  }
}
