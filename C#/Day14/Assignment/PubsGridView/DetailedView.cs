using BLL.Entities;
using BLL.EntityList;
using BLL.EntityManager;

namespace PubsGridView
{
    public partial class DetailedView : Form
    {
        BindingSource empBindingSource;
        BindingSource jobBindingSource;
        BindingNavigator empBindingNavigator;
        public DetailedView()
        {
            InitializeComponent();
        }

        private void DetailedView_Load(object sender, EventArgs e)
        {
            // Load Data
            EmployeeList Emps = EmployeeManager.SelectAllEmployees();
            JobList Jobs = JobManager.SelectAllJobs();

            empBindingSource = new BindingSource(Emps, "");
            jobBindingSource = new BindingSource(Jobs, "");

            empBindingSource.AddingNew += (sender, e) =>
                e.NewObject = new Employee()
                {
                    EmpId = "AAA11111M",
                    Fname = "New",
                    Lname = "Employee",
                    JobId = 1,
                    PubId = "0877",
                    HireDate = DateTime.Now,
                    State = EntitySate.Added
                };

            // Navigator
            empBindingNavigator = new BindingNavigator(empBindingSource);
            empBindingNavigator.Dock = DockStyle.Top;
            this.Controls.Add(empBindingNavigator);

            //EMPLOYEE DROPDOWN 
            cmbEmployeeId.DataSource = empBindingSource;
            cmbEmployeeId.DisplayMember = "EmpId";

            // Employee
            txtFname.DataBindings.Add("Text", empBindingSource, "Fname");
            txtLname.DataBindings.Add("Text", empBindingSource, "Lname");
            txtMinit.DataBindings.Add("Text", empBindingSource, "Minit");

            textjobID.DataBindings.Add("Text", empBindingSource, "JobId");
            txtJobLvl.DataBindings.Add("Text", empBindingSource, "JobLvl", true);
            txtPubId.DataBindings.Add("Text", empBindingSource, "PubId");
            txtHireDate.DataBindings.Add("Text", empBindingSource, "HireDate", true, DataSourceUpdateMode.OnValidation, "", "d");

            // Job 
            cmbJobDesc.DataSource = jobBindingSource;
            cmbJobDesc.DisplayMember = "JobDesc";
            cmbJobDesc.ValueMember = "JobId";
            cmbJobDesc.DataBindings.Add("SelectedValue", empBindingSource, "JobId");

            txtMinLvl.DataBindings.Add("Text", jobBindingSource, "MinLvl");
            txtMaxLvl.DataBindings.Add("Text", jobBindingSource, "MaxLvl");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            empBindingSource.EndEdit();

            EmployeeList currentList = (EmployeeList)empBindingSource.DataSource;

            if (EmployeeManager.SaveChanges(currentList))
            {
                this.Text = "Saved"; 
                MessageBox.Show("All changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Some changes failed to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
