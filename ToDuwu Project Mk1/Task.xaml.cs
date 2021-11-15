﻿using System;
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
            DisplayName.Text = "Welcome back " + Login.UserNow + ", what are we doing today!";
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;" +
                          "Initial Catalog=ToDuwu Database; Integrated Security=True; ";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string CmdString = "SELECT * FROM [Task]";
                SqlCommand cmd = new(CmdString, con);
                SqlDataAdapter sda = new(cmd);
                DataTable dt = new("[Task]");
                sda.Fill(dt);
                TheDataGrid.ItemsSource = dt.DefaultView;
            }
            
        }
        //sorts by difficulty
        private void difficultySort(object sender, RoutedEventArgs e)
        {
            var sql = "SELECT* FROM dboTask ORDER BY difficulty DESC";
        }
        //sorts by task name alphabetically
        private void sortByName(object sender, RoutedEventArgs e)
        {
            var sql = "SELECT* FROM dboTask ORDER BY TaskName";
        }


        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        //sorting function for due date
        private void DueDateSort(object sender, RoutedEventArgs e)
        {
            var sql = "SELECT* FROM dboTask ORDER BY DueDate";
        }

        //button that takes user to new popup that creates a task
        private void newTaskBttn(object sender, RoutedEventArgs e)
        {
            // Create the CreateTaskWindow window
            CreateTaskWindow window = new CreateTaskWindow();

            // Open the CreateTaskWindow window
            window.Show();
            this.Close();
        }
        private void editTaskBttn(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "UPDATE [Task]" +
                                  "SET TaskDescription=@param1, DueDate=@param2, Difficulty=@param3, Group=@param4 " +
                                  "WHERE TaskName=@paramTaskName";            
        }

        //button that sorts by genre
        private void GenreSort(object sender, RoutedEventArgs e)
        {

        }

        private void logout_click(object sender, RoutedEventArgs e)
        {
            // Create the CreateTaskWindow window
            Login window = new Login();

            // Open the CreateTaskWindow window
            window.Show();
            this.Close();

        }

        private void TheDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
