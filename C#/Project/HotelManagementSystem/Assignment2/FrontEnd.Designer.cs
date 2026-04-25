namespace Assignmint2
{
    partial class Frontend
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

        #region Windows Form Designer Generated Code
        private void InitializeComponent()
        {
            topGreenBar = new Panel();
            lblTitle = new Label();
            lblClose = new Label();
            tabControlMain = new TabControl();
            tabReservation = new TabPage();
            pnlLeft = new Panel();
            lblName = new Label();
            txtFirst = new TextBox();
            txtLast = new TextBox();
            lblBirthday = new Label();
            cmbMonth = new ComboBox();
            cmbDay = new ComboBox();
            cmbYear = new ComboBox();
            lblGender = new Label();
            cmbGender = new ComboBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            txtStreet = new TextBox();
            txtApt = new TextBox();
            txtCity = new TextBox();
            cmbState = new ComboBox();
            txtZip = new TextBox();
            pnlMiddle = new Panel();
            lblChoices = new Label();
            cmbGuests = new ComboBox();
            cmbRoomType = new ComboBox();
            cmbFloor = new ComboBox();
            cmbRoomNo = new ComboBox();
            lblEntry = new Label();
            dtpEntry = new DateTimePicker();
            lblDeparture = new Label();
            dtpDeparture = new DateTimePicker();
            btnFoodMenu = new Button();
            chkCheckIn = new CheckBox();
            chkSendSms = new CheckBox();
            chkFoodStatus = new CheckBox();
            btnFinalizeBill = new Button();
            btnSubmit = new Button();
            pnlRight = new Panel();
            cmbEditReservation = new ComboBox();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnEditExisting = new Button();
            btnNewReservation = new Button();
            tabUniversalSearch = new TabPage();
            searchDataGridView = new DataGridView();
            btnSearch = new Button();
            txtUniversalSearch = new TextBox();
            tabAdvView = new TabPage();
            advViewDataGridView = new DataGridView();
            tabRoomAvailability = new TabPage();
            lblOccupied = new Label();
            lblReserved = new Label();
            lblOccupiedHeaders = new Label();
            lblReservedHeaders = new Label();
            roomOccupiedListBox = new ListBox();
            roomReservedListBox = new ListBox();
            tabControlMain.SuspendLayout();
            tabReservation.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlMiddle.SuspendLayout();
            pnlRight.SuspendLayout();
            tabUniversalSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)searchDataGridView).BeginInit();
            tabAdvView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)advViewDataGridView).BeginInit();
            tabRoomAvailability.SuspendLayout();
            SuspendLayout();
            // 
            // topGreenBar
            // 
            topGreenBar.BackColor = Color.MediumSeaGreen;
            topGreenBar.Dock = DockStyle.Top;
            topGreenBar.Location = new Point(0, 0);
            topGreenBar.Margin = new Padding(3, 4, 3, 4);
            topGreenBar.Name = "topGreenBar";
            topGreenBar.Size = new Size(1358, 9);
            topGreenBar.TabIndex = 3;
            topGreenBar.MouseDown += Form_MouseDown;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Light", 22F);
            lblTitle.Location = new Point(26, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(162, 50);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Frontend";
            lblTitle.MouseDown += Form_MouseDown;
            // 
            // lblClose
            // 
            lblClose.AutoSize = true;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblClose.ForeColor = Color.Gray;
            lblClose.Location = new Point(1326, 17);
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
            tabControlMain.Controls.Add(tabReservation);
            tabControlMain.Controls.Add(tabUniversalSearch);
            tabControlMain.Controls.Add(tabAdvView);
            tabControlMain.Controls.Add(tabRoomAvailability);
            tabControlMain.Font = new Font("Segoe UI", 10F);
            tabControlMain.Location = new Point(46, 81);
            tabControlMain.Margin = new Padding(3, 4, 3, 4);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1299, 829);
            tabControlMain.TabIndex = 1;
            // 
            // tabReservation
            // 
            tabReservation.BackColor = Color.White;
            tabReservation.Controls.Add(pnlLeft);
            tabReservation.Controls.Add(pnlMiddle);
            tabReservation.Controls.Add(pnlRight);
            tabReservation.Location = new Point(4, 32);
            tabReservation.Margin = new Padding(3, 4, 3, 4);
            tabReservation.Name = "tabReservation";
            tabReservation.Size = new Size(1291, 793);
            tabReservation.TabIndex = 0;
            tabReservation.Text = "Reservation";
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(lblName);
            pnlLeft.Controls.Add(txtFirst);
            pnlLeft.Controls.Add(txtLast);
            pnlLeft.Controls.Add(lblBirthday);
            pnlLeft.Controls.Add(cmbMonth);
            pnlLeft.Controls.Add(cmbDay);
            pnlLeft.Controls.Add(cmbYear);
            pnlLeft.Controls.Add(lblGender);
            pnlLeft.Controls.Add(cmbGender);
            pnlLeft.Controls.Add(lblPhone);
            pnlLeft.Controls.Add(txtPhone);
            pnlLeft.Controls.Add(lblEmail);
            pnlLeft.Controls.Add(txtEmail);
            pnlLeft.Controls.Add(txtStreet);
            pnlLeft.Controls.Add(txtApt);
            pnlLeft.Controls.Add(txtCity);
            pnlLeft.Controls.Add(cmbState);
            pnlLeft.Controls.Add(txtZip);
            pnlLeft.Location = new Point(19, 27);
            pnlLeft.Margin = new Padding(3, 4, 3, 4);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(392, 744);
            pnlLeft.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.Location = new Point(19, 27);
            lblName.Name = "lblName";
            lblName.Size = new Size(130, 41);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // txtFirst
            // 
            txtFirst.BorderStyle = BorderStyle.FixedSingle;
            txtFirst.Location = new Point(24, 71);
            txtFirst.Margin = new Padding(3, 4, 3, 4);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(156, 30);
            txtFirst.TabIndex = 1;
            txtFirst.Text = "First";
            // 
            // txtLast
            // 
            txtLast.BorderStyle = BorderStyle.FixedSingle;
            txtLast.Location = new Point(195, 71);
            txtLast.Margin = new Padding(3, 4, 3, 4);
            txtLast.Name = "txtLast";
            txtLast.Size = new Size(169, 30);
            txtLast.TabIndex = 2;
            txtLast.Text = "Last";
            // 
            // lblBirthday
            // 
            lblBirthday.Location = new Point(13, 112);
            lblBirthday.Name = "lblBirthday";
            lblBirthday.Size = new Size(130, 41);
            lblBirthday.TabIndex = 3;
            lblBirthday.Text = "Birthday";
            // 
            // cmbMonth
            // 
            cmbMonth.Location = new Point(18, 156);
            cmbMonth.Margin = new Padding(3, 4, 3, 4);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.Size = new Size(103, 31);
            cmbMonth.TabIndex = 4;
            cmbMonth.Text = "Month";
            // 
            // cmbDay
            // 
            cmbDay.Location = new Point(138, 156);
            cmbDay.Margin = new Padding(3, 4, 3, 4);
            cmbDay.Name = "cmbDay";
            cmbDay.Size = new Size(77, 31);
            cmbDay.TabIndex = 5;
            cmbDay.Text = "Day";
            // 
            // cmbYear
            // 
            cmbYear.Location = new Point(229, 156);
            cmbYear.Margin = new Padding(3, 4, 3, 4);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(130, 31);
            cmbYear.TabIndex = 6;
            cmbYear.Text = "Year";
            // 
            // lblGender
            // 
            lblGender.Location = new Point(18, 209);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(130, 41);
            lblGender.TabIndex = 7;
            lblGender.Text = "Gender";
            // 
            // cmbGender
            // 
            cmbGender.Location = new Point(23, 253);
            cmbGender.Margin = new Padding(3, 4, 3, 4);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(341, 31);
            cmbGender.TabIndex = 8;
            cmbGender.Text = ".........";
            // 
            // lblPhone
            // 
            lblPhone.Location = new Point(19, 304);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(130, 41);
            lblPhone.TabIndex = 9;
            lblPhone.Text = "Phone number";
            // 
            // txtPhone
            // 
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Location = new Point(24, 348);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(341, 30);
            txtPhone.TabIndex = 10;
            txtPhone.Text = "(999) 999-9999";
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(19, 409);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(169, 41);
            lblEmail.TabIndex = 11;
            lblEmail.Text = "Your e-mail address";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(24, 453);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(341, 30);
            txtEmail.TabIndex = 12;
            txtEmail.Text = "first.last@example.com";
            // 
            // txtStreet
            // 
            txtStreet.BorderStyle = BorderStyle.FixedSingle;
            txtStreet.Location = new Point(25, 511);
            txtStreet.Margin = new Padding(3, 4, 3, 4);
            txtStreet.Name = "txtStreet";
            txtStreet.Size = new Size(341, 30);
            txtStreet.TabIndex = 13;
            txtStreet.Text = "Street address";
            // 
            // txtApt
            // 
            txtApt.BorderStyle = BorderStyle.FixedSingle;
            txtApt.Location = new Point(25, 600);
            txtApt.Margin = new Padding(3, 4, 3, 4);
            txtApt.Name = "txtApt";
            txtApt.Size = new Size(156, 30);
            txtApt.TabIndex = 14;
            txtApt.Text = "Apt./Suite";
            // 
            // txtCity
            // 
            txtCity.BorderStyle = BorderStyle.FixedSingle;
            txtCity.Location = new Point(196, 600);
            txtCity.Margin = new Padding(3, 4, 3, 4);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(169, 30);
            txtCity.TabIndex = 15;
            txtCity.Text = "City";
            // 
            // cmbState
            // 
            cmbState.Location = new Point(25, 688);
            cmbState.Margin = new Padding(3, 4, 3, 4);
            cmbState.Name = "cmbState";
            cmbState.Size = new Size(156, 31);
            cmbState.TabIndex = 16;
            cmbState.Text = "State";
            // 
            // txtZip
            // 
            txtZip.BorderStyle = BorderStyle.FixedSingle;
            txtZip.Location = new Point(196, 688);
            txtZip.Margin = new Padding(3, 4, 3, 4);
            txtZip.Name = "txtZip";
            txtZip.Size = new Size(169, 30);
            txtZip.TabIndex = 17;
            txtZip.Text = "Zip code";
            // 
            // pnlMiddle
            // 
            pnlMiddle.Controls.Add(lblChoices);
            pnlMiddle.Controls.Add(cmbGuests);
            pnlMiddle.Controls.Add(cmbRoomType);
            pnlMiddle.Controls.Add(cmbFloor);
            pnlMiddle.Controls.Add(cmbRoomNo);
            pnlMiddle.Controls.Add(lblEntry);
            pnlMiddle.Controls.Add(dtpEntry);
            pnlMiddle.Controls.Add(lblDeparture);
            pnlMiddle.Controls.Add(dtpDeparture);
            pnlMiddle.Controls.Add(btnFoodMenu);
            pnlMiddle.Controls.Add(chkCheckIn);
            pnlMiddle.Controls.Add(chkSendSms);
            pnlMiddle.Controls.Add(chkFoodStatus);
            pnlMiddle.Controls.Add(btnFinalizeBill);
            pnlMiddle.Controls.Add(btnSubmit);
            pnlMiddle.Location = new Point(431, 27);
            pnlMiddle.Margin = new Padding(3, 4, 3, 4);
            pnlMiddle.Name = "pnlMiddle";
            pnlMiddle.Size = new Size(418, 744);
            pnlMiddle.TabIndex = 1;
            // 
            // lblChoices
            // 
            lblChoices.Location = new Point(19, 27);
            lblChoices.Name = "lblChoices";
            lblChoices.Size = new Size(130, 41);
            lblChoices.TabIndex = 0;
            lblChoices.Text = "Your choices";
            // 
            // cmbGuests
            // 
            cmbGuests.Location = new Point(24, 71);
            cmbGuests.Margin = new Padding(3, 4, 3, 4);
            cmbGuests.Name = "cmbGuests";
            cmbGuests.Size = new Size(169, 31);
            cmbGuests.TabIndex = 1;
            cmbGuests.Text = "# of guests";
            // 
            // cmbRoomType
            // 
            cmbRoomType.Location = new Point(216, 71);
            cmbRoomType.Margin = new Padding(3, 4, 3, 4);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(169, 31);
            cmbRoomType.TabIndex = 2;
            cmbRoomType.Text = "Room type";
            // 
            // cmbFloor
            // 
            cmbFloor.Location = new Point(24, 130);
            cmbFloor.Margin = new Padding(3, 4, 3, 4);
            cmbFloor.Name = "cmbFloor";
            cmbFloor.Size = new Size(169, 31);
            cmbFloor.TabIndex = 3;
            cmbFloor.Text = "Floor";
            // 
            // cmbRoomNo
            // 
            cmbRoomNo.Location = new Point(216, 130);
            cmbRoomNo.Margin = new Padding(3, 4, 3, 4);
            cmbRoomNo.Name = "cmbRoomNo";
            cmbRoomNo.Size = new Size(169, 31);
            cmbRoomNo.TabIndex = 4;
            cmbRoomNo.Text = "Room number";
            // 
            // lblEntry
            // 
            lblEntry.Location = new Point(20, 179);
            lblEntry.Name = "lblEntry";
            lblEntry.Size = new Size(130, 41);
            lblEntry.TabIndex = 5;
            lblEntry.Text = "Entry [date]";
            // 
            // dtpEntry
            // 
            dtpEntry.Format = DateTimePickerFormat.Short;
            dtpEntry.Location = new Point(25, 223);
            dtpEntry.Margin = new Padding(3, 4, 3, 4);
            dtpEntry.Name = "dtpEntry";
            dtpEntry.Size = new Size(361, 30);
            dtpEntry.TabIndex = 6;
            // 
            // lblDeparture
            // 
            lblDeparture.Location = new Point(20, 286);
            lblDeparture.Name = "lblDeparture";
            lblDeparture.Size = new Size(130, 41);
            lblDeparture.TabIndex = 7;
            lblDeparture.Text = "Departure";
            // 
            // dtpDeparture
            // 
            dtpDeparture.Format = DateTimePickerFormat.Short;
            dtpDeparture.Location = new Point(25, 330);
            dtpDeparture.Margin = new Padding(3, 4, 3, 4);
            dtpDeparture.Name = "dtpDeparture";
            dtpDeparture.Size = new Size(361, 30);
            dtpDeparture.TabIndex = 8;
            // 
            // btnFoodMenu
            // 
            btnFoodMenu.BackColor = Color.FromArgb(240, 240, 240);
            btnFoodMenu.FlatAppearance.BorderColor = Color.LightGray;
            btnFoodMenu.FlatStyle = FlatStyle.Flat;
            btnFoodMenu.ForeColor = Color.MediumSeaGreen;
            btnFoodMenu.Location = new Point(24, 391);
            btnFoodMenu.Margin = new Padding(3, 4, 3, 4);
            btnFoodMenu.Name = "btnFoodMenu";
            btnFoodMenu.Size = new Size(362, 53);
            btnFoodMenu.TabIndex = 9;
            btnFoodMenu.Text = "Food and menu";
            btnFoodMenu.UseVisualStyleBackColor = false;
            // 
            // chkCheckIn
            // 
            chkCheckIn.AutoSize = true;
            chkCheckIn.Location = new Point(24, 481);
            chkCheckIn.Margin = new Padding(3, 4, 3, 4);
            chkCheckIn.Name = "chkCheckIn";
            chkCheckIn.Size = new Size(110, 27);
            chkCheckIn.TabIndex = 10;
            chkCheckIn.Text = "Check in ?";
            // 
            // chkSendSms
            // 
            chkSendSms.AutoSize = true;
            chkSendSms.Location = new Point(257, 481);
            chkSendSms.Margin = new Padding(3, 4, 3, 4);
            chkSendSms.Name = "chkSendSms";
            chkSendSms.Size = new Size(112, 27);
            chkSendSms.TabIndex = 11;
            chkSendSms.Text = "Send sms?";
            // 
            // chkFoodStatus
            // 
            chkFoodStatus.AutoSize = true;
            chkFoodStatus.Location = new Point(24, 523);
            chkFoodStatus.Margin = new Padding(3, 4, 3, 4);
            chkFoodStatus.Name = "chkFoodStatus";
            chkFoodStatus.Size = new Size(191, 27);
            chkFoodStatus.TabIndex = 12;
            chkFoodStatus.Text = "Food/Supply status ?";
            // 
            // btnFinalizeBill
            // 
            btnFinalizeBill.BackColor = Color.FromArgb(240, 240, 240);
            btnFinalizeBill.FlatAppearance.BorderColor = Color.LightGray;
            btnFinalizeBill.FlatStyle = FlatStyle.Flat;
            btnFinalizeBill.ForeColor = Color.MediumSeaGreen;
            btnFinalizeBill.Location = new Point(25, 556);
            btnFinalizeBill.Margin = new Padding(3, 4, 3, 4);
            btnFinalizeBill.Name = "btnFinalizeBill";
            btnFinalizeBill.Size = new Size(362, 53);
            btnFinalizeBill.TabIndex = 13;
            btnFinalizeBill.Text = "Finalize bill";
            btnFinalizeBill.UseVisualStyleBackColor = false;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(240, 240, 240);
            btnSubmit.FlatAppearance.BorderColor = Color.MediumSeaGreen;
            btnSubmit.FlatAppearance.BorderSize = 2;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.MediumSeaGreen;
            btnSubmit.Location = new Point(25, 627);
            btnSubmit.Margin = new Padding(3, 4, 3, 4);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(362, 63);
            btnSubmit.TabIndex = 14;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            //btnSubmit.Click += btnSubmit_Click_1;
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(cmbEditReservation);
            pnlRight.Controls.Add(btnUpdate);
            pnlRight.Controls.Add(btnDelete);
            pnlRight.Controls.Add(btnEditExisting);
            pnlRight.Controls.Add(btnNewReservation);
            pnlRight.Location = new Point(869, 27);
            pnlRight.Margin = new Padding(3, 4, 3, 4);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(392, 744);
            pnlRight.TabIndex = 2;
            // 
            // cmbEditReservation
            // 
            cmbEditReservation.Location = new Point(19, 27);
            cmbEditReservation.Margin = new Padding(3, 4, 3, 4);
            cmbEditReservation.Name = "cmbEditReservation";
            cmbEditReservation.Size = new Size(351, 31);
            cmbEditReservation.TabIndex = 0;
            cmbEditReservation.Text = "Select reservation to edit";
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 240, 240);
            btnUpdate.FlatAppearance.BorderColor = Color.MediumSeaGreen;
            btnUpdate.FlatAppearance.BorderSize = 2;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.MediumSeaGreen;
            btnUpdate.Location = new Point(19, 397);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(353, 63);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(20, 20, 20);
            btnDelete.FlatAppearance.BorderColor = Color.Crimson;
            btnDelete.FlatAppearance.BorderSize = 2;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.Crimson;
            btnDelete.Location = new Point(19, 477);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(353, 63);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEditExisting
            // 
            btnEditExisting.BackColor = Color.FromArgb(240, 240, 240);
            btnEditExisting.FlatAppearance.BorderColor = Color.LightGray;
            btnEditExisting.FlatStyle = FlatStyle.Flat;
            btnEditExisting.ForeColor = Color.MediumSeaGreen;
            btnEditExisting.Location = new Point(19, 566);
            btnEditExisting.Margin = new Padding(3, 4, 3, 4);
            btnEditExisting.Name = "btnEditExisting";
            btnEditExisting.Size = new Size(353, 53);
            btnEditExisting.TabIndex = 4;
            btnEditExisting.Text = "Edit existing Reservation";
            btnEditExisting.UseVisualStyleBackColor = false;
            // 
            // btnNewReservation
            // 
            btnNewReservation.BackColor = Color.FromArgb(240, 240, 240);
            btnNewReservation.FlatAppearance.BorderColor = Color.LightGray;
            btnNewReservation.FlatStyle = FlatStyle.Flat;
            btnNewReservation.ForeColor = Color.MediumSeaGreen;
            btnNewReservation.Location = new Point(19, 637);
            btnNewReservation.Margin = new Padding(3, 4, 3, 4);
            btnNewReservation.Name = "btnNewReservation";
            btnNewReservation.Size = new Size(353, 53);
            btnNewReservation.TabIndex = 5;
            btnNewReservation.Text = "New reservation";
            btnNewReservation.UseVisualStyleBackColor = false;
            // 
            // tabUniversalSearch
            // 
            tabUniversalSearch.BackColor = Color.White;
            tabUniversalSearch.Controls.Add(searchDataGridView);
            tabUniversalSearch.Controls.Add(btnSearch);
            tabUniversalSearch.Controls.Add(txtUniversalSearch);
            tabUniversalSearch.Location = new Point(4, 32);
            tabUniversalSearch.Margin = new Padding(3, 4, 3, 4);
            tabUniversalSearch.Name = "tabUniversalSearch";
            tabUniversalSearch.Padding = new Padding(11, 13, 11, 13);
            tabUniversalSearch.Size = new Size(1291, 793);
            tabUniversalSearch.TabIndex = 1;
            tabUniversalSearch.Text = "Universal Search";
            // 
            // searchDataGridView
            // 
            searchDataGridView.AllowUserToAddRows = false;
            searchDataGridView.AllowUserToDeleteRows = false;
            searchDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            searchDataGridView.BackgroundColor = Color.FromArgb(230, 230, 230);
            searchDataGridView.BorderStyle = BorderStyle.None;
            searchDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            searchDataGridView.Location = new Point(14, 80);
            searchDataGridView.Margin = new Padding(3, 4, 3, 4);
            searchDataGridView.Name = "searchDataGridView";
            searchDataGridView.ReadOnly = true;
            searchDataGridView.RowHeadersVisible = false;
            searchDataGridView.RowHeadersWidth = 51;
            searchDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            searchDataGridView.Size = new Size(1263, 692);
            searchDataGridView.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(235, 235, 235);
            btnSearch.FlatAppearance.BorderColor = Color.LightGray;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(994, 33);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 39);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtUniversalSearch
            // 
            txtUniversalSearch.BorderStyle = BorderStyle.FixedSingle;
            txtUniversalSearch.Font = new Font("Segoe UI", 12F);
            txtUniversalSearch.Location = new Point(14, 34);
            txtUniversalSearch.Margin = new Padding(3, 4, 3, 4);
            txtUniversalSearch.Name = "txtUniversalSearch";
            txtUniversalSearch.Size = new Size(945, 34);
            txtUniversalSearch.TabIndex = 0;
            // 
            // tabAdvView
            // 
            tabAdvView.BackColor = Color.White;
            tabAdvView.Controls.Add(advViewDataGridView);
            tabAdvView.Location = new Point(4, 32);
            tabAdvView.Margin = new Padding(3, 4, 3, 4);
            tabAdvView.Name = "tabAdvView";
            tabAdvView.Padding = new Padding(13, 17, 13, 17);
            tabAdvView.Size = new Size(1291, 793);
            tabAdvView.TabIndex = 2;
            tabAdvView.Text = "Reservation Adv. view";
            // 
            // advViewDataGridView
            // 
            advViewDataGridView.AllowUserToAddRows = false;
            advViewDataGridView.AllowUserToDeleteRows = false;
            advViewDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            advViewDataGridView.BackgroundColor = Color.DarkGray;
            advViewDataGridView.BorderStyle = BorderStyle.None;
            advViewDataGridView.ColumnHeadersHeight = 29;
            advViewDataGridView.Dock = DockStyle.Fill;
            advViewDataGridView.Location = new Point(13, 17);
            advViewDataGridView.Margin = new Padding(3, 4, 3, 4);
            advViewDataGridView.Name = "advViewDataGridView";
            advViewDataGridView.ReadOnly = true;
            advViewDataGridView.RowHeadersVisible = false;
            advViewDataGridView.RowHeadersWidth = 51;
            advViewDataGridView.Size = new Size(1265, 759);
            advViewDataGridView.TabIndex = 0;
            // 
            // tabRoomAvailability
            // 
            tabRoomAvailability.BackColor = Color.White;
            tabRoomAvailability.Controls.Add(lblOccupied);
            tabRoomAvailability.Controls.Add(lblReserved);
            tabRoomAvailability.Controls.Add(lblOccupiedHeaders);
            tabRoomAvailability.Controls.Add(lblReservedHeaders);
            tabRoomAvailability.Controls.Add(roomOccupiedListBox);
            tabRoomAvailability.Controls.Add(roomReservedListBox);
            tabRoomAvailability.Location = new Point(4, 32);
            tabRoomAvailability.Margin = new Padding(3, 4, 3, 4);
            tabRoomAvailability.Name = "tabRoomAvailability";
            tabRoomAvailability.Size = new Size(1291, 793);
            tabRoomAvailability.TabIndex = 3;
            tabRoomAvailability.Text = "Room availibility";
            // 
            // lblOccupied
            // 
            lblOccupied.AutoSize = true;
            lblOccupied.Location = new Point(19, 27);
            lblOccupied.Name = "lblOccupied";
            lblOccupied.Size = new Size(82, 23);
            lblOccupied.TabIndex = 0;
            lblOccupied.Text = "Occupied";
            // 
            // lblReserved
            // 
            lblReserved.AutoSize = true;
            lblReserved.Location = new Point(666, 27);
            lblReserved.Name = "lblReserved";
            lblReserved.Size = new Size(78, 23);
            lblReserved.TabIndex = 1;
            lblReserved.Text = "Reserved";
            // 
            // lblOccupiedHeaders
            // 
            lblOccupiedHeaders.AutoSize = true;
            lblOccupiedHeaders.Location = new Point(19, 71);
            lblOccupiedHeaders.Name = "lblOccupiedHeaders";
            lblOccupiedHeaders.Size = new Size(293, 23);
            lblOccupiedHeaders.TabIndex = 2;
            lblOccupiedHeaders.Text = "Room# | Type | ID# | Name | Phone #";
            // 
            // lblReservedHeaders
            // 
            lblReservedHeaders.AutoSize = true;
            lblReservedHeaders.Location = new Point(666, 71);
            lblReservedHeaders.Name = "lblReservedHeaders";
            lblReservedHeaders.Size = new Size(412, 23);
            lblReservedHeaders.TabIndex = 3;
            lblReservedHeaders.Text = "Room# | Type | ID# | Name | Phone # | Entry | Depart";
            // 
            // roomOccupiedListBox
            // 
            roomOccupiedListBox.BackColor = Color.FromArgb(230, 230, 230);
            roomOccupiedListBox.BorderStyle = BorderStyle.None;
            roomOccupiedListBox.Location = new Point(19, 116);
            roomOccupiedListBox.Margin = new Padding(3, 4, 3, 4);
            roomOccupiedListBox.Name = "roomOccupiedListBox";
            roomOccupiedListBox.Size = new Size(627, 782);
            roomOccupiedListBox.TabIndex = 4;
            // 
            // roomReservedListBox
            // 
            roomReservedListBox.BackColor = Color.FromArgb(230, 230, 230);
            roomReservedListBox.BorderStyle = BorderStyle.None;
            roomReservedListBox.Location = new Point(666, 116);
            roomReservedListBox.Margin = new Padding(3, 4, 3, 4);
            roomReservedListBox.Name = "roomReservedListBox";
            roomReservedListBox.Size = new Size(627, 782);
            roomReservedListBox.TabIndex = 5;
            // 
            // Frontend
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1358, 929);
            Controls.Add(lblClose);
            Controls.Add(tabControlMain);
            Controls.Add(lblTitle);
            Controls.Add(topGreenBar);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Frontend";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frontend";
            Load += Frontend_Load;
            MouseDown += Form_MouseDown;
            tabControlMain.ResumeLayout(false);
            tabReservation.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlMiddle.ResumeLayout(false);
            pnlMiddle.PerformLayout();
            pnlRight.ResumeLayout(false);
            tabUniversalSearch.ResumeLayout(false);
            tabUniversalSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)searchDataGridView).EndInit();
            tabAdvView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)advViewDataGridView).EndInit();
            tabRoomAvailability.ResumeLayout(false);
            tabRoomAvailability.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        #region Main Layout & System Controls
        private System.Windows.Forms.Panel topGreenBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.TabControl tabControlMain;
        #endregion

        #region Tab 1: Reservation
        private System.Windows.Forms.TabPage tabReservation;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblName, lblBirthday, lblGender, lblPhone, lblEmail, lblChoices, lblEntry, lblDeparture;
        private System.Windows.Forms.TextBox txtFirst, txtLast, txtPhone, txtEmail, txtStreet, txtApt, txtCity, txtZip;
        private System.Windows.Forms.ComboBox cmbMonth, cmbDay, cmbYear, cmbGender, cmbState, cmbGuests, cmbRoomType, cmbFloor, cmbRoomNo, cmbEditReservation;
        private System.Windows.Forms.DateTimePicker dtpEntry, dtpDeparture;
        private System.Windows.Forms.CheckBox chkCheckIn, chkSendSms, chkFoodStatus;
        private System.Windows.Forms.Button btnFoodMenu, btnFinalizeBill, btnSubmit, btnUpdate, btnDelete, btnEditExisting, btnNewReservation;
        #endregion

        #region Tab 2: Universal Search
        private System.Windows.Forms.TabPage tabUniversalSearch;
        private System.Windows.Forms.TextBox txtUniversalSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView searchDataGridView;
        #endregion

        #region Tab 3: Adv View
        private System.Windows.Forms.TabPage tabAdvView;
        private System.Windows.Forms.DataGridView advViewDataGridView;
        #endregion

        #region Tab 4: Room Availability
        private System.Windows.Forms.TabPage tabRoomAvailability;
        private System.Windows.Forms.Label lblOccupied, lblReserved, lblOccupiedHeaders, lblReservedHeaders;
        private System.Windows.Forms.ListBox roomOccupiedListBox, roomReservedListBox;
        #endregion
    }
}