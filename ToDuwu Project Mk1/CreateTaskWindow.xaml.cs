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
            Task window = new();

            // Open the Task window
            window.Show();
            Close();
        }

        private void Difficulty_Slider(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        // adds task to database
        private void btnNewReg_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = (@"Data Source=(localdb)\MSSQLLocalDB;" +
               "Initial Catalog=ToDuwu Database; Integrated Security=True; ");
            SqlConnection con = new(connectionString);

            try
            {

                con = new SqlConnection(connectionString);

                //open connection
                con.Open();

                string sqlQuery = "INSERT INTO [Task] (Id, [User], TaskName, TaskDescription, DueDate, Difficulty, [Group]) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7)";
                Random rand = new Random();
                int randNum = rand.Next(0, 99999);


                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.Int).Value = randNum;
                    cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value =Login.UserNow;
        
                    cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = newTaskName.Text;
                    cmd.Parameters.Add("@param4", SqlDbType.VarChar, 50).Value = newDesc.Text;
                    cmd.Parameters.Add("@param5", SqlDbType.Date).Value = newDate.SelectedDate.Value.Date.ToShortDateString();
                    cmd.Parameters.Add("@param6", SqlDbType.Int).Value = (int)DifficultySlider.Value;
                    cmd.Parameters.Add("@param7", SqlDbType.VarChar, 50).Value = newGenre.Text;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand(sqlQuery, con)) //pass SQL query created above and connection
                {
                    command.ExecuteNonQuery(); //execute the Query

                }
            }
            catch (SqlException esq) {
                //MessageBox.Show("Inputted");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
                // Create the Task window
                Task window = new Task();

        
                // Open the Task window
                window.Show();
                this.Close();
            }
        }
    }
}