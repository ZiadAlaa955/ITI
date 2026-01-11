--Create sequence------------
create sequence mySequence
	start with 1			-->first number is 1
	increment by 1			-->count up by 1
	minValue 1				-->Cannot be below 1
	maxValue 5				-->limit is 5
							-->when hits 5 ==> next number will be 1
	Cycle					-->default 

--check status--------------
select name, minimum_value, maximum_value, current_value, is_cycling
from sys.sequences
where name = 'mySequence'

--using the sequence--------------
create table person1 (ID int, fullName varchar(50) not null)
create table person2 (ID int, fullName varchar(50) not null)

insert into person1 values (next value for mySequence, 'Nada')
insert into person2 values (next value for mySequence, 'Ahmed')

select * from person1
select * from person2

--update & defaults--------------
update person1
set id = next value for mySequence
where id = 1

alter table person1
add default next value for mySequence for ID -->Instead of type "next value for mySequen" every time

insert into person1 (fullName) values ('Ziad')
--Restart & Delete-----------------
alter sequence mySequence 
	restart with 1

drop sequence mySequence
