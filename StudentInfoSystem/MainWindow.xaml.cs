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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserLogin;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public StudentInfoContext context;

        private Student student;
        public List<string> StudStatusChoices { get; set; } = new List<string>();
        private Student Student
        {
            get
            {
                student = new Student();
                student.year = Int32.Parse(this.txtCurse.Text);
                student.facultyNumber = this.txtFacNum.Text;
                student.faculty = this.txtFac.Text;
                student.flow = Int32.Parse(this.txtPotok.Text);
                student.name = this.txtName.Text;
                student.group = Int32.Parse(this.txtGroup.Text);
                student.last_name = this.txtFamily.Text;
                student.surname = this.txtSurName.Text;
                student.major = this.txtSpec.Text;
                //student.status = this.txtSts.Text;
                student.degree = this.txtOKS.Text;                             
                return student;
            }
            set
            {

            }
        }
       // public MainWindow(object data)
     // : this()
       // {
            // Bind to expense report data.
          //  this.DataContext = data;

       // }
        
        
        public MainWindow()

        {
            InitializeComponent();
            //hideAllFields();
            FillStudStatusChoices();
            this.DataContext = DataContext;
            this.statusListBox.ItemsSource = StudStatusChoices;
            if (TestStudentsIfEmpty())
                CopyTestStudents();

        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr
                FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)

                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clearAllFields();
        }

       


        private void enableBtn_Click(object sender, RoutedEventArgs e)
        {
            enableFields();
        }

        private void disableBtn_Click(object sender, RoutedEventArgs e)
        {
            disableFields();
        }

        private void hideAllFields()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.Visibility = Visibility.Hidden;
                }

                if (item is Label)
                {
                    Label label = (Label)item;
                    label.Visibility = Visibility.Hidden;
                }

                if (item is Button)
                {
                    Button button = (Button)item;

                    if (button.Name != "showBtn")
                    {
                        button.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        private void fillFieldsWithStudentInfo()
        {
            Student student = StudentData.TestStudents[0];

            this.txtCurse.Text = student.year.ToString();
            this.txtFacNum.Text = student.facultyNumber;
            this.txtFac.Text = student.faculty;
            this.txtPotok.Text = student.flow.ToString();
            this.txtName.Text = student.name;
            this.txtGroup.Text = student.group.ToString();
            this.txtFamily.Text = student.last_name;
            this.txtOKS.Text = student.degree;
            this.txtSurName.Text = student.surname;
            this.txtSpec.Text = student.major;
            this.statusListBox.ItemsSource = student.status;

        }

        private void clearAllFields()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.Clear();
                }
            }
        }

        private void disableFields()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.IsEnabled = false;
                }
            }
        }

        private void enableFields()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.IsEnabled = true;
                }
            }

        }

        private void showMoreBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;

                    if (textBox.Name == "txtName")
                    {
                        continue;
                    }

                    if (textBox.Name == "txtSurName")
                    {
                        continue;
                    }

                    if (textBox.Name == "txtFamily")
                    {
                        continue;
                    }

                    textBox.Visibility = Visibility.Visible;
                }

                if (item is Label)
                {
                    Label label = (Label)item;

                    if (label.Name == "lblName")
                    {
                        continue;
                    }

                    if (label.Name == "lblSurName")
                    {
                        continue;
                    }

                    if (label.Name == "lblFamily")
                    {
                        continue;
                    }

                    label.Visibility = Visibility.Visible;
                }

                if (item is Button)
                {
                    Button button = (Button)item;

                    if (button.Name == "showBtn")
                    {
                        continue;
                    }

                    button.Visibility = Visibility.Visible;
                }
            }
        }

        private void showBtn_Click(object sender, RoutedEventArgs e)
        {
            fillFieldsWithStudentInfo();

            this.lblName.Visibility = Visibility.Visible;
            this.lblSurName.Visibility = Visibility.Visible;
            this.lblFamily.Visibility = Visibility.Visible;
            this.txtName.Visibility = Visibility.Visible;
            this.txtSurName.Visibility = Visibility.Visible;
            this.txtFamily.Visibility = Visibility.Visible;
            /*this.showBtn.Visibility = Visibility.Hidden;
            this.showMoreBtn.Visibility = Visibility.Visible;*/

        }
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.ShowDialog();

            User user = window.user;
            if (user != null)
            {
                Student student = (from s in StudentData.TestStudents where s.name == user.Username select s).FirstOrDefault();
                Student = student;
            }


        }
        private bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;

            int countStudents = queryStudents.Count();

            return countStudents == 0;
        }
        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            

            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
            }

            context.SaveChanges();
        }

        private void get_GradesTable(object sender, RoutedEventArgs e)
        {
            GradesWindow gradesWindow = new GradesWindow();
            gradesWindow.Show();
            this.Close();
        }

        private void fillBtn_Click(object sender, RoutedEventArgs e)
        {
            fillFieldsWithStudentInfo();
        }
    }
}
        
    
