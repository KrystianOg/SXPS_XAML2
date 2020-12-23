using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;
using System.Threading;

namespace SXPS_XAML.Network
{
    public class Webscraper
    {
        //Adidas
        //Adrenaline                            ✓
        //Asos - nadaje swój kod produktu       ✘
        //Ataf                                  ✓
        //Chmielna20                            ✓
        //Footlocker - może ale coś ciężko      ✘           
        //ForPro                                ✓
        //JejSklep                              ✓
        //Nike                                  ✓
        //PerfektSport - 'kłopoty techniczne'   ✘               
        //Size? - nadaje swój kod produktu      ✘
        //Sizeer                                ✓
        //SklepBiegacza                         ✓
        //SklepKoszykarza                       ✓
        //SneakerShop                           ✓
        //Zalando - nadaje swój kod produktu    ✘ może?



        public Webscraper()
        {

        }

        public void Scrape(string sku)
        {
            Console.WriteLine(GetAdrenalinePrice("DA4086-100"));        //239.99
            Console.WriteLine(GetAtafPrice("AQ7475-105"));              //359
            Console.WriteLine(GetChmielnaPrice("CJ1631-100"));          //549.99
            Console.WriteLine(GetFootlockerPrice("315122-111"));        //0
            Console.WriteLine(GetForproPrice("DC4118-001"));            //455
            Console.WriteLine(GetJejsklepPrice("AH6789-001"));          //
            Console.WriteLine(GetSizeerPrice("bq6806-102"));            //399.99
            Console.WriteLine(GetSklepBiegaczaPrice("CQ7935-300"));     //439.99
            Console.WriteLine(GetSklepKoszykarzaPrice("CT6047-100"));   //739.99
            Console.WriteLine(GetSneakerShopPrice("DA4651-100"));       //739.99
            Console.WriteLine(GetZalandoPrice("CZ1055-100"));           //419.00
        }

        private void GetAdidasPrice()
        {


        }

        private double GetAdrenalinePrice(string skuSearch)
        {
            string link = @"https://adrenaline.pl/search.php?text=" + skuSearch;

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(link);

            foreach (var node in htmlDoc.DocumentNode.SelectNodes("//span[@class='price']"))
            {
                return PriceToDouble(node.InnerText);
            }

            return 0.0;
        }

        private void GetAsosPrice(string skuSearch)
        {
            string link = @"https://www.asos.com/pl/search/?q=" + skuSearch;
        }

        private double GetAtafPrice(string skuSearch)
        {
            string link = @"https://www.ataf.pl/pl/szukaj?s=" + skuSearch;

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(link);

            Thread.Sleep(200);

            try
            {
                foreach (var node in htmlDoc.DocumentNode.SelectNodes("//p[@class='slider-price']"))
                {
                    return PriceToDouble(node.InnerText);
                }
            } catch (NullReferenceException)
            {
                Console.WriteLine("Ataf ??");
            }

            return 0.0;

        }

        private double GetChmielnaPrice(string skuSearch)
        {
            string link = @"https://chmielna20.pl/products/" + skuSearch + "/keyword," + skuSearch;

            HtmlWeb web = new HtmlWeb();
            web.PreRequest = OnPreRequest;
            var htmlDoc = web.Load(link);

            foreach (var node in htmlDoc.DocumentNode.SelectNodes("//span[@class='product__price_shop']"))
            {
                return PriceToDouble(node.InnerText);
            }

            return 0.0;
        }

        private double GetFootlockerPrice(string skuSearch)
        {
            string link = @"https://www.footlocker.pl/en/search?query=" + skuSearch;


            return 0.0;
        }

        private double GetForproPrice(string skuSearch)
        {
            string link = @"https://www.forpro.pl/?q=" + skuSearch;

            HtmlWeb web = new HtmlWeb();
            web.PreRequest = OnPreRequest;
            var htmlDoc = web.Load(link);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='product-item']/div/a");

            string att = node.Attributes["href"].Value;

            htmlDoc = web.Load("https://www.forpro.pl/" + att);

            node = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='col-sm-12']/div/div");

            //if equals sku
            if (!htmlDoc.DocumentNode.SelectSingleNode("//div[@class='col-sm-12']/div/div").InnerText.Equals(skuSearch))
                return 0.0;

            foreach (var n in htmlDoc.DocumentNode.SelectNodes("//span[@class='price-current']"))
            {
                return Double.Parse(n.InnerText.Substring(0, n.InnerText.IndexOf('z')));
            }

