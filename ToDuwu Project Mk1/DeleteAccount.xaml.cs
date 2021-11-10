using System;
using System.Collections.Generic;
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
    /// Interaction logic for DeleteAccount.xaml
    /// </summary>
    public partial class DeleteAccount : Window
    {
        public DeleteAccount()
        {
            InitializeComponent();
        }

        private void confirmDelete_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Hello, Windows Presentation Foundation!");
            string connectionString = (@"Data Source=(localdb)\MSSQLLocalDB;" +
                "Initial Catalog=ToDuwu Database; Integrated Security=True; ");
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();

                string sqlQuery = @"SELECT * 
                                    FROM [User] 
                                    WHERE UserName=@UserName AND HashedPW=@HashedPW";
                SqlCommand com = new SqlCommand(sqlQuery, con);
                com.CommandType = System.Data.CommandType.Text;
                com.Parameters.AddWithValue("@UserName", deleteUser.Text);
                com.Parameters.AddWithValue("@HashedPW", deletePass.Text);
                var result = com.ExecuteScalar();


                if (result != null)
                {

                    sqlQuery = @"DELETE FROM [User] 
                                    WHERE UserName=@UserName AND HashedPW=@HashedPW";
                    com = new SqlCommand(sqlQuery, con);
                    com.CommandType = System.Data.CommandType.Text;
                    com.Parameters.AddWithValue("@UserName", deleteUser.Text);
                    com.Parameters.AddWithValue("@HashedPW", deletePass.Text);
                    result = com.ExecuteScalar();
                    // Create the Task window
                    Task window = new Task();

                    // Open the Task window
                    window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally {
                con.Close();
                // Create the Task window
                Login window = new Login();

                // Open the Task window
                window.Show();
                this.Close();
            }
        }
        private void btnCloseWin(object sender, RoutedEventArgs e)
        {
            {
                // Create the Task window
                Login window = new Login();

                // Open the Task window
                window.Show();
                this.Close();
            }
        }
    }
}
