-------------ExamAnswers: when submit answer or navigate to the next question
create proc Submit_Exam_Answers
@studentID int, @examID int, @questionID int, @studentAnswer varchar(200)
as
begin
	if exists (select * from Student_Exam_Answer where Student_ID = @studentID AND Exam_ID = @examID AND Q_ID = @questionID)
	begin
		update Student_Exam_Answer
		set Stud_Answer = @studentAnswer
		where Student_ID = @studentID AND Exam_ID = @examID AND Q_ID = @questionID
	end
	else
	begin
		insert into Student_Exam_Answer (Student_ID, Exam_ID, Q_ID, Stud_Answer, grade)
		values (@studentID, @examID, @questionID, @studentAnswer, NULL)
	end
end

--ExamCorrection: when finish exam
create proc Correct_Exam
@studentID int, @examID int
as
begin
	declare @totalScore int
	
	select @totalScore = sum(Q.Mark)
	from Student_Exam_Answer sea join question q
	on sea.Q_ID = q.Question_ID
	where sea.Student_ID = @studentID AND sea.Exam_ID = @examID AND sea.Stud_Answer = q.Model_Answer

	declare @courseID int
	select @courseID = crs_ID 
	from exam 
	where exam_ID = @examID

	update Student_Course
	set grade = isNULL(@totalScore, 0)
	where Student_ID = @studentID AND Crs_ID = @courseID

	select @totalScore as Score
end

-----------Generate_Exam-----------
create proc Generate_Exam @CrsName varchar(50), @ExamDuration int, @NoOfMCQs int, @NoOfTFs int,
@ExamID int output

as 
    declare @CrsID int
    select @CrsID = c.Course_ID from Course c
    where c.Course_Name = @CrsName

    if @CrsID is null
    begin
        select 'Error course not found' as errorMessage
        return
    end

    insert into Exam (Exam_Duration_mins, Crs_ID) 
    values (@ExamDuration, @CrsID)

    set @ExamID = SCOPE_IDENTITY()

    insert into Exam_Question(Exam_ID,Question_ID)
    select top(@NoOfMCQs) @ExamID, q.Question_ID
    from Question q
    where q.Crs_ID = @CrsID and q.Q_Type = 'MCQ'
    order by NEWID()

    insert into Exam_Question(Exam_ID,Question_ID)
    select top(@NoOfMCQs) @ExamID, q.Question_ID
    from Question q
    where q.Crs_ID = @CrsID and q.Q_Type = 'TF'
    order by NEWID()

declare @ExamID
Generate_Exam @CrsName = "C++ Programming", @ExamDuration = 60 , @NoOfMCQs = 3 ,@NoOfTFs = 3 , @ExamID = @ExamID output
drop proc Generate_Exam