import 'package:assignment_d04/components/buttons/add_employee_button.dart';
import 'package:assignment_d04/components/input_fields/custom_dropdown_button_form_field.dart';
import 'package:assignment_d04/components/input_fields/custom_text_form_field.dart';
import 'package:assignment_d04/models/employee_model.dart';
import 'package:flutter/material.dart';

class AddEmployeePage extends StatefulWidget {
  const AddEmployeePage({super.key});

  @override
  State<AddEmployeePage> createState() => _AddEmployeePageState();
}

class _AddEmployeePageState extends State<AddEmployeePage> {
  final _formKey = GlobalKey<FormState>();
  final TextEditingController _nameController = TextEditingController();
  final TextEditingController _urlController = TextEditingController();
  final TextEditingController _hoursController = TextEditingController();
  final FocusNode _nameFocusNode = FocusNode();
  final FocusNode _urlFocusNode = FocusNode();
  final FocusNode _hoursFocusNode = FocusNode();
  String? _nameValidator(String? value) {
    if (value == null || value.trim().isEmpty) {
      return 'Required, please enter a name.';
    }
    if (value.trim().length < 3) {
      return 'Required, minimum 3 characters.';
    }
    return null;
  }

  String? _imageValidator(String? value) {
    if (value == null || value.trim().isEmpty) {
      return 'Required, please enter an image URL.';
    }
    if (!value.trim().startsWith('http')) {
      return 'Please enter a valid URL starting with http/https.';
    }
    return null;
  }

  String? _hoursValidator(String? value) {
    if (value == null || value.trim().isEmpty) {
      return 'Required, please enter weekly hours.';
    }
    final int? hours = int.tryParse(value.trim());

    if (hours == null) {
      return 'Must be a valid integer.';
    }
    if (hours <= 0 || hours > 80) {
      return 'Required, must be a valid integer within logical range.';
    }
    return null;
  }

  String? _selectedLevel;
  String? _selectedRole;
  bool? _isCheked = false;

  final List<String> _levels = ["Junior", "Mid_Level", "Senior"];
  final List<String> _roles = [
    "Project Manager",
    "Software Engineer",
    "UX Designer",
    "Quality Assurance",
    "Product Owner",
    "Data Scientist",
    "HR Specialist",
    "DevOps Engineer",
    "Marketing Manager",
  ];

  void _addEmployee() {
    final isValid = _formKey.currentState!.validate();

    if (!isValid) return;

    if (_isCheked != true) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text("Please confirm data accuracy before submitting"),
          backgroundColor: Colors.red,
        ),
      );
      return;
    }

    final savedEmployee = EmployeeModel(
      name: _nameController.text.trim(),
      role: _selectedRole!,
      image: _urlController.text.trim(),
      isActive: true,
      level: _selectedLevel!,
    );

    Navigator.of(context).pop(savedEmployee);
  }

  @override
  void dispose() {
    _nameController.dispose();
    _urlController.dispose();
    _hoursController.dispose();
    _nameFocusNode.dispose();
    _urlFocusNode.dispose();
    _hoursFocusNode.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Color(0xff0D7A8F),
        foregroundColor: Colors.white,
        centerTitle: true,
        title: Text(
          "Add New Employee",
          style: TextStyle(
            fontWeight: FontWeight.bold,
            fontSize: 22,
          ),
        ),
      ),
      body: Form(
        key: _formKey,
        child: SingleChildScrollView(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            children: [
              const SizedBox(height: 16),
              CustomTextFormField(
                label: "Full Name",
                hint: "Enter employee's full name",
                iconData: Icons.person,
                controller: _nameController,
                focusNode: _nameFocusNode,
                isSecured: false,
                validator: _nameValidator,
              ),
              const SizedBox(height: 32),
              CustomTextFormField(
                label: "Image URL",
                hint: "Enter profile image link",
                iconData: Icons.image,
                controller: _urlController,
                focusNode: _urlFocusNode,
                isSecured: false,
                validator: _imageValidator,
              ),
              const SizedBox(height: 32),
              CustomTextFormField(
                label: "Weekly Hours",
                hint: "Enter hours (e.g. 40)",
                iconData: Icons.access_time_filled,
                controller: _hoursController,
                focusNode: _hoursFocusNode,
                isSecured: false,
                validator: _hoursValidator,
              ),
              const SizedBox(height: 32),
              CustomDropownButtonFormField(
                label: 'Role',
                icon: Icons.work,
                hint: 'Select employee role',
                value: _selectedRole,
                items: _roles,
                onChanged: (value) {
                  setState(() {
                    _selectedRole = value;
                  });
                },
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return "Please select a role";
                  }
                  return null;
                },
              ),
              const SizedBox(height: 32),
              CustomDropownButtonFormField(
                label: "Level",
                icon: Icons.star_border,
                hint: "Select experience level",
                value: _selectedLevel,
                items: _levels,
                onChanged: (value) {
                  setState(() {
                    _selectedLevel = value;
                  });
                },
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return "Please select a level";
                  }
                  return null;
                },
              ),
              const SizedBox(height: 16),
              CheckboxListTile(
                controlAffinity: ListTileControlAffinity.leading,
                contentPadding: EdgeInsets.zero,
                title: Text(
                  "Confirm Data Accuracy",
                  style: TextStyle(
                    fontWeight: FontWeight.w500,
                    fontSize: 18,
                  ),
                ),
                subtitle: Text(
                  "I verify that the employee information provided above is correct",
                  style: TextStyle(
                    fontWeight: FontWeight.w400,
                    fontSize: 16,
                  ),
                ),
                value: _isCheked,
                onChanged: (value) {
                  setState(() {
                    _isCheked = value;
                  });
                },
              ),
              const SizedBox(height: 64),
              AddEmployeeButton(
                onPressed: _addEmployee,
              ),
            ],
          ),
        ),
      ),
    );
  }
}
