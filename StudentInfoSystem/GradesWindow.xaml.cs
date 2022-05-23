using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Windows;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using UserLogin;
using System.Data.OleDb;

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


            //string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data  Source=C:\Database1.accdb";
            //OleDbConnection connect = new OleDbConnection(connection);

            //string sql = "SELECT * FROM StudGrades";
            //connect.Open();
            //OleDbCommand command = new OleDbCommand(sql, connect);
            //DataSet data = new DataSet();
            //OleDbDataAdapter adapter = new OleDbDataAdapter(command);


            //for (int i = 0; i < data.Tables["Grades"].Rows.Count; i++)
            //{
            //    var gpa = data.Tables["Grades"].AsEnumerable()
            //    .Average(row => row.Field<double>("Grade"));
            //}

            //connect.Close();
        

        //this.Close();
        //MainWindow main = new MainWindow();
        //main.Show();
    }

    }
}