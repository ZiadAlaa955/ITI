use SD

create type loc from nchar(2) not null;
create default default_loc as 'NY';
create rule rule_loc as @values in ('NY','DS','KW');
exec sp_bindefault 'default_loc', 'loc';
exec sp_bindrule 'rule_loc', 'loc';

create table Department(
DeptNo varchar(50) primary key,
DeptName varchar(50),
Location loc
);

insert into Department (DeptNo, DeptName, Location)
values ('d1','Research','NY');

insert into Department (DeptNo, DeptName, Location)
values ('d2','Accounting','DS');

insert into Department (DeptNo, DeptName, Location)
values ('d3','Marketing','KW');
----------------------------------------------------
create table Employee(
EmpNo int primary key,
EmpFname varchar(50),
EmpLname varchar(50),
DeptNo varchar(50),
Salary int,
constraint fk foreign key (DeptNo) references Department(DeptNo),
constraint uniqe_salary unique (Salary),
constraint chk_salary check (salary < 6000)
);
alter table Employee
alter column EmpLname varchar(50) not null
alter table Employee
alter column EmpFname varchar(50)not null

insert into Employee(EmpNo, EmpFname, EmpLname, DeptNo, Salary)
values(25348,'Mathew','Smith','d3',2500);
insert into Employee(EmpNo, EmpFname, EmpLname, DeptNo, Salary)
values(10102,'Ann','Jones','d3',3000);
insert into Employee(EmpNo, EmpFname, EmpLname, DeptNo, Salary)
values(18316,'John','Barrimore','d1',2400);
insert into Employee(EmpNo, EmpFname, EmpLname, DeptNo, Salary)
values(29346,'James','James','d2',2800);
insert into Employee(EmpNo, EmpFname, EmpLname, DeptNo, Salary)
values(9031,'Lisa','Bertoni','d2',4000);
insert into Employee(EmpNo, EmpFname, EmpLname, DeptNo, Salary)
values(2581,'Elisa','Hansel','d1',3600);
insert into Employee(EmpNo, EmpFname, EmpLname, DeptNo, Salary)
values(28559,'Sybl','Sybl','d1',2900);
--------------------------------------------------------------
insert into Employee(EmpNo, EmpFname, EmpLname, DeptNo, Salary)
values(11111 ,'Ziad','Alaa','d2',4000); --error because the default & rule in department table

insert into Employee(EmpNo, EmpFname, EmpLname, DeptNo, Salary)
values(10102 ,'Ziad','Alaa','d2',4000); --duplicate

update Employee
set EmpNo = 22222
where EmpNo = 10102; ---conflict

delete from employee 
where empNo = 10102; ---conflict
---------------------------------
alter table Employee
add TelephoneNumber int;

alter table Employee
drop column TelephoneNumber;
---------------------------------
--2.Create the following schema and transfer the following tables to it 
create schema Company;
alter schema Company transfer dbo.Department;

create schema [Human Resources];
alter schema [Human Resources] transfer dbo.Employee;
----------------------------------
--3.Write query to display the constraints for the Employee table.
select CONSTRAINT_NAME, CONSTRAINT_TYPE
from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
where TABLE_NAME = 'Employee' AND TABLE_SCHEMA = 'Human Resources';
----------------------------------
--4.Create Synonym for table Employee as Emp and then run the following queries and describe the results
create synonym Emp for [Human Resources].Employee;
select * from Employee; --invalid table name
select * from [Human Resources].Employee; --show the rows
select * from Emp; --show the rows
select * from [Human Resources].Emp;  --invalid table name
----------------------------------
--5.Increase the budget of the project where the manager number is 10102 by 10%.
update company.project
set budget = budget * 1.10
where projectNo in (
	select projectNo 
	from dbo.Works_on 
	where EmpNo = 10102
);
----------------------------------
--6.Change the name of the department for which the employee named James works.The new department name is Sales.
update company.department
set DeptName = 'Sales'
where DeptNo in (
	select DeptNo
	from Emp
	where EmpFname = 'James'
);
----------------------------------
--7.Change the enter date for the projects for those employees who work in project p1 and belong to department ‘Sales’. The new date is 12.12.2007.
update dbo.Works_on
set Enter_date = '2007-12-12'
where projectNo = 'p1'
AND EmpNo in(
	select EmpNo 
	from [Human Resources].Employee
	where DeptNo = ( 
		select DeptNo
		from Company.Department 
	where DeptName = 'Sales'
	)
);
-----------------------------------
--8.Delete the information in the works_on table for all employees who work for the department located in KW.
delete 
from dbo.Works_on
where EmpNo in (
	select EmpNo
	from Emp
	where DeptNo in (
		select DeptNo
		from Company.Department
		where Location = 'KW'
	)
);
-----------------------------------
--9.Try to Create Login Named(ITIStud) who can access Only student and Course tablesfrom ITI DB then allow him to select and insert data into tables and deny Delete and update .(Use ITI DB)
