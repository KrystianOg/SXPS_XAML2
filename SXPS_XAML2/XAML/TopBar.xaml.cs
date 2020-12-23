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

namespace SXPS_XAML2.XAML
{
    /// <summary>
    /// Interaction logic for TopBar.xaml
    /// </summary>
    public partial class TopBar : UserControl
    {
        
        public TopBar()
        {
            InitializeComponent();
            
        }

        private void exit_Click(object sender,RoutedEventArgs e)
        {
            //zapis 


            Application.Current.Shutdown();
        }

        private void maximize_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (window.WindowState.Equals(WindowState.Maximized))
            {
                Maximize.Kind = MaterialDesignThemes.Wpf.PackIconKind.Fullscreen;
                window.WindowState = WindowState.Normal;
            }
            else
            {
                Maximize.Kind = MaterialDesignThemes.Wpf.PackIconKind.FullscreenExit;
                window.WindowState = WindowState.Maximized;
            }
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.WindowState = WindowState.Minimized;
        }
    }

}
