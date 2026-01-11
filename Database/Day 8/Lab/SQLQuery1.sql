use ITI

--PART 1
--1.Create a view that displays student full name, course name if the student has a grade more than 50. 
create view viewStident
as
select 
	st_fname + ' ' + st_lname as [full name], crs_name
from student s join Stud_Course sc
	on s.st_id = sc.St_Id
join course c
	on sc.Crs_Id = c.Crs_Id
where grade > 50


--2.Create an Encrypted view that displays manager names and the topics they teach. 
create view viewManager
with encryption
as
select ins_name, top_name
from department d join instructor i 
	on d.Dept_Manager = i.ins_id
join Ins_Course ic
	on i.ins_id = ic.ins_id
join course c
	on c.crs_id = ic.Crs_Id
join topic t 
	on t.Top_Id = c.Top_Id


--3.Create a view that will display Instructor Name, Department Name for the ‘SD’ or ‘Java’ Department 
create view viewSD_JavaDepartment
as
select ins_name, dept_name
from instructor i join department d
	on d.Dept_Id = i.Dept_Id
where Dept_Name in ('SD', 'Java')


--4.Create a view “V1” that displays student data for student who lives in Alex or Cairo. 
create view v1
as
select * from student 
where St_Address in ('Cairo', 'Alex')
with check option ;


--5.Create a view that will display the project name and the number of employees work on it. “Use SD database”
use SD
create view view_project_employees
as
select count(empNo) as employees_count, projectName
from Company.project p join dbo.Works_on w
	on p.ProjectNo = w.ProjectNo
group by p.ProjectName;


--6.Create index on column (Hiredate) that allow u to cluster the data in table Department. What will happen?
use ITI
create clustered index hiredateIndex 
on department (manager_hiredate) 
--Error: there is an existing clustered index -> dept_id(pk) 


--7.Create index that allow u to enter unique ages in student table. What will happen? 
create unique index studentsAgesIndex
on student (st_age)
--Error: ages not unique [duplicate key]


--8.Using Merge statement between the following two tables [User ID, Transaction Amount]
use SD
create table lastTransations (
	userID int primary key,
	transactionAmount int
)
create table dailyTransations (
	userID int primary key,
	transactionAmount int
)


insert into lastTransations (UserID, TransactionAmount)
values 
(1, 1000), 
(2, 2000), 
(3, 3000)


insert into dailyTransations (UserID, TransactionAmount)
values 
(1, 4000), 
(4, 2000), 
(2, 10000)


merge into lastTransations as T 
using dailyTransations as S
on T.userID = S.userID
when matched then 
	update 
		set T.transactionAmount = S.transactionAmount
when not matched then
	insert
	values(S.userID, S.transactionAmount);

select * from lastTransations

--------------------------------------------------------
--PART 2
use SD
--1)Create view named “v_clerk” that will display employee#,project#, the date of hiring of all the jobs of the type 'Clerk'.
create view v_clerk
As
select 
	empNo as [#employee],
	projectNo as [#project],
	enter_date as [date of hiring]
from Works_on
where job = 'Clerk'


--2) Create view named  “v_without_budget” that will display all the projects data without budget
create view v_without_budget
as 
select projectNo, projectName
from Company.Project
where Company.Project.Budget = NULL


--3)Create view named  “v_count “ that will display the project name and the # of jobs in it
create view v_count 
as
select projectName, count(job) as [#jobs]
from Company.project p join dbo.Works_on w
	on p.ProjectNo = w.ProjectNo
group by p.ProjectName


--4)Create view named ” v_project_p2” that will display the emp#  for the project# ‘p2’ use the previously created view  “v_clerk”
create view v_project_p2
as 
select [#employee]
from v_clerk
where [#project] = 'p2'


--5)modifey the view named  “v_without_budget”  to display all DATA in project p1 and p2 
Alter view v_without_budget
as 
select * from Company.Project
where projectNo in ('p1', 'p2') 


--6)Delete the views  “v_ clerk” and “v_count”
drop view v_clerk
drop view v_count


--7)Create view that will display the emp# and emp lastname who works on dept# is ‘d2’
create view d2Employees 
as
select empNo, empLname
from [Human Resources].Employee
where deptNo = 'd2'


--8)Display the employee  lastname that contains letter “J” Use the previous view created in Q#7
select empLname 
from d2Employees 
where empLname like '%j%'


--9)Create view named “v_dept” that will display the department# and department name.
create view v_dept
as
select deptNo, deptName
from Company.Department


--10)using the previous view try enter new department data where dept# is ’d4’ and dept name is ‘Development’
insert into v_dept 
values('d4', 'Development’')


--11)Create view name “v_2006_check” that will display employee#, the project #where he works and the date of joining the project which must be from the first of January and the last of December 2006.
create view v_2006_check
as
select empNo, projectNo, Enter_date
from Works_on
where Enter_date between '2006-01-01' AND '2006-12-31'


