using BLL.Entities;
using BLL.EntityList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAL;

namespace BLL.EntityManager
{
    public static class JobManager
    {
        public static DBManager Manager = new();

        public static JobList SelectAllJobs()
        {
            return DataTableToJobList(Manager.ExecuteDataTable("GetAllJobs"));
        }

        internal static JobList DataTableToJobList(DataTable dt)
        {
            JobList jobs = new JobList();
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    jobs.Add(DataRowToJob(item));
                }
            }
            return jobs;
        }

        internal static Job DataRowToJob(DataRow Dr)
        {
            Job j = new() { JobId = 0, JobDesc = "" };
            j.JobId = Dr.Field<short>("job_id");
            j.JobDesc = Dr.Field<string>("job_desc") ?? "NA";
            j.MinLvl = Dr.Field<byte>("min_lvl");
            j.MaxLvl = Dr.Field<byte>("max_lvl");

            j.State = EntitySate.UnChanged;
            return j;
        }
    }
}
