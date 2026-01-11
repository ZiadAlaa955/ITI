use ITI

--1.Create a stored procedure without parameters to show the number of students per department name
create procedure getDepartmentCount
as 
	select count(st_id) as students, dept_name
	from student join department
	on student.Dept_Id = Department.Dept_Id
	group by dept_name

--2.Create a stored procedure that will check for the # of employees in the project p1 if they are more than 3 print message to the user “'The number of employees in the project p1 is 3 or more'” if they are less display a message to the user “'The following employees work for the project p1'” in addition to the first name and last name of each one. 
use Company_SD
create procedure getP1Employees
as
	declare @n int
	select @n = count(eSSN)
	from Works_for
	where pno = 100
	if @n > 3
	begin
		select 'The number of employees in the project p1 is 3 or more'
	end
	else 
	begin
		select 'The following employees work for the project p1'
		select fname, lname
		from employee join works_for
		on ssn = essn
		where pno = 100
	end

--3.Create a stored procedure that will be used in case there is an old employee has left the project and a new one become instead of him. The procedure should take 3 parameters (old Emp. number, new Emp. number and the project number) and it will be used to update works_on table
create procedure updateEmployeesInProjects @oldEmpNum int, @newEmpNum int, @pNum int
as
begin
	update works_for 
	set essn = @newEmpNum
	where essn = @oldEmpNum AND pno = @pNum
end

--4.add column budget in project table and insert any draft values in it then then Create an Audit table with the following structure 
alter table project 
add budget int

update project set budget = 10000 where pnumber = 100
update project set budget = 20000 where pnumber = 200
update project set budget = 30000 where pnumber = 300

create table Audit (
	projectNo int,
	userName varchar(50),
	modifiedDate date,
	budget_old int,
	budget_new int
);

create trigger auditBudget 
on project
after update 
as
begin
	if update(budget)
		insert into audit
		select
			inserted.pnumber,
			SUSER_NAME(),
			GETDATE(),
			deleted.budget,
			inserted.budget
		from inserted join deleted
		on inserted.pnumber = deleted.pnumber
end

--5.Create a trigger to prevent anyone from inserting a new record in the Department table [ITI DB] “Print a message for user to tell him that he can’t insert a new record in that table”
use ITI
create trigger preventInsert
on department
instead of insert
as
begin
	select 'You can’t insert a new record in that table'
end

--6.Create a trigger that prevents the insertion Process for Employee table in March [Company DB].
use Company_SD
create trigger preventInsertInMarch
on employee
after insert
as
begin
	if MONTH(getdate()) = 3
	begin
		select  'You can’t insert a new record in that table in March'
	end
	else
	begin
		insert into employee (
			fname,
			lname,
			ssn,
			bdate,
			address,
			sex,
			salary,
			superssn,
			dno
		)
		select
			fname,
			lname,
			ssn,
			bdate,
			address,
			sex,
			salary,
			superssn,
			dno
		from inserted
	end
end


--7.Create a trigger on student table after insert to add Row in Student Audit table (Server User Name , Date, Note) where note will be “[username] Insert New Row with Key=[Key Value] in table [table name]”
use ITI

create table studentAudit (
	server_user_name varchar(100),
	dt date,
	note varchar(MAX)
);

alter trigger insertIntoAudit 
on student 
after insert
as
begin
	insert into studentAudit (server_user_name, dt, note)
	select 
		SUSER_NAME(),
		GETDATE(),
		SUSER_NAME() + ' Insert New Row with Key = ' + cast(inserted.St_Id as varchar(50)) + ' in table student'
		from inserted
end

insert into student (st_id, st_fname)
values(556,'Ziad')

--8.Create a trigger on student table instead of delete to add Row in Student Audit table (Server User Name, Date, Note) where note will be“ try to delete Row with Key=[Key Value]”
alter trigger deleteMessage
on student
instead of delete
as
begin
	insert into studentAudit
	select 
		SUSER_NAME(),
		GETDATE(),
		' try to delete Row with Key = ' + cast(deleted.st_id as varchar(50))
	from deleted
end




