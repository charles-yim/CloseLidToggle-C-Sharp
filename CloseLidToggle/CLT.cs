using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace CloseLidToggle
{
    public partial class CLT : Form
    {
        public CLT()
        {
            InitializeComponent();
            notifyIcon1.Icon = Properties.Resources.Icon1;
        }

        private void runCMD(String cmd)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo();
            processStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            processStartInfo.FileName = "cmd.exe";
            processStartInfo.Arguments = "/C " + cmd;
            process.StartInfo = processStartInfo;
            process.Start();
        }

        private void minimiseUI()
        {
            this.Hide();
        }

        //powercfg -setacvalueindex SCHEME_CURRENT 4f971e89-eebd-4455-a8de-9e59040e7347 5ca83367-6e45-459f-a27b-476b1d01c936 0
        private void btnDoNothing_Click(object sender, EventArgs e)
        {
            runCMD("powercfg -setacvalueindex SCHEME_CURRENT 4f971e89-eebd-4455-a8de-9e59040e7347 5ca83367-6e45-459f-a27b-476b1d01c936 0");
            runCMD("powercfg -setactive SCHEME_CURRENT");
        }

        //powercfg -setacvalueindex SCHEME_CURRENT 4f971e89-eebd-4455-a8de-9e59040e7347 5ca83367-6e45-459f-a27b-476b1d01c936 1
        private void btnSleep_Click(object sender, EventArgs e)
        {
            runCMD("powercfg -setacvalueindex SCHEME_CURRENT 4f971e89-eebd-4455-a8de-9e59040e7347 5ca83367-6e45-459f-a27b-476b1d01c936 1");
            runCMD("powercfg -setactive SCHEME_CURRENT");
        }

        private void CLT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                minimiseUI();
                e.Cancel = true;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
