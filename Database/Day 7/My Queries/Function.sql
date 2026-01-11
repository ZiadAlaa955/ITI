--Scalar functions: return 1 value
--function -fun_name -params -return -body
create function getStudentName(@sid int)
returns varchar(30)
as
BEGIN
	declare @name varchar(30)
	
	select @name = st_fname
	from student where st_id = @sid

	return @name
END

--calling
select dbo.getStudentName(4) -->Must use schema name

--move between schemas
alter schema hr transfer getStudentName
select hr.getStudentName(4) -->Must use schema name
alter schema dbo transfer hr.getStudentName

drop function getStudentName
------------------------------------
--Inline function 
-->return table 
-->contains single select 
-->No begin & end scope

create function getIsts(@did int)
returns table
as
return(
	select ins_name, salary * 12 as AnnualSalary
	from Instructor
	where Dept_Id = @did
)

select * from getIsts(10)
select ins_name from getIsts(10)
select sum(AnnualSalary) from getIsts(10)

-----------------------------------------
--Multi-statement function
-->return table
-->allow write complex logic inside begin..end
create function getStudents(@format varchar(20))
returns @t table(id int, sname varchar(50))
as
begin 
	if @format = 'first'
		insert into	@t
		select st_id, st_fname from student
	else if @format = 'last'
		insert into	@t
		select st_id, st_lname from student
	else if @format = 'fullName'
		insert into @t 
		select st_id, concat(st_fname, ' ', st_lname) 
		from student
	return 
end

select * from getStudents('fullName')














