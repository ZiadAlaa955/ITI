import 'package:assignment_d03/components/custom_button.dart';
import 'package:assignment_d03/components/custom_text_form_field.dart';
import 'package:assignment_d03/components/form_Info_card.dart';
import 'package:assignment_d03/components/preview_row.dart';
import 'package:assignment_d03/components/signup_title.dart';
import 'package:assignment_d03/models/user_model.dart';
import 'package:flutter/material.dart';

class SignupPage extends StatefulWidget {
  const SignupPage({super.key});

  @override
  State<SignupPage> createState() => _SignupPageState();
}

class _SignupPageState extends State<SignupPage> {
  bool _isPasswordHidden = true;
  bool _isConfirmPasswordHidden = true;
  bool _showValidationAfterSubmit = false;

  UserModel? _userModel;

  final GlobalKey<FormState> _enrollmentKey = GlobalKey<FormState>();

  final TextEditingController _nameController = TextEditingController();
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _confirmPasswordController =
      TextEditingController();

  final FocusNode _nameFocusNode = FocusNode();
  final FocusNode _emailFocusNode = FocusNode();
  final FocusNode _passwordFocusNode = FocusNode();
  final FocusNode _confirmPasswordFocusNode = FocusNode();

  String? _nameValidator(String? value) {
    final name = value?.trim() ?? "";
    if (name.isEmpty) {
      return "Name is required";
    }
    if (name.length < 3) {
      return "Name must be at least 3 characters";
    }
    return null;
  }

  String? _emailValidator(String? value) {
    final email = value?.trim() ?? "";
    if (email.isEmpty) {
      return "Email is required";
    }
    final hasAtSymbol = email.contains("@");
    final hasDot = email.contains(".");
    if (!hasAtSymbol || !hasDot) {
      return "Enter a vaild email";
    }
    return null;
  }

  String? _passwordValidator(String? value) {
    final password = value ?? "";
    if (password.isEmpty) {
      return "Password is required";
    }
    if (password.length < 8) {
      return "Password must be at least 8 characters";
    }
    final RegExp passwordRegex = RegExp(
      r'^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^a-zA-Z0-9]).+$',
    );
    if (!passwordRegex.hasMatch(password)) {
      return "Password must include an uppercase letter, a number, and a special character";
    }
    return null;
  }

  String? _confirmPasswordValidator(String? value) {
    final confirmPassword = value ?? "";
    if (confirmPassword.isEmpty) {
      return "Please confirm your password";
    }
    if (confirmPassword != _passwordController.text) {
      return "Passowrds do not match";
    }
    return null;
  }

  void _togglePasswordVisibility() {
    setState(() {
      _isPasswordHidden = !_isPasswordHidden;
    });
  }

  void _toggleConfirmPasswordVisibility() {
    setState(() {
      _isConfirmPasswordHidden = !_isConfirmPasswordHidden;
    });
  }

  void _submitForm() {
    final isValid = _enrollmentKey.currentState!.validate();

    if (!isValid) return;

    final request = UserModel(
      username: _nameController.text.trim(),
      email: _emailController.text.trim(),
    );

    setState(() {
      _userModel = request;
    });

    FocusScope.of(context).unfocus();

    setState(() {
      _showValidationAfterSubmit = true;
    });

    ScaffoldMessenger.of(context).showSnackBar(
      const SnackBar(
        content: Text("Submitted successfully"),
      ),
    );
  }

  void _resetForm() {
    _enrollmentKey.currentState?.reset();

    setState(() {
      _isPasswordHidden = true;
      _isConfirmPasswordHidden = true;
      _showValidationAfterSubmit = false;
      _userModel = null;
    });

    _confirmPasswordController.clear();
    _nameController.clear();
    _emailController.clear();
    _passwordController.clear();

    _nameFocusNode.requestFocus();
  }

  AutovalidateMode get _autoValidateMode {
    if (_showValidationAfterSubmit) {
      return AutovalidateMode.onUserInteraction;
    }
    return AutovalidateMode.disabled;
  }

  @override
  void dispose() {
    _confirmPasswordController.dispose();
    _nameController.dispose();
    _emailController.dispose();
    _passwordController.dispose();

    _nameFocusNode.dispose();
    _emailFocusNode.dispose();
    _passwordFocusNode.dispose();
    _confirmPasswordFocusNode.dispose();

    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Padding(
          padding: const EdgeInsets.all(32),
          child: SingleChildScrollView(
            child: Column(
              children: [
                SignupTitle(),
                SizedBox(height: 32),
                Form(
                  key: _enrollmentKey,
                  autovalidateMode: _autoValidateMode,
                  child: Column(
                    children: [
                      CustomTextFormField(
                        label: "Full Name",
                        hint: 'Enter your full name',
                        iconData: Icons.person_outline,
                        controller: _nameController,
                        focusNode: _nameFocusNode,
                        validator: _nameValidator,
                        isSecured: false,
                      ),
                      SizedBox(height: 16),
                      CustomTextFormField(
                        label: "Email Address",
                        hint: 'person132@gmail.com',
                        iconData: Icons.email_outlined,
                        controller: _emailController,
                        focusNode: _emailFocusNode,
                        validator: _emailValidator,
                        isSecured: false,
                      ),
                      SizedBox(height: 16),
                      CustomTextFormField(
                        label: "Password",
                        hint: '*********',
                        iconData: Icons.lock_outline,
                        controller: _passwordController,
                        focusNode: _passwordFocusNode,
                        validator: _passwordValidator,
                        isSecured: _isPasswordHidden,
                        toggleObsecure: _togglePasswordVisibility,
                      ),
                      SizedBox(height: 16),
                      CustomTextFormField(
                        label: "Confirm Password",
                        hint: '*********',
                        iconData: Icons.shield_outlined,
                        controller: _confirmPasswordController,
                        focusNode: _confirmPasswordFocusNode,
                        validator: _confirmPasswordValidator,
                        isSecured: _isConfirmPasswordHidden,
                        toggleObsecure: _toggleConfirmPasswordVisibility,
                      ),
                      SizedBox(height: 32),
                    ],
                  ),
                ),
                Row(
                  children: [
                    CustomButton(
                      buttonTitle: "Sign Up",
                      buttonColor: Color(0xff334655),
                      onPressed: _submitForm,
                    ),
                    SizedBox(width: 12),
                    CustomButton(
                      buttonTitle: "Reset Form",
                      buttonColor: Color(0xff64748B),
                      onPressed: _resetForm,
                    ),
                  ],
                ),
                SizedBox(height: 32),
                FormInfoCard(
                  title: "Submitted values",
                  children: [
                    PreviewRow(
                      label: "Engineer",
                      value: _userModel?.username ?? "",
                    ),
                    Divider(indent: 15, endIndent: 15),
                    PreviewRow(label: "Email", value: _userModel?.email ?? ""),
                    Divider(indent: 15, endIndent: 15),
                  ],
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
