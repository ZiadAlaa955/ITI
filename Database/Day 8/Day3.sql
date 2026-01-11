create clustered index i2
on student(St_fname)

create nonclustered index i2
on student(St_fname)

drop index i2


create nonclustered index i3
on student(St_address)

select * from Student where st_id=10

select * from grades where sid=10

---> Primary key constraint ===> clustered index
---> unique constraint  ========> nonclustered index

create table test1
(
 id int identity,
 ssn int Primary key,
 ename varchar(20),
 sal int unique,
 overtime int unique,
 constraint cc check(sal>1000)
)

create unique index i33    --unique constraint + nonclustered index
on student(st_age)

create index i33  --nonclustered index
on student(st_age)

select * from Instructor where Salary=1000

select * from Course where Crs_Duration=10
-----------------------------------------------------
--index
--Pivoting data
--types of tables
---->physical table
create table myexam
(
 id int,
 _desc varchar(20),
 edate date
)

insert into myexam values(1,'db','1/1/2026')

select * from myexam

drop table myexam


---->variable table
declare @myexam table
(
 id int,
 _desc varchar(20),
 edate date
)

insert into @myexam values(1,'db','1/1/2026')

select * from @myexam

---->local tables ---->session based tables
create table #myexam
(
 id int,
 _desc varchar(20),
 edate date
)

---->Global tables
create table ##myexam
(
 id int,
 _desc varchar(20),
 edate date
)


--view
select * from Student

create view vstuds
as
	select * from Student

--calling
select * from vstuds

create view vcairo(sid,sname,sadd)
as
	select st_id,st_fname,st_address
	from Student
	where St_Address='cairo'

select * from vcairo
select sname from vcairo
alter schema hr transfer vcairo
select * from [HR].[vcairo]
alter schema dbo transfer hr.vcairo
drop view vcairo

create view valex(sid,sname,sadd)
as
	select st_id,st_fname,st_address
	from Student
	where St_Address='alex'

select * from valex

create view valex_cairo
as
	select * from valex
	union all
	select * from vcairo

select * from valex_cairo

-->complex queries
alter view vjoin(sid,sname,did,dname)
with encryption
as
	select st_id,st_fname,d.Dept_Id,Dept_Name
	from Student s inner join Department d
	on d.Dept_Id=s.Dept_Id

select * from vjoin
select sname,dname from vjoin

sp_helptext 'vjoin'


create view vgrades
as
	select sname,dname,grade
	from vjoin v inner join Stud_Course sc
	on v.sid=sc.St_Id

select * from vgrades

--DML   view
---------------
-->view   one table
alter view valex(sid,sname,sadd)
as
	select st_id,st_fname,st_address
	from Student
	where St_Address='alex'
with check option

insert into valex
values(155,'ahmed','alex')

insert into valex
values(118,'ahmed','mansoura')


select * from valex

--> view  multi tables
create view vjoin(sid,sname,did,dname)
as
	select st_id,st_fname,d.Dept_Id,Dept_Name
	from Student s inner join Department d
	on d.Dept_Id=s.Dept_Id

--Delete XXXXX
--insert   update
insert into vjoin(sid,sname)
values(22,'ahmed')

insert into vjoin(did,dname)
values(2000,'hr')

update vjoin
	set sname='ali'
where sid=1

insert into vjoin
values(22,'ahmed',2000,'hr')

update vjoin
	set sname='ali',dname='cloud'
where sid=1

-->Merge

















