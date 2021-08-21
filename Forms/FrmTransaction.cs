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

namespace CryptoTrader
{
    public partial class FrmTransaction : Form
    {

        SQLite_ApiKey MySQLite_ApiKey = new SQLite_ApiKey();
        SQLite_Whitelist MySQLite_Whitelist = new SQLite_Whitelist();
        SQLite_Transaction MySQLite_Transaction = new SQLite_Transaction();

        dynamic MyWhiteList;

        public FrmTransaction()
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

        private void FrmTransaction_Load(object sender, EventArgs e)
        {

        }
//=========================================================================================================================================================

        private void CmdSave_Click(object sender, EventArgs e)
        {
           
            MyTimer.Enabled = true;
            Dictionary<string, string> TokenInfo = new Dictionary<string, string>();

            TokenInfo["Transaction_ID"] = TxtTransactionID.Text.Trim();
            TokenInfo["TokenID"] = (string)MyWhiteList[CmbToken.SelectedIndex].WhiteList_ID;
            TokenInfo["Capital"] = TxtCapital.Text.ToString().Replace(",", "").Trim();
            TokenInfo["BuyPrice"] = TxtBuyPrice.Text.ToString().Replace(",", "").Trim();
            TokenInfo["SellPrice"] = TxtSellPrice.Text.ToString().Replace(",", "").Trim();
            TokenInfo["TransactionFee"] = TxtTransactionFee.Text.ToString().Replace(",", "").Trim();

            //TokenInfo["Capital"] = TxtCapital.Text.ToString().Trim();
            //TokenInfo["BuyPrice"] = TxtBuyPrice.Text.ToString().Trim();
            //TokenInfo["SellPrice"] = TxtSellPrice.Text.ToString().Trim();
            //TokenInfo["TransactionFee"] = TxtTransactionFee.Text.ToString().Trim();

            TokenInfo["Status"] = CmbStatus.Text;

            MySQLite_Transaction.Update(TokenInfo);

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

//=============================================================================================================================================================================================================================================================
        public void Set_Transaction(Dictionary<string, string> TokenInfo)
        {
            Load_WhiteList();

            TxtTransactionID.Text = TokenInfo["TransactionID"];
            CmbToken.Text = TokenInfo["TokenName"];

            TxtCapital.Text = TokenInfo["Capital"].Replace(",", "");
            TxtBuyPrice.Text = TokenInfo["BuyPrice"].Replace(",", "");
            TxtSellPrice.Text = TokenInfo["SellPrice"].Replace(",", "");

            //TxtCapital.Text = TokenInfo["Capital"];
            //TxtBuyPrice.Text = TokenInfo["BuyPrice"];
            //TxtSellPrice.Text = TokenInfo["SellPrice"];

            CmbStatus.Text = TokenInfo["Status"];
            //TokenInfo["Symbol"] 
        }


 //=============================================================================================================================================================================================================================================================

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

                MyDataGridLoader.Load_TradeOrder(Application.OpenForms.OfType<FrmMain>().Single().TradeOrder_Grid);

                this.Close();
            }
        }

//=============================================================================================================================================================================================================================================================

        private void CmdRemove_Click(object sender, EventArgs e)
        {
           
        }

//=============================================================================================================================================================================================================================================================

    }
}
