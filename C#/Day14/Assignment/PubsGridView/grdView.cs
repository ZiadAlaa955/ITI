using BLL.EntityList;
using BLL.EntityManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PubsUI
{
    public partial class grdView : Form
    {
        EmployeeList Emps;
        BindingSource empBindingSource;

        public grdView()
        {
            InitializeComponent();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Emps = EmployeeManager.SelectAllEmployees();
            empBindingSource = new BindingSource(Emps, "");

            dataGridView1.DataSource = empBindingSource;
            this.Text = "Employee Grid View Loaded";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            empBindingSource.EndEdit();

            if (EmployeeManager.SaveChanges(Emps))
            {
                this.Text = "Saved successfully!";
                MessageBox.Show("Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Text = "Failed to save.";
                MessageBox.Show("Some changes failed to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdView_Load(object sender, EventArgs e)
        {

        }
    }
}
