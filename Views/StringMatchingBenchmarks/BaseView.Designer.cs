namespace Algorithms_Performance_Visualizer.Views {
    partial class StringMatchingBenchmarkViewBase {
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
            this.chartControl = new Algorithms_Performance_Visualizer.Controls.ChartControl();
            this.SuspendLayout();
            // 
            // chartControl
            // 
            this.chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl.GridDensity = Algorithms_Performance_Visualizer.Controls.ChartGridDensity.Dense;
            this.chartControl.DrawBorder = false;
            this.chartControl.LegendSpacing = 8;
            this.chartControl.LegendWidth = 100;
            this.chartControl.Location = new System.Drawing.Point(0, 0);
            this.chartControl.Name = "chartControl";
            this.chartControl.PointSize = new System.Drawing.Size(5, 5);
            this.chartControl.Size = new System.Drawing.Size(600, 400);
            this.chartControl.TabIndex = 1;
            // 
            // StringMatchingBenchmarkViewBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartControl);
            this.Name = "StringMatchingBenchmarkViewBase";
            this.Size = new System.Drawing.Size(600, 400);
            this.ResumeLayout(false);

        }

        #endregion

        protected Controls.ChartControl chartControl;
    }
}
