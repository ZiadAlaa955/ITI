import 'package:assignment_d05/core/utils/app_validators.dart';
import 'package:assignment_d05/features/auth/cubit/auth_cubit.dart';
import 'package:assignment_d05/features/auth/cubit/auth_state.dart';
import 'package:assignment_d05/features/auth/presentation/widgets/auth_title.dart';
import 'package:assignment_d05/core/widgets/custom_button.dart';
import 'package:assignment_d05/core/widgets/custom_text_form_field.dart';
import 'package:assignment_d05/features/auth/presentation/widgets/signup_clickable_message.dart';
import 'package:assignment_d05/features/employees/presentation/widgets/app_shell.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({super.key});

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  bool _isPasswordHidden = true;
  bool _showValidationAfterSubmit = false;

  final GlobalKey<FormState> _loginKey = GlobalKey<FormState>();

  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();

  final FocusNode _emailFocusNode = FocusNode();
  final FocusNode _passwordFocusNode = FocusNode();

  void _togglePasswordVisibility() {
    setState(() {
      _isPasswordHidden = !_isPasswordHidden;
    });
  }

  void _submitLogin() {
    final isValid = _loginKey.currentState!.validate();

    if (!isValid) {
      setState(() {
        _showValidationAfterSubmit = true;
      });
      return;
    }

    FocusScope.of(context).unfocus();

    context.read<AuthCubit>().login(
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
    _emailController.dispose();
    _passwordController.dispose();
    _emailFocusNode.dispose();
    _passwordFocusNode.dispose();
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
                SnackBar(
                  content: Text("Welcome back, ${state.user.username}"),
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
                      subtitle: 'Sign in to manage employees and departments',
                    ),
                    const SizedBox(height: 64),
                    Form(
                      key: _loginKey,
                      autovalidateMode: _autoValidateMode,
                      child: Column(
                        children: [
                          CustomTextFormField(
                            label: "Email",
                            hint: 'example@company.com',
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
                          const SizedBox(height: 48),
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
                              buttonTitle: "Login",
                              buttonColor: const Color(0xff334655),
                              onPressed: _submitLogin,
                            ),
                    ),
                    const SizedBox(height: 16),
                    const SignupClickableMessage(),
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
