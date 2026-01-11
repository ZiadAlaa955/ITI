
create Proc getgrades
as
	SELECT Course.Crs_Name, Stud_Course.Grade, Student.St_Id, Student.St_Fname
	FROM   Course INNER JOIN
             Stud_Course ON Course.Crs_Id = Stud_Course.Crs_Id INNER JOIN
             Student ON Stud_Course.St_Id = Student.St_Id
	WHERE (Stud_Course.Grade > 50)
	ORDER BY Course.Crs_Name

--calling
getgrades 
execute getgrades 
exec getgrades 

create Procedure getstbyadd @add varchar(20)
as
	select st_id,st_fname
	from Student
	where st_Address=@add

--calling
getstbyadd 'cairo'
getstbyadd 'alex'
alter schema hr transfer getstbyadd 
hr.getstbyadd 'alex'
alter schema dbo transfer hr.getstbyadd 
drop proc getstbyadd


alter Proc deltopic @tid int
as
	if not exists(select top_id from course where top_id=@tid)
		delete from topic where top_id=@tid
	else
		select 'table has relationship'



deltopic 40

--Parameters  & return values
alter Proc sumdata @x int=200,@y int=100
as
	select @x+@y

sumdata 3,6 --->passing Parameters by position
sumdata @y=5,@x=2 --> Passing parameters by name
sumdata 4
sumdata

--return values
create Procedure getstbyadd @add varchar(20)
as
	select st_id,st_fname
	from Student
	where st_Address=@add

--1
getstbyadd 'cairo' 

--2
declare @t table(x int,y varchar(20))
	insert into @t
	execute getstbyadd 'cairo'
select * from @t
select count(*) from @t

--3
insert into grades(sid,sname)
execute getstbyadd 'cairo'

--return one value   --scalar function
create Proc getdata @id int
as
	declare @age int
		select @age=st_age from Student
		where st_id=@id
	return @age

declare @x int
	execute @x = getdata 5
select @x

alter Proc getdata @id int ,@age int output,@name varchar(20) output
as
		select @age=st_age,@name=st_fname from Student
		where st_id=@id
	
declare @x int,@y varchar(20)
	execute  getdata 2 , @x output ,@y output
select @x,@y
------------------------------------------------------------
alter Proc getdata @z int output,@name varchar(20) output
with encryption
as
		select @z=st_age,@name=st_fname from Student
		where st_id=@z
	
declare @x int=2,@y varchar(20)
	execute  getdata  @x output ,@y output
select @x,@y

sp_helptext 'getdata'
--------------------------------------------
--dynamic queries
create Proc getvalues @col varchar(20),@t varchar(20)
as
	execute('select '+@col+' from '+@t)

--calling
getvalues 'crs_name','course'
-------------------------------------------------------------
--types of SP
----------------
--user defined SP
sumdata   deltopc  getsbyadd

--built-in SP
sp_bindrule  sp_unbindefault  sp_helptext  sp_helpconstraint  sp_Addtype ......

--Triggers
--special type of SP
--can't call
--can't take parameters
--automatic firing according actions
--triggers  tables [insert,update,delete]

--server   --DB   --schema    --object


create trigger tr_1
on student
after insert
as
	select 'wlecome to ITI'

insert into Student(st_id,St_Fname) 
values(551,'ahmed')

create trigger tr_2
on student
for update
as
	select getdate(),suser_name(),HOST_NAME(),DB_NAME()

update Student set st_age+=1

create trigger tr_3
on student
instead of delete
as
	select 'not allowed'

delete from Student where st_id=550

alter trigger tr_5
on department
instead of insert,update,delete
as
	select 'not allowed for user = '+SUSER_NAME()

update Department set Dept_Name='HR' where Dept_Id=10

alter table department disable trigger tr_5
alter table department enable trigger tr_5

alter trigger tr_7
on course
after update
as
	if update(crs_name)
		select 'data is updated'
	
update course 
	set Crs_name='js'
where crs_id=-1
------------------------------------------------
create trigger tr_10
on course
after update
as
	select * from inserted 
	select * from deleted

update course
	set crs_name='cloud',Crs_Duration='55',top_id=4
where crs_id=100

update course
	set crs_name='OOP',Crs_Duration='100',top_id=2
where crs_id=300

create trigger tr_test
on course
instead of delete
as
	select 'not allowed to delete course name = '+(select crs_name from deleted)

delete from course where crs_id=1200

--------------
--output ===>runtime trigger

delete from instructor
	output getdate()
where ins_id=55

update instructor
	set salary=5000
output suser_name(),getdate(),deleted.salary,inserted.Salary,'update instructor' into history_audit
where ins_id=66

--------------------------------------------
-->batch    script   transaction
-----batch
-----set of independent queries

insert
update
delete


--ddl
--script
--set of bached separated by go
create table
go
create function
go
create rule
go
drop table

declare @x int
go
declare @x int

--transaction
--set of dependent queries
--run as single unit work

insert
update
delete

create table Parent(Pid int primary key)
create table child(cid int foreign key references parent(pid))

insert into parent values(1)
insert into parent values(2)
insert into parent values(3)
insert into parent values(4)

insert into child values(1)
insert into child values(22)
insert into child values(3)

begin transaction
	insert into child values(1)
	insert into child values(2)
	insert into child values(3)
rollback

begin try
	begin transaction
		insert into child values(1)
		insert into child values(200) --error
		insert into child values(3)
	commit
end try
begin catch
	rollback --remove id=1
	select 'error'
end catch


begin transaction
	insert
	truncate  --log file
	update
	delete  ---error   --rollback


-->Transaction Properties ACID

select * from child
truncate table child
------------------------------------------------





















































