create table test
(
	ID int,
	St_name varchar(50)
)

--insert with top
insert into test 
select top (3) st_id, st_fname
from Student

insert top(3) into test 
select st_id, st_fname
from Student

--update with top
update top(2) department
set Dept_Location = 'Alex'

--Delete with top
delete top(2) from test

--delete 25% from the data
delete top(25) percent
from test


