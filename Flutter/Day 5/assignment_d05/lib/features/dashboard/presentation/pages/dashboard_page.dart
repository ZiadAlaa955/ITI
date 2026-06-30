import 'package:assignment_d05/features/dashboard/presentation/widgets/activity_list_card.dart';
import 'package:assignment_d05/features/dashboard/presentation/widgets/company_overview_card.dart';
import 'package:assignment_d05/features/dashboard/presentation/widgets/custom_statistics_card.dart';
import 'package:assignment_d05/features/employees/data/models/employee_model.dart';
import 'package:assignment_d05/features/employees/presentation/cubit/employee_cubit.dart';
import 'package:assignment_d05/features/employees/presentation/cubit/employee_state.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class DashboardPage extends StatelessWidget {
  const DashboardPage({super.key});

  @override
  Widget build(BuildContext context) {
    int calcAvgSalary(List<EmployeeModel> employees) {
      if (employees.isEmpty) return 0;

      int totalSalary = 0;

      for (int i = 0; i < employees.length; i++) {
        totalSalary += employees[i].salary.round();
      }
      return (totalSalary / employees.length).round();
    }

    int calcFavorites(List<EmployeeModel> employees) {
      if (employees.isEmpty) return 0;

      int total = 0;

      for (int i = 0; i < employees.length; i++) {
        if (employees[i].isFavorite) total++;
      }
      return total;
    }

    int calcDepartments(List<EmployeeModel> employees) {
      if (employees.isEmpty) return 0;

      return employees.map((emp) => emp.department).toSet().length;
    }

    return Scaffold(
      appBar: AppBar(
        title: const Text(
          "Dashboard",
          style: TextStyle(fontWeight: FontWeight.w600),
        ),
      ),
      body: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
        child: SingleChildScrollView(
          child: BlocBuilder<EmployeeCubit, EmployeeState>(
            builder: (context, state) {
              if (state is EmployeeLoading) {
                return const Center(child: CircularProgressIndicator());
              } else if (state is EmployeeError) {
                return Center(child: Text(state.message));
              } else if (state is EmployeeLoaded) {
                return Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    CompanyOverviewCard(
                      totalEmployee: state.employees.length,
                      favoriteEmployees: calcFavorites(state.employees),
                      departments: calcDepartments(state.employees),
                      avgSalary: calcAvgSalary(state.employees),
                    ),
                    const SizedBox(height: 16),
                    GridView.count(
                      crossAxisCount: 2,
                      physics: const NeverScrollableScrollPhysics(),
                      crossAxisSpacing: 0,
                      shrinkWrap: true,
                      mainAxisSpacing: 8,
                      childAspectRatio: 1.7,
                      children: [
                        CustomStatisticsCard(
                          title: 'Employees',
                          value: state.employees.length.toString(),
                          icon: Icons.people,
                          iconColor: const Color(0xff0153A7),
                          iconBackgroundColor: const Color(0xffE5F0FE),
                        ),
                        CustomStatisticsCard(
                          title: 'Favorites',
                          value: calcFavorites(state.employees).toString(),
                          icon: Icons.favorite,
                          iconColor: const Color(0xffE54659),
                          iconBackgroundColor: const Color(0xffFEEBEE),
                        ),
                        CustomStatisticsCard(
                          title: 'Departments',
                          value: calcDepartments(state.employees).toString(),
                          icon: Icons.account_tree,
                          iconColor: const Color(0xff027E9E),
                          iconBackgroundColor: const Color(0xffE7F6F9),
                        ),
                        CustomStatisticsCard(
                          title: 'Avg Salary',
                          value: calcAvgSalary(state.employees).toString(),
                          icon: Icons.payment,
                          iconColor: const Color(0xff088337),
                          iconBackgroundColor: const Color(0xffE5F3E6),
                        ),
                      ],
                    ),
                    const SizedBox(height: 16),
                    const Text(
                      "Recent Activity",
                      style: TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 18,
                      ),
                    ),
                    const ActivityListCard(),
                  ],
                );
              }
              return const SizedBox();
            },
          ),
        ),
      ),
    );
  }
}
