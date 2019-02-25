using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace PingOverlay
{
    public partial class FrOverlay : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public Config Config { get; set; }

        public Timer Timer = new Timer();

        public FrOverlay()
        {
            InitializeComponent();
            Timer.Elapsed += Ping;
            Timer.Enabled = true;
            TopMost = true;
            BackColor = Color.Wheat;
            TransparencyKey = Color.Wheat;
            Text = " ";
            ControlBox = false;
        }

        public FrOverlay(Config config) : this() => ApplyConfig(config);

        public void ApplyConfig(Config config)
        {
            try
            {
                Config = config;

                var fontSize = short.Parse(Config.FontSize);
                lblPing.Font = new Font("Consolas", fontSize);
                lblPing.ForeColor = (Color)new ColorConverter().ConvertFromString(Config.TextColor);
                lblPing.OutlineWidth = short.Parse(Config.OutlineWidth);
                lblPing.OutlineForeColor = (Color)new ColorConverter().ConvertFromString(Config.OutlineForeColor);
                lblPing.Text = Config.Timeout;
                Height = lblPing.Height + 60;
                Width = lblPing.Width;

                StartPosition = FormStartPosition.Manual;
                Location = new Point(short.Parse(Config.PosX), short.Parse(Config.PosY));

                if (Config.ShowBorder.Value)
                    FormBorderStyle = FormBorderStyle.FixedDialog;
                else
                {
                    FormBorderStyle = FormBorderStyle.None;
                    var initialStyle = GetWindowLong(Handle, -20);
                    SetWindowLong(Handle, -20, initialStyle | 0x80000 | 0x20);
                }

                Timer.Stop();
                Timer.Interval = short.Parse(Config.Interval) * 1000;
                Timer.Start();

                SaveConfig();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Invalid Configuration");
            }
        }

        private void FrOverlay_LocationChanged(object sender, EventArgs e)
        {
            if (Config == null)
                return;
            var frOverlay = ((FrOverlay)sender);
            Config.PosX = frOverlay.Location.X.ToString();
            Config.PosY = frOverlay.Location.Y.ToString();
            SaveConfig();
        }

        public void SaveConfig()
        {
            using (var sw = File.CreateText(Program.ConfigFilePath))
            {
                sw.WriteLine(JsonConvert.SerializeObject(Config));
            }
        }

        private void Ping(object source, ElapsedEventArgs e)
        {
            try
            {
                var ping = new Ping().Send(Config.Ip, short.Parse(Config.Timeout), new byte[short.Parse(Config.Bytes)], new PingOptions(short.Parse(Config.Ttl), true));
                lblPing.Invoke((MethodInvoker)delegate { lblPing.Text = ping.RoundtripTime == 0 ? "1" : ping.RoundtripTime.ToString(); });
            }
            catch
            {
                lblPing.Invoke((MethodInvoker)delegate { lblPing.Text = Config.Timeout; });
            }
        }
    }
}