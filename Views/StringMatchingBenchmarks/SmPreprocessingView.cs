using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_and_Algorithms;
using Algorithms_Performance_Visualizer.Controls;
using Algorithms_Performance_Visualizer.Helpers;

namespace Algorithms_Performance_Visualizer.Views {
    public partial class SmPreprocessingView : StringMatchingBenchmarkViewBase {
        public SmPreprocessingView() {
            InitializeComponent();
        }
        protected override async Task Measure(int taskSize) {
            string pattern = StringHelper.NewString(taskSize);
            long time = await Controller.MeasureRK(taskSize, pattern);
            seriesRK.PointList.Add(new ChartPoint(taskSize, time));
            time = await Controller.MeasureFASM(taskSize, pattern);
            seriesFASM.PointList.Add(new ChartPoint(taskSize, time));
            time = await Controller.MeasureKMP(taskSize, pattern);
            seriesKMP.PointList.Add(new ChartPoint(taskSize, time));
            time = await Controller.MeasureBM(taskSize, pattern);
            seriesBM.PointList.Add(new ChartPoint(taskSize, time));
        }
        protected override StringMatchingBenchmarkViewControllerBase CreateControllerCore() {
            return new SmPreprocessingViewController();
        }
        internal new SmPreprocessingViewController Controller { get { return (SmPreprocessingViewController)base.Controller; } }
    }


    public class SmPreprocessingViewController : StringMatchingBenchmarkViewControllerBase {
        public SmPreprocessingViewController() {
        }
        public async Task<long> MeasureRK(long taskSize, string pattern) {
            return await Measure(taskSize, () => new RabinKarpStringMatcher(pattern));
        }
        public async Task<long> MeasureFASM(long taskSize, string pattern) {
            return await Measure(taskSize, () => new FiniteAutomatonStringMatcher(pattern));
        }
        public async Task<long> MeasureKMP(long taskSize, string pattern) {
            return await Measure(taskSize, () => new KnuthMorrisPrattStringMatcher(pattern));
        }
        public async Task<long> MeasureBM(long taskSize, string pattern) {
            return await Measure(taskSize, () => new BoyerMooreStringMatcher(pattern));
        }
        public override bool SupportsDifferentOperationResults { get { return false; } }
    }
}
