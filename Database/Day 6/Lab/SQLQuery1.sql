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

