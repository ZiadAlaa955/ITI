import 'package:assignment_d05/features/employees/data/models/employee_model.dart';
import 'package:assignment_d05/features/employees/presentation/pages/add_edit_employee_page.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

class EmployeeCard extends StatefulWidget {
  const EmployeeCard({
    super.key,
    required this.employee,
    required this.onUpdate,
    required this.onDelete,
  });

  final EmployeeModel employee;
  final void Function(EmployeeModel) onUpdate;
  final void Function(EmployeeModel) onDelete;

  @override
  State<EmployeeCard> createState() => _EmployeeCardState();
}

class _EmployeeCardState extends State<EmployeeCard> {
  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onLongPress: () {
        showDialog(
          context: context,
          builder: (context) {
            return AlertDialog(
              title: Text("Delete ${widget.employee.name} ?"),
              content: const SingleChildScrollView(
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    Text(
                      "This action can't be undone.",
                    ),
                  ],
                ),
              ),
              actions: [
                TextButton(
                  child: const Text('Cancel'),
                  onPressed: () {
                    Navigator.of(context).pop(false);
                  },
                ),
                TextButton(
                  child: const Text(
                    'Delete',
                    style: TextStyle(color: Colors.red),
                  ),
                  onPressed: () {
                    widget.onDelete(widget.employee);
                    Navigator.of(context).pop(true);
                  },
                ),
              ],
            );
          },
        );
      },
      onTap: () async {
        final updatedEmployee = await Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) {
              return AddEditEmployeePage(
                appBarTitle: 'Edit Employee',
                employeeToEdit: widget.employee,
              );
            },
          ),
        );
        if (updatedEmployee != null && updatedEmployee is EmployeeModel) {
          widget.onUpdate(updatedEmployee);
        }
      },
      child: Card(
        color: Theme.of(context).colorScheme.surface,
        clipBehavior: Clip.antiAlias,
        child: Container(
          decoration: BoxDecoration(
            border: Border(
              left: BorderSide(
                color: widget.employee.departmentColor,
                width: 4,
              ),
            ),
          ),
          child: ListTile(
            leading: CircleAvatar(
              radius: 24,
              backgroundImage: NetworkImage(widget.employee.image),
            ),
            title: Text(
              widget.employee.name,
              style: const TextStyle(
                fontWeight: FontWeight.w500,
              ),
            ),
            subtitle: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  "${widget.employee.jobTitle} • ${widget.employee.department}",
                  style: const TextStyle(
                    fontWeight: FontWeight.w500,
                    fontSize: 12,
                  ),
                ),
                Text(
                  "${NumberFormat('#,##0.##').format(widget.employee.salary)} EGP",
                  style: const TextStyle(
                    fontWeight: FontWeight.w500,
                    color: Color(0xff016D83),
                  ),
                ),
              ],
            ),
            trailing: IconButton(
              onPressed: () {
                setState(() {
                  widget.employee.isFavorite = !widget.employee.isFavorite;
                });
              },
              icon: widget.employee.isFavorite
                  ? const Icon(
                      Icons.favorite,
                      color: Color(0xffE54659),
                    )
                  : const Icon(
                      Icons.favorite_border,
                      color: Colors.grey,
                    ),
              tooltip: widget.employee.isFavorite
                  ? "Mark as inactive"
                  : "Mark as active",
              iconSize: 33,
            ),
          ),
        ),
      ),
    );
  }
}
