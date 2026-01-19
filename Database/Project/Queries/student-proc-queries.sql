--Track------------------------------
create proc select_all_tracks
as
begin
	select Track_ID, Track_Name, MaxNoStudents
	from track
end

create proc insert_track 
@trackName varchar(50), @maxNoStudents int
as
begin
	insert into track (Track_Name, MaxNoStudents)
	values(@trackName, @maxNoStudents)
end

create proc update_track
@trackID int, @trackName varchar(50), @MaxNoStudents int
as
begin
	update track 
	set Track_Name = @trackName,
	MaxNoStudents = @MaxNoStudents
	where Track_ID = @trackID
end

create proc delete_track
@trackID int
as
begin
	begin try
		delete from track 
		where Track_ID = @trackID
	end try
	begin catch
	select 'Error: cannot delete track because it has students or instructors assigned to it' as messageError
	end catch
end

--Student-------------------------------------
create proc select_all_students
as
begin
	select Student_ID, Student_Name, Phone_Number, City, Street, Track_ID
	from Student
end

create proc select_student_by_ID
@studentID int
as
begin
	select Student_ID, Student_Name, Phone_Number, City, Street, Track_ID
	from Student
	where Student_ID = @studentID
end

create proc insert_student
@studentName varchar(50), @phoneNumber varchar(15), @city varchar(50), @street varchar(50), @trackID int
as
begin
	insert into student (Student_Name, Phone_Number, City, street, Track_ID)
	values(@studentName, @phoneNumber, @city, @street, @trackID)
end

create proc update_student
@studentName varchar(50), @phoneNumber varchar(15), @city varchar(50), @street varchar(50), @trackID int, @studentID int
as
begin
	update student 
	set 
		Student_Name = @studentName, Phone_Number = @phoneNumber, City = @city, Street = @street, Track_ID = @trackID
		where Student_ID = @studentID
end

create proc delete_student
@studentID int
as
begin
	begin try
		delete from student 
		where Student_ID = @studentID
	end try
	begin catch
		select 'Error: cannot delete this student because he/she has an exam' as errorMessage
	end catch
end

--course------------------------------
create proc select_all_courses
as
begin
	select * from course
end

create proc select_course_by_ID
@courseID int
as
begin
	select * from Course
	where Course_ID = @courseID
end

create proc insert_course
@courseName varchar(50), @trackID int
as
begin
	insert into course (Course_Name, Track_ID)
	values (@courseName, @trackID)
end

create proc update_course
@courseID int, @courseName varchar(50), @trackID int 
as
begin
	update course
	set Course_Name = @courseName, Track_ID = @trackID
	where Course_ID = @courseID
end

create proc delete_course
@courseID int
as
begin
	begin try
		delete from course
		where Course_ID = @courseID
	end try
	begin catch
		select 'Error; cannot delete this course because it has students enrollments or has topics or questions' as errorMessage
	end catch
end

--topic------------------------------
create proc select_topics_by_course_ID
@courseID int
as
begin
	select * from topic
	where course_ID = @courseID
end

create proc insert_topic
@topicName varchar(50), @courseID int
as
begin
	insert into topic (Topic_Name, Course_ID)
	values (@topicName, @courseID)
end

create proc update_topic
@oldTopicName varchar(50), @newTopicName varchar(50), @courseID int
as
begin
	update topic
	set Topic_Name = @newTopicName, Course_ID = @courseID
	where Topic_Name = @oldTopicName AND Course_ID = @courseID
end

create proc delete_topic
@topicName varcHar(50), @courseID int
as
begin
	delete from Topic
	where Topic_Name =@topicName AND Course_ID = @courseID
end

--student course----------------------------
create proc select_courses_by_student_id
@studentID int
as
begin
	select  c.Course_Name, sc.Crs_ID, sc.Student_ID, sc.Grade
	from Student_Course sc join course c 
	on sc.Crs_ID = c.Course_ID
	where sc.Student_ID = @studentID
end

create proc select_student_by_course_ID
@courseID int
as
begin
	select s.Student_Name, sc.Student_ID, sc.Crs_ID, sc.Grade
	from Student_Course sc join Student s
	on sc.Student_ID = s.Student_ID
	where sc.Crs_ID = @courseID
end

create proc insert_student_course
@studentID int, @courseID int
as
begin
	insert into Student_Course (Student_ID, Crs_ID, Grade)
	values (@studentID, @courseID, NULL)
end

create proc update_student_grade
@studentID int, @courseID int, @newGrade int
as
begin
	update Student_Course
	set grade = @newGrade
	where Student_ID = @studentID AND Crs_ID = @courseID
end

create proc delete_student_course
@studentID int, @courseID int
as
begin
	delete from Student_Course
	where Student_ID = @studentID AND Crs_ID = @courseID
end
