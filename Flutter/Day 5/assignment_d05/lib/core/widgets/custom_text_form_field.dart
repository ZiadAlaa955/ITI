import 'package:flutter/material.dart';

class CustomTextFormField extends StatelessWidget {
  const CustomTextFormField({
    super.key,
    required this.label,
    required this.hint,
    required this.iconData,
    required this.controller,
    required this.focusNode,
    required this.validator,
    required this.isSecured,
    this.toggleObsecure,
    this.keyboardType,
  });

  final String label;
  final String hint;
  final IconData iconData;
  final TextEditingController controller;
  final FocusNode focusNode;
  final String? Function(String? value) validator;
  final bool isSecured;
  final VoidCallback? toggleObsecure;
  final TextInputType? keyboardType;

  @override
  Widget build(BuildContext context) {
    return TextFormField(
      keyboardType: keyboardType,
      onTapOutside: (event) {
        FocusManager.instance.primaryFocus?.unfocus();
      },
      controller: controller,
      focusNode: focusNode,
      textInputAction: TextInputAction.next,
      validator: validator,
      obscureText: isSecured,
      decoration: InputDecoration(
        label: Text(
          label,
          style:  const TextStyle(color: Colors.black),
        ),
        hint: Text(
          hint,
          style: TextStyle(color: Colors.grey[600]),
        ),
        prefixIcon: Icon(iconData),
        suffixIcon: toggleObsecure != null
            ? IconButton(
                onPressed: toggleObsecure,
                icon: Icon(
                  isSecured ? Icons.visibility_off : Icons.visibility,
                ),
              )
            : null,
        border: OutlineInputBorder(
          borderRadius: BorderRadius.circular(12),
        ),
        focusedBorder: OutlineInputBorder(
          borderRadius: BorderRadius.circular(12),
        ),
      ),
    );
  }
}
