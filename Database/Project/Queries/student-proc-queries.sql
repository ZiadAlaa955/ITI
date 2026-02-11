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
	if exists(select * from track where Track_Name = @trackName)
	begin
		select 'Error: a track with this name already exists'as errorMessage
	end
	else
	begin
		insert into track (Track_Name, MaxNoStudents)
		values(@trackName, @maxNoStudents)
	end
end

create proc update_track
@trackID int, @trackName varchar(50), @MaxNoStudents int
as
begin
	if not exists(select * from track where Track_ID = @trackID)
	begin
		select'Error: track ID not found' as errorMessage
	end
	else
	begin
		update track 
		set Track_Name = @trackName,MaxNoStudents = @MaxNoStudents
		where Track_ID = @trackID
	end
end

create proc delete_track
	@trackID int
as
begin
	if not exists(select * from Track where Track_ID = @trackID)
	begin
		select 'Error: Track ID not found.' AS ErrorMessage
	end
	else
	begin
		begin try
			delete from track 
			where Track_ID = @trackID
		end try
		begin catch
		select 'Error: cannot delete track because it has students or instructors assigned to it' as messageError
		end catch
	end
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
	if not exists(select * from track where Track_ID = @trackID)
	begin
		select 'Error: The provided Track ID does not exist.' AS ErrorMessage
	end
	else
	begin
		insert into student (Student_Name, Phone_Number, City, street, Track_ID)
	values(@studentName, @phoneNumber, @city, @street, @trackID)
	end
end

create proc update_student
@studentName varchar(50), @phoneNumber varchar(15), @city varchar(50), @street varchar(50), @trackID int, @studentID int
as
begin
	if not exists(select * from student where Student_ID = @studentID)
	begin
		select 'Error: Student ID not found.' AS ErrorMessage
	end
	else if not exists(select * from Track where Track_ID = @trackID)
    begin
        select 'Error: The new Track ID does not exist.' AS ErrorMessage
    end
	else
	begin
		update student 
		set 
		Student_Name = @studentName, Phone_Number = @phoneNumber, City = @city, Street = @street, Track_ID = @trackID
		where Student_ID = @studentID
	end
end

create proc delete_student
@studentID int
as
begin
	if not exists(select * from student where Student_ID = @studentID)
	begin
		select 'Error: Student ID not found.' AS ErrorMessage
		return
	end
	else
	begin
		begin try
			delete from student 
			where Student_ID = @studentID
		end try
		begin catch
			select 'Error: cannot delete this student because he/she has an exam' as errorMessage
		end catch
	end
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
	if not exists(select * from track where Track_ID = @trackID)
	begin
		select 'Error: Track ID does not exist.' AS ErrorMessage
	end
	else 
	begin
		insert into course (Course_Name, Track_ID)
		values (@courseName, @trackID)
	end
end

create proc update_course
@courseID int, @courseName varchar(50), @trackID int 
as
begin
	if not exists(select * from Course where Course_ID = @courseID)
        select 'Error: Course ID not found.' AS ErrorMessage
    else if not exists(select * from Track where Track_ID = @trackID)
        select 'Error: Track ID does not exist.' AS ErrorMessage
    else
    begin
		update course
		set Course_Name = @courseName, Track_ID = @trackID
		where Course_ID = @courseID
	end
end

create proc delete_course
@courseID int
as
begin
	if not exists(select * from Course where Course_ID = @courseID)
    begin
        select 'Error: Course ID not found.' AS ErrorMessage
        return
    end
	else
		begin
		begin try
			delete from course
			where Course_ID = @courseID
		end try
		begin catch
			select 'Error; cannot delete this course because it has students enrollments or has topics or questions' as errorMessage
		end catch
	end
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
	if not exists(select * from Course where Course_ID = @courseID)
    begin
        select 'Error: Course ID does not exist.' AS ErrorMessage
    end
    else
    begin
		insert into topic (Topic_Name, Course_ID)
		values (@topicName, @courseID)
	end
end

create proc update_topic
@oldTopicName varchar(50), @newTopicName varchar(50), @courseID int
as
begin
	if not exists(select * from Topic where Topic_Name = @oldTopicName AND Course_ID = @courseID)
    begin
        select 'Error: Topic not found for this course.' AS ErrorMessage
    end
    else
    begin
		update topic
		set Topic_Name = @newTopicName, Course_ID = @courseID
		where Topic_Name = @oldTopicName AND Course_ID = @courseID
	end
end

create proc delete_topic
@topicName varcHar(50), @courseID int
as
begin
	if not exists(select * from Topic where Topic_Name = @topicName AND Course_ID = @courseID)
    begin
        select 'Error: Topic not found.' AS ErrorMessage
    end
    else
    begin
		delete from Topic
		where Topic_Name =@topicName AND Course_ID = @courseID
	end
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
	if not exists(select * from Student where Student_ID = @studentID)
        select 'Error: Student ID not found.' AS ErrorMessage
    else if not exists(select * from Course where Course_ID = @courseID)
        select 'Error: Course ID not found.' AS ErrorMessage
    else if exists(select * from Student_Course where Student_ID = @studentID AND Crs_ID = @courseID)
        select 'Error: Student is already enrolled in this course.' AS ErrorMessage
    else
    begin
        insert into Student_Course (Student_ID, Crs_ID, Grade)
       values (@studentID, @courseID, NULL)
    end
end

create proc update_student_grade
@studentID int, @courseID int, @newGrade int
as
begin
	if not exists(select * from Student_Course where Student_ID = @studentID AND Crs_ID = @courseID)
    begin
        select 'Error: Student is not enrolled in this course.' AS ErrorMessage
    end
    else if @newGrade < 0 OR @newGrade > 100
    begin
        select 'Error: Grade must be between 0 and 100.' AS ErrorMessage
    end
    else
    begin
        update Student_Course
        set grade = @newGrade
        where Student_ID = @studentID AND Crs_ID = @courseID
    end
end

create proc delete_student_course
@studentID int, @courseID int
as
begin
	if not exists(select * from Student_Course where Student_ID = @studentID AND Crs_ID = @courseID)
    begin
        select 'Error: Enrollment record not found.' AS ErrorMessage
    end
    else
    begin
        delete from Student_Course
        where Student_ID = @studentID AND Crs_ID = @courseID
    end
end
