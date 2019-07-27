namespace Algorithms_Performance_Visualizer.Views {
    partial class SmPreprocessingView {
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
            this.seriesRK = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesFASM = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesKMP = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesBM = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.SuspendLayout();
            // 
            // chartControl
            // 
            this.chartControl.Series.Add(this.seriesRK);
            this.chartControl.Series.Add(this.seriesFASM);
            this.chartControl.Series.Add(this.seriesKMP);
            this.chartControl.Series.Add(this.seriesBM);
            // 
            // seriesRK
            // 
            this.seriesRK.Color = System.Drawing.Color.Red;
            this.seriesRK.Label = "Rabin-Karp";
            // 
            // seriesFASM
            // 
            this.seriesFASM.Color = System.Drawing.Color.Black;
            this.seriesFASM.Label = "FA";
            // 
            // seriesKMP
            // 
            this.seriesKMP.Color = System.Drawing.Color.Blue;
            this.seriesKMP.Label = "KMP";
            // 
            // seriesBM
            // 
            this.seriesBM.Color = System.Drawing.Color.Lime;
            this.seriesBM.Label = "Boyer-Moore";
            // 
            // SmPreprocessingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "SmPreprocessingView";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ChartSeries seriesRK;
        private Controls.ChartSeries seriesFASM;
        private Controls.ChartSeries seriesKMP;
        private Controls.ChartSeries seriesBM;
    }
}
