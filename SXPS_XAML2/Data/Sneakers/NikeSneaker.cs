using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SXPS_XAML.Enums;

namespace SXPS_XAML.Data.Sneakers
{
    public class NikeSneaker
    {
        private string link;
        public string sku
        {
            get;
            private set;
        }
        public string sxSKU
        {
            get;
            private set;
        }
        private string ID;
        public double currentPrice
        {
            get;
            private set;
        }
        private bool favourite = false;
        //private double MaxProfit = 0;

        private Currency currency;
        private LinkedList<NikeSize> NikeSizes;
        //private SizesList sizesList;

        public NikeSneaker(string link,string ID,string currentPrice,LinkedList<NikeSize> nikeSizes)
        {
            this.link = link;
            this.ID = ID;
            this.currentPrice = priceToDouble(currentPrice);
            this.NikeSizes = nikeSizes;
              
        }

        private double priceToDouble(string price)
        {
            string returnString = "";

            returnString=price.Substring(0,price.LastIndexOf(' '));

            returnString=returnString.Replace(',', '.');

            return double.Parse(returnString);
        }

        private string getSKU(string link)
        {
            return link.Substring(link.LastIndexOf('/')+1);

        }

        public string Save()
        {
            StringBuilder s = new StringBuilder();

            s.Append(Write.SaveKeyValue("link", link));
            s.Append(Write.SaveKeyValue("id",ID));
            s.Append(Write.SaveKeyValue("price",currentPrice.ToString()));
            s.Append(Write.SaveKeyValue("favourite", favourite.ToString()));
            s.Append(Write.SaveKeyValue("link",link));
            
            s.Append("sizes=");
            foreach(NikeSize n in NikeSizes)
            {
                s.Append(n.size.Replace(' ', '_')).Append("+").Append(n.isActive).Append(',');
            }

            return s.ToString();
        }

    }

    public class NikeSize
    {
        public string size
        {
            get;
            private set;
        }
        public bool isActive
        {
            get;
            private set;
        }

        public NikeSize(string size,bool isActive)
        {
            this.size = size;
            this.isActive = isActive;
        }
    }
}
