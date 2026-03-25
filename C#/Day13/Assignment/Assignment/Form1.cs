using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace Assignment
{
    public partial class Form1 : Form
    {
        SqlConnection sqlCn;
        SqlCommand sqlCmd;
        SqlDataAdapter dataAdapter;
        DataTable dtEmployees = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCn = new();
            sqlCn.ConnectionString = ConfigurationManager.ConnectionStrings["pubsCN"].ConnectionString;
            sqlCmd = new("Select * from employee", sqlCn);

            dataAdapter = new SqlDataAdapter(sqlCmd);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
            dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataAdapter.Fill(dtEmployees); //Open sqlCn, Execute command,fill table with data, close connection

            EmployeeGridView.DataSource = dtEmployees; //Simple Data Binding
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dtEmployees.Rows)
            {
                Trace.WriteLine(row.RowState);
            }

            dataAdapter.Update(dtEmployees); //commit changes into DB from tdEmployees
        }
    }
}
