using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoTrader.Classes;
using Newtonsoft.Json;
using System.Drawing;

namespace CryptoTrader.Classes
{
    class DataGridLoader
    {

        SQLite_PriceAlert MySQLite_PriceAlert = new SQLite_PriceAlert();

        SQLite_Transaction MySQLite_Transaction = new SQLite_Transaction();

//==============================================================================================================================================================================================================================================================
        public async void Load_PriceAlert(System.Windows.Forms.DataGridView MyDataGrid)
        {
            await Task.Delay(0);
           dynamic MyPriceAlert = JsonConvert.DeserializeObject(MySQLite_PriceAlert.Load().Result);
           
            MyDataGrid.Rows.Clear();
            MyDataGrid.RowCount = MyPriceAlert.Count;

            for (int Cnt = 0; Cnt < MyPriceAlert.Count; Cnt++)
            {
                string MyOperator="== ";
                
                if ((string)MyPriceAlert[Cnt].Operator == "0")
                   { MyOperator= " == "; }
                else if ((string)MyPriceAlert[Cnt].Operator == "1")
                   { MyOperator = " >= "; }
                else if ((string)MyPriceAlert[Cnt].Operator == "2")
                   { MyOperator = " <= "; }

            

                MyDataGrid.Rows[Cnt].Cells["NoIndexAlert"].Value = (Cnt + 1).ToString();
                MyDataGrid.Rows[Cnt].Cells["TokenNameAlert"].Value = (string)MyPriceAlert[Cnt].Token_Name;
                MyDataGrid.Rows[Cnt].Cells["OperatorSymbol"].Value = MyOperator;
                MyDataGrid.Rows[Cnt].Cells["TokenPriceAlert"].Value = (string)MyPriceAlert[Cnt].Price;
                MyDataGrid.Rows[Cnt].Cells["WhitelistID"].Value = (string)MyPriceAlert[Cnt].Whitelist_ID;
                MyDataGrid.Rows[Cnt].Cells["PriceAlertID"].Value = (string)MyPriceAlert[Cnt].PriceAlert_ID;
                MyDataGrid.Rows[Cnt].Cells["TokenOperatorAlert"].Value = (string)MyPriceAlert[Cnt].Operator;
                MyDataGrid.Rows[Cnt].Cells["TokenSymbolAlert"].Value = (string)MyPriceAlert[Cnt].Symbol;
            }
           

        }
        //==============================================================================================================================================================================================================================================================

        public async void Load_TradeOrder(System.Windows.Forms.DataGridView MyDataGrid)
        {
            await Task.Delay(0);
            dynamic MyTradeOrder = JsonConvert.DeserializeObject(MySQLite_Transaction.Load().Result);

            MyDataGrid.Rows.Clear();
            MyDataGrid.RowCount = MyTradeOrder.Count;

            Color MyForeColor = new Color();

            for (int Cnt = 0; Cnt < MyTradeOrder.Count; Cnt++)
            {
                
                MyDataGrid.Rows[Cnt].Cells[0].Value = (Cnt + 1).ToString();
                MyDataGrid.Rows[Cnt].Cells[1].Value = (string)MyTradeOrder[Cnt].Token_Name;
                MyDataGrid.Rows[Cnt].Cells[2].Value = "";  
                MyDataGrid.Rows[Cnt].Cells[3].Value = Convert.ToDouble((string)MyTradeOrder[Cnt].Capital).ToString("###,###,##0.###");
                MyDataGrid.Rows[Cnt].Cells[4].Value = Convert.ToDouble((string)MyTradeOrder[Cnt].BuyPrice).ToString("###,###,##0.0#######");
                MyDataGrid.Rows[Cnt].Cells[5].Value = Convert.ToDouble((string)MyTradeOrder[Cnt].SellPrice).ToString("###,###,##0.0#######");

                Double BuyFee =  (Convert.ToDouble((string)MyTradeOrder[Cnt].TransactionFee)/100)  *  Convert.ToDouble((string)MyTradeOrder[Cnt].Capital) ;
                Double BuyCrypto = (Convert.ToDouble((string)MyTradeOrder[Cnt].Capital) - BuyFee) / Convert.ToDouble((string)MyTradeOrder[Cnt].BuyPrice);

                Double SellCrypto = BuyCrypto * Convert.ToDouble((string)MyTradeOrder[Cnt].SellPrice);
                Double SellFee =   (Convert.ToDouble((string)MyTradeOrder[Cnt].TransactionFee)/ 100) * SellCrypto;
                Double Gross = SellCrypto - SellFee;

                Double Profit = Gross - Convert.ToDouble((string)MyTradeOrder[Cnt].Capital);

                MyDataGrid.Rows[Cnt].Cells[6].Value = Gross.ToString("###,###,##0.00");
                MyDataGrid.Rows[Cnt].Cells[7].Value = Profit.ToString("###,###,##0.00");

                MyDataGrid.Rows[Cnt].Cells[9].Value = (string)MyTradeOrder[Cnt].Symbol;
                MyDataGrid.Rows[Cnt].Cells[10].Value = (string)MyTradeOrder[Cnt].Whitelist_ID;
                MyDataGrid.Rows[Cnt].Cells[11].Value = (string)MyTradeOrder[Cnt].Transaction_ID;
                MyDataGrid.Rows[Cnt].Cells[12].Value = (string)MyTradeOrder[Cnt].TransactionFee;
                MyDataGrid.Rows[Cnt].Cells[13].Value = (string)MyTradeOrder[Cnt].Status;

                if (((string)MyTradeOrder[Cnt].Status).ToUpper() =="BUY")
                  { MyForeColor = Color.DarkGreen; }
                else
                  { MyForeColor = Color.DarkRed; }

                for(int Cols=0; Cols< MyDataGrid.ColumnCount; Cols++ )
                {
                    MyDataGrid.Rows[Cnt].Cells[Cols].Style.ForeColor = MyForeColor;
                 }
                 
            }

        }
        //==============================================================================================================================================================================================================================================================

    }
}
