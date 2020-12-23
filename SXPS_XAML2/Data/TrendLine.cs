using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SXPS_but_in_C.Data
{
    public class TrendLine
    {
        private double A;
        private double Aerr;
        private double B;
        private double Berr;

        public TrendLine(LinkedList<Point> points)
        {


        }


        public class Point
        {
            public double x
            {
                get;
                private set;
            }
            public double y
            {
                get;
                private set;
            }

            public Point(double x,double y)
            {
                this.x = x;
                this.y = y;
            }

        }

    }

    
}
