namespace Assignmint2
{
    partial class FoodMenu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            topBlueBar = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            lblClose = new System.Windows.Forms.Label();
            pnlFood = new System.Windows.Forms.Panel();
            lblFoodTitle = new System.Windows.Forms.Label();
            picBreakfast = new System.Windows.Forms.PictureBox();
            chkBreakfast = new System.Windows.Forms.CheckBox();
            txtQtyBreakfast = new System.Windows.Forms.TextBox();
            picLunch = new System.Windows.Forms.PictureBox();
            chkLunch = new System.Windows.Forms.CheckBox();
            txtQtyLunch = new System.Windows.Forms.TextBox();
            picDinner = new System.Windows.Forms.PictureBox();
            chkDinner = new System.Windows.Forms.CheckBox();
            txtQtyDinner = new System.Windows.Forms.TextBox();
            pnlSpecial = new System.Windows.Forms.Panel();
            lblSpecialTitle = new System.Windows.Forms.Label();
            chkCleaning = new System.Windows.Forms.CheckBox();
            chkTowels = new System.Windows.Forms.CheckBox();
            chkSurprise = new System.Windows.Forms.CheckBox();
            btnNext = new System.Windows.Forms.Button();
            pnlFood.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBreakfast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLunch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picDinner).BeginInit();
            pnlSpecial.SuspendLayout();
            SuspendLayout();

            topBlueBar.BackColor = System.Drawing.Color.DeepSkyBlue;
            topBlueBar.Dock = System.Windows.Forms.DockStyle.Top;
            topBlueBar.Location = new System.Drawing.Point(0, 0);
            topBlueBar.Size = new System.Drawing.Size(743, 7);
            topBlueBar.MouseDown += Form_MouseDown;

            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            lblTitle.Location = new System.Drawing.Point(17, 20);
            lblTitle.Size = new System.Drawing.Size(246, 46);
            lblTitle.Text = "Food and Menu";
            lblTitle.MouseDown += Form_MouseDown;

            lblClose.AutoSize = true;
            lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            lblClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblClose.ForeColor = System.Drawing.Color.Gray;
            lblClose.Location = new System.Drawing.Point(703, 13);
            lblClose.Size = new System.Drawing.Size(30, 32);
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            lblClose.MouseEnter += lblClose_MouseEnter;
            lblClose.MouseLeave += lblClose_MouseLeave;

            pnlFood.Controls.Add(lblFoodTitle);
            pnlFood.Controls.Add(picBreakfast);
            pnlFood.Controls.Add(chkBreakfast);
            pnlFood.Controls.Add(txtQtyBreakfast);
            pnlFood.Controls.Add(picLunch);
            pnlFood.Controls.Add(chkLunch);
            pnlFood.Controls.Add(txtQtyLunch);
            pnlFood.Controls.Add(picDinner);
            pnlFood.Controls.Add(chkDinner);
            pnlFood.Controls.Add(txtQtyDinner);
            pnlFood.Location = new System.Drawing.Point(23, 93);
            pnlFood.Size = new System.Drawing.Size(457, 560);
            pnlFood.Paint += DrawDashedBorder;

            lblFoodTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            lblFoodTitle.Location = new System.Drawing.Point(17, 20);
            lblFoodTitle.Size = new System.Drawing.Size(140, 31);
            lblFoodTitle.Text = "Food Selection";

            picBreakfast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picBreakfast.Location = new System.Drawing.Point(23, 67);
            picBreakfast.Size = new System.Drawing.Size(183, 133);
            picBreakfast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            chkBreakfast.AutoSize = true;
            chkBreakfast.Location = new System.Drawing.Point(23, 213);
            chkBreakfast.Size = new System.Drawing.Size(131, 24);
            chkBreakfast.Text = "Break Fast  ($7)";

            txtQtyBreakfast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtQtyBreakfast.Location = new System.Drawing.Point(23, 247);
            txtQtyBreakfast.Size = new System.Drawing.Size(183, 27);

            picLunch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picLunch.Location = new System.Drawing.Point(240, 67);
            picLunch.Size = new System.Drawing.Size(183, 133);
            picLunch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            chkLunch.AutoSize = true;
            chkLunch.Location = new System.Drawing.Point(240, 213);
            chkLunch.Size = new System.Drawing.Size(111, 24);
            chkLunch.Text = "Lunch  ($15)";

            txtQtyLunch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtQtyLunch.Location = new System.Drawing.Point(240, 247);
            txtQtyLunch.Size = new System.Drawing.Size(183, 27);

            picDinner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picDinner.Location = new System.Drawing.Point(23, 307);
            picDinner.Size = new System.Drawing.Size(183, 133);
            picDinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            chkDinner.AutoSize = true;
            chkDinner.Location = new System.Drawing.Point(23, 453);
            chkDinner.Size = new System.Drawing.Size(117, 24);
            chkDinner.Text = "Dinner  ($15)";

            txtQtyDinner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtQtyDinner.Location = new System.Drawing.Point(23, 487);
            txtQtyDinner.Size = new System.Drawing.Size(183, 27);

            pnlSpecial.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            pnlSpecial.Controls.Add(lblSpecialTitle);
            pnlSpecial.Controls.Add(chkCleaning);
            pnlSpecial.Controls.Add(chkTowels);
            pnlSpecial.Controls.Add(chkSurprise);
            pnlSpecial.Location = new System.Drawing.Point(503, 93);
            pnlSpecial.Size = new System.Drawing.Size(217, 467);
            pnlSpecial.Paint += DrawDashedBorder;

            lblSpecialTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            lblSpecialTitle.Location = new System.Drawing.Point(17, 20);
            lblSpecialTitle.Size = new System.Drawing.Size(114, 31);
            lblSpecialTitle.Text = "Special needs";

            chkCleaning.AutoSize = true;
            chkCleaning.Location = new System.Drawing.Point(23, 80);
            chkCleaning.Size = new System.Drawing.Size(89, 24);
            chkCleaning.Text = "Cleaning";

            chkTowels.AutoSize = true;
            chkTowels.Location = new System.Drawing.Point(23, 133);
            chkTowels.Size = new System.Drawing.Size(76, 24);
            chkTowels.Text = "Towels";

            chkSurprise.AutoSize = true;
            chkSurprise.Location = new System.Drawing.Point(23, 187);
            chkSurprise.Size = new System.Drawing.Size(145, 24);
            chkSurprise.Text = "Sweetest surprise";

            btnNext.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            btnNext.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNext.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnNext.Location = new System.Drawing.Point(503, 587);
            btnNext.Size = new System.Drawing.Size(217, 67);
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(743, 693);
            Controls.Add(lblClose);
            Controls.Add(lblTitle);
            Controls.Add(topBlueBar);
            Controls.Add(pnlFood);
            Controls.Add(pnlSpecial);
            Controls.Add(btnNext);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Food and Menu";
            MouseDown += Form_MouseDown;
            pnlFood.ResumeLayout(false);
            pnlFood.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBreakfast).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLunch).EndInit();
            ((System.ComponentModel.ISupportInitialize)picDinner).EndInit();
            pnlSpecial.ResumeLayout(false);
            pnlSpecial.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel topBlueBar, pnlFood, pnlSpecial;
        private System.Windows.Forms.Label lblTitle, lblClose, lblFoodTitle, lblSpecialTitle;
        private System.Windows.Forms.PictureBox picBreakfast, picLunch, picDinner;
        private System.Windows.Forms.CheckBox chkBreakfast, chkLunch, chkDinner, chkCleaning, chkTowels, chkSurprise;
        private System.Windows.Forms.TextBox txtQtyBreakfast, txtQtyLunch, txtQtyDinner;
        private System.Windows.Forms.Button btnNext;
    }
}