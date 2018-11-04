using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


// Dwarf pool documentation: https://dwarfpool.com/api/
namespace DwarfPoolAPIClient.DataStruct
{
    /// <summary>
    /// The data structure to hold the data coming from dwarfpool
    /// </summary>
    public class DwarfpoolReading
    {
        //============================================================================
        //Data Members                                                                |          
        //============================================================================
        // The raw data in html from dwardpool
        private string _RawReponse;
        // The total hashrate of all the workers
        private double _HashrateSummation;
        // The calculated total hashrate
        private double _HashrateCalculatedSummation;
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
        public DwarfpoolReading(string RawHtmlResponse = "") => this.ParseRawHtml(RawHtmlResponse);

        /// <summary>
        /// Copy constructor for the Dwarfpool readings object
        /// </summary>
        /// <param name="other">the other reading object you will be copying </param>
        public DwarfpoolReading(ref DwarfpoolReading other)
        {
            this._RawReponse = other._RawReponse;
            this._HashrateSummation = other._HashrateSummation;
            this._HashrateCalculatedSummation = other._HashrateCalculatedSummation;
            this._WalletAddress = other._WalletAddress;
            this._WorkerReadingData = new List<WorkerReadingData>(_WorkerReadingData);
        }

        //============================================================================
        //Initalization                                                               |          
        //============================================================================
        /// <summary>
        /// Parses the Raw Html into the current data members
        /// </summary>
        /// <param name="RawHtmlResponse"> The raw Html from dwarfpool  </param>
        private void ParseRawHtml(string RawHtmlResponse)
        {
            _WorkerReadingData = new List<WorkerReadingData>();
            _RawReponse = RawHtmlResponse;
            //Uses the Json parser to split into the current data members 
            // and labeled correctly
            if (RawHtmlResponse.Length != 0)
            {
                //using Newtonsoft to solve JSon problems. 
                //Could write my own but why re-invent the wheel right?
                dynamic json_input = JsonConvert.DeserializeObject(RawHtmlResponse);
                //Translate the Json names to the names in the data structure

            }
        }

        //============================================================================
        //Getters and Setters                                                         |          
        //============================================================================

        /// <summary> 
        /// Modifers for the Raw Html Reponse from dwarfpool; Kept to observe and log reponse data.
        /// </summary>
        public string RawReponse
        {
            get { return _RawReponse; }
        }
        /// <summary>
        /// Modifiers for the summation of the current hashrate
        /// </summary>
        public double HashrateSummation
        {
            get { return _HashrateSummation; }
            set { _HashrateSummation = value; }
        }
        /// <summary>
        ///  Modifiers for the summation of the calculated summation
        /// </summary>
        public double HashrateCalculatedSummation
        {
            get { return _HashrateCalculatedSummation; }
            set { _HashrateCalculatedSummation = value;}
        }
        /// <summary>
        ///  Modifiers for the wallet address
        /// </summary>
        public string WalletAddress
        {
            get { return _WalletAddress;  }
            set { _WalletAddress = value; }
        }
        /// <summary>
        ///  Modifiers for all worker reading data
        /// </summary>
        public List<WorkerReadingData> AllWorkerReadingData
        {
            get { return _WorkerReadingData;  }
            set { _WorkerReadingData = value; }
        }

    }
}
