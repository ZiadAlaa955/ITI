using BLL.Entities;
using BLL.EntityList;
using System.Data;
using DAL;

namespace BLL.EntityManager
{
    public static class EmployeeManager
    {
        public static DBManager Manager = new();

        public static EmployeeList SelectAllEmployees()
        {
            return DataTableToEmployeeList(Manager.ExecuteDataTable("GetAllEmployees"));
        }

        public static bool SaveChanges(EmployeeList employees)
        {
            bool allSaved = true;
            try
            {
                foreach (Employee emp in employees)
                {
                    if (emp.State == EntitySate.Modified)
                    {
                        Dictionary<string, object> Parameters = new()
                        {
                            ["@emp_id"] = emp.EmpId,
                            ["@fname"] = emp.Fname,
                            ["@minit"] = emp.Minit ?? (object)DBNull.Value,
                            ["@lname"] = emp.Lname,
                            ["@job_id"] = emp.JobId,
                            ["@job_lvl"] = emp.JobLvl ?? (object)DBNull.Value,
                            ["@pub_id"] = emp.PubId,
                            ["@hire_date"] = emp.HireDate
                        };

                        Manager.ExecuteNonQuery("UpdateEmployee", Parameters); // Requires UpdateEmployee Proc
                        emp.State = EntitySate.UnChanged;
                    }
                    else if (emp.State == EntitySate.Added)
                    {
                        Dictionary<string, object> Parameters = new()
                        {
                            ["@emp_id"] = emp.EmpId,
                            ["@fname"] = emp.Fname,
                            ["@minit"] = emp.Minit ?? (object)DBNull.Value,
                            ["@lname"] = emp.Lname,
                            ["@job_id"] = emp.JobId,
                            ["@job_lvl"] = emp.JobLvl ?? (object)DBNull.Value,
                            ["@pub_id"] = emp.PubId,
                            ["@hire_date"] = emp.HireDate
                        };

                        Manager.ExecuteNonQuery("InsertEmployee", Parameters);
                        emp.State = EntitySate.UnChanged;
                    }
                }
            }
            catch
            {
                allSaved = false;
            }
            return allSaved;
        }

        internal static EmployeeList DataTableToEmployeeList(DataTable dt)
        {
            EmployeeList Emps = new EmployeeList();
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Emps.Add(DataRowToEmployee(item));
                }
            }
            return Emps;
        }

        internal static Employee DataRowToEmployee(DataRow Dr)
        {
            Employee E = new() { EmpId = "", Fname = "", Lname = "", JobId = 0, PubId = "" };

            E.EmpId = Dr["emp_id"]?.ToString() ?? "NA";
            E.Fname = Dr["fname"]?.ToString() ?? "NA";
            E.Minit = Dr["minit"]?.ToString();
            E.Lname = Dr["lname"]?.ToString() ?? "NA";

            if (short.TryParse(Dr["job_id"].ToString(), out short jobId)) E.JobId = jobId;
            if (byte.TryParse(Dr["job_lvl"]?.ToString(), out byte jobLvl)) E.JobLvl = jobLvl; else E.JobLvl = null;

            E.PubId = Dr["pub_id"]?.ToString() ?? "NA";
            if (DateTime.TryParse(Dr["hire_date"]?.ToString(), out DateTime hireDate)) E.HireDate = hireDate;


            E.State = EntitySate.UnChanged;
            return E;
        }
    }
}
