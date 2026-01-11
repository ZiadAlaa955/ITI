use ITI
--Declare variable & assign value into it
declare @x int = 10
set @x = 20
select @x = 100
select @x as currentValue

--Assign values from table
Declare @avg_age int
select @avg_age = avg(st_age) from student
select @avg_age as AverageAge

--query retun NULL
Declare @y int

select @y = st_age
from student
where st_id = -1

select @y 

--Query return multiple rows ==> variable will hold last value
Declare @z int

select @z = st_age
from student
where St_Address = 'Cairo'

select @z

--Scalar variable assignment
declare @x int, @name varchar(20)

select @x = st_age, @name  = st_fname
from student
where st_id = 1

select @x as age, @name as Name

--Assignment during update
declare @savedSalary int
update instructor
set ins_name = 'omar', @savedSalary = salary
where ins_id = 1

select @savedSalary


--Dynamic queries
declare @parameter int = 5

select * from student
where st_id = @parameter

select top(@parameter) *
from student

--metadata-------------------
Select 'select * from student'    -->just display the string 

execute ('select * from student') -->translate string into statement 

--Dynamic column & tables
declare @columnName varchar(10) = 'Salary',
@tableName varchar(20) = 'Instructor'

execute('Select '+ @columnName + ' from ' + @tableName)

--Dynamic conditions 
declare @columnName2 varchar(10) = '*',
@tableName2 varchar(20) = 'Instructor',
@condition varchar(20) = 'Salary > 1000'

execute('select ' + @columnName2 + ' from ' + @tableName2 + ' where ' + @condition)



