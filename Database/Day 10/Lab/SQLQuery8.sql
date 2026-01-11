use Company_SD

--1.Create a cursor for Employee table that increases Employee salary by 10% if Salary <3000 and increases it by 20% if Salary >=3000. 
Declare c1 cursor
for select salary
from employee
for update

declare @salary int

open c1

fetch c1 into @salary 

while @@FETCH_STATUS = 0
begin
	if @salary < 300
		BEGIN 
			update employee
			set salary = @salary * 1.10
			where current of c1
		END
	else if @salary >= 3000
		begin
			update employee
			set salary = @salary * 1.20
			where current of c1
		end
	fetch c1 into @salary
end

close c1
deallocate c1

--------------------------------------------------------
--2.Display Department name with its manager name using cursor. Use ITI DB
use ITI
declare c1 cursor
for select dept_name, ins_name
from Department join Instructor 
on Dept_Manager = ins_id
for read only

declare @deptName varchar(50), @managerName varchar(50)

open c1

fetch c1 into @deptName, @managerName

while @@FETCH_STATUS = 0
begin
	select @deptName, @managerName
	fetch c1 into @deptName, @managerName
end

close c1
deallocate c1

--------------------------------------------------------
--3.Try to display all students first name in one cell separated by comma. Using Cursor 
declare c1 cursor
for select st_fname 
from student 
where st_fname is not null
for read only

declare @name varchar(50), @listNames varchar(300) = ''

open c1

fetch c1 into @name

while @@FETCH_STATUS = 0
BEGIN
	set @listNames = concat(@listNames , ',' , @name)
	fetch c1 into @name
END

select @listNames 

close c1
deallocate c1

--------------------------------------------------------
--4.Create a sequence object that allow values from 1 to 10 without cycling in a specific column and test it.
create sequence seq
start with 1
increment by 1
minValue 1
maxValue 10

create table test (
	ID int,
	name varchar (40)
)

create table test2 (
	ID int,
	name varchar (40)
)


insert into test values(next value for seq, 'Ziad')
insert into test2 values(next value for seq, 'Ziad')

select * from test
select * from test2

--------------------------------------------------------
--5.Create snapshot of adventureworks_db and test it
use AdventureWorks2012

create database AdventureWorks2012_Snap
on 
(
	name = 'AdventureWorks2012_Data',
	fileName = 'D:\ITI\Database\MySnapShots\AdventureWorks2012_Snap.ss'
)
as snapshot of AdventureWorks2012

select FirstName from AdventureWorks2012.Person.Person
where BusinessEntityID = 1

update AdventureWorks2012.Person.Person
set FirstName = 'Deleted'
where BusinessEntityID = 1

select FirstName from AdventureWorks2012.Person.Person
where BusinessEntityID = 1

select FirstName from AdventureWorks2012_snap.Person.Person
where BusinessEntityID = 1

--------------------------------------------------------
--6.Transform all functions in day2 to Stored Procedures
--6.1 Create a scalar function that takes date and returns Month name of that date
create procedure getMontName @dt date
as
BEGIN
	select DateName(Month,@dt)
END

declare @currentDate date = getDate()
exec getMontName @dt = @currentDate

--6.2 Create a multi-statements table-valued function that takes 2 integers and returns the values between them.
create proc SP_printNumbers @n1 int, @n2 int
as
BEGIN
	declare @t table (n int)
	declare @num int = @n1 + 1
	while @num < @n2
	begin
		insert into @t values(@num)
		set @num+=1
	end
	select * from @t
END

SP_printNumbers 1, 10

--6.3 Create inline function that takes Student No and returns Department Name with Student full name.
create proc SP_printStudentInfo @stdNo int
as
BEGIN
		select st_fname + ' ' + st_lname, dept_name
		from student join Department
		on Student.Dept_Id = Department.Dept_Id
		where Student.St_Id = Student.St_Id
END

SP_printStudentInfo 10

--6.4 Create a scalar function that takes Student ID and returns a message to user 
create proc sp_userMessage @id int
AS
BEGIN
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

	select @message
END

sp_userMessage 10

--6.5 Create inline function that takes integer which represents manager ID and displays department name, Manager Name and hiring date 
create proc SP_printManagerInfo @managerID int
AS
BEGIN
	select dept_name, ins_name, manager_hiredate
	from department join instructor
	on dept_manager = ins_id
	where dept_manager = @managerID
END

SP_printManagerInfo 8

--6.6 Create multi-statements table-valued function that takes a string
create proc SP_printName @name varchar(50)
as
BEGIN
	if @name = 'first name'
	begin
		select isnull(st_fname,'no fname')
		from student
	end
	else if @name = 'last name'
	begin
		select isnull(st_lname,'no lname')
		from student
	end
	else if @name = 'full name' 
	begin
		select isnull(st_fname, ' ') + ' ' + isnull(st_lname,' ')
		from student
	end	
END

SP_printName 'first name'

--------------------------------------------------------
--7.Create full, differential Backup for SD DB.
--FULL BACKUP
backup database SD 
to disk = 'D:\ITI\Database\MyBackupData\SD.bak'

--DIFF BACKUP
backup database SD
to disk = 'D:\ITI\Database\MyBackupData\SD.bak'
with differential

--------------------------------------------------------
--8.Use display student’s data (ITI DB) in excel sheet
use ITI; 
select * from Student;

