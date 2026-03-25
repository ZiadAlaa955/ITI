using Assignment2.Context;
using Assignment2.Entities;
using Assignmint2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Login : Form
    {
        // --- DLL IMPORTS FOR WINDOW DRAGGING ---
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        HotelContext hotelContext;
        string username, password;

        public Login()
        {
            InitializeComponent();

            // Load the pencil icon from Resources!
            if (Properties.Resources.edit != null)
            {
                picUser.Image = Properties.Resources.edit;
                picPass.Image = Properties.Resources.edit;
            }

            usernameTextBox.Enter += Username_Enter;
            usernameTextBox.Leave += Username_Leave;
            passwordTextBox.Enter += Password_Enter;
            passwordTextBox.Leave += Password_Leave;
        }

        // --- AUTHENTICATION LOGIC ---
        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            username = usernameTextBox.Text;
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            password = passwordTextBox.Text;
        }

        private void signinButton_Click_1(object sender, EventArgs e)
        {
            hotelContext = new HotelContext();

            bool isFrontEndUser = hotelContext.FrontendUsers.Any(u => u.UserName == username && u.Password == password);

            if (isFrontEndUser)
            {
                Frontend frontend = new Frontend();
                frontend.Show();
                this.Hide();
                return;
            }

            bool isKitchenUser = hotelContext.KitchenUsers.Any(u => u.UserName == username && u.Password == password);
            if (isKitchenUser)
            {
                Kitchen kitchen = new Kitchen();
                kitchen.Show();
                this.Hide();
                return;
            }

            MessageBox.Show("Invalid username or password. Please try again.");
        }

        // --- WINDOW DRAGGING LOGIC ---
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // --- CUSTOM X BUTTON LOGIC ---
        private void lblClose_Click(object sender, EventArgs e) => Application.Exit();
        private void lblClose_MouseEnter(object sender, EventArgs e) => lblClose.ForeColor = Color.Red;
        private void lblClose_MouseLeave(object sender, EventArgs e) => lblClose.ForeColor = Color.Gray;

        // --- PLACEHOLDER TEXT LOGIC ---
        private void Username_Enter(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "Username")
            {
                usernameTextBox.Text = "";
                usernameTextBox.ForeColor = Color.Black;
            }
        }

        private void Username_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text))
            {
                usernameTextBox.Text = "Username";
                usernameTextBox.ForeColor = Color.Gray;
            }
        }

        private void Password_Enter(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "Password")
            {
                passwordTextBox.Text = "";
                passwordTextBox.ForeColor = Color.Black;
                passwordTextBox.PasswordChar = '*';
            }
        }

        private void Password_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                passwordTextBox.PasswordChar = '\0';
                passwordTextBox.Text = "Password";
                passwordTextBox.ForeColor = Color.Gray;
            }
        }

        // --- CUSTOM UI PAINTING ---
        private void DrawBlueBorder(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, pnl.ClientRectangle,
                                    Color.DeepSkyBlue, 1, ButtonBorderStyle.Solid,
                                    Color.DeepSkyBlue, 1, ButtonBorderStyle.Solid,
                                    Color.DeepSkyBlue, 1, ButtonBorderStyle.Solid,
                                    Color.DeepSkyBlue, 1, ButtonBorderStyle.Solid);
        }

        private void Login_Load(object sender, EventArgs e) { }
    }
}