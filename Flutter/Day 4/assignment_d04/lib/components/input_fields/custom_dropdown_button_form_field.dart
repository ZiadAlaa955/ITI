import 'package:flutter/material.dart';

class CustomDropownButtonFormField extends StatelessWidget {
  const CustomDropownButtonFormField({
    super.key,
    required this.label,
    required this.icon,
    required this.hint,
    required this.value,
    required this.items,
    this.onChanged,
    this.validator,
  });
  final String label;
  final IconData icon;
  final String hint;
  final String? value;
  final List<String> items;
  final ValueChanged<String?>? onChanged;
  final FormFieldValidator<String>? validator;

  @override
  Widget build(BuildContext context) {
    return DropdownButtonFormField(
      decoration: InputDecoration(
        label: Text(label),
        prefixIcon: Icon(icon),
        border: OutlineInputBorder(
          borderRadius: BorderRadius.circular(12),
        ),
        focusedBorder: OutlineInputBorder(
          borderRadius: BorderRadius.circular(12),
        ),
      ),
      hint: Text(
        hint,
        style: TextStyle(color: Colors.grey[600]),
      ),
      initialValue: value,
      items: items.map((String item) {
        return DropdownMenuItem<String>(
          value: item,
          child: Text(item),
        );
      }).toList(),
      onChanged: onChanged,
      validator: validator,
    );
  }
}
