namespace Assignment2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            btnClose.Click += (sender, e) => this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dlgOpen.Filter = "Rich Text Files|*.rtf|Text Files|*.txt";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                switch (dlgOpen.FilterIndex)
                {
                    case 1:
                        rtfTxt.LoadFile(dlgOpen.FileName, RichTextBoxStreamType.RichText);
                        break;
                    case 2:
                        rtfTxt.LoadFile(dlgOpen.FileName, RichTextBoxStreamType.PlainText);
                        break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dlgSave.Filter = "Rich Text Files|*.rtf|Text Files|*.txt";
            dlgSave.InitialDirectory = "D:";

            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                rtfTxt.SaveFile(dlgSave.FileName, (RichTextBoxStreamType)(dlgSave.FilterIndex - 1));
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (rtfTxt.SelectedText?.Length > 0 && rtfTxt.SelectionFont != null)
                dlgFont.Font = rtfTxt.SelectionFont;

            if (dlgFont.ShowDialog() == DialogResult.OK)
                rtfTxt.SelectionFont = dlgFont.Font;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (rtfTxt.SelectedText?.Length > 0)
                dlgColor.Color = rtfTxt.SelectionColor;

            if (dlgColor.ShowDialog() == DialogResult.OK)
                rtfTxt.SelectionColor = dlgColor.Color;
        }
        
        dlgCust dlgCust = new(); 
        private void button6_Click(object sender, EventArgs e)
        {
            dlgCust.UserText = "Type Here";
            if(dlgCust.ShowDialog() == DialogResult.OK)
            {
                this.rtfTxt.AppendText(dlgCust.UserText.ToUpper());
            }
        }

    }
}
