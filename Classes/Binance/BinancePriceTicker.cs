using BinanceExchange.API;
using BinanceExchange.API.Client;
using BinanceExchange.API.Client.Interfaces;
using BinanceExchange.API.Enums;
using BinanceExchange.API.Models.Request;
using BinanceExchange.API.Models.Response;
using BinanceExchange.API.Models.Response.Error;
using BinanceExchange.API.Models.WebSocket;
using BinanceExchange.API.Utility;
using BinanceExchange.API.Websockets;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTrader.Classes
{
    class BinancePriceTicker
    {
        private string ApiKey { get; set; }
        private string SecretKey { get; set; }

        //===========================================================================================================================================================================

        public BinancePriceTicker(string _ApiKey, string _SecretKey)
        {
            this.ApiKey = _ApiKey;
            this.SecretKey = _SecretKey;
        }

        //===========================================================================================================================================================================
      
        public async Task<dynamic> GetCurrentPrice(string Symbol)
        { //  await Binance.TestConnectivity();
            var Binance = new BinanceClient(new ClientConfiguration()
            {
                ApiKey = this.ApiKey,
                SecretKey = this.SecretKey
            });

            var MyDailyTicker = await Binance.GetDailyTicker(Symbol);

            return MyDailyTicker;
        }

        //===========================================================================================================================================================================
       public async Task<double> Convert_to_USDT(string Symbol)
        { //  await Binance.TestConnectivity();
            var Binance = new BinanceClient(new ClientConfiguration()
            {
                ApiKey = this.ApiKey,
                SecretKey = this.SecretKey
            });

            var MyDailyTicker = await Binance.GetPrice(Symbol + "USDT");
   
            return Convert.ToDouble(MyDailyTicker.Price.ToString());

        }


        //===========================================================================================================================================================================



    }
}
