using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DetailedView
{
    public partial class Form1 : Form
    {
        SqlConnection sqlCn;

        #region Adapters
        SqlDataAdapter daEmployees;
        SqlDataAdapter daJobs;
        #endregion

        #region Data Tables
        DataTable dtEmployees = new();
        DataTable dtJobs = new();
        #endregion

        #region Binding
        BindingSource bsEmployees;
        BindingSource bsJobs;
        BindingNavigator bindingNavigator; 
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Establish Connection to pub DB
            sqlCn = new SqlConnection(ConfigurationManager.ConnectionStrings["pubsCN"].ConnectionString);

            #region Jobs Setup
            //1. Load jobs table
            daJobs = new SqlDataAdapter("SELECT * FROM jobs", sqlCn);
            daJobs.Fill(dtJobs); 

            //2. Create bindingSource for jobs
            bsJobs = new BindingSource(dtJobs, "");
            #endregion

            #region Employee Setup
            //1. Load employee table
            daEmployees = new SqlDataAdapter("SELECT * FROM employee", sqlCn);
            daEmployees.Fill(dtEmployees);

            //2. Create BindingSource for Employees
            bsEmployees = new BindingSource(dtEmployees, "");

            //3. create command builder for insert, update and delete commands
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(daEmployees);
            #endregion

            #region Employee ID Dropdown
            //Automatically change current employee data on screen
            cmbEmployeeId.DataSource = bsEmployees; // simple data binding
            cmbEmployeeId.DisplayMember = "emp_id"; //Display employee id in dropdown list
            #endregion

            #region employee data binding
            txtFname.DataBindings.Add("Text", bsEmployees, "fname");
            txtMinit.DataBindings.Add("Text", bsEmployees, "minit");
            txtLname.DataBindings.Add("Text", bsEmployees, "lname");
            txtJobLvl.DataBindings.Add("Text", bsEmployees, "job_lvl");
            txtPubId.DataBindings.Add("Text", bsEmployees, "pub_id"); 
            textjobID.DataBindings.Add("Text", bsEmployees, "job_id");
            txtHireDate.DataBindings.Add("Text", bsEmployees, "hire_date", true, DataSourceUpdateMode.OnValidation, "", "d");
            #endregion

            #region Job description Dropdown
            cmbJobDesc.DataSource = bsJobs; //Simple Data binding
            cmbJobDesc.DisplayMember = "job_desc"; 
            cmbJobDesc.ValueMember = "job_id";
            #endregion

            #region Job data binding
            cmbJobDesc.DataBindings.Add("SelectedValue", bsEmployees, "job_id");
            txtMinLvl.DataBindings.Add("Text", bsJobs, "min_lvl");
            txtMaxLvl.DataBindings.Add("Text", bsJobs, "max_lvl");
            #endregion

            #region Navigator
            bindingNavigator = new BindingNavigator(bsEmployees);
            bindingNavigator.Dock = DockStyle.Top;
            this.Controls.Add(bindingNavigator);
            #endregion

            #region Save button
            btnSave.Click += btnSave_Click;
            #endregion
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            daEmployees.Update(dtEmployees);
            MessageBox.Show("Employee data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}