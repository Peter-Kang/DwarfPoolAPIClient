using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using DwarfPoolAPIClient.DataStruct;



//The Client to send and receieve data
namespace DwarfPoolAPIClient
{
    /// <summary>
    /// A Web Client wrapper for the dwarfpool site
    /// </summary>
    class DwarfPoolWebClient
    {
        // the url to use
        private String _Url;
        // the web client to use
        private WebClient _WebClient;

        /// <summary>
        ///  the constructor 
        /// </summary>
        /// <param name="url"> deafults to empty string, the full url of the dwarfpool link</param>
        public DwarfPoolWebClient(string url = "")
        {
            this._Url = url;
            this._WebClient = new WebClient();
        }

        /// <summary>
        ///  copy constructor
        /// </summary>
        /// <param name="other"> the other class to copy</param>
        public DwarfPoolWebClient(ref DwarfPoolWebClient other)
        {
            this._Url = other._Url;
            this._WebClient = new WebClient();
        }

        /// <summary>
        ///  Gets a reading from dwarfpool
        /// </summary>
        /// <returns> a null or a dwarfpool reading from the dwarfpool api</returns>
        public DwarfpoolReading GetReading()
        {
            DwarfpoolReading result = null;
            if ( this._Url.Count() != 0 )
            {
                String response = "";
                response = this._WebClient.DownloadString(this._Url);
                if (response.Count() != 0 )
                {
                    result = new DwarfpoolReading(response);
                }
            }
            return result;
        }
    }
}
