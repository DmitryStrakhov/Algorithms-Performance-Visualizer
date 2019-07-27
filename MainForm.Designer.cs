namespace Algorithms_Performance_Visualizer {
    partial class MainForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSorting = new System.Windows.Forms.TabPage();
            this.sortingView1 = new Algorithms_Performance_Visualizer.Views.SortingView();
            this.tabSearching = new System.Windows.Forms.TabPage();
            this.searchingView = new Algorithms_Performance_Visualizer.Views.SearchingView();
            this.tabSelection = new System.Windows.Forms.TabPage();
            this.selectionView1 = new Algorithms_Performance_Visualizer.Views.SelectionView();
            this.tabHashMap = new System.Windows.Forms.TabPage();
            this.hashMapView1 = new Algorithms_Performance_Visualizer.Views.HashMapView();
            this.tabStringMatching = new System.Windows.Forms.TabPage();
            this.stringMatchingView = new Algorithms_Performance_Visualizer.Views.StringMatchingView();
            this.tabControl.SuspendLayout();
            this.tabSorting.SuspendLayout();
            this.tabSearching.SuspendLayout();
            this.tabSelection.SuspendLayout();
            this.tabHashMap.SuspendLayout();
            this.tabStringMatching.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSorting);
            this.tabControl.Controls.Add(this.tabSearching);
            this.tabControl.Controls.Add(this.tabSelection);
            this.tabControl.Controls.Add(this.tabHashMap);
            this.tabControl.Controls.Add(this.tabStringMatching);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1210, 607);
            this.tabControl.TabIndex = 0;
            // 
            // tabSorting
            // 
            this.tabSorting.Controls.Add(this.sortingView1);
            this.tabSorting.Location = new System.Drawing.Point(4, 22);
            this.tabSorting.Name = "tabSorting";
            this.tabSorting.Padding = new System.Windows.Forms.Padding(3);
            this.tabSorting.Size = new System.Drawing.Size(1202, 581);
            this.tabSorting.TabIndex = 0;
            this.tabSorting.Text = "Sorting";
            this.tabSorting.UseVisualStyleBackColor = true;
            // 
            // sortingView1
            // 
            this.sortingView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortingView1.Location = new System.Drawing.Point(3, 3);
            this.sortingView1.Name = "sortingView1";
            this.sortingView1.Size = new System.Drawing.Size(1196, 575);
            this.sortingView1.TabIndex = 0;
            // 
            // tabSearching
            // 
            this.tabSearching.Controls.Add(this.searchingView);
            this.tabSearching.Location = new System.Drawing.Point(4, 22);
            this.tabSearching.Name = "tabSearching";
            this.tabSearching.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearching.Size = new System.Drawing.Size(1202, 581);
            this.tabSearching.TabIndex = 1;
            this.tabSearching.Text = "Searching";
            this.tabSearching.UseVisualStyleBackColor = true;
            // 
            // searchingView
            // 
            this.searchingView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchingView.Location = new System.Drawing.Point(3, 3);
            this.searchingView.Name = "searchingView";
            this.searchingView.Size = new System.Drawing.Size(1196, 575);
            this.searchingView.TabIndex = 0;
            // 
            // tabSelection
            // 
            this.tabSelection.Controls.Add(this.selectionView1);
            this.tabSelection.Location = new System.Drawing.Point(4, 22);
            this.tabSelection.Name = "tabSelection";
            this.tabSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tabSelection.Size = new System.Drawing.Size(1202, 581);
            this.tabSelection.TabIndex = 2;
            this.tabSelection.Text = "Selection";
            this.tabSelection.UseVisualStyleBackColor = true;
            // 
            // selectionView1
            // 
            this.selectionView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionView1.Location = new System.Drawing.Point(3, 3);
            this.selectionView1.Name = "selectionView1";
            this.selectionView1.Size = new System.Drawing.Size(1196, 575);
            this.selectionView1.TabIndex = 0;
            // 
            // tabHashMap
            // 
            this.tabHashMap.Controls.Add(this.hashMapView1);
            this.tabHashMap.Location = new System.Drawing.Point(4, 22);
            this.tabHashMap.Name = "tabHashMap";
            this.tabHashMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabHashMap.Size = new System.Drawing.Size(1202, 581);
            this.tabHashMap.TabIndex = 3;
            this.tabHashMap.Text = "HashMap";
            this.tabHashMap.UseVisualStyleBackColor = true;
            // 
            // hashMapView1
            // 
            this.hashMapView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hashMapView1.Location = new System.Drawing.Point(3, 3);
            this.hashMapView1.Name = "hashMapView1";
            this.hashMapView1.Size = new System.Drawing.Size(1196, 575);
            this.hashMapView1.TabIndex = 0;
            // 
            // tabStringMatching
            // 
            this.tabStringMatching.Controls.Add(this.stringMatchingView);
            this.tabStringMatching.Location = new System.Drawing.Point(4, 22);
            this.tabStringMatching.Name = "tabStringMatching";
            this.tabStringMatching.Padding = new System.Windows.Forms.Padding(3);
            this.tabStringMatching.Size = new System.Drawing.Size(1202, 581);
            this.tabStringMatching.TabIndex = 4;
            this.tabStringMatching.Text = "String Matching";
            this.tabStringMatching.UseVisualStyleBackColor = true;
            // 
            // stringMatchingView
            // 
            this.stringMatchingView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stringMatchingView.Location = new System.Drawing.Point(3, 3);
            this.stringMatchingView.Name = "stringMatchingView";
            this.stringMatchingView.Size = new System.Drawing.Size(1196, 575);
            this.stringMatchingView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 607);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algorithms Performance Visualizer";
            this.tabControl.ResumeLayout(false);
            this.tabSorting.ResumeLayout(false);
            this.tabSearching.ResumeLayout(false);
            this.tabSelection.ResumeLayout(false);
            this.tabHashMap.ResumeLayout(false);
            this.tabStringMatching.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSorting;
        private Views.SortingView sortingView1;
        private System.Windows.Forms.TabPage tabSearching;
        private Views.SearchingView searchingView;
        private System.Windows.Forms.TabPage tabSelection;
        private Views.SelectionView selectionView1;
        private System.Windows.Forms.TabPage tabHashMap;
        private Views.HashMapView hashMapView1;
        private System.Windows.Forms.TabPage tabStringMatching;
        private Views.StringMatchingView stringMatchingView;
    }
}

