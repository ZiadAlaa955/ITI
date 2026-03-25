namespace Assignment2
{
    partial class Kitchen
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
            lblTitle = new Label();
            lblClose = new Label();
            tabControlMain = new TabControl();
            tabTodo = new TabPage();
            lblName = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblRoomType = new Label();
            txtRoomType = new TextBox();
            lblFloor = new Label();
            txtFloor = new TextBox();
            lblRoomNo = new Label();
            txtRoomNo = new TextBox();
            grpTodo = new GroupBox();
            lblBreakfast = new Label();
            txtBreakfast = new TextBox();
            lblLunch = new Label();
            txtLunch = new TextBox();
            lblDinner = new Label();
            txtDinner = new TextBox();
            chkCleaning = new CheckBox();
            chkTowels = new CheckBox();
            chkSurprise = new CheckBox();
            chkFoodStatus = new CheckBox();
            btnChangeFood = new Button();
            lblQueue = new Label();
            queueListBox = new ListBox();
            btnUpdateChanges = new Button();
            tabOverview = new TabPage();
            overviewDataGridView = new DataGridView();
            tabControlMain.SuspendLayout();
            tabTodo.SuspendLayout();
            grpTodo.SuspendLayout();
            tabOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)overviewDataGridView).BeginInit();
            SuspendLayout();
            // 
            // topGreenBar
            // 
            topGreenBar.BackColor = Color.YellowGreen;
            topGreenBar.Dock = DockStyle.Top;
            topGreenBar.Location = new Point(0, 0);
            topGreenBar.Margin = new Padding(3, 4, 3, 4);
            topGreenBar.Name = "topGreenBar";
            topGreenBar.Size = new Size(1086, 7);
            topGreenBar.TabIndex = 3;
            topGreenBar.MouseDown += Form_MouseDown;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Light", 22F);
            lblTitle.Location = new Point(23, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(236, 50);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Room Service";
            lblTitle.MouseDown += Form_MouseDown;
            // 
            // lblClose
            // 
            lblClose.AutoSize = true;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblClose.ForeColor = Color.Gray;
            lblClose.Location = new Point(1046, 13);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(30, 32);
            lblClose.TabIndex = 0;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            lblClose.MouseEnter += lblClose_MouseEnter;
            lblClose.MouseLeave += lblClose_MouseLeave;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabTodo);
            tabControlMain.Controls.Add(tabOverview);
            tabControlMain.Font = new Font("Segoe UI", 10F);
            tabControlMain.Location = new Point(29, 100);
            tabControlMain.Margin = new Padding(3, 4, 3, 4);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1029, 640);
            tabControlMain.TabIndex = 1;
            // 
            // tabTodo
            // 
            tabTodo.BackColor = Color.White;
            tabTodo.Controls.Add(lblName);
            tabTodo.Controls.Add(txtFirstName);
            tabTodo.Controls.Add(txtLastName);
            tabTodo.Controls.Add(lblPhone);
            tabTodo.Controls.Add(txtPhone);
            tabTodo.Controls.Add(lblRoomType);
            tabTodo.Controls.Add(txtRoomType);
            tabTodo.Controls.Add(lblFloor);
            tabTodo.Controls.Add(txtFloor);
            tabTodo.Controls.Add(lblRoomNo);
            tabTodo.Controls.Add(txtRoomNo);
            tabTodo.Controls.Add(grpTodo);
            tabTodo.Controls.Add(lblQueue);
            tabTodo.Controls.Add(queueListBox);
            tabTodo.Controls.Add(btnUpdateChanges);
            tabTodo.Location = new Point(4, 32);
            tabTodo.Margin = new Padding(3, 4, 3, 4);
            tabTodo.Name = "tabTodo";
            tabTodo.Padding = new Padding(3, 4, 3, 4);
            tabTodo.Size = new Size(1021, 604);
            tabTodo.TabIndex = 0;
            tabTodo.Text = "TODO*";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(23, 27);
            lblName.Name = "lblName";
            lblName.Size = new Size(56, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // txtFirstName
            // 
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.ForeColor = Color.Gray;
            txtFirstName.Location = new Point(26, 60);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(137, 30);
            txtFirstName.TabIndex = 1;
            txtFirstName.Text = "First";
            // 
            // txtLastName
            // 
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.ForeColor = Color.Gray;
            txtLastName.Location = new Point(175, 60);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(137, 30);
            txtLastName.TabIndex = 2;
            txtLastName.Text = "Last";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(23, 113);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(124, 23);
            lblPhone.TabIndex = 3;
            lblPhone.Text = "Phone number";
            // 
            // txtPhone
            // 
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.ForeColor = Color.Gray;
            txtPhone.Location = new Point(26, 147);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(285, 30);
            txtPhone.TabIndex = 4;
            txtPhone.Text = "(999)-999-9999";
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Location = new Point(23, 200);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(93, 23);
            lblRoomType.TabIndex = 5;
            lblRoomType.Text = "Room type";
            // 
            // txtRoomType
            // 
            txtRoomType.BorderStyle = BorderStyle.FixedSingle;
            txtRoomType.ForeColor = Color.Gray;
            txtRoomType.Location = new Point(26, 233);
            txtRoomType.Margin = new Padding(3, 4, 3, 4);
            txtRoomType.Name = "txtRoomType";
            txtRoomType.Size = new Size(137, 30);
            txtRoomType.TabIndex = 6;
            txtRoomType.Text = "Room type";
            // 
            // lblFloor
            // 
            lblFloor.AutoSize = true;
            lblFloor.Location = new Point(171, 200);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(63, 23);
            lblFloor.TabIndex = 7;
            lblFloor.Text = "Floor #";
            // 
            // txtFloor
            // 
            txtFloor.BorderStyle = BorderStyle.FixedSingle;
            txtFloor.ForeColor = Color.Gray;
            txtFloor.Location = new Point(175, 233);
            txtFloor.Margin = new Padding(3, 4, 3, 4);
            txtFloor.Name = "txtFloor";
            txtFloor.Size = new Size(137, 30);
            txtFloor.TabIndex = 8;
            txtFloor.Text = "Floor #";
            // 
            // lblRoomNo
            // 
            lblRoomNo.AutoSize = true;
            lblRoomNo.Location = new Point(23, 287);
            lblRoomNo.Name = "lblRoomNo";
            lblRoomNo.Size = new Size(70, 23);
            lblRoomNo.TabIndex = 9;
            lblRoomNo.Text = "Room #";
            // 
            // txtRoomNo
            // 
            txtRoomNo.BorderStyle = BorderStyle.FixedSingle;
            txtRoomNo.ForeColor = Color.Gray;
            txtRoomNo.Location = new Point(26, 320);
            txtRoomNo.Margin = new Padding(3, 4, 3, 4);
            txtRoomNo.Name = "txtRoomNo";
            txtRoomNo.Size = new Size(285, 30);
            txtRoomNo.TabIndex = 10;
            txtRoomNo.Text = "Room #";
            // 
            // grpTodo
            // 
            grpTodo.Controls.Add(lblBreakfast);
            grpTodo.Controls.Add(txtBreakfast);
            grpTodo.Controls.Add(lblLunch);
            grpTodo.Controls.Add(txtLunch);
            grpTodo.Controls.Add(lblDinner);
            grpTodo.Controls.Add(txtDinner);
            grpTodo.Controls.Add(chkCleaning);
            grpTodo.Controls.Add(chkTowels);
            grpTodo.Controls.Add(chkSurprise);
            grpTodo.Controls.Add(chkFoodStatus);
            grpTodo.Controls.Add(btnChangeFood);
            grpTodo.Location = new Point(343, 27);
            grpTodo.Margin = new Padding(3, 4, 3, 4);
            grpTodo.Name = "grpTodo";
            grpTodo.Padding = new Padding(3, 4, 3, 4);
            grpTodo.Size = new Size(366, 547);
            grpTodo.TabIndex = 11;
            grpTodo.TabStop = false;
            grpTodo.Text = "Todo";
            // 
            // lblBreakfast
            // 
            lblBreakfast.AutoSize = true;
            lblBreakfast.Location = new Point(17, 40);
            lblBreakfast.Name = "lblBreakfast";
            lblBreakfast.Size = new Size(124, 23);
            lblBreakfast.TabIndex = 0;
            lblBreakfast.Text = "Breakfast [QTY]";
            // 
            // txtBreakfast
            // 
            txtBreakfast.BorderStyle = BorderStyle.FixedSingle;
            txtBreakfast.ForeColor = Color.Gray;
            txtBreakfast.Location = new Point(21, 73);
            txtBreakfast.Margin = new Padding(3, 4, 3, 4);
            txtBreakfast.Name = "txtBreakfast";
            txtBreakfast.Size = new Size(154, 30);
            txtBreakfast.TabIndex = 1;
            txtBreakfast.Text = "Breakfast";
            // 
            // lblLunch
            // 
            lblLunch.AutoSize = true;
            lblLunch.Location = new Point(189, 40);
            lblLunch.Name = "lblLunch";
            lblLunch.Size = new Size(101, 23);
            lblLunch.TabIndex = 2;
            lblLunch.Text = "Lunch [QTY]";
            // 
            // txtLunch
            // 
            txtLunch.BorderStyle = BorderStyle.FixedSingle;
            txtLunch.ForeColor = Color.Gray;
            txtLunch.Location = new Point(192, 73);
            txtLunch.Margin = new Padding(3, 4, 3, 4);
            txtLunch.Name = "txtLunch";
            txtLunch.Size = new Size(154, 30);
            txtLunch.TabIndex = 3;
            txtLunch.Text = "Lunch";
            // 
            // lblDinner
            // 
            lblDinner.AutoSize = true;
            lblDinner.Location = new Point(17, 127);
            lblDinner.Name = "lblDinner";
            lblDinner.Size = new Size(106, 23);
            lblDinner.TabIndex = 4;
            lblDinner.Text = "Dinner [QTY]";
            // 
            // txtDinner
            // 
            txtDinner.BorderStyle = BorderStyle.FixedSingle;
            txtDinner.ForeColor = Color.Gray;
            txtDinner.Location = new Point(21, 160);
            txtDinner.Margin = new Padding(3, 4, 3, 4);
            txtDinner.Name = "txtDinner";
            txtDinner.Size = new Size(325, 30);
            txtDinner.TabIndex = 5;
            txtDinner.Text = "Dinner";
            // 
            // chkCleaning
            // 
            chkCleaning.AutoSize = true;
            chkCleaning.Location = new Point(21, 227);
            chkCleaning.Margin = new Padding(3, 4, 3, 4);
            chkCleaning.Name = "chkCleaning";
            chkCleaning.Size = new Size(99, 27);
            chkCleaning.TabIndex = 6;
            chkCleaning.Text = "Cleaning";
            // 
            // chkTowels
            // 
            chkTowels.AutoSize = true;
            chkTowels.Location = new Point(17, 270);
            chkTowels.Margin = new Padding(3, 4, 3, 4);
            chkTowels.Name = "chkTowels";
            chkTowels.Size = new Size(81, 27);
            chkTowels.TabIndex = 7;
            chkTowels.Text = "Towels";
            // 
            // chkSurprise
            // 
            chkSurprise.AutoSize = true;
            chkSurprise.Location = new Point(181, 227);
            chkSurprise.Margin = new Padding(3, 4, 3, 4);
            chkSurprise.Name = "chkSurprise";
            chkSurprise.Size = new Size(165, 27);
            chkSurprise.TabIndex = 8;
            chkSurprise.Text = "Sweetest Surprise";
            // 
            // chkFoodStatus
            // 
            chkFoodStatus.AutoSize = true;
            chkFoodStatus.Location = new Point(155, 270);
            chkFoodStatus.Margin = new Padding(3, 4, 3, 4);
            chkFoodStatus.Name = "chkFoodStatus";
            chkFoodStatus.Size = new Size(191, 27);
            chkFoodStatus.TabIndex = 9;
            chkFoodStatus.Text = "Food/Supply status ?";
            // 
            // btnChangeFood
            // 
            btnChangeFood.BackColor = Color.FromArgb(235, 235, 235);
            btnChangeFood.FlatAppearance.BorderColor = Color.LightGray;
            btnChangeFood.FlatStyle = FlatStyle.Flat;
            btnChangeFood.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChangeFood.ForeColor = Color.SeaGreen;
            btnChangeFood.Location = new Point(21, 357);
            btnChangeFood.Margin = new Padding(3, 4, 3, 4);
            btnChangeFood.Name = "btnChangeFood";
            btnChangeFood.Size = new Size(326, 40);
            btnChangeFood.TabIndex = 10;
            btnChangeFood.Text = "Change food selection?";
            btnChangeFood.UseVisualStyleBackColor = false;
            // 
            // lblQueue
            // 
            lblQueue.AutoSize = true;
            lblQueue.Location = new Point(731, 27);
            lblQueue.Name = "lblQueue";
            lblQueue.Size = new Size(95, 23);
            lblQueue.TabIndex = 12;
            lblQueue.Text = "On the line";
            // 
            // queueListBox
            // 
            queueListBox.FormattingEnabled = true;
            queueListBox.Location = new Point(735, 60);
            queueListBox.Margin = new Padding(3, 4, 3, 4);
            queueListBox.Name = "queueListBox";
            queueListBox.Size = new Size(262, 395);
            queueListBox.TabIndex = 13;
            // 
            // btnUpdateChanges
            // 
            btnUpdateChanges.BackColor = Color.FromArgb(235, 235, 235);
            btnUpdateChanges.FlatAppearance.BorderColor = Color.LightGray;
            btnUpdateChanges.FlatStyle = FlatStyle.Flat;
            btnUpdateChanges.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateChanges.ForeColor = Color.SeaGreen;
            btnUpdateChanges.Location = new Point(735, 527);
            btnUpdateChanges.Margin = new Padding(3, 4, 3, 4);
            btnUpdateChanges.Name = "btnUpdateChanges";
            btnUpdateChanges.Size = new Size(263, 47);
            btnUpdateChanges.TabIndex = 14;
            btnUpdateChanges.Text = "Update changes";
            btnUpdateChanges.UseVisualStyleBackColor = false;
            // 
            // tabOverview
            // 
            tabOverview.BackColor = Color.White;
            tabOverview.Controls.Add(overviewDataGridView);
            tabOverview.Location = new Point(4, 32);
            tabOverview.Margin = new Padding(3, 4, 3, 4);
            tabOverview.Name = "tabOverview";
            tabOverview.Padding = new Padding(11, 13, 11, 13);
            tabOverview.Size = new Size(1021, 604);
            tabOverview.TabIndex = 1;
            tabOverview.Text = "Overview";
            // 
            // overviewDataGridView
            // 
            overviewDataGridView.AllowUserToAddRows = false;
            overviewDataGridView.AllowUserToDeleteRows = false;
            overviewDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            overviewDataGridView.BackgroundColor = Color.FromArgb(224, 224, 224);
            overviewDataGridView.BorderStyle = BorderStyle.None;
            overviewDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            overviewDataGridView.Dock = DockStyle.Fill;
            overviewDataGridView.Location = new Point(11, 13);
            overviewDataGridView.Margin = new Padding(3, 4, 3, 4);
            overviewDataGridView.Name = "overviewDataGridView";
            overviewDataGridView.ReadOnly = true;
            overviewDataGridView.RowHeadersVisible = false;
            overviewDataGridView.RowHeadersWidth = 51;
            overviewDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            overviewDataGridView.Size = new Size(999, 578);
            overviewDataGridView.TabIndex = 0;
            // 
            // Kitchen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1086, 773);
            Controls.Add(lblClose);
            Controls.Add(tabControlMain);
            Controls.Add(lblTitle);
            Controls.Add(topGreenBar);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Kitchen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kitchen";
            MouseDown += Form_MouseDown;
            tabControlMain.ResumeLayout(false);
            tabTodo.ResumeLayout(false);
            tabTodo.PerformLayout();
            grpTodo.ResumeLayout(false);
            grpTodo.PerformLayout();
            tabOverview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)overviewDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel topGreenBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabTodo;
        private System.Windows.Forms.TabPage tabOverview;
        private System.Windows.Forms.DataGridView overviewDataGridView; // The new DataGridView

        // Left Column
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.TextBox txtRoomType;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Label lblRoomNo;
        private System.Windows.Forms.TextBox txtRoomNo;

        // Middle Column
        private System.Windows.Forms.GroupBox grpTodo;
        private System.Windows.Forms.Label lblBreakfast;
        private System.Windows.Forms.TextBox txtBreakfast;
        private System.Windows.Forms.Label lblLunch;
        private System.Windows.Forms.TextBox txtLunch;
        private System.Windows.Forms.Label lblDinner;
        private System.Windows.Forms.TextBox txtDinner;
        private System.Windows.Forms.CheckBox chkCleaning;
        private System.Windows.Forms.CheckBox chkTowels;
        private System.Windows.Forms.CheckBox chkSurprise;
        private System.Windows.Forms.CheckBox chkFoodStatus;
        private System.Windows.Forms.Button btnChangeFood;

        // Right Column
        private System.Windows.Forms.Label lblQueue;
        private System.Windows.Forms.ListBox queueListBox;
        private System.Windows.Forms.Button btnUpdateChanges;
    }
}