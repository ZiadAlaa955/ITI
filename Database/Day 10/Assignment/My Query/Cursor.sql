use ITI

--Basic Cursor
--1)Declare cursor
declare c1 cursor
for select st_id, st_fname
from student
where St_Address = 'Cairo'
for read only -->No data changes (update, delete, insert)

--2)Declare Variables
declare @id int, @name varchar(20)

--3)Open cursor
open c1
--4)Fetch Row
fetch c1 into @id, @name

--5)Loop while data exists (@@FETCH_STATUS = 0: the fetch is successful)
while @@FETCH_STATUS = 0
begin	
	select @id, @name -->The operation 
	fetch c1 into @id, @name -->Cursor points to the next row
end

--6)close & deallocate cursor
Close C1 
Deallocate C1  --> remove the cursor from memory

-----------------------------------------------------------------
--Concatenation ==> convert Array into string ==> [Ahmed,Ali,Omar]
declare c1 cursor
for select St_fname
from student
where st_fname is not NULL
for read only

declare @name varchar(20)
declare @all_names varchar(300) = ''

open c1

fetch c1 into @name

while @@FETCH_STATUS = 0
begin
	set @all_names = CONCAT(@all_names, ',' , @name)
	fetch c1 into @name
end

close c1
deallocate c1
-----------------------------------------------------------------
--Update Cursor values (current of)
declare c1 cursor
for select salary from instructor
for update -->can update data

declare @salary int

open c1

fetch c1 into @salary

while @@FETCH_STATUS = 0
begin 
	if @salary >= 3000
		update instructor
		set salary = @salary * 1.10
		where current of c1
	else if @salary < 3000
		update instructor 
		set salary = @salary * 1.20
		where current of c1
	else
		delete from instructor 
		where current of c1
	fetch c1 into @salary
end

close c1
deallocate c1
-----------------------------------------------------------------
--Count how many times the name "Ahmed" appears immediately after the name "Amr"
declare c1 cursor
for select st_fname from student ORDER BY St_Id
for read only 

declare @currentName varchar(20) --hold current row value
declare @prevName varchar(20) --hold previous row value
declare @cnt int = 0

open c1

fetch c1 into @currentName

while @@FETCH_STATUS = 0
begin
	if @currentName = 'Ahmed' AND @prevName = 'Amr'
	begin
		set @cnt = @cnt + 1
	end
	set @prevName = @currentname
	fetch c1 into @currentName
end

select @cnt 

close c1
deallocate c1



