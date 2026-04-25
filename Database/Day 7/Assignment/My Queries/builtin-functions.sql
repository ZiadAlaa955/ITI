--Bulin-functions--------------
--1.Handling NULLs
select isNull(st_fname, '') from student

select coalesce(st_fname, st_lname, '') from student

--2.Data converstion
select getDate()
select cast(getDate() as varchar(30))

select convert(varchar(30), getDate(), 101) --us: mm/dd/yyyy
select convert(varchar(30), getDate(), 103) --British/Egypt: dd/mm/yyyy
select convert(varchar(30), getDate(), 104) --German: dd.mm.yyyy
select convert(varchar(30), getDate(), 105) --Italian: dd-mm-yyyy


--3.Format
select format(getdate(), 'dd-mm-yyyy')
select format(getdate(), 'dddd mmmm yyyy')
select format(getdate(), 'hh:mm:ss tt')
select format(getdate(), 'yyyy')
select year(getDate())

--4.Eomonth
select eomonth(getdate())
select EOMONTH(GETDATE(), -1)
select EOMONTH(GETDATE(), +2)
SELECT FORMAT(EOMONTH(GETDATE()), 'dddd')


--5.string functions
select concat(st_fname, ' ', st_lname) from student

select CONCAT_WS('-','USA','Cairo', 'Alex')

select SUBSTRING(st_fname, 1, 3) from student

select CHARINDEX('a', 'Ahmed') 
select CHARINDEX('x', 'Ahmed') 

select replace('Ziad&gmail.com','&','@')

select stuff('ZiadAlaa', 5,4,'Ezzat')

select upper(st_fname), lower(st_lname), LEN(st_fname) from student


--system functions
select DB_name()
select SUSER_NAME()

if OBJECT_ID('exam') is null
	select 'Table does not exist'
else 
	select OBJECT_ID('exam')

select SCOPE_IDENTITY()

select IDENT_CURRENT('student')



--Logical functions
select isDate('2025-01-01')
select isDate('Hello')

select ISNUMERIC('123')
select ISNUMERIC('123a')