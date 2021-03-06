using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDuwu_Project_Mk1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {

            InitializeComponent();
        }

        public static string UserNow { get; set; }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show("Hello, Windows Presentation Foundation!");
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;" +
                "Initial Catalog=ToDuwu Database; Integrated Security=True; ";
            SqlConnection con = new(connectionString);

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();

                string sqlQuery = @"SELECT * 
                                    FROM [User] 
                                    WHERE UserName=@UserName AND HashedPW=@HashedPW";
                SqlCommand com = new SqlCommand(sqlQuery, con);
                com.CommandType = System.Data.CommandType.Text;
                com.Parameters.AddWithValue("@UserName", txtUserName.Text);
                com.Parameters.AddWithValue("@HashedPW", txtPassword.Password);
                object result = com.ExecuteScalar();


                if (result != null)
                {

                    UserNow = txtUserName.Text; // used for keeping track of the current user
                    // Create the Task window
                    Task window = new();

                    //(txtUserName.Text);   
                    // Open the Task window
                    window.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect.");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            // Create the window
            Register window = new();

            // Open the window
            window.Show();
            Close();
        }

        private void deleteFunc(object sender, RoutedEventArgs e)
        {
            // Create the Task window
            DeleteAccount window = new();

            // Open the Task window
            window.Show();
            Close();
        }
    }
}
