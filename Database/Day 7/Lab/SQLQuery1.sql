Use ITI

--1.Create a scalar function that takes date and returns Month name of that date.
create function getMonthName(@dt date) returns varchar(30)
as
begin
	return Datename(MONTH,@dt)
end
select dbo.getMonthName(getdate())

-------------------------------------
--2.Create a multi-statements table-valued function that takes 2 integers and returns the values between them.
create function printNumbers(@n1 int,@n2 int) 
returns @t table (n  int)
as
begin
	declare @num int = @n1+1
	while @num < @n2
	begin
		insert into @t values(@num)
		set @num+=1
	end
	return
end

select * from printNumbers(1,10)

-------------------------------------
--3.Create inline function that takes Student No and returns Department Name with Student full name.
create function printStudentInfo(@stdNo int) 
returns @t table(fullName varchar(50), deptName varchar(50))
as
begin 
	insert into @t 
		select st_fname + ' ' + st_lname, dept_name 
		from Student join Department
		on Student.Dept_Id = Department.Dept_Id
		where Student.St_Id = @stdNo
	return 
end
select * from dbo.printStudentInfo(10)
-----------------------------------------
--4.Create a scalar function that takes Student ID and returns a message to user 
create function userMessage(@id int) returns varchar(50)
as
begin
	declare @fname varchar(50)
	declare @lname varchar(50)
	declare @message varchar(50)
	
	select @fname = st_fname, @lname = st_lname
	from student
	where st_id = @id

	if @fname is null AND @lname is null
		set @message = 'First name & last name are null'
	else if @fname is null 
		set @message = 'first name is null'
	else if @lname is null
		set @message = 'last name is null'
	else
		set @message = 'First name & last name are not null'

	return @message
end

select dbo.userMessage(10)

-------------------------------
--5.Create inline function that takes integer which represents manager ID and displays department name, Manager Name and hiring date 
create function printManagerInfo(@managerID int) returns @t table(deptName varchar(50),managerName varchar(50),hiringDate date)
as
begin
	insert into @t
		select dept_name, ins_name, manager_hiredate
		from department join instructor
		on dept_manager = ins_id
		where dept_manager = @managerID
	return 
end
select * from printManagerInfo(10)
---------------------------------
--6.Create multi-statements table-valued function that takes a string
create function printName(@name varchar(50)) returns @t table(name varchar(50))
as
begin
	if @name = 'first name'
	begin
		insert into @t
		select isnull(st_fname,'no fname')
		from student
	end
	else if @name = 'last name'
	begin
		insert into @t
		select isnull(st_lname,'no lname')
		from student
	end
	else if @name = 'full name' 
	begin
		insert into @t
		select isnull(st_fname, ' ') + ' ' + isnull(st_lname,' ')
		from student
	end	
	return
end
select * from dbo.printName('first name')

-----------------------------------------
--7.Write a query that returns the Student No and Student first name without the last char
select st_id, substring(st_fname,0,len(st_fname)-1)
from student 
-----------------------------------------
--8.Wirte query to delete all grades for the students Located in SD Department 
delete stud_course 
from stud_course join Student  
on stud_course.St_Id = Student.St_Id
join Department 
on Student.Dept_Id = Department.Dept_Id
where department.Dept_Name = 'SD';
