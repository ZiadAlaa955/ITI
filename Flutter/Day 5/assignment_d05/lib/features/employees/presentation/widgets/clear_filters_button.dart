import 'package:flutter/material.dart';

class ClearFiltersButton extends StatelessWidget {
  const ClearFiltersButton({super.key, this.onPressed});

  final void Function()? onPressed;

  @override
  Widget build(BuildContext context) {
    return TextButton.icon(
      onPressed: onPressed,
      icon: const Icon(
        Icons.cancel_outlined,
        color: Color(0xff0D7A8F),
        size: 20,
      ),
      label: const Text(
        "Clear filters",
        style: TextStyle(
          color: Color(0xff0D7A8F),
          fontWeight: FontWeight.w600,
          fontSize: 15,
        ),
      ),
      style: TextButton.styleFrom(
        padding: EdgeInsets.zero,
        alignment: Alignment.centerRight,
      ),
    );
  }
}
