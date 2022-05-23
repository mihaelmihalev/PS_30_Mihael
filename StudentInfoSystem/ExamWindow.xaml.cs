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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for ExamWindow.xaml
    /// </summary>
    public partial class ExamWindow : Window
    {
        public ExamWindow()
        {
            InitializeComponent();
        }
        private void Program_Click1(object sender, RoutedEventArgs e)
        {
            ExamFKST window = new ExamFKST();
            window.Show();
            this.Hide();
        }

        private void Program_Click2(object sender, RoutedEventArgs e)
        {
            ExamFMI window = new ExamFMI();
            window.Show();
            this.Hide();
        }

        private void Program_Click3(object sender, RoutedEventArgs e)
        {
            ExamFTK window = new ExamFTK();
            window.Show();
            this.Hide();
        }
    }
}
