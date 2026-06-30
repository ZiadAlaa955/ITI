import 'package:assignment_d05/core/theme/app_theme.dart';
import 'package:assignment_d05/core/theme/theme_cubit.dart';
import 'package:assignment_d05/features/auth/cubit/auth_cubit.dart';
import 'package:assignment_d05/features/auth/presentation/pages/login_page.dart';
import 'package:assignment_d05/features/employees/presentation/cubit/employee_cubit.dart';
import 'package:assignment_d05/firebase_options.dart';
import 'package:firebase_core/firebase_core.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();

  await Firebase.initializeApp(
    options: DefaultFirebaseOptions.currentPlatform,
  );

  runApp(const CompanyManagerApp());
}

class CompanyManagerApp extends StatefulWidget {
  const CompanyManagerApp({super.key});

  @override
  State<CompanyManagerApp> createState() => _CompanyManagerAppState();
}

class _CompanyManagerAppState extends State<CompanyManagerApp> {
  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      providers: [
        BlocProvider(create: (context) => EmployeeCubit()),
        BlocProvider(create: (context) => ThemeCubit()),
        BlocProvider(create: (context) => AuthCubit()),
      ],
      child: BlocBuilder<ThemeCubit, bool>(
        builder: (context, isDark) {
          return MaterialApp(
            debugShowCheckedModeBanner: false,
            theme: AppTheme.lightTheme,
            darkTheme: AppTheme.darkTheme,
            themeMode: isDark ? ThemeMode.dark : ThemeMode.light,
            home: const LoginPage(),
          );
        },
      ),
    );
  }
}
