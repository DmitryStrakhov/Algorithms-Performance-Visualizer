using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Data_Structures_and_Algorithms;
using Algorithms_Performance_Visualizer.Base;
using Algorithms_Performance_Visualizer.Data;
using Algorithms_Performance_Visualizer.Controls;
using System.Collections;

namespace Algorithms_Performance_Visualizer.Views {
    public partial class HashMapView : BaseUserControl {
        public HashMapView() {
            InitializeComponent();
        }
        protected override BaseController CreateController() {
            return new HashMapViewController();
        }
        protected override void Bind() {
            base.Bind();
            this.progressLabel.Bind("Text", Controller, "Progress");
            this.btnStart.Bind("Text", Controller, "State", formatDelegate: OnStartButtonFormatControllerState);
            this.rbAdd.Bind("Checked", Controller, "Operation", parseDelegate: OnAddRadioButtonParseControllerOperation, formatDelegate: OnAddRadioButtonFormatControllerOperation);
            this.rbContainsKey.Bind("Checked", Controller, "Operation", parseDelegate: OnContainsKeyRadioButtonParseControllerOperation, formatDelegate: OnContainsKeyRadioButtonFormatControllerOperation);
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
        void OnAddRadioButtonFormatControllerOperation(object sender, ConvertEventArgs e) {
            if(e.DesiredType == typeof(bool)) {
                e.Value = (HashMapOperation)e.Value == HashMapOperation.Add;
            }
        }
        void OnAddRadioButtonParseControllerOperation(object sender, ConvertEventArgs e) {
            if(e.DesiredType == typeof(HashMapOperation)) {
                e.Value = (bool)e.Value ? HashMapOperation.Add : HashMapOperation.ContainsKey;
            }
        }
        void OnContainsKeyRadioButtonFormatControllerOperation(object sender, ConvertEventArgs e) {
            if(e.DesiredType == typeof(bool)) {
                e.Value = (HashMapOperation)e.Value == HashMapOperation.ContainsKey;
            }
        }
        void OnContainsKeyRadioButtonParseControllerOperation(object sender, ConvertEventArgs e) {
            if(e.DesiredType == typeof(HashMapOperation)) {
                e.Value = (bool)e.Value ? HashMapOperation.ContainsKey : HashMapOperation.Add;
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
            for(long dataSetSize = 10; Controller.IsActive; dataSetSize += 1000) {
                HashMapDataSetItem[] dataSet = CreateDataSet(dataSetSize);
                long time = await Controller.MeasureHashMap(dataSet);
                this.seriesHashMap.PointList.Add(new ChartPoint(dataSet.Length, time));
                time = await Controller.MeasureHashtable(dataSet);
                this.seriesHashtable.PointList.Add(new ChartPoint(dataSet.Length, time));
                time = await Controller.MeasureDictionary(dataSet);
                this.seriesDictionary.PointList.Add(new ChartPoint(dataSet.Length, time));
            }
        }
        static HashMapDataSetItem[] CreateDataSet(long dataSetSize) {
            HashMapDataSetItem[] dataSet = new HashMapDataSetItem[dataSetSize];
            for(int n = 0; n < dataSetSize; n++) {
                dataSet[n] = new HashMapDataSetItem(Random.Next());
            }
            return dataSet;
        }
        internal new HashMapViewController Controller { get { return (HashMapViewController)base.Controller; } }
    }


    [DebuggerDisplay("HashMapDataSetItem(Key={First.ID},Value={Second.Value})")]
    public class HashMapDataSetItem : Pair<HashMapDataKey, HashMapDataValue> {
        public HashMapDataSetItem(int key)
            : base(new HashMapDataKey(key), new HashMapDataValue(key.ToString())) {
        }
    }

    interface IHashMap {
        HashMapDataValue this[HashMapDataKey key] { get; set; }
    }

    class HashMap : HashMap<HashMapDataKey, HashMapDataValue>, IHashMap {
        public HashMap() { }
    }

    class MsHashtable : Hashtable, IHashMap {
        public MsHashtable() {
        }
        public HashMapDataValue this[HashMapDataKey key] {
            get { return (HashMapDataValue)base[key]; }
            set { base[key] = value; }
        }
    }

    class MsDictionary : Dictionary<HashMapDataKey, HashMapDataValue>, IHashMap {
        public MsDictionary() { }
    }


    public enum HashMapOperation {
        Add, ContainsKey
    }

    static class IHashMapExtensions {
        public static void Fill(this IHashMap @this, HashMapDataSetItem[] dataSet) {
            for(int n = 0; n < dataSet.Length; n++) {
                @this[dataSet[n].First] = dataSet[n].Second;
            }
        }
    }


    public class HashMapViewController : BaseController {
        HashMapOperation operation;
        Random random;

        public HashMapViewController() {
            this.random = new Random();
            this.operation = HashMapOperation.Add;
        }
        public HashMapOperation Operation {
            get { return operation; }
            set {
                if(Operation == value)
                    return;
                operation = value;
                OnPropertyChanged("Operation");
            }
        }
        public Task<long> MeasureHashMap(HashMapDataSetItem[] dataSet) {
            return MeasureCore(new HashMap(), dataSet);
        }
        public Task<long> MeasureHashtable(HashMapDataSetItem[] dataSet) {
            return MeasureCore(new MsHashtable(), dataSet);
        }
        public Task<long> MeasureDictionary(HashMapDataSetItem[] dataSet) {
            return MeasureCore(new MsDictionary(), dataSet);
        }
        Task<long> MeasureCore(IHashMap hashMap, HashMapDataSetItem[] dataSet) {
            if(Operation == HashMapOperation.Add) {
                return MeasureCore(hashMap, dataSet, MeasureHashMapAdd);
            }
            if(Operation == HashMapOperation.ContainsKey) {
                hashMap.Fill(dataSet);
                return MeasureCore(hashMap, dataSet, MeasureHashMapContainsKey);
            }
            throw new NotImplementedException();
        }
        void MeasureHashMapAdd(IHashMap hashMap, HashMapDataSetItem[] dataSet) {
            hashMap.Fill(dataSet);
        }
        void MeasureHashMapContainsKey(IHashMap hashMap, HashMapDataSetItem[] dataSet) {
            for(int n = 0; n < 1000; n++) {
                HashMapDataKey key = dataSet[random.Next(dataSet.Length)].First;
                HashMapDataValue value = hashMap[key];
            }
        }
        Task<long> MeasureCore(IHashMap hashMap, HashMapDataSetItem[] dataSet, Action<IHashMap, HashMapDataSetItem[]> action) {
            Progress = $"DataSet Size = {dataSet.Length}";
            return Task.Run(() => {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                action(hashMap, dataSet);
                stopWatch.Stop();
                return stopWatch.ElapsedMilliseconds;
            });
        }
    }
}
