using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;

namespace Guac
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public partial class main : Form
    {
        public static string version = "v1.7";
        
        public static String backColor;
        public static String backColorMain;
        public static String panelColor;
        public static String foreColor;
        public static String textColor;

        private ExploitAPI api = new ExploitAPI();

        private bool dragging = false;
        private Point start_point = new Point(0, 0);

        WebBrowser webBrowser;
        RichTextBox rtb;

        private options options = new options();
        private scripthub sh = new scripthub();

        private dynamic config;

        public main()
        {
            InitializeComponent();

            try
            {
                config = JsonConvert.DeserializeObject(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Data/config.json"));
            }
            catch
            {
                MessageBox.Show("Could not read config file, either fix it or redownload the file", "Guac");
                Application.Exit();
            }
        }

        public class FileObject
        {
            public String FileName { get; set; }
            public String FileContent { get; set; }
        }

        private void main_Load(object sender, EventArgs e)
        {
            UpdateTheme();

            if (config.useFancyCodeEditor == "true")
            {
                webBrowser = new WebBrowser();
                webBrowser.Size = new Size(901, 380);
                webBrowser.Location = new Point(12, 63);
                webBrowser.Show();
            }
            else
            {
                rtb = new RichTextBox();
                rtb.Size = new Size(901, 380);
                rtb.Location = new Point(12, 63);
                rtb.BackColor = Color.FromArgb(50, 50, 50);
                rtb.BorderStyle = BorderStyle.None;
                rtb.Font = new Font("Segoe UI", 9.75f);
                rtb.ForeColor = Color.White;
                rtb.Show();
            }

            WebClient wc = new WebClient();
            ScriptList.DisplayMember = "FileName";
            versionLabel.Text = version;

            if (config.useFancyCodeEditor == "true")
            {
                webBrowser.ScriptErrorsSuppressed = true;
                webBrowser.AllowNavigation = true;

                wc.Proxy = null;
                try
                {
                    RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                    string friendlyName = AppDomain.CurrentDomain.FriendlyName;
                    bool flag2 = registryKey.GetValue(friendlyName) == null;
                    if (flag2)
                    {
                        registryKey.SetValue(friendlyName, 11001, RegistryValueKind.DWord);
                    }
                    registryKey = null;
                    friendlyName = null;
                }
                catch (Exception)
                {
                }

                webBrowser.Navigate(string.Format("file:///{0}/Data/editor.html", Directory.GetCurrentDirectory()));
            }

            var foldersFound = Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory, "Data/scripts", SearchOption.AllDirectories);
            foreach (var folderFound in foldersFound)
            {
                string fileLocation = folderFound;
                string[] txtFiles = Directory.GetFiles(fileLocation, "*.txt");
                string[] luaFiles = Directory.GetFiles(fileLocation, "*.lua");
                foreach (var luaFile in luaFiles)
                {
                    FileObject f = new FileObject();
                    f.FileName = Path.GetFileNameWithoutExtension(luaFile.ToString());
                    f.FileContent = File.ReadAllText(luaFile.ToString());
                    ScriptList.Items.Add(f);
                }
                foreach (var txtFile in txtFiles)
                {
                    FileObject f = new FileObject();
                    f.FileName = Path.GetFileNameWithoutExtension(txtFile.ToString());
                    f.FileContent = File.ReadAllText(txtFile.ToString());
                    ScriptList.Items.Add(f);
                }
            }

            if (config.useFancyCodeEditor == "true")
            {
                this.Controls.Add(webBrowser);
            }
            else
            {
                this.Controls.Add(rtb);
            }

            InitStatusTimer();
        }

        private void UpdateTheme()
        {
            if (config.theme.backColorAlt.ToString() != "")
            {
                Color backColorAlt = ColorTranslator.FromHtml(config.theme.backColorAlt.ToString());

                ScriptList.BackColor = backColorAlt;
                ExecuteButton.BackColor = backColorAlt;
                ScriptHubButton.BackColor = backColorAlt;
                SaveButton.BackColor = backColorAlt;
                ClearButton.BackColor = backColorAlt;
                OpenButton.BackColor = backColorAlt;
                OptionsButton.BackColor = backColorAlt;
                Inject.BackColor = backColorAlt;
            }

            if (config.theme.backColorAlt2.ToString() != "")
            {
                Color backColorAlt2 = ColorTranslator.FromHtml(config.theme.backColorAlt2.ToString());

                ExecuteButton.BackColor = backColorAlt2;
                ScriptHubButton.BackColor = backColorAlt2;
                SaveButton.BackColor = backColorAlt2;
                ClearButton.BackColor = backColorAlt2;
                OpenButton.BackColor = backColorAlt2;
                OptionsButton.BackColor = backColorAlt2;
                Inject.BackColor = backColorAlt2;
            }

            if (config.theme.backColorAlt3.ToString() != "")
            {
                Color backColorAlt3 = ColorTranslator.FromHtml(config.theme.backColorAlt3.ToString());

                this.BackColor = backColorAlt3;
            }

            if (config.theme.panelColor.ToString() != "")
            {
                Color panelColor = ColorTranslator.FromHtml(config.theme.panelColor.ToString());

                MovePanel.BackColor = panelColor;
                MinimizeButton.BackColor = panelColor;
                ExitButton.BackColor = panelColor;
            }

            if (config.theme.textColor.ToString() != "")
            {
                Color textColor = ColorTranslator.FromHtml(config.theme.textColor.ToString());

                name.ForeColor = textColor;
                versionLabel.ForeColor = textColor;
                MinimizeButton.ForeColor = textColor;
                ExitButton.ForeColor = textColor;
                ScriptList.ForeColor = textColor;
                ExecuteButton.ForeColor = textColor;
                ScriptHubButton.ForeColor = textColor;
                SaveButton.ForeColor = textColor;
                ClearButton.ForeColor = textColor;
                OpenButton.ForeColor = textColor;
                OptionsButton.ForeColor = textColor;
                Inject.ForeColor = textColor;
            }
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (api.isAPIAttached())
            {
                if (config.useFancyCodeEditor == "true")
                {
                    if (webBrowser.Document.InvokeScript("GetText").ToString().Length != 0)
                    {
                        api.SendLuaScript(webBrowser.Document.InvokeScript("GetText").ToString());
                    }
                    else
                    {
                        MessageBox.Show("Script box is empty", "Guac");
                    }
                }
                else
                {
                    if (rtb.Text.Length != 0)
                    {
                        api.SendLuaScript(rtb.Text);
                    }
                    else
                    {
                        MessageBox.Show("Script box is empty", "Guac");
                    }
                }
            }
            else
            {
                MessageBox.Show("DLL is not attached", "Guac");
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            webBrowser.Document.InvokeScript("SetText", new string[] { "" });
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    webBrowser.Document.InvokeScript("SetText", new string[] { File.ReadAllText(openfiledialog.FileName) });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Guac");
                }
            }
        }

        private void Inject_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MovePanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_point = new Point(e.X, e.Y);
        }

        private void MovePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_point.X, p.Y - this.start_point.Y);
            }
        }

        private void MovePanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Stream saveFile;

            if (webBrowser.Document.InvokeScript("GetText").ToString().Length != 0)
            {
                if (savefiledialog.ShowDialog() == DialogResult.OK)
                {
                    if ((saveFile = savefiledialog.OpenFile()) != null)
                    {
                        using (var writer = new StreamWriter(saveFile))
                        {
                            writer.Write(webBrowser.Document.InvokeScript("GetText").ToString());
                            writer.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Script box is empty", "Guac");
            }
        }

        private void ScriptHubButton_Click(object sender, EventArgs e)
        {
            sh.Show();
        }

        public static OpenFileDialog openfiledialog = new OpenFileDialog
        {
            Filter = "Lua Script Txt (*.txt)|*.txt|All files (*.*)|*.*",
            FilterIndex = 1,
            RestoreDirectory = true,
            Title = "Guac Open"
        };

        public static SaveFileDialog savefiledialog = new SaveFileDialog
        {
            Filter = "Lua Script Txt (*.txt)|*.txt|All files (*.*)|*.*",
            FilterIndex = 1,
            RestoreDirectory = true,
            Title = "Guac Save"
        };

        private void ScriptList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ScriptList.SelectedItem != null)
            {
                FileObject f = (FileObject)ScriptList.SelectedItem;
                webBrowser.Document.InvokeScript("SetText", new string[] { "" });
                webBrowser.Document.InvokeScript("SetText", new string[] { f.FileContent });
            }
        }

        private void injectStatusTimer_Tick(object sender, EventArgs e)
        {
            if (api.isAPIAttached())
            {
                injectStatus.Text = "Injected";
                injectStatus.ForeColor = Color.Green;
            }
            else
            {
                injectStatus.Text = "Not Injected";
                injectStatus.ForeColor = Color.Red;
            }
        }

        public void InitStatusTimer()
        {
            Timer injectStatusTimer = new Timer();
            injectStatusTimer.Tick += new EventHandler(injectStatusTimer_Tick);
            injectStatusTimer.Interval = 2000;
            injectStatusTimer.Start();
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            options.Show();
        }
    }
}
