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
    /// Interaction logic for Task.xaml
    /// </summary>
    public partial class Task : Window
    {
        public Task()
        {
            InitializeComponent();
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

        //button that sorts by genre
        private void GenreSort(object sender, RoutedEventArgs e)
        {

        }
    }
}
