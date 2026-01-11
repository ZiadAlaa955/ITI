use ITI

declare c1 cursor
for select st_id,st_fname from Student where St_Address='cairo'
for read only       
declare @id int,@name varchar(20)
open c1
fetch c1 into @id,@name
while @@FETCH_STATUS=0	
	begin
		select @id,@name
		fetch c1 into @id,@name  --counter++
	end
close c1
deallocate c1
---------------------------------------
--Array --string   one cell [ahmed,ali,amr,fady......]
declare c1 cursor
for select distinct st_fname from Student where st_fname is not null
for read only
declare @name varchar(20),@all_names varchar(300)=''
open c1
fetch c1 into @name
while @@FETCH_STATUS=0
	begin
		set @all_names=concat(@all_names,',',@name)
		fetch c1 into @name
	end
select @all_names
close c1
deallocate c1

---------------------------
declare c1 cursor
for select salary from Instructor
for update
declare @sal int
open c1
fetch c1 into @sal
while @@FETCH_STATUS=0
	begin
		if @sal>=3000
			update Instructor
				set Salary=@sal*1.10
			where current of c1
		else if @sal<3000
			update Instructor
				set Salary=Salary*1.20
			where current of c1
		else
			delete from Instructor
			where current of c1
		fetch c1 into @sal
	end
close c1
deallocate c1

declare c1 cursor
for select st_fname from student
for read only
declare @name1 varchar(20),@name2 varchar(20),@c int=0
open c1
fetch c1 into @name1
while @@FETCH_STATUS=0    --0 Succ   --1  fail    --2  end
	begin
		if @name1='ahmed' and @name2='Amr'
			set @c+=1
		set @name2=@name1
	fetch c1 into @name1
	end
select @c
close c1
deallocate c1
-----------------------------------------------
backup database ITI 
to disk='g:\iti.bak'

--filename backup
--dbname_type_date+time.bak
backup database ITI 
to disk='g:\iti_full_'+getdate()+'.bak'

backup database ITI 
to disk=''
with differential

backup log ITI 
to disk=''

restore database iti
from disk=''
with replace

--Jobs   query+time
--------------------------------------------
--snapshot
create database snapITI
on
(
 name='iti',  --mdf file name
 filename='e:\snap1.ss'
)
as snapshot of ITI

select * from Student
















