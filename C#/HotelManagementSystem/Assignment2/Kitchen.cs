using Assignment2.Context;
using Assignment2.Entities;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Kitchen : Form
    {
        private int selectedReservationId = -1;

        #region Initialization & UI Setup
        public Kitchen()
        {
            InitializeComponent();

            // ==========================================
            // DYNAMIC LOGOUT BUTTON
            // ==========================================
            Button btnLogout = new Button();
            btnLogout.Text = "Log Out";
            btnLogout.Size = new Size(120, 40);
            btnLogout.Location = new Point(850, 10); // Places it neatly at the top right of the Kitchen
            btnLogout.BackColor = Color.Crimson; // Professional Red color
            btnLogout.ForeColor = Color.White;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Click += (s, e) => {
                // Return to Login screen
                Assignment2.Login loginForm = new Assignment2.Login();
                loginForm.Show();
                this.Hide();
            };
            this.Controls.Add(btnLogout);
            btnLogout.BringToFront();

            this.Load += Kitchen_Load;
            btnChangeFood.Click += btnChangeFood_Click;
            btnUpdateChanges.Click += btnUpdateChanges_Click;
            overviewDataGridView.CellClick += overviewDataGridView_CellClick;
            tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
            queueListBox.SelectedIndexChanged += queueListBox_SelectedIndexChanged;

            AddPlaceholderManager(txtFirstName, "First");
            AddPlaceholderManager(txtLastName, "Last");
            AddPlaceholderManager(txtPhone, "(999)-999-9999");
            AddPlaceholderManager(txtRoomType, "Room type");
            AddPlaceholderManager(txtFloor, "Floor #");
            AddPlaceholderManager(txtRoomNo, "Room #");
            AddPlaceholderManager(txtBreakfast, "Breakfast");
            AddPlaceholderManager(txtLunch, "Lunch");
            AddPlaceholderManager(txtDinner, "Dinner");
        }

        private void Kitchen_Load(object sender, EventArgs e)
        {
            overviewDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            overviewDataGridView.ScrollBars = ScrollBars.Both;

            LoadOverviewGrid();
            LoadQueueList();
        }
        #endregion

        #region Data Loading
        private void LoadOverviewGrid()
        {
            using (var context = new HotelContext())
            {
                overviewDataGridView.DataSource = context.Reservations
                    .Select(r => new { r.Id, Name = r.FirstName + " " + r.LastName, r.RoomNumber, r.Breakfast, r.Lunch, r.Dinner, r.SupplyStatus })
                    .ToList();
            }
        }

        private void LoadQueueList()
        {
            using (var context = new HotelContext())
            {
                var reservations = context.Reservations
                    .Select(r => new { r.Id, DisplayText = r.Id + " | " + r.FirstName.Trim() + " " + r.LastName.Trim() + " | " + r.PhoneNumber.Trim() })
                    .ToList();

                queueListBox.SelectedIndexChanged -= queueListBox_SelectedIndexChanged;
                queueListBox.DataSource = reservations;
                queueListBox.DisplayMember = "DisplayText";
                queueListBox.ValueMember = "Id";
                queueListBox.SelectedIndex = -1;
                queueListBox.SelectedIndexChanged += queueListBox_SelectedIndexChanged;
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabOverview) LoadOverviewGrid();
            else if (tabControlMain.SelectedTab == tabTodo) LoadQueueList();
        }
        #endregion

        #region Guest Selection & UI Filling
        private void overviewDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedReservationId = (int)overviewDataGridView.Rows[e.RowIndex].Cells["Id"].Value;
                tabControlMain.SelectedTab = tabTodo;
                queueListBox.SelectedValue = selectedReservationId;
            }
        }

        private void queueListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (queueListBox.SelectedIndex == -1 || !(queueListBox.SelectedValue is int)) return;
            selectedReservationId = (int)queueListBox.SelectedValue;
            LoadGuestDetails(selectedReservationId);
        }

        private void LoadGuestDetails(int id)
        {
            using (var context = new HotelContext())
            {
                var res = context.Reservations.Find(id);
                if (res != null)
                {
                    txtFirstName.Text = res.FirstName; txtFirstName.ForeColor = Color.Black;
                    txtLastName.Text = res.LastName; txtLastName.ForeColor = Color.Black;
                    txtPhone.Text = res.PhoneNumber; txtPhone.ForeColor = Color.Black;
                    txtRoomType.Text = res.RoomType.Trim(); txtRoomType.ForeColor = Color.Black;
                    txtFloor.Text = res.RoomFloor.Trim(); txtFloor.ForeColor = Color.Black;
                    txtRoomNo.Text = res.RoomNumber.Trim(); txtRoomNo.ForeColor = Color.Black;

                    txtBreakfast.Text = res.Breakfast.ToString(); txtBreakfast.ForeColor = Color.Black;
                    txtLunch.Text = res.Lunch.ToString(); txtLunch.ForeColor = Color.Black;
                    txtDinner.Text = res.Dinner.ToString(); txtDinner.ForeColor = Color.Black;
                    chkCleaning.Checked = res.Cleaning; chkTowels.Checked = res.Towel;
                    chkSurprise.Checked = res.SSurprise; chkFoodStatus.Checked = res.SupplyStatus;
                }
            }
        }
        #endregion

        #region Updating Changes
        private void btnChangeFood_Click(object sender, EventArgs e)
        {
            if (selectedReservationId == -1) { MessageBox.Show("Select a guest first."); return; }

            Assignmint2.FoodMenu foodPopup = new Assignmint2.FoodMenu();
            if (foodPopup.ShowDialog() == DialogResult.OK)
            {
                txtBreakfast.Text = foodPopup.BreakfastQty.ToString(); txtBreakfast.ForeColor = Color.Black;
                txtLunch.Text = foodPopup.LunchQty.ToString(); txtLunch.ForeColor = Color.Black;
                txtDinner.Text = foodPopup.DinnerQty.ToString(); txtDinner.ForeColor = Color.Black;
                chkCleaning.Checked = foodPopup.NeedsCleaning; chkTowels.Checked = foodPopup.NeedsTowels; chkSurprise.Checked = foodPopup.NeedsSurprise;
            }
        }

        private void btnUpdateChanges_Click(object sender, EventArgs e)
        {
            if (selectedReservationId == -1) return;

            using (var context = new HotelContext())
            {
                var res = context.Reservations.Find(selectedReservationId);
                if (res != null)
                {
                    int.TryParse(txtBreakfast.Text, out int bQty); int.TryParse(txtLunch.Text, out int lQty); int.TryParse(txtDinner.Text, out int dQty);

                    res.Breakfast = bQty; res.Lunch = lQty; res.Dinner = dQty;
                    res.Cleaning = chkCleaning.Checked; res.Towel = chkTowels.Checked; res.SSurprise = chkSurprise.Checked;
                    res.SupplyStatus = chkFoodStatus.Checked;
                    res.FoodBill = (res.Breakfast * 7) + (res.Lunch * 15) + (res.Dinner * 15);

                    context.SaveChanges();
                    MessageBox.Show("Kitchen changes saved successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region DLL Imports & UI Helpers
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void AddPlaceholderManager(TextBox textBox, string placeholder)
        {
            textBox.Enter += (sender, e) => { if (textBox.Text == placeholder) { textBox.Text = ""; textBox.ForeColor = Color.Black; } };
            textBox.Leave += (sender, e) => { if (string.IsNullOrWhiteSpace(textBox.Text)) { textBox.Text = placeholder; textBox.ForeColor = Color.Gray; } };
        }

        private void Form_MouseDown(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); } }

        // KILLS THE ENTIRE APP SO NOTHING RUNS IN THE BACKGROUND
        private void lblClose_Click(object sender, EventArgs e) => Application.Exit();
        private void lblClose_MouseEnter(object sender, EventArgs e) => lblClose.ForeColor = Color.Red;
        private void lblClose_MouseLeave(object sender, EventArgs e) => lblClose.ForeColor = Color.Gray;
        #endregion
    }
}