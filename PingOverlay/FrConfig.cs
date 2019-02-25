using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace PingOverlay
{
    public partial class FrConfig : Form
    {
        public FrOverlay FrOverlay;
        public Config Config = new Config();

        public FrConfig()
        {
            InitializeComponent();
            try
            {
                var configJson = File.ReadAllText(Program.ConfigFilePath);
                Config = JsonConvert.DeserializeObject<Config>(configJson);
            }
            catch { }

            Config.ApplyDefaultToNulls();
            PlotConfig();

            FrOverlay = new FrOverlay(Config);
            FrOverlay.Show();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            Config.Ip = tbIp.Text;
            Config.Interval = tbInterval.Text;
            Config.Bytes = tbBytes.Text;
            Config.Ttl = tbTtl.Text;
            Config.Timeout = tbTimeout.Text;
            Config.FontSize = tbFontSize.Text;
            Config.TextColor = tbTextColor.Text;
            Config.OutlineWidth = tbOutlineWidth.Text;
            Config.OutlineForeColor = tbOutlineForeColor.Text;
            Config.ShowBorder = cbShowBorder.Checked;

            FrOverlay.ApplyConfig(Config);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Config = new Config();
            Config.ApplyDefaultToNulls();
            PlotConfig();
            FrOverlay.ApplyConfig(Config);
        }

        public void PlotConfig()
        {
            tbIp.Text = Config.Ip;
            tbInterval.Text = Config.Interval;
            tbBytes.Text = Config.Bytes;
            tbTtl.Text = Config.Ttl;
            tbTimeout.Text = Config.Timeout;
            tbFontSize.Text = Config.FontSize;
            tbTextColor.Text = Config.TextColor;
            tbOutlineWidth.Text = Config.OutlineWidth;
            tbOutlineForeColor.Text = Config.OutlineForeColor;
            cbShowBorder.Checked = Config.ShowBorder.Value;
        }
    }
}