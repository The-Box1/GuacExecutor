using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Guac
{
    public partial class scripthub : Form
    {
        String scripthubLoc = "https://thebox1.dev/uploads/guac-executor/scripthub/";

        ExploitAPI api = new ExploitAPI();
        WebClient wc = new WebClient();

        private bool dragging = false;
        private Point start_point = new Point(0, 0);

        private dynamic config;

        public scripthub()
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

        public class ScriptObject
        {
            public String ScriptName { get; set; }
            public String ScriptDescription { get; set; }
            public String ScriptContent { get; set; }
            public String ScriptBannerLoc { get; set; }
        }

        private void scripthub_Load(object sender, EventArgs e)
        {
            UpdateTheme();

            ScriptList.DisplayMember = "ScriptName";

            dynamic scripthubJson = JsonConvert.DeserializeObject(wc.DownloadString(scripthubLoc + "scripts.json"));

            foreach (var script in scripthubJson.scripts)
            {
                ScriptObject s = new ScriptObject();
                s.ScriptName = script.name;
                s.ScriptDescription = script.description;
                try
                {
                    s.ScriptContent = wc.DownloadString(script.location.ToString() + "source.txt");
                }
                catch (Exception)
                {
                    s.ScriptContent = "";
                }
                try
                {
                    wc.DownloadFileAsync(new Uri(script.location.ToString() + "banner.png"), AppDomain.CurrentDomain.BaseDirectory + "Data/scripthubRes/" + script.name + ".png");
                }
                catch (Exception)
                {
                    
                }
                s.ScriptBannerLoc = AppDomain.CurrentDomain.BaseDirectory + "Data/scripthubRes/" + script.name + ".png";
                ScriptList.Items.Add(s);
            }
        }

        private void UpdateTheme()
        {
            if (config.theme.backColor.ToString() != "")
            {
                Color backColor = ColorTranslator.FromHtml(config.theme.backColor.ToString());

                this.BackColor = backColor;
                ScriptImage.BackColor = backColor;
            }

            if (config.theme.backColorAlt.ToString() != "")
            {
                Color backColorAlt = ColorTranslator.FromHtml(config.theme.backColorAlt.ToString());

                ScriptList.BackColor = backColorAlt;
                ScriptDescription.BackColor = backColorAlt;
            }

            if (config.theme.backColorAlt2.ToString() != "")
            {
                Color backColorAlt2 = ColorTranslator.FromHtml(config.theme.backColorAlt2.ToString());
                
                ExecuteButton.BackColor = backColorAlt2;
            }

            if (config.theme.panelColor.ToString() != "")
            {
                Color panelColor = ColorTranslator.FromHtml(config.theme.panelColor.ToString());

                MovePanel.BackColor = panelColor;
                ExitButton.BackColor = panelColor;
            }

            if (config.theme.textColor.ToString() != "")
            {
                Color textColor = ColorTranslator.FromHtml(config.theme.textColor.ToString());

                label1.ForeColor = textColor;
                ExitButton.ForeColor = textColor;
                ScriptList.ForeColor = textColor;
                ScriptDescription.ForeColor = textColor;
                ExecuteButton.ForeColor = textColor;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Hide();
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

        private void ScriptList_MouseClick(object sender, MouseEventArgs e)
        {
            if (ScriptList.SelectedItem != null)
            {
                try
                {
                    ScriptObject s = (ScriptObject)ScriptList.SelectedItem;
                    ScriptDescription.Text = s.ScriptDescription;
                    ScriptImage.Image = Image.FromFile(s.ScriptBannerLoc);
                } catch {}
            }
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (ScriptList.SelectedItem != null)
            {
                ScriptObject s = (ScriptObject)ScriptList.SelectedItem;

                if (api.isAPIAttached())
                {
                    api.SendLuaScript(s.ScriptContent.ToString());
                }
                else
                {
                    MessageBox.Show("DLL is not attached", "Guac");
                }
            }
        }
    }
}
