use ITI

--1.Basic View----------------------------
--1.1 Basic view creation
create view vStudent
as
	select * from student

select * from vStudent

--1.2 View with custom column names ==> hide column names
create view vCairo(sid, fname, sadd)
as
	select st_id, st_fname, st_address
	from Student
	where St_Address = 'Cairo'

select * from vCairo
select fname from vCairo
drop view vCairo

--1.3 Security: hide view code
create view vJoin(sid, sname, did, dname)
with encryption
as
	select st_id, st_fname, d.dept_id, dept_name
	from student s join Department d
	on s.dept_id = d.dept_id

sp_helptext 'vjoin'  --Will fail


--1.4 Layering: view on view ==> union / join
create view vAlex
as
	select * from Student
	where St_Address = 'Alex'

create view vCairo
as
	select * from Student
	where St_Address = 'Cairo'

--union
create view vCairo_vAlex
as
	select * from vCairo
	union
	select * from vAlex

select * from vCairo_vAlex

--join
alter view grades 
as 
select sname, dname, grade
from vjoin join Stud_Course
on sid = st_id

select * from grades


--1.5 move it between schemas
alter schema HR transfer vCairo
select * from HR.vCairo

alter schema dbo transfer HR.vCairo
select * from vCairo

drop view vcairo


--2.View with DML (insert, update, delete) ===> "With check option"------------------
--2.1View on a single Table
Alter view vAlex
as
	select * from Student
	where St_Address = 'Alex'
	with check option			--> prevent user from insert data out of specified address "Alex"

insert into vAlex (st_id, st_fname, st_address) 
values(155, 'Ahmed', 'Alex')

insert into vAlex (st_id, st_fname, st_address) 
values(118, 'Ahmed', 'Mansoura')				--> Fail: this view can insert only 'Alex' address

--2.2 View on multi-tables
--You can modify data, but only one table at a tile
Alter view vJoin(sid, sname, did, dname)
as
	select st_id, st_fname, d.dept_id, dept_name
	from student s join Department d
	on s.dept_id = d.dept_id 

Delete from vJoin Where sid = 1  -->Error: can't delete from view with multiple table ==> DB doesn't know which table to delete from

--insert only on one table per statement
insert into vJoin (sid, sname) values(22, 'Ahmed') --> affect student table
insert into vJoin (did, dname) values(2000, 'HR')  --> affect department table
insert into vjoin (sid, sname, did, dname) values(22,'Ahmed',2000,'HR') -->Error

--Update one table per statement
update vjoin
set sname = 'Ali'
where sid = 1

--update both tables ==> Fails
Update vjoin 
set sname = 'Ali', dname = 'Cloud'
where sid = 1


