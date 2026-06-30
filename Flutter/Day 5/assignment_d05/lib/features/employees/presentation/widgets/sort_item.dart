import 'package:flutter/material.dart';

class SortItem extends StatelessWidget {
  const SortItem({
    super.key,
    required this.icon,
    required this.title,
    required this.bgColor,
    required this.iconColor,
    this.onTap,
  });
  final IconData icon;
  final String title;
  final Color bgColor;
  final Color iconColor;
  final void Function()? onTap;

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: ListTile(
        title: Text(
          title,
          style: const TextStyle(
            fontSize: 18,
            fontWeight: FontWeight.w600,
          ),
        ),
        leading: CircleAvatar(
          backgroundColor: bgColor,
          radius: 25,
          child: Icon(
            icon,
            size: 25,
            color: iconColor,
          ),
        ),
      ),
    );
  }
}
