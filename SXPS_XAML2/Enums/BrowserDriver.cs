using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SXPS_but_in_C.Enums
{
    public class BrowserDriver
    {
        private NAME bDriver;

        public enum NAME {
            EDGE,
            CHROME,
            FIREFOX
        }

        public BrowserDriver(NAME driver)
        {
            bDriver = driver;
        }

        private static IDictionary<NAME, string> id = new Dictionary<NAME, string>();
        private static IDictionary<NAME, string> name = new Dictionary<NAME, string>();
        private static IDictionary<string, NAME> driver = new Dictionary<string,NAME>();

        public static void Init()
        {
            name[NAME.EDGE] = "edge";
            name[NAME.CHROME] = "chrome";
            name[NAME.FIREFOX] = "firefox";
        }
    }
}
