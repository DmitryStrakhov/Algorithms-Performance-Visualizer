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
using Algorithms_Performance_Visualizer.Controls;

namespace Algorithms_Performance_Visualizer.Views {
    public partial class TreeBuildingView : StringMatchingBenchmarkViewBase {
        public TreeBuildingView() {
            InitializeComponent();
        }
        protected override async Task Measure(int taskSize) {
            string[] strings = StringHelper.NewStrings(taskSize);
            long time = await Controller.MeasureTrie(taskSize, strings);
            seriesTrie.PointList.Add(new ChartPoint(taskSize, time));
            time = await Controller.MeasureTST(taskSize, strings);
            seriesTST.PointList.Add(new ChartPoint(taskSize, time));
            time = await Controller.MeasureST(taskSize, strings);
            seriesST.PointList.Add(new ChartPoint(taskSize, time));
        }
        protected override StringMatchingBenchmarkViewControllerBase CreateControllerCore() {
            return new TreeBuildingViewController();
        }
        internal new TreeBuildingViewController Controller { get { return (TreeBuildingViewController)base.Controller; } }
    }


    public class TreeBuildingViewController : StringMatchingBenchmarkViewControllerBase {
        public TreeBuildingViewController() {
        }
        public async Task<long> MeasureTrie(int taskSize, string[] strings) {
            return await Measure(taskSize, () => {
                Trie<int> trie = new Trie<int>();
                for(int n = 0; n < strings.Length; n++) {
                    trie.Insert(strings[n], n);
                }
            });
        }
        public async Task<long> MeasureTST(int taskSize, string[] strings) {
            return await Measure(taskSize, () => {
                TernarySearchTree<int> tst = new TernarySearchTree<int>();
                for(int n = 0; n < strings.Length; n++) {
                    tst.Insert(strings[n], n);
                }
            });
        }
        public async Task<long> MeasureST(int taskSize, string[] strings) {
            string @string = string.Join(";", strings);
            return await Measure(taskSize, () => new SuffixTree((char)5000, @string));
        }
        public override bool SupportsDifferentOperationResults { get { return false; } }
    }
}
