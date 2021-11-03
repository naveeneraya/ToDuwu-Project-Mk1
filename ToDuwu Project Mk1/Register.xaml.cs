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
            var datasource = @"Data Source=(localdb)\MSSQLLocalDB";   //your server
            var database = "ToDuwu Database";   //your database name

            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;";


            SqlConnection conn = null;

            try
            {

                conn = new SqlConnection(connString);

                //open connection
                conn.Open();

                //create a new SQL Query using StringBuilder
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append(@"INSERT INTO [User] (Id, UserName, FirstName, LastName, HashedPW) ");
                strBuilder.Append("VALUES (" + 1 + ", N'" + newUserTxt  + "', N'" + newFirstTxt + "', N'" + newlastTxt + "' , N'" + confirmPass + "'); ");

                string sqlQuery = strBuilder.ToString();

                using (SqlCommand command = new SqlCommand(sqlQuery, conn)) //pass SQL query created above and connection
                {
                    command.ExecuteNonQuery(); //execute the Query
                    Console.WriteLine("Query Executed.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            finally {
                // makes sure conn is always closed at end
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
