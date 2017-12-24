namespace Algorithms_Performance_Visualizer.Views {
    partial class SortingView {
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.treeSortCheckBox = new System.Windows.Forms.CheckBox();
            this.radixSortCheckBox = new System.Windows.Forms.CheckBox();
            this.bucketSortCheckBox = new System.Windows.Forms.CheckBox();
            this.countingSortCheckBox = new System.Windows.Forms.CheckBox();
            this.quickSortCheckBox = new System.Windows.Forms.CheckBox();
            this.heapSortCheckBox = new System.Windows.Forms.CheckBox();
            this.mergeSortCheckBox = new System.Windows.Forms.CheckBox();
            this.shellSortCheckBox = new System.Windows.Forms.CheckBox();
            this.insertionSortCheckBox = new System.Windows.Forms.CheckBox();
            this.selectionSortCheckBox = new System.Windows.Forms.CheckBox();
            this.bubbleSortCheckBox = new System.Windows.Forms.CheckBox();
            this.commandPanel = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.progressLabel = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.chartControl = new Algorithms_Performance_Visualizer.Controls.ChartControl();
            this.seriesBubbleSort = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesSelectionSort = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesInsertionSort = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesShellSort = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesMergeSort = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesHeapSort = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesQuickSort = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesTreeSort = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesCountingSort = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesBucketSort = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            this.seriesRadixSort = new Algorithms_Performance_Visualizer.Controls.ChartSeries();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.commandPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.chartControl);
            this.splitContainer.Size = new System.Drawing.Size(1041, 551);
            this.splitContainer.SplitterDistance = 345;
            this.splitContainer.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.optionsPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.commandPanel);
            this.splitContainer1.Size = new System.Drawing.Size(345, 551);
            this.splitContainer1.SplitterDistance = 390;
            this.splitContainer1.TabIndex = 0;
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.treeSortCheckBox);
            this.optionsPanel.Controls.Add(this.radixSortCheckBox);
            this.optionsPanel.Controls.Add(this.bucketSortCheckBox);
            this.optionsPanel.Controls.Add(this.countingSortCheckBox);
            this.optionsPanel.Controls.Add(this.quickSortCheckBox);
            this.optionsPanel.Controls.Add(this.heapSortCheckBox);
            this.optionsPanel.Controls.Add(this.mergeSortCheckBox);
            this.optionsPanel.Controls.Add(this.shellSortCheckBox);
            this.optionsPanel.Controls.Add(this.insertionSortCheckBox);
            this.optionsPanel.Controls.Add(this.selectionSortCheckBox);
            this.optionsPanel.Controls.Add(this.bubbleSortCheckBox);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsPanel.Location = new System.Drawing.Point(0, 0);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(343, 388);
            this.optionsPanel.TabIndex = 0;
            // 
            // treeSortCheckBox
            // 
            this.treeSortCheckBox.AutoSize = true;
            this.treeSortCheckBox.Location = new System.Drawing.Point(6, 203);
            this.treeSortCheckBox.Name = "treeSortCheckBox";
            this.treeSortCheckBox.Size = new System.Drawing.Size(67, 17);
            this.treeSortCheckBox.TabIndex = 7;
            this.treeSortCheckBox.Text = "TreeSort";
            this.treeSortCheckBox.UseVisualStyleBackColor = true;
            // 
            // radixSortCheckBox
            // 
            this.radixSortCheckBox.AutoSize = true;
            this.radixSortCheckBox.Location = new System.Drawing.Point(6, 278);
            this.radixSortCheckBox.Name = "radixSortCheckBox";
            this.radixSortCheckBox.Size = new System.Drawing.Size(72, 17);
            this.radixSortCheckBox.TabIndex = 10;
            this.radixSortCheckBox.Text = "RadixSort";
            this.radixSortCheckBox.UseVisualStyleBackColor = true;
            // 
            // bucketSortCheckBox
            // 
            this.bucketSortCheckBox.AutoSize = true;
            this.bucketSortCheckBox.Location = new System.Drawing.Point(6, 253);
            this.bucketSortCheckBox.Name = "bucketSortCheckBox";
            this.bucketSortCheckBox.Size = new System.Drawing.Size(79, 17);
            this.bucketSortCheckBox.TabIndex = 9;
            this.bucketSortCheckBox.Text = "BucketSort";
            this.bucketSortCheckBox.UseVisualStyleBackColor = true;
            // 
            // countingSortCheckBox
            // 
            this.countingSortCheckBox.AutoSize = true;
            this.countingSortCheckBox.Location = new System.Drawing.Point(6, 228);
            this.countingSortCheckBox.Name = "countingSortCheckBox";
            this.countingSortCheckBox.Size = new System.Drawing.Size(87, 17);
            this.countingSortCheckBox.TabIndex = 8;
            this.countingSortCheckBox.Text = "CountingSort";
            this.countingSortCheckBox.UseVisualStyleBackColor = true;
            // 
            // quickSortCheckBox
            // 
            this.quickSortCheckBox.AutoSize = true;
            this.quickSortCheckBox.Location = new System.Drawing.Point(6, 178);
            this.quickSortCheckBox.Name = "quickSortCheckBox";
            this.quickSortCheckBox.Size = new System.Drawing.Size(73, 17);
            this.quickSortCheckBox.TabIndex = 6;
            this.quickSortCheckBox.Text = "QuickSort";
            this.quickSortCheckBox.UseVisualStyleBackColor = true;
            // 
            // heapSortCheckBox
            // 
            this.heapSortCheckBox.AutoSize = true;
            this.heapSortCheckBox.Location = new System.Drawing.Point(6, 153);
            this.heapSortCheckBox.Name = "heapSortCheckBox";
            this.heapSortCheckBox.Size = new System.Drawing.Size(71, 17);
            this.heapSortCheckBox.TabIndex = 5;
            this.heapSortCheckBox.Text = "HeapSort";
            this.heapSortCheckBox.UseVisualStyleBackColor = true;
            // 
            // mergeSortCheckBox
            // 
            this.mergeSortCheckBox.AutoSize = true;
            this.mergeSortCheckBox.Location = new System.Drawing.Point(6, 128);
            this.mergeSortCheckBox.Name = "mergeSortCheckBox";
            this.mergeSortCheckBox.Size = new System.Drawing.Size(75, 17);
            this.mergeSortCheckBox.TabIndex = 4;
            this.mergeSortCheckBox.Text = "MergeSort";
            this.mergeSortCheckBox.UseVisualStyleBackColor = true;
            // 
            // shellSortCheckBox
            // 
            this.shellSortCheckBox.AutoSize = true;
            this.shellSortCheckBox.Location = new System.Drawing.Point(6, 103);
            this.shellSortCheckBox.Name = "shellSortCheckBox";
            this.shellSortCheckBox.Size = new System.Drawing.Size(68, 17);
            this.shellSortCheckBox.TabIndex = 3;
            this.shellSortCheckBox.Text = "ShellSort";
            this.shellSortCheckBox.UseVisualStyleBackColor = true;
            // 
            // insertionSortCheckBox
            // 
            this.insertionSortCheckBox.AutoSize = true;
            this.insertionSortCheckBox.Location = new System.Drawing.Point(6, 78);
            this.insertionSortCheckBox.Name = "insertionSortCheckBox";
            this.insertionSortCheckBox.Size = new System.Drawing.Size(85, 17);
            this.insertionSortCheckBox.TabIndex = 2;
            this.insertionSortCheckBox.Text = "InsertionSort";
            this.insertionSortCheckBox.UseVisualStyleBackColor = true;
            // 
            // selectionSortCheckBox
            // 
            this.selectionSortCheckBox.AutoSize = true;
            this.selectionSortCheckBox.Location = new System.Drawing.Point(6, 53);
            this.selectionSortCheckBox.Name = "selectionSortCheckBox";
            this.selectionSortCheckBox.Size = new System.Drawing.Size(89, 17);
            this.selectionSortCheckBox.TabIndex = 1;
            this.selectionSortCheckBox.Text = "SelectionSort";
            this.selectionSortCheckBox.UseVisualStyleBackColor = true;
            // 
            // bubbleSortCheckBox
            // 
            this.bubbleSortCheckBox.AutoSize = true;
            this.bubbleSortCheckBox.Location = new System.Drawing.Point(6, 28);
            this.bubbleSortCheckBox.Name = "bubbleSortCheckBox";
            this.bubbleSortCheckBox.Size = new System.Drawing.Size(78, 17);
            this.bubbleSortCheckBox.TabIndex = 0;
            this.bubbleSortCheckBox.Text = "BubbleSort";
            this.bubbleSortCheckBox.UseVisualStyleBackColor = true;
            // 
            // commandPanel
            // 
            this.commandPanel.Controls.Add(this.btnClear);
            this.commandPanel.Controls.Add(this.progressLabel);
            this.commandPanel.Controls.Add(this.btnStart);
            this.commandPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandPanel.Location = new System.Drawing.Point(0, 0);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(343, 155);
            this.commandPanel.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(86, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear Chart";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.OnClearChartButtonClick);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(3, 62);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(53, 13);
            this.progressLabel.TabIndex = 0;
            this.progressLabel.Text = "(progress)";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(5, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.OnStartButtonClick);
            // 
            // chartControl
            // 
            this.chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl.LegendSpacing = 8;
            this.chartControl.LegendWidth = 135;
            this.chartControl.Location = new System.Drawing.Point(0, 0);
            this.chartControl.Name = "chartControl";
            this.chartControl.PointSize = new System.Drawing.Size(5, 5);
            this.chartControl.Series.Add(this.seriesBubbleSort);
            this.chartControl.Series.Add(this.seriesSelectionSort);
            this.chartControl.Series.Add(this.seriesInsertionSort);
            this.chartControl.Series.Add(this.seriesShellSort);
            this.chartControl.Series.Add(this.seriesMergeSort);
            this.chartControl.Series.Add(this.seriesHeapSort);
            this.chartControl.Series.Add(this.seriesQuickSort);
            this.chartControl.Series.Add(this.seriesTreeSort);
            this.chartControl.Series.Add(this.seriesCountingSort);
            this.chartControl.Series.Add(this.seriesBucketSort);
            this.chartControl.Series.Add(this.seriesRadixSort);
            this.chartControl.Size = new System.Drawing.Size(692, 551);
            this.chartControl.TabIndex = 0;
            this.chartControl.Text = "chartControl1";
            // 
            // seriesBubbleSort
            // 
            this.seriesBubbleSort.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.seriesBubbleSort.Label = "Bubble Sort";
            // 
            // seriesSelectionSort
            // 
            this.seriesSelectionSort.Color = System.Drawing.Color.Yellow;
            this.seriesSelectionSort.Label = "Selection Sort";
            // 
            // seriesInsertionSort
            // 
            this.seriesInsertionSort.Color = System.Drawing.Color.Aqua;
            this.seriesInsertionSort.Label = "Insertion Sort";
            // 
            // seriesShellSort
            // 
            this.seriesShellSort.Color = System.Drawing.Color.Olive;
            this.seriesShellSort.Label = "Shell Sort";
            // 
            // seriesMergeSort
            // 
            this.seriesMergeSort.Color = System.Drawing.Color.Red;
            this.seriesMergeSort.Label = "Merge Sort";
            // 
            // seriesHeapSort
            // 
            this.seriesHeapSort.Color = System.Drawing.Color.Black;
            this.seriesHeapSort.Label = "Heap Sort";
            // 
            // seriesQuickSort
            // 
            this.seriesQuickSort.Color = System.Drawing.Color.Blue;
            this.seriesQuickSort.Label = "Quick Sort";
            // 
            // seriesTreeSort
            // 
            this.seriesTreeSort.Color = System.Drawing.Color.Fuchsia;
            this.seriesTreeSort.Label = "Tree Sort";
            // 
            // seriesCountingSort
            // 
            this.seriesCountingSort.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.seriesCountingSort.Label = "Counting Sort";
            // 
            // seriesBucketSort
            // 
            this.seriesBucketSort.Color = System.Drawing.Color.Lime;
            this.seriesBucketSort.Label = "Bucket Sort";
            // 
            // seriesRadixSort
            // 
            this.seriesRadixSort.Color = System.Drawing.Color.Teal;
            this.seriesRadixSort.Label = "Radix Sort";
            // 
            // SortingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "SortingView";
            this.Size = new System.Drawing.Size(1041, 551);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            this.commandPanel.ResumeLayout(false);
            this.commandPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private Controls.ChartControl chartControl;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Panel commandPanel;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox treeSortCheckBox;
        private System.Windows.Forms.CheckBox radixSortCheckBox;
        private System.Windows.Forms.CheckBox bucketSortCheckBox;
        private System.Windows.Forms.CheckBox countingSortCheckBox;
        private System.Windows.Forms.CheckBox quickSortCheckBox;
        private System.Windows.Forms.CheckBox heapSortCheckBox;
        private System.Windows.Forms.CheckBox mergeSortCheckBox;
        private System.Windows.Forms.CheckBox shellSortCheckBox;
        private System.Windows.Forms.CheckBox insertionSortCheckBox;
        private System.Windows.Forms.CheckBox selectionSortCheckBox;
        private System.Windows.Forms.CheckBox bubbleSortCheckBox;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.ChartSeries seriesBubbleSort;
        private Controls.ChartSeries seriesSelectionSort;
        private Controls.ChartSeries seriesInsertionSort;
        private Controls.ChartSeries seriesShellSort;
        private Controls.ChartSeries seriesMergeSort;
        private Controls.ChartSeries seriesHeapSort;
        private Controls.ChartSeries seriesQuickSort;
        private Controls.ChartSeries seriesTreeSort;
        private Controls.ChartSeries seriesCountingSort;
        private Controls.ChartSeries seriesBucketSort;
        private Controls.ChartSeries seriesRadixSort;
    }
}
