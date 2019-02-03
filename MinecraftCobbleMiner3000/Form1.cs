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

namespace MinecraftCobbleMiner3000
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;

        public Form1()
        {
            InitializeComponent();
        }

        private async void mine(decimal bdelay, decimal wdelay)
        {
            // Convert to ms
            bdelay = bdelay * 1000;
            wdelay = wdelay * 1000;

            // Convert decimal to integers
            int icbdelay = Convert.ToInt32(Math.Round(bdelay, 0));
            int icwdelay = Convert.ToInt32(Math.Round(wdelay, 0));

            int startoutdelay = 10;
            DateTime future = DateTime.Now.AddSeconds(10);

            outputPrint("Launching in:");
            while (future > DateTime.Now)
            {
                outputPrint(startoutdelay.ToString());
                await Task.Delay(1000);

                startoutdelay = startoutdelay - 1;
            }

            outputPrint("Beginning mining operation.");

            while (checkBox1.Checked)
            {
                int X = Cursor.Position.X;
                int Y = Cursor.Position.Y;
                mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
                outputPrint("Left mouse down");
                await Task.Delay(icbdelay);
                mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                outputPrint("Left mouse up");
                await Task.Delay(icwdelay);
            }
            outputPrint("Ending mining operation.");
        }

        private void outputPrint(string msg)
        {
            msg += "\n";
            richTextBox1.AppendText(msg);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                mine(bDelay.Value, rDelay.Value);

            }
        }
    }
}
