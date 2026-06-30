import 'package:assignment_d05/features/employees/data/models/employee_model.dart';
import 'package:path/path.dart';
import 'package:sqflite/sqflite.dart';

class DatabaseHelper {
  static final DatabaseHelper instance = DatabaseHelper._init();
  static Database? _database;

  DatabaseHelper._init();

  Future<void> _createDB(Database db, int version) async {
    await db.execute('''
  CREATE TABLE employees(
        id INTEGER PRIMARY KEY AUTOINCREMENT, 
        name TEXT NOT NULL, 
        jobTitle TEXT NOT NULL,
        image TEXT NOT NULL, 
        department TEXT NOT NULL, 
        weeklyHours INTEGER NOT NULL,
        salary REAL NOT NULL, 
        isFavorite INTEGER NOT NULL
      )
''');
  }

  Future<Database> _initDB(String filepath) async {
    final databasePath = await getDatabasesPath();
    final path = join(databasePath, filepath);
    return await openDatabase(
      path,
      version: 1,
      onCreate: _createDB,
    );
  }

  Future<Database> get database async {
    if (_database != null) return _database!;
    _database = await _initDB("employees.db");
    return _database!;
  }

  Future<int> insertEmployee(EmployeeModel employee) async {
    final db = await instance.database;
    final map = employee.toMap();
    return await db.insert(
      'employees',
      map,
      conflictAlgorithm: ConflictAlgorithm.replace,
    );
  }

  Future<List<EmployeeModel>> getEmployees() async {
    final db = await instance.database;
    final maps = await db.query("employees");
    return maps.map((map) => EmployeeModel.fromMap(map)).toList();
  }

  Future<int> updateEmployee(EmployeeModel employee) async {
    final db = await instance.database;
    return await db.update(
      'employees',
      employee.toMap(),
      where: "id = ?",
      whereArgs: [employee.id],
    );
  }

  Future<int> deleteEmployee(int id) async {
    final db = await instance.database;
    return await db.delete(
      'employees',
      where: "id = ?",
      whereArgs: [id],
    );
  }
}
