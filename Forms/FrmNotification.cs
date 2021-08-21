using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using CryptoTrader.Classes;

namespace CryptoTrader
{
    public partial class FrmNotification : Form
    {
        dynamic MySound; 
        public FrmNotification()
        {
            InitializeComponent();
        }
        //====================================================================================================================================================================================================================
        private void CmdClose_Click(object sender, EventArgs e)
        {
            ((System.Media.SoundPlayer)MySound).Stop();
            this.Close();
        }
        //====================================================================================================================================================================================================================

        private void FrmNotification_Load(object sender, EventArgs e)
        {

        }
        //====================================================================================================================================================================================================================

        public async void ShowNotification(string NotificationID, string Price, string Message) 
        {
            await Task.Delay(0);
            int MyRow = -1;
            for(int Cnt=0; Cnt <= Grid_Notify.RowCount-1; Cnt++ )
              {
                if(Grid_Notify.Rows[Cnt].Cells[4].Value.ToString()== NotificationID.Trim())
                 { MyRow = Cnt; }
               }

            if (MyRow == -1)
            { Grid_Notify.Rows.Add(Grid_Notify.RowCount + 1, DateTime.Now.ToString("MMM-dd hh:mm:ss tt"), Price,  Message, NotificationID);
                Grid_Notify.Rows[Grid_Notify.RowCount - 1].Height = 40;

                SoundPlayer MySound = new SoundPlayer();
                    MySound.SoundLocation = AppUtilities.GetShortPath(Application.StartupPath + "\\Sounds\\notification.wav");

                    MySound.LoadCompleted += new AsyncCompletedEventHandler(MySound_LoadCompleted);
                    MySound.LoadAsync();
             }
            else {
                   Grid_Notify.Rows[MyRow].Cells[1].Value = DateTime.Now.ToString("MMM-dd hh:mm:ss tt");
                   Grid_Notify.Rows[MyRow].Cells[2].Value = Price;
                   Grid_Notify.Rows[MyRow].Cells[3].Value = Message;
                 }
       }

 //====================================================================================================================================================================================================================

        private void MySound_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MySound = sender;

            ((System.Media.SoundPlayer)MySound).Stop();

            if (ChkPlaySound.Checked == true)
            { 
                ((System.Media.SoundPlayer)MySound).PlayLooping();
            }
           
        }

//====================================================================================================================================================================================================================

        private void CmdSave_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            ((System.Media.SoundPlayer)MySound).Stop();
        }

 //====================================================================================================================================================================================================================

        private void ChkPlaySound_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPlaySound.Checked == false)
            {
                ((System.Media.SoundPlayer)MySound).Stop();
            }
            else  { CmdClose_Click(null,null); }
        }

 //====================================================================================================================================================================================================================


    }
}
