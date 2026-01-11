create database ITIsnap
on
(
	name = 'ITI',  --mdf name
	filename = 'D:\ITI\Database\MySnapShots\snap.ss'
)
as snapshot of ITI   --DB name


delete from student 
where st_id = 556

use ITI
select * from student

use ITIsnap
select * from student


