import 'package:flutter/material.dart';

class FavoritesSwitch extends StatelessWidget {
  const FavoritesSwitch({super.key, required this.value, this.onChanged});

  final bool value;
  final void Function(bool)? onChanged;

  @override
  Widget build(BuildContext context) {
    return SwitchListTile(
      contentPadding: EdgeInsets.zero,
      title: const Text(
        "Show favorites only",
        style: TextStyle(
          fontWeight: FontWeight.w500,
          fontSize: 16,
          color: Color(0xFF334655),
        ),
      ),
      secondary: const Icon(
        Icons.favorite_border,
        color: Color(0xFF334655),
        size: 24,
      ),
      activeTrackColor: const Color(0xff0D7A8F),
      value: value,
      onChanged: onChanged,
      trackOutlineColor: const WidgetStatePropertyAll(Colors.transparent),
    );
  }
}
