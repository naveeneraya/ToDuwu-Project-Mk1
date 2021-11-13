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
using Microsoft.SqlServer.Management.Smo.Wmi;

namespace ToDuwu_Project_Mk1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnNewReg_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;" +
                           "Initial Catalog=ToDuwu Database; Integrated Security=True; ";
            SqlConnection con = new(connectionString);

            try
            {

                con = new SqlConnection(connectionString);

                //open connection
                con.Open();

                string sqlQuery = @"SELECT * 
                                    FROM [User] 
                                    WHERE UserName=@UserName";
                SqlCommand com = new SqlCommand(sqlQuery, con);
                com.CommandType = System.Data.CommandType.Text;
                com.Parameters.AddWithValue("@UserName", newUserTxt.Text);

                string var = (string)com.ExecuteScalar();

                if (var != null)
                {
                    MessageBox.Show("User name already exists");
                }

                else
                {

                    //create a new SQL Query using StringBuilder
                    StringBuilder strBuilder = new StringBuilder();
                    strBuilder.Append(@"INSERT INTO [User] (UserName, FirstName, LastName, HashedPW) ");
                    strBuilder.Append("VALUES (N'" + newUserTxt.Text + "', N'" + newFirstTxt.Text + "', N'" + newlastTxt.Text + "' , N'" + confirmPass.Text + "'); ");

                    sqlQuery = strBuilder.ToString();

                    using (SqlCommand command = new SqlCommand(sqlQuery, con)) //pass SQL query created above and connection
                    {
                        command.ExecuteNonQuery(); //execute the Query

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            finally
            {
                // makes sure conn is always closed at end
                if (con != null)
                {
                    con.Close();
                }

                // Create the Login window
                Login window = new Login();

                // Open the Login window
                window.Show();

                this.Close();
            }
        }

        private void closeWin_Click(object sender, RoutedEventArgs e)
        {
            // Create the Task window
            Login window = new();

            // Open the Task window
            window.Show();
            Close();
        }
    }
}