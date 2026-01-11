use ITI
-------------------------------------------------
--Create a Simple Procedure
create procedure getGrades
as
	select crs_name, grade, student.st_id, st_fname
	from Course 
	inner join Stud_Course on Course.Crs_Id = Stud_Course.Crs_Id 
	inner join Student on Student.St_Id = Stud_Course.St_Id
	where Stud_Course.Grade > 50
	order by Course.Crs_Name
--Calling
getGrades 
execute getGrades 
exec getGrades 
-------------------------------------------------
--Create Procedure with Parameters
create procedure getStudentByAddress @address varchar(50)
as
	select st_id, st_fname
	from student 
	where St_Address = @address

getStudentByAddress 'Cairo'
getStudentByAddress 'Alex'
-------------------------------------------------
--Move procedure between schemas
alter schema hr transfer getStudentByAddress
exec hr.getStudentByAddress 'Alex'

alter schema dbo transfer hr.getStudentByAddress

--DROP
drop procedure getStudentByAddress
-------------------------------------------------
--Default Values & Passing Styles
create Procedure sumData @n1 int = 100, @n2 int = 200
as
	select @n1 + @n2

sumData 3, 6
sumData @n2 = 6, @n1 = 5 
sumData 4
sumData	
-------------------------------------------------
--Using Control Flow
create procedure deleteTopic @topicID int
as
	if not exists (select top_id from course where Top_Id = @topicID)
		delete from topic where top_id = @topicID
	else
		select 'Table has relashionship -> cannot delete'

deleteTopic 1
-------------------------------------------------
-- Save procedure results in table variable
declare @t table (x int, y varchar(50))

insert into @t 
execute getStudentByAddress 'Cairo' --capture data 

select * from @t 
select count(*) from @t
-------------------------------------------------
--return one value 
create procedure getAge @id int
as
	declare @age int
	select @age = st_age from student where St_Id = @id
	return @age

declare @x int
execute @x = getAge 5
select @x
-------------------------------------------------
--Return multiple values (Output)
create procedure getData @id int, @age int output, @name varchar(50) output
as
	select @age = st_age, @name = St_Fname
	from Student where st_id = @id

declare @myAge int, @myName varchar(20)
execute getData 2, @myAge output, @myName output
select @myAge, @myName
-------------------------------------------------
--Encryption (prevent using 'sp_helptext')
create procedure getData_encrypted @id int ,@age int output, @name varchar(50) output
with encryption
as
	select @age = st_age, @name = St_fname
	from Student 
	where St_Id = @id

sp_helptext 'getData_encrypted'
-------------------------------------------------
--Dynamic Queries
create procedure getValues @col varchar(50), @t varchar(50)
as
	execute ('select ' + @col + ' From ' + @t)

getValues 'Crs_Name','Course'
