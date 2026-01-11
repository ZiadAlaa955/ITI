--After trigger
create trigger tr1
on student 
after insert
as
	select 'Welcome to ITI'

insert into student(st_id, st_fname)
values (551, 'Ahmed')
--------------------------------------------
--For trigger (after = for)
create trigger tr2
on student 
for update
as
	select getDate(), SUSER_NAME(), HOST_NAME(), DB_NAME()

update student set st_age +=1
--------------------------------------------
--Instead of Trigger
create trigger tr3
on student
instead of delete
as
	select 'Not allowed -> deletion is blocked'

delete from student where st_id = 550
-----
create trigger tr4
on department 
instead of insert, update, delete
as
	select 'Not allowed for user: '+ SUSER_NAME()

update Department set Dept_Name = 'HR' where Dept_Id = 10
--------------------------------------------
--switch on/off
alter table department disable trigger tr4
alter table department enable trigger tr4
--------------------------------------------
--triggers with conditions
create trigger tr5
on Course 
after update 
as
	if update(crs_name)
		select 'Data is updated'

--message will appear
update course 
set Crs_Name = 'JS'
where Crs_Id = -1
--message will not appear
update Course
set crs_duration = 50
where crs_id = -1
--------------------------------------------
--trigger with inserted & deleted tables
create trigger tr6
on course 
after update
as
	select * from inserted  --show new data
	select * from deleted   --show old data

update course 
set crs_name = 'Cloud', Crs_Duration = '56', Top_Id = 4
where crs_id = 100
--------------------------------------------
--access the data with "Instead Of"
create trigger tr7
on course 
instead of delete
as
	select 'Not allowed to delete course: ' + (Select crs_name from deleted)

delete from Course
where crs_id = 1200
--------------------------------------------
--Runtime trigger (Output)
delete from Instructor
output GETDATE() as deleteTime, deleted.Ins_Id
where ins_id = 55

update instructor
set salary = 5000
output 
	SUSER_NAME(),
	GETDATE(),
	deleted.Salary as oldSalary,
	inserted.Salary as newSalary,
	'Updated instructor'
where ins_id = 1


