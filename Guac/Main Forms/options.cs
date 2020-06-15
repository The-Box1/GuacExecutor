using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guac
{
    public partial class options : Form
    {
        private bool dragging = false;
        private Point start_point = new Point(0, 0);

        private dynamic config;

        public options()
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

        private void options_Load(object sender, EventArgs e)
        {
            UpdateTheme();

            BackColorText.Text = config.theme.backColor;
            BackColorAltText.Text = config.theme.backColorAlt;
            BackColorAlt2Text.Text = config.theme.backColorAlt2;
            BackColorAlt3Text.Text = config.theme.backColorAlt3;
            PanelColorText.Text = config.theme.panelColor;
            TextColorText.Text = config.theme.textColor;
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

                BackColorText.BackColor = backColorAlt;
                BackColorAltText.BackColor = backColorAlt;
                BackColorAlt2Text.BackColor = backColorAlt;
                BackColorAlt3Text.BackColor = backColorAlt;
                PanelColorText.BackColor = backColorAlt;
                TextColorText.BackColor = backColorAlt;
            }

            if (config.theme.backColorAlt2.ToString() != "")
            {
                Color backColorAlt2 = ColorTranslator.FromHtml(config.theme.backColorAlt2.ToString());

                BrowseBackgroundImageButton.BackColor = backColorAlt2;
                SaveThemeButton.BackColor = backColorAlt2;
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
                BackgroundImageLabel.ForeColor = textColor;
                BackColorLabel.ForeColor = textColor;
                BackColorAltLabel.ForeColor = textColor;
                BackColorAlt2Label.ForeColor = textColor;
                BackColorAlt3Label.ForeColor = textColor;
                PanelColorLabel.ForeColor = textColor;
                TextColorLabel.ForeColor = textColor;
                BrowseBackgroundImageButton.ForeColor = textColor;
                BackColorText.ForeColor = textColor;
                BackColorAltText.ForeColor = textColor;
                BackColorAlt2Text.ForeColor = textColor;
                BackColorAlt3Text.ForeColor = textColor;
                PanelColorText.ForeColor = textColor;
                TextColorText.ForeColor = textColor;
                SaveThemeButton.ForeColor = textColor;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        public static OpenFileDialog openfiledialog = new OpenFileDialog
        {
            Filter = "Choose Image(*.png;*.gif)|*.png;*.gif",
            FilterIndex = 1,
            RestoreDirectory = true,
            Title = "Guac Open"
        };

        private void BrowseBackgroundImageButton_Click(object sender, EventArgs e)
        {
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Data/bg.png");
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Data/bg.gif");
                    File.Copy(openfiledialog.FileName, AppDomain.CurrentDomain.BaseDirectory + "Data/bg" + Path.GetExtension(openfiledialog.FileName), true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not copy/read the specified file", "Guac");
                }
            }
        }

        private void SaveThemeButton_Click(object sender, EventArgs e)
        {
            config.theme.backColor = BackColorText.Text;
            config.theme.backColorAlt = BackColorAltText.Text;
            config.theme.backColorAlt2 = BackColorAlt2Text.Text;
            config.theme.backColorAlt3 = BackColorAlt3Text.Text;
            config.theme.panelColor = PanelColorText.Text;
            config.theme.textColor = TextColorText.Text;

            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Data/config.json", JsonConvert.SerializeObject(config, Formatting.Indented));
        }
    }
}
