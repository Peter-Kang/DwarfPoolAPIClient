using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfPoolAPIClient.DataStruct
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
        private double _HashRate;
        // The calculated HashRate of the miner
        private double _HashrateCalculated;
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
            ref double argsHashRate, ref double argsCalculatedHashRate,
            ref bool argsIsUnderThreshold, ref DateTime argsLastSubmition,
            ref int argsTimeSInceLastSubmition)
        {
            this._WorkerName = argsWorkersName;
            this._IsAlive = argsIsAlive;
            this._HashRate = argsHashRate;
            this._HashrateCalculated = argsCalculatedHashRate;
            this._IsUnderThreshold = argsIsUnderThreshold;
            this._LastSubmition = argsLastSubmition;
            this._TimeSinceLastSubmit = argsTimeSInceLastSubmition;
        }

        /// <summary>
        ///  The copy constructor for the WorkerReadingData class
        /// </summary>
        /// <param name="other"> the other worker reading data to copy </param>
        public WorkerReadingData(ref WorkerReadingData other)
        {
            this._WorkerName = other._WorkerName;
            this._IsAlive = other._IsAlive;
            this._HashRate = other._HashRate;
            this._HashrateCalculated = other._HashrateCalculated;
            this._IsUnderThreshold = other._IsUnderThreshold;
            this._LastSubmition = other._LastSubmition;
            this._TimeSinceLastSubmit = other._TimeSinceLastSubmit;
        }

        //============================================================================
        //Getters and Setters                                                         |          
        //============================================================================

        /// <summary>
        ///  Modifiers for the worker name
        /// </summary>
        public string WorkerName
        {
            get { return _WorkerName; }
            set { _WorkerName = value; }
        }
        /// <summary>
        /// Modifiers for the flag to determine if the worker is still live or not
        /// </summary>
        public bool IsAlive
        {
            get { return _IsAlive; }
            set { _IsAlive = value; }
        }
        /// <summary>
        /// Modifers for the hashrate
        /// </summary>
        public double HashRateCurrent
        {
            get { return _HashRate; }
            set { _HashRate = value; }
        }
        /// <summary>
        /// Modifers for for the calculated hashrate
        /// </summary>
        public double HashRateCalculated
        {
            get { return _HashrateCalculated; }
            set { _HashrateCalculated = value; }
        }
        /// <summary>
        /// Modifers for if the reading is under the 60% threshold
        /// </summary>
        public bool IsUnderThreshold
        {
            get { return _IsUnderThreshold; }
            set { _IsUnderThreshold = value; }
        }
        /// <summary>
        /// Modifers for the last time it was submitted
        /// </summary>
        public DateTime LastSubmition
        {
            get { return _LastSubmition; }
            set { _LastSubmition = value; }
        }
        /// <summary>
        /// Modifers for the time in seconds since the last reading
        /// </summary>
        public int TimeSinceLastSubmit
        {
            get { return _TimeSinceLastSubmit; }
            set { _TimeSinceLastSubmit = value; }
        }

    };


}
