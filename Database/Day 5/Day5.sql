--transact-SQL
--top   select into    newid   bulkinsert  ranking

use ITI

select *
from student

select *
from student
where St_Address='alex'

select top(5)*
from student

select top(2) st_fname
from student

select top(1)*
from student

select top(1)*
from student
where st_address='alex'

select Max(salary)
from Instructor

select top(2) Max(salary)
from Instructor

--from select order top
select top(2) salary
from Instructor
order by salary desc

--Newid   GUID
select newid()

select * ,newid() as Xid
from Student
order by Xid

select top(1) *
from student

select top(1) *
from student
order by newid()

select top(10)*
from questions
order by newid()

--fullpath
--Servername.DBname.SchemaName.Objectname

select * from Student

select * from [Rami].[ITI].dbo.student

select *
from Project  --[].[ITI].dbo.Project

select *
from Company_SD.dbo.Project

select dept_name from Department
union all
select dname from Company_SD.dbo.Departments

--select into
--ddl
--create table from existing one

select * into tab2
from Student

select * into tab3
from Student

select st_id,st_fname into tab5
from Student
where St_Address='cairo'

select * into Myitidb.dbo.student
from Student

select * into tab7
from Student
where 1=2   --false condition   age<0

--insert based on select
insert into Student
values(.....)

insert into Student
values(.....),(....),(...)

insert into tab5
select st_id,st_fname from student where St_Address='alex'

--insert data from file
bulk insert tab5
from 'E:\studentdata.txt'
with(fieldterminator=',')

select *
from (select *,Row_number() over(order by st_age desc) as RN
      from Student) as newtable
where RN=1


select *
from (select *,Dense_rank() over(order by st_age desc) as DR
      from Student) as newtable
where DR=1

select *
from (select *,Ntile(3) over(order by st_age desc) as G
      from Student) as newtable
where g=2

select *
from (select *,Row_number() over(PArtition by dept_id order by st_age desc) as RN
      from Student) as newtable
where RN=1


select *
from (select *,Dense_rank() over(PArtition by dept_id order by st_age desc) as DR
      from Student) as newtable
where DR=1

select *
from (select *,Ntile(2) over(PArtition by dept_id order by st_id desc) as G
      from Student) as newtable
where g=1 and Dept_Id=10

select *
from (select *,Ntile(2) over(PArtition by dept_id order by st_id desc) as G
      from Student) as newtable
where g=1 

select *
from (select *,Ntile(2) over(PArtition by dept_id order by st_id desc) as G
      from Student) as newtable
where g=2

--Top  --newid  --Ranking  --selectinto --bulkinsert  --insertbased onselect

--builtin function
select Upper(st_fname),lower(st_lname)
from Student

select len(st_fname) ,st_fname
from Student

select SUBSTRING(st_fname,1,3)
from Student

select SUBSTRING(st_fname,3,3)
from Student


select SUBSTRING(st_fname,1,len(st_fname)-1)
from Student

select *
from Student
where len(St_fname)>3

select *
from Student
where substring(st_fname,1,1)='a'

use ITI

use Company_SD





select db_name()

select SUSER_NAME()

insert into test values('eman')

select SCOPE_IDENTITY()

select IDENT_CURRENT('test')

drop table student --ddl   data & metadata  child

delete from student  --DMl data where slower --log  --rollback
                     --child parent 

truncate table student  --data faster  --sometimes log
                         --Child --ddl  --reset identity



