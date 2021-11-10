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
using System.Data.SqlClient;
using System.Data;

namespace ToDuwu_Project_Mk1
{
    /// <summary>
    /// Interaction logic for CreateTaskWindow.xaml
    /// </summary>
    public partial class CreateTaskWindow : Window
    {
        public CreateTaskWindow()
        {
            InitializeComponent();
        }

        //closes task window
        private void btnCloseWin(object sender, RoutedEventArgs e)
        {
            // Create the Task window
            Task window = new Task();

            // Open the Task window
            window.Show();
            this.Close();
        }

        private void Difficulty_Slider(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        // adds task to database
        private void btnNewReg_Click(object sender, RoutedEventArgs e)
        {
            String connectionString = (@"Data Source=(localdb)\MSSQLLocalDB;" +
               "Initial Catalog=ToDuwu Database; Integrated Security=True; ");
            SqlConnection con = new(connectionString);

            try
            {

                con = new SqlConnection(connectionString);

                //open connection
                con.Open();

                //create a new SQL Query using StringBuilder
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append(@"INSERT INTO [Task] (UserName, FirstName, LastName, HashedPW) ");
                strBuilder.Append("VALUES (N'" + newGenre.Text + "', N'" + newTaskName.Text + "', N'" + newDate.Text + "' , N'" + newDesc.Text + "'); ");

                string sqlQuery = strBuilder.ToString();

                using (SqlCommand command = new SqlCommand(sqlQuery, con)) //pass SQL query created above and connection
                {
                    command.ExecuteNonQuery(); //execute the Query

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}