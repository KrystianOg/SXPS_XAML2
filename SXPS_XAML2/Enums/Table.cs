using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPS_XAML.Enums
{
    

    public enum Table
    {
        MENS,
        WMNS,
        KIDS
    }

    public static class TableExtensions
    {
        private static IDictionary<Table, string> tableString = new Dictionary<Table, string>() {
            {Table.MENS,"mens" },
            {Table.WMNS, "wmns"},
            {Table.KIDS, "kids" }
        };

        private static IDictionary<string,Table> stringTable = new Dictionary<string,Table>() {
            { "mens", Table.MENS},
            { "wmns", Table.WMNS},
            { "kids", Table.KIDS}
        };

        private static IDictionary<Table, string> tableLink = new Dictionary<Table, string>()
        {
            {Table.MENS, "https://www.nike.com/pl/w/mezczyzni-buty-nik1zy7ok"},
            {Table.WMNS, "https://www.nike.com/pl/w/kobiety-buty-5e1x6zy7ok"},
            {Table.KIDS, "https://www.nike.com/pl/w/kids-buty-v4dhzy7ok"}
        };

        public static string toString(this Table t)
        {
            return tableString[t];
        }

        public static Table toTable(string table)
        {
            return stringTable[table];
        }

        public static string GetLink(this Table t)
        {
            
            return tableLink[t];
        }

       
    }
}
