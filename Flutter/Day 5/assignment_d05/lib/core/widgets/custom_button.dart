import 'package:flutter/material.dart';

class CustomButton extends StatelessWidget {
  const CustomButton({
    super.key,
    required this.buttonTitle,
    required this.onPressed,
    this.icon,
    this.buttonColor,
  });

  final String buttonTitle;
  final VoidCallback onPressed;
  final IconData? icon;
  final Color? buttonColor;

  @override
  Widget build(BuildContext context) {
    final buttonStyle = FilledButton.styleFrom(
      backgroundColor:
          buttonColor ??
          const Color(
            0xff0D7A8F,
          ),
      foregroundColor: Colors.white,
      minimumSize: const Size.fromHeight(48),
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(12),
      ),
    );
    if (icon != null) {
      return FilledButton.icon(
        onPressed: onPressed,
        style: buttonStyle,
        icon: Icon(icon),
        label: Text(
          buttonTitle,
          style: const TextStyle(
            fontSize: 16,
            fontWeight: FontWeight.bold,
          ),
        ),
      );
    }
    return FilledButton(
      onPressed: onPressed,
      style: buttonStyle,
      child: Text(
        buttonTitle,
        style: const TextStyle(
          fontSize: 16,
          fontWeight: FontWeight.bold,
        ),
      ),
    );
  }
}
