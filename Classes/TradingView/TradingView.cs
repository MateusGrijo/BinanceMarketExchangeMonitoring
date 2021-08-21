using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader.Classes
{
    class TradingView
    {

//================================================================================================================================================================================================================
        public string ViewChart(string TokenSymbol, int Interval, int Width, int Height)
        {  
            return " <html> <body> <div class='tradingview-widget-container'> <div id='tradingview_9eef1'></div> " +
                   " <script type = 'text/javascript' src = 'https://s3.tradingview.com/tv.js' ></script> " +
                   " <script type = 'text/javascript'>  new TradingView.widget({'width': " + Width.ToString() + ", 'height': " + Height.ToString() + ", 'symbol': 'BINANCE:" + TokenSymbol + "', " +
                   " 'interval': '" + Interval.ToString() + "', 'timezone': 'Asia/Hong_Kong', 'theme': 'light', 'style': '1', " +
                   " 'locale': 'en', 'toolbar_bg': '#f1f3f6', 'enable_publishing': false, 'hide_top_toolbar': true, 'hide_legend': true, 'studies': ['BB@tv-basicstudies', 'StochasticRSI@tv-basicstudies'], " +
                   " 'save_image': false, 'container_id': 'tradingview_9eef1' });  </script> </div ></body> </html>";
        }

  
   //================================================================================================================================================================================================================

        public string ViewSignal(string TokenSymbol, int Interval)
        {
            return " <html><body> <div class=\"tradingview-widget-container\">  <div class=\"tradingview-widget-container__widget\"></div> " +
                   " <script type = \"text/javascript\" src=\"https://s3.tradingview.com/external-embedding/embed-widget-technical-analysis.js\" async> " +
                   " { \"interval\": \""+ Interval.ToString() + "m\", \"width\": \"100%\", \"isTransparent\": false, " +
                   "\"height\": \"100%\", \"symbol\": \"BINANCE:"+ TokenSymbol + "\", \"showIntervalTabs\": false, \"locale\": \"en\", \"colorTheme\": \"light\" } " +
                   "</script> </div> </body> </html>";
        }

 //================================================================================================================================================================================================================




    }
}
