using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptoTrader.Classes;
using Newtonsoft.Json;

namespace CryptoTrader.Forms
{
    public partial class FrmPriceNotify : Form
    {
        BinancePriceTicker MyBinancePriceTicker;

        SQLite_ApiKey MySQLite_ApiKey = new SQLite_ApiKey();
        SQLite_Whitelist MySQLite_Whitelist = new SQLite_Whitelist();

        SQLite_PriceAlert MySQLite_PriceAlert = new SQLite_PriceAlert();
        Dictionary<string, string> MyTokenPriceAlert = new Dictionary<string, string>();

        dynamic MyWhiteList;

        public FrmPriceNotify()
        {
            InitializeComponent();
            FormInterface.DisableCloseButton(this, true);
        }
        //=========================================================================================================================================================

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //=========================================================================================================================================================

        public void Load_WhiteList()
        {
            MyWhiteList = JsonConvert.DeserializeObject(MySQLite_Whitelist.Load().Result);
            CmbToken.Items.Clear();

            for (int Cnt = 0; Cnt < MyWhiteList.Count; Cnt++)
            {
                CmbToken.Items.Add((string)MyWhiteList[Cnt].Name);
                CmbToken.SelectedIndex = 0;
            }
            CmbToken.SelectedIndex = 0;
        }

        //=========================================================================================================================================================
        public void Set_PriceAlert(Dictionary<string, string> TokenInfo)
        {
            Load_WhiteList();

            MyTokenPriceAlert["Whitelist_ID"] = TokenInfo["Whitelist_ID"];
            MyTokenPriceAlert["PriceAlert_ID"] = TokenInfo["PriceAlert_ID"];
            MyTokenPriceAlert["Symbol"] = TokenInfo["Symbol"];
            MyTokenPriceAlert["TokenName"] = TokenInfo["TokenName"];
            MyTokenPriceAlert["TokenOperator"] = TokenInfo["TokenOperator"];
            MyTokenPriceAlert["TokenPrice"] = TokenInfo["TokenPrice"];

            CmbToken.Text = TokenInfo["TokenName"];

            CmbOperator.SelectedIndex = int.Parse(TokenInfo["TokenOperator"]);
         

            TxtTokenPrice.Text = TokenInfo["TokenPrice"];

            CmbToken.Focus();
        }

        //=========================================================================================================================================================

        private void CmdSave_Click(object sender, EventArgs e)
        {
          
            MyTimer.Enabled = true;
            Dictionary<string, string> TokenInfo = new Dictionary<string, string>();

            TokenInfo["PriceAlert_ID"] = MyTokenPriceAlert["PriceAlert_ID"];
            TokenInfo["TokenID"] = (string)MyWhiteList[CmbToken.SelectedIndex].WhiteList_ID;
            TokenInfo["Operator"] = CmbOperator.SelectedIndex.ToString();
            TokenInfo["Price"] = TxtTokenPrice.Text.ToString().Replace(",", "");
            MySQLite_PriceAlert.Update(TokenInfo);
        }


        //=========================================================================================================================================================


        //=========================================================================================================================================================

        private async void MyTimer_Tick(object sender, EventArgs e)
        {
            await Task.Delay(0);
            if (PBar.Value != 50)
            { PBar.Value += 1; }
            else
            {
                DataGridLoader MyDataGridLoader = new DataGridLoader();

                PBar.Value = 0;
                MyTimer.Enabled = false;

                MyDataGridLoader.Load_PriceAlert(Application.OpenForms.OfType<FrmMain>().Single().PriceAlert_Grid);

                this.Close();
            }
        }

        //=========================================================================================================================================================

        private void FrmPriceAlert_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> MyApiKey = MySQLite_ApiKey.Load().Result;

            MyBinancePriceTicker = new BinancePriceTicker(MyApiKey["BinanceApiKey"], MyApiKey["BinanceSecret"]);
            Init_Timer.Enabled = true;


        }
        //=========================================================================================================================================================

        private async void CmbToken_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string TokenSymbol = (string)MyWhiteList[CmbToken.SelectedIndex].Symbol + "USDT";
                var MyDailyTicker = await MyBinancePriceTicker.GetCurrentPrice(TokenSymbol);

                try
                {
                    TxtTokenPrice.Text = Convert.ToDouble(MyDailyTicker.LastPrice.ToString()).ToString("###,###,##0.0#######");

                    if (MyTokenPriceAlert["TokenName"] == CmbToken.Text)
                    {
                        if (MyTokenPriceAlert["TokenPrice"] != "0")
                        {
                            TxtTokenPrice.Text = MyTokenPriceAlert["TokenPrice"];
                        }
                    }


                    TxtTokenPrice.Focus();
                }
                catch {; }
            }
            catch {; }


        }



        //=========================================================================================================================================================

        private void Init_Timer_Tick(object sender, EventArgs e)
        {
            Init_Timer.Enabled = false;
            CmbToken_SelectedIndexChanged(null, null);
        }

        private void PBar_Click(object sender, EventArgs e)
        {

        }

        //=========================================================================================================================================================

    }
}
