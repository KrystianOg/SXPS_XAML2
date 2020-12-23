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

using System.Threading;

namespace SXPS_XAML2.XAML.Panels
{
    /// <summary>
    /// Interaction logic for NikePanel.xaml
    /// </summary>
    public partial class NikePanel : UserControl
    {
        public NikePanel()
        {
            InitializeComponent();
            Title.Children.Add(new SneakerContainer());
        }

        public void AddSneaker()
        {
            //Thread t;

            //margin

            Viewer.Children.Add(new SneakerContainer("Aaaaaaa","Aaaaa","AAAAA",500,300,100));
        }
    }
}
