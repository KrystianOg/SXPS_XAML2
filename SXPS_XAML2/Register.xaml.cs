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

namespace SXPS_XAML2
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private LogInWindow logInWindow;

        public Register(LogInWindow logInWindow)
        {
            this.logInWindow = logInWindow;
            InitializeComponent();
        }

        public void btnExit_Click(object sender,RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void btnRegister_Click(object sender,RoutedEventArgs e)
        {
            Console.WriteLine("Register.");

        }

        public void btnLogin_Click(object sender,RoutedEventArgs e)
        {
            logInWindow.Show();
            Hide();
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

        private void HandleManageButton(object sender,RoutedEventArgs e)
        {

        }
    }
}
