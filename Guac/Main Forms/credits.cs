using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using Guac.Updating;

namespace Guac
{
    public partial class credits : Form, IGuacUpdatable
    {

        private bool dragging = false;
        private Point start_point = new Point(0, 0);

        private GuacUpdater updater;

        private dynamic config;

        public credits()
        {
            InitializeComponent();

            updater = new GuacUpdater(this);

            try
            {
                config = JsonConvert.DeserializeObject(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Data/config.json"));
            }
            catch
            {
                MessageBox.Show("Could not read config file. Either fix it or redownload the file", "Guac");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updater.DoUpdate();

            UpdateTheme();
        }

        private void UpdateTheme()
        {
            try
            {
                if (config.theme.backColor.ToString() != "")
                {
                    Color backColor = ColorTranslator.FromHtml(config.theme.backColor.ToString());

                    this.BackColor = backColor;
                }

                if (config.theme.backColorAlt.ToString() != "")
                {
                    Color backColorAlt = ColorTranslator.FromHtml(config.theme.backColorAlt.ToString());

                    textBox1.BackColor = backColorAlt;
                }

                if (config.theme.backColorAlt2.ToString() != "")
                {
                    Color backColorAlt2 = ColorTranslator.FromHtml(config.theme.backColorAlt2.ToString());

                    OkButton.BackColor = backColorAlt2;
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
                    textBox1.ForeColor = textColor;
                    OkButton.ForeColor = textColor;
                }
            }
            catch {}
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            main main = new main();

            main.Show();
            this.Hide();
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

        public string ApplicationName
        {
            get { return "Guac"; }
        }

        public string ApplicationID
        {
            get { return "Guac"; }
        }

        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        public Icon ApplicationIcon
        {
            get { return this.Icon; }
        }

        public Uri UpdateXmlLocation
        {
            get { return new Uri("https://thebox1.dev/uploads/guac-executor/update.xml"); }
        }

        public Form Context
        {
            get { return this; }
        }
    }
}
