using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CryptoTrader.Classes;
using Newtonsoft.Json;
using System.Drawing;
using AppSecurity.Models;
using CefSharp;
using CefSharp.WinForms;
using System.Globalization;

namespace CryptoTrader
{

    public partial class FrmMain : Form
    {
        BinanceAccount MyBinanceAccount;
        BinancePriceTicker MyBinancePriceTicker;
        MarketVolume MyMarketVolume;
        MarketPrice MyMarketPrice;
        TradingView MyTradingView;
        SQLite_Whitelist MySQLite_Whitelist = new SQLite_Whitelist();
        SQLite_ApiKey MySQLite_ApiKey = new SQLite_ApiKey();


        public static string UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36";
        public static string AcceptLanguage = "en-US,en;q=0.9";
        ChromiumWebBrowser MyBrowser;

        string TokenSymbol = "";
        string MyToken = "";
        string MyFiat = "";
        string MyIndicatorSymbol = "";
        string MyIndicatorInterval = "";

        string MyChartInterval = "0";

        string MyIndicatorAPI = "";

        double BRL_Value = 1;



        string AroonTrend = "   ---";
        string BBTrend = "   ---";
        string TechnicalAnalysis = "NEUTRAL";

        dynamic MyWhiteList;

        DataGridLoader MyDataGridLoader = new DataGridLoader();

        public FrmMain()
        {
            InitializeComponent();
            this.TabMain.SelectedIndexChanged += TabMain_SelectedIndexChanged;
            this.WhiteList_Grid.CellDoubleClick += WhiteList_Grid_CellDoubleClick;

            this.PriceAlert_Grid.CellDoubleClick += PriceAlert_Grid_CellDoubleClick;
            this.TradeOrder_Grid.CellDoubleClick += TradeOrder_Grid_CellDoubleClick;

            this.TimeOption1.CheckedChanged += TimeOption_CheckedChanged;
            this.TimeOption2.CheckedChanged += TimeOption_CheckedChanged;
            this.TimeOption3.CheckedChanged += TimeOption_CheckedChanged;
            this.TimeOption4.CheckedChanged += TimeOption_CheckedChanged;


        }


        //=====================================================================================================================================================================================================================================================================

        private void TradeOrder_Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (TradeOrder_Grid.Rows[e.RowIndex].Cells[11].Value.ToString().Trim() != "")
            {

                var TokenInfo = new Dictionary<string, string>();

                TokenInfo["TransactionID"] = TradeOrder_Grid.Rows[e.RowIndex].Cells[11].Value.ToString().Trim();
                TokenInfo["Symbol"] = TradeOrder_Grid.Rows[e.RowIndex].Cells[9].Value.ToString().Trim();
                TokenInfo["TokenName"] = TradeOrder_Grid.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                TokenInfo["BuyPrice"] = TradeOrder_Grid.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                TokenInfo["SellPrice"] = TradeOrder_Grid.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                TokenInfo["Capital"] = TradeOrder_Grid.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                TokenInfo["Fee"] = TradeOrder_Grid.Rows[e.RowIndex].Cells[12].Value.ToString().Trim();
                TokenInfo["Status"] = TradeOrder_Grid.Rows[e.RowIndex].Cells[13].Value.ToString().Trim();

                FrmTransaction MyFrmTransaction = new FrmTransaction();
                MyFrmTransaction.Set_Transaction(TokenInfo);
                MyFrmTransaction.ShowDialog();

            }
        }

        //=====================================================================================================================================================================================================================================================================

