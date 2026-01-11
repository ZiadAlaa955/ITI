use ITI

select Sum(salary) as Total
from Instructor

select count(ins_id)
from Instructor

select min(salary),Max(salary)
from Instructor

select count(*),count(st_id),count(st_fname),count(st_age)
from Student

select avg(st_age)
from Student

select avg(isnull(st_age,0))
from Student

select sum(st_age)/count(*)
from Student

select sum(Salary),dept_id
from Instructor
group by dept_id

select sum(Salary),d.dept_id,dept_name
from Instructor i inner join Department d
	on d.Dept_Id=i.Dept_Id
group by d.dept_id,dept_name

select count(st_id),st_address
from Student
group by St_Address

select count(st_id),dept_id
from Student
group by dept_id

select count(st_id),dept_id,St_Address
from Student
group by dept_id,st_address


select count(st_id),dept_id,St_Address
from Student
group by st_address,dept_id

select sum(Salary),dept_id
from Instructor
group by dept_id

select sum(Salary),dept_id
from Instructor
where salary>1000
group by dept_id


select sum(Salary),dept_id
from Instructor
group by dept_id

select sum(Salary),dept_id
from Instructor
group by dept_id
having sum(salary)<30000

select sum(Salary),dept_id
from Instructor
group by dept_id
having count(ins_id)<6

--group by having
select *
from Student
where st_age between 20 and 25

select sum(salary)
from Instructor
having count(ins_id)<100

----------------------------------------------
--subqueries
select *
from Student
where st_age<(select avg(St_age) from Student)

select *,(select count(st_id) from Student)
from Student

select dept_name
from Department
where Dept_Id in (select distinct dept_id
                  from student
				  where dept_id is not null)

select distinct dept_name
from Student s inner join Department d
	on d.Dept_Id =s.Dept_Id

-->Agg functions + grouping +having'
-->subqueries
-->EERD
--> Set operators  []union all   union  intersect  except

select st_fname 
from Student
union all
select ins_name
from Instructor

select st_fname as [ITInames]
from Student
union all
select ins_name
from Instructor

select st_fname ,st_id
from Student
union all
select ins_name,ins_id
from Instructor

select convert(varchar(20),st_id)
from Student
union all
select ins_name
from Instructor

select st_fname 
from Student
union --[distinct]
select ins_name
from Instructor

select st_fname 
from Student
intersect
select ins_name
from Instructor

select st_fname 
from Student
except
select ins_name
from Instructor

select st_fname,dept_id,st_age
from Student
where St_Address='cairo'

select st_fname,dept_id,st_age
from Student
order by St_Address

select st_fname,dept_id,st_age
from Student
order by 1

select st_fname,dept_id,st_age
from Student
order by dept_id asc,st_age desc

select st_fname+' '+st_lname as fullname
from Student
order by fullname

select st_fname+' '+st_lname as fullname
from Student
where fullname='ahmed hassan'

select st_fname+' '+st_lname as fullname
from Student
where fullname='ahmed hassan'

select st_fname+' '+st_lname as fullname
from Student
where st_fname+' '+st_lname='ahmed hassan'

select *
from (	select st_fname+' '+st_lname as fullname
	   from Student) as newtable
where fullname='ahmed hassan'

create table test
(
 id int Primary key identity(1,1),
 ename varchar(20)
)

select * from test

insert into test values('omar')


dbcc checkident('test',reseed,0)

delete from test

create table test
(
 id int  identity(1,1),
 ssn int primary key,
 ename varchar(20)
)

drop table test


insert into test values(1,'ahmed')
insert into test values(2,'ahmed')
insert into test values(3,'ahmed')




--->execution order 
----from
----join
----on
---where 
--group by
--having
--select
--order
--top
--into




