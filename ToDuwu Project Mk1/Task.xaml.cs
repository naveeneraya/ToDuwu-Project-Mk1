using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    /// Interaction logic for Task.xaml
    /// </summary>
    public partial class Task : Window
    {
        public Task()
        {

            InitializeComponent();
            Random rand = new Random();
            int randNum = rand.Next(0, 6);
            // this is so cool, new switch statment dropped
            DisplayName.Text = randNum switch
            {
                0 => "Welcome back " + Login.UserNow + ", what are we doing today!",
                1 => "Let's get some tasks done," + Login.UserNow + "!",
                2 => "Go! Go! Go! Go! Go!",
                3 => "I am supporting you " + Login.UserNow + "!",
                4 => "No task is too difficult for us!",
                5 => "To whom much is given much is tested!",
                6 => "Keep moving forward!",
                _ => "ERROR 404!",
            };

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;" +
                          "Initial Catalog=ToDuwu Database; Integrated Security=True; ";
            using (SqlConnection con = new(connectionString))
            {
                string CmdString = "SELECT * FROM [Task] WHERE [User]=@UserName";
                SqlCommand cmd = new(CmdString, con);
                cmd.Parameters.AddWithValue("@UserName", Login.UserNow);
                SqlDataAdapter sda = new(cmd);
                DataTable dt = new("[Task]");
                sda.Fill(dt);
                TheDataGrid.ItemsSource = dt.DefaultView;
            }


        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        //button that takes user to new popup that creates a task
        private void newTaskBttn(object sender, RoutedEventArgs e)
        {
            // Create the CreateTaskWindow window
            CreateTaskWindow window = new();

            // Open the CreateTaskWindow window
            window.Show();
            Close();
        }
        private void editTaskBttn(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "UPDATE [Task]" +
                                  "SET TaskDescription=@param1, DueDate=@param2, Difficulty=@param3, Group=@param4 " +
                                  "WHERE TaskName=@paramTaskName";            
        }


        private void logout_click(object sender, RoutedEventArgs e)
        {
            // Create the CreateTaskWindow window
            Login window = new();

            // Open the CreateTaskWindow window
            window.Show();
            Close();

        }

        private void TaskEditDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Create the EditWindow window

            DataGrid dataGrid = sender as DataGrid;
            
            if (dataGrid != null)
            {
               
                var index = dataGrid.SelectedItem;
                //dostuff with index
            }
            /*
            EditWindow window = new();

            // Open the EditWindow window
            window.Show();
            Close(); */
        }

        private void TheDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataRowView row = TheDataGrid.SelectedItem as DataRowView;

            EditWindow window = new(row);

            // Open the EditWindow window
            window.Show();
            Close();
            /*
            for (int i = 0; i < 7; i++) {
                print += row.Row.ItemArray[i].ToString();
            }
            MessageBox.Show(print);
            */

        }

        private void masterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
