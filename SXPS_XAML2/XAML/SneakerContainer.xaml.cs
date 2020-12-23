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
    /// Interaction logic for SneakerContainer.xaml
    /// </summary>
    public partial class SneakerContainer : UserControl
    {
        private string NikeLink;

        public SneakerContainer()
        {
            InitializeComponent();
            ID.Text = "Sneaker ID";
            SKU.Text = "SKU";
            Price.Text = "Price";
            SellPrice.Text = "Sell";
            Profit.Text = "Profit";

            IsOnNike.IsChecked = false;

            fire.Width = 24;
            fire.Height = 24;

            SneakerButton.IsEnabled = false;
        }

        public SneakerContainer(string NikeLink,string id,string sku,double price,double sellprice,double profit)
        {
            InitializeComponent();

            this.NikeLink = NikeLink;

            ID.Text = id;
            SKU.Text = sku;
            Price.Text = price.ToString();
            SellPrice.Text = sellprice.ToString();
            Profit.Text = profit.ToString();

            IsOnNike.IsChecked = true;

            fire.Width = 24;
            fire.Height = 24;
        }

        public SneakerContainer(string NikeLink, string id, string sku, string price,string sellPrice,string profit)
        {
            InitializeComponent();

            this.NikeLink = NikeLink;

            ID.Text = id;
            SKU.Text = sku;
            Price.Text = price;
            SellPrice.Text = sellPrice;
            Profit.Text = profit;

            IsOnNike.IsChecked = true;

            fire.Width = 24;
            fire.Height = 24;
        }

        private void OpenLinksInBrowser(object sender,RoutedEventArgs e)
        {
            Console.WriteLine("Open adfadf");
        }
    }
}
