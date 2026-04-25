--ServerName
Select @@SERVERNAME as serverName


--SQL version 
select @@VERSION as SQLVersion

--count of rows from last statement
update student set st_age +=1
select @@ROWCOUNT as rowsAffected

select * from student where st_age > 25
select @@ROWCOUNT as firstCheck
select @@ROWCOUNT as secondCheck -->return 1 because of the firstCheck returns exactly 1 row

--Error status number
select * from student where st_age > 25
select @@ERROR as errorStatus

--identity tracking
select @@identity as lastCreatedID







