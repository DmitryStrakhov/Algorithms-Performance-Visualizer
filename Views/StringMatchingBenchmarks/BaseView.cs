using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Algorithms_Performance_Visualizer.Base;
using Algorithms_Performance_Visualizer.Data;

namespace Algorithms_Performance_Visualizer.Views {
    public partial class StringMatchingBenchmarkViewBase : BaseUserControl {
        public StringMatchingBenchmarkViewBase() {
            InitializeComponent();
        }
        public async void Start() {
            for(int taskSize = 10; Controller.IsActive; taskSize += 10) {
                await Measure(taskSize);
            }
        }
        protected virtual Task Measure(int taskSize) {
            return Task.Delay(0);
        }
        public void ClearChart() {
            chartControl.Series.ForEach(x => x.PointList.Clear());
        }
        protected sealed override BaseController CreateController() {
            return CreateControllerCore();
        }

        protected virtual StringMatchingBenchmarkViewControllerBase CreateControllerCore() {
            return null;
        }
        internal new StringMatchingBenchmarkViewControllerBase Controller { get { return (StringMatchingBenchmarkViewControllerBase)base.Controller; } }
    }


    public abstract class StringMatchingBenchmarkViewControllerBase : BaseController {
        OperationResult operationResult;

        public StringMatchingBenchmarkViewControllerBase() {
            this.operationResult = OperationResult.Success;
        }
        protected Task<long> Measure(long taskSize, Action action) {
            return MeasureCore(taskSize, action, x => x.ElapsedMilliseconds);
        }
        protected Task<long> MeasureTicks(long taskSize, Action action) {
            return MeasureCore(taskSize, action, x => x.ElapsedTicks);
        }
        private Task<long> MeasureCore(long taskSize, Action action, Func<Stopwatch, long> getResult) {
            Progress = $"Task Size = {taskSize}";
            return Task.Run(() => {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                action();
                stopWatch.Stop();
                return getResult(stopWatch);
            });
        }
        public OperationResult OperationResult {
            get { return operationResult; }
            set {
                if(OperationResult == value)
                    return;
                operationResult = value;
                OnPropertyChanged(nameof(OperationResult));
            }
        }
        public abstract bool SupportsDifferentOperationResults { get; }
    }
}
