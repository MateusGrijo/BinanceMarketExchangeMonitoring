using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace CryptoTrader.Classes
{
    class SQLite_ApiKey
    {


        //================================================================================================================================================================
        //================================================================================================================================================================


        SQLiteConnection SQLConnect = new SQLiteConnection();

        private SQLiteConnection ConnectDatabase()
        {
            string DIR = System.Windows.Forms.Application.StartupPath;
            string DataLocation = "Data Source=" + DIR + "\\DB\\CryptoTraderDB.dat;  Pooling=true;";
            SQLConnect.ConnectionString = DataLocation;
            if (SQLConnect.State == ConnectionState.Open)
            { SQLConnect.Close(); }
            SQLConnect.Open();
            return SQLConnect;
        }

        //================================================================================================================================================================
         

        public async void Update(Dictionary<string, string> MyApiKey)
        {
            await Task.Delay(0);
            SQLiteConnection SQLConnect = ConnectDatabase();

            SQLiteCommand SQLiteCmd = new SQLiteCommand();
            SQLiteCmd = SQLConnect.CreateCommand();

            String SQLQuery = "Delete from ApiKey";
            SQLiteCmd.CommandText = SQLQuery;
            SQLiteCmd.ExecuteNonQuery();

            SQLQuery = "INSERT INTO ApiKey(BinanceApiKey, BinanceSecret, CoinMarketCapApiKey, CryptoCompareApiKey, Taapi_io_ApiKey)";
            SQLQuery += " values('" + MyApiKey["BinanceApiKey"] + "', '" + MyApiKey["BinanceSecret"] + "','" + MyApiKey["CoinMarketCapApiKey"] + "','" + MyApiKey["CryptoCompareApiKey"] + "','" + MyApiKey["Taapi_io_ApiKey"] + "'" + ");";
            SQLiteCmd.CommandText = SQLQuery;
            SQLiteCmd.ExecuteNonQuery();
            SQLiteCmd.Dispose();
            SQLConnect.Close();

        }

        //================================================================================================================================================================
        //================================================================================================================================================================

        public async Task<Dictionary<string, string>> Load()
        {
            await Task.Delay(0);
            SQLiteConnection SQLConnect = ConnectDatabase();

            SQLiteCommand SQLiteCmd = new SQLiteCommand("Select * from ApiKey;", SQLConnect);
            SQLiteDataAdapter SQLDataAdapter = new SQLiteDataAdapter();
            DataTable SqlDataTable = new DataTable();
            SQLDataAdapter.SelectCommand = SQLiteCmd;
            SQLDataAdapter.Fill(SqlDataTable);
            SQLiteDataReader SQLDataReader = SQLiteCmd.ExecuteReader();

            Dictionary<string, string> MyApiKey = new Dictionary<string, string>();

            MyApiKey["BinanceApiKey"] = "";
            MyApiKey["BinanceSecret"] = "";
            MyApiKey["CoinMarketCapApiKey"] = "";
            MyApiKey["CryptoCompareApiKey"] = "";
            MyApiKey["Taapi_io_ApiKey"] = "";


            if (SqlDataTable.Rows.Count > 0)
            {
                while (SQLDataReader.Read())
                {
                    MyApiKey["BinanceApiKey"] = SQLDataReader.GetString(SQLDataReader.GetOrdinal("BinanceApiKey")).ToString();
                    MyApiKey["BinanceSecret"] = SQLDataReader.GetString(SQLDataReader.GetOrdinal("BinanceSecret")).ToString();
                    MyApiKey["CoinMarketCapApiKey"] = SQLDataReader.GetString(SQLDataReader.GetOrdinal("CoinMarketCapApiKey")).ToString();
                    MyApiKey["CryptoCompareApiKey"] = SQLDataReader.GetString(SQLDataReader.GetOrdinal("CryptoCompareApiKey")).ToString();
                    MyApiKey["Taapi_io_ApiKey"] = SQLDataReader.GetString(SQLDataReader.GetOrdinal("Taapi_io_ApiKey")).ToString();
                 
                    break;
                }

            }

            SQLConnect.Close();

            return MyApiKey;

        }

        //================================================================================================================================================================


    }
}
