import 'package:assignment_d05/core/utils/app_validators.dart';
import 'package:assignment_d05/features/employees/presentation/widgets/add_employee_button.dart';
import 'package:assignment_d05/features/employees/presentation/widgets/cancel_employee_button.dart';
import 'package:assignment_d05/features/employees/presentation/widgets/toggle_active_button.dart';
import 'package:assignment_d05/core/widgets/custom_dropdown_button_form_field.dart';
import 'package:assignment_d05/core/widgets/custom_text_form_field.dart';
import 'package:assignment_d05/features/employees/data/models/employee_model.dart';
import 'package:flutter/material.dart';

class AddEditEmployeePage extends StatefulWidget {
  const AddEditEmployeePage({
    super.key,
    required this.appBarTitle,
    this.employeeToEdit,
  });
  final String appBarTitle;
  final EmployeeModel? employeeToEdit;

  @override
  State<AddEditEmployeePage> createState() => _AddEditEmployeePageState();
}

class _AddEditEmployeePageState extends State<AddEditEmployeePage> {
  final _formKey = GlobalKey<FormState>();
  final TextEditingController _nameController = TextEditingController();
  final TextEditingController _urlController = TextEditingController();
  final TextEditingController _hoursController = TextEditingController();
  final TextEditingController _salaryController = TextEditingController();
  final FocusNode _nameFocusNode = FocusNode();
  final FocusNode _urlFocusNode = FocusNode();
  final FocusNode _hoursFocusNode = FocusNode();
  final FocusNode _salaryNode = FocusNode();

  String? _selectedDepartment;
  String? _selectedJobTitle;
  bool? _isCheked = false;
  bool _isFavorite = false;

  final List<String> _departments = [
    "Engineering",
    "Design",
    "HR",
    "Marketing",
    "Sales",
  ];
  final List<String> _jobTitles = [
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
        const SnackBar(
          content: Text("Please confirm data accuracy before submitting"),
          backgroundColor: Colors.red,
          behavior: SnackBarBehavior.floating,
        ),
      );
      return;
    }

    final savedEmployee = EmployeeModel(
      id: 0,
      name: _nameController.text.trim(),
      jobTitle: _selectedJobTitle!,
      image: _urlController.text.trim(),
      isFavorite: _isFavorite,
      department: _selectedDepartment!,
      salary: double.parse(_salaryController.text.trim()),
      weeklyHours: int.parse(_hoursController.text),
    );

    Navigator.of(context).pop(savedEmployee);
  }

  void _editEmployee() {
    final isValid = _formKey.currentState!.validate();

    if (!isValid) return;

    final savedEmployee = EmployeeModel(
      id: widget.employeeToEdit!.id,
      name: _nameController.text.trim(),
      jobTitle: _selectedJobTitle!,
      image: _urlController.text.trim(),
      isFavorite: _isFavorite,
      department: _selectedDepartment!,
      salary: double.parse(_salaryController.text.trim()),
      weeklyHours: int.parse(_hoursController.text),
    );

    Navigator.of(context).pop(savedEmployee);
  }

  @override
  void initState() {
    super.initState();
    if (widget.employeeToEdit != null) {
      _nameController.text = widget.employeeToEdit!.name;
      _salaryController.text = widget.employeeToEdit!.salary.toString();
      _urlController.text = widget.employeeToEdit!.image;
      _hoursController.text = widget.employeeToEdit!.weeklyHours.toString();
      _selectedDepartment = widget.employeeToEdit!.department;
      _selectedJobTitle = widget.employeeToEdit!.jobTitle;
      _isFavorite = widget.employeeToEdit!.isFavorite;
    }
  }

  @override
  void dispose() {
    _nameController.dispose();
    _urlController.dispose();
    _hoursController.dispose();
    _nameFocusNode.dispose();
    _urlFocusNode.dispose();
    _hoursFocusNode.dispose();
    _salaryController.dispose();
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
          widget.appBarTitle,
          style: const TextStyle(
            fontWeight: FontWeight.bold,
            fontSize: 22,
          ),
        ),
      ),
      body: Form(
        key: _formKey,
        child: Column(
          children: [
            Expanded(
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
                      validator: AppValidators.nameValidator,
                    ),
                    const SizedBox(height: 32),
                    CustomTextFormField(
                      label: "Image URL",
                      hint: "Enter profile image link",
                      iconData: Icons.image,
                      controller: _urlController,
                      focusNode: _urlFocusNode,
                      isSecured: false,
                      validator: AppValidators.imageValidator,
                    ),
                    const SizedBox(height: 32),
                    CustomTextFormField(
                      label: "Weekly Hours",
                      hint: "Enter hours (e.g. 40)",
                      iconData: Icons.access_time_filled,
                      controller: _hoursController,
                      focusNode: _hoursFocusNode,
                      isSecured: false,
                      validator: AppValidators.hoursValidator,
                    ),
                    const SizedBox(height: 32),
                    CustomTextFormField(
                      label: "Salary",
                      hint: "Enter Salary",
                      iconData: Icons.credit_card,
                      controller: _salaryController,
                      focusNode: _salaryNode,
                      isSecured: false,
                      validator: AppValidators.salaryValidator,
                    ),
                    const SizedBox(height: 32),
                    CustomDropownButtonFormField(
                      label: 'Job Title',
                      icon: Icons.work,
                      hint: 'Select a job title',
                      value: _selectedJobTitle,
                      items: _jobTitles,
                      onChanged: (value) {
                        setState(() {
                          _selectedJobTitle = value;
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
                      label: "Department",
                      icon: Icons.star_border,
                      hint: "Select department",
                      value: _selectedDepartment,
                      items: _departments,
                      onChanged: (value) {
                        setState(() {
                          _selectedDepartment = value;
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
                    FavoritesSwitch(
                      value: _isFavorite,
                      onChanged: (value) {
                        setState(() {
                          _isFavorite = value;
                        });
                      },
                    ),
                    const SizedBox(height: 16),
                    widget.employeeToEdit == null
                        ? CheckboxListTile(
                            controlAffinity: ListTileControlAffinity.leading,
                            contentPadding: EdgeInsets.zero,
                            title: const Text(
                              "Confirm Data Accuracy",
                              style: TextStyle(
                                fontWeight: FontWeight.w500,
                                fontSize: 18,
                              ),
                            ),
                            subtitle: const Text(
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
                          )
                        : const SizedBox(),
                    const SizedBox(height: 32),
                    AddEditEmployeeButton(
                      onPressed: widget.employeeToEdit == null
                          ? _addEmployee
                          : _editEmployee,
                      title: widget.employeeToEdit == null
                          ? "Add Employee"
                          : "Save Employee",
                    ),
                    const SizedBox(height: 8),
                    const CancelEmployeeButton(),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
