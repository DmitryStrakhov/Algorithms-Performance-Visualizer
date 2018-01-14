﻿namespace Algorithms_Performance_Visualizer.Views {
    partial class SearchingView {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.chartControl = new Algorithms_Performance_Visualizer.Controls.ChartControl();
            this.seriesBinarySearch = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesSearch = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.commandPanel = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.progressLabel = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.commandPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.chartControl);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.commandPanel);
            this.splitContainer.Size = new System.Drawing.Size(1041, 551);
            this.splitContainer.SplitterDistance = 495;
            this.splitContainer.TabIndex = 0;
            // 
            // chartControl
            // 
            this.chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl.GridDensity = Algorithms_Performance_Visualizer.Controls.ChartGridDensity.Dense;
            this.chartControl.LegendSpacing = 8;
            this.chartControl.LegendWidth = 120;
            this.chartControl.Location = new System.Drawing.Point(0, 0);
            this.chartControl.Name = "chartControl";
            this.chartControl.PointSize = new System.Drawing.Size(5, 5);
            this.chartControl.Series.Add(this.seriesBinarySearch);
            this.chartControl.Series.Add(this.seriesSearch);
            this.chartControl.Size = new System.Drawing.Size(1039, 493);
            this.chartControl.TabIndex = 0;
            this.chartControl.Text = "chartControl";
            // 
            // seriesBinarySearch
            // 
            this.seriesBinarySearch.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.seriesBinarySearch.Label = "Binary Search";
            // 
            // seriesSearch
            // 
            this.seriesSearch.Color = System.Drawing.Color.Black;
            this.seriesSearch.Label = "Search";
            // 
            // commandPanel
            // 
            this.commandPanel.Controls.Add(this.btnStart);
            this.commandPanel.Controls.Add(this.progressLabel);
            this.commandPanel.Controls.Add(this.btnClear);
            this.commandPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandPanel.Location = new System.Drawing.Point(0, 0);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(1039, 50);
            this.commandPanel.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(3, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.OnStartButtonClick);
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(210, 17);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(53, 13);
            this.progressLabel.TabIndex = 2;
            this.progressLabel.Text = "(progress)";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(84, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Cleart Chart";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.OnClearChartButtonClick);
            // 
            // SearchingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "SearchingView";
            this.Size = new System.Drawing.Size(1041, 551);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.commandPanel.ResumeLayout(false);
            this.commandPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStart;
        private Controls.ChartControl chartControl;
        private System.Windows.Forms.Label progressLabel;
        private Controls.ChartSeries seriesBinarySearch;
        private Controls.ChartSeries seriesSearch;
        private System.Windows.Forms.Panel commandPanel;
    }
}
