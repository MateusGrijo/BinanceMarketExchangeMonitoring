using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader.Classes
{
    class MarketPrice
    {
        private string ApiKey { get; set; }


        //===========================================================================================================================================================================

        public MarketPrice(string _ApiKey)
        {
            this.ApiKey = _ApiKey;

        }

        //===========================================================================================================================================================================

        public async Task<double> ConvertValue(string  SourceSymbol, string ConvertSymbol, double Amount)
        { 
            string URL = "https://pro-api.coinmarketcap.com/v1/tools/price-conversion?CMC_PRO_API_KEY=" + this.ApiKey + "&symbol="+ SourceSymbol + "&convert="+ ConvertSymbol + "&amount=" + Amount.ToString();

            double Result = 0.00;

            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                await Task.Delay(1);
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36");
                 
               string MyData= await webClient.DownloadStringTaskAsync(new Uri(URL));
                MyData = MyData.Replace(ConvertSymbol, "XXX");
                try
                {
                   
                    dynamic MyUSDT = JsonConvert.DeserializeObject(MyData);
                    string str = (string)MyUSDT.data.quote.XXX.price;
                    Result = Double.Parse(str, CultureInfo.InvariantCulture);
                }
                catch {; }


            }


            return Result;
        }
        //===========================================================================================================================================================================

    }
}
