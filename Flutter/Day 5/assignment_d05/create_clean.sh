#!/usr/bin/env bash

# ======================================================
# Flutter Clean Architecture Structure Generator
# Tailored for Lab 5: Tech Company Staff Manager
# ======================================================

set -e

if [ ! -f "pubspec.yaml" ]; then
  echo "Error: pubspec.yaml not found."
  echo "Please run this script from your Flutter project root."
  exit 1
fi

echo "Creating Clean Architecture structure for Staff Manager..."

# ======================================================
# Main lib structure
# ======================================================

mkdir -p lib/core
mkdir -p lib/features

touch lib/main.dart

# ======================================================
# Core Layer (Shared across the app)
# ======================================================

mkdir -p lib/core/theme
mkdir -p lib/core/widgets
mkdir -p lib/core/utils
mkdir -p lib/core/errors

touch lib/core/theme/app_theme.dart
touch lib/core/widgets/custom_text_field.dart
touch lib/core/widgets/custom_button.dart
touch lib/core/errors/failures.dart
touch lib/core/errors/exceptions.dart

# ======================================================
# Features Layer
# ======================================================

# 1. Auth Feature (Login Screen)
mkdir -p lib/features/auth/presentation/pages
touch lib/features/auth/presentation/pages/login_screen.dart

# 2. Dashboard Feature
mkdir -p lib/features/dashboard/presentation/pages
mkdir -p lib/features/dashboard/presentation/widgets
touch lib/features/dashboard/presentation/pages/dashboard_screen.dart
touch lib/features/dashboard/presentation/widgets/statistics_card.dart

# 3. Employees Feature (The Core Feature)
mkdir -p lib/features/employees/data/datasources
mkdir -p lib/features/employees/data/models
mkdir -p lib/features/employees/data/repositories
mkdir -p lib/features/employees/domain/entities
mkdir -p lib/features/employees/domain/repositories
mkdir -p lib/features/employees/presentation/cubit
mkdir -p lib/features/employees/presentation/pages
mkdir -p lib/features/employees/presentation/widgets

# Domain
touch lib/features/employees/domain/entities/employee.dart
touch lib/features/employees/domain/repositories/employee_repository.dart

# Data
touch lib/features/employees/data/models/employee_model.dart
touch lib/features/employees/data/datasources/api_service.dart
touch lib/features/employees/data/datasources/database_helper.dart
touch lib/features/employees/data/repositories/employee_repository_impl.dart

# Presentation (Cubit & UI)
touch lib/features/employees/presentation/cubit/employee_cubit.dart
touch lib/features/employees/presentation/cubit/employee_state.dart
touch lib/features/employees/presentation/pages/employees_screen.dart
touch lib/features/employees/presentation/pages/employee_form_screen.dart
touch lib/features/employees/presentation/widgets/employee_card.dart
touch lib/features/employees/presentation/widgets/filter_chips.dart
touch lib/features/employees/presentation/widgets/sort_bottom_sheet.dart

# ======================================================
# Add required packages for Lab 5
# ======================================================

echo "Adding required packages (flutter_bloc, dio, sqflite, path)..."

flutter pub add flutter_bloc
flutter pub add dio
flutter pub add sqflite
flutter pub add path
flutter pub add equatable # Highly recommended for Cubit states

# ======================================================
# Finish
# ======================================================

echo "Structure created successfully!"