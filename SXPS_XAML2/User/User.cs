using SXPS_but_in_C.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SXPS_XAML.Enums;
using System.Security.Cryptography;
using SXPS_XAML.Data;
namespace SXPS_but_in_C
{
    public class User
    {
        private string name;
        private string lastName;
        private int age;
        private PhoneNumber phoneNumber;

        private HashSet<string> favouriteSKUs = new HashSet<string>();
        private EMail eMail;
        private Password password;
        private UserSettings userSettings;
        private string id;
    }

    class PhoneNumber
    {
        private long phoneNumber;

        private string defPrefix = "48";

        public PhoneNumber(string phoneNumber) 
        {
            phoneNumber = phoneNumber.Substring(phoneNumber.IndexOf('+') + 1);

            if (phoneNumber.Length < 9)
                throw new InvalidPhoneNumberException();
            else if (phoneNumber.Length > 11)
                throw new InvalidPhoneNumberException();
            else if (phoneNumber.Length == 9)
                phoneNumber = defPrefix + phoneNumber;
            this.phoneNumber = long.Parse(phoneNumber);
        }

        public string getString()
        {
            return phoneNumber.ToString();
        }
    }

    

    class EMail
    {
        private string eMail;

        public EMail(string eMail) 
        {
            if (eMail.Contains("@"))
                this.eMail = eMail;
            else 
                throw new InvalidEMailException();
        }
    }

    class Password
    {
        //some encription
        private byte[] HashedPass;
        private string Salt;
        
        //new password
        public Password(string pass)
        {
            Salt = GenerateSalt();
            HashedPass = GetHash(pass, Salt);
            
        }

        public Password()
        {
            byte[] a;

            

        }

        static string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        static byte[] GetHash(string password,string salt)
        {
            byte[] unhashedBytes = Encoding.Unicode.GetBytes(String.Concat(salt, password));

            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(unhashedBytes);

            return hashedBytes;
        }

        static bool CompareHash(string attempt, byte[] hash, string salt)
        {
            string base64Hash = Convert.ToBase64String(hash);
            string base64AttemptedHash = Convert.ToBase64String(GetHash(attempt, salt));

            return base64Hash.Equals(base64AttemptedHash);
        }

        public string Save()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Write.SaveKeyValue("password", Encoding.ASCII.GetString(this.HashedPass)));
            sb.Append(Write.SaveKeyValue("salt",Salt));
            return sb.ToString();
        }
        
    }

    class UserSettings
    {
        private bool sendEMails;
        private bool sendSMSs;

        private int averageOf;
        private int minProfit;
        private int searchDelay;

        //private string driverPath;
        private BrowserDriver driver;
        private Currency used;

        bool searchMens;
        bool searchWmns;
        bool searchKids;

        public UserSettings(bool sendEmails,bool sendSMSs,int averageOf, int minProfit,int searchDelay,string driverPath,BrowserDriver driver,Currency used,bool searchMens,bool searchWmns,bool searchKids)
        {
            this.sendEMails = sendEmails;
            this.sendSMSs = sendSMSs;
            this.averageOf = averageOf;
            this.minProfit = minProfit;
            this.searchDelay = searchDelay;
            this.driver = driver;
            this.used = used;
            this.searchMens = searchMens;
            this.searchWmns = searchWmns;
            this.searchKids = searchKids;
        }

        public void setDefault()
        {
            sendEMails = true;
            sendSMSs = false;

            averageOf = 5;
            minProfit = 20;
            searchDelay = 300;

            driver = new BrowserDriver(BrowserDriver.NAME.EDGE);
            used = Currency.GBP;
            searchMens = true;
            searchWmns = true;
            searchKids = true;
        }
    }

    public class InvalidPhoneNumberException : Exception
    {
        public InvalidPhoneNumberException() : base("Given phone number is invalid")
        {

        }
    }

    
    class InvalidEMailException : Exception
    {
        public InvalidEMailException() : base("Given e-mail is invalid")
        {

        }
    }
}
