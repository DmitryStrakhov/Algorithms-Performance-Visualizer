namespace Algorithms_Performance_Visualizer.Views {
    partial class TreeSearchView {
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
            this.seriesTrie = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesTST = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesST = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.SuspendLayout();
            // 
            // chartControl
            // 
            this.chartControl.Series.Add(this.seriesTrie);
            this.chartControl.Series.Add(this.seriesTST);
            this.chartControl.Series.Add(this.seriesST);
            // 
            // seriesTrie
            // 
            this.seriesTrie.Color = System.Drawing.Color.Black;
            this.seriesTrie.Label = "Tries";
            // 
            // seriesTST
            // 
            this.seriesTST.Color = System.Drawing.Color.Red;
            this.seriesTST.Label = "TST";
            // 
            // seriesST
            // 
            this.seriesST.Color = System.Drawing.Color.Blue;
            this.seriesST.Label = "Suffix Tree";
            // 
            // TreeSearchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TreeSearchView";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ChartSeries seriesTrie;
        private Controls.ChartSeries seriesTST;
        private Controls.ChartSeries seriesST;
    }
}
