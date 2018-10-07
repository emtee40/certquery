using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CertWiper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter search term: ");
            string searchTerm = Console.ReadLine();
            Console.WriteLine("### QUERYING USER CERTIFICATES ###");
            for(int i = 1; i<=8; i++)
            {
                X509Store store = new X509Store((StoreName)i, (StoreLocation)1);
                store.Open(OpenFlags.ReadOnly);

                foreach (X509Certificate2 cert in store.Certificates)
                {
                    if (cert.Subject.ToLower().Contains(searchTerm.ToLower()))
                    {
                        Console.WriteLine("---------- " + store.Location + " --- " + store.Name + " ----------");
                        Console.WriteLine(cert.Subject);
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine("### QUERYING MACHINE CERTIFICATES ###");
            for (int i = 1; i <= 8; i++)
            {
                X509Store store = new X509Store((StoreName)i, (StoreLocation)2);
                store.Open(OpenFlags.ReadOnly);

                foreach (X509Certificate2 cert in store.Certificates)
                {
                    if (cert.Subject.ToLower().Contains(searchTerm.ToLower()))
                    {
                        Console.WriteLine("---------- " + store.Location + " --- " + store.Name + " ----------");
                        Console.WriteLine(cert.Subject);
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine("DONE!");
            Console.ReadKey();
        }
    }
}
