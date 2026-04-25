--Basic IF..else
Declare @x int

update Instructor 
set salary += 100

select @x = @@ROWCOUNT

if @x > 0
Begin
	select 'Multi rows affected' 
End
else
Begin
	select 'Zero rows affected'
End


--if exists
if exists(select name from sys.tables where name = 'student')
	select 'Table already exists'
else
Begin
	create table staudent
	(
		id int,
		name varchar(20)
	)
	select 'Table created successfuly'
End

--if not exists
if not exists(select top_id from course where top_id = 10)
Begin
	delete from topic where top_id = 10
	select 'topic deleted'
End
else
Begin
	select 'Cannot delete topic: has relationship'
End

--------------------------------------------------
--try...catch
Begin try
	delete from topic where top_id = 1
End try
Begin catch
	select 
	ERROR_LINE(), ERROR_MESSAGE(), ERROR_NUMBER()
end catch
--------------------------------------------------
--While
declare @x int = 10

while @x<=20
Begin
	set @x += 1
	if @x = 14
		continue
	if @x = 16
		break
	select @x
End
--------------------------------------------------
--Case statement
select ins_name, salary,
	case
		when salary >= 5000 then 'High salary'
		when salary < 5000 then 'Low salary'
		else 'No data'
	end as salaryStatus
from instructor


--IIf statement
select ins_name, IIF(salary >= 5000, 'High Salary', 'Low Salary') 
from instructor


--Case with update
update instructor 
set salary = Case
	when salary >= 5000 then Salary * 1.20
	else Salary * 1.10
End

