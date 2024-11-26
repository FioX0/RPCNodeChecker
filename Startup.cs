using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RPCNodeChecker
{
    public partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();
            SetupWorker.RunWorkerAsync();
        }

        private async void SetupWorker_DoWork_1(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(3000);
            RPCN0deChecker.rpcNodes = await _9CAPI.Node.RPCNodesAsync();
            if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Nine Chronicles\\config.json"))
            {
                RPCN0deChecker.configPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Nine Chronicles\\config.json";
            }
            else
            {
                throw new Exception("Config Not found in default path");
            }
            this.Invoke(new MethodInvoker(this.Close));
        }
    }
}
