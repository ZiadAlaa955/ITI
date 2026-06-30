import 'package:assignment_d05/features/employees/presentation/widgets/clear_filters_button.dart';
import 'package:assignment_d05/features/employees/presentation/widgets/custom_filter_chip.dart';
import 'package:assignment_d05/features/employees/presentation/widgets/search_employees_textfield.dart';
import 'package:assignment_d05/features/employees/presentation/widgets/toggle_active_button.dart';
import 'package:flutter/material.dart';

class FiltersCard extends StatelessWidget {
  FiltersCard({
    super.key,
    required this.searchControler,
    required this.selectedDepartment,
    required this.showFavoritesOnly,
    required this.onDepartmentChanged,
    required this.onFavoritesChanged,
    this.clearFilters,
  });

  final TextEditingController searchControler;
  final String selectedDepartment;
  final bool showFavoritesOnly;

  final ValueChanged<String> onDepartmentChanged;
  final ValueChanged<bool> onFavoritesChanged;
  final VoidCallback? clearFilters;

  final List<String> _departments = [
    "Engineering",
    "Design",
    "HR",
    "Marketing",
    "Sales",
  ];

  @override
  Widget build(BuildContext context) {
    return Card(
      child: Padding(
        padding: const EdgeInsets.symmetric(
          horizontal: 16,
          vertical: 8,
        ),
        child: Column(
          children: [
            SearchEmployeesTextField(
              controller: searchControler,
            ),
            SingleChildScrollView(
              scrollDirection: Axis.horizontal,
              child: Row(
                children: _departments.map((dept) {
                  return CustomFilterChip(
                    title: dept,
                    isSelected: selectedDepartment == dept,
                    onTap: () {
                      final newDept = selectedDepartment == dept ? "" : dept;
                      onDepartmentChanged(newDept);
                    },
                  );
                }).toList(),
              ),
            ),
            Column(
              crossAxisAlignment: CrossAxisAlignment.end,
              children: [
                FavoritesSwitch(
                  value: showFavoritesOnly,
                  onChanged: (value) {
                    onFavoritesChanged(value);
                  },
                ),
                Divider(
                  height: 1,
                  thickness: 1,
                  color: Colors.grey.shade200,
                ),
                ClearFiltersButton(
                  onPressed: () {
                    clearFilters?.call();
                  },
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
