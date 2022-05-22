using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Windows;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GradesWindow : Window
    {
        public List<string> StudInfo { get; set; } = new List<string>();
        public User user = new User();

        StudentInfoDatabaseEntities dataEntities = new StudentInfoDatabaseEntities();

        public GradesWindow()

        {

            InitializeComponent();

            FillDataGrid();

        }

        private void FillDataGrid()

        {

            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))

            {

                CmdString = "SELECT SubjectID,SubjectName,Grade,LastChanged FROM StudGrades";

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("StudGrades");

                sda.Fill(dt);

                gradeData.ItemsSource = dt.DefaultView;

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow main = new MainWindow();
            main.Show();
        }

    }
}