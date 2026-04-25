namespace Assignmint2
{
    partial class FinalizePayment
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
            topGreenBar = new Panel();
            lblClose = new Label();
            pnlMain = new Panel();
            lblReservation = new Label();
            lblCurrentBill = new Label();
            lblFoodBill = new Label();
            lblTax = new Label();
            lblTotal = new Label();
            lblPaymentTitle = new Label();
            lblHeaderPrice = new Label();
            lblValRes = new Label();
            lblValCurrent = new Label();
            lblValFood = new Label();
            lblValTax = new Label();
            lblValTotal = new Label();
            cmbPaymentType = new ComboBox();
            txtCardNumber = new TextBox();
            cmbMonth = new ComboBox();
            lblSlash = new Label();
            cmbYear = new ComboBox();
            txtCVC = new TextBox();
            lblCardTypeTitle = new Label();
            lblCardTypeValue = new Label();
            btnNext = new Button();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // topGreenBar
            // 
            topGreenBar.BackColor = Color.MediumSeaGreen;
            topGreenBar.Dock = DockStyle.Top;
            topGreenBar.Location = new Point(0, 0);
            topGreenBar.Name = "topGreenBar";
            topGreenBar.Size = new Size(550, 5);
            topGreenBar.TabIndex = 1;
            topGreenBar.MouseDown += Form_MouseDown;
            // 
            // lblClose
            // 
            lblClose.AutoSize = true;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblClose.ForeColor = Color.Gray;
            lblClose.Location = new Point(525, 10);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(25, 28);
            lblClose.TabIndex = 0;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            lblClose.MouseEnter += lblClose_MouseEnter;
            lblClose.MouseLeave += lblClose_MouseLeave;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(lblReservation);
            pnlMain.Controls.Add(lblCurrentBill);
            pnlMain.Controls.Add(lblFoodBill);
            pnlMain.Controls.Add(lblTax);
            pnlMain.Controls.Add(lblTotal);
            pnlMain.Controls.Add(lblPaymentTitle);
            pnlMain.Controls.Add(lblHeaderPrice);
            pnlMain.Controls.Add(lblValRes);
            pnlMain.Controls.Add(lblValCurrent);
            pnlMain.Controls.Add(lblValFood);
            pnlMain.Controls.Add(lblValTax);
            pnlMain.Controls.Add(lblValTotal);
            pnlMain.Controls.Add(cmbPaymentType);
            pnlMain.Controls.Add(txtCardNumber);
            pnlMain.Controls.Add(cmbMonth);
            pnlMain.Controls.Add(lblSlash);
            pnlMain.Controls.Add(cmbYear);
            pnlMain.Controls.Add(txtCVC);
            pnlMain.Controls.Add(lblCardTypeTitle);
            pnlMain.Controls.Add(lblCardTypeValue);
            pnlMain.Controls.Add(btnNext);
            pnlMain.Location = new Point(15, 30);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(520, 310);
            pnlMain.TabIndex = 2;
            pnlMain.Paint += DrawDashedBorder;
            // 
            // lblReservation
            // 
            lblReservation.AutoSize = true;
            lblReservation.Location = new Point(21, 25);
            lblReservation.Name = "lblReservation";
            lblReservation.Size = new Size(98, 23);
            lblReservation.TabIndex = 0;
            lblReservation.Text = "Reservation";
            // 
            // lblCurrentBill
            // 
            lblCurrentBill.AutoSize = true;
            lblCurrentBill.Location = new Point(21, 55);
            lblCurrentBill.Name = "lblCurrentBill";
            lblCurrentBill.Size = new Size(95, 23);
            lblCurrentBill.TabIndex = 1;
            lblCurrentBill.Text = "Current bill";
            // 
            // lblFoodBill
            // 
            lblFoodBill.AutoSize = true;
            lblFoodBill.Location = new Point(21, 85);
            lblFoodBill.Name = "lblFoodBill";
            lblFoodBill.Size = new Size(75, 23);
            lblFoodBill.TabIndex = 2;
            lblFoodBill.Text = "Food bill";
            // 
            // lblTax
            // 
            lblTax.AutoSize = true;
            lblTax.Location = new Point(21, 115);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(34, 23);
            lblTax.TabIndex = 3;
            lblTax.Text = "Tax";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(22, 138);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(49, 23);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total";
            // 
            // lblPaymentTitle
            // 
            lblPaymentTitle.AutoSize = true;
            lblPaymentTitle.Location = new Point(20, 170);
            lblPaymentTitle.Name = "lblPaymentTitle";
            lblPaymentTitle.Size = new Size(76, 23);
            lblPaymentTitle.TabIndex = 5;
            lblPaymentTitle.Text = "Payment";
            // 
            // lblHeaderPrice
            // 
            lblHeaderPrice.AutoSize = true;
            lblHeaderPrice.Location = new Point(426, 0);
            lblHeaderPrice.Name = "lblHeaderPrice";
            lblHeaderPrice.Size = new Size(47, 23);
            lblHeaderPrice.TabIndex = 6;
            lblHeaderPrice.Text = "Price";
            // 
            // lblValRes
            // 
            lblValRes.AutoSize = true;
            lblValRes.Location = new Point(373, 18);
            lblValRes.Name = "lblValRes";
            lblValRes.Size = new Size(19, 23);
            lblValRes.TabIndex = 7;
            lblValRes.Text = "$";
            // 
            // lblValCurrent
            // 
            lblValCurrent.AutoSize = true;
            lblValCurrent.Location = new Point(373, 48);
            lblValCurrent.Name = "lblValCurrent";
            lblValCurrent.Size = new Size(19, 23);
            lblValCurrent.TabIndex = 8;
            lblValCurrent.Text = "$";
            // 
            // lblValFood
            // 
            lblValFood.AutoSize = true;
            lblValFood.Location = new Point(373, 78);
            lblValFood.Name = "lblValFood";
            lblValFood.Size = new Size(19, 23);
            lblValFood.TabIndex = 9;
            lblValFood.Text = "$";
            // 
            // lblValTax
            // 
            lblValTax.AutoSize = true;
            lblValTax.Location = new Point(373, 108);
            lblValTax.Name = "lblValTax";
            lblValTax.Size = new Size(19, 23);
            lblValTax.TabIndex = 10;
            lblValTax.Text = "$";
            // 
            // lblValTotal
            // 
            lblValTotal.AutoSize = true;
            lblValTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblValTotal.Location = new Point(373, 138);
            lblValTotal.Name = "lblValTotal";
            lblValTotal.Size = new Size(20, 23);
            lblValTotal.TabIndex = 11;
            lblValTotal.Text = "$";
            // 
            // cmbPaymentType
            // 
            cmbPaymentType.Location = new Point(20, 195);
            cmbPaymentType.Name = "cmbPaymentType";
            cmbPaymentType.Size = new Size(135, 31);
            cmbPaymentType.TabIndex = 12;
            cmbPaymentType.Text = "Payment type";
            // 
            // txtCardNumber
            // 
            txtCardNumber.BorderStyle = BorderStyle.FixedSingle;
            txtCardNumber.Location = new Point(161, 195);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(339, 30);
            txtCardNumber.TabIndex = 13;
            txtCardNumber.Text = "9999 - 9999 - 9999 - 9999\r\n";
            // 
            // cmbMonth
            // 
            cmbMonth.Location = new Point(20, 240);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.Size = new Size(57, 31);
            cmbMonth.TabIndex = 14;
            cmbMonth.Text = "MM";
            // 
            // lblSlash
            // 
            lblSlash.AutoSize = true;
            lblSlash.Location = new Point(79, 245);
            lblSlash.Name = "lblSlash";
            lblSlash.Size = new Size(17, 23);
            lblSlash.TabIndex = 15;
            lblSlash.Text = "/";
            // 
            // cmbYear
            // 
            cmbYear.Location = new Point(98, 240);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(50, 31);
            cmbYear.TabIndex = 16;
            cmbYear.Text = "YY";
            // 
            // txtCVC
            // 
            txtCVC.BorderStyle = BorderStyle.FixedSingle;
            txtCVC.Location = new Point(174, 240);
            txtCVC.Name = "txtCVC";
            txtCVC.Size = new Size(50, 30);
            txtCVC.TabIndex = 17;
            txtCVC.Text = "CVC";
            // 
            // lblCardTypeTitle
            // 
            lblCardTypeTitle.AutoSize = true;
            lblCardTypeTitle.Location = new Point(230, 245);
            lblCardTypeTitle.Name = "lblCardTypeTitle";
            lblCardTypeTitle.Size = new Size(93, 23);
            lblCardTypeTitle.TabIndex = 18;
            lblCardTypeTitle.Text = "Card type :";
            // 
            // lblCardTypeValue
            // 
            lblCardTypeValue.AutoSize = true;
            lblCardTypeValue.Location = new Point(310, 245);
            lblCardTypeValue.Name = "lblCardTypeValue";
            lblCardTypeValue.Size = new Size(82, 23);
            lblCardTypeValue.TabIndex = 19;
            lblCardTypeValue.Text = "Unknown";
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(235, 235, 235);
            btnNext.FlatAppearance.BorderColor = Color.LightGray;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNext.Location = new Point(417, 267);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(100, 40);
            btnNext.TabIndex = 20;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // FinalizePayment
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(550, 360);
            Controls.Add(lblClose);
            Controls.Add(topGreenBar);
            Controls.Add(pnlMain);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FinalizePayment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Finalize Payment";
            Load += FinalizePayment_Load;
            MouseDown += Form_MouseDown;
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel topGreenBar, pnlMain;
        private System.Windows.Forms.Label lblClose, lblReservation, lblCurrentBill, lblFoodBill, lblTax, lblTotal, lblPaymentTitle;
        private System.Windows.Forms.Label lblHeaderPrice, lblValRes, lblValCurrent, lblValFood, lblValTax, lblValTotal;
        private System.Windows.Forms.ComboBox cmbPaymentType, cmbMonth, cmbYear;
        private System.Windows.Forms.TextBox txtCardNumber, txtCVC;
        private System.Windows.Forms.Label lblSlash, lblCardTypeTitle, lblCardTypeValue;
        private System.Windows.Forms.Button btnNext;
    }
}