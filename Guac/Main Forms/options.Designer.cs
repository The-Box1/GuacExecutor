namespace Guac
{
    partial class options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(options));
            this.MovePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.BackColorText = new System.Windows.Forms.TextBox();
            this.BackgroundImageLabel = new System.Windows.Forms.Label();
            this.BrowseBackgroundImageButton = new System.Windows.Forms.Button();
            this.SaveThemeButton = new System.Windows.Forms.Button();
            this.BackColorLabel = new System.Windows.Forms.Label();
            this.BackColorAltLabel = new System.Windows.Forms.Label();
            this.BackColorAltText = new System.Windows.Forms.TextBox();
            this.BackColorAlt2Label = new System.Windows.Forms.Label();
            this.BackColorAlt2Text = new System.Windows.Forms.TextBox();
            this.PanelColorLabel = new System.Windows.Forms.Label();
            this.PanelColorText = new System.Windows.Forms.TextBox();
            this.TextColorLabel = new System.Windows.Forms.Label();
            this.TextColorText = new System.Windows.Forms.TextBox();
            this.BackColorAlt3Label = new System.Windows.Forms.Label();
            this.BackColorAlt3Text = new System.Windows.Forms.TextBox();
            this.MovePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MovePanel
            // 
            this.MovePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.MovePanel.Controls.Add(this.label1);
            this.MovePanel.Controls.Add(this.ExitButton);
            this.MovePanel.Location = new System.Drawing.Point(0, 0);
            this.MovePanel.Name = "MovePanel";
            this.MovePanel.Size = new System.Drawing.Size(532, 34);
            this.MovePanel.TabIndex = 5;
            this.MovePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MovePanel_MouseDown);
            this.MovePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MovePanel_MouseMove);
            this.MovePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MovePanel_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Guac";
            // 
            // ExitButton
            // 
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(504, 3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(25, 25);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // BackColorText
            // 
            this.BackColorText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BackColorText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackColorText.Cursor = System.Windows.Forms.Cursors.Default;
            this.BackColorText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackColorText.ForeColor = System.Drawing.Color.White;
            this.BackColorText.Location = new System.Drawing.Point(86, 77);
            this.BackColorText.Name = "BackColorText";
            this.BackColorText.Size = new System.Drawing.Size(90, 25);
            this.BackColorText.TabIndex = 14;
            this.BackColorText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BackgroundImageLabel
            // 
            this.BackgroundImageLabel.AutoSize = true;
            this.BackgroundImageLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackgroundImageLabel.ForeColor = System.Drawing.Color.White;
            this.BackgroundImageLabel.Location = new System.Drawing.Point(10, 45);
            this.BackgroundImageLabel.Name = "BackgroundImageLabel";
            this.BackgroundImageLabel.Size = new System.Drawing.Size(69, 26);
            this.BackgroundImageLabel.TabIndex = 15;
            this.BackgroundImageLabel.Text = "Background\r\nImage";
            this.BackgroundImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrowseBackgroundImageButton
            // 
            this.BrowseBackgroundImageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.BrowseBackgroundImageButton.FlatAppearance.BorderSize = 0;
            this.BrowseBackgroundImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseBackgroundImageButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseBackgroundImageButton.ForeColor = System.Drawing.Color.White;
            this.BrowseBackgroundImageButton.Location = new System.Drawing.Point(86, 44);
            this.BrowseBackgroundImageButton.Name = "BrowseBackgroundImageButton";
            this.BrowseBackgroundImageButton.Size = new System.Drawing.Size(90, 27);
            this.BrowseBackgroundImageButton.TabIndex = 16;
            this.BrowseBackgroundImageButton.Text = "Browse";
            this.BrowseBackgroundImageButton.UseVisualStyleBackColor = false;
            this.BrowseBackgroundImageButton.Click += new System.EventHandler(this.BrowseBackgroundImageButton_Click);
            // 
            // SaveThemeButton
            // 
            this.SaveThemeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.SaveThemeButton.FlatAppearance.BorderSize = 0;
            this.SaveThemeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveThemeButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveThemeButton.ForeColor = System.Drawing.Color.White;
            this.SaveThemeButton.Location = new System.Drawing.Point(12, 272);
            this.SaveThemeButton.Name = "SaveThemeButton";
            this.SaveThemeButton.Size = new System.Drawing.Size(107, 34);
            this.SaveThemeButton.TabIndex = 17;
            this.SaveThemeButton.Text = "Save Theme";
            this.SaveThemeButton.UseVisualStyleBackColor = false;
            this.SaveThemeButton.Click += new System.EventHandler(this.SaveThemeButton_Click);
            // 
            // BackColorLabel
            // 
            this.BackColorLabel.AutoSize = true;
            this.BackColorLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackColorLabel.ForeColor = System.Drawing.Color.White;
            this.BackColorLabel.Location = new System.Drawing.Point(15, 84);
            this.BackColorLabel.Name = "BackColorLabel";
            this.BackColorLabel.Size = new System.Drawing.Size(61, 13);
            this.BackColorLabel.TabIndex = 18;
            this.BackColorLabel.Text = "Back Color";
            this.BackColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackColorAltLabel
            // 
            this.BackColorAltLabel.AutoSize = true;
            this.BackColorAltLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackColorAltLabel.ForeColor = System.Drawing.Color.White;
            this.BackColorAltLabel.Location = new System.Drawing.Point(15, 108);
            this.BackColorAltLabel.Name = "BackColorAltLabel";
            this.BackColorAltLabel.Size = new System.Drawing.Size(61, 26);
            this.BackColorAltLabel.TabIndex = 20;
            this.BackColorAltLabel.Text = "Back Color\r\nAlt";
            this.BackColorAltLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackColorAltText
            // 
            this.BackColorAltText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BackColorAltText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackColorAltText.Cursor = System.Windows.Forms.Cursors.Default;
            this.BackColorAltText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackColorAltText.ForeColor = System.Drawing.Color.White;
            this.BackColorAltText.Location = new System.Drawing.Point(86, 108);
            this.BackColorAltText.Name = "BackColorAltText";
            this.BackColorAltText.Size = new System.Drawing.Size(90, 25);
            this.BackColorAltText.TabIndex = 19;
            this.BackColorAltText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BackColorAlt2Label
            // 
            this.BackColorAlt2Label.AutoSize = true;
            this.BackColorAlt2Label.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackColorAlt2Label.ForeColor = System.Drawing.Color.White;
            this.BackColorAlt2Label.Location = new System.Drawing.Point(13, 139);
            this.BackColorAlt2Label.Name = "BackColorAlt2Label";
            this.BackColorAlt2Label.Size = new System.Drawing.Size(61, 26);
            this.BackColorAlt2Label.TabIndex = 22;
            this.BackColorAlt2Label.Text = "Back Color\r\nAlt 2";
            this.BackColorAlt2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackColorAlt2Text
            // 
            this.BackColorAlt2Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BackColorAlt2Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackColorAlt2Text.Cursor = System.Windows.Forms.Cursors.Default;
            this.BackColorAlt2Text.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackColorAlt2Text.ForeColor = System.Drawing.Color.White;
            this.BackColorAlt2Text.Location = new System.Drawing.Point(86, 139);
            this.BackColorAlt2Text.Name = "BackColorAlt2Text";
            this.BackColorAlt2Text.Size = new System.Drawing.Size(90, 25);
            this.BackColorAlt2Text.TabIndex = 21;
            this.BackColorAlt2Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PanelColorLabel
            // 
            this.PanelColorLabel.AutoSize = true;
            this.PanelColorLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelColorLabel.ForeColor = System.Drawing.Color.White;
            this.PanelColorLabel.Location = new System.Drawing.Point(15, 206);
            this.PanelColorLabel.Name = "PanelColorLabel";
            this.PanelColorLabel.Size = new System.Drawing.Size(66, 13);
            this.PanelColorLabel.TabIndex = 24;
            this.PanelColorLabel.Text = "Panel Color";
            this.PanelColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelColorText
            // 
            this.PanelColorText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PanelColorText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelColorText.Cursor = System.Windows.Forms.Cursors.Default;
            this.PanelColorText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelColorText.ForeColor = System.Drawing.Color.White;
            this.PanelColorText.Location = new System.Drawing.Point(86, 201);
            this.PanelColorText.Name = "PanelColorText";
            this.PanelColorText.Size = new System.Drawing.Size(90, 25);
            this.PanelColorText.TabIndex = 23;
            this.PanelColorText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextColorLabel
            // 
            this.TextColorLabel.AutoSize = true;
            this.TextColorLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextColorLabel.ForeColor = System.Drawing.Color.White;
            this.TextColorLabel.Location = new System.Drawing.Point(15, 239);
            this.TextColorLabel.Name = "TextColorLabel";
            this.TextColorLabel.Size = new System.Drawing.Size(58, 13);
            this.TextColorLabel.TabIndex = 26;
            this.TextColorLabel.Text = "Text Color";
            this.TextColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextColorText
            // 
            this.TextColorText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.TextColorText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextColorText.Cursor = System.Windows.Forms.Cursors.Default;
            this.TextColorText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextColorText.ForeColor = System.Drawing.Color.White;
            this.TextColorText.Location = new System.Drawing.Point(86, 232);
            this.TextColorText.Name = "TextColorText";
            this.TextColorText.Size = new System.Drawing.Size(90, 25);
            this.TextColorText.TabIndex = 25;
            this.TextColorText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BackColorAlt3Label
            // 
            this.BackColorAlt3Label.AutoSize = true;
            this.BackColorAlt3Label.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackColorAlt3Label.ForeColor = System.Drawing.Color.White;
            this.BackColorAlt3Label.Location = new System.Drawing.Point(15, 169);
            this.BackColorAlt3Label.Name = "BackColorAlt3Label";
            this.BackColorAlt3Label.Size = new System.Drawing.Size(61, 26);
            this.BackColorAlt3Label.TabIndex = 28;
            this.BackColorAlt3Label.Text = "Back Color\r\nAlt 3";
            this.BackColorAlt3Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackColorAlt3Text
            // 
            this.BackColorAlt3Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BackColorAlt3Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackColorAlt3Text.Cursor = System.Windows.Forms.Cursors.Default;
            this.BackColorAlt3Text.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackColorAlt3Text.ForeColor = System.Drawing.Color.White;
            this.BackColorAlt3Text.Location = new System.Drawing.Point(86, 170);
            this.BackColorAlt3Text.Name = "BackColorAlt3Text";
            this.BackColorAlt3Text.Size = new System.Drawing.Size(90, 25);
            this.BackColorAlt3Text.TabIndex = 27;
            this.BackColorAlt3Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(532, 319);
            this.Controls.Add(this.BackColorAlt3Label);
            this.Controls.Add(this.BackColorAlt3Text);
            this.Controls.Add(this.TextColorLabel);
            this.Controls.Add(this.TextColorText);
            this.Controls.Add(this.PanelColorLabel);
            this.Controls.Add(this.PanelColorText);
            this.Controls.Add(this.BackColorAlt2Label);
            this.Controls.Add(this.BackColorAlt2Text);
            this.Controls.Add(this.BackColorAltLabel);
            this.Controls.Add(this.BackColorAltText);
            this.Controls.Add(this.BackColorLabel);
            this.Controls.Add(this.SaveThemeButton);
            this.Controls.Add(this.BrowseBackgroundImageButton);
            this.Controls.Add(this.BackgroundImageLabel);
            this.Controls.Add(this.BackColorText);
            this.Controls.Add(this.MovePanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "options";
            this.ShowInTaskbar = false;
            this.Text = "Guac";
            this.Load += new System.EventHandler(this.options_Load);
            this.MovePanel.ResumeLayout(false);
            this.MovePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MovePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.TextBox BackColorText;
        private System.Windows.Forms.Label BackgroundImageLabel;
        private System.Windows.Forms.Button BrowseBackgroundImageButton;
        private System.Windows.Forms.Button SaveThemeButton;
        private System.Windows.Forms.Label BackColorLabel;
        private System.Windows.Forms.Label BackColorAltLabel;
        private System.Windows.Forms.TextBox BackColorAltText;
        private System.Windows.Forms.Label BackColorAlt2Label;
        private System.Windows.Forms.TextBox BackColorAlt2Text;
        private System.Windows.Forms.Label PanelColorLabel;
        private System.Windows.Forms.TextBox PanelColorText;
        private System.Windows.Forms.Label TextColorLabel;
        private System.Windows.Forms.TextBox TextColorText;
        private System.Windows.Forms.Label BackColorAlt3Label;
        private System.Windows.Forms.TextBox BackColorAlt3Text;
    }
}