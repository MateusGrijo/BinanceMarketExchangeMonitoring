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
 

namespace CryptoTrader.Forms
{
    public partial class FrmToken : Form
    {
        SQLite_Whitelist MySQLite_WhiteList = new SQLite_Whitelist();

        public FrmToken()
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
         public void Set_Token(Dictionary<string, string> TokenInfo)
         {
            TxtTokenID.Text = TokenInfo["TokenID"];
            TxtTokenName.Text = TokenInfo["TokenName"];
            TxtTokenSymbol.Text = TokenInfo["TokenSymbol"];
            TxtTokenName.Focus();
        }
         

        //=========================================================================================================================================================

        private void CmdSave_Click(object sender, EventArgs e)
        { 
         
            MyTimer.Enabled = true;
            Dictionary<string, string> TokenInfo = new Dictionary<string, string>();

            TokenInfo["TokenID"]= TxtTokenID.Text ;
            TokenInfo["TokenName"] = TxtTokenName.Text;
            TokenInfo["TokenSymbol"] = TxtTokenSymbol.Text.ToString().ToUpper().Trim();
            MySQLite_WhiteList.Update(TokenInfo);
         }

 //=========================================================================================================================================================

     

        //=========================================================================================================================================================

        private async void MyTimer_Tick(object sender, EventArgs e)
        {
            string Mytoken = Application.OpenForms.OfType<FrmMain>().Single().CmbToken.Text;
            await Task.Delay(0);
            if (PBar.Value != 50)
            { PBar.Value += 1; }
            else
            {   PBar.Value = 0;
                MyTimer.Enabled = false;
                Application.OpenForms.OfType<FrmMain>().Single().Load_WhiteList();
                Application.OpenForms.OfType<FrmMain>().Single().CmbToken.Text = Mytoken;
                this.Close();
            }
        }

        private void FrmToken_Load(object sender, EventArgs e)
        {

        }

        //=========================================================================================================================================================


    }
}
