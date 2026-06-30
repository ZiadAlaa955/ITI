import 'package:flutter/material.dart';

class EmployeeModel {
  final int id;
  final String name;
  final String jobTitle;
  final String image;
  final String department;
  final double salary;
  final int weeklyHours;
  bool isFavorite;

  EmployeeModel({
    required this.name,
    required this.jobTitle,
    required this.image,
    required this.isFavorite,
    required this.department,
    required this.salary,
    required this.weeklyHours,
    required this.id,
  });

  Color get departmentColor {
    switch (department) {
      case "Engineering":
        return const Color(0xff3A5A78);
      case "Design":
        return const Color(0xff8A5A6D);
      case "HR":
        return const Color(0xffC99B78);
      case "Marketing":
        return const Color(0xff5B7A66);
      case "Sales":
        return const Color(0xffA86F54);
      default:
        return Colors.grey;
    }
  }

  EmployeeModel copyWith({
    int? id,
    String? name,
    String? jobTitle,
    String? image,
    String? department,
    double? salary,
    int? weeklyHours,
    bool? isFavorite,
  }) {
    return EmployeeModel(
      name: name ?? this.name,
      jobTitle: jobTitle ?? this.jobTitle,
      image: image ?? this.image,
      isFavorite: isFavorite ?? this.isFavorite,
      department: department ?? this.department,
      salary: salary ?? this.salary,
      weeklyHours: weeklyHours ?? this.weeklyHours,
      id: id ?? this.id,
    );
  }

  Map<String, Object?> toMap() {
    return {
      'id': id,
      'name': name,
      'jobTitle': jobTitle,
      'image': image,
      'department': department,
      'salary': salary,
      'weeklyHours': weeklyHours,
      'isFavorite': isFavorite ? 1 : 0,
    };
  }

  factory EmployeeModel.fromMap(Map<String, dynamic> map) {
    return EmployeeModel(
      id: map['id'] as int? ?? 0,
      name: map['name']?.toString() ?? 'Unknown Name',
      jobTitle: map['jobTitle']?.toString() ?? 'Unknown Title',
      image: map['image']?.toString() ?? '',
      department: map['department']?.toString() ?? 'Engineering',
      salary: double.tryParse(map['salary']?.toString() ?? '0') ?? 0.0,
      weeklyHours: int.tryParse(map['weeklyHours']?.toString() ?? '0') ?? 0,
      isFavorite: map['isFavorite'] == 1 || map['isFavorite'] == true,
    );
  }
}
