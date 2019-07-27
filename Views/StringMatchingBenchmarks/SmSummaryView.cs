using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_and_Algorithms;
using Algorithms_Performance_Visualizer.Helpers;
using Algorithms_Performance_Visualizer.Data;
using Algorithms_Performance_Visualizer.Controls;

namespace Algorithms_Performance_Visualizer.Views {
    public partial class SmSummaryView : StringMatchingBenchmarkViewBase {
        public SmSummaryView() {
            InitializeComponent();
        }
        protected override async Task Measure(int taskSize) {
            string pattern;
            string text = StringHelper.NewString(taskSize);

            if(Controller.OperationResult == OperationResult.Success)
                pattern = StringHelper.Substring(text);
            else
                pattern = StringHelper.UniqueString();

            long time = await Controller.MeasureBF(taskSize, text, pattern);
            seriesBF.PointList.Add(new ChartPoint(taskSize, time));
            time = await Controller.MeasureRK(taskSize, text, pattern);
            seriesRK.PointList.Add(new ChartPoint(taskSize, time));
            time = await Controller.MeasureFASM(taskSize, text, pattern);
            seriesFASM.PointList.Add(new ChartPoint(taskSize, time));
            time = await Controller.MeasureKMP(taskSize, text, pattern);
            seriesKMP.PointList.Add(new ChartPoint(taskSize, time));
            time = await Controller.MeasureBM(taskSize, text, pattern);
            seriesBM.PointList.Add(new ChartPoint(taskSize, time));
        }
        protected override StringMatchingBenchmarkViewControllerBase CreateControllerCore() {
            return new SmSummaryViewController();
        }
        internal new SmSummaryViewController Controller { get { return (SmSummaryViewController)base.Controller; } }
    }


    public class SmSummaryViewController : StringMatchingBenchmarkViewControllerBase {
        public SmSummaryViewController() {
        }
        public async Task<long> MeasureBF(int taskSize, string text, string pattern) {
            return await MeasureTicks(taskSize, () => new BruteForceStringMatcher(pattern).MatchTo(text));
        }
        public async Task<long> MeasureRK(int taskSize, string text, string pattern) {
            return await MeasureTicks(taskSize, () => new RabinKarpStringMatcher(pattern).MatchTo(text));
        }
        public async Task<long> MeasureFASM(int taskSize, string text, string pattern) {
            return await MeasureTicks(taskSize, () => new FiniteAutomatonStringMatcher(pattern).MatchTo(text));
        }
        public async Task<long> MeasureKMP(int taskSize, string text, string pattern) {
            return await MeasureTicks(taskSize, () => new KnuthMorrisPrattStringMatcher(pattern).MatchTo(text));
        }
        public async Task<long> MeasureBM(int taskSize, string text, string pattern) {
            return await MeasureTicks(taskSize, () => new BoyerMooreStringMatcher(pattern).MatchTo(text));
        }
        public override bool SupportsDifferentOperationResults { get { return true; } }
    }
}
