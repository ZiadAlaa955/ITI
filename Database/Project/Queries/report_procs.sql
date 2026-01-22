use DB_project

-----------Report that returns the students information according to Department No parameter.-----------

create proc Report_Get_Students_By_Track @TrackID int
as 
	select s.* from Student s, Track t
	where t.Track_ID = s.Track_ID and t.Track_ID = @TrackID

Report_Get_Students_By_Track @TrackID = 1
drop proc Report_Get_Students_By_Track

-----------Report that takes the student ID and returns the grades of the student in all courses. %-----------

create proc Report_Get_Student_Grades @StudentID int
as	
	select c.Course_ID, c.Course_Name , isnull(cast(sc.Grade as varchar(20)), 'Not graded yet') as Grade
	from Student_Course sc, Course c
	where c.Course_ID = sc.Crs_ID and sc.Student_ID = @StudentID

Report_Get_Student_Grades @StudentID = 1
drop proc Report_Get_Student_Grades

-----------Report that takes the instructor ID and returns the name of the courses that he teaches and the number of student per course.-----------

create proc Report_Get_Instructor_courses_AND_Count
@instructorID int
as
begin
    select c.Course_Name, count(sc.Student_ID)
    from instructor i join instructor_course ic
    on i.Ins_ID = ic.Ins_ID
    join course c
    on c.Course_ID = ic.Crs_ID
    left join student_course sc
    on sc.Crs_ID = c.Course_ID
    where i.Ins_ID = @instructorID
    group by c.Course_Name
end

Report_Get_Instructor_courses_AND_Count @instructorID = 1
drop proc Report_Get_Instructor_courses_AND_Count

-----------Report that takes course ID and returns its topics  -----------

create proc Report_get_Course_Topics
@courseID int
as
begin
    select c.Course_ID, t.Topic_Name
    from course c join topic t
    on c.course_ID = t.course_ID
    where c.Course_ID = @courseID
end

Report_get_Course_Topics @courseID = 1
drop proc Report_get_Course_Topics

-----------Report that takes exam number and returns the Questions in it and choices [freeform report]-----------

create proc Report_Get_Exam_Questions @ExamID int
as
	select q.Q_Description,q.Q_Type,q.Mark, string_agg(qa.Q_Ans_Option, ' | ') as Options
    from Exam_Question eq, Question q , Question_Answer_Options qa
    where eq.Question_ID = q.Question_ID and q.Question_ID = qa.Question_ID
    and eq.Exam_ID = @ExamID
    group by q.Q_Description, q.Q_Type, q.Mark

Report_Get_Exam_Questions @ExamID = 1
drop proc Report_Get_Exam_Questions

-----------Report that takes exam number and the student ID then returns the Questions in this exam with the student answers.-----------

create proc Report_Get_Students_Exam_Answers @ExamID int, @StudentID int
as
	select q.Q_Description,sa.Stud_Answer ,q.Model_Answer,sa.Grade, q.Mark
    from Student_Exam_Answer sa, Question q 
    where sa.Q_ID = q.Question_ID and sa.Exam_ID = @ExamID and sa.Student_ID = @StudentID

Report_Get_Students_Exam_Answers @ExamID = 1, @StudentID = 1
drop proc Report_Get_Students_Exam_Answers
