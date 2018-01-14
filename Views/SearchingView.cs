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
using Algorithms_Performance_Visualizer.Data;
using Algorithms_Performance_Visualizer.Controls;
using System.Diagnostics;
using Data_Structures_and_Algorithms;

namespace Algorithms_Performance_Visualizer.Views {
    public partial class SearchingView : BaseUserControl {
        public SearchingView() {
            InitializeComponent();
        }
        protected override BaseController CreateController() {
            return new SearchingViewController();
        }
        protected override void Bind() {
            base.Bind();
            this.progressLabel.Bind("Text", Controller, "Progress");
            this.btnStart.Bind("Text", Controller, "State", formatDelegate: OnStartButtonFormatControllerState);
        }
        void OnStartButtonFormatControllerState(object sender, ConvertEventArgs e) {
            if(e.DesiredType != typeof(string)) return;
            ControllerState state = (ControllerState)e.Value;
            switch(state) {
                case ControllerState.Wait:
                    e.Value = "Start";
                    break;
                case ControllerState.Active:
                    e.Value = "Stop";
                    break;
                default:
                    throw new ArgumentException();
            }
        }
        async void OnStartButtonClick(object sender, EventArgs e) {
            if(Controller.State == ControllerState.Wait) {
                Controller.State = ControllerState.Active;
                await Start();
            }
            else {
                Controller.State = ControllerState.Wait;
            }
        }
        void OnClearChartButtonClick(object sender, EventArgs e) {
            this.chartControl.Series.ForEach(x => x.PointList.Clear());
        }
        async Task Start() {
            Random rg = new Random();
            for(long arraySize = 10; Controller.IsActive; arraySize += 1000) {
                DataItem[] data = CreateData(arraySize);
                int key = data[rg.Next(0, data.Length)].Key;
                await Measure(data, key);
            }
        }
        async Task Measure(DataItem[] data, int key) {
            long time = await Controller.Search(data, key);
            this.seriesSearch.PointList.Add(new ChartPoint(data.Length, time));
            time = await Controller.BinarySearch(data, key);
            this.seriesBinarySearch.PointList.Add(new ChartPoint(data.Length, time));
        }
        static DataItem[] CreateData(long dataSetSize) {
            DataItem[] data = new DataItem[dataSetSize];
            for(int n = 0; n < dataSetSize; n++) {
                data[n] = new DataItem(n);
            }
            return data;
        }
        protected internal new SearchingViewController Controller { get { return (SearchingViewController)base.Controller; } }
    }

    public class SearchingViewController : BaseController {
        string progress;

        public SearchingViewController() {
            this.progress = string.Empty;
        }
        public Task<long> Search(DataItem[] data, int key) {
            return DoSearch(data, key, SearchCore);
        }
        public Task<long> BinarySearch(DataItem[] data, int key) {
            return DoSearch(data, key, BinarySearchCore);
        }
        Task<long> DoSearch(DataItem[] data, int key, Action<DataItem[], int> searchAction) {
            Progress = $"DataSet Size: {data.Length}";
            return Task.Run(() => {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                searchAction(data, key);
                stopWatch.Stop();
                return stopWatch.ElapsedMilliseconds;
            });
        }
        static void SearchCore(DataItem[] data, int key) {
            data.Search(x => x.Key == key);
        }
        static void BinarySearchCore(DataItem[] data, int key) {
            data.BinarySearch(x => key.CompareTo(x.Key));
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
    }
}
