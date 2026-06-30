import 'package:flutter/material.dart';

class CustomFilterChip extends StatelessWidget {
  const CustomFilterChip({
    super.key,
    required this.title,
    this.onTap,
    required this.isSelected,
  });

  final String title;
  final bool isSelected;
  final void Function()? onTap;

  Color departmentColor(String departmentName) {
    switch (departmentName) {
      case "Engineering":
        return const Color(0xff3A5A78);
      case "Design":
        return const Color(0xff8A5A6D);
      case "HR":
        return const Color(0xffC99B78);
      case "Marketing":
        return const Color(0xff5B7A66);
      case "Sales":
        return const Color(0xffA86F54);
      default:
        return Colors.grey;
    }
  }

  @override
  @override
  Widget build(BuildContext context) {
    final isDark = Theme.of(context).brightness == Brightness.dark;

    final unselectedBgColor = isDark ? const Color(0xFF2A2D32) : Colors.white;

    return Padding(
      padding: const EdgeInsets.only(top: 16, bottom: 8, right: 10),
      child: GestureDetector(
        onTap: onTap,
        child: AnimatedContainer(
          duration: const Duration(milliseconds: 200),
          decoration: BoxDecoration(
            color: isSelected ? departmentColor(title) : unselectedBgColor,
            border: Border.all(
              color: isSelected
                  ? departmentColor(title)
                  : departmentColor(title).withAlpha(120),
              width: 1.5,
            ),
            borderRadius: BorderRadius.circular(24),
          ),
          child: Padding(
            padding: const EdgeInsets.symmetric(vertical: 5, horizontal: 8),
            child: Center(
              child: Text(
                title,
                style: TextStyle(
                  color: isSelected ? Colors.white : departmentColor(title),
                  fontWeight: FontWeight.w600,
                  fontSize: 14,
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }
}
