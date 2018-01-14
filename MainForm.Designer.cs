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
            this.tabControl.SuspendLayout();
            this.tabSorting.SuspendLayout();
            this.tabSearching.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSorting);
            this.tabControl.Controls.Add(this.tabSearching);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSorting;
        private Views.SortingView sortingView1;
        private System.Windows.Forms.TabPage tabSearching;
        private Views.SearchingView searchingView;
    }
}

