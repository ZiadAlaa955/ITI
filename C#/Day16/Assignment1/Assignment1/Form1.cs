using Assignment1.Context;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Assignment1
{
    public partial class Form1 : Form
    {

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            context?.Dispose();
        }

        PubsContext context;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            context = new PubsContext();
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            context.Employees.Include(e => e.Job).Load();

            grdView.DataSource = context.Employees.Local.ToBindingList();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine(context.SaveChanges());
        }
    }
}
