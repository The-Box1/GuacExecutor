using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace Guac
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Checks();
        }

        private static void Checks()
        {
            if ((!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Data")) || (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Data/scripts")) ||
                (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Data/vs")) || (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Data/editor.html")) ||
                (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Data/scripthubRes")) || (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Data/config.json")))
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile("https://thebox1.dev/uploads/guac-executor/Data.zip", AppDomain.CurrentDomain.BaseDirectory + "Data.zip");
                    client.Dispose();
                }

                using (FileStream zipStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Data.zip", FileMode.Open))
                {
                    using (ZipArchive archive = new ZipArchive(zipStream))
                    {
                        ZipUtil.ExtractToDirectory(archive, AppDomain.CurrentDomain.BaseDirectory, true);
                    }
                }

                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Data.zip");
            }

            Application.Run(new credits());
        }
    }
}
