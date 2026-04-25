-- Primary key -> clustered index
-- unique      -> nonclustered index

create table test1
(
	id int identity,
	ssn int Primary key, -- creates clustered index automatically
	ename varchar(20),
	sal int unique,		 -- creates non clustered index automatically
	overtime int unique, -- creates non clustered index automatically
	constraint cc check(sal>1000)
)

-------------------
--create indexes manually
create clustered index i2
on student(st_fname)

create nonclustered index i2
on student (st_fname)

create nonclustered index i3
on student (st_address)

create index i33  -- 'nonclustered' is the default if you don't specify
on student(st_age) 


create unique index i34
on student(st_age) -- error: there is duplicates

------------------------------------------------
--Display estimated execution plan:
select * from Student where st_id=10 -- cost is 100% used by clustered index (fast)

select * from Instructor where Salary=1000 -- index scan (slow)
------------------------------------------------
--SQL Server Profiler AND Database Engine Tuning Advisor (DTA).
select * from Instructor where Salary=1000

select * from Course where Crs_Duration=10
