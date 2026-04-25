using Assignment2.Context;
using Assignment2.Entities;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Assignmint2
{
    public partial class Frontend : Form
    {
        #region DLL Imports & Class Variables
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        bool food_Breakfast, food_Lunch, food_Dinner;
        int qty_Breakfast, qty_Lunch, qty_Dinner;
        bool special_Cleaning, special_Towels, special_Surprise;

        private double payment_TotalBill;
        private int payment_FoodBill;
        private string payment_Type = "";
        private string payment_CardType = "";
        private string payment_CardNumber = "";
        private string payment_CardExp = "";
        private string payment_CardCvc = "";
        #endregion

        #region Constructor & Initialization
        public Frontend()
        {
            InitializeComponent();

            Button btnLogout = new Button();
            btnLogout.Text = "Log Out";
            btnLogout.Size = new Size(120, 40);
            btnLogout.Location = new Point(780, 10); 
            btnLogout.BackColor = Color.Crimson; 
            btnLogout.ForeColor = Color.White;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Click += (s, e) => {
                Assignment2.Login loginForm = new Assignment2.Login();
                loginForm.Show();
                this.Hide();
            };
            this.Controls.Add(btnLogout);
            btnLogout.BringToFront();

            btnFoodMenu.Click += btnFoodMenu_Click;
            btnFinalizeBill.Click += btnFinalizeBill_Click;
            btnSubmit.Click += btnSubmit_Click;
            btnEditExisting.Click += btnEditExisting_Click;
            btnNewReservation.Click += btnNewReservation_Click;
            btnUpdate.Click += btnUpdate_Click;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            cmbEditReservation.SelectedIndexChanged += cmbEditReservation_SelectedIndexChanged;
            tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;

            dtpEntry.Format = DateTimePickerFormat.Short;
            dtpDeparture.Format = DateTimePickerFormat.Short;

            AddPlaceholderManager(txtFirst, "First");
            AddPlaceholderManager(txtLast, "Last");
            AddPlaceholderManager(txtPhone, "(999) 999-9999");
            AddPlaceholderManager(txtEmail, "first.last@example.com");
            AddPlaceholderManager(txtStreet, "Street address");
            AddPlaceholderManager(txtApt, "Apt./Suite");
            AddPlaceholderManager(txtCity, "City");
            AddPlaceholderManager(txtZip, "Zip code");
        }

        private void Frontend_Load(object sender, EventArgs e)
        {
            searchDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            searchDataGridView.ScrollBars = ScrollBars.Both;

            advViewDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            advViewDataGridView.ScrollBars = ScrollBars.Both;

            btnSubmit.Visible = false;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;

            string[] Months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            cmbMonth.Items.AddRange(Months);

            for (int i = 1; i <= 31; i++) cmbDay.Items.Add(i.ToString());
            for (int i = 1995; i <= 2025; i++) cmbYear.Items.Add(i.ToString());

            cmbGender.Items.AddRange(new string[] { "Male", "Female" });

            string[] states = { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado",
                                "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho",
                                "Illinois", "New York", "Texas", "Washington" };
            cmbState.Items.AddRange(states);

            cmbGuests.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6" });
            cmbRoomType.Items.AddRange(new string[] { "Single", "Double", "Suite", "Duplex", "Twin" });
            cmbFloor.Items.AddRange(new string[] { "1", "2", "3", "4", "5" });

            using (var hotelContext = new Assignment2.Context.HotelContext())
            {
                var occupiedRooms = hotelContext.Reservations.Select(r => r.RoomNumber.Trim()).ToList();
                for (int i = 100; i <= 500; i++)
                {
                    if (!occupiedRooms.Contains(i.ToString())) cmbRoomNo.Items.Add(i.ToString());
                }
            }
        }
        #endregion

        #region Window Controls & UI Helpers
        private void AddPlaceholderManager(TextBox textBox, string placeholder)
        {
            textBox.ForeColor = string.IsNullOrWhiteSpace(textBox.Text) || textBox.Text == placeholder ? Color.Gray : Color.Black;

            textBox.Enter += (sender, e) => { if (textBox.Text == placeholder) { textBox.Text = ""; textBox.ForeColor = Color.Black; } };
            textBox.Leave += (sender, e) => { if (string.IsNullOrWhiteSpace(textBox.Text)) { textBox.Text = placeholder; textBox.ForeColor = Color.Gray; } };
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); }
        }

        private void lblClose_Click(object sender, EventArgs e) => Application.Exit();
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
        #endregion

        #region Tab 1: Create Reservation & Billing
        private void btnFoodMenu_Click(object sender, EventArgs e)
        {
            FoodMenu foodForm = new FoodMenu();

            if (foodForm.ShowDialog() == DialogResult.OK)
            {
                food_Breakfast = foodForm.HasBreakfast; qty_Breakfast = foodForm.BreakfastQty;
                food_Lunch = foodForm.HasLunch; qty_Lunch = foodForm.LunchQty;
                food_Dinner = foodForm.HasDinner; qty_Dinner = foodForm.DinnerQty;
                special_Cleaning = foodForm.NeedsCleaning; special_Towels = foodForm.NeedsTowels; special_Surprise = foodForm.NeedsSurprise;
                chkFoodStatus.Checked = true;
            }
        }

        private void btnFinalizeBill_Click(object sender, EventArgs e)
        {
            if (cmbRoomType.SelectedIndex == -1 || cmbRoomType.Text == "Room type")
            {
                MessageBox.Show("Please select a Room Type before finalizing the bill.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int daysStaying = (dtpDeparture.Value.Date - dtpEntry.Value.Date).Days;
            if (daysStaying <= 0) daysStaying = 1;

            double roomRate = cmbRoomType.Text == "Single" ? 50.0 : cmbRoomType.Text == "Double" ? 100.0 : cmbRoomType.Text == "Twin" ? 120.0 : 200.0;
            double totalReservationCost = roomRate * daysStaying;
            double totalFoodCost = (qty_Breakfast * 7.0) + (qty_Lunch * 15.0) + (qty_Dinner * 15.0);

            FinalizePayment paymentForm = new FinalizePayment();
            paymentForm.ReservationCost = totalReservationCost;
            paymentForm.FoodCost = totalFoodCost;

            if (paymentForm.ShowDialog() == DialogResult.OK)
            {
                payment_TotalBill = paymentForm.FinalTotalBill;
                payment_FoodBill = (int)totalFoodCost;
                payment_Type = paymentForm.SelectedPaymentType;
                payment_CardNumber = paymentForm.CardNumber;
                payment_CardExp = paymentForm.CardExp;
                payment_CardCvc = paymentForm.CardCvc;
                payment_CardType = paymentForm.CardType;

                btnSubmit.Visible = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtFirst.Text == "First" || txtLast.Text == "Last" || txtPhone.Text == "(999) 999-9999" ||
                cmbMonth.SelectedIndex == -1 || cmbDay.SelectedIndex == -1 || cmbYear.SelectedIndex == -1 ||
                cmbGender.SelectedIndex == -1 || cmbState.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill out all Guest Information on the left side before submitting.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string formattedBirthday = $"{cmbMonth.Text}-{cmbDay.Text}-{cmbYear.Text}";

            Reservation newReservation = new Reservation
            {
                FirstName = txtFirst.Text,
                LastName = txtLast.Text,
                BirthDay = formattedBirthday,
                Gender = cmbGender.Text,
                PhoneNumber = txtPhone.Text,
                EmailAddress = txtEmail.Text == "first.last@example.com" ? "" : txtEmail.Text,
                NumberGuest = int.Parse(cmbGuests.Text),
                StreetAddress = txtStreet.Text == "Street address" ? "" : txtStreet.Text,
                AptSuite = txtApt.Text == "Apt./Suite" ? "" : txtApt.Text,
                City = txtCity.Text == "City" ? "" : txtCity.Text,
                State = cmbState.Text,
                ZipCode = txtZip.Text == "Zip code" ? "" : txtZip.Text,
                RoomType = cmbRoomType.Text,
                RoomFloor = cmbFloor.Text,
                RoomNumber = cmbRoomNo.Text,

                TotalBill = payment_TotalBill,
                FoodBill = payment_FoodBill,
                PaymentType = payment_Type,
                CardType = payment_CardType,
                CardNumber = payment_CardNumber,
                CardExp = payment_CardExp,
                CardCvc = payment_CardCvc,

                ArrivalTime = dtpEntry.Value,
                LeavingTime = dtpDeparture.Value,
                CheckIn = chkCheckIn.Checked,
                Breakfast = qty_Breakfast,
                Lunch = qty_Lunch,
                Dinner = qty_Dinner,
                Cleaning = special_Cleaning,
                Towel = special_Towels,
                SSurprise = special_Surprise,
                SupplyStatus = chkFoodStatus.Checked
            };

            try
            {
                using (var hotelContext = new Assignment2.Context.HotelContext())
                {
                    hotelContext.Reservations.Add(newReservation);
                    hotelContext.SaveChanges();
                }

                MessageBox.Show("Reservation successfully saved to the database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSubmit.Visible = false;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                if (ex.InnerException != null) errorMsg += "\n\nInner Exception: " + ex.InnerException.Message;
                MessageBox.Show($"Database Error:\n\n{errorMsg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Tab 1: Edit, Update & Delete
        private void btnEditExisting_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = true; btnDelete.Visible = true; btnSubmit.Visible = false;
            using (var context = new Assignment2.Context.HotelContext())
            {
                var reservationList = context.Reservations.Select(r => new { r.Id, DisplayText = r.Id + " - " + r.FirstName + " " + r.LastName }).ToList();
                cmbEditReservation.DataSource = reservationList;
                cmbEditReservation.DisplayMember = "DisplayText";
                cmbEditReservation.ValueMember = "Id";
                cmbEditReservation.SelectedIndex = -1;
            }
        }

        private void cmbEditReservation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEditReservation.SelectedIndex == -1 || !(cmbEditReservation.SelectedValue is int)) return;
            int selectedId = (int)cmbEditReservation.SelectedValue;

            using (var context = new Assignment2.Context.HotelContext())
            {
                var res = context.Reservations.Find(selectedId);
                if (res != null)
                {
                    txtFirst.Text = res.FirstName; txtFirst.ForeColor = Color.Black;
                    txtLast.Text = res.LastName; txtLast.ForeColor = Color.Black;
                    txtPhone.Text = res.PhoneNumber; txtPhone.ForeColor = Color.Black;
                    txtEmail.Text = res.EmailAddress; txtEmail.ForeColor = Color.Black;
                    txtStreet.Text = res.StreetAddress; txtStreet.ForeColor = Color.Black;
                    txtApt.Text = res.AptSuite; txtApt.ForeColor = Color.Black;
                    txtCity.Text = res.City; txtCity.ForeColor = Color.Black;
                    txtZip.Text = res.ZipCode; txtZip.ForeColor = Color.Black;

                    cmbGender.Text = res.Gender; cmbState.Text = res.State; cmbGuests.Text = res.NumberGuest.ToString();
                    cmbRoomType.Text = res.RoomType.Trim(); cmbFloor.Text = res.RoomFloor.Trim(); cmbRoomNo.Text = res.RoomNumber.Trim();
                    dtpEntry.Value = res.ArrivalTime; dtpDeparture.Value = res.LeavingTime;
                    chkCheckIn.Checked = res.CheckIn; chkFoodStatus.Checked = res.SupplyStatus;

                    string[] bdayParts = res.BirthDay.Split('-');
                    if (bdayParts.Length == 3) { cmbMonth.Text = bdayParts[0].Trim(); cmbDay.Text = bdayParts[1].Trim(); cmbYear.Text = bdayParts[2].Trim(); }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbEditReservation.SelectedIndex == -1 || !(cmbEditReservation.SelectedValue is int)) return;
            int selectedId = (int)cmbEditReservation.SelectedValue;

            using (var context = new Assignment2.Context.HotelContext())
            {
                var res = context.Reservations.Find(selectedId);
                if (res != null)
                {
                    res.FirstName = txtFirst.Text; res.LastName = txtLast.Text; res.BirthDay = $"{cmbMonth.Text}-{cmbDay.Text}-{cmbYear.Text}";
                    res.Gender = cmbGender.Text; res.PhoneNumber = txtPhone.Text; res.EmailAddress = txtEmail.Text;
                    res.StreetAddress = txtStreet.Text; res.AptSuite = txtApt.Text; res.City = txtCity.Text; res.State = cmbState.Text; res.ZipCode = txtZip.Text;
                    res.NumberGuest = int.Parse(cmbGuests.Text); res.RoomType = cmbRoomType.Text; res.RoomFloor = cmbFloor.Text; res.RoomNumber = cmbRoomNo.Text;
                    res.ArrivalTime = dtpEntry.Value; res.LeavingTime = dtpDeparture.Value; res.CheckIn = chkCheckIn.Checked; res.SupplyStatus = chkFoodStatus.Checked;

                    context.SaveChanges();
                    MessageBox.Show("Reservation updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEditExisting_Click(null, null);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbEditReservation.SelectedIndex == -1 || !(cmbEditReservation.SelectedValue is int)) return;
            int selectedId = (int)cmbEditReservation.SelectedValue;

            if (MessageBox.Show("PERMANENTLY delete this reservation?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var context = new Assignment2.Context.HotelContext())
                {
                    var res = context.Reservations.Find(selectedId);
                    if (res != null) { context.Reservations.Remove(res); context.SaveChanges(); MessageBox.Show("Deleted."); btnNewReservation_Click(null, null); }
                }
            }
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false; btnDelete.Visible = false; btnSubmit.Visible = false; cmbEditReservation.DataSource = null;

            txtFirst.Text = "First"; txtFirst.ForeColor = Color.Gray; txtLast.Text = "Last"; txtLast.ForeColor = Color.Gray;
            txtPhone.Text = "(999) 999-9999"; txtPhone.ForeColor = Color.Gray; txtEmail.Text = "first.last@example.com"; txtEmail.ForeColor = Color.Gray;
            txtStreet.Text = "Street address"; txtStreet.ForeColor = Color.Gray; txtApt.Text = "Apt./Suite"; txtApt.ForeColor = Color.Gray;
            txtCity.Text = "City"; txtCity.ForeColor = Color.Gray; txtZip.Text = "Zip code"; txtZip.ForeColor = Color.Gray;

            cmbMonth.SelectedIndex = -1; cmbDay.SelectedIndex = -1; cmbYear.SelectedIndex = -1;
            cmbGender.SelectedIndex = -1; cmbState.SelectedIndex = -1; cmbGuests.SelectedIndex = -1;
            cmbRoomType.SelectedIndex = -1; cmbFloor.SelectedIndex = -1; cmbRoomNo.SelectedIndex = -1;

            chkCheckIn.Checked = false; chkFoodStatus.Checked = false;
            dtpEntry.Value = DateTime.Now; dtpDeparture.Value = DateTime.Now;
        }
        #endregion

        #region Tab 2: Universal Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtUniversalSearch.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(searchTerm)) return;

            using (var context = new Assignment2.Context.HotelContext())
            {
                var searchResults = context.Reservations
                    .Where(r => r.FirstName.ToLower().Contains(searchTerm) || r.LastName.ToLower().Contains(searchTerm) ||
                                r.PhoneNumber.Contains(searchTerm) || r.EmailAddress.ToLower().Contains(searchTerm) ||
                                r.City.ToLower().Contains(searchTerm) || r.RoomNumber.Contains(searchTerm)).ToList();

                if (searchResults.Count == 0) { MessageBox.Show("No results found."); searchDataGridView.DataSource = null; return; }
                searchDataGridView.DataSource = searchResults;
                if (searchDataGridView.Columns["Id"] != null) searchDataGridView.Columns["Id"].Visible = false;
            }
        }
        #endregion

        #region Tabs 3 & 4: Advanced View & Room Availability
        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabAdvView) LoadAdvancedViewData();
            else if (tabControlMain.SelectedTab == tabRoomAvailability) LoadRoomAvailabilityData();
        }

        private void LoadAdvancedViewData()
        {
            using (var context = new Assignment2.Context.HotelContext())
            {
                advViewDataGridView.DataSource = context.Reservations.ToList();
                advViewDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void LoadRoomAvailabilityData()
        {
            roomOccupiedListBox.Items.Clear(); roomReservedListBox.Items.Clear();
            using (var context = new Assignment2.Context.HotelContext())
            {
                foreach (var res in context.Reservations.ToList())
                {
                    string info = $"[{res.RoomNumber.Trim()}] {res.RoomType.Trim()} {res.Id} [{res.FirstName.Trim()} {res.LastName.Trim()}] {res.PhoneNumber.Trim()}";
                    if (res.CheckIn) roomOccupiedListBox.Items.Add(info);
                    else roomReservedListBox.Items.Add(info + $" {res.ArrivalTime:MM-dd-yyyy} {res.LeavingTime:MM-dd-yyyy}");
                }
            }
        }
        #endregion
    }
}