using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;


namespace CryptoTrader.Classes
{
    class SQLite_Transaction
    {
        SQLiteConnection SQLConnect = new SQLiteConnection();

        private SQLiteConnection ConnectDatabase()
        {
            string DIR = System.Windows.Forms.Application.StartupPath;
            string DataLocation = "Data Source=" + DIR + "\\DB\\CryptoTraderDB.dat; Pooling=true;";
            SQLConnect.ConnectionString = DataLocation;

            if (SQLConnect.State == ConnectionState.Open)
            { SQLConnect.Close(); }

            SQLConnect.Open();
            return SQLConnect;
        }
        //================================================================================================================================================================
        

        public async void Update(Dictionary<string, string> TokenInfo)
        {
            await Task.Delay(0);
            SQLiteConnection SQLConnect = ConnectDatabase();

            SQLiteCommand SQLiteCmd = new SQLiteCommand();
            SQLiteCmd = SQLConnect.CreateCommand();

            String SQLQuery = "";



            if (TokenInfo["Transaction_ID"] != "0")
            {
                SQLQuery = "INSERT OR IGNORE INTO TradeOrder(Transaction_ID, WhiteList_ID, Capital, BuyPrice, SellPrice, TransactionFee, Status)";
                SQLQuery += " values(" + TokenInfo["Transaction_ID"] + ", " + TokenInfo["TokenID"] + ", " + TokenInfo["Capital"] + ", " + TokenInfo["BuyPrice"] + ", " + TokenInfo["SellPrice"] + ", " + TokenInfo["TransactionFee"] + ", '" + TokenInfo["Status"] + "'); ";
            }
            else
            {
                SQLQuery = "INSERT OR IGNORE INTO TradeOrder(WhiteList_ID, Capital, BuyPrice, SellPrice, TransactionFee, Status)";
                SQLQuery += " values(" + TokenInfo["TokenID"] + ", " + TokenInfo["Capital"] + ", " + TokenInfo["BuyPrice"] + ", " + TokenInfo["SellPrice"] + ", " + TokenInfo["TransactionFee"] + ", '" + TokenInfo["Status"] + "'); ";
            }

            SQLQuery += "  UPDATE TradeOrder set WhiteList_ID =" + TokenInfo["TokenID"] + ", Capital=" + TokenInfo["Capital"] + ",  BuyPrice = " + TokenInfo["BuyPrice"] + ",  SellPrice = " + TokenInfo["SellPrice"] + ",  TransactionFee = " + TokenInfo["TransactionFee"] + ",  Status = '" + TokenInfo["Status"] + "' where Transaction_ID=" + TokenInfo["Transaction_ID"] + ";";

            SQLiteCmd.CommandText = SQLQuery;
            SQLiteCmd.ExecuteNonQuery();
            SQLiteCmd.Dispose();

            SQLConnect.Close();

        }
        //================================================================================================================================================================
        public async void Remove(string TransactionID)
        {
            await Task.Delay(0);
            SQLiteConnection SQLConnect = ConnectDatabase();


            SQLiteCommand SQLiteCmd = new SQLiteCommand();
            SQLiteCmd = SQLConnect.CreateCommand();

            String SQLQuery = "Delete from TradeOrder where Transaction_ID =" + TransactionID + ";";
            SQLiteCmd.CommandText = SQLQuery;

            SQLiteCmd.ExecuteNonQuery();
            SQLiteCmd.Dispose();
            SQLConnect.Close();

        }


        //================================================================================================================================================================
        
        public async Task<string> Load()
        {
            await Task.Delay(0);
            SQLiteConnection SQLConnect = ConnectDatabase();
            string SQLString = "SELECT TradeOrder.Transaction_ID, Whitelist.WhiteList_ID, Whitelist.Token_Name, Whitelist.Token_Symbol, TradeOrder.Capital, ";
            SQLString += " TradeOrder.BuyPrice, TradeOrder.SellPrice, TradeOrder.TransactionFee, TradeOrder.Status FROM TradeOrder INNER JOIN Whitelist ON TradeOrder.WhiteList_ID = Whitelist.WhiteList_ID ";
            SQLString += " ORDER BY Whitelist.Token_Name ASC;";
            SQLiteCommand SQLiteCmd = new SQLiteCommand(SQLString, SQLConnect);
            SQLiteDataAdapter SQLDataAdapter = new SQLiteDataAdapter();
            DataTable SqlDataTable = new DataTable();
            SQLDataAdapter.SelectCommand = SQLiteCmd;
            SQLDataAdapter.Fill(SqlDataTable);
            SQLiteDataReader SQLDataReader = SQLiteCmd.ExecuteReader();

            string MyToken = "[";
            if (SqlDataTable.Rows.Count > 0)
            {
                while (SQLDataReader.Read())
                {
                    MyToken += "{\"Transaction_ID\" : \"" + SQLDataReader.GetInt32(SQLDataReader.GetOrdinal("Transaction_ID")).ToString() + "\", ";
                    MyToken += "\"Whitelist_ID\" : \"" + SQLDataReader.GetInt32(SQLDataReader.GetOrdinal("WhiteList_ID")).ToString() + "\", ";
                    MyToken += "\"Symbol\" : \"" + SQLDataReader.GetString(SQLDataReader.GetOrdinal("Token_Symbol")).ToString() + "\", ";
                    MyToken += "\"Token_Name\" : \"" + SQLDataReader.GetString(SQLDataReader.GetOrdinal("Token_Name")).ToString() + "\", ";
                    MyToken += "\"Capital\" : \"" + SQLDataReader.GetDouble(SQLDataReader.GetOrdinal("Capital")).ToString() + "\", ";
                    MyToken += "\"BuyPrice\" : \"" + SQLDataReader.GetDouble(SQLDataReader.GetOrdinal("BuyPrice")).ToString() + "\", ";
                    MyToken += "\"SellPrice\" : \"" + SQLDataReader.GetDouble(SQLDataReader.GetOrdinal("SellPrice")).ToString() + "\", ";
                    MyToken += "\"TransactionFee\" : \"" + SQLDataReader.GetDouble(SQLDataReader.GetOrdinal("TransactionFee")).ToString() + "\", ";
                    MyToken += "\"Status\" : \"" + SQLDataReader.GetString(SQLDataReader.GetOrdinal("Status")).ToString() + "\"}, ";

                }

            }

            if (MyToken.Length >= 5)
            { MyToken = MyToken.Trim().Substring(0, MyToken.Length - 2); }

            SQLConnect.Close();

            return MyToken + "]";

        }

        //================================================================================================================================================================
         

    }
}
