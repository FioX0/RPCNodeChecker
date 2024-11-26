using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RPCNodeChecker._9CAPI;
using RPCNodeChecker.Models;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace RPCNodeChecker
{
    public partial class RPCN0deChecker : Form
    {
        public static List<ChainModel> rpcNodes = new List<ChainModel>();
        public static Form mainForm = new Form();
        public static string configPath = string.Empty;
        private delegate void SafeCallDelegate(int client, string text);

        public RPCN0deChecker()
        {
            InitializeComponent();
            //rpcNodes = nodes;
            //Setup();
            var startup = new Startup();
            startup.FormClosing += Form1_FormClosing;
            startup.Show();
            ArenaCheckerWorker.RunWorkerAsync();
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            Setup();
        }

        public async Task<Task> Setup()
        {
            DataGridViewTextBoxColumn RPCNameColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn GQLColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn RPCActiveColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn RPCUsersColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn RPCDifferenceColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn RPCResponseTimeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ThirdPartyColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ArenaProviderColumn = new DataGridViewTextBoxColumn();
            DataGridViewButtonColumn RPCSelectColumn = new DataGridViewButtonColumn();

            RPCNameColumn.Name = "Node Name";
            RPCNameColumn.Width = 160;
            GQLColumn.Name = "GQL Endpoint";
            GQLColumn.Width = 300;
            RPCActiveColumn.Name = "Active";
            RPCActiveColumn.Width = 50;
            RPCUsersColumn.Name = "Users";
            RPCUsersColumn.Width = 40;
            RPCDifferenceColumn.Name = "Diff";
            RPCDifferenceColumn.Width = 40;
            RPCResponseTimeColumn.Name = "Ping";
            RPCResponseTimeColumn.Width = 40;
            ThirdPartyColumn.Name = "Third Party";
            ThirdPartyColumn.Width = 60;
            ArenaProviderColumn.Name = "ArenaProvider";
            ArenaProviderColumn.Width = 80;
            RPCSelectColumn.Name = "Use Node";
            RPCSelectColumn.Width = 60;

            dataGridView1.Columns.Insert(0, RPCNameColumn);
            dataGridView1.Columns.Insert(1, GQLColumn);
            dataGridView1.Columns.Insert(2, RPCActiveColumn);
            dataGridView1.Columns.Insert(3, RPCUsersColumn);
            dataGridView1.Columns.Insert(4, RPCDifferenceColumn);
            dataGridView1.Columns.Insert(5, RPCResponseTimeColumn);
            dataGridView1.Columns.Insert(6, ThirdPartyColumn);
            dataGridView1.Columns.Insert(7, ArenaProviderColumn);
            dataGridView1.Columns.Insert(8, RPCSelectColumn);

            foreach (var rpcNode in rpcNodes)
            {
                if (rpcNode.name.Contains("RPC"))
                    dataGridView1.Rows.Add(rpcNode.name, rpcNode.url, rpcNode.active, rpcNode.users, rpcNode.difference, rpcNode.response_time_seconds, false, "Planetarium", "Select");
                else if (rpcNode.name.Contains("9CAPI"))
                    dataGridView1.Rows.Add(rpcNode.name, rpcNode.url, rpcNode.active, rpcNode.users, rpcNode.difference, rpcNode.response_time_seconds, true, "9CAPI", "Select");
                else
                    dataGridView1.Rows.Add(rpcNode.name, rpcNode.url, rpcNode.active, rpcNode.users, rpcNode.difference, rpcNode.response_time_seconds, true, "Planetarium", "Select");
            }

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            foreach (DataGridViewRow col in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in col.Cells)
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //Console.WriteLine(comboBox1.SelectedIndex);
            return Task.CompletedTask;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Rows.Count > 0 && e.RowIndex >= 0 && e.ColumnIndex == 8)
            {
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    string nodeUrl = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string arenaProvider = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    if (comboBox1.SelectedIndex != -1)
                    {
                        switch (comboBox1.SelectedIndex)
                        {
                            case 0:
                                arenaProvider = "Planetarium";
                                break;

                            case 1:
                                arenaProvider = "9CAPI";
                                break;
                        }
                    }
                    SetNodeConfiguration(nodeUrl, arenaProvider);
                }
            }
        }

        private async Task<bool> SetNodeConfiguration(string nodeUrl, string ArenaProvider)
        {
            try
            {
                var url = await Node.SubmitNodeRequest(nodeUrl, ArenaProvider);
                if(url is not null)
                {
                    ConfigModel configModel = new ConfigModel();
                    using (StreamReader file = new StreamReader(configPath))
                    {
                        configModel = JsonConvert.DeserializeObject<ConfigModel>(file.ReadToEnd());
                    }
                    configModel.PlanetRegistryUrl = url.Replace("\"", "");

                    using (StreamWriter myFile = new StreamWriter(configPath))
                    {
                        myFile.WriteLine(JsonConvert.SerializeObject(configModel, Formatting.Indented));
                        myFile.Close();
                    }
                    MessageBox.Show("Config Applied");
                }
                else
                    MessageBox.Show("Config Failed. Please contact support on discord.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Resetting is actually easier to delete the file. Launcher will re-download the config.
            File.Delete(configPath);
        }

        private void ArenaCheckerWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ArenaWorkerAsync(); //We need Async
        }

        private async void ArenaWorkerAsync()
        {
            Thread.Sleep(10000); // Let the UI Load Fully.

            while (true)
            {
                //Planetarium Region
            #region

                //Odin Planetarium
                try
                {
                    var options = new RestClientOptions("http://odin-arena.9c.gg")
                    {
                        MaxTimeout = -1,
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest("/graphql", Method.Post);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddParameter("application/json", "{\"query\":\"query{\\r\\n  stateQuery{\\r\\n    arenaParticipants(avatarAddress:\\\"0x3b7a47daaece48807fc00a310b05bd9f5d26736e\\\", filterBounds:true){nameWithHash}\\r\\n  }\\r\\n}\",\"variables\":{}}",
                               ParameterType.RequestBody);
                    RestResponse response = await client.ExecuteAsync(request);
                    JObject joResponse = JObject.Parse(response.Content);
                    JArray ojObject = (JArray)joResponse["data"]["stateQuery"]["arenaParticipants"];
                    if (ojObject.Count > 0)
                        PLTOdinArenaLBL.BeginInvoke((Action)delegate ()
                        {
                            PLTOdinArenaLBL.Text = "Online";
                            PLTOdinArenaLBL.ForeColor = Color.Green;
                        });
                    else
                        PLTOdinArenaLBL.BeginInvoke((Action)delegate ()
                        {
                            PLTOdinArenaLBL.Text = "Down";
                            PLTOdinArenaLBL.ForeColor = Color.Red;
                        });
                }
                catch (Exception ex)
                {
                    PLTOdinArenaLBL.BeginInvoke((Action)delegate ()
                    {
                        PLTOdinArenaLBL.Text = "Down";
                        PLTOdinArenaLBL.ForeColor = Color.Red;
                    });
                }

                //Heimdall Planetarium
                try
                {
                    var options = new RestClientOptions("http://heimdall-arena.9c.gg")
                    {
                        MaxTimeout = -1,
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest("/graphql", Method.Post);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddParameter("application/json", "{\"query\":\"query{\\r\\n  stateQuery{\\r\\n    arenaParticipants(avatarAddress:\\\"0x3b7a47daaece48807fc00a310b05bd9f5d26736e\\\", filterBounds:true){nameWithHash}\\r\\n  }\\r\\n}\",\"variables\":{}}",
                               ParameterType.RequestBody);
                    RestResponse response = await client.ExecuteAsync(request);
                    JObject joResponse = JObject.Parse(response.Content);
                    JArray ojObject = (JArray)joResponse["data"]["stateQuery"]["arenaParticipants"];
                    if (ojObject.Count > 0)
                        PLTHeimArenaLBL.BeginInvoke((Action)delegate ()
                        {
                            PLTHeimArenaLBL.Text = "Online";
                            PLTHeimArenaLBL.ForeColor = Color.Green;
                        });
                    else
                        PLTHeimArenaLBL.BeginInvoke((Action)delegate ()
                        {
                            PLTHeimArenaLBL.Text = "Down";
                            PLTHeimArenaLBL.ForeColor = Color.Red;
                        });
                }
                catch (Exception ex)
                {
                    PLTHeimArenaLBL.BeginInvoke((Action)delegate ()
                    {
                        PLTHeimArenaLBL.Text = "Down";
                        PLTHeimArenaLBL.ForeColor = Color.Red;
                    });
                }
            #endregion

                //9CAPI Region
            #region

                //9CAPI Odin
                try
                {
                    var options = new RestClientOptions("http://odin.9capi.com:23061")
                    {
                        MaxTimeout = -1,
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest("/graphql", Method.Post);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddParameter("application/json", "{\"query\":\"query{\\r\\n  stateQuery{\\r\\n    arenaParticipants(avatarAddress:\\\"0x3b7a47daaece48807fc00a310b05bd9f5d26736e\\\", filterBounds:true){nameWithHash}\\r\\n  }\\r\\n}\",\"variables\":{}}",
                               ParameterType.RequestBody);
                    RestResponse response = await client.ExecuteAsync(request);
                    JObject joResponse = JObject.Parse(response.Content);
                    JArray ojObject = (JArray)joResponse["data"]["stateQuery"]["arenaParticipants"];
                    if (ojObject.Count > 0)
                        APIOdinArenaLBL.BeginInvoke((Action)delegate ()
                        {
                            APIOdinArenaLBL.Text = "Online";
                            APIOdinArenaLBL.ForeColor = Color.Green;
                        });
                    else
                        APIOdinArenaLBL.BeginInvoke((Action)delegate ()
                        {
                            APIOdinArenaLBL.Text = "Down";
                            APIOdinArenaLBL.ForeColor = Color.Red;
                        });
                }
                catch (Exception ex)
                {
                    APIOdinArenaLBL.BeginInvoke((Action)delegate ()
                    {
                        APIOdinArenaLBL.Text = "Down";
                        APIOdinArenaLBL.ForeColor = Color.Red;
                    });
                }

                //9CAPI Heimdall
                try
                {
                    var options = new RestClientOptions("http://heimdall.9capi.com:8080")
                    {
                        MaxTimeout = -1,
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest("/graphql", Method.Post);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddParameter("application/json", "{\"query\":\"query{\\r\\n  stateQuery{\\r\\n    arenaParticipants(avatarAddress:\\\"0x3b7a47daaece48807fc00a310b05bd9f5d26736e\\\", filterBounds:true){nameWithHash}\\r\\n  }\\r\\n}\",\"variables\":{}}",
                               ParameterType.RequestBody);
                    RestResponse response = await client.ExecuteAsync(request);
                    JObject joResponse = JObject.Parse(response.Content);
                    JArray ojObject = (JArray)joResponse["data"]["stateQuery"]["arenaParticipants"];
                    if (ojObject.Count > 0)
                        APIHeimArenaLBL.BeginInvoke((Action)delegate ()
                        {
                            APIHeimArenaLBL.Text = "Online";
                            APIHeimArenaLBL.ForeColor = Color.Green;
                        });
                    else
                        APIHeimArenaLBL.BeginInvoke((Action)delegate ()
                        {
                            APIHeimArenaLBL.Text = "Down";
                            APIHeimArenaLBL.ForeColor = Color.Red;
                        });
                }
                catch (Exception ex)
                {
                    APIHeimArenaLBL.BeginInvoke((Action)delegate ()
                    {
                        APIHeimArenaLBL.Text = "Down";
                        APIHeimArenaLBL.ForeColor = Color.Red;
                    });
                }
                #endregion
                Thread.Sleep(60000*5);
            }
        }
    }
}
