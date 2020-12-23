using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using SXPS_XAML.Data.Sneakers;

namespace SXPS_XAML.Data
{
    enum File
    {
        EXCHANGE,
        NIKE,
        SKUs,
        EMAIL_TO_ID,

    }

    enum Folder
    {
        ACCOUNTS,
        SKUs,
        SX_LISTS,
        SX_DATA,
        SNEAKERS_TABLES,
        USERS,
        USERS_SETTINGS,
        EMAIL_ATTACHMENTS
    }

    static class FileExtension
    {
        private static IDictionary<File, string[]> FileToPath = new Dictionary<File, string[]>()
        {


            { File.EXCHANGE, new string[]{ "exchange","exchange.txt"} },
            { File.SKUs, new string[]{"skus","skus","skus.txt" } },
            { File.EMAIL_TO_ID, new string[]{"users","eMailToIdMap.txt" } },
            { File.NIKE,new string[]{"nike","nike.txt" } }
        };

        private static IDictionary<Folder, string[]> FolderToPath = new Dictionary<Folder, string[]>()
        {
            { Folder.ACCOUNTS, new string[]{"nike","accounts" } },
            { Folder.SKUs, new string[]{"skus","skus" } },
            { Folder.SX_LISTS, new string[]{"stockx","lists" } },
            { Folder.SX_DATA,new string[]{"stockx","data" } },
            { Folder.SNEAKERS_TABLES, new string[]{"sneakers" } },
            { Folder.USERS, new string[]{"users" } },
            { Folder.USERS_SETTINGS, new string[]{"users","settings" } },
            { Folder.EMAIL_ATTACHMENTS,new string[]{"attachments" } }

        };

        public static string[] Path(this File file)
        {
            return FileToPath[file];
        }

        public static string[] Path(this Folder folder)
        {
            return FolderToPath[folder];
        }
    }


    public static class Read{
        
        public static void readSmth()
        {


        }

    }

    public static class Write
    {
        
        public static void writeSmth()
        {

        }

        
        public static void SaveNikeSneaker(NikeSneaker sneaker)
        {
            string path = Path.Combine(Pathing.MainFolder, sneaker.sku);

            System.IO.File.WriteAllText(path, sneaker.ToString());
        }

        public static void SomeText()
        {
            var path = CreateFilePath(File.NIKE.Path(),false);

            System.IO.File.WriteAllText(path, "Aaaaa\n\naaaaaaa\naaaaa\naaaa");


        }

        public static string CreateFilePath(string []path,bool directory)
        {
            var partPath = Pathing.MainFolder;

            if (!System.IO.File.Exists(partPath))
                Directory.CreateDirectory(partPath);

            for(int i = 0; i < path.Length; i++)
            {
                partPath = Path.Combine(partPath, path[i]);
                if (!System.IO.File.Exists(partPath)&&(path.Length-1!=i))
                    Directory.CreateDirectory(partPath);
            }

            if (directory)
                Directory.CreateDirectory(partPath);
            else
            {
                System.IO.File.Create(partPath).Close();
            }
            

            return partPath;
        }

        public static string SaveKeyValue(string key, string value)
        {
            StringBuilder sb = new StringBuilder();
            return sb.Append(key).Append("='").Append(value).Append('\'').Append(Environment.NewLine).ToString();
        }
    }

    public static class Pathing
    {
        public static readonly string MainFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StockXProfitSearcher");

    }

}
