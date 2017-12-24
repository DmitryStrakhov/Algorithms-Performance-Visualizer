using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms_Performance_Visualizer.Base;
using Algorithms_Performance_Visualizer.Services;
using System.Diagnostics;
using Algorithms_Performance_Visualizer.Controls;
using Algorithms_Performance_Visualizer.Components;

namespace Algorithms_Performance_Visualizer.Views {
    public partial class SortingView : BaseUserControl {
        public SortingView() {
            InitializeComponent();
        }
        protected override BaseController CreateController() {
            return new SortingViewController();
        }
        protected override void Bind() {
            base.Bind();
            this.bubbleSortCheckBox.Bind("Checked", Controller, "AllowBubbleSort");
            this.selectionSortCheckBox.Bind("Checked", Controller, "AllowSelectionSort");
            this.insertionSortCheckBox.Bind("Checked", Controller, "AllowInsertionSort");
            this.shellSortCheckBox.Bind("Checked", Controller, "AllowShellSort");
            this.mergeSortCheckBox.Bind("Checked", Controller, "AllowMergeSort");
            this.heapSortCheckBox.Bind("Checked", Controller, "AllowHeapSort");
            this.quickSortCheckBox.Bind("Checked", Controller, "AllowQuickSort");
            this.treeSortCheckBox.Bind("Checked", Controller, "AllowTreeSort");
            this.countingSortCheckBox.Bind("Checked", Controller, "AllowCountingSort");
            this.bucketSortCheckBox.Bind("Checked", Controller, "AllowBucketSort");
            this.radixSortCheckBox.Bind("Checked", Controller, "AllowRadixSort");
            this.progressLabel.Bind("Text", Controller, "Progress");
            this.btnStart.Bind("Text", Controller, "State", formatDelegate: OnStartButtonFormatControllerState);
        }
        void OnStartButtonFormatControllerState(object sender, ConvertEventArgs e) {
            if(e.DesiredType != typeof(string)) return;
            SortingViewControllerState state = (SortingViewControllerState)e.Value;
            switch(state) {
                case SortingViewControllerState.Wait:
                    e.Value = "Start";
                    break;
                case SortingViewControllerState.Active:
                    e.Value = "Stop";
                    break;
                default:
                    throw new ArgumentException();
            }
        }
        async void OnStartButtonClick(object sender, EventArgs e) {
            if(Controller.State == SortingViewControllerState.Wait) {
                Controller.State = SortingViewControllerState.Active;
                await Start();
            }
            else {
                Controller.State = SortingViewControllerState.Wait;
            }
        }
        void OnClearChartButtonClick(object sender, EventArgs e) {
            this.chartControl.Series.ForEach(x => x.PointList.Clear());
        }

        async Task Start() {
            for(long arraySize = 10; Controller.IsActive; arraySize += 100) {
                SortDataItem[] data = CreateData(arraySize);
                await Measure(data);
            }
        }
        async Task Measure(SortDataItem[] data) {
            if(Controller.AllowBubbleSort) {
                await Measure(this.seriesBubbleSort, new BubbleDataSorter(), data);
            }
            if(Controller.AllowSelectionSort) {
                await Measure(this.seriesSelectionSort, new SelectionDataSorter(), data);
            }
            if(Controller.AllowInsertionSort) {
                await Measure(this.seriesInsertionSort, new InsertionDataSorter(), data);
            }
            if(Controller.AllowShellSort) {
                await Measure(this.seriesShellSort, new ShellDataSorter(), data);
            }
            if(Controller.AllowMergeSort) {
                await Measure(this.seriesMergeSort, new MergeDataSorter(), data);
            }
            if(Controller.AllowHeapSort) {
                await Measure(this.seriesHeapSort, new HeapDataSorter(), data);
            }
            if(Controller.AllowQuickSort) {
                await Measure(this.seriesQuickSort, new QuickDataSorter(), data);
            }
            if(Controller.AllowTreeSort) {
                await Measure(this.seriesTreeSort, new TreeDataSorter(), data);
            }
            if(Controller.AllowCountingSort) {
                await Measure(this.seriesCountingSort, new CountingDataSorter(0, 10000), data);
            }
            if(Controller.AllowBucketSort) {
                await Measure(this.seriesBucketSort, new BucketDataSorter(0, 10000), data);
            }
            if(Controller.AllowRadixSort) {
                await Measure(this.seriesRadixSort, new RadixDataSorter(), data);
            }
        }
        async Task Measure<TSorter>(ChartSeries chartSeries, TSorter sorter, SortDataItem[] data) where TSorter : ISorter {
            long sortTime = await Controller.Sort(sorter, CloneData(data));
            chartSeries.PointList.Add(new ChartPoint(data.Length, sortTime));
        }
        SortDataItem[] CloneData(SortDataItem[] data) {
            SortDataItem[] clonedData = new SortDataItem[data.Length];
            for(int n = 0; n < data.Length; n++) {
                clonedData[n] = data[n];
            }
            return clonedData;
        }

