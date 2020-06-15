using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Guac.Updating
{
    public partial class GuacUpdateInfoForm : Form
    {
        private bool dragging = false;
        private Point start_point = new Point(0, 0);

        private dynamic config;

        internal GuacUpdateInfoForm(IGuacUpdatable applicationInfo, GuacUpdateXml updateInfo)
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

            UpdateTheme();

            this.Text = applicationInfo.ApplicationName + " - Update Info";
            this.lblVersions.Text = String.Format("Current Version: {0}\nUpdate Version: {1}", applicationInfo.ApplicationAssembly.GetName().Version.ToString(), updateInfo.Version.ToString());
            this.txtDescription.Text = updateInfo.Description;
        }

        private void UpdateTheme()
        {
            if (config.theme.backColor.ToString() != "")
            {
                Color backColor = ColorTranslator.FromHtml(config.theme.backColor.ToString());

                this.BackColor = backColor;
            }

            if (config.theme.backColorAlt.ToString() != "")
            {
                Color backColorAlt = ColorTranslator.FromHtml(config.theme.backColorAlt.ToString());

                txtDescription.BackColor = backColorAlt;
            }

            if (config.theme.backColorAlt2.ToString() != "")
            {
                Color backColorAlt2 = ColorTranslator.FromHtml(config.theme.backColorAlt2.ToString());

                btnBack.BackColor = backColorAlt2;
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
                lblVersions.ForeColor = textColor;
                lblDescription.ForeColor = textColor;
                txtDescription.ForeColor = textColor;
                btnBack.ForeColor = textColor;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Control && e.KeyCode == Keys.C))
                e.SuppressKeyPress = true;
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

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
