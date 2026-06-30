import 'package:assignment_d05/features/employees/data/models/employee_model.dart';
import 'package:flutter/foundation.dart';

@immutable
abstract class EmployeeState {}

class EmployeeLoading extends EmployeeState {}

class EmployeeLoaded extends EmployeeState {
  final List<EmployeeModel> employees;
  EmployeeLoaded({required this.employees});
}

class EmployeeError extends EmployeeState {
  final String message;
  EmployeeError({required this.message});
}
