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

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            String connectionString = (@"Data Source=(localdb)\MSSQLLocalDB;" +
                "Initial Catalog=ToDuwu DB; Integrated Security=True; ");
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();

                String sqlQuery = @"INSERT INTO Task (UserId, TaskName, TaskDescription)
                                    VALUES (@Id, @Name, @Description)";
                SqlCommand com = new SqlCommand(sqlQuery, con);
                com.Parameters.AddWithValue("@Name", TaskName.Text);
                com.Parameters.AddWithValue("@Description", TaskDescription.Text);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
