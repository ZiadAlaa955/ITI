import 'package:assignment_d05/features/dashboard/presentation/widgets/activity_item.dart';
import 'package:flutter/material.dart';

class ActivityListCard extends StatelessWidget {
  const ActivityListCard({super.key});

  @override
  Widget build(BuildContext context) {
    final isDark = Theme.of(context).brightness == Brightness.dark;

    const addColor = Color(0xff0153A7);
    const editColor = Color(0xFF0F9D58);
    const removeColor = Color(0xFFDB4437);

    return Card(
      elevation: 0,
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(16),
        side: BorderSide(
          color: isDark ? Colors.grey.shade800 : Colors.grey.shade200,
        ),
      ),
      clipBehavior: Clip.antiAlias,
      child: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          ActivityItem(
            icon: Icons.person_add_alt_rounded,
            iconColor: isDark ? Colors.white : addColor,
            bgColor: isDark ? addColor.withAlpha(40) : const Color(0xffE5F0FE),
            title: "New employee added",
          ),
          Divider(
            height: 1,
            thickness: 1,
            color: isDark ? Colors.grey.shade800 : Colors.grey.shade100,
          ),
          ActivityItem(
            icon: Icons.edit,
            iconColor: isDark ? Colors.white : editColor,
            bgColor: isDark ? editColor.withAlpha(40) : const Color(0xFFE6F4EA),
            title: "Employee profile updated",
          ),
          Divider(
            height: 1,
            thickness: 1,
            color: isDark ? Colors.grey.shade800 : Colors.grey.shade100,
          ),
          ActivityItem(
            icon: Icons.person_remove,
            iconColor: isDark ? Colors.white : removeColor,
            bgColor: isDark
                ? removeColor.withAlpha(40)
                : const Color(0xFFFCE8E6),
            title: "Employee removed from list",
          ),
        ],
      ),
    );
  }
}
