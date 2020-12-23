using System;
using System.Collections.Generic;
using System.Linq;

using ActiveUp.Net.Mail;

using SXPS_XAML.Data;
using SXPS_XAML.Devices;
using System.Threading;

namespace SXPS_XAML.Network
{
    public class EMail
    {

        private static bool IsInUse = false;

        public static readonly string EMAIL = "remotetailowskisprinter@gmail.com";
        public static readonly string PASSWORD = "ETDkrsaPYM39UBy5";

        private Imap4Client client;

        public EMail(string mailServer,int port,bool ssl,string login,string password)
        {
            if (ssl)
                Client.ConnectSsl(mailServer, port);
            else
                Client.Connect(mailServer, port);
            Client.Login(login, password);
        }

        public IEnumerable<Message> GetAllMails(string mailBox)
        {
            return GetMails(mailBox, "ALL").Cast<Message>();
        }

        public IEnumerable<Message> GetUnreadMails(string mailBox)
        {
            return GetMails(mailBox, "UNSEEN").Cast<Message>();
        }

        protected Imap4Client Client
        {
            get
            {
                return client ?? (client = new Imap4Client());
            }
        }

        private MessageCollection GetMails(string mailBox,string searchPhrase)
        {
            Mailbox mails = Client.SelectMailbox(mailBox);
            MessageCollection messages = mails.SearchParse(searchPhrase);
            return messages;
        }

        public static void ReadAndPrint()
        {
            if (IsInUse)
                return;
            else IsInUse = true;

            var mailRepository = new EMail(
                                    "imap.gmail.com",
                                    993,
                                    true,
                                    EMail.EMAIL,
                                    EMail.PASSWORD
                                );

            var emailList = mailRepository.GetUnreadMails("inbox");

            foreach (Message email in emailList)
            {
                
                Console.WriteLine("Count: " + email.Attachments.Count);
                foreach (MimePart n in email.Attachments)
                {

                    string path = Write.CreateFilePath(Folder.EMAIL_ATTACHMENTS.Path(), true);
                    string fileName = Generate.RandomString(10)+"_"+n.Filename;
                    n.StoreToFile(System.IO.Path.Combine(path,fileName));

                    string fullPath = System.IO.Path.Combine(path, fileName);
                    Console.WriteLine(fullPath);
                    Printer.AddPath(fullPath);
                } 


            }

            Printer.Print();

            Console.WriteLine("Read and printed if not null");
            
            IsInUse = false;
        }

    }

}
