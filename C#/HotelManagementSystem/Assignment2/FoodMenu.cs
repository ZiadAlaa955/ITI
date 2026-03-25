using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;
using Assignment2;

// Adjust the namespace below to match your project exactly! 
// Assignment2 vs Assignmint2
namespace Assignmint2
{
    public partial class FoodMenu : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FoodMenu()
        {
            InitializeComponent();

            // Load the beautiful food icons directly from the Resources file you just set up!
            // Note: If you named the project "Assignment2", change Assignmint2 below!
            if (Assignment2.Properties.Resources.breakfast != null) picBreakfast.Image = Assignment2.Properties.Resources.breakfast;
            if (Assignment2.Properties.Resources.lunch_new_png != null) picLunch.Image = Assignment2.Properties.Resources.lunch_new_png;
            if (Assignment2.Properties.Resources.Dinner_new_png != null) picDinner.Image = Assignment2.Properties.Resources.Dinner_new_png;

            // Set placeholders
            AddPlaceholderManager(txtQtyBreakfast, "Quantity ?");
            AddPlaceholderManager(txtQtyLunch, "Quantity ?");
            AddPlaceholderManager(txtQtyDinner, "Quantity ?");
        }

        private void AddPlaceholderManager(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (sender, e) => { if (textBox.Text == placeholder) { textBox.Text = ""; textBox.ForeColor = Color.Black; } };
            textBox.Leave += (sender, e) => { if (string.IsNullOrWhiteSpace(textBox.Text)) { textBox.Text = placeholder; textBox.ForeColor = Color.Gray; } };
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); }
        }

        private void lblClose_Click(object sender, EventArgs e) => this.Close();
        private void lblClose_MouseEnter(object sender, EventArgs e) => lblClose.ForeColor = Color.Red;
        private void lblClose_MouseLeave(object sender, EventArgs e) => lblClose.ForeColor = Color.Gray;

        private void DrawDashedBorder(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            using (Pen dashedPen = new Pen(Color.Gray, 1) { DashStyle = DashStyle.Dash })
            {
                e.Graphics.DrawRectangle(dashedPen, new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1));
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HasBreakfast { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BreakfastQty { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HasLunch { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LunchQty { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HasDinner { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DinnerQty { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NeedsCleaning { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NeedsTowels { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NeedsSurprise { get; set; }

        private void btnNext_Click(object sender, EventArgs e)
        {
            HasBreakfast = chkBreakfast.Checked;
            HasLunch = chkLunch.Checked;
            HasDinner = chkDinner.Checked;
            NeedsCleaning = chkCleaning.Checked;
            NeedsTowels = chkTowels.Checked;
            NeedsSurprise = chkSurprise.Checked;

            // 2. Safely grab the quantities (If it's checked but they didn't type a number, default to 1)
            int bQty;
            BreakfastQty = (HasBreakfast && int.TryParse(txtQtyBreakfast.Text, out bQty)) ? bQty : (HasBreakfast ? 1 : 0);

            int lQty;
            LunchQty = (HasLunch && int.TryParse(txtQtyLunch.Text, out lQty)) ? lQty : (HasLunch ? 1 : 0);

            int dQty;
            DinnerQty = (HasDinner && int.TryParse(txtQtyDinner.Text, out dQty)) ? dQty : (HasDinner ? 1 : 0);

            // 3. Send the Thumbs Up signal back to Frontend and close
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}