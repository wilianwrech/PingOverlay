using System;
using System.IO;
using System.Windows.Forms;

namespace PingOverlay
{
    internal static class Program
    {
        public static string AppDataFolder => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\PingOverlay";
        public static string ConfigFileName => "config.cfg";
        public static string ConfigFilePath => AppDataFolder + "\\" + ConfigFileName;

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Directory.Exists(AppDataFolder))
                Directory.CreateDirectory(AppDataFolder);

            Application.Run(new FrConfig());
        }
    }
}