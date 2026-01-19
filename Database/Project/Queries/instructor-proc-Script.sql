use DB_project

-----------Instructor-----------

create proc Select_Instructors
as 
	select * from Instructor

Select_Instructors 
drop proc Select_Instructors

-----

create proc Select_Instructor_by_ID @InsID int
as 
	select i.* from Instructor i where i.Ins_ID=@InsID

Select_Instructor_by_ID @InsID=3
drop proc Select_Instructor_by_ID

-----

create proc Insert_Instructor @InsName varchar(50) ,@HiringDate date , @TrackID int
as 
	insert into Instructor (Ins_Name, Hiring_Date, Track_ID)
    values (@InsName, @HiringDate, @TrackID)
		
Insert_Instructor @InsName = "The Legend" , @HiringDate = '2024-08-15' ,@TrackID = 1
drop proc Insert_Instructor

-----

create proc Update_Instructor @InsID int, @InsName varchar(50) ,@HiringDate date , @TrackID int
as 
	update Instructor
	set Ins_Name = @InsName,
	Hiring_Date = @HiringDate,
    Track_ID = @TrackID
	where Ins_ID = @InsID

Update_Instructor @InsID=3, @InsName = "The Legend" , @HiringDate = '2024-08-15' ,@TrackID = 1
drop proc Update_Instructor

-----

create proc Delete_Instructor @InsID int
as 
	begin try
		delete from Instructor
		where Ins_ID = @InsID
	end try
	begin catch
		select 'Error cannot delete this instructor because it has assigned to courses or tracks' as errorMessage
	end catch

Delete_Instructor @InsID=3
drop proc Delete_Instructor

-----------Instructor_Course-----------

create proc Select_Instructor_Course
as 
	select i.*, c.* from Instructor_Course ic , Instructor i, Course c
	where i.Ins_ID = ic.Ins_ID and ic.Crs_ID = c.Course_ID

Select_Instructor_Course 
drop proc Select_Instructor_Course

-----

create proc Select_Instructor_Course_by_Ins_ID @InsID int
as 
	select i.*, c.* from Instructor_Course ic , Instructor i, Course c
	where i.Ins_ID = ic.Ins_ID and ic.Crs_ID = c.Course_ID
	and ic.Ins_ID = @InsID

Select_Instructor_Course_by_Ins_ID @InsID=3
drop proc Select_Instructor_Course_by_Ins_ID

-----

create proc Select_Instructor_Course_by_Crs_ID @CrsID int
as 
	select i.*, c.* from Instructor_Course ic , Instructor i, Course c
	where i.Ins_ID = ic.Ins_ID and ic.Crs_ID = c.Course_ID
	and ic.Crs_ID = @CrsID

Select_Instructor_Course_by_Crs_ID @CrsID=3
drop proc Select_Instructor_Course_by_Crs_ID

-----

create proc Insert_Instructor_Course @InsID int,@CrsID int
as 
	insert into Instructor_Course(Ins_ID,Crs_ID)
    values (@InsID, @CrsID)
		
Insert_Instructor_Course @InsID=4,@CrsID=4
drop proc Insert_Instructor_Course

-----

create proc Update_Ins_Instructor_Course @CrsID int,@OldInsID int,@NewInsID int
as 
	delete from Instructor_Course
    where Ins_ID = @OldInsID and Crs_ID = @CrsID

    insert into Instructor_Course (Ins_ID, Crs_ID)
    values (@NewInsID, @CrsID)

--	update Instructor_Course
--	set Ins_ID = @NewInsID
--	where Ins_ID= @OldInsID and Crs_ID = @CrsID

Update_Ins_Instructor_Course @CrsID = 3,@OldInsID = 3,@NewInsID = 3
drop proc Update_Ins_Instructor_Course

-----

-- create proc Update_Crs_Instructor_Course @InsID int , @OldCrsID int,@NewCrsID int
-- as 
-- 	update Instructor_Course
-- 	set Crs_ID = @NewCrsID
-- 	where Ins_ID= @InsID and Crs_ID = @OldCrsID

-- Update_Crs_Instructor_Course @InsID =3 , @OldCrsID =3,@NewCrsID =3
-- drop proc Update_Crs_Instructor_Course

-----

create proc Delete_Instructor_Course @InsID int,@CrsID int
as 
	delete from Instructor_Course
	where Ins_ID = @InsID and Crs_ID=@CrsID

Delete_Instructor_Course @InsID=3,@CrsID=3
drop proc Delete_Instructor_Course

-----------Question-----------

create proc Select_Questions
as 
	select * from Question

Select_Questions 
drop proc Select_Questions

-----

create proc Select_Question_by_Question_ID @QID int
as 
	select q.* from Question q where q.Question_ID=@QID

Select_Question_by_Question_ID @QID=3
drop proc Select_Question_by_Question_ID

-----

create proc Select_Question_by_Crs_ID @CrsID int
as 
	select q.* from Question q where q.Crs_ID=@CrsID

Select_Question_by_Crs_ID @CrsID=1
drop proc Select_Question_by_Crs_ID

-----

create proc Insert_Question @QDesc varchar(100),@QType varchar(10),@Model_Answer varchar(100),
@Mark int,@CrsID int , @QID int output
as 
	insert into Question (Q_Description, Q_Type, Model_Answer, Mark, Crs_ID)
    values (@QDesc, @QType, @Model_Answer, @Mark, @CrsID)
	
	set @QID = scope_identity()

declare @QuestionID int
Insert_Question @QDesc = "",@QType = "" ,@Model_Answer ="",@Mark = 1, @Crs_ID= 1 , @QID = @QuestionID output
drop proc Insert_Question

-----

create proc Update_Question @QID int, @QDesc varchar(100),@QType varchar(10),@Model_Answer varchar(100),
@Mark int,@CrsID int
as 
	update Question
	set Q_Description = @QDesc,
	Q_Type = @QType,
    Model_Answer = @Model_Answer,
	Mark = @Mark,
	Crs_ID  = @CrsID
	where Question_ID = @QID

Update_Question @QID = 3, @QDesc = "",@QType = "" ,@Model_Answer ="",@Mark = 1, @Crs_ID= 1
drop proc Update_Question

-----

create proc Delete_Question @QID int
as 
	begin try
	begin transaction
		delete from Question_Answer_Options
		where Question_ID = @QID
		
		delete from Question
		where Question_ID = @QID
	commit transaction
	end try
	begin catch
		rollback transaction
		select 'Error cannot delete this question because it has assigned to exam, student answers, or options' as errorMessage
	end catch
	
Delete_Question @QID=3
drop proc Delete_Question

-----------Question_Options-----------

create proc Select_Question_Options
as 
	select * from Question_Answer_Options

Select_Question_Options 
drop proc Select_Question_Options

-----

create proc Select_Question_Options_by_ID @QID int
as 
	select q.* from Question_Answer_Options q where q.Question_ID=@QID

Select_Question_Options_by_ID @QID=3
drop proc Select_Question_Options_by_ID

-----

create proc Insert_Question_Options @QID int, @QOption varchar(100) 
as 
	insert into Question_Answer_Options (Question_ID, Q_Ans_Option)
    values (@QID, @QOption)
		
Insert_Question_Options @QID = 1, @QOption = ""
drop proc Insert_Question_Options

-----

create proc Update_Question_Options @QID int, @OldQOption varchar(100), @NewQOption varchar(100) 
as 
	update Question_Answer_Options
	set Q_Ans_Option = @NewQOption
	where Question_ID = @QID and Q_Ans_Option = @OldQOption

Update_Question_Options @QID = 1, @OldQOption = "" , @NewQOption = ""
drop proc Update_Question_Options

-----

create proc Delete_Question_Options @QID int
as 
	begin try
		delete from Question_Answer_Options
		where Question_ID = @QID
	end try
	begin catch
		select 'Error cannot delete this option because it has assigned to student answers' as errorMessage
	end catch
	
Delete_Question_Options @QID = 1
drop proc Delete_Question_Options

-----

create proc Delete_Question_Option @QID int, @QOption varchar(100) 
as 
	begin try
		delete from Question_Answer_Options
		where Question_ID = @QID and Q_Ans_Option = @QOption
	end try
	begin catch
		select 'Error cannot delete this option because it has assigned to student answers' as errorMessage
	end catch
	
Delete_Question_Option @QID = 1 , @QOption = ""
drop proc Delete_Question_Option