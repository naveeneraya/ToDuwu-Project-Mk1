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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show("Hello, Windows Presentation Foundation!");
            String connectionString = (@"Data Source=(localdb)\MSSQLLocalDB;" +
                "Initial Catalog=ToDuwu Database; Integrated Security=True; ");
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();

                String sqlQuery = @"SELECT * 
                                    FROM [User] 
                                    WHERE UserName=@UserName AND HashedPW=@HashedPW";
                SqlCommand com = new SqlCommand(sqlQuery, con);
                com.CommandType = System.Data.CommandType.Text;
                com.Parameters.AddWithValue("@UserName", txtUserName.Text);
                com.Parameters.AddWithValue("@HashedPW", txtPassword.Password);

                object count = com.ExecuteScalar();
                Int32 check = System.Convert.ToInt32(count);

                if (check == 1)
                {
                    var cApp = ((App)Application.Current);
                    cApp.MainWindow = new MainWindow();
                    cApp.MainWindow.Show();
                    this.Close();
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
            Register window = new Register();

            // Open the window
            window.Show();
            this.Close();
        }
    }
}
