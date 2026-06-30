import 'package:assignment_d05/core/utils/app_validators.dart';
import 'package:assignment_d05/core/widgets/custom_button.dart';
import 'package:assignment_d05/features/auth/cubit/auth_cubit.dart';
import 'package:assignment_d05/features/auth/cubit/auth_state.dart';
import 'package:assignment_d05/features/employees/presentation/widgets/app_shell.dart';
import 'package:assignment_d05/core/widgets/custom_text_form_field.dart';
import 'package:assignment_d05/features/auth/presentation/widgets/auth_title.dart';
import 'package:assignment_d05/features/auth/presentation/pages/login_page.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class SignupPage extends StatefulWidget {
  const SignupPage({super.key});

  @override
  State<SignupPage> createState() => _SignupPageState();
}

class _SignupPageState extends State<SignupPage> {
  bool _isPasswordHidden = true;
  bool _isConfirmPasswordHidden = true;
  bool _showValidationAfterSubmit = false;

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

    if (!isValid) {
      setState(() {
        _showValidationAfterSubmit = true;
      });
      return;
    }

    FocusScope.of(context).unfocus();

    context.read<AuthCubit>().signup(
      name: _nameController.text.trim(),
      email: _emailController.text.trim(),
      password: _passwordController.text,
    );
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
        child: BlocConsumer<AuthCubit, AuthState>(
          listener: (context, state) {
            if (state is AuthSuccess) {
              ScaffoldMessenger.of(context).showSnackBar(
                const SnackBar(
                  content: Text("Submitted successfully"),
                  backgroundColor: Colors.green,
                  behavior: SnackBarBehavior.floating,
                ),
              );
              Navigator.pushReplacement(
                context,
                MaterialPageRoute(
                  builder: (context) {
                    return const AppShell();
                  },
                ),
              );
            } else if (state is AuthError) {
              ScaffoldMessenger.of(context).showSnackBar(
                SnackBar(
                  content: Text(state.message),
                  backgroundColor: Colors.red,
                  behavior: SnackBarBehavior.floating,
                ),
              );
            }
          },
          builder: (context, state) {
            return Padding(
              padding: const EdgeInsets.all(32),
              child: SingleChildScrollView(
                child: Column(
                  children: [
                    const SizedBox(height: 32),
                    const AuthTitle(
                      title: 'Tech Company Portal',
                      subtitle: 'Sign up to manage employees and departments',
                    ),
                    const SizedBox(height: 64),
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
                            validator: AppValidators.nameValidator,
                            isSecured: false,
                          ),
                          const SizedBox(height: 32),
                          CustomTextFormField(
                            label: "Email Address",
                            hint: 'person132@gmail.com',
                            iconData: Icons.email_outlined,
                            controller: _emailController,
                            focusNode: _emailFocusNode,
                            validator: AppValidators.emailValidator,
                            isSecured: false,
                            keyboardType: TextInputType.emailAddress,
                          ),
                          const SizedBox(height: 32),
                          CustomTextFormField(
                            label: "Password",
                            hint: 'Enter your password',
                            iconData: Icons.lock_outline,
                            controller: _passwordController,
                            focusNode: _passwordFocusNode,
                            validator: AppValidators.passwordValidator,
                            isSecured: _isPasswordHidden,
                            toggleObsecure: _togglePasswordVisibility,
                          ),
                          const SizedBox(height: 32),
                          CustomTextFormField(
                            label: "Confirm Password",
                            hint: 'Enter your confirm password',
                            iconData: Icons.shield_outlined,
                            controller: _confirmPasswordController,
                            focusNode: _confirmPasswordFocusNode,
                            validator: (value) {
                              AppValidators.confirmPasswordValidator(
                                value,
                                _passwordController,
                              );
                              return;
                            },
                            isSecured: _isConfirmPasswordHidden,
                            toggleObsecure: _toggleConfirmPasswordVisibility,
                          ),
                          const SizedBox(height: 64),
                        ],
                      ),
                    ),
                    SizedBox(
                      width: double.infinity,
                      child: state is AuthLoading
                          ? const Center(
                              child: CircularProgressIndicator(
                                color: Color(0xff334655),
                              ),
                            )
                          : CustomButton(
                              icon: Icons.login,
                              buttonTitle: "Sign Up",
                              buttonColor: const Color(0xff334655),
                              onPressed: _submitForm,
                            ),
                    ),
                    const SizedBox(width: 12),
                    const SizedBox(height: 32),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        const Text(
                          "Already have an account? ",
                          style: TextStyle(fontSize: 16),
                        ),
                        GestureDetector(
                          onTap: () {
                            Navigator.pushReplacement(
                              context,
                              MaterialPageRoute(
                                builder: (context) {
                                  return const LoginPage();
                                },
                              ),
                            );
                          },
                          child: const Text(
                            "Login",
                            style: TextStyle(
                              fontSize: 16,
                              fontWeight: FontWeight.bold,
                              color: Color(0xff334655),
                            ),
                          ),
                        ),
                      ],
                    ),
                  ],
                ),
              ),
            );
          },
        ),
      ),
    );
  }
}
