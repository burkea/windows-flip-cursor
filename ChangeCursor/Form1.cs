using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeCursor
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);

        const int SPI_SETCURSORS = 0x0057;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDCHANGE = 0x02;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //            ---------------------------

            //---------------------------
            //C:\Windows\cursors\aero_arrow.cur
            //-------------------------- -
            //OK
            //-------------------------- -

            //RegWrite, REG_EXPAND_SZ, HKEY_CURRENT_USER, Control Panel\Cursors, Arrow, % blackArrow %
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Cursors", true);
            
            Object o = key.GetValue("Arrow");
            if (o.ToString() == @"C:\Windows\cursors\aero_arrow.cur")
                key.SetValue("Arrow", @"C:\Windows\cursors\pen_l.cur");
            else
                key.SetValue("Arrow", @"C:\Windows\cursors\aero_arrow.cur");
            SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }
    }
}
