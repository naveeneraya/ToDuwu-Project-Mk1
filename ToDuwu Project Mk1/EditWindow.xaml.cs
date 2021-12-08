using System;
using System.Collections.Generic;
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
            DifficultySlider.Value = (int)row.Row.ItemArray[5];
            editDesc.Text = row.Row.ItemArray[3].ToString();
        }

        private void Difficulty_Slider(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void btnNewEdit_Click(object sender, RoutedEventArgs e)
        {

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;" +
                      "Initial Catalog=ToDuwu Database; Integrated Security=True; ";
            using (SqlConnection con = new(connectionString))
            {
                con.Open();
                string CmdString = "UPDATE [Task] SET TaskName=@param1 , TaskDescription=@param2 , DueDate=@param3, Difficulty=@param4, [Group]=@param5 WHERE Id=@Id;";
                SqlCommand cmd = new(CmdString, con);

                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = editTaskName.Text;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = editDesc.Text;
                cmd.Parameters.Add("@param3", SqlDbType.Date).Value = editDate.SelectedDate.Value.Date.ToShortDateString();
                cmd.Parameters.Add("@param4", SqlDbType.Int).Value = (int)DifficultySlider.Value;
                cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = editGenre.Text;
                cmd.Parameters.AddWithValue("@Id", row.Row.ItemArray[0].ToString());
                cmd.ExecuteNonQuery();
            }

            // Create the Task window
            Task window = new();

            //(txtUserName.Text);   
            // Open the Task window
            window.Show();
            Close();
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
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;" +
                      "Initial Catalog=ToDuwu Database; Integrated Security=True; ";
            using (SqlConnection con = new(connectionString))
            {
                con.Open();
                string CmdString = "DELETE FROM [Task] WHERE Id=@Id;";
                SqlCommand cmd = new(CmdString, con);
                cmd.Parameters.AddWithValue("@Id", row.Row.ItemArray[0].ToString());
                cmd.ExecuteNonQuery();
            }

            // Create the Task window
            Task window = new();
            // Open the Task window
            window.Show();
            Close();
        }
    }
}
