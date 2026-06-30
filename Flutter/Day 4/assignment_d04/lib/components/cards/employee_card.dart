import 'package:assignment_d04/models/employee_model.dart';
import 'package:flutter/material.dart';

class EmployeeCard extends StatefulWidget {
  const EmployeeCard({
    super.key,
    required this.employee,
  });

  final EmployeeModel employee;

  @override
  State<EmployeeCard> createState() => _EmployeeCardState();
}

class _EmployeeCardState extends State<EmployeeCard> {
  @override
  Widget build(BuildContext context) {
    return Card(
      color: Colors.white,
      child: ListTile(
        leading: CircleAvatar(
          radius: 24,
          backgroundImage: NetworkImage(widget.employee.image),
        ),
        title: Text(
          widget.employee.name,
          style: TextStyle(
            fontWeight: FontWeight.w500,
          ),
        ),
        subtitle: Text(
          widget.employee.role,
          style: TextStyle(fontWeight: FontWeight.w500),
        ),
        trailing: IconButton(
          onPressed: () {
            setState(() {
              widget.employee.isActive = !widget.employee.isActive;
            });
          },
          icon: widget.employee.isActive
              ? Icon(
                  Icons.star,
                  color: Color(0xffE3A416),
                )
              : Icon(
                  Icons.star,
                  color: Colors.grey,
                ),
          tooltip: widget.employee.isActive
              ? "Mark as inactive"
              : "Mark as active",
          iconSize: 33,
        ),
      ),
    );
  }
}
