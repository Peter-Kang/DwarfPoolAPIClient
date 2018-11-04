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
    /// A Html Client to send and parse Html objects sent between the two objects
    /// </summary>
    class DwarfPoolHtmlClient
    {
        //The singleton class to interface with dwarfpool
        static HttpClient connection_client = new HttpClient();



    }
}
