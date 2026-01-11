use ITI

---(1)
select count(*) 
from student 
where st_age is not null

---(2)
select distinct Ins_Name 
from Instructor

---(3)
select St_Id , ISNULL(CONCAT(St_Fname , ' ' ,St_Lname) , 'None') as [Full Name] , ISNULL(Dept_Name , 'None')
from Student s left outer join Department d
on s.Dept_Id = d.Dept_Id

---(4)
select Ins_Name , Dept_Name
from Instructor left outer join Department
on Ins_Id = Dept_Manager

---(5)
select CONCAT(St_Fname ,' ' , St_Lname) as [Full Nmae] , Crs_Name
from student s inner join Stud_Course sc
on s.St_Id = sc.St_Id
inner join course c
on c.Crs_Id = sc.Crs_Id 
where sc.Grade is not null 

---(6)
select Top_Name , count(Crs_Id) as [num of courses]
from topic t inner join course c
on t.Top_Id = c.Top_Id
group by Top_Name

---(7)
select max(salary) as [max salary] , min(salary) as [min salary]
from Instructor

---(8)
select Ins_Name , salary 
from Instructor
where salary < (select avg(salary) from Instructor)

---(9)
select dept_name
from Department inner join Instructor
on Dept_Manager = Ins_Id
where Salary = (select min(salary) from Instructor)


---(10)
select salary 
from Instructor
where salary = (select max(salary) from Instructor) or salary = (select max(salary) from Instructor where salary < (select max(salary) from Instructor ))
order by Salary desc
--OR
select top 2 Salary
from instructor
order by Salary desc

---(11)
--I don't know what is "bonus keyword"
select Ins_Name , coalesce( Convert(varchar,salary) , 'No Data') as Salary 
from Instructor

---(12)
select avg(salary) as avgSalary
from Instructor

---(13)
select st.St_Fname , sp.*
from student st inner join student sp
on st.St_super = sp.St_Id

---(14)
select dept_id , salary
from( select * , dense_rank() over(partition by dept_id order by salary desc) as DN
from Instructor) as newTable
where DN = 1 or DN = 2

---(15)
select st_fname , Dept_Id
from( select st_fname , Dept_Id , row_number() over(partition by Dept_Id order by NEWID()) as RN
from Student  
) as newtable
where RN = 1


