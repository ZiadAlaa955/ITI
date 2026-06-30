import 'package:assignment_d05/features/dashboard/presentation/widgets/company_overview_info_row.dart';
import 'package:flutter/material.dart';

class CompanyOverviewCard extends StatelessWidget {
  const CompanyOverviewCard({
    super.key,
    required this.totalEmployee,
    required this.favoriteEmployees,
    required this.departments,
    required this.avgSalary,
  });
  final int totalEmployee;
  final int favoriteEmployees;
  final int departments;
  final int avgSalary;

  @override
  Widget build(BuildContext context) {
    return Container(
      width: double.infinity,
      padding: const EdgeInsets.all(20),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(20),
        gradient: const LinearGradient(
          colors: [
            Color(0xFF1E60A4),
            Color(0xFF0B3D70),
          ],
          begin: Alignment.topLeft,
          end: Alignment.bottomRight,
        ),
        boxShadow: [
          BoxShadow(
            color: Colors.black.withValues(alpha: 0.15),
            blurRadius: 10,
            offset: const Offset(0, 5),
          ),
        ],
      ),
      child: Row(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Expanded(
            flex: 3,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              mainAxisSize: MainAxisSize.min,
              children: [
                const Text(
                  "Company Overview",
                  style: TextStyle(
                    color: Colors.white,
                    fontSize: 25,
                    fontWeight: FontWeight.bold,
                  ),
                ),
                Text(
                  "HR summary and employee insights",
                  style: TextStyle(
                    color: Colors.white.withValues(alpha: 0.8),
                    fontSize: 15,
                  ),
                ),
                const SizedBox(height: 16),
                CompanyOverviewInfoRow(
                  icon: Icons.percent,
                  text: "Total Employees: $totalEmployee",
                ),
                const SizedBox(height: 12),
                CompanyOverviewInfoRow(
                  icon: Icons.favorite,
                  text: "Favorite Employees: $favoriteEmployees",
                ),
                const SizedBox(height: 12),
                CompanyOverviewInfoRow(
                  icon: Icons.domain,
                  text: "Departments: $departments",
                ),
                const SizedBox(height: 12),
                CompanyOverviewInfoRow(
                  icon: Icons.account_balance_wallet,
                  text: "Average Salary: $avgSalary EGP",
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
