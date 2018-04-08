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
using System.Threading;
using Data_Structures_and_Algorithms;

namespace Algorithms_Performance_Visualizer.Views {
    public partial class SelectionView : BaseUserControl {
        public SelectionView() {
            InitializeComponent();
        }
        protected override void Bind() {
            base.Bind();
            this.progressLabel.Bind("Text", Controller, "Progress");
            this.btnStart.Bind("Text", Controller, "State", formatDelegate: OnStartButtonFormatControllerState);
        }

        #region Parse & Format

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
        
        #endregion

        #region Handlers

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

        #endregion

        async Task Start() {
            for(long arraySize = 10; Controller.IsActive; arraySize += 100) {
                DataItem[] dataSet1 = CreateData(arraySize);
                DataItem[] dataSet2 = dataSet1.DoClone();
                int key = Random.Next(0, dataSet1.Length);
                await Measure(dataSet1, dataSet2, key);
            }
        }
        async Task Measure(DataItem[] dataSet1, DataItem[] dataSet2, int key) {
            long time = await Controller.QuickSelect(dataSet1, key);
            this.seriesQuickSelect.PointList.Add(new ChartPoint(dataSet1.Length, time));
            time = await Controller.QuickSort(dataSet2, key);
            this.seriesQuickSort.PointList.Add(new ChartPoint(dataSet2.Length, time));
        }

        static DataItem[] CreateData(long dataSetSize) {
            DataItem[] data = new DataItem[dataSetSize];
            for(int n = 0; n < dataSetSize; n++) {
                data[n] = new DataItem(Random.Next(1000));
            }
            return data;
        }

        protected override BaseController CreateController() {
            return new SelectionViewController();
        }
        internal new SelectionViewController Controller { get { return (SelectionViewController)base.Controller; } }
    }

    public class SelectionViewController : BaseController {
        public SelectionViewController() {
        }
        public Task<long> QuickSelect(DataItem[] data, int key) {
            return DoSelect(data, key, QuickSelectCore);
        }
        public Task<long> QuickSort(DataItem[] data, int key) {
            return DoSelect(data, key, QuickSortCore);
        }
        Task<long> DoSelect(DataItem[] data, int key, Func<DataItem[], int, DataItem> selectAction) {
            Progress = $"DataSet Size: {data.Length}";
            return Task.Run(() => {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                selectAction(data, key);
                stopWatch.Stop();
                return stopWatch.ElapsedMilliseconds;
            });
        }
        static DataItem QuickSelectCore(DataItem[] data, int key) {
            return Selection.Select(data, key);
        }
        static DataItem QuickSortCore(DataItem[] data, int key) {
            quickSorter.Sort(data);
            return data[key];
        }
        static readonly ISort quickSorter = new QuickSorter();
    }
}
