using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Guac.Updating
{
    internal partial class GuacUpdateAcceptForm : Form
    {
        private bool dragging = false;
        private Point start_point = new Point(0, 0);

        private IGuacUpdatable applicationInfo;
        private GuacUpdateXml updateInfo;
        private GuacUpdateInfoForm updateInfoForm;

        private dynamic config;

        internal GuacUpdateAcceptForm(IGuacUpdatable applicationInfo, GuacUpdateXml updateInfo)
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

            this.applicationInfo = applicationInfo;
            this.updateInfo = updateInfo;

            this.Text = this.applicationInfo.ApplicationName + " - Update Available";

            this.lblNewVersion.Text = string.Format("New Version: {0}", this.updateInfo.Version.ToString());
        }

        private void UpdateTheme()
        {
            if (config.theme.backColor.ToString() != "")
            {
                Color backColor = ColorTranslator.FromHtml(config.theme.backColor.ToString());

                this.BackColor = backColor;
            }

            if (config.theme.backColorAlt2.ToString() != "")
            {
                Color backColorAlt2 = ColorTranslator.FromHtml(config.theme.backColorAlt2.ToString());

                btnYes.BackColor = backColorAlt2;
                btnNo.BackColor = backColorAlt2;
                btnDetails.BackColor = backColorAlt2;
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
                lblUpdateAvail.ForeColor = textColor;
                lblNewVersion.ForeColor = textColor;
                btnYes.ForeColor = textColor;
                btnNo.ForeColor = textColor;
                btnDetails.ForeColor = textColor;
            }
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

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (this.updateInfoForm == null)
                this.updateInfoForm = new GuacUpdateInfoForm(this.applicationInfo, this.updateInfo);

            this.updateInfoForm.ShowDialog(this);
        }
    }
}