        private void PriceAlert_Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (WhiteList_Grid.Rows[e.RowIndex].Cells[2].Value.ToString().Trim() != "")
            {
                var TokenInfo = new Dictionary<string, string>();

                TokenInfo["Symbol"] = PriceAlert_Grid.Rows[e.RowIndex].Cells[2].Value.ToString();
                TokenInfo["TokenName"] = PriceAlert_Grid.Rows[e.RowIndex].Cells[1].Value.ToString();
                TokenInfo["TokenPrice"] = PriceAlert_Grid.Rows[e.RowIndex].Cells[3].Value.ToString();
                TokenInfo["Whitelist_ID"] = PriceAlert_Grid.Rows[e.RowIndex].Cells[4].Value.ToString();
                TokenInfo["PriceAlert_ID"] = PriceAlert_Grid.Rows[e.RowIndex].Cells[5].Value.ToString();
                TokenInfo["TokenOperator"] = PriceAlert_Grid.Rows[e.RowIndex].Cells[6].Value.ToString();

                Forms.FrmPriceNotify MyPriceAlert = new Forms.FrmPriceNotify();
                MyPriceAlert.Set_PriceAlert(TokenInfo);
                MyPriceAlert.ShowDialog();
            }
        }

        //=====================================================================================================================================================================================================================================================================

        private void TimeOption_CheckedChanged(object sender, EventArgs e)
        {

            if (TimeOption1.Checked == true)
            { MyIndicatorInterval = "1m"; MyChartInterval = "1"; }
            else if (TimeOption2.Checked == true)
            { MyIndicatorInterval = "5m"; MyChartInterval = "5"; }
            else if (TimeOption3.Checked == true)
            { MyIndicatorInterval = "15m"; MyChartInterval = "15"; }
            else if (TimeOption4.Checked == true)
            { MyIndicatorInterval = "30m"; MyChartInterval = "30"; }


            InitApplication();
            CmbToken_SelectedIndexChanged(null, null);
        }


        //=====================================================================================================================================================================================================================================================================

        private void TxtActivitionKey_KeyUp(object sender, KeyEventArgs e)
        {


        }


        //=====================================================================================================================================================================================================================================================================

        private void WhiteList_Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (WhiteList_Grid.Rows[e.RowIndex].Cells[4].Value.ToString().Trim() != "")
            {
                var TokenInfo = new Dictionary<string, string>();
                TokenInfo["TokenID"] = WhiteList_Grid.Rows[e.RowIndex].Cells[5].Value.ToString();
                TokenInfo["TokenName"] = WhiteList_Grid.Rows[e.RowIndex].Cells[1].Value.ToString();
                TokenInfo["TokenSymbol"] = WhiteList_Grid.Rows[e.RowIndex].Cells[2].Value.ToString();

                Forms.FrmToken MyFrmToken = new Forms.FrmToken();
                MyFrmToken.Set_Token(TokenInfo);
                MyFrmToken.ShowDialog();
            }

        }

        //=====================================================================================================================================================================================================================================================================

        private async void TabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabMain.SelectedIndex == 1)
            {
                TradeOrder_Timer.Enabled = false;

                WhiteList_Timer.Enabled = true;
                WhiteList_Timer.Interval = 1;
            
                MyDataGridLoader.Load_PriceAlert(PriceAlert_Grid);

                WhiteList_Grid.Rows[CmbToken.SelectedIndex].Cells[2].Selected = true;
                WhiteList_Grid.CurrentCell = WhiteList_Grid.Rows[CmbToken.SelectedIndex].Cells[2];
                WhiteList_Grid.CurrentCell.Selected = true;

                PriceAlert_Timer.Enabled = true;
                PriceAlert_Timer.Interval = 1;

            }
            else if (TabMain.SelectedIndex == 2)
            {
                BRL_Value = await MyMarketPrice.ConvertValue("USDT", "BRL", 1);

                MyDataGridLoader.Load_TradeOrder(TradeOrder_Grid);
                TradeOrder_Timer.Enabled = true;
                TradeOrder_Timer.Interval = 1;
            }

            else if (TabMain.SelectedIndex == 3)
            {
                BRL_Value = await MyMarketPrice.ConvertValue("USDT", "BRL", 1);

                TradeOrder_Timer.Enabled = false;
                Account_GetOpenOrder();
                Account_GetBalance();
                WhiteList_Timer.Enabled = false;
            }

            else if (TabMain.SelectedIndex == 0)
            {
                WhiteList_Timer.Enabled = false;
                TradeOrder_Timer.Enabled = false;
            }
        }

        //=====================================================================================================================================================================================================================================================================

        private void FrmMain_Load(object sender, EventArgs e)
        {


            Dictionary<string, string> MyApiKey = MySQLite_ApiKey.Load().Result;

          

            foreach (var apikeys in MyApiKey)
            {
                if(String.IsNullOrEmpty(apikeys.Value))
                {
                    MessageBox.Show(this, "Set your API keys to use the application.", "API Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabMain.SelectTab(TabMainPageSettings);
                    cbShowKeys.Checked = true;
                    return;
                }
            }

            TxtBinanceApiKey.Text = MyApiKey["BinanceApiKey"];
            TxtBinanceSecretKey.Text = MyApiKey["BinanceSecret"];
            TxtCoinMarketCapApiKey.Text = MyApiKey["CoinMarketCapApiKey"];
            TxtCryptoCompareApiKey.Text = MyApiKey["CryptoCompareApiKey"];
            TxtTaapi_io_ApiKey.Text = MyApiKey["Taapi_io_ApiKey"];

            string Binance_ApiKey = MyApiKey["BinanceApiKey"];
            string Binance_SecretKey = MyApiKey["BinanceSecret"];

            string CryptoCompare_ApiKey = MyApiKey["CryptoCompareApiKey"];
            string MarketCap_ApiKey = MyApiKey["CoinMarketCapApiKey"];
            MyIndicatorAPI = MyApiKey["Taapi_io_ApiKey"];

            MyBinanceAccount = new BinanceAccount(Binance_ApiKey, Binance_SecretKey);
            MyBinancePriceTicker = new BinancePriceTicker(Binance_ApiKey, Binance_SecretKey);

            MyMarketVolume = new MarketVolume(CryptoCompare_ApiKey);
            MyMarketPrice = new MarketPrice(MarketCap_ApiKey);

            TokenSymbol = "GRTUSDT"; MyToken = "GRT"; MyFiat = "USDT";
            MyIndicatorSymbol = "GRT/USDT"; MyIndicatorInterval = "15m"; MyChartInterval = "15";


            foreach (Control MyControl in TabMain.Controls)
            {
                if (MyControl is TabPage)
                {
                    TabPage MyTabPage = MyControl as TabPage;
                    foreach (Control MyTabPageControl in MyTabPage.Controls)
                    {
                        if (MyTabPageControl is DataGridView)
                        {
                            DataGridView MyGrid = MyTabPageControl as DataGridView;
                            MyGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
                            MyGrid.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Regular);
                            MyGrid.AlternatingRowsDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Regular);
                        }
                    }
                }
            }

            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            CefSharpSettings.WcfEnabled = false;

            CefSettings settings = new CefSettings();

            settings.UserAgent = UserAgent;
            settings.AcceptLanguageList = AcceptLanguage;
            settings.IgnoreCertificateErrors = true;

            Cef.Initialize(settings);

            Load_WhiteList();
            MyDataGridLoader.Load_PriceAlert(PriceAlert_Grid);
            MyDataGridLoader.Load_TradeOrder(TradeOrder_Grid);

            InitApplication();
        }

        //=====================================================================================================================================================================================================================================================================

        private void InitApplication()
        {

            if (TxtBinanceApiKey.Text.Trim() != "" && TxtBinanceSecretKey.Text.Trim() != "" && TxtCoinMarketCapApiKey.Text.Trim() != "" && TxtCryptoCompareApiKey.Text.Trim() != "" && TxtTaapi_io_ApiKey.Text.Trim() != "")
            {

                TxtBinanceApiKey.PasswordChar = '*';
                TxtBinanceSecretKey.PasswordChar = '*';
                TxtCoinMarketCapApiKey.PasswordChar = '*';
                TxtCryptoCompareApiKey.PasswordChar = '*';
                TxtTaapi_io_ApiKey.PasswordChar = '*';


                Init_Layout();

                PriceTicker_Timer.Enabled = true;
                Volume_Timer.Enabled = true;
                StochRSI_Timer.Enabled = true;
                CCI_Timer.Enabled = true;
                IMI_Timer.Enabled = true;
                UltOsc_Timer.Enabled = true;
                PPO_Timer.Enabled = true;
                ChandeOsc_Timer.Enabled = true;
                Fibonnci_Timer.Enabled = true;
                BB_Timer.Enabled = true;
                TechAnalysis_Timer.Enabled = true;
                Counter_Timer.Enabled = true;

                PriceAlert_Timer.Enabled = true;
                PriceAlert_Timer.Interval = 1;

                Account_GetOpenOrder();
                Account_GetBalance();

            }
        }

        //=====================================================================================================================================================================================================================================================================
        private async void Account_GetBalance()
        {
            try
            {

                var MyAccountInformation = await MyBinanceAccount.GetInformation();

                Balance_Grid.Rows.Clear();
                Balance_Grid.RowCount = 1;
                int Counter = 0;
                double USDT_GrandTotal = 0;
                double BRL_GrandTotal = 0;
                for (int Cnt = 0; Cnt < MyAccountInformation.Balances.Count; Cnt++)
                {
                    if ((Convert.ToDouble(MyAccountInformation.Balances[Cnt].Free) + Convert.ToDouble(MyAccountInformation.Balances[Cnt].Locked)) > 0.00000000)
                    {
                        Counter++;
                        double BalanceTotal = Convert.ToDouble(MyAccountInformation.Balances[Cnt].Free) + Convert.ToDouble(MyAccountInformation.Balances[Cnt].Locked);
                        double USDT_Value = 1;

                        try
                        {
                            if (MyAccountInformation.Balances[Cnt].Asset.ToString() != "USDT")
                            {
                                string MyToken = MyAccountInformation.Balances[Cnt].Asset.ToString();

                                if (MyToken.Trim().Substring(0, 2).ToUpper().Trim() == "LD")
                                {
                                    if (MyToken.Trim().Length >= 5)
                                    { MyToken = MyToken.Substring(2, MyToken.Length - (MyToken.Length - 3)); }
                                }

                                USDT_Value = await MyBinancePriceTicker.Convert_to_USDT(MyToken.Trim());
                            }
                        }
                        catch {; }


                        string USDT_Total = (BalanceTotal * USDT_Value).ToString("###,###,##0.00");
                        USDT_GrandTotal += Convert.ToDouble(USDT_Total);

                        Balance_Grid.Rows.Add(Counter.ToString(), MyAccountInformation.Balances[Cnt].Asset.ToString(), MyAccountInformation.Balances[Cnt].Free.ToString("###,###,##0.00######"), MyAccountInformation.Balances[Cnt].Locked.ToString("###,###,##0.00######"), BalanceTotal.ToString("###,###,##0.00######"), USDT_Total, "");
                    }
                }

                for (int Cnt = 0; Cnt <= Balance_Grid.RowCount - 2; Cnt++)
                {
                    BRL_GrandTotal += BRL_Value * Convert.ToDouble(Balance_Grid.Rows[Cnt].Cells[5].Value.ToString());
                    Balance_Grid.Rows[Cnt].Cells[6].Value = (BRL_Value * Convert.ToDouble(Balance_Grid.Rows[Cnt].Cells[5].Value.ToString())).ToString("###,###,###,##0.00");
                }

                TxtUSDT_Total.Text = USDT_GrandTotal.ToString("###,###,###,##0.00");
                TxtBRL_Total.Text = BRL_GrandTotal.ToString("###,###,###,##0.00");


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        //=====================================================================================================================================================================================================================================================================

        private async void Account_GetOpenOrder()
        {
            Order_Grid.RowCount = 1;
            Order_Grid.Rows.Clear();

            if (WhiteList_Grid.RowCount >= 1)
            {
                try
                {
                    for (int Cnt = 0; Cnt < WhiteList_Grid.RowCount; Cnt++)
                    {

                        if (WhiteList_Grid.Rows[Cnt].Cells[2].Value.ToString().Trim() != "")
                        {
                            var MyOrders = await MyBinanceAccount.GetOpenOrder(WhiteList_Grid.Rows[Cnt].Cells[2].Value.ToString().Trim() + "USDT");

                            for (int Counter = 0; Counter < MyOrders.Count; Counter++)
                            {
                                Order_Grid.Rows.Add(MyOrders[Counter].OrderId.ToString(), MyOrders[Counter].Symbol.ToString(), Convert.ToDouble(MyOrders[Counter].OriginalQuantity.ToString()).ToString("###,###,##0.00######"), Convert.ToDouble(MyOrders[Counter].Price.ToString()).ToString("###,###,##0.00######"), Convert.ToDouble(MyOrders[Counter].StopPrice.ToString()).ToString("###,###,##0.00######"), "   " + MyOrders[Counter].Side.ToString() + "-" + MyOrders[Counter].Type.ToString(), (Convert.ToDouble(MyOrders[Counter].OriginalQuantity.ToString()) * Convert.ToDouble(MyOrders[Counter].Price.ToString())).ToString("###,###,##0.00######"), "   " + MyOrders[Counter].Time.ToString());
                            }
                        }
                    }

                }
                catch {; }
            }

        }

        //=====================================================================================================================================================================================================================================================================
        private async void PriceTicker_Timer_Tick(object sender, EventArgs e)
        {
            PriceTicker_Timer.Interval = 1000 * 3;
            try
            {
                var MyDailyTicker = await MyBinancePriceTicker.GetCurrentPrice(TokenSymbol);

                string PriceDirection = "  ♦";
                Color MyColor = Color.Black;
                Color MyPriceChangeColor = Color.Black;

                try
                {

                    TxtPrice.Text = "   " + Convert.ToDouble(MyDailyTicker.LastPrice.ToString()).ToString("###,###,##0.0#######");
                    TxtPriceChange.Text = Convert.ToDouble(MyDailyTicker.PriceChangePercent).ToString("###,###,##0.0") + "%";
                    TxtBidPrice.Text = Convert.ToDouble(MyDailyTicker.BidPrice.ToString()).ToString("###,###,##0.0#######");
                    TxtOpenePrice.Text = Convert.ToDouble(MyDailyTicker.OpenPrice.ToString()).ToString("###,###,##0.0#######");
                    TxtAskPrice.Text = Convert.ToDouble(MyDailyTicker.AskPrice.ToString()).ToString("###,###,##0.0#######");

                    if (MyDailyTicker.LastPrice.ToString() != PriceTicker_Grid.Rows[0].Cells[1].Value.ToString().Split(' ')[0].Trim())
                    {
                        if (Convert.ToDouble(MyDailyTicker.LastPrice.ToString()) > Convert.ToDouble(PriceTicker_Grid.Rows[0].Cells[1].Value.ToString().Split(' ')[0].Trim()))
                        { PriceDirection = "  ▲"; MyColor = Color.DarkGreen; }
                        else { PriceDirection = "  ▼"; MyColor = Color.DarkRed; }

                        if (Convert.ToDouble(MyDailyTicker.PriceChangePercent) >= 0)
                        { MyPriceChangeColor = Color.DarkGreen; }
                        else { MyPriceChangeColor = Color.DarkRed; }

                        if (PriceTicker_Grid.RowCount <= 1) { PriceDirection = "  ♦"; }

                        PriceTicker_Grid.Rows.Insert(0, DateTime.Now.ToString("hh:mm:ss tt,  MMM-dd").ToUpper(), Convert.ToDouble(MyDailyTicker.LastPrice.ToString()).ToString("###,###,##0.0#######") + PriceDirection, "    " + Convert.ToDouble(MyDailyTicker.PriceChange.ToString()).ToString("###,###,##0.0#######") + ",   " + Convert.ToDouble(MyDailyTicker.PriceChangePercent).ToString("###,###,##0.0#") + "%", Convert.ToDouble(MyDailyTicker.Volume.ToString()).ToString("###,###,##0.0#######"), AroonTrend, BBTrend, TechnicalAnalysis);

                        if (PriceTicker_Grid.RowCount >= 102)
                        { PriceTicker_Grid.Rows.RemoveAt(100); }
                    }
                    else
                    {
                        PriceTicker_Grid.Rows[0].Cells[0].Value = DateTime.Now.ToString("hh:mm:ss tt,  MMM-dd").ToUpper();
                        MyColor = PriceTicker_Grid.Rows[0].Cells[1].Style.ForeColor;
                        MyPriceChangeColor = PriceTicker_Grid.Rows[0].Cells[2].Style.ForeColor;
                    }
                }
                catch { PriceTicker_Grid.Rows.Insert(0, DateTime.Now.ToString("hh:mm:ss tt,  MMM-dd").ToUpper(), Convert.ToDouble(MyDailyTicker.LastPrice.ToString()).ToString("###,###,##0.0#######") + PriceDirection, "    " + Convert.ToDouble(MyDailyTicker.PriceChange.ToString()).ToString("###,###,##0.0#######") + ",   " + Convert.ToDouble(MyDailyTicker.PriceChangePercent).ToString("###,###,##0.0#") + "%", Convert.ToDouble(MyDailyTicker.Volume.ToString()).ToString("###,###,##0.0#######"), AroonTrend, BBTrend, TechnicalAnalysis); }

                PriceTicker_Grid.Rows[0].Cells[1].Style.ForeColor = MyColor;
                PriceTicker_Grid.Rows[0].Cells[2].Style.ForeColor = MyPriceChangeColor;

                TxtPrice.ForeColor = MyColor;
                TxtPriceChange.ForeColor = MyPriceChangeColor;
                TxtBidPrice.ForeColor = MyColor;

                //-------
                if (AroonTrend.Split('(')[0].ToUpper().Trim() == "DOWNTREND")
                { PriceTicker_Grid.Rows[0].Cells[4].Style.ForeColor = Color.DarkRed; }
                else if (AroonTrend.Split('(')[0].ToUpper().Trim() == "UPTREND")
                { PriceTicker_Grid.Rows[0].Cells[4].Style.ForeColor = Color.DarkGreen; }
                else { PriceTicker_Grid.Rows[0].Cells[4].Style.ForeColor = Color.Black; }

                PriceTicker_Grid.Rows[0].Cells[5].Style.ForeColor = PriceTicker_Grid.Rows[0].Cells[1].Style.ForeColor;

                //-------

                if (TechnicalAnalysis.ToUpper().Trim() == "BUY" || TechnicalAnalysis.ToUpper().Trim() == "STRONG BUY")
                { PriceTicker_Grid.Rows[0].Cells[6].Style.ForeColor = Color.DarkGreen; }
                else if (TechnicalAnalysis.ToUpper().Trim() == "SELL" | TechnicalAnalysis.ToUpper().Trim() == "STRONG SELL")
                { PriceTicker_Grid.Rows[0].Cells[6].Style.ForeColor = Color.DarkRed; }
                else { PriceTicker_Grid.Rows[0].Cells[6].Style.ForeColor = Color.Black; }
            }
            catch {; }

        }


        //========================================================================================================================================================================================================================================================================

        private async void Volume_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Volume_Timer.Interval = 1000 * 20;
                string VolumeResult = await MyMarketVolume.GetRequest(MyToken, MyFiat, "Binance");
                VolumeResult = VolumeResult.ToUpper().Replace(MyToken.ToUpper(), "XXX");

                dynamic MyVolume = JsonConvert.DeserializeObject(VolumeResult);

                TxtHighHour.Text = Convert.ToDouble((string)MyVolume.RAW.XXX.USDT.HIGHHOUR).ToString("###,###,###,##0.00######");
                TxtHigh24Hour.Text = Convert.ToDouble((string)MyVolume.RAW.XXX.USDT.HIGH24HOUR).ToString("###,###,###,##0.00######");
                TxtLowHour.Text = Convert.ToDouble((string)MyVolume.RAW.XXX.USDT.LOWHOUR).ToString("###,###,###,##0.00######");
                TxtLow24Hour.Text = Convert.ToDouble((string)MyVolume.RAW.XXX.USDT.LOW24HOUR).ToString("###,###,###,##0.00######");
                TxtHighDay.Text = Convert.ToDouble((string)MyVolume.RAW.XXX.USDT.HIGHDAY).ToString("###,###,###,##0.00######");
                TxtLowDay.Text = Convert.ToDouble((string)MyVolume.RAW.XXX.USDT.LOWDAY).ToString("###,###,###,##0.00######");
            }
            catch {; }

        }

        //========================================================================================================================================================================================================================================================================

        private void InitIndicator_Grid()
        {

            BinanceIndicator_Grid.Rows.Clear();
            BinanceIndicator_Grid.RowCount = 6;
            BinanceIndicator_Grid.Rows[0].Cells[0].Value = "Stoch RSI TV";
            BinanceIndicator_Grid.Rows[1].Cells[0].Value = "Commodity Channel Index";
            BinanceIndicator_Grid.Rows[2].Cells[0].Value = "Ultimate Oscillator";
            BinanceIndicator_Grid.Rows[3].Cells[0].Value = "Chande Momentum Oscillator";
            BinanceIndicator_Grid.Rows[4].Cells[0].Value = "Money Flow Index";
            BinanceIndicator_Grid.Rows[5].Cells[0].Value = "Percentage Price Oscillator";


        }

        //========================================================================================================================================================================================================================================================================

        private async void StochRSI_Timer_Tick(object sender, EventArgs e)
        {
            BinanceIndicator MyBinanceIndicator = new BinanceIndicator();

            StochRSI_Timer.Interval = 1000 * 30;
            try
            {
                string StochRSI = await MyBinanceIndicator.Request("stochrsitv", MyIndicatorSymbol, MyIndicatorInterval, MyIndicatorAPI);
                dynamic MyStochRSI = JsonConvert.DeserializeObject(StochRSI);
                PBar.Value = 0;

                string Data = Convert.ToDouble((string)MyStochRSI.value.valueK, CultureInfo.InvariantCulture).ToString("##0.0") + ",  " + Convert.ToDouble((string)MyStochRSI.value.valueD, CultureInfo.InvariantCulture).ToString("##0.0");
                string Remark = "  Neutral";
                string Signal = "  Neutral";

                if (Convert.ToDouble((string)MyStochRSI.value.valueK, CultureInfo.InvariantCulture) > Convert.ToDouble((string)MyStochRSI.value.valueD, CultureInfo.InvariantCulture))
                { 
                    Data += "  ▲"; BinanceIndicator_Grid.Rows[0].Cells[1].Style.ForeColor = Color.DarkGreen;
                }
                else 
                { 
                    Data += "  ▼"; BinanceIndicator_Grid.Rows[0].Cells[1].Style.ForeColor = Color.DarkRed; 
                }


                if (Convert.ToDouble((string)MyStochRSI.value.valueK, CultureInfo.InvariantCulture) >= 85)
                {
                    Remark = "  OverBought";

                    if (Convert.ToDouble((string)MyStochRSI.value.valueK, CultureInfo.InvariantCulture) < Convert.ToDouble((string)MyStochRSI.value.valueD, CultureInfo.InvariantCulture))
                    { Signal = "  Sell"; }

                }
                else if (Convert.ToDouble((string)MyStochRSI.value.valueK, CultureInfo.InvariantCulture) <= 15)
                {
                    Remark = "  OverSold";
                    if (Convert.ToDouble((string)MyStochRSI.value.valueK, CultureInfo.InvariantCulture) > Convert.ToDouble((string)MyStochRSI.value.valueD, CultureInfo.InvariantCulture))
                    { Signal = "  Buy"; }
                }
                else { Remark = "  Neutral"; }

                BinanceIndicator_Grid.Rows[0].Cells[1].Value = Data;
                BinanceIndicator_Grid.Rows[0].Cells[2].Value = Remark;
                BinanceIndicator_Grid.Rows[0].Cells[3].Value = Signal;


            }
            catch {; }

        }



        //========================================================================================================================================================================================================================================================================

        private async void CCI_Timer_Tick(object sender, EventArgs e)
        {
            BinanceIndicator MyBinanceIndicator = new BinanceIndicator();

            CCI_Timer.Interval = 1000 * 30;
            try
            {
                string CCI = await MyBinanceIndicator.Request("cci", MyIndicatorSymbol, MyIndicatorInterval, MyIndicatorAPI);
                dynamic MyCCI = JsonConvert.DeserializeObject(CCI);

                string Remark = "  Neutral";
                string Signal = "  Neutral";
                string Data = Convert.ToDouble((string)MyCCI.value).ToString("##0.0#");

                if (Convert.ToDouble((string)MyCCI.value) >= 110)
                {
                    Remark = "  OverBought";
                    Signal = "  Sell";

                }
                else if (Convert.ToDouble((string)MyCCI.value) <= -110)
                {
                    Remark = "  OverSold";
                    Signal = "  Buy";
                }

                try
                {
                    if (Convert.ToDouble(BinanceIndicator_Grid.Rows[1].Cells[1].Value.ToString().Split(' ')[0].Trim()) < Convert.ToDouble((string)MyCCI.value))
                    { Data += "  ▲"; BinanceIndicator_Grid.Rows[1].Cells[1].Style.ForeColor = Color.DarkGreen; }
                    else { Data += "  ▼"; BinanceIndicator_Grid.Rows[1].Cells[1].Style.ForeColor = Color.DarkRed; }
                }
                catch { Data += "  ♦"; }
                finally
                {
                    BinanceIndicator_Grid.Rows[1].Cells[1].Value = Data;
                    BinanceIndicator_Grid.Rows[1].Cells[2].Value = Remark;
                    BinanceIndicator_Grid.Rows[1].Cells[3].Value = Signal;
                }


            }
            catch {; }

        }
        //========================================================================================================================================================================================================================================================================

        private async void UltOsc_Timer_Tick(object sender, EventArgs e)
        {
            BinanceIndicator MyBinanceIndicator = new BinanceIndicator();

            UltOsc_Timer.Interval = 1000 * 30;
            try
            {
                string UltOsc = await MyBinanceIndicator.Request("ultosc", MyIndicatorSymbol, MyIndicatorInterval, MyIndicatorAPI);
                dynamic MyUltOsc = JsonConvert.DeserializeObject(UltOsc);

                string Remark = "  Neutral";
                string Signal = "  Neutral";
                string Data = Convert.ToDouble((string)MyUltOsc.value).ToString("##0.0#");

                if (Convert.ToDouble((string)MyUltOsc.value) >= 70)
                {
                    Remark = "  OverBought";
                    Signal = "  Sell";

                }
                else if (Convert.ToDouble((string)MyUltOsc.value) <= 30)
                {
                    Remark = "  OverSold";
                    Signal = "  Buy";
                }

                try
                {
                    if (Convert.ToDouble(BinanceIndicator_Grid.Rows[2].Cells[1].Value.ToString().Split(' ')[0].Trim()) < Convert.ToDouble((string)MyUltOsc.value))
                    { Data += "  ▲"; BinanceIndicator_Grid.Rows[2].Cells[1].Style.ForeColor = Color.DarkGreen; }
                    else { Data += "  ▼"; BinanceIndicator_Grid.Rows[2].Cells[1].Style.ForeColor = Color.DarkRed; }
                }
                catch { Data += "  ♦"; }
                finally
                {
                    BinanceIndicator_Grid.Rows[2].Cells[1].Value = Data;
                    BinanceIndicator_Grid.Rows[2].Cells[2].Value = Remark;
                    BinanceIndicator_Grid.Rows[2].Cells[3].Value = Signal;
                }

            }
            catch {; }
        }



        //========================================================================================================================================================================================================================================================================

        private async void ChandeOsc_Timer_Tick(object sender, EventArgs e)
        {
            BinanceIndicator MyBinanceIndicator = new BinanceIndicator();

            ChandeOsc_Timer.Interval = 1000 * 30;
            try
            {
                string ChandeOsc = await MyBinanceIndicator.Request("cmo", MyIndicatorSymbol, MyIndicatorInterval, MyIndicatorAPI);
                dynamic MyChandeOsc = JsonConvert.DeserializeObject(ChandeOsc);

                string Remark = "  Neutral";
                string Signal = "  Neutral";
                string Data = Convert.ToDouble((string)MyChandeOsc.value).ToString("##0.0#");

                if (Convert.ToDouble((string)MyChandeOsc.value) >= 50)
                {
                    Remark = "  OverBought";
                    Signal = "  Sell";

                }
                else if (Convert.ToDouble((string)MyChandeOsc.value) <= -50)
                {
                    Remark = "  OverSold";
                    Signal = "  Buy";
                }

                try
                {
                    if (Convert.ToDouble(BinanceIndicator_Grid.Rows[3].Cells[1].Value.ToString().Split(' ')[0].Trim()) < Convert.ToDouble((string)MyChandeOsc.value))
                    { Data += "  ▲"; BinanceIndicator_Grid.Rows[3].Cells[1].Style.ForeColor = Color.DarkGreen; }
                    else { Data += "  ▼"; BinanceIndicator_Grid.Rows[3].Cells[1].Style.ForeColor = Color.DarkRed; }
                }
                catch { Data += "  ♦"; }
                finally
                {
                    BinanceIndicator_Grid.Rows[3].Cells[1].Value = Data;
                    BinanceIndicator_Grid.Rows[3].Cells[2].Value = Remark;
                    BinanceIndicator_Grid.Rows[3].Cells[3].Value = Signal;
                }

            }
            catch {; }
        }


        //========================================================================================================================================================================================================================================================================

        private async void IMI_Timer_Tick(object sender, EventArgs e)
        {
            BinanceIndicator MyBinanceIndicator = new BinanceIndicator();

            IMI_Timer.Interval = 1000 * 30;
            try
            {
                string MFI = await MyBinanceIndicator.Request("mfi", MyIndicatorSymbol, MyIndicatorInterval, MyIndicatorAPI);
                dynamic MyMFI = JsonConvert.DeserializeObject(MFI);

                string Remark = "  Neutral";
                string Signal = "  Neutral";
                string Data = Convert.ToDouble((string)MyMFI.value).ToString("##0.0#");

                if (Convert.ToDouble((string)MyMFI.value) >= 80)
                {
                    Remark = "  OverBought";
                    Signal = "  Sell";
                }
                else if (Convert.ToDouble((string)MyMFI.value) <= 20)
                {
                    Remark = "  OverSold";
                    Signal = "  Buy";
                }

                try
                {
                    if (Convert.ToDouble(BinanceIndicator_Grid.Rows[4].Cells[1].Value.ToString().Split(' ')[0].Trim()) < Convert.ToDouble((string)MyMFI.value))
                    { Data += "  ▲"; BinanceIndicator_Grid.Rows[4].Cells[1].Style.ForeColor = Color.DarkGreen; }
                    else { Data += "  ▼"; BinanceIndicator_Grid.Rows[4].Cells[1].Style.ForeColor = Color.DarkRed; }
                }
                catch { Data += "  ♦"; }
                finally
                {
                    BinanceIndicator_Grid.Rows[4].Cells[1].Value = Data;
                    BinanceIndicator_Grid.Rows[4].Cells[2].Value = Remark;
                    BinanceIndicator_Grid.Rows[4].Cells[3].Value = Signal;
                }

            }
            catch {; }
        }

        //========================================================================================================================================================================================================================================================================

        private async void PPO_Timer_Tick(object sender, EventArgs e)
        {
            BinanceIndicator MyBinanceIndicator = new BinanceIndicator();

            PPO_Timer.Interval = 1000 * 30;
            try
            {
                string PPO = await MyBinanceIndicator.Request("ppo", MyIndicatorSymbol, MyIndicatorInterval, MyIndicatorAPI);
                dynamic MyPPO = JsonConvert.DeserializeObject(PPO);

                string Remark = "  Neutral";
                string Signal = "  Neutral";
                string Data = Convert.ToDouble((string)MyPPO.value).ToString("##0.0#");

                if (Convert.ToDouble((string)MyPPO.value) >= 5)
                {
                    if (BinanceIndicator_Grid.Rows[0].Cells[3].Value.ToString().Trim() == "Sell")
                    {
                        Remark = "  OverBought";
                        Signal = "  Sell";
                    }

                }
                else if (Convert.ToDouble((string)MyPPO.value) <= -5)
                {
                    if (BinanceIndicator_Grid.Rows[0].Cells[3].Value.ToString().Trim() == "Buy")
                    {
                        Remark = "  OverSold";
                        Signal = "  Buy";
                    }
                }

                try
                {
                    if (Convert.ToDouble(BinanceIndicator_Grid.Rows[5].Cells[1].Value.ToString().Split(' ')[0].Trim()) < Convert.ToDouble((string)MyPPO.value))
                    { Data += "  ▲"; BinanceIndicator_Grid.Rows[5].Cells[1].Style.ForeColor = Color.DarkGreen; }
                    else { Data += "  ▼"; BinanceIndicator_Grid.Rows[5].Cells[1].Style.ForeColor = Color.DarkRed; }
                }
                catch { Data += "  ♦"; }
                finally
                {
                    BinanceIndicator_Grid.Rows[5].Cells[1].Value = Data;
                    BinanceIndicator_Grid.Rows[5].Cells[2].Value = Remark;
                    BinanceIndicator_Grid.Rows[5].Cells[3].Value = Signal;
                }

            }
            catch {; }
        }


        //========================================================================================================================================================================================================================================================================

        private async void Fibonnci_Timer_Tick(object sender, EventArgs e)
        {
            BinanceIndicator MyBinanceIndicator = new BinanceIndicator();

            Fibonnci_Timer.Interval = 1000 * 30;
            try
            {
                string Aroon = await MyBinanceIndicator.Request("aroon", MyIndicatorSymbol, MyIndicatorInterval, MyIndicatorAPI);
                dynamic MyAroon = JsonConvert.DeserializeObject(Aroon);

                try
                {
                    double UpAroon = Convert.ToDouble((string)MyAroon.valueAroonUp);
                    double DownAroon = Convert.ToDouble((string)MyAroon.valueAroonDown);

                    if (UpAroon > DownAroon)
                    { AroonTrend = "  UPTREND (" + (UpAroon - DownAroon).ToString("#0.#") + "%)"; }
                    else { AroonTrend = "  DOWNTREND (" + (DownAroon - UpAroon).ToString("#0.#") + "%)"; }

                }
                catch
                {
                    try { AroonTrend = PriceTicker_Grid.Rows[0].Cells[4].Value.ToString(); }
                    catch { AroonTrend = "   ---"; }
                }

            }
            catch {; }
        }


        //========================================================================================================================================================================================================================================================================

        private async void BB_Timer_Tick(object sender, EventArgs e)
        {
            BinanceIndicator MyBinanceIndicator = new BinanceIndicator();

            BB_Timer.Interval = 1000 * 30;
            string[,] BB_Data = new string[3, 2];

            try
            {
                string Bollinger = await MyBinanceIndicator.Request("bbands2", MyIndicatorSymbol, MyIndicatorInterval, MyIndicatorAPI);

                dynamic MyBollinger = JsonConvert.DeserializeObject(Bollinger);

                double CurrentPrice = Convert.ToDouble(PriceTicker_Grid.Rows[0].Cells[1].Value.ToString().Split(' ')[0].Trim());


                double Upper = CurrentPrice - Convert.ToDouble((string)MyBollinger.valueUpperBand);
                double Middle = CurrentPrice - Convert.ToDouble((string)MyBollinger.valueMiddleBand);
                double Lower = CurrentPrice - Convert.ToDouble((string)MyBollinger.valueLowerBand);

                try
                {
                    Upper = Upper < 0 ? Upper * -1 : Upper;
                    Middle = Middle < 0 ? Middle * -1 : Middle;
                    Lower = Lower < 0 ? Lower * -1 : Lower;

                    BB_Data[0, 0] = "  UPPER BAND"; BB_Data[0, 1] = Upper.ToString();
                    BB_Data[1, 0] = "  MIDDLE BAND"; BB_Data[1, 1] = Middle.ToString();
                    BB_Data[2, 0] = "  LOWER BAND"; BB_Data[2, 1] = Lower.ToString();

                    for (int Cnt1 = 0; Cnt1 < 2; Cnt1++)
                    {
                        for (int Cnt2 = Cnt1 + 1; Cnt2 < 3; Cnt2++)
                        {
                            if (Convert.ToDouble(BB_Data[Cnt1, 1]) > Convert.ToDouble(BB_Data[Cnt2, 1]))
                            {
                                string Temp = BB_Data[Cnt1, 1];
                                BB_Data[Cnt1, 1] = BB_Data[Cnt2, 1];
                                BB_Data[Cnt2, 1] = Temp;

                                Temp = BB_Data[Cnt1, 0];
                                BB_Data[Cnt1, 0] = BB_Data[Cnt2, 0];
                                BB_Data[Cnt2, 0] = Temp;
                            }
                        }
                    }

                }
                catch {; }

            }
            catch {; }


            try
            {
                BBTrend = BB_Data[0, 0];
                if (BB_Data[0, 0].Trim() == "")
                { BBTrend = PriceTicker_Grid.Rows[0].Cells[5].Value.ToString(); }
            }
            catch
            {
                try { BBTrend = PriceTicker_Grid.Rows[0].Cells[5].Value.ToString(); }
                catch { BBTrend = "   ---"; }
            }


        }

        //========================================================================================================================================================================================================================================================================


        private void TechAnalysis_Timer_Tick(object sender, EventArgs e)
        {
            string[,] TA_Data = new string[3, 2];

            TA_Data[0, 0] = "BUY"; TA_Data[0, 1] = "0";
            TA_Data[1, 0] = "SELL"; TA_Data[1, 1] = "0";
            TA_Data[2, 0] = "NEUTRAL"; TA_Data[2, 1] = "0";

            try
            {
                for (int Cnt = 0; Cnt <= 5; Cnt++)
                {
                    string Signal = BinanceIndicator_Grid.Rows[Cnt].Cells[3].Value.ToString().Trim();
                    if (Signal.ToUpper().Trim() == "BUY")
                    { TA_Data[0, 1] = (Convert.ToDouble(TA_Data[0, 1]) + 1).ToString(); }
                    else if (Signal.ToUpper().Trim() == "SELL")
                    { TA_Data[1, 1] = (Convert.ToDouble(TA_Data[1, 1]) + 1).ToString(); }
                    else { TA_Data[2, 1] = (Convert.ToDouble(TA_Data[2, 1]) + 1).ToString(); }
                }

                TA_Data[2, 1] = (Convert.ToDouble(TA_Data[2, 1]) - 2).ToString();


                for (int Cnt1 = 0; Cnt1 < 2; Cnt1++)
                {
                    for (int Cnt2 = Cnt1 + 1; Cnt2 < 3; Cnt2++)
                    {
                        if (Convert.ToDouble(TA_Data[Cnt1, 1]) > Convert.ToDouble(TA_Data[Cnt2, 1]))
                        {
                            string Temp = TA_Data[Cnt1, 1];
                            TA_Data[Cnt1, 1] = TA_Data[Cnt2, 1];
                            TA_Data[Cnt2, 1] = Temp;

                            Temp = TA_Data[Cnt1, 0];
                            TA_Data[Cnt1, 0] = TA_Data[Cnt2, 0];
                            TA_Data[Cnt2, 0] = Temp;
                        }
                    }
                }


            }
            catch {; }


            TechnicalAnalysis = "  NEUTRAL";
            try
            {

                if (TA_Data[2, 0] == "BUY")
                {
                    if (PriceTicker_Grid.Rows[0].Cells[5].Value.ToString().Trim() == "LOWER BAND")
                    {
                        if (Convert.ToDouble(TA_Data[2, 1]) >= 4)
                        {
                            TechnicalAnalysis = "  STRONG BUY";
                        }
                        else { TechnicalAnalysis = "  BUY"; }
                    }
                    else { TechnicalAnalysis = "  BUY"; }
                }
                else if (TA_Data[2, 0] == "SELL")
                {
                    if (PriceTicker_Grid.Rows[0].Cells[5].Value.ToString().Trim() == "UPPER BAND")
                    {
                        if (Convert.ToDouble(TA_Data[2, 1]) >= 4)
                        {
                            TechnicalAnalysis = "  STRONG SELL";
                        }
                        else { TechnicalAnalysis = "  SELL"; }
                    }
                    else { TechnicalAnalysis = "  SELL"; }
                }

            }
            catch {; }
        }


        //========================================================================================================================================================================================================================================================================

        private void CmbToken_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbToken.Text.Trim() != "")
            {
                TxtSymbol.Text = ((string)MyWhiteList[CmbToken.SelectedIndex].Symbol).Trim() + "/USDT";
                TokenSymbol = ((string)MyWhiteList[CmbToken.SelectedIndex].Symbol).Trim() + "USDT";
                MyToken = ((string)MyWhiteList[CmbToken.SelectedIndex].Symbol).Trim();
                MyIndicatorSymbol = TxtSymbol.Text;

                Init_Layout();

                MyTradingView = new TradingView();
                MyBrowser = new ChromiumWebBrowser("");
                MyBrowser.LoadHtml(MyTradingView.ViewChart(TokenSymbol, Convert.ToInt32(MyChartInterval), MyPanelBrowser.Width + 5, MyPanelBrowser.Height + 20));

                MyPanelBrowser.Controls.Clear();
                MyBrowser.Dock = DockStyle.None;

                MyBrowser.Height = MyPanelBrowser.Height + 30;
                MyBrowser.Width = MyPanelBrowser.Width + 30;

                MyPanelBrowser.Controls.Add(MyBrowser);

                MyBrowser.Top = -10;
                MyBrowser.Left = -15;



            }
        }

        //========================================================================================================================================================================================================================================================================

        public void Init_Layout()
        {

            TxtHighHour.Text = "0.0";
            TxtHigh24Hour.Text = "0.0";
            TxtLowHour.Text = "0.0";
            TxtLow24Hour.Text = "0.0";
            TxtHighDay.Text = "0.0";
            TxtLowDay.Text = "0.0";

            AroonTrend = "   ---";
            BBTrend = "   ---";
            TechnicalAnalysis = "NEUTRAL";


            PriceTicker_Grid.RowCount = 1;
            PriceTicker_Grid.Rows.Clear();

            InitIndicator_Grid();

        }


        //========================================================================================================================================================================================================================================================================

        private void Counter_Timer_Tick(object sender, EventArgs e)
        {
            if (PBar.Value != 30)
            { PBar.Value += 1; }
        }

        //========================================================================================================================================================================================================================================================================

        public void Load_WhiteList()
        {
            MyWhiteList = JsonConvert.DeserializeObject(MySQLite_Whitelist.Load().Result);
            CmbToken.Items.Clear();

            WhiteList_Grid.Rows.Clear();
            WhiteList_Grid.RowCount = MyWhiteList.Count;

            for (int Cnt = 0; Cnt < MyWhiteList.Count; Cnt++)
            {
                WhiteList_Grid.Rows[Cnt].Cells[0].Value = (Cnt + 1).ToString();
                WhiteList_Grid.Rows[Cnt].Cells[1].Value = (string)MyWhiteList[Cnt].Name;
                WhiteList_Grid.Rows[Cnt].Cells[2].Value = (string)MyWhiteList[Cnt].Symbol;
                WhiteList_Grid.Rows[Cnt].Cells[5].Value = (string)MyWhiteList[Cnt].WhiteList_ID;

                CmbToken.Items.Add((string)MyWhiteList[Cnt].Name);
                CmbToken.SelectedIndex = Cnt;
            }

        }

        //========================================================================================================================================================================================================================================================================

        private async void WhiteList_Timer_Tick(object sender, EventArgs e)
        {
            WhiteList_Timer.Enabled = false;
            WhiteList_Timer.Interval = 1000 * 10;
            if (WhiteList_Grid.RowCount >= 1)
            {
                int Counter = 0;
                try
                {
                    for (int Cnt = 0; Cnt < WhiteList_Grid.RowCount; Cnt++)
                    {
                        if (WhiteList_Grid.Rows[Cnt].Cells[2].Value.ToString().Trim() != "")
                        {
                            var MyDailyTicker = await MyBinancePriceTicker.GetCurrentPrice(WhiteList_Grid.Rows[Cnt].Cells[2].Value.ToString().Trim() + "USDT");
                            Counter++;

                            try
                            {
                                if (WhiteList_Grid.Rows[Cnt].Cells[3].Value == null)
                                    throw new Exception();


                                if (Convert.ToDouble(WhiteList_Grid.Rows[Cnt].Cells[3].Value.ToString().Split(' ')[0]) >= Convert.ToDouble(MyDailyTicker.LastPrice.ToString()))
                                {
                                    WhiteList_Grid.Rows[Cnt].Cells[3].Value = Convert.ToDouble(MyDailyTicker.LastPrice.ToString()).ToString("###,###,##0.0#######  ▼");
                                }
                                else
                                {
                                    WhiteList_Grid.Rows[Cnt].Cells[3].Value = Convert.ToDouble(MyDailyTicker.LastPrice.ToString()).ToString("###,###,##0.0#######  ▲");
                                }
                            }
                            catch (System.NullReferenceException)
                            {
                                WhiteList_Grid.Rows[Cnt].Cells[3].Value = Convert.ToDouble(MyDailyTicker.LastPrice.ToString()).ToString("###,###,##0.0#######  ♦");
                            }
                            catch
                            {
                                WhiteList_Grid.Rows[Cnt].Cells[3].Value = Convert.ToDouble(MyDailyTicker.LastPrice.ToString()).ToString("###,###,##0.0#######  ♦");
                            }

                            WhiteList_Grid.Rows[Cnt].Cells[4].Value = Convert.ToDouble(MyDailyTicker.PriceChangePercent).ToString("###,###,##0.0#") + "%";
                            if (Convert.ToDouble(MyDailyTicker.PriceChangePercent) <= 0)
                            {
                                WhiteList_Grid.Rows[Cnt].Cells[3].Style.ForeColor = Color.DarkRed;
                                WhiteList_Grid.Rows[Cnt].Cells[4].Style.ForeColor = Color.DarkRed;
                            }
                            else
                            {
                                WhiteList_Grid.Rows[Cnt].Cells[3].Style.ForeColor = Color.DarkGreen;
                                WhiteList_Grid.Rows[Cnt].Cells[4].Style.ForeColor = Color.DarkGreen;
                            }

                        }
                    }
                    Counter++;
                    if (Counter >= WhiteList_Grid.RowCount)
                    { WhiteList_Timer.Enabled = true; }
                }
                catch { WhiteList_Timer.Enabled = true; }
            }
        }

        //========================================================================================================================================================================================================================================================================


        private void CmdClose_Click(object sender, EventArgs e)
        {

        }


        //========================================================================================================================================================================================================================================================================

        private void BtnAddToken_Click(object sender, EventArgs e)
        {
            var TokenInfo = new Dictionary<string, string>();
            TokenInfo["TokenID"] = "0";
            TokenInfo["TokenName"] = "";
            TokenInfo["TokenSymbol"] = "";

            Forms.FrmToken MyFrmToken = new Forms.FrmToken();
            MyFrmToken.Set_Token(TokenInfo);
            MyFrmToken.ShowDialog();
        }


        //========================================================================================================================================================================================================================================================================

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> MyApiKey = new Dictionary<string, string>();

            if (TxtBinanceApiKey.Text.Trim() != "" && TxtBinanceSecretKey.Text.Trim() != "" && TxtCoinMarketCapApiKey.Text.Trim() != "" && TxtCryptoCompareApiKey.Text.Trim() != "" && TxtTaapi_io_ApiKey.Text.Trim() != "")
            {

                TxtBinanceApiKey.PasswordChar = '*';
                TxtBinanceSecretKey.PasswordChar = '*';
                TxtCoinMarketCapApiKey.PasswordChar = '*';
                TxtCryptoCompareApiKey.PasswordChar = '*';
                TxtTaapi_io_ApiKey.PasswordChar = '*';

                MyApiKey["BinanceApiKey"] = TxtBinanceApiKey.Text;
                MyApiKey["BinanceSecret"] = TxtBinanceSecretKey.Text;
                MyApiKey["CoinMarketCapApiKey"] = TxtCoinMarketCapApiKey.Text;
                MyApiKey["CryptoCompareApiKey"] = TxtCryptoCompareApiKey.Text;
                MyApiKey["Taapi_io_ApiKey"] = TxtTaapi_io_ApiKey.Text;


                MySQLite_ApiKey.Update(MyApiKey);

                MessageBox.Show("API settings updated" + Environment.NewLine + "Please restart this application to initialize the Api Key.", "API Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("Invalid null inputs." + Environment.NewLine + "Fill-up all the required fields.", "API Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //========================================================================================================================================================================================================================================================================

        private void CmdPriceAlert_Click(object sender, EventArgs e)
        {
            var TokenInfo = new Dictionary<string, string>();

            TokenInfo["Symbol"] = "";
            TokenInfo["TokenName"] = "";
            TokenInfo["TokenPrice"] = "0";
            TokenInfo["Whitelist_ID"] = "0";
            TokenInfo["PriceAlert_ID"] = "0";
            TokenInfo["TokenOperator"] = "0";

            Forms.FrmPriceNotify MyPriceAlert = new Forms.FrmPriceNotify();
            MyPriceAlert.Set_PriceAlert(TokenInfo);
            MyPriceAlert.ShowDialog();

        }


        //========================================================================================================================================================================================================================================================================

        private void CmfRefres_Click(object sender, EventArgs e)
        {
            Account_GetOpenOrder();
            Account_GetBalance();
        }


        //========================================================================================================================================================================================================================================================================

        private async void PriceAlert_Timer_Tick(object sender, EventArgs e)
        {
            PriceAlert_Timer.Enabled = false;
            PriceAlert_Timer.Interval = 1000 * 10;
            if (PriceAlert_Grid.RowCount >= 1)
            {
                int Counter = 0;
                try
                {
                    for (int Cnt = 0; Cnt < PriceAlert_Grid.RowCount; Cnt++)
                    {
                        if (PriceAlert_Grid.Rows[Cnt].Cells["OperatorSymbol"].Value.ToString().Trim() != "")
                        {
                            var MyDailyTicker = await MyBinancePriceTicker.GetCurrentPrice(PriceAlert_Grid.Rows[Cnt].Cells["TokenSymbolAlert"].Value.ToString().Trim() + "USDT");
                            Counter++;


                            PriceAlert_Grid.Rows[Cnt].Cells["CurrentPriceAlert"].Value = Convert.ToDouble(MyDailyTicker.LastPrice.ToString()).ToString();

                            if (PriceAlert_Grid.Rows[Cnt].Cells["OperatorSymbol"].Value.ToString().Trim() == "==")
                            {
                                if (Convert.ToDouble(PriceAlert_Grid.Rows[Cnt].Cells["TokenPriceAlert"].Value.ToString().Trim()) == Convert.ToDouble(MyDailyTicker.LastPrice.ToString()))
                                {

                                    Load_Notification(PriceAlert_Grid.Rows[Cnt].Cells["PriceAlertID"].Value.ToString().Trim(), "The Current Price of the '" + PriceAlert_Grid.Rows[Cnt].Cells["TokenNameAlert"].Value + "' is EQUAL to " + PriceAlert_Grid.Rows[Cnt].Cells["TokenPriceAlert"].Value.ToString().Trim(), MyDailyTicker.LastPrice.ToString());
                                }
                            }
                            else if (PriceAlert_Grid.Rows[Cnt].Cells["OperatorSymbol"].Value.ToString().Trim() == "<=")
                            {
                                if (Convert.ToDouble(PriceAlert_Grid.Rows[Cnt].Cells["TokenPriceAlert"].Value.ToString().Trim()) >= Convert.ToDouble(MyDailyTicker.LastPrice.ToString()))
                                {
                                    Load_Notification(PriceAlert_Grid.Rows[Cnt].Cells["PriceAlertID"].Value.ToString().Trim(), "The Current Price of the '" + PriceAlert_Grid.Rows[Cnt].Cells["TokenNameAlert"].Value + "' is LESS-THAN to " + PriceAlert_Grid.Rows[Cnt].Cells["TokenPriceAlert"].Value.ToString().Trim(), MyDailyTicker.LastPrice.ToString());
                                }
                            }
                            else if (PriceAlert_Grid.Rows[Cnt].Cells["OperatorSymbol"].Value.ToString().Trim() == ">=")
                            {
                                if (Convert.ToDouble(PriceAlert_Grid.Rows[Cnt].Cells["TokenPriceAlert"].Value.ToString().Trim()) <= Convert.ToDouble(MyDailyTicker.LastPrice.ToString()))
                                {
                                    Load_Notification(PriceAlert_Grid.Rows[Cnt].Cells["PriceAlertID"].Value.ToString().Trim(), "The Current Price of the '" + PriceAlert_Grid.Rows[Cnt].Cells["TokenNameAlert"].Value + "' is GREATER-THAN to " + PriceAlert_Grid.Rows[Cnt].Cells["TokenPriceAlert"].Value.ToString().Trim(), MyDailyTicker.LastPrice.ToString());
                                }
                            }

                        }
                    }
                    Counter++;
                    if (Counter >= PriceAlert_Grid.RowCount)
                    { PriceAlert_Timer.Enabled = true; }
                }
                catch { PriceAlert_Timer.Enabled = true; }
            }

     
        }

        //========================================================================================================================================================================================================================================================================
        private async void Load_Notification(string NotificationID, string MsgNotification, string Price)
        {
            await Task.Delay(0);

            Boolean MyFormRun = false;

            FormCollection MyForms = Application.OpenForms;
            foreach (Form Myfrm in MyForms)
            {
                if (Myfrm.Name == "FrmNotification")
                {
                    MyFormRun = true;
                }
            }


            if (MyFormRun == true)
            {

                (System.Windows.Forms.Application.OpenForms["FrmNotification"] as FrmNotification).ShowNotification(NotificationID, Price, MsgNotification);

            }
            else
            {
                FrmNotification MyFrmPriceNotify = new FrmNotification();
                MyFrmPriceNotify.ShowNotification(NotificationID, Price, MsgNotification);
                MyFrmPriceNotify.Show();
            }

        }
        //========================================================================================================================================================================================================================================================================

        private void CmdTransaction_Click(object sender, EventArgs e)
        {
            var TokenInfo = new Dictionary<string, string>();

            TokenInfo["TransactionID"] = "0";
            TokenInfo["Symbol"] = "";
            TokenInfo["TokenName"] = "";
            TokenInfo["BuyPrice"] = "0";
            TokenInfo["SellPrice"] = "0";
            TokenInfo["Capital"] = "0";
            TokenInfo["Fee"] = "0";
            TokenInfo["Status"] = "0";

            FrmTransaction MyFrmTransaction = new FrmTransaction();
            MyFrmTransaction.Set_Transaction(TokenInfo);
            MyFrmTransaction.ShowDialog();
        }


        //========================================================================================================================================================================================================================================================================

        private async void TradeOrder_Timer_Tick(object sender, EventArgs e)
        {
            TradeOrder_Timer.Enabled = false;

            TradeOrder_Timer.Interval = 1000 * 10;
            Double TotalCapital = 0;
            Double TotalProfit = 0;

            if (TradeOrder_Grid.RowCount >= 1)
            {
                int Counter = 0;
                try
                {
                    for (int Cnt = 0; Cnt < TradeOrder_Grid.RowCount; Cnt++)
                    {
                        if (TradeOrder_Grid.Rows[Cnt].Cells[9].Value.ToString().Trim() != "")
                        {
                            var MyDailyTicker = await MyBinancePriceTicker.GetCurrentPrice(TradeOrder_Grid.Rows[Cnt].Cells[9].Value.ToString().Trim() + "USDT");
                            Counter++;
                            try
                            {
                                if (Convert.ToDouble(TradeOrder_Grid.Rows[Cnt].Cells[2].Value.ToString().Split(' ')[0]) >= Convert.ToDouble(MyDailyTicker.LastPrice.ToString()))
                                {
                                    TradeOrder_Grid.Rows[Cnt].Cells[2].Value = Convert.ToDouble(MyDailyTicker.LastPrice.ToString()).ToString("###,###,##0.0#######  ▼");
                                    TradeOrder_Grid.Rows[Cnt].Cells[2].Style.ForeColor = Color.DarkRed;
                                }
                                else
                                {
                                    TradeOrder_Grid.Rows[Cnt].Cells[2].Value = Convert.ToDouble(MyDailyTicker.LastPrice.ToString()).ToString("###,###,##0.0#######  ▲");
                                    TradeOrder_Grid.Rows[Cnt].Cells[2].Style.ForeColor = Color.DarkGreen;
                                }
                            }
                            catch { TradeOrder_Grid.Rows[Cnt].Cells[2].Value = Convert.ToDouble(MyDailyTicker.LastPrice.ToString()).ToString("###,###,##0.0#######  ♦"); }

                            TradeOrder_Grid.Rows[Cnt].Cells[8].Value = (BRL_Value * Convert.ToDouble(TradeOrder_Grid.Rows[Cnt].Cells[7].Value)).ToString("###,###,##0.00");

                            TotalCapital = TotalCapital + Convert.ToDouble(TradeOrder_Grid.Rows[Cnt].Cells[3].Value.ToString());
                            TotalProfit = TotalProfit + Convert.ToDouble(TradeOrder_Grid.Rows[Cnt].Cells[7].Value.ToString());
                        }
                    }

                    TxtCapital.Text = TotalCapital.ToString("###,###,##0.00") + "   (" + (TotalCapital * BRL_Value).ToString("###,###,##0.00") + " BRL)";
                    TxtProfit.Text = TotalProfit.ToString("###,###,##0.00") + "   (" + (TotalProfit * BRL_Value).ToString("###,###,##0.00") + " BRL)";

                    Counter++;
                    if (Counter >= TradeOrder_Grid.RowCount)
                    { TradeOrder_Timer.Enabled = true; }
                }
                catch { TradeOrder_Timer.Enabled = true; }
            }
        }

        private void cbShowKeys_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbShowKeys.Checked)
            {

                TxtBinanceApiKey.PasswordChar = '*';
                TxtBinanceSecretKey.PasswordChar = '*';
                TxtCoinMarketCapApiKey.PasswordChar = '*';
                TxtCryptoCompareApiKey.PasswordChar = '*';
                TxtTaapi_io_ApiKey.PasswordChar = '*';
            }
            else
            {
                TxtBinanceApiKey.PasswordChar = '\0';
                TxtBinanceSecretKey.PasswordChar = '\0';
                TxtCoinMarketCapApiKey.PasswordChar = '\0';
                TxtCryptoCompareApiKey.PasswordChar = '\0';
                TxtTaapi_io_ApiKey.PasswordChar = '\0';

            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            PriceTicker_Timer.Enabled = false;
            Volume_Timer.Enabled = false;
            StochRSI_Timer.Enabled = false;
            CCI_Timer.Enabled = false;
            IMI_Timer.Enabled = false;
            UltOsc_Timer.Enabled = false;
            PPO_Timer.Enabled = false;
            ChandeOsc_Timer.Enabled = false;
            Fibonnci_Timer.Enabled = false;
            BB_Timer.Enabled = false;
            TechAnalysis_Timer.Enabled = false;
            Counter_Timer.Enabled = false;

            //this.Close();
            //Application.Exit();
        }

        private void TabMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(e.TabPage != TabMainPageSettings && TxtBinanceApiKey.Text == "")
            {
                TabMain.SelectTab(TabMainPageSettings);
            }
        }

        private void WhiteList_Grid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = WhiteList_Grid.HitTest(e.X, e.Y);

                if (hti.RowIndex != -1)
                {
                    WhiteList_Grid.ClearSelection();
                    WhiteList_Grid.Rows[hti.RowIndex].Selected = true;
                }

                cmsWatchList.Show(WhiteList_Grid, new Point(e.X, e.Y));
            }
        }

        private void btnRemoveTokenWatchList_Click(object sender, EventArgs e)
        {
            if(WhiteList_Grid.SelectedRows.Count == 1)
            {
                if (MessageBox.Show(this, "Are you sure, You want to remove the selected token/crypto?", "Remove Token/Crypto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SQLite_Whitelist MySQLite_WhiteList = new SQLite_Whitelist();
                    string tokenID = WhiteList_Grid.SelectedRows[0].Cells["TokenIDCol"].Value.ToString();
                    MySQLite_WhiteList.Remove(tokenID);
                    WhiteList_Grid.Rows.RemoveAt(WhiteList_Grid.SelectedRows[0].Index);
                }
            }
        }

        private void btnAddTokenWatchList_Click(object sender, EventArgs e)
        {
            var TokenInfo = new Dictionary<string, string>();
            TokenInfo["TokenID"] = "0";
            TokenInfo["TokenName"] = "";
            TokenInfo["TokenSymbol"] = "";

            Forms.FrmToken MyFrmToken = new Forms.FrmToken();
            MyFrmToken.Set_Token(TokenInfo);
            MyFrmToken.ShowDialog();
        }

        private void btnUpdateTokenWatchList_Click(object sender, EventArgs e)
        {
            if (WhiteList_Grid.SelectedRows.Count == 1)
            {
                var TokenInfo = new Dictionary<string, string>();
                TokenInfo["TokenID"] = WhiteList_Grid.SelectedRows[0].Cells["TokenIDCol"].Value.ToString();
                TokenInfo["TokenName"] = WhiteList_Grid.SelectedRows[0].Cells["TokenNameCol"].Value.ToString();
                TokenInfo["TokenSymbol"] = WhiteList_Grid.SelectedRows[0].Cells["TokenSymbolCol"].Value.ToString();

                Forms.FrmToken MyFrmToken = new Forms.FrmToken();
                MyFrmToken.Set_Token(TokenInfo);
                MyFrmToken.ShowDialog();
            }
        }

        private void btnAddTokenPriceAlert_Click(object sender, EventArgs e)
        {
            var TokenInfo = new Dictionary<string, string>();

            TokenInfo["Symbol"] = "";
            TokenInfo["TokenName"] = "";
            TokenInfo["TokenPrice"] = "0";
            TokenInfo["Whitelist_ID"] = "0";
            TokenInfo["PriceAlert_ID"] = "0";
            TokenInfo["TokenOperator"] = "0";

            Forms.FrmPriceNotify MyPriceAlert = new Forms.FrmPriceNotify();
            MyPriceAlert.Set_PriceAlert(TokenInfo);
            MyPriceAlert.ShowDialog();
        }

        private void btnUpdateTokenPriceAlert_Click(object sender, EventArgs e)
        {
            if (PriceAlert_Grid.SelectedRows.Count == 1)
            {
              

                var TokenInfo = new Dictionary<string, string>();

                TokenInfo["Symbol"] = PriceAlert_Grid.SelectedRows[0].Cells["TokenSymbolAlert"].Value.ToString();
                TokenInfo["TokenName"] = PriceAlert_Grid.SelectedRows[0].Cells["TokenNameAlert"].Value.ToString();
                TokenInfo["TokenPrice"] = PriceAlert_Grid.SelectedRows[0].Cells["TokenPriceAlert"].Value.ToString();
                TokenInfo["Whitelist_ID"] = PriceAlert_Grid.SelectedRows[0].Cells["WhitelistID"].Value.ToString();
                TokenInfo["PriceAlert_ID"] = PriceAlert_Grid.SelectedRows[0].Cells["PriceAlertID"].Value.ToString();


                TokenInfo["TokenOperator"] = PriceAlert_Grid.SelectedRows[0].Cells["TokenOperatorAlert"].Value.ToString().Trim();

                Forms.FrmPriceNotify MyPriceAlert = new Forms.FrmPriceNotify();
                MyPriceAlert.Set_PriceAlert(TokenInfo);
                MyPriceAlert.ShowDialog();
            }
        }

        private void btnRemoveTokenPriceAlert_Click(object sender, EventArgs e)
        {
            if (PriceAlert_Grid.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Are you sure, You want to remove the selected Price Alert?", "Remove Price Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SQLite_PriceAlert MySQLite_PriceAlert = new SQLite_PriceAlert();
                    string priceAlertId = PriceAlert_Grid.SelectedRows[0].Cells["PriceAlertID"].Value.ToString();
                    MySQLite_PriceAlert.Remove(priceAlertId);
                    PriceAlert_Grid.Rows.RemoveAt(PriceAlert_Grid.SelectedRows[0].Index);
                }
            }
           
        }

        private void PriceAlert_Grid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = PriceAlert_Grid.HitTest(e.X, e.Y);

                if (hti.RowIndex != -1)
                {
                    PriceAlert_Grid.ClearSelection();
                    PriceAlert_Grid.Rows[hti.RowIndex].Selected = true;
                }

                cmsPriceAlert.Show(PriceAlert_Grid, new Point(e.X, e.Y));
            }
        }

        private void TradeOrder_Grid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = TradeOrder_Grid.HitTest(e.X, e.Y);

                if (hti.RowIndex != -1)
                {
                    TradeOrder_Grid.ClearSelection();
                    TradeOrder_Grid.Rows[hti.RowIndex].Selected = true;
                }

                cmsTransaction.Show(TradeOrder_Grid, new Point(e.X, e.Y));
            }
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            var TokenInfo = new Dictionary<string, string>();

            TokenInfo["TransactionID"] = "0";
            TokenInfo["Symbol"] = "";
            TokenInfo["TokenName"] = "";
            TokenInfo["BuyPrice"] = "0";
            TokenInfo["SellPrice"] = "0";
            TokenInfo["Capital"] = "0";
            TokenInfo["Fee"] = "0";
            TokenInfo["Status"] = "0";

            FrmTransaction MyFrmTransaction = new FrmTransaction();
            MyFrmTransaction.Set_Transaction(TokenInfo);
            MyFrmTransaction.ShowDialog();
        }

        private void btnUpdateTransaction_Click(object sender, EventArgs e)
        {
            if (TradeOrder_Grid.SelectedRows.Count == 1)
            {
                var TokenInfo = new Dictionary<string, string>();

                TokenInfo["TransactionID"] = TradeOrder_Grid.SelectedRows[0].Cells["Transaction_ID"].Value.ToString();
                TokenInfo["Symbol"] = TradeOrder_Grid.SelectedRows[0].Cells["TokenSymbolTrade"].Value.ToString();
                TokenInfo["TokenName"] = TradeOrder_Grid.SelectedRows[0].Cells["TokenNameTransaction"].Value.ToString();
                TokenInfo["BuyPrice"] = TradeOrder_Grid.SelectedRows[0].Cells["BuyPriceTransaction"].Value.ToString();
                TokenInfo["SellPrice"] = TradeOrder_Grid.SelectedRows[0].Cells["SellPriceTransaction"].Value.ToString();
                TokenInfo["Capital"] = TradeOrder_Grid.SelectedRows[0].Cells["CapitalUSDT"].Value.ToString();
                TokenInfo["Fee"] = TradeOrder_Grid.SelectedRows[0].Cells["TransactionFee"].Value.ToString();
                TokenInfo["Status"] = TradeOrder_Grid.SelectedRows[0].Cells["TransactionStatus"].Value.ToString();

                FrmTransaction MyFrmTransaction = new FrmTransaction();
                MyFrmTransaction.Set_Transaction(TokenInfo);
                MyFrmTransaction.ShowDialog();
            }

        }

        private void btnRemoveTransaction_Click(object sender, EventArgs e)
        {
            if (TradeOrder_Grid.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Are you sure, You want to remove the selected Transaction?", "Remove Current Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SQLite_Transaction MySQLite_Transaction = new SQLite_Transaction();
                    string txId = TradeOrder_Grid.SelectedRows[0].Cells["Transaction_ID"].Value.ToString();
                    MySQLite_Transaction.Remove(txId);
                    TradeOrder_Grid.Rows.RemoveAt(TradeOrder_Grid.SelectedRows[0].Index);
                }
            }
        }

        private void linkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MateusGrijo");
        }


        //========================================================================================================================================================================================================================================================================
        //========================================================================================================================================================================================================================================================================

    }
}
