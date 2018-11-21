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
    class DwarfPoolWebClient
    {
        public DwarfPoolWebClient() { }

        public DwarfPoolWebClient(ref DwarfPoolWebClient other) { }

        public String Test()
        {
            WebClient connection_client = new WebClient();
            String url = "http://dwarfpool.com/eth/api?wallet=de3aFa2eD6C8e1Fe32C94151B07ecb676F9C3f15&email=mail@example.com";
            String value = "";
            value = connection_client.DownloadString(url);
            DwarfpoolReading temp = new DwarfpoolReading(value);
            return value;
        }

    }
}
