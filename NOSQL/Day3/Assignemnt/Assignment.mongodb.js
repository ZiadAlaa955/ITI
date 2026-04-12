// Create new database named: FacultySystemV2
use("FacultySystemV2");

// • Create student collection that has (FirstName, lastName, IsFired, FacultyID, array of objects, each object has CourseID, grade).
db.student.insertMany([
  {
    FirstName: "Ahmed",
    lastName: "Ali",
    IsFired: false,
    FacultyID: 1,
    courses: [
      { CourseID: 1, grade: 85 },
      { CourseID: 2, grade: 90 },
    ],
  },
  {
    FirstName: "Sara",
    lastName: "Hassan",
    IsFired: true,
    FacultyID: 2,
    courses: [{ CourseID: 1, grade: 45 }],
  },
]);

// • Create Faculty collection that has (Faculty Name, Address).
db.Faculty.insertMany([
  { _id: 1, FacultyName: "Engineering", Address: "Building A" },
  { _id: 2, FacultyName: "Computer Science", Address: "Building B" },
]);

// • Create Course collection, which has (Course Name, Final Mark).
db.Course.insertMany([
  { _id: 1, CourseName: "Database", "Final Mark": 100 },
  { _id: 2, CourseName: "NoSql", "Final Mark": 150 },
]);

db.student.find();
db.Course.find();
db.Faculty.find();

//2. Display each student Full Name along with his average grade in all courses. $concat
db.student.aggregate([
  {
    $project: {
      _id: 0,
      FullName: { $concat: ["$FirstName", " ", "$lastName"] },
      AverageGrade: { $avg: "$courses.grade" },
    },
  },
]);

//3. Using aggregation display the sum of final mark for all courses in Course collection.
db.Course.aggregate([
  {
    $group: {
      _id: null,
      FinalMarksSum: {
        $sum: "$Final Mark",
      },
    },
  },
  {
    $project: {
      _id: 0,
      FinalMarksSum: 1,
    },
  },
]);

//4. Implement (one to many) relation between Student and Course, by adding array of Courses IDs in the student object.
db.student.updateMany({}, [
  {
    $set: {
      CourseIDs: "$courses.CourseID",
    },
  },
]);

// /• Select specific student with his name, and then display his courses.
db.student.aggregate([
  {
    $match: {
      FirstName: "Ahmed",
    },
  },
  {
    $lookup: {
      from: "Course",
      localField: "CourseIDs",
      foreignField: "_id",
      as: "CoursesList",
    },
  },
  {
    $project: {
      _id: 0,
      FirstName: 1,
      lastName: 1,
      CoursesList: 1,
    },
  },
]);

//4.Implement relation between Student and faculty by adding the faculty object in the student using _id Relation using $Lookup.
db.student.aggregate([
  {
    $lookup: {
      from: "Faculty",
      localField: "FacultyID",
      foreignField: "_id",
      as: "FacultyData",
    },
  },
  {
    $unwind: "$FacultyData",
  },
]);

// • Select specific student with his name, and then display his faculty
db.student.aggregate([
  {
    $match: {
      FirstName: "Ahmed",
    },
  },
  {
    $lookup: {
      from: "Faculty",
      localField: "FacultyID",
      foreignField: "_id",
      as: "FacultyData",
    },
  },
  {
    $unwind: "$FacultyData",
  },
  {
    $project: {
      _id: 0,
      FirstName: 1,
      lastName: 1,
      FacultyData: 1,
    },
  },
]);
