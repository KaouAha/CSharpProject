using ConsoleApplication1.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace ConsoleApplication1
{
    class Prgram
    {
        const double interval10Seconds = 10 * 1000; // milliseconds to 10 seconds
        static SyncDBServiceClient Services = new SyncDBServiceClient();
        static string clientConnectionString = @"Data Source=(localdb)\v11.0;Initial Catalog = VideothequeDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static void Main(string[] args)
        {
            syncData();
        }

        public static void syncData()
        {
            try
            {
                Timer checkForTime = new Timer(interval10Seconds);
                checkForTime.Elapsed += new ElapsedEventHandler(checkForTime_Elapsed);
                checkForTime.Enabled = true;

                Console.WriteLine("Synchronization process started !!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public static void checkForTime_Elapsed(object sender, ElapsedEventArgs e)
        {

            var status = Services.Sync(@"Data Source=(localdb)\v11.0;Initial Catalog=VideothequeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            if (status)
            {
                Console.WriteLine("Databases are Synced successfully.");
            }
            else
            {
                Console.WriteLine("Error in Synchronization process.");
                Environment.Exit(0);
            }
        }
    }
}
