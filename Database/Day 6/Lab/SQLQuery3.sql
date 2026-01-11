--9.Try to Create Login Named(ITIStud) who can access Only student and Course tablesfrom ITI DB then allow him to select and insert data into tables and deny Delete and update .(Use ITI DB)
select * from hr.Student

delete from dbo.Course 
where crs_id = 100   ---error => no permession