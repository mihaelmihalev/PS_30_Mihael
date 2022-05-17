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
using UserLogin;
using System.Web;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        
        public User user = new User();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void loginLogWin_Click(object sender, RoutedEventArgs e)
        {
            string username = this.usernameLogWIn.Text.Trim();
            string password = this.passwordLogWin.Text.Trim();

            List<User> users = UserData.TestUsers;
     
            user = (from u in users where u.Username == username && u.Password == password select u).FirstOrDefault();

            if (user == null)
            {
                MessageBox.Show("Wrong creditentials!");
            }
            else
            {
                MessageBox.Show("Logged!");
                MainWindow win = new MainWindow();
                win.Show();
                this.Close();
            }
          //  if (lblCaptcha.Content != txtCaptcha.Text)
            //{
               // MessageBox.Show("Wrong Captcha");
               
            //}
        }
     //   private void LoginWindow_Load(object sender, EventArgs e)
       // {
         //   Random rand = new Random();
          //  int num = rand.Next(6, 8);
           // string captcha = "";
           // int tot1 = 0;
           // do
           // {
             //   int chr = rand.Next(48, 123);
             //   if((chr>48 && chr<=57) || (chr>=65 && chr <=90) || (chr>=97 && chr<=122))
             //   {
               //     captcha = captcha + (char)chr;
              //      tot1++;
               //     if (tot1 == num)
               //     {
               //         break;
               //     }
               // }
         //   }
         //   while (true);
         //   lblCaptcha.Content = captcha;
                        //  }
       

    }
}
    

