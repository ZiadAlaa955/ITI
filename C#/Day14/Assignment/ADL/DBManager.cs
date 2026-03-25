using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class DBManager
    {
        SqlConnection sqlcn;
        SqlCommand sqlcmd;
        SqlDataAdapter sqlDA;

        public DBManager()
        {
            try
            {
                sqlcn = new SqlConnection();
                sqlcn.ConnectionString = ConfigurationManager.ConnectionStrings["PubsCN"].ConnectionString;
                sqlcmd = new SqlCommand(string.Empty, sqlcn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlDA = new SqlDataAdapter(sqlcmd);
            }
            catch { }
        }

        public int ExecuteNonQuery(string SPName, Dictionary<string, object> Parameters)
        {
            try
            {
                sqlcmd.Parameters.Clear();
                sqlcmd.CommandText = SPName;

                foreach (var param in Parameters)
                    sqlcmd.Parameters.Add(new SqlParameter(param.Key, param.Value ?? DBNull.Value));

                if (sqlcn.State != ConnectionState.Open) sqlcn.Open();
                return sqlcmd.ExecuteNonQuery();
            }
            catch { return -1; }
            finally { sqlcn.Close(); }
        }
        public object ExecuteScalar(string SPName)
        {
            try
            {
                sqlcmd.Parameters.Clear();
                sqlcmd.CommandText = SPName;

                if (sqlcn.State != ConnectionState.Open)
                    sqlcn.Open();

                return sqlcmd.ExecuteScalar();
            }
            catch
            {

            }
            finally
            {
                sqlcn.Close();
            }
            return new();
        }
        public DataTable ExecuteDataTable(string SPName)
        {
            DataTable dt = new DataTable();
            try
            {
                sqlcmd.Parameters.Clear();
                sqlcmd.CommandText = SPName;
                sqlDA.Fill(dt);
            }
            catch { }
            return dt;
        }
    }
}

