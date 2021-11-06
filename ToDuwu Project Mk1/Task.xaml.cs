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

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
        //launches into the create Task Window
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create the CreateTaskWindow window
            CreateTaskWindow window = new CreateTaskWindow();

            // Open the CreateTaskWindow window
            window.Show();

            this.Close();
        }
        //sorting function for due date
        private void DueDateSort(object sender, RoutedEventArgs e)
        {
            var sql = "SELECT* FROM dboTask ORDER BY DueDate";
        }

        //sorting function for diffuclty
        private void DifficultySort(object sender, RoutedEventArgs e)
        {
            var sql = "SELECT* FROM dboTask ORDER BY Difficulty desc";
            

        }
    }
}
