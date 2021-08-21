using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader.Classes
{
    class MarketVolume
    {
        private string ApiKey { get; set; }
      

        //===========================================================================================================================================================================

        public MarketVolume(string _ApiKey )
        {
            this.ApiKey = _ApiKey;
            
        }

        //===========================================================================================================================================================================
         
        public async Task<string> GetRequest(string TokenSymbol, string FiatSymbol, string Platform)
        {
            string URL = "data/pricemultifull?fsyms=" + TokenSymbol + "&tsyms=" + FiatSymbol + "&e=" + Platform + "&api_key=" + this.ApiKey;

            string Result = "";

            using (var client = new HttpClient())
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                client.BaseAddress = new Uri("https://min-api.cryptocompare.com/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36");

                HttpResponseMessage response = new HttpResponseMessage();
    
                response = await client.GetAsync(URL).ConfigureAwait(false);

                // Verification  
                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.  
                    Result = response.Content.ReadAsStringAsync().Result;
                    
                }
            }
             

            return Result;
        }
        //===========================================================================================================================================================================

    }


}
