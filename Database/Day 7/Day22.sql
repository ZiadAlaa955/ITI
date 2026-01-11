use ITI

declare @x int=(select avg(st_age) from Student)

set @x=10

select @x=100


select @x

declare @y int
	select @y=st_age from Student
	where st_id=-1
select @y


declare @y int
	select @y=st_age from Student
	where st_address='cairo'
select @y

--Arrays   --variable table
declare @t table(col1 int) ---> 1D array of integers
	insert into @t
	values(5),(7),(10)
select * from @t
select count(*) from @t


declare @t table(col1 int) ---> 1D array of integers
	insert into @t
	select st_age from Student where st_address='cairo'
select * from @t
select count(*) from @t

declare @t table(col1 int,col2 varchar(20)) ---> 2D array 
	insert into @t
	select st_age,st_fname from Student where st_address='cairo'
select * from @t
select count(*) from @t

declare @x int,@name varchar(20)
	select @x=st_age, @name=st_fname from Student
	where st_id=1
select @x,@name

declare @s int
	update Instructor
		set ins_name='omar' , @s=salary
	where ins_id=1
select @s

--dynamic queries

declare @par int=5

select * from Student 
where st_id=@par

declare @par int=5

select top(@par)*
from Student

--metadata
declare @col varchar(10)='salary',@t varchar(20)='instructor'
execute('select '+@col+' from '+@t)

declare @col varchar(10)='*',@t varchar(20)='instructor',@cond varchar(20)='salary>1000'
execute('select '+@col+' from '+@t+' where '+@cond)


select 'select * from student'
execute('select * from student')

---->Global

select @@SERVERNAME

select @@VERSION

update Student set st_age+=1
select @@ROWCOUNT

select * from Student where st_age>25
select @@ROWCOUNT
select @@ROWCOUNT

select * from Student where st_age>25
go
select @@ERROR

select @@identity

---------------------------------------------
--control of flow statements
--if
declare @x int
	update Instructor set Salary+=100
select @x=@@ROWCOUNT
if @x>0
	begin
		select 'multi rows affected'
		select 'welcome to ITI'
	end
else 
	begin
		select 'zero rows affected'
	end



--begin end
--if exists   if not exists

if exists(select name from sys.tables where name='students')
	select 'table is existed'
else
	create table students
	(
	id int,
	name varchar(20)
	)


if not exists(select top_id from course where top_id=10)
	delete from topic where top_id=10
else
	select 'table has relationship'

begin try
		delete from topic where top_id=1
end try
begin catch
	select ERROR_LINE(),ERROR_MESSAGE(),ERROR_NUMBER()
end catch

--while
declare @x int=10
while @x<=20
	begin
		set @x+=1
		if @x=14
			continue
		if @x=16
			break
		select @x
	end







--continue break
--case iif
select ins_name,salary,
              case
			     when salary>=5000 then 'high salary'
				 when Salary<5000 then 'low'
				 else 'No data'
			  end as Xcol
from Instructor

select ins_name ,iif(salary>=5000,'high','low')
from Instructor

update Instructor
	set Salary=Salary*1.20
	
update Instructor
	set Salary=
				case
					when salary>=5000 then Salary*1.20
					else Salary*1.10
				end


--choose
--waitfor
-----funtions
--user defined function

---scalar
--function   Fun_name   Parameters   -return    --body
alter function getsname(@sid int) returns varchar(30)
	begin
		declare @name varchar(30)
			select @name=st_fname from Student
			where st_id=@sid
		return @name
	end

--calling
select dbo.getsname(4)
alter schema hr transfer getsname
select hr.getsname(1)
alter schema dbo transfer hr.getsname

drop function getsname


---inline
create function getists(@did int)
returns table
as
	return
	(
	  select ins_name, salary*12 as annualsal
	  from Instructor
	  where Dept_Id=@did
	)

	--calling
	select * from getists(10)
	select ins_name from getists(10)
	select sum(annualsal) from getists(10)

---multi
create function getstuds(@format varchar(20))
returns @t table
           (
		    id int,
			sname varchar(20)
		   )
as
	begin
		if @format='first'
			insert into @t
			select st_id,st_fname from Student
		else if @format='last'
			insert into @t
			select st_id,st_lname from Student
		else if @format='fullname'
			insert into @t
			select st_id,concat(st_fname,'',st_lname) from Student
		return 
	end

--calling
select * from getstuds('first')

--Builtin
--NULL
select isnull(st_fname,'')
from Student

coalesce

--data conversion
select convert(varchar(30),getdate())
select cast(getdate() as varchar(30))

select convert(varchar(30),getdate(),101)
select convert(varchar(30),getdate(),102)
select convert(varchar(30),getdate(),103)
select convert(varchar(30),getdate(),104)
select convert(varchar(30),getdate(),105)

select format(getdate(),'dd-MM-yyyy')
select format(getdate(),'dddd MMMM yyyy')
select format(getdate(),'ddd MMM yy')
select format(getdate(),'dddd')
select format(getdate(),'MMMM')
select format(getdate(),'hh:mm:ss')
select format(getdate(),'hh')
select format(getdate(),'hh tt')

select format(getdate(),'yyyy')  --return string
select year(getdate()) --return int

select eomonth(getdate())
select format(eomonth(getdate()),'dd')
select format(eomonth(getdate()),'dddd')

select eomonth(getdate(),+2)
select eomonth(getdate(),-1)

--system function

select db_name()

select SUSER_SNAME()

select SCOPE_IDENTITY()

select IDENT_CURRENT('test')

select OBJECT_ID('student')

select OBJECT_ID('exam')

if OBJECT_ID('exam') is null
	select 'obj is not exists'

--aggregate
--date
--math
sin cos tan log power sqrt abs

--logical
select isdate('1/1/2000')

select isnumeric('434')

--string
concat
concat_ws

upper   lower   len   substring

select substring(st_fname,3,3)
from Student

select CHARINDEX('x','mohamed')

select CHARINDEX('a',st_fname)
from Student

select replace('ahmed$gmail.com','$','@')

select stuff('ahmedomarkhalid',6,4,'ali')


select top(1) st_fname
from student
order by len(st_fname) desc
























































