import 'package:assignment_d05/features/employees/data/datasources/api_service.dart';
import 'package:assignment_d05/features/employees/data/datasources/database_helper.dart';
import 'package:assignment_d05/features/employees/data/models/employee_model.dart';
import 'package:assignment_d05/features/employees/presentation/cubit/employee_state.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class EmployeeCubit extends Cubit<EmployeeState> {
  EmployeeCubit() : super(EmployeeLoading()) {
    loadEmployees();
  }

  final ApiService _apiService = ApiService();

  Future<void> loadEmployees() async {
    emit(EmployeeLoading());
    try {
      final localEmployees = await DatabaseHelper.instance.getEmployees();
      if (localEmployees.isNotEmpty) {
        emit(EmployeeLoaded(employees: localEmployees));
      }

      final apiEmployees = await _apiService.fetchEmployees();

      for (final employee in apiEmployees) {
        await DatabaseHelper.instance.insertEmployee(employee);
      }

      final syncedEmployees = await DatabaseHelper.instance.getEmployees();
      emit(EmployeeLoaded(employees: syncedEmployees));
    } catch (e) {
      try {
        final localEmployees = await DatabaseHelper.instance.getEmployees();
        if (localEmployees.isNotEmpty) {
          emit(EmployeeLoaded(employees: localEmployees));
        } else {
          emit(EmployeeError(message: "Failed to load data. Error: $e"));
        }
      } catch (dbError) {
        emit(
          EmployeeError(
            message: "Critical Error: Could not access local database.",
          ),
        );
      }
    }
  }

  Future<void> addEmployee(EmployeeModel employee) async {
    try {
      final newEmployeeFromApi = await _apiService.postEmployee(employee);

      await DatabaseHelper.instance.insertEmployee(newEmployeeFromApi);

      loadEmployees();
    } catch (e) {
      emit(EmployeeError(message: "Failed to add employee to cloud: $e"));
    }
  }

  Future<void> updateEmployee(EmployeeModel updatedEmployee) async {
    try {
      await _apiService.updateEmployee(updatedEmployee);

      await DatabaseHelper.instance.updateEmployee(updatedEmployee);

      await loadEmployees();
    } catch (e) {
      emit(EmployeeError(message: "Failed to update employee in cloud: $e"));
    }
  }

  Future<void> deleteEmployee(int id) async {
    try {
      await _apiService.deleteEmployee(id);

      await DatabaseHelper.instance.deleteEmployee(id);

      await loadEmployees();
    } catch (e) {
      emit(EmployeeError(message: "Failed to delete employee from cloud: $e"));
    }
  }

  Future<void> toggleFavorite(EmployeeModel employee) async {
    final updatedEmployee = employee.copyWith(isFavorite: !employee.isFavorite);
    await updateEmployee(updatedEmployee);
  }
}
