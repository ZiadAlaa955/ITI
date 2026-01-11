--Arrays ==> Table variables
--1D Array
Declare @myList table(val int)

insert into @myList values (5), (7), (10) --insert manually

insert into @myList
select st_age from Student where St_Address = 'Cairo'  --insert data from a query

select * from @myList

select count(*) as ArrayLength from @myList  --Array Length

--2D Array
Declare @my2DList table (
	age int, 
	name varchar(20)
)

insert into @my2DList
select st_age, st_fname
from student 
where St_Address = 'Cairo'

select * from @my2DList






