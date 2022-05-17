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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);
            ListBoxItem david = new ListBoxItem();
            james.Content = "David";
            peopleListBox.Items.Add(david);
            peopleListBox.SelectedItem = james;


            Closing += new System.ComponentModel.CancelEventHandler(MainWindowClosing_Message);
        }
      private void MainWindowClosing_Message(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this window?", "CLOSING", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            

            foreach (var item in MainGrid.Children)
            {
                
                if (item is TextBox)
                    {              
                    s = s + ((TextBox)item).Text;
                    s = s + '\n';
                }
                

            }


            
            MessageBox.Show("Здрасти " + s  + "!!!" + "\nТова е вашата първа програма на Visual Studio 2022!");
            

            //   if (this.txtName.Text.Length > 2)
            // {
            //   MessageBox.Show("Здрасти " + this.txtName.Text + "!!!" + "\nТова е твоята първа програма на Visual Studio 2022!");

            //  }
            // else
            //  { 
            //        MessageBox.Show("Името трябва да съдържа повече от 2 символа!!! ");              
            //  }
        }

        private void btnSumN_Click(object sender, RoutedEventArgs e)
        {
            {
                int i, fact = 1, number;            
                number = int.Parse(this.txtN.Text);
                for (i = 1; i <= number; i++)
                {
                    fact = fact * i;
                }
                MessageBox.Show("Factorial of " + number + " is: " + fact);
            }
        }
        private void btnSumNNN_Click(object sender, RoutedEventArgs e)
        {          
           double result = Math.Pow(Double.Parse(this.txtN.Text), Double.Parse(this.txtY.Text));
            MessageBox.Show(this.txtN.Text + "^" + this.txtY.Text + " = " + result);
        }

        private void peopleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void greetingBtn_Click(object sender, RoutedEventArgs e)
        {
            string greetingMsg;
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
        }
    }
}