        SortDataItem[] CreateData(long dataSetSize) {
            SortDataItem[] data = new SortDataItem[dataSetSize];
            Random rg = new Random();
            for(int n = 0; n < data.Length; n++) {
                data[n] = new SortDataItem(rg.Next(0, 10000));
            }
            return data;
        }
        
        protected internal new SortingViewController Controller { get { return (SortingViewController)base.Controller; } }
    }

    public class SortingViewController : BaseController {
        bool allowBubbleSort;
        bool allowSelectionSort;
        bool allowInsertionSort;
        bool allowShellSort;
        bool allowMergeSort;
        bool allowHeapSort;
        bool allowQuickSort;
        bool allowTreeSort;
        bool allowCountingSort;
        bool allowBucketSort;
        bool allowRadixSort;
        string progress;
        SortingViewControllerState state;

        public SortingViewController() {
            this.state = SortingViewControllerState.Wait;
            this.allowBubbleSort = this.allowSelectionSort = this.allowInsertionSort = this.allowShellSort = this.allowMergeSort = this.allowHeapSort = this.allowQuickSort = this.allowTreeSort = this.allowCountingSort = this.allowBucketSort = this.allowRadixSort = true;
        }

        public Task<long> Sort(ISorter sorter, SortDataItem[] data) {
            if(sorter == null || data == null) {
                throw new ArgumentNullException();
            }
            Progress = $"DataSet Size: {data.Length}";
            return Task.Run(() => {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                sorter.Sort(data);
                stopWatch.Stop();
                return stopWatch.ElapsedMilliseconds;
            });
        }
        public bool AllowBubbleSort {
            get { return allowBubbleSort; }
            set {
                if(AllowBubbleSort == value)
                    return;
                allowBubbleSort = value;
                OnPropertyChanged("AllowBubbleSort");
            }
        }
        public bool AllowSelectionSort {
            get { return allowSelectionSort; }
            set {
                if(AllowSelectionSort == value)
                    return;
                allowSelectionSort = value;
                OnPropertyChanged("AllowSelectionSort");
            }
        }
        public bool AllowInsertionSort {
            get { return allowInsertionSort; }
            set {
                if(AllowInsertionSort == value)
                    return;
                allowInsertionSort = value;
                OnPropertyChanged("AllowInsertionSort");
            }
        }
        public bool AllowShellSort {
            get { return allowShellSort; }
            set {
                if(AllowShellSort == value)
                    return;
                allowShellSort = value;
                OnPropertyChanged("AllowShellSort");
            }
        }
        public bool AllowMergeSort {
            get { return allowMergeSort; }
            set {
                if(AllowMergeSort == value)
                    return;
                allowMergeSort = value;
                OnPropertyChanged("AllowMergeSort");
            }
        }
        public bool AllowHeapSort {
            get { return allowHeapSort; }
            set {
                if(AllowHeapSort == value)
                    return;
                allowHeapSort = value;
                OnPropertyChanged("AllowHeapSort");
            }
        }
        public bool AllowQuickSort {
            get { return allowQuickSort; }
            set {
                if(AllowQuickSort == value)
                    return;
                allowQuickSort = value;
                OnPropertyChanged("AllowQuickSort");
            }
        }
        public bool AllowTreeSort {
            get { return allowTreeSort; }
            set {
                if(AllowTreeSort == value)
                    return;
                allowTreeSort = value;
                OnPropertyChanged("AllowTreeSort");
            }
        }
        public bool AllowCountingSort {
            get { return allowCountingSort; }
            set {
                if(AllowCountingSort == value)
                    return;
                allowCountingSort = value;
                OnPropertyChanged("AllowCountingSort");
            }
        }
        public bool AllowBucketSort {
            get { return allowBucketSort; }
            set {
                if(AllowBucketSort == value)
                    return;
                allowBucketSort = value;
                OnPropertyChanged("AllowBucketSort");
            }
        }
        public bool AllowRadixSort {
            get { return allowRadixSort; }
            set {
                if(AllowRadixSort == value)
                    return;
                allowRadixSort = value;
                OnPropertyChanged("AllowRadixSort");
            }
        }
        public string Progress {
            get { return progress; }
            set {
                if(Progress == value)
                    return;
                progress = value;
                OnPropertyChanged("Progress");
            }
        }
        public SortingViewControllerState State {
            get { return state; }
            set {
                if(State == value)
                    return;
                state = value;
                OnPropertyChanged("State");
            }
        }
        public bool IsActive {
            get { return State == SortingViewControllerState.Active; }
        }
    }

    public enum SortingViewControllerState {
        Wait, Active
    }
}
