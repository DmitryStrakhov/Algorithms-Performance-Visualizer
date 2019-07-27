namespace Algorithms_Performance_Visualizer.Views {
    partial class StringMatchingView {
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.smPreprocessingView = new Algorithms_Performance_Visualizer.Views.SmPreprocessingView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.smSearchView = new Algorithms_Performance_Visualizer.Views.SmSearchView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.smSummaryView = new Algorithms_Performance_Visualizer.Views.SmSummaryView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.treeBuildingView = new Algorithms_Performance_Visualizer.Views.TreeBuildingView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.treeSearchView = new Algorithms_Performance_Visualizer.Views.TreeSearchView();
            this.commandPanel = new System.Windows.Forms.Panel();
            this.rbFail = new System.Windows.Forms.RadioButton();
            this.rbSuccess = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.progressLabel = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.commandPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(746, 396);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.OnTabControlSelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.smPreprocessingView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(738, 370);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ESM Preprocessing";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // smPreprocessingView
            // 
            this.smPreprocessingView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smPreprocessingView.Location = new System.Drawing.Point(3, 3);
            this.smPreprocessingView.Name = "smPreprocessingView";
            this.smPreprocessingView.Size = new System.Drawing.Size(732, 364);
            this.smPreprocessingView.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.smSearchView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(738, 370);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ESM Search";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // smSearchView
            // 
            this.smSearchView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smSearchView.Location = new System.Drawing.Point(3, 3);
            this.smSearchView.Name = "smSearchView";
            this.smSearchView.Size = new System.Drawing.Size(732, 364);
            this.smSearchView.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.smSummaryView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(738, 370);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ESM Preprocessing & Search";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // smSummaryView
            // 
            this.smSummaryView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smSummaryView.Location = new System.Drawing.Point(3, 3);
            this.smSummaryView.Name = "smSummaryView";
            this.smSummaryView.Size = new System.Drawing.Size(732, 364);
            this.smSummaryView.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.treeBuildingView);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(738, 370);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Storage Building";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // treeBuildingView
            // 
            this.treeBuildingView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeBuildingView.Location = new System.Drawing.Point(3, 3);
            this.treeBuildingView.Name = "treeBuildingView";
            this.treeBuildingView.Size = new System.Drawing.Size(732, 364);
            this.treeBuildingView.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.treeSearchView);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(738, 370);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Search in storage";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // treeSearchView
            // 
            this.treeSearchView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSearchView.Location = new System.Drawing.Point(3, 3);
            this.treeSearchView.Name = "treeSearchView";
            this.treeSearchView.Size = new System.Drawing.Size(732, 364);
            this.treeSearchView.TabIndex = 0;
            // 
            // commandPanel
            // 
            this.commandPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.commandPanel.Controls.Add(this.rbFail);
            this.commandPanel.Controls.Add(this.rbSuccess);
            this.commandPanel.Controls.Add(this.btnStart);
            this.commandPanel.Controls.Add(this.progressLabel);
            this.commandPanel.Controls.Add(this.btnClear);
            this.commandPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandPanel.Location = new System.Drawing.Point(0, 396);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(746, 50);
            this.commandPanel.TabIndex = 4;
            // 
            // rbFail
            // 
            this.rbFail.AutoSize = true;
            this.rbFail.Location = new System.Drawing.Point(467, 13);
            this.rbFail.Name = "rbFail";
            this.rbFail.Size = new System.Drawing.Size(41, 17);
            this.rbFail.TabIndex = 4;
            this.rbFail.Text = "Fail";
            this.rbFail.UseVisualStyleBackColor = true;
            // 
            // rbSuccess
            // 
            this.rbSuccess.AutoSize = true;
            this.rbSuccess.Checked = true;
            this.rbSuccess.Location = new System.Drawing.Point(363, 13);
            this.rbSuccess.Name = "rbSuccess";
            this.rbSuccess.Size = new System.Drawing.Size(66, 17);
            this.rbSuccess.TabIndex = 3;
            this.rbSuccess.TabStop = true;
            this.rbSuccess.Text = "Success";
            this.rbSuccess.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(3, 10);
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
            this.progressLabel.Location = new System.Drawing.Point(210, 15);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(53, 13);
            this.progressLabel.TabIndex = 2;
            this.progressLabel.Text = "(progress)";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(84, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Cleart Chart";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.OnClearButtonClick);
            // 
            // StringMatchingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.commandPanel);
            this.Name = "StringMatchingView";
            this.Size = new System.Drawing.Size(746, 446);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.commandPanel.ResumeLayout(false);
            this.commandPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Panel commandPanel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button btnClear;
        private SmPreprocessingView smPreprocessingView;
        private SmSearchView smSearchView;
        private SmSummaryView smSummaryView;
        private TreeBuildingView treeBuildingView;
        private TreeSearchView treeSearchView;
        private System.Windows.Forms.RadioButton rbFail;
        private System.Windows.Forms.RadioButton rbSuccess;
    }
}
