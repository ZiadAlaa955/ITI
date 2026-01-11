create schema HR
create schema Sales

alter schema HR transfer student
alter schema HR transfer instructor
alter schema Sales transfer department
create table student(
id int,
name varchar(50)
)

select * from hr.student