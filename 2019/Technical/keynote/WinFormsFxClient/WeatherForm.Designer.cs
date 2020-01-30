using System.Drawing;

namespace WeatherWinFormsFx
{
    partial class WeatherForm
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
            this.WeatherIcon = new System.Windows.Forms.PictureBox();
            this.Temperature = new System.Windows.Forms.Label();
            this.GradLabel = new System.Windows.Forms.Label();
            this.PressureLabel = new System.Windows.Forms.Label();
            this.Pressure = new System.Windows.Forms.Label();
            this.Humidity = new System.Windows.Forms.Label();
            this.HumidityLabel = new System.Windows.Forms.Label();
            this.Wind = new System.Windows.Forms.Label();
            this.WindLabel = new System.Windows.Forms.Label();
            this.Updated = new System.Windows.Forms.Label();
            this.WeatherText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.City = new System.Windows.Forms.Label();
            this.CollapseExpandButton = new System.Windows.Forms.Button();
            this.UVIndex = new System.Windows.Forms.Label();
            this.UVIndexLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WeatherIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // WeatherIcon
            // 
            this.WeatherIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(68)))), ((int)(((byte)(128)))));
            this.WeatherIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WeatherIcon.ErrorImage = null;
            this.WeatherIcon.InitialImage = null;
            this.WeatherIcon.Location = new System.Drawing.Point(43, 114);
            this.WeatherIcon.Margin = new System.Windows.Forms.Padding(4);
            this.WeatherIcon.Name = "WeatherIcon";
            this.WeatherIcon.Size = new System.Drawing.Size(200, 111);
            this.WeatherIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WeatherIcon.TabIndex = 0;
            this.WeatherIcon.TabStop = false;
            // 
            // Temperature
            // 
            this.Temperature.Font = new System.Drawing.Font("Segoe UI", 92.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Temperature.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Temperature.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Temperature.Location = new System.Drawing.Point(53, 49);
            this.Temperature.Margin = new System.Windows.Forms.Padding(0);
            this.Temperature.Name = "Temperature";
            this.Temperature.Size = new System.Drawing.Size(445, 177);
            this.Temperature.TabIndex = 2;
            this.Temperature.Text = "71";
            this.Temperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GradLabel
            // 
            this.GradLabel.AutoSize = true;
            this.GradLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GradLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GradLabel.Location = new System.Drawing.Point(448, 94);
            this.GradLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GradLabel.Name = "GradLabel";
            this.GradLabel.Size = new System.Drawing.Size(23, 25);
            this.GradLabel.TabIndex = 3;
            this.GradLabel.Text = "o";
            // 
            // PressureLabel
            // 
            this.PressureLabel.AutoSize = true;
            this.PressureLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PressureLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PressureLabel.Location = new System.Drawing.Point(117, 386);
            this.PressureLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PressureLabel.Name = "PressureLabel";
            this.PressureLabel.Size = new System.Drawing.Size(84, 25);
            this.PressureLabel.TabIndex = 4;
            this.PressureLabel.Text = "Pressure";
            this.PressureLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Pressure
            // 
            this.Pressure.AutoSize = true;
            this.Pressure.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pressure.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Pressure.Location = new System.Drawing.Point(245, 386);
            this.Pressure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Pressure.Name = "Pressure";
            this.Pressure.Size = new System.Drawing.Size(53, 25);
            this.Pressure.TabIndex = 5;
            this.Pressure.Text = "32 in";
            // 
            // Humidity
            // 
            this.Humidity.AutoSize = true;
            this.Humidity.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Humidity.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Humidity.Location = new System.Drawing.Point(245, 433);
            this.Humidity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Humidity.Name = "Humidity";
            this.Humidity.Size = new System.Drawing.Size(53, 25);
            this.Humidity.TabIndex = 7;
            this.Humidity.Text = "45 %";
            // 
            // HumidityLabel
            // 
            this.HumidityLabel.AutoSize = true;
            this.HumidityLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HumidityLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HumidityLabel.Location = new System.Drawing.Point(112, 433);
            this.HumidityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HumidityLabel.Name = "HumidityLabel";
            this.HumidityLabel.Size = new System.Drawing.Size(88, 25);
            this.HumidityLabel.TabIndex = 6;
            this.HumidityLabel.Text = "Humidity";
            // 
            // Wind
            // 
            this.Wind.AutoSize = true;
            this.Wind.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wind.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Wind.Location = new System.Drawing.Point(245, 482);
            this.Wind.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Wind.Name = "Wind";
            this.Wind.Size = new System.Drawing.Size(79, 25);
            this.Wind.TabIndex = 9;
            this.Wind.Text = "4.9 mph";
            // 
            // WindLabel
            // 
            this.WindLabel.AutoSize = true;
            this.WindLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.WindLabel.Location = new System.Drawing.Point(80, 482);
            this.WindLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WindLabel.Name = "WindLabel";
            this.WindLabel.Size = new System.Drawing.Size(112, 25);
            this.WindLabel.TabIndex = 8;
            this.WindLabel.Text = "Wind speed";
            // 
            // Updated
            // 
            this.Updated.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Updated.ForeColor = System.Drawing.Color.SpringGreen;
            this.Updated.Location = new System.Drawing.Point(21, 286);
            this.Updated.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Updated.Name = "Updated";
            this.Updated.Size = new System.Drawing.Size(437, 42);
            this.Updated.TabIndex = 11;
            this.Updated.Text = "Updated at 12:36:11 AM";
            this.Updated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WeatherText
            // 
            this.WeatherText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(68)))), ((int)(((byte)(128)))));
            this.WeatherText.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeatherText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.WeatherText.Location = new System.Drawing.Point(21, 217);
            this.WeatherText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WeatherText.Name = "WeatherText";
            this.WeatherText.Size = new System.Drawing.Size(437, 62);
            this.WeatherText.TabIndex = 12;
            this.WeatherText.Text = "Sunny";
            this.WeatherText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(54)))), ((int)(((byte)(170)))));
            this.label1.Location = new System.Drawing.Point(-12, 375);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(507, 47);
            this.label1.TabIndex = 13;
            this.label1.Text = "Powered by .NET with 💜";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // City
            // 
            this.City.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.City.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.City.Location = new System.Drawing.Point(21, 11);
            this.City.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(437, 59);
            this.City.TabIndex = 14;
            this.City.Text = "Redmond";
            this.City.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CollapseExpandButton
            // 
            this.CollapseExpandButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CollapseExpandButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(68)))), ((int)(((byte)(128)))));
            this.CollapseExpandButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CollapseExpandButton.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CollapseExpandButton.ForeColor = System.Drawing.Color.White;
            this.CollapseExpandButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CollapseExpandButton.Location = new System.Drawing.Point(-12, 336);
            this.CollapseExpandButton.Margin = new System.Windows.Forms.Padding(4);
            this.CollapseExpandButton.Name = "CollapseExpandButton";
            this.CollapseExpandButton.Size = new System.Drawing.Size(507, 41);
            this.CollapseExpandButton.TabIndex = 15;
            this.CollapseExpandButton.Text = "ꓦ";
            this.CollapseExpandButton.UseVisualStyleBackColor = true;
            this.CollapseExpandButton.Click += new System.EventHandler(this.CollapseExpandButton_Click);
            // 
            // UVIndex
            // 
            this.UVIndex.AutoSize = true;
            this.UVIndex.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UVIndex.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UVIndex.Location = new System.Drawing.Point(245, 532);
            this.UVIndex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UVIndex.Name = "UVIndex";
            this.UVIndex.Size = new System.Drawing.Size(22, 25);
            this.UVIndex.TabIndex = 18;
            this.UVIndex.Text = "4";
            // 
            // UVIndexLabel
            // 
            this.UVIndexLabel.AutoSize = true;
            this.UVIndexLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UVIndexLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UVIndexLabel.Location = new System.Drawing.Point(112, 532);
            this.UVIndexLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UVIndexLabel.Name = "UVIndexLabel";
            this.UVIndexLabel.Size = new System.Drawing.Size(88, 25);
            this.UVIndexLabel.TabIndex = 17;
            this.UVIndexLabel.Text = "UV index";
            // 
            // WeatherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(68)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(484, 421);
            this.Controls.Add(this.WeatherIcon);
            this.Controls.Add(this.UVIndex);
            this.Controls.Add(this.UVIndexLabel);
            this.Controls.Add(this.WeatherText);
            this.Controls.Add(this.CollapseExpandButton);
            this.Controls.Add(this.City);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Updated);
            this.Controls.Add(this.Wind);
            this.Controls.Add(this.WindLabel);
            this.Controls.Add(this.Humidity);
            this.Controls.Add(this.HumidityLabel);
            this.Controls.Add(this.Pressure);
            this.Controls.Add(this.PressureLabel);
            this.Controls.Add(this.GradLabel);
            this.Controls.Add(this.Temperature);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 460);
            this.Name = "WeatherForm";
            this.Text = "Weather Now";
            ((System.ComponentModel.ISupportInitialize)(this.WeatherIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox WeatherIcon;
        private System.Windows.Forms.Label Temperature;
        private System.Windows.Forms.Label GradLabel;
        private System.Windows.Forms.Label PressureLabel;
        private System.Windows.Forms.Label Pressure;
        private System.Windows.Forms.Label Humidity;
        private System.Windows.Forms.Label HumidityLabel;
        private System.Windows.Forms.Label Wind;
        private System.Windows.Forms.Label WindLabel;
        private System.Windows.Forms.Label Updated;
        private System.Windows.Forms.Label WeatherText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label City;
        private System.Windows.Forms.Button CollapseExpandButton;
        private System.Windows.Forms.Label UVIndex;
        private System.Windows.Forms.Label UVIndexLabel;
    }
}

