using System;
using DwarfPoolAPIClient.DataStruct;
using System.Timers;

namespace DwarfPoolAPIClient
{
    class DwarfPoolAPIClient
    {
        //the web client to get the data from
        private DwarfPoolWebClient _WebClient;
        //Then timer to keep track of when to poll the device
        private Timer _CurrentTimer;

        /// <summary>
        ///  Test the current functionality 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Dwarfpool Client");
            //Reading in the config
            DwarfPoolWebClient test = new DwarfPoolWebClient("http://dwarfpool.com/eth/api?wallet=de3aFa2eD6C8e1Fe32C94151B07ecb676F9C3f15&email=mail@example.com");
            DwarfpoolReading resting = test.GetReading();

        }

        /// <summary>
        /// Creates a object to read in the api event at a certain interval
        /// </summary>
        public DwarfPoolAPIClient()
        {
            this._CurrentTimer = new Timer();
            this._WebClient = new DwarfPoolWebClient("");
        }

    }
}