import 'package:assignment_d05/core/theme/theme_cubit.dart';
import 'package:assignment_d05/features/employees/presentation/cubit/employee_cubit.dart';
import 'package:assignment_d05/features/employees/presentation/cubit/employee_state.dart';
import 'package:assignment_d05/features/employees/presentation/widgets/filters_card.dart';
import 'package:assignment_d05/features/employees/presentation/widgets/employee_card.dart';
import 'package:assignment_d05/features/employees/presentation/widgets/not_found_message.dart';
import 'package:assignment_d05/features/employees/presentation/widgets/sort_item.dart';
import 'package:assignment_d05/features/employees/data/models/employee_model.dart';
import 'package:assignment_d05/features/employees/presentation/pages/add_edit_employee_page.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class EmployeeDirectoryPage extends StatefulWidget {
  const EmployeeDirectoryPage({super.key});

  @override
  State<EmployeeDirectoryPage> createState() => _EmployeeDirectoryPageState();
}

class _EmployeeDirectoryPageState extends State<EmployeeDirectoryPage> {
  final TextEditingController _searchControler = TextEditingController();
  bool _showFavoritesOnly = false;
  String searchQuery = "";
  String selectedDepartment = "";
  String selectedSortedOption = "name";

  @override
  void initState() {
    super.initState();
    _searchControler.addListener(_updateSearchQuery);
  }

  void _updateSearchQuery() {
    setState(() {
      searchQuery = _searchControler.text;
    });
  }

  List<EmployeeModel> _getFilteredEmployees(
    List<EmployeeModel> employees,
  ) {
    final normalizedQuery = searchQuery.trim().toLowerCase();

    final filteredList = employees.where((employee) {
      final matchesSearch =
          normalizedQuery.isEmpty ||
          employee.name.toLowerCase().contains(
            normalizedQuery,
          ) ||
          employee.jobTitle.toLowerCase().contains(
            normalizedQuery,
          ) ||
          employee.department.toLowerCase().contains(
            normalizedQuery,
          );

      final matchesFavorite = !_showFavoritesOnly || employee.isFavorite;

      final matchesDept =
          selectedDepartment.isEmpty ||
          employee.department.toLowerCase() == selectedDepartment.toLowerCase();

      return matchesSearch && matchesFavorite && matchesDept;
    }).toList();

    filteredList.sort((a, b) {
      if (selectedSortedOption == "salary") {
        return a.salary.compareTo(b.salary);
      } else if (selectedSortedOption == "job title") {
        return a.jobTitle.compareTo(b.jobTitle);
      } else {
        return a.name.compareTo(b.name);
      }
    });

    return filteredList;
  }

  void clearFilters() {
    _searchControler.clear();

    setState(() {
      _showFavoritesOnly = false;
      searchQuery = "";
      selectedDepartment = "";
    });
  }

