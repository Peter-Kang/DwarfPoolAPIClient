using System;
using DwarfPoolAPIClient.DataStruct;
using System.Timers;

namespace DwarfPoolAPIClient
{
    class DwarfPoolAPIClient
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Dwarfpool Client");
            //Reading in the config
            DwarfPoolWebClient test = new DwarfPoolWebClient();
            DwarfpoolReading test_item = new DwarfpoolReading(test.Test());

        }

        /// <summary>
        /// Creates a object to read in the api event at a certain interval
        /// </summary>
        public DwarfPoolAPIClient()
        {
            this._CurrentTimer = new Timer();
            this._WebClient = new DwarfPoolWebClient();


        }
        private DwarfPoolWebClient _WebClient;
        private Timer _CurrentTimer;
    }
}