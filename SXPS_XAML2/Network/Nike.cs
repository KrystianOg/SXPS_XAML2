using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;

using SXPS_XAML.Enums;
using SXPS_XAML.Data.Sneakers;
using SXPS_XAML.ClassResources;
using SXPS_XAML.Data;
using OpenQA.Selenium.Interactions;

namespace SXPS_XAML.Network
{
    public static class Nike
    {
        private static int itemsAmount = 0;
        private static bool reloading;

        private static bool useMens = false;
        private static bool useWmns = false;
        private static bool useKids = true;

        private static readonly string edgePath = @"C:\Users\tailo\Source\Repos\SXPS_XAML\SXPS_XAML\Network\Drivers";

        private static IWebDriver Driver;
        
        
        public static void UseTables(bool mens,bool wmns,bool kids)
        {
            useMens = mens;
            useWmns = wmns;
            useKids = kids;
        }

        public static void getData()
        {
            if (!reloading)
                reloading = true;
            else return;


            if (!useMens && !useWmns && !useKids)
            {
                Console.WriteLine("No tables has been choosen.");
                return;
            }

            DateTime before = DateTime.Now;

            var path = Path.GetFullPath("Network");

            Console.WriteLine(path);

            Driver = new EdgeDriver(edgePath);

            //maximizing window
            Driver.Manage().Window.Maximize();

            List<string> mensLinks = new List<string>();
            List<string> wmnsLinks = new List<string>();
            List<string> kidsLinks = new List<string>();

            if (useMens)
                mensLinks.AddRange(GetLinks(Table.MENS));
            if (useWmns)
                mensLinks.AddRange(GetLinks(Table.WMNS));
            if (useKids)
                kidsLinks.AddRange(GetLinks(Table.KIDS));

            if (useMens)
            {
                List<NikeSneaker> mens = GetAll(mensLinks);
                //Write.
            }
            if (useWmns)
            {
                List<NikeSneaker> wmns = GetAll(wmnsLinks);
                //Write.
            }
            if(useKids)
            {
                List<NikeSneaker> kids = GetAll(kidsLinks);
                //Write.
            }

            var after = DateTime.Now;

            TimeSpan t = before - after;

            Console.WriteLine("Hours: " + t.TotalHours + "\tMinutes: " + t.TotalMinutes + "\tSeconds: " + t.TotalSeconds);
            Console.WriteLine("Items amount: " + itemsAmount);
            Driver.Close();
            reloading = false;
        }
        
        private static List<NikeSneaker> GetAll(List<string> links)
        {
            List<NikeSneaker> info = new List<NikeSneaker>();

            foreach (string l in links)
                info.AddRange(GetSneakerTypes(l));
            return info;
        }

        private static LinkedList<string> GetLinks(Table t)
        {
            Driver.Url = t.GetLink();
            int size = 0;
            int lastSize;
            LinkedList<string> links = new LinkedList<string>();
            LinkedList<string> linkscpy = new LinkedList<string>();

            bool first = true;

            while (true)
            {
                var elements = Driver.FindElements(By.ClassName("product-card__link-overlay"));
                Actions actions = new Actions(Driver);
                actions.MoveToElement(elements.Last());
                actions.Perform();

                lastSize = size;
                size = elements.Count;

                Console.WriteLine("Last:" + lastSize + "\t\tnow:" + size);

                if (size == lastSize && first)
                {
                    first = false;
                }
                else if (size == lastSize && !first)
                {
                    foreach (var w in elements)
                        links.AddLast(w.GetAttribute("href"));

                    foreach(string link in links)
                    {
                        linkscpy.AddLast(String.Copy(link));
                    }

                    foreach(string s in links)
                    {
                        if (s.Contains("by-you")||s.Contains("custom")||s.Contains("u/custom"))
                            linkscpy.Remove(s);
                    }

                    foreach (string s in links)
                        Console.WriteLine(s);

                    Console.WriteLine(t.ToString() + " links: " + links.Count);
                    break;
                }

                Thread.Sleep(5000);

            }
            return linkscpy;
        }

        private static LinkedList<NikeSneaker> GetSneakerTypes(string link)
        {
            LinkedList<NikeSneaker> sd = new LinkedList<NikeSneaker>();

            Driver.Url = link;

            Thread.Sleep(Settings.DELAY);

            var els = Driver.FindElements(By.ClassName("colorway-anchor"));
            LinkedList<string> links = new LinkedList<string>();
            itemsAmount += els.Count;
            if (els.Count == 0)
            {
                sd.AddLast(GetNikeSneaker(link, false));
                return sd;
            }

            foreach (var w in els)
                links.AddLast(w.GetAttribute("href"));

            foreach(string l in links){
                if (l.Equals(link))
                    sd.AddLast(GetNikeSneaker(link, false));
                else
                    sd.AddLast(GetNikeSneaker(l, true));
            }
            return sd;
        }

        private static NikeSneaker GetNikeSneaker(string link,bool navigate)
        {
            if (navigate)
            {
                Driver.Url = link;
                Thread.Sleep(Settings.DELAY);
            }

            string name = GetName();
            string price = GetPrice();
            LinkedList<NikeSize> ns = GetSizes();

            return new NikeSneaker(link, name, price, ns);

        }

        private static string GetName()
        {
            var e = Driver.FindElements(By.Id("pdp_product_title"));
            StringBuilder sb = new StringBuilder();
            foreach (var w in e)
                sb.Append(w.Text);
            if (!sb.ToString().Equals(""))
                return sb.ToString();

            var s = Driver.FindElements(By.Id("headline-1"));
            sb = new StringBuilder();
            foreach (var w in s)
                sb.Append(w.Text);

            if (!sb.ToString().Equals(""))
                return sb.ToString();

            return "null";
        }

        private static string GetPrice()
        {
            var e = Driver.FindElements(By.ClassName("product-price"));
            StringBuilder sb = new StringBuilder();
            foreach (var w in e)
                sb.Append(w.Text);
            if (!sb.ToString().Equals(""))
                return sb.ToString();

            var s = Driver.FindElements(By.ClassName("fs14-sm"));
            sb = new StringBuilder();
            foreach (var w in s)
                sb.Append(w.Text);
            if (!sb.ToString().Equals(""))
                return sb.ToString();

            return "0.0";
        }

        private static LinkedList<NikeSize> GetSizes()
        {
            LinkedList<NikeSize> ns = new LinkedList<NikeSize>();

            var sizesb = Driver.FindElements(By.ClassName("visually-hidden"));
            var sizes = Driver.FindElements(By.ClassName("css-xf3ahq"));

            if (sizesb.Count == sizes.Count)
                for (int i = 0; i < sizesb.Count; i++)
                    ns.AddLast(new NikeSize(sizes.ElementAt(i).Text, sizesb.ElementAt(i).Enabled));
            return ns;
        }
        public static void CloseDriver()
        {
            if(Driver!=null)
                Driver.Close();
        }
    }
}
