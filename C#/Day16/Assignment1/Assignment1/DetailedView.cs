using Assignment1.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class DetailedView : Form
    {
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            context?.Dispose();
        }

        PubsContext context;

        BindingSource bsEmployees;
        BindingSource bsJobs;
        public DetailedView()
        {
            InitializeComponent();
        }

        private void DetailedView_Load(object sender, EventArgs e)
        {
            {
                context = new PubsContext();

                context.Employees.Load();
                context.Jobs.Load();

                bsJobs = new BindingSource(context.Jobs.Local.ToBindingList(), "");
                bsEmployees = new BindingSource(context.Employees.Local.ToBindingList(), "");

                #region Employee Dropdownlist
                cmbEmployeeId.DataSource = bsEmployees;
                cmbEmployeeId.DisplayMember = "EmpId";
                #endregion

                #region Employee TextBoxes
                txtFname.DataBindings.Add("Text", bsEmployees, "FirstName");
                txtLname.DataBindings.Add("Text", bsEmployees, "LastName");
                txtMinit.DataBindings.Add("Text", bsEmployees, "MiddleInitial");
                txtJobLvl.DataBindings.Add("Text", bsEmployees, "JobLevel", true);
                txtPubId.DataBindings.Add("Text", bsEmployees, "PubId");
                txtHireDate.DataBindings.Add("Text", bsEmployees, "HireDate", true, DataSourceUpdateMode.OnValidation, "", "d");
                textjobID.DataBindings.Add("Text", bsEmployees, "JobId");
                #endregion

                #region Job DropDwonList
                cmbJobDesc.DataSource = bsJobs;
                cmbJobDesc.DisplayMember = "JobDesc";
                cmbJobDesc.ValueMember = "JobId";
                #endregion

                #region Job TextBoxes
                cmbJobDesc.DataBindings.Add("SelectedValue", bsEmployees, "JobId");
                txtMinLvl.DataBindings.Add("Text", bsJobs, "MinLvl");
                txtMaxLvl.DataBindings.Add("Text", bsJobs, "MaxLvl");
                #endregion

                #region Navigator
                BindingNavigator bindingNavigator = new BindingNavigator(bsEmployees);
                bindingNavigator.Dock = DockStyle.Top;
                this.Controls.Add(bindingNavigator);
                #endregion
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bsEmployees.EndEdit();

            this.Text = $"{context.SaveChanges()}";
        }
    }
}