  @override
  void dispose() {
    _searchControler.dispose();

    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        actions: [
          const Icon(
            Icons.wb_sunny_sharp,
            color: Colors.white,
          ),
          BlocBuilder<ThemeCubit, bool>(
            builder: (context, isDark) {
              return Switch(
                value: isDark,
                onChanged: (value) {
                  context.read<ThemeCubit>().toggleTheme(value);
                },
                trackOutlineColor: const WidgetStatePropertyAll(
                  Colors.transparent,
                ),
              );
            },
          ),
          const Icon(
            Icons.dark_mode_outlined,
            color: Colors.white,
          ),
          const SizedBox(width: 20),
          IconButton(
            onPressed: () {
              showModalBottomSheet(
                context: context,
                builder: (context) {
                  return SizedBox(
                    height: 250,
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        SortItem(
                          icon: Icons.sort_by_alpha,
                          title: 'Sort by name',
                          bgColor: selectedSortedOption == "name"
                              ? const Color(0xff037088)
                              : const Color(0xffD5EAED),
                          iconColor: selectedSortedOption == "name"
                              ? Colors.white
                              : const Color(0xff2E90A2),
                          onTap: () {
                            setState(() {
                              selectedSortedOption = "name";
                              Navigator.pop(context);
                            });
                          },
                        ),
                        const Divider(),
                        SortItem(
                          icon: Icons.payment,
                          title: 'Sort by salary',
                          bgColor: selectedSortedOption == "salary"
                              ? const Color(0xff037088)
                              : const Color(0xffD5EAED),
                          iconColor: selectedSortedOption == "salary"
                              ? Colors.white
                              : const Color(0xff2E90A2),
                          onTap: () {
                            setState(() {
                              selectedSortedOption = "salary";
                              Navigator.pop(context);
                            });
                          },
                        ),
                        const Divider(),
                        SortItem(
                          icon: Icons.business_center,
                          title: 'Sort by job title',
                          bgColor: selectedSortedOption == "job title"
                              ? const Color(0xff037088)
                              : const Color(0xffD5EAED),
                          iconColor: selectedSortedOption == "job title"
                              ? Colors.white
                              : const Color(0xff2E90A2),
                          onTap: () {
                            setState(() {
                              selectedSortedOption = "job title";
                              Navigator.pop(context);
                            });
                          },
                        ),
                      ],
                    ),
                  );
                },
              );
            },
            icon: const Icon(Icons.sort),
            color: Colors.white,
            iconSize: 30,
          ),
        ],
        backgroundColor: const Color(0xff0D7A8F),
        title: const Text(
          "Employees",
          style: TextStyle(
            fontWeight: FontWeight.bold,
            fontSize: 22,
            color: Colors.white,
          ),
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () async {
          final newEmployee = await Navigator.push(
            context,
            MaterialPageRoute(
              builder: (context) => const AddEditEmployeePage(
                appBarTitle: 'Add New Employee',
              ),
            ),
          );

          if (newEmployee != null && newEmployee is EmployeeModel) {
            context.read<EmployeeCubit>().addEmployee(newEmployee);

            ScaffoldMessenger.of(context).showSnackBar(
              SnackBar(
                content: Text("${newEmployee.name} added"),
                backgroundColor: Colors.green,
                behavior: SnackBarBehavior.floating,
              ),
            );
          }
        },
        backgroundColor: const Color(0xff007A8F),
        shape: const CircleBorder(),
        child: const Icon(
          Icons.add,
          color: Colors.white,
          size: 28,
        ),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            FiltersCard(
              searchControler: _searchControler,
              selectedDepartment: selectedDepartment,
              showFavoritesOnly: _showFavoritesOnly,
              onDepartmentChanged: (String value) {
                setState(() {
                  selectedDepartment = value;
                });
              },
              onFavoritesChanged: (bool value) {
                setState(() {
                  _showFavoritesOnly = value;
                });
              },
              clearFilters: clearFilters,
            ),
            const Padding(
              padding: EdgeInsets.symmetric(vertical: 8),
              child: Text(
                "Employees",
                style: TextStyle(
                  fontWeight: FontWeight.w600,
                  fontSize: 22,
                ),
              ),
            ),
            BlocBuilder<EmployeeCubit, EmployeeState>(
              builder: (context, state) {
                if (state is EmployeeLoading) {
                  return const Center(child: CircularProgressIndicator());
                } else if (state is EmployeeError) {
                  return Center(child: Text(state.message));
                } else if (state is EmployeeLoaded) {
                  final filteredEmployees = _getFilteredEmployees(
                    state.employees,
                  );
                  return Expanded(
                    child: filteredEmployees.isEmpty
                        ? SingleChildScrollView(
                            child: Padding(
                              padding: const EdgeInsets.only(top: 32),
                              child: NotFoundMessage(
                                onPressed: () {
                                  clearFilters();
                                },
                              ),
                            ),
                          )
                        : ListView.builder(
                            padding: const EdgeInsets.only(bottom: 80),
                            itemCount: filteredEmployees.length,
                            itemBuilder: (context, index) {
                              return EmployeeCard(
                                employee: filteredEmployees[index],
                                onUpdate: (EmployeeModel updatedEmployee) async {
                                  context.read<EmployeeCubit>().updateEmployee(
                                    updatedEmployee,
                                  );

                                  ScaffoldMessenger.of(context).showSnackBar(
                                    SnackBar(
                                      content: Text(
                                        "${updatedEmployee.name} updated successfully",
                                      ),
                                      backgroundColor: Colors.green,
                                      behavior: SnackBarBehavior.floating,
                                    ),
                                  );
                                },
                                onDelete:
                                    (EmployeeModel deletedEmployee) async {
                                      context
                                          .read<EmployeeCubit>()
                                          .deleteEmployee(
                                            deletedEmployee.id,
                                          );

                                      ScaffoldMessenger.of(
                                        context,
                                      ).showSnackBar(
                                        SnackBar(
                                          content: Text(
                                            "${deletedEmployee.name} deleted",
                                          ),
                                          backgroundColor: Colors.red,
                                          behavior: SnackBarBehavior.floating,
                                        ),
                                      );
                                    },
                              );
                            },
                          ),
                  );
                }
                return const SizedBox();
              },
            ),
          ],
        ),
      ),
    );
  }
}
