using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GetLearning
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        /// Event handler for the "Don't have an account? Sign up" hyperlink
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Navigates the user to the Login page
            RegisterWindow RegisterWindow = new RegisterWindow();
            RegisterWindow.Show();

            // Close the RegisterWindow (current window)
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = tbLoginEmail.Text.Trim();
            string password = tbLoginPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            string dbPath = "users.db";
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM users WHERE email = @Email AND password = @Password";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password); // Plain text (can hash later)

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        // Login successful
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        // Login failed
                        MessageBox.Show("Invalid email or password.");
                    }
                }
            }
        }

        private void btnLoginClear_Click(object sender, RoutedEventArgs e)
        {
            // Clear all textboxes on the login page
            tbLoginEmail.Clear();
            tbLoginPassword.Clear();
        }
    }
}
