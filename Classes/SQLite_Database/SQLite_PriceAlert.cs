using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;


namespace CryptoTrader.Classes
{
    class SQLite_PriceAlert
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



            if (TokenInfo["PriceAlert_ID"] != "0")
            {
                SQLQuery = "INSERT OR IGNORE INTO PriceAlert(PriceAlert_ID, WhiteList_ID, Operator, Price)";
                SQLQuery += " values(" + TokenInfo["PriceAlert_ID"] + ", " + TokenInfo["TokenID"] + ", " + TokenInfo["Operator"] + ", " + TokenInfo["Price"] + ");";
            }
            else
            {
                SQLQuery = "INSERT OR IGNORE INTO PriceAlert(WhiteList_ID, Operator, Price)";
                SQLQuery += " values(" + TokenInfo["TokenID"] + ", " + TokenInfo["Operator"] + ", " + TokenInfo["Price"] + ");";
            }

            SQLQuery += "  UPDATE PriceAlert set WhiteList_ID =" + TokenInfo["TokenID"] + ", Operator=" + TokenInfo["Operator"] + ",  Price = " + TokenInfo["Price"] + " where PriceAlert_ID=" + TokenInfo["PriceAlert_ID"] + ";";
    
            SQLiteCmd.CommandText = SQLQuery;
            SQLiteCmd.ExecuteNonQuery();
            SQLiteCmd.Dispose();

            SQLConnect.Close();

        }
   //================================================================================================================================================================
        public async void Remove(string TokenID)
        {
            await Task.Delay(0);
            SQLiteConnection SQLConnect = ConnectDatabase();


            SQLiteCommand SQLiteCmd = new SQLiteCommand();
            SQLiteCmd = SQLConnect.CreateCommand();

            String SQLQuery = "Delete from PriceAlert where PriceAlert_ID =" + TokenID + ";";
            SQLiteCmd.CommandText = SQLQuery;

            SQLiteCmd.ExecuteNonQuery();
            SQLiteCmd.Dispose();
            SQLConnect.Close();

        }


        //================================================================================================================================================================
        //================================================================================================================================================================

        public async Task<string> Load()
        {
            await Task.Delay(0);
            SQLiteConnection SQLConnect = ConnectDatabase();
            string SQLString = "SELECT PriceAlert.WhiteList_ID, Whitelist.Token_Symbol, Whitelist.Token_Name, PriceAlert.PriceAlert_ID, PriceAlert.Operator, ";
                   SQLString += " PriceAlert.Price FROM PriceAlert INNER JOIN Whitelist ON PriceAlert.WhiteList_ID = Whitelist.WhiteList_ID ORDER BY Whitelist.Token_Name ASC;";
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
                    MyToken += "{\"Whitelist_ID\" : \"" + SQLDataReader.GetInt32(SQLDataReader.GetOrdinal("WhiteList_ID")).ToString() + "\", ";
                    MyToken += "\"Symbol\" : \"" + SQLDataReader.GetString(SQLDataReader.GetOrdinal("Token_Symbol")).ToString() + "\", ";
                    MyToken += "\"Token_Name\" : \"" + SQLDataReader.GetString(SQLDataReader.GetOrdinal("Token_Name")).ToString() + "\", ";
                    MyToken += "\"PriceAlert_ID\" : \"" + SQLDataReader.GetInt32(SQLDataReader.GetOrdinal("PriceAlert_ID")).ToString() + "\", ";
                    MyToken += "\"Operator\" : \"" + SQLDataReader.GetInt32(SQLDataReader.GetOrdinal("Operator")).ToString() + "\", ";
                    MyToken += "\"Price\" : \"" + SQLDataReader.GetDouble(SQLDataReader.GetOrdinal("Price")).ToString() + "\"}, ";

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