            return 0.0;
        }

        private double GetJejsklepPrice(string skuSearch)
        {
            string link = "https://jejsklep.pl/pl/search.html?text=" + skuSearch;

            HtmlWeb web = new HtmlWeb();
            web.PreRequest = OnPreRequest;
            var htmlDoc = web.Load(link);

            foreach (var node in htmlDoc.DocumentNode.SelectNodes("//span[@class='price']"))
            {
                return PriceToDouble(node.InnerText);
            }

            return 0.0;
        }

        private double GetSizeerPrice(string skuSearch)
        {
            string link = "https://sklep.sizeer.com/search?query%5Bquerystring%5D=" + skuSearch;

            HtmlWeb web = new HtmlWeb();
            web.PreRequest = OnPreRequest;
            var htmlDoc = web.Load(link);

            foreach (var node in htmlDoc.DocumentNode.SelectNodes("//p[@class='b-itemList_price']"))
            {
                return PriceToDouble(node.InnerText);
            }
            return 0.0;
        }

        private double GetSklepBiegaczaPrice(string skuSearch)
        {
            string link = "https://sklepbiegacza.pl/products/" + skuSearch + "/keyword," + skuSearch + "?keyword=" + skuSearch;

            HtmlWeb web = new HtmlWeb();
            web.PreRequest = OnPreRequest;
            var htmlDoc = web.Load(link);

            foreach (var node in htmlDoc.DocumentNode.SelectNodes("//div[@class='product__price']/div[@class='price']/span"))
            {
                return Double.Parse(node.InnerText.Substring(0, node.InnerText.IndexOf(' ')));
            }
            return 0.0;

        }

        private double GetSklepKoszykarzaPrice(string skuSearch)
        {
            string link = "https://sklepkoszykarza.pl/products/" + skuSearch + "/keyword," + skuSearch + "?keyword=" + skuSearch;

            HtmlWeb web = new HtmlWeb();
            web.PreRequest = OnPreRequest;
            var htmlDoc = web.Load(link);

            foreach (var node in htmlDoc.DocumentNode.SelectNodes("//li[@class='p1']/p"))
            {
                return Double.Parse(node.InnerText.Substring(0, node.InnerText.IndexOf(' ')));
            }
            return 0.0;

        }

        private double GetSneakerShopPrice(string skuSearch)
        {
            string link = "https://sneakershop.pl/pl/search.html?text=" + skuSearch;

            HtmlWeb web = new HtmlWeb();
            web.PreRequest = OnPreRequest;
            var htmlDoc = web.Load(link);

            foreach (var node in htmlDoc.DocumentNode.SelectNodes("//div[@class='product_prices']/span[@class='price']"))
            {
                return PriceToDouble(node.InnerText);
            }
            return 0.0;

        }

        private double GetZalandoPrice(string skuSearch)
        {
            //CZ1055-100
            //https://www.google.pl/search?q=CZ1055-100&sxsrf=ALeKk02qaXxy5OEhV06g3wZIec2kHKZMbQ:1608365964752&source=lnms&tbm=shop&sa=X&ved=2ahUKEwjpsv2PztntAhXnmIsKHccxAE8Q_AUoBHoECA8QBg&biw=1146&bih=929
            //CZ1055-111
            //https://www.google.pl/search?q=CZ1055-111&sxsrf=ALeKk0059lqhDWLicFw99tLFhM382fEfOw:1608366079007&source=lnms&tbm=shop&sa=X&ved=2ahUKEwjB-rrGztntAhWvlYsKHS2GCyYQ_AUoBHoECA8QBg&biw=1146&bih=929

            //&source=lnms&tbm=shop&sa=X&biw=1146&bih=929

            string link = "https://www.google.pl/search?q=" + skuSearch+ "&source=lnms&tbm=shop&sa=X&biw=1146&bih=929";

            HtmlWeb web = new HtmlWeb();
            web.PreRequest = OnPreRequest;
            var htmlDoc = web.Load(link);

            foreach (var node in htmlDoc.DocumentNode.SelectNodes("//div[@class='product_prices']/span[@class='price']"))
            {
                return PriceToDouble(node.InnerText);
            }
            return 0.0;
        }

        private  double PriceToDouble(string price)
        {
            if (price.Length < 0)
                return 0.0;

            if (price.Contains(' '))
                price = price.Substring(0, price.IndexOf(' '));
            if(price.Contains('P'))
                price = price.Substring(0, price.IndexOf('P'));


            price=price.Replace(',', '.');
            return Double.Parse(price);
        }

        private static bool OnPreRequest(HttpWebRequest request)
        {
            request.AllowAutoRedirect = true;
            return true;
        }
    }

    class CanNotFindPriceException : Exception
    {
        public CanNotFindPriceException(string shop) :base("Can not find price in "+shop)
        {
        }
    }
}
