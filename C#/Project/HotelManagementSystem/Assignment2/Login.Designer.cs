namespace Assignment2
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            topTealBar = new Panel();
            lblTitle = new Label();
            usernameLabel = new Label();
            passwordLabel = new Label();
            signinButton = new Button();
            LicenseCallButton = new Button();
            lblClose = new Label();
            pnlUser = new Panel();
            usernameTextBox = new TextBox();
            picUser = new PictureBox();
            pnlPass = new Panel();
            passwordTextBox = new TextBox();
            picPass = new PictureBox();
            pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picUser).BeginInit();
            pnlPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPass).BeginInit();
            SuspendLayout();

            topTealBar.BackColor = Color.LightSeaGreen;
            topTealBar.Dock = DockStyle.Top;
            topTealBar.Location = new Point(0, 0);
            topTealBar.Size = new Size(686, 7);
            topTealBar.MouseDown += Form_MouseDown;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Light", 24F);
            lblTitle.Location = new Point(23, 27);
            lblTitle.Size = new Size(114, 54);
            lblTitle.Text = "Login";
            lblTitle.MouseDown += Form_MouseDown;

            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Segoe UI", 10F);
            usernameLabel.Location = new Point(217, 156);
            usernameLabel.Size = new Size(87, 23);
            usernameLabel.Text = "Username";

            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 10F);
            passwordLabel.Location = new Point(216, 251);
            passwordLabel.Size = new Size(80, 23);
            passwordLabel.Text = "Password";

            signinButton.BackColor = Color.FromArgb(235, 235, 235);
            signinButton.FlatAppearance.BorderColor = Color.LimeGreen;
            signinButton.FlatStyle = FlatStyle.Flat;
            signinButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            signinButton.Location = new Point(218, 383);
            signinButton.Size = new Size(272, 47);
            signinButton.Text = "Sign in";
            signinButton.UseVisualStyleBackColor = false;
            signinButton.Click += signinButton_Click_1;

            LicenseCallButton.BackColor = Color.FromArgb(235, 235, 235);
            LicenseCallButton.FlatAppearance.BorderColor = Color.LightGray;
            LicenseCallButton.FlatStyle = FlatStyle.Flat;
            LicenseCallButton.Location = new Point(594, 560);
            LicenseCallButton.Size = new Size(80, 37);
            LicenseCallButton.Text = "License";
            LicenseCallButton.UseVisualStyleBackColor = false;

            lblClose.AutoSize = true;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblClose.ForeColor = Color.Gray;
            lblClose.Location = new Point(646, 13);
            lblClose.Size = new Size(30, 32);
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            lblClose.MouseEnter += lblClose_MouseEnter;
            lblClose.MouseLeave += lblClose_MouseLeave;

            pnlUser.BackColor = Color.White;
            pnlUser.Controls.Add(usernameTextBox);
            pnlUser.Controls.Add(picUser);
            pnlUser.Location = new Point(218, 185);
            pnlUser.Size = new Size(272, 48);
            pnlUser.Paint += DrawBlueBorder;

            usernameTextBox.BorderStyle = BorderStyle.None;
            usernameTextBox.Font = new Font("Segoe UI", 12F);
            usernameTextBox.ForeColor = Color.Gray;
            usernameTextBox.Location = new Point(43, 9);
            usernameTextBox.Size = new Size(217, 27);
            usernameTextBox.Text = "Username";
            usernameTextBox.TextChanged += usernameTextBox_TextChanged;

            picUser.Location = new Point(6, 7);
            picUser.Size = new Size(30, 35);
            picUser.SizeMode = PictureBoxSizeMode.Zoom;

            pnlPass.BackColor = Color.White;
            pnlPass.Controls.Add(passwordTextBox);
            pnlPass.Controls.Add(picPass);
            pnlPass.Location = new Point(218, 280);
            pnlPass.Size = new Size(272, 48);
            pnlPass.Paint += DrawBlueBorder;

            passwordTextBox.BorderStyle = BorderStyle.None;
            passwordTextBox.Font = new Font("Segoe UI", 12F);
            passwordTextBox.ForeColor = Color.Gray;
            passwordTextBox.Location = new Point(43, 9);
            passwordTextBox.Size = new Size(217, 27);
            passwordTextBox.Text = "Password";
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;

            picPass.Location = new Point(6, 7);
            picPass.Size = new Size(30, 35);
            picPass.SizeMode = PictureBoxSizeMode.Zoom;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(686, 613);
            Controls.Add(lblClose);
            Controls.Add(topTealBar);
            Controls.Add(lblTitle);
            Controls.Add(LicenseCallButton);
            Controls.Add(pnlPass);
            Controls.Add(passwordLabel);
            Controls.Add(pnlUser);
            Controls.Add(usernameLabel);
            Controls.Add(signinButton);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            MouseDown += Form_MouseDown;
            pnlUser.ResumeLayout(false);
            pnlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picUser).EndInit();
            pnlPass.ResumeLayout(false);
            pnlPass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPass).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Panel topTealBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button signinButton;
        private System.Windows.Forms.Button LicenseCallButton;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Panel pnlPass;
        private System.Windows.Forms.PictureBox picPass;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label lblClose;
    }
}