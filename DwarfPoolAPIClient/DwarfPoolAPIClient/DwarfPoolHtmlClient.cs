using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

// Dwarf pool documentation: https://dwarfpool.com/api/

namespace DwarfPoolAPIClient
{
    /// <summary>
    /// The hashrate of one of the workers coming from dwarfpool
    /// </summary>
    public class WorkerReadingData
    {
        //============================================================================
        //Data Members                                                                |          
        //============================================================================
        // The Worker's name
        private string _WorkerName;
        // Dead or Alive status, True if the worker is still on, False if the worker 
        // is off
        private bool _IsAlive;
        // Current hashrate of the worker 
        private string _HashRate;
        // The calculated HashRate of the miner
        private string _HashrateCalculated;
        // Signals if the current hash rate is below the 
        // threshold(60% of what is expected)
        private bool _IsUnderThreshold;
        // Last time that the miner submitted a reponse
        private DateTime _LastSubmition;
        // Time in seconds since the last submition
        private int _TimeSinceLastSubmit;

        //============================================================================
        //Constructors                                                                |          
        //============================================================================

        /// <summary>
        ///  Empty Constructor
        /// </summary>
        public WorkerReadingData() { }

        /// <summary>
        ///  Constructor containing each of the data memeber as parameters
        /// </summary>
        /// <param name="argsWorkersName"> The Worker's name to set </param>
        /// <param name="argsIsAlive"> Dead or Alive status, True if the worker is 
        ///                            still on, False if the worker is off  </param>
        /// <param name="argsHashRate">Current hashrate of the worker  </param>
        /// <param name="argsCalculatedHashRate">The calculated HashRate of the miner
        /// </param>
        /// <param name="argsIsUnderThreshold">Signals if the current hash rate is 
        ///     below the threshold(60% of what is expected) </param>
        /// <param name="argsLastSubmition">Last time that the miner 
        ///  submitted a reponse</param>
        /// <param name="argsTimeSInceLastSubmition">Time in seconds since the 
        /// last submition</param>
        public WorkerReadingData(ref string argsWorkersName, ref bool argsIsAlive,
            ref string argsHashRate, ref string argsCalculatedHashRate,
            ref bool argsIsUnderThreshold, ref DateTime argsLastSubmition,
            ref int argsTimeSInceLastSubmition)
        {
            this._WorkerName            = argsWorkersName;
            this._IsAlive               = argsIsAlive;
            this._HashRate              = argsHashRate;
            this._HashrateCalculated    = argsCalculatedHashRate;
            this._IsUnderThreshold      = argsIsUnderThreshold;
            this._LastSubmition         = argsLastSubmition;
            this._TimeSinceLastSubmit   = argsTimeSInceLastSubmition;
        }

        /// <summary>
        ///  The copy constructor for the WorkerReadingData class
        /// </summary>
        /// <param name="other"></param>
        public WorkerReadingData(ref WorkerReadingData other)
        {
            this._WorkerName            = other._WorkerName;
            this._IsAlive               = other._IsAlive;
            this._HashRate              = other._HashRate;
            this._HashrateCalculated    = other._HashrateCalculated;
            this._IsUnderThreshold      = other._IsUnderThreshold;
            this._LastSubmition         = other._LastSubmition;
            this._TimeSinceLastSubmit   = other._TimeSinceLastSubmit;
        }

        //============================================================================
        //Getters and Setters                                                         |          
        //============================================================================



    };

    /// <summary>
    /// The data structure to hold the data coming from dwarfpool
    /// </summary>
    public class ReadingData
    {
        //============================================================================
        //Data Members                                                                |          
        //============================================================================
        // The raw data in html from dwardpool
        private string _RawReponse;
        // The total hashrate of all the workers
        private string _HashrateSummation;
        // The calculated total hashrate
        private string _HashrateCalculatedSummation;
        // The current wallet address that the ethereum is registered under in dwarfpool
        private string _WalletAddress;
        // The list of reading data from each of the workers
        private List<WorkerReadingData> _WorkerReadingData;

        //============================================================================
        //Constructors                                                                |          
        //============================================================================

        /// <summary>
        /// Empty constructor and string constructor
        /// </summary>
        /// <param name="RawHtmlResponse"> The raw Html from dwarfpool </param>
        public ReadingData(string RawHtmlResponse = "") => this.ParseRawHtml(RawHtmlResponse);

        //============================================================================
        //Initalization                                                               |          
        //============================================================================
        /// <summary>
        /// Parses the Raw Html into the current data members
        /// </summary>
        /// <param name="RawHtmlResponse"> The raw Html from dwarfpool  </param>
        private void ParseRawHtml(string RawHtmlResponse)
        {
            _RawReponse = RawHtmlResponse;
            //Uses the Json parser to split into the current data members and labeled correctly
            if ( RawHtmlResponse.Length != 0 )
            {
                dynamic json_input = JsonConvert.DeserializeObject(RawHtmlResponse);

            }
        }

        //============================================================================
        //Getters and Setters                                                         |          
        //============================================================================

        /// <summary> The Raw Html Reponse from dwarfpool; Kept to observe and log reponse data.</summary>
        /// <value> The Raw Response property get/sets the value of the string field _RawReponse </value>
        public string RawReponse
        {
            get
            {
                return _RawReponse;
            }
        }

    }



    /// <summary>
    /// A Html Client to send and parse Html objects sent between the two objects
    /// </summary>
    class DwarfPoolHtmlClient
    {

    }
}
