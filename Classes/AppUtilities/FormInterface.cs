using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader.Classes 
{
    public static class FormInterface
    {

        [DllImport("user32")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32")]
        public static extern bool EnableMenuItem(IntPtr hMenu, uint itemId, uint uEnable);

   //========================================================================================================================================================================================================================================================================

        public static void DisableCloseButton(System.Windows.Forms.Form form, Boolean Enabled)
        {
            if (Enabled == true)  {
                 EnableMenuItem(GetSystemMenu(form.Handle, false), 0xF060, 1); }
            else  {
                EnableMenuItem(GetSystemMenu(form.Handle, false), 0xF060, 0); }
        }
   //========================================================================================================================================================================================================================================================================






    }
}
