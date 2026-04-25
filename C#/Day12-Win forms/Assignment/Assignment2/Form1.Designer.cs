namespace Assignment2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnOpen = new Button();
            btnSave = new Button();
            btnClose = new Button();
            btnFont = new Button();
            btnColor = new Button();
            btnCust = new Button();
            rtfTxt = new RichTextBox();
            dlgColor = new ColorDialog();
            dlgFont = new FontDialog();
            dlgOpen = new OpenFileDialog();
            dlgSave = new SaveFileDialog();
            SuspendLayout();
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(41, 31);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(94, 29);
            btnOpen.TabIndex = 0;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top;
            btnSave.Location = new Point(336, 31);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Location = new Point(654, 31);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnFont
            // 
            btnFont.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFont.Location = new Point(41, 491);
            btnFont.Name = "btnFont";
            btnFont.Size = new Size(94, 29);
            btnFont.TabIndex = 3;
            btnFont.Text = "Font";
            btnFont.UseVisualStyleBackColor = true;
            btnFont.Click += btnFont_Click;
            // 
            // btnColor
            // 
            btnColor.Anchor = AnchorStyles.Bottom;
            btnColor.Location = new Point(336, 491);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(94, 29);
            btnColor.TabIndex = 4;
            btnColor.Text = "Color";
            btnColor.UseVisualStyleBackColor = true;
            btnColor.Click += btnColor_Click;
            // 
            // btnCust
            // 
            btnCust.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCust.Location = new Point(654, 491);
            btnCust.Name = "btnCust";
            btnCust.Size = new Size(94, 29);
            btnCust.TabIndex = 5;
            btnCust.Text = "Cust";
            btnCust.UseVisualStyleBackColor = true;
            btnCust.Click += button6_Click;
            // 
            // rtfTxt
            // 
            rtfTxt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtfTxt.Location = new Point(41, 84);
            rtfTxt.Name = "rtfTxt";
            rtfTxt.Size = new Size(707, 382);
            rtfTxt.TabIndex = 6;
            rtfTxt.Text = "";
            // 
            // dlgOpen
            // 
            dlgOpen.FileName = "openFileDialog1";
            dlgOpen.InitialDirectory = "D:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(rtfTxt);
            Controls.Add(btnCust);
            Controls.Add(btnColor);
            Controls.Add(btnFont);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(btnOpen);
            Name = "Form1";
            Text = " ";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnOpen;
        private Button btnSave;
        private Button btnClose;
        private Button btnFont;
        private Button btnColor;
        private Button btnCust;
        private RichTextBox rtfTxt;
        private ColorDialog dlgColor;
        private FontDialog dlgFont;
        private OpenFileDialog dlgOpen;
        private SaveFileDialog dlgSave;
    }
}
