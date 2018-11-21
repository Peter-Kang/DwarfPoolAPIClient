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
        // the string to index into the json objects
        protected static string json_total_hashrate_string = "total_hashrate";
        protected static string json_total_calculated_hashrate_string = "total_hashrate_calculated";
        protected static string json_wallet_address_string = "wallet";
        protected static string json_worker_string = "workers";
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
            _HashrateSummation = 0.0;
            _HashrateCalculatedSummation = 0.0;
            _WalletAddress = "";
            //Uses the Json parser to split into the current data members 
            // and labeled correctly
            if (RawHtmlResponse.Length != 0)
            {
                //using Newtonsoft to solve JSon problems. 
                //Could write my own but why re-invent the wheel right?
                dynamic json_input = JsonConvert.DeserializeObject(RawHtmlResponse);
                //Get each varaible out
                bool success = 
                    ( json_input[json_total_hashrate_string]            != null )   &&
                    ( json_input[json_total_calculated_hashrate_string] != null )   &&
                    ( json_input[json_wallet_address_string]            != null );
                // if they exist
                if ( success )
                {
                    string total_hashrate_from_json = json_input[json_total_hashrate_string];
                    string total_cal_hashrate_from_json = json_input[json_total_calculated_hashrate_string];

                    success &= double.TryParse(total_hashrate_from_json, out this._HashrateSummation);
                    success &=  double.TryParse(total_cal_hashrate_from_json, out this._HashrateCalculatedSummation);

                    this._WalletAddress = json_input[json_wallet_address_string];
                }
                if (success)
                {//Get readings from each of the workers / miners
                    dynamic json_worker_input = json_input[json_worker_string];
                    foreach (var item in json_worker_input)
                    {
                        WorkerReadingData data = new WorkerReadingData();
                        var json_worker = json_worker_input[item.Name];

                        data.WorkerName = (json_worker["worker"] == null ? "" : json_worker.worker);
                        data.IsAlive = (json_worker["alive"] != null && json_worker["alive"] == "true");
                        data.IsUnderThreshold = (json_worker["hashrate_below_threshold"] != null && json_worker["hashrate_below_threshold"] == "true");
                        data.HashRateCalculated = (json_worker["hashrate_calculated"] != null ? GetDoubleDefaultToZero(json_worker["hashrate_calculated"].ToString()) : 0);
                        data.HashRateCurrent = (json_worker["hashrate"] != null ? GetDoubleDefaultToZero(json_worker["hashrate"].ToString()) : 0);
                        data.LastSubmition = ( json_worker["last_submit"] != null ? GetDateTimeDefaultMinTIme(json_worker["last_submit"].ToString()) : DateTime.MinValue);
                        data.TimeSinceLastSubmit = (json_worker["second_since_submit"] != null ? GetIntegerDefaultToZero(json_worker["second_since_submit"]) : 0);
                    }
                }
            }
        }


        private double GetDoubleDefaultToZero( string value)
        {
            double result = 0;
            double.TryParse(value, out result);
            return result;
        }

        private int GetIntegerDefaultToZero( string value)
        {
            int result = 0;
            int.TryParse(value, out result);
            return result;
        }
        
        private DateTime GetDateTimeDefaultMinTIme( string value)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(value, out result);
            return result;
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
