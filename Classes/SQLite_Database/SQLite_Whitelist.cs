using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;


namespace CryptoTrader.Classes
{
    class SQLite_Whitelist
    {

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

        public async Task<string> Load() 
        {
            await Task.Delay(0);
            SQLiteConnection SQLConnect = ConnectDatabase();

            SQLiteCommand SQLiteCmd = new SQLiteCommand("Select * from WhiteList order by Token_Name ASC;", SQLConnect);
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
                    MyToken += "{\"Name\" : \"" +  SQLDataReader.GetString(SQLDataReader.GetOrdinal("Token_Name")).ToString() + "\", ";
                    MyToken += "\"Symbol\" : \"" + SQLDataReader.GetString(SQLDataReader.GetOrdinal("Token_Symbol")).ToString() + "\", ";
                    MyToken += "\"WhiteList_ID\" : \"" + SQLDataReader.GetInt32(SQLDataReader.GetOrdinal("WhiteList_ID")).ToString() + "\"}, ";
                }

            }

            if(MyToken.Length>=5)
               { MyToken = MyToken.Trim().Substring(0, MyToken.Length - 2); }

            SQLConnect.Close();

            return MyToken +"]";
 
        }

 //================================================================================================================================================================


        public async void Update(Dictionary<string, string> TokenInfo)
        {
            await Task.Delay(0);
            SQLiteConnection SQLConnect = ConnectDatabase();

            SQLiteCommand SQLiteCmd = new SQLiteCommand();
            SQLiteCmd = SQLConnect.CreateCommand();
             
            String SQLQuery = "";

            if (TokenInfo["TokenID"] != "0")
            {
                  SQLQuery = "INSERT OR IGNORE INTO Whitelist(WhiteList_ID, Token_Name, Token_Symbol)";
                  SQLQuery += " values(" + TokenInfo["TokenID"] + ", '" + TokenInfo["TokenName"] + "','" + TokenInfo["TokenSymbol"] + "');";
                    }
            else
            {
                  SQLQuery = "INSERT OR IGNORE INTO Whitelist(Token_Name, Token_Symbol)";
                  SQLQuery += " values('" + TokenInfo["TokenName"] + "','" + TokenInfo["TokenSymbol"] + "');";
                }

            SQLQuery += "  UPDATE Whitelist set Token_Name ='" + TokenInfo["TokenName"] + "',Token_Symbol='" + TokenInfo["TokenSymbol"] + "' where WhiteList_ID=" + TokenInfo["TokenID"] + ";";


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

            String SQLQuery = "Delete from Whitelist where WhiteList_ID = " + TokenID;
            SQLiteCmd.CommandText = SQLQuery;

            SQLiteCmd.ExecuteNonQuery();
            SQLiteCmd.Dispose();
            SQLConnect.Close();

        }

       
 //================================================================================================================================================================

    }
}
