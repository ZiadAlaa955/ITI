--Types Of Tables-----------------
--1.Physical Table
create table myExam
(
	ID int, 
	_desc varchar(20),
	examDate date
)

insert into myExam values(1,'DB',GETDATE())
select * from myExam
drop table myExam

--2.Variable table
declare @myExam table
(
	ID int, 
	_desc varchar(20),
	examDate date
)

insert into @myExam values(1,'DB',GETDATE())
select * from @myExam

--3.Local table
Create table #myExam 
(
	ID int, 
	_desc varchar(20),
	examDate date
)

select * from #myExam

insert into #myExam values(1,'C#',GETDATE())

--4.Global table
Create table ##myExam 
(
	ID int, 
	_desc varchar(20),
	examDate date
)

insert into ##myExam values(1,'C#',GETDATE())

