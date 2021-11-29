using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public DataRowView row;
        public EditWindow(DataRowView newRow)
        {
            row = newRow;
            InitializeComponent();
            editGenre.Text = row.Row.ItemArray[6].ToString();
            editTaskName.Text = row.Row.ItemArray[2].ToString();
            editDate.SelectedDate = DateTime.Parse(row.Row.ItemArray[4].ToString());
            DifficultySlider.Value = (double)row.Row.ItemArray[5];
            editDesc.Text = row.Row.ItemArray[3].ToString();
        }

        private void Difficulty_Slider(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void btnNewEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCloseWin(object sender, RoutedEventArgs e)
        {
            // Create the Task window
            Task window = new();

            //(txtUserName.Text);   
            // Open the Task window
            window.Show();
            Close();
        }

        private void btnDeleteTask(object sender, RoutedEventArgs e)
        {
            // Create the Task window
            Task window = new();

            //(txtUserName.Text);   
            // Open the Task window
            window.Show();
            Close();
        }
    }
}
