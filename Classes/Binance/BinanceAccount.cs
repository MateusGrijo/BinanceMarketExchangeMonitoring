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
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTrader.Classes
{
 
    
//===========================================================================================================================================================================
    class BinanceAccount
    {
        private string ApiKey { get; set; }
        private string SecretKey { get; set; }

 //===========================================================================================================================================================================

        public BinanceAccount(string _ApiKey, string _SecretKey)
        {
            this.ApiKey = _ApiKey;
            this.SecretKey = _SecretKey;
        }

//===========================================================================================================================================================================
 
        public async Task<dynamic> GetInformation()
        {   
           
            var Binance = new BinanceClient(new ClientConfiguration()
            {
                ApiKey = this.ApiKey,
                SecretKey = this.SecretKey,
    
                
            });


    
            var MyAccountInformation = await Binance.GetAccountInformation(60000);
            
            return MyAccountInformation;
        }

//===========================================================================================================================================================================

        public async Task<dynamic> GetOpenOrder(string Symbol)
        {  
            var Binance = new BinanceClient(new ClientConfiguration()
            {
                ApiKey = this.ApiKey,
                SecretKey = this.SecretKey
            });

            CurrentOpenOrdersRequest MyRequest = new CurrentOpenOrdersRequest();

            MyRequest.Symbol = Symbol;
            var MyOrders = await Binance.GetCurrentOpenOrders(MyRequest, -1);
            return MyOrders;
        }
//===========================================================================================================================================================================

    }
}
