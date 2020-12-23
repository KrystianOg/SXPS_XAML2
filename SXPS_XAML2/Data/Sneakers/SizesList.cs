using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SXPS_XAML.Enums;
namespace SXPS_XAML.Data.Sneakers
{
    class SizesList
    {
        private readonly List<Size> sizes;
        private IDictionary<string, Size> sToSize;
        private NikeSneaker sneaker;

        public SizesList(NikeSneaker sneaker)
        {
            this.sneaker = sneaker;
        }

    }

    class Size
    {
        private readonly List<Sell> lastSoldItems;
        private readonly string size;
        private double probableProfit = 0;
        private readonly NikeSneaker sneaker;
        private readonly Currency currency;

        private bool profitable = false;
        //private TrendLine trendLine;

        public Size(Sell item,NikeSneaker sneaker)
        {
            this.size = item.shoeSize;
            this.currency = item.localCurrency;
            this.lastSoldItems.Add(item);
            this.sneaker = sneaker;
        }

        public void calculateRegression()
        {

        }

        public void addItem(Sell item)
        {
            this.lastSoldItems.Add(item);
        }

        void CalculateProfit()
        {
            double np;
            if (sneaker.currentPrice - Math.Floor(sneaker.currentPrice) == 0.99)
            {
                np = sneaker.currentPrice * 0.75;
            } else
            {
                np = sneaker.currentPrice;
            }

        }


    }

    class Sell
    {
        public Currency localCurrency
        {
            get;
            private set;
        }
        private double localAmount;
        private string skuUuid;
        public string shoeSize
        {
            get;
            private set;
        }
        private DateTime createdAt;

        public Sell(string JSONchain)
        {
            List<string> type = new List<string>(JSONchain.Split('\"'));

            type.RemoveAll(item =>item.Equals(","));

            for (int i=1;i<type.Count;i++)
            {
                string s = type.ElementAt(i);
                if (s.Contains("createdAt"));
                else if (s.Contains("shoeSize"));
                else if (s.Contains("skuUuid"));
                else if (s.Contains("localAmount"));
                else if (s.Contains("localCurrency"));



            }
           
        }

        public Sell(string date,string size,double amount,Currency currency,string sxSKU)
        {
            //this.createdAt = DecodeDate();
            this.shoeSize = size;
            this.localAmount = amount;
            this.localCurrency = currency;
            this.skuUuid = sxSKU;

        }

        private void DecodeDate()
        {

        }

        public string Save()
        {
            StringBuilder sb = new StringBuilder();
            /*
            sb.Append(Write.SaveKeyValue("created_at", createdAt.ToString()));
            sb.Append(Write.SaveKeyValue("shoe_size", shoeSize));
            sb.Append(Write.SaveKeyValue("amount", localAmount.ToString()));
            sb.Append(Write.SaveKeyValue("currency", localCurrency.ToString()));
            */

            sb.Append("Created_at: ").Append(createdAt.ToString()).Append(',');
            sb.Append("Shoe_size: ").Append(shoeSize).Append(',');
            sb.Append("Amount: ").Append(localAmount).Append(',');
            sb.Append("Currency: ").Append(localCurrency.ToString()).Append(Environment.NewLine);
            return sb.ToString();
        }

        public bool isBefore()
        {
            return false;
        }

       
    }
}
