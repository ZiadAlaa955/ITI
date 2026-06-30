import 'package:assignment_d05/features/employees/data/models/employee_model.dart';
import 'package:dio/dio.dart';

class ApiService {
  final Dio _dio = Dio();

  final String _baseURL = "https://retoolapi.dev/NonOuh/employees";

  Future<List<EmployeeModel>> fetchEmployees() async {
    final response = await _dio.get(_baseURL);

    final List<dynamic> data = response.data;

    return data
        .map((json) => EmployeeModel.fromMap(json as Map<String, dynamic>))
        .toList();
  }

  Future<EmployeeModel> postEmployee(EmployeeModel employee) async {
    final employeeMap = employee.toMap();

    employeeMap.remove('id');

    final response = await _dio.post(_baseURL, data: employeeMap);

    return EmployeeModel.fromMap(response.data as Map<String, dynamic>);
  }

  Future<void> updateEmployee(EmployeeModel employee) async {
    await _dio.put('$_baseURL/${employee.id}', data: employee.toMap());
  }

  Future<void> deleteEmployee(int id) async {
    await _dio.delete('$_baseURL/$id');
  }
}
