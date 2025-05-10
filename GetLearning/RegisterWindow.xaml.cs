using System;
using System.Collections.Generic;
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
//Add the following namespaces
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;

namespace GetLearning
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

            // Initialize the database
            InitializeDatabase();
        }

        /// Event handler for the "Already have an account? Login" hyperlink
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Navigates the user to the Login page
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();

            // Close the RegisterWindow (current window)
            this.Close();
        }

        /// Event handler for the "Register" button
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string firstName = tbFirstName.Text;
            string surname = tbSurname.Text;
            string email = tbEmail.Text;
            string confirmEmail = tbConfirmEmail.Text;
            string password = tbPassword.Text;
            string confirmPassword = tbConfirmPassword.Text;

            if (email != confirmEmail)
            {
                MessageBox.Show("Emails do not match!");
            }
            else if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!");
            }
            else
            {
                string dbPath = "users.db";

                using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO users (firstname, surname, email, password) VALUES (@first, @last, @email, @password)";
                    using (var cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@first", firstName);
                        cmd.Parameters.AddWithValue("@last", surname);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Registration successful!");

                            LoginWindow loginWindow = new LoginWindow();
                            loginWindow.Show();
                            this.Close();
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show("Registration failed: " + ex.Message);
                        }
                    }

                    conn.Close();
                }
            }
        }

        /// Event handler for the "Clear" button
        private void btnRegisterClear_Click(object sender, RoutedEventArgs e)
        {
            // Clear all textboxes on the register page
            tbFirstName.Clear();
            tbSurname.Clear();
            tbEmail.Clear();
            tbConfirmEmail.Clear();
            tbPassword.Clear();
            tbConfirmPassword.Clear();
        }


        private void InitializeDatabase()
        {
            string dbPath = "users.db";

            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);

                using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();

                    string createTableQuery = @"
                CREATE TABLE users (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    firstname TEXT NOT NULL,
                    surname TEXT NOT NULL,
                    email TEXT NOT NULL UNIQUE,
                    password TEXT NOT NULL
                );
            ";

                    using (var cmd = new SQLiteCommand(createTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
        }

    }

}


