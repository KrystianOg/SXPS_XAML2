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
    /// Interaction logic for Menu.xaml
    /// </summary>
    /// 
    public enum Panel
    {
        ACCOUNT,
        SEARCH,
        NIKE,
        SNEAKER,
        FAVOURITE,
        CURRENCIES,
        SETTINGS
    }

    public static class PanelExtension
    {
        private static IDictionary<Panel, string> message = new Dictionary<Panel, string>()
        {
            {Panel.ACCOUNT,"ACCOUNT"},
            {Panel.SEARCH,"SEARCH" },
            {Panel.NIKE,"NIKE" },
            {Panel.SNEAKER,"SNEAKER" },
            {Panel.FAVOURITE,"FAVOURITE" },
            {Panel.CURRENCIES,"CURRENCIES" },
            {Panel.SETTINGS,"SETTINGS" }
        };

        public static string ToString(this Panel p)
        {
            return message[p];
        }
    }

    public partial class Menu : Window
    {

        private IDictionary<Button, UserControl> ButtonUCMap = new Dictionary<Button, UserControl>();
        private IDictionary<Button, Panel> ButtonPanelMap = new Dictionary<Button, Panel>();

        public Menu()
        {
            InitializeComponent();

            ButtonUCMap[Search] = SearchPanel;
            ButtonUCMap[Account] = AccountPanel;
            ButtonUCMap[Nike] = NikePanel;
            ButtonUCMap[Sneaker] = SneakerPanel;
            ButtonUCMap[Favourite] = FavouritePanel;
            ButtonUCMap[Currencies] = CurrenciesPanel;
            ButtonUCMap[Settings] = SettingsPanel;

            ButtonPanelMap[Search] = Panel.SEARCH;
            ButtonPanelMap[Account] = Panel.ACCOUNT;
            ButtonPanelMap[Nike] = Panel.NIKE;
            ButtonPanelMap[Sneaker] = Panel.SNEAKER;
            ButtonPanelMap[Favourite] = Panel.FAVOURITE;
            ButtonPanelMap[Currencies] = Panel.CURRENCIES;
            ButtonPanelMap[Settings] = Panel.SETTINGS;
        }

        private void MouseDrag(object sender, MouseButtonEventArgs e)
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

        private void HandleButtons(object sender,RoutedEventArgs e)
        {
            var b = (Button)sender;

            TabLabel.Content = ButtonPanelMap[b].ToString();

            AccountPanel.Visibility = Visibility.Hidden;
            SearchPanel.Visibility = Visibility.Hidden;
            NikePanel.Visibility = Visibility.Hidden;
            SneakerPanel.Visibility = Visibility.Hidden;
            FavouritePanel.Visibility = Visibility.Hidden;
            CurrenciesPanel.Visibility = Visibility.Hidden;
            SettingsPanel.Visibility = Visibility.Hidden;

            ButtonUCMap[b].Visibility = Visibility.Visible;

            NikePanel.AddSneaker();
        }
    }
}