import 'package:assignment_d04/components/buttons/clear_filters_button.dart';
import 'package:assignment_d04/components/cards/employee_card.dart';
import 'package:assignment_d04/components/not_found_message.dart';
import 'package:assignment_d04/components/input_fields/search_employees_textfield.dart';
import 'package:assignment_d04/components/buttons/toggle_active_button.dart';
import 'package:assignment_d04/models/employee_model.dart';
import 'package:assignment_d04/pages/add_employee_page.dart';
import 'package:flutter/material.dart';
import 'package:assignment_d04/components/filters/custom_filter_chip.dart';

class EmployeeDirectoryPage extends StatefulWidget {
  const EmployeeDirectoryPage({super.key});

  @override
  State<EmployeeDirectoryPage> createState() => _EmployeeDirectoryPageState();
}

class _EmployeeDirectoryPageState extends State<EmployeeDirectoryPage> {
  final List<EmployeeModel> employees = [
    EmployeeModel(
      name: "Sarah Chen",
      role: "Project Manager",
      image: "https://randomuser.me/api/portraits/women/44.jpg",
      isActive: true,
      level: "Senior",
    ),
    EmployeeModel(
      name: "Alex Ramirez",
      role: "Software Engineer",
      image: "https://randomuser.me/api/portraits/men/32.jpg",
      isActive: false,
      level: "Mid_Level",
    ),
    EmployeeModel(
      name: "Sumar Chen",
      role: "Software Engineer",
      image: "https://randomuser.me/api/portraits/men/46.jpg",
      isActive: true,
      level: "Junior",
    ),
    EmployeeModel(
      name: "Emily Davis",
      role: "UX Designer",
      image: "https://randomuser.me/api/portraits/women/68.jpg",
      isActive: false,
      level: "Mid_Level",
    ),
    EmployeeModel(
      name: "Marcus Johnson",
      role: "Quality Assurance",
      image: "https://randomuser.me/api/portraits/men/22.jpg",
      isActive: false,
      level: "Junior",
    ),
    EmployeeModel(
      name: "Priya Patel",
      role: "Product Owner",
      image: "https://randomuser.me/api/portraits/women/31.jpg",
      isActive: true,
      level: "Senior",
    ),
    EmployeeModel(
      name: "David Kim",
      role: "Data Scientist",
      image: "https://randomuser.me/api/portraits/men/67.jpg",
      isActive: false,
      level: "Mid_Level",
    ),
    EmployeeModel(
      name: "Jessica Taylor",
      role: "HR Specialist",
      image: "https://randomuser.me/api/portraits/women/12.jpg",
      isActive: false,
      level: "Junior",
    ),
    EmployeeModel(
      name: "Michael Brown",
      role: "DevOps Engineer",
      image: "https://randomuser.me/api/portraits/men/85.jpg",
      isActive: true,
      level: "Senior",
    ),
    EmployeeModel(
      name: "Lisa Wong",
      role: "Marketing Manager",
      image: "https://randomuser.me/api/portraits/women/24.jpg",
      isActive: false,
      level: "Mid_Level",
    ),
  ];
  final TextEditingController _searchControler = TextEditingController();
  bool _showActiveOnly = false;
  String searchQuery = "";
  String selectedLevel = "";

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

  List<EmployeeModel> get _filteredEmployees {
    final normalizedQuery = searchQuery.trim().toLowerCase();

    return employees.where((employee) {
      final matchesSearch =
          employee.name.toLowerCase().contains(normalizedQuery) ||
          normalizedQuery.isEmpty;

      final matchesAvailable = !_showActiveOnly || employee.isActive;

      final matchesLevel =
          selectedLevel.isEmpty ||
          employee.level.toLowerCase() == selectedLevel.toLowerCase();

      return matchesSearch && matchesAvailable && matchesLevel;
    }).toList();
  }

  void clearFilters() {
    _searchControler.clear();

    setState(() {
      _showActiveOnly = false;
      searchQuery = "";
      selectedLevel = "";
    });
  }

  @override
  void dispose() {
    _searchControler.dispose();

    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final filteredEmployees = _filteredEmployees;
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Color(0xff0D7A8F),
        centerTitle: true,
        title: Text(
          "Employee Directory",
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
              builder: (context) => AddEmployeePage(),
            ),
          );
          if (newEmployee != null && newEmployee is EmployeeModel) {
            setState(() {
              employees.add(newEmployee);
            });

            if (!mounted) return;

            ScaffoldMessenger.of(context).showSnackBar(
              SnackBar(
                content: Text("${newEmployee.name} added"),
                backgroundColor: Colors.green,
              ),
            );
          }
        },
        backgroundColor: Color(0xff007A8F),
        shape: CircleBorder(),
        child: const Icon(
          Icons.add,
          color: Colors.white,
          size: 28,
        ),
      ),
      body: Padding(
        padding: EdgeInsets.all(16),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            SearchEmployeesTextField(
              controller: _searchControler,
            ),
            Row(
              children: [
                CustomFilterChip(
                  title: "Junior",
                  isSelected: selectedLevel.toLowerCase() == "junior",
                  onTap: () {
                    setState(() {
                      selectedLevel = selectedLevel.toLowerCase() == "junior"
                          ? ""
                          : "Junior";
                    });
                  },
                ),
                CustomFilterChip(
                  title: "Mid_Level",
                  isSelected: selectedLevel.toLowerCase() == "mid_level",
                  onTap: () {
                    setState(() {
                      selectedLevel = selectedLevel.toLowerCase() == "mid_level"
                          ? ""
                          : "Mid_Level";
                    });
                  },
                ),
                CustomFilterChip(
                  title: "Senior",
                  isSelected: selectedLevel.toLowerCase() == "senior",
                  onTap: () {
                    setState(() {
                      selectedLevel = selectedLevel.toLowerCase() == "senior"
                          ? ""
                          : "Senior";
                    });
                  },
                ),
              ],
            ),
            Row(
              children: [
                ToggleAactiveButton(
                  value: _showActiveOnly,
                  onChanged: (value) {
                    setState(() {
                      _showActiveOnly = value;
                    });
                  },
                ),
                Spacer(),
                ClearFiltersButton(
                  onPressed: () {
                    clearFilters();
                  },
                ),
              ],
            ),
            Divider(
              indent: 10,
              endIndent: 10,
              thickness: 1.2,
            ),
            Padding(
              padding: const EdgeInsets.symmetric(vertical: 8),
              child: Text(
                "Employees",
                style: TextStyle(
                  fontWeight: FontWeight.w600,
                  fontSize: 22,
                ),
              ),
            ),
            Expanded(
              child: filteredEmployees.isEmpty
                  ? NotFoundMessage(
                      onPressed: () {
                        clearFilters();
                      },
                    )
                  : ListView.builder(
                      itemCount: filteredEmployees.length,
                      itemBuilder: (context, index) {
                        return EmployeeCard(
                          employee: filteredEmployees[index],
                        );
                      },
                    ),
            ),
          ],
        ),
      ),
    );
  }
}
