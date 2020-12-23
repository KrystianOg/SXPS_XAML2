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

namespace SXPS_XAML2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        private Register register = null;

        public LogInWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            } 
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid operation");
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnRegister_Click(object sender,RoutedEventArgs e)
        {
            
            if(register==null)
                register = new Register(this);
            register.Show();
            Hide();
        }
    }
}
