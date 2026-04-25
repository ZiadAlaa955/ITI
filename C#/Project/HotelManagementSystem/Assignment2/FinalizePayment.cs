using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace Assignmint2
{
    public partial class FinalizePayment : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FinalizePayment()
        {
            InitializeComponent();

            // Set placeholders
            AddPlaceholderManager(txtCardNumber, "9999 - 9999 - 9999 - 9999");
            AddPlaceholderManager(txtCVC, "CVC");
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

        public string SelectedPaymentType => cmbPaymentType.Text;
        public string CardNumber => txtCardNumber.Text;
        public string CardExp => $"{cmbMonth.Text}/{cmbYear.Text}";
        public string CardCvc => txtCVC.Text;
        public string CardType => lblCardTypeValue.Text;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double FinalTotalBill { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ReservationCost { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double FoodCost { get; set; }
        private void FinalizePayment_Load(object sender, EventArgs e)
        {
            cmbPaymentType.Items.AddRange(new string[] { "Credit Card", "Debit Card", "PayPal", "Apple Pay", "Google Pay" });
            cmbMonth.Items.AddRange(new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" });
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear; i <= currentYear + 10; i++)
            {
                cmbYear.Items.Add(i.ToString().Substring(2));
            }

            double currentBill = ReservationCost + FoodCost;
            double taxAmount = currentBill * 0.10; 
            double totalBill = currentBill + taxAmount;

            lblValRes.Text = "$" + ReservationCost.ToString("0.00");
            lblValFood.Text = "$" + FoodCost.ToString("0.00");
            lblValCurrent.Text = "$" + currentBill.ToString("0.00");
            lblValTax.Text = "$" + taxAmount.ToString("0.00");
            lblValTotal.Text = "$" + totalBill.ToString("0.00");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cmbPaymentType.Text == "Payment type" || cmbMonth.Text == "MM" ||cmbYear.Text == "YY" ||txtCardNumber.Text == "9999 - 9999 - 9999 - 9999" || string.IsNullOrWhiteSpace(txtCardNumber.Text) ||txtCVC.Text == "CVC" || string.IsNullOrWhiteSpace(txtCVC.Text)) 
            {
                MessageBox.Show("Please fill in all payment details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}