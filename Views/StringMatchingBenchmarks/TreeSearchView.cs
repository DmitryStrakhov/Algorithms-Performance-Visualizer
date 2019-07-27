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
using Algorithms_Performance_Visualizer.Data;

namespace Algorithms_Performance_Visualizer.Views {
    public partial class TreeSearchView : StringMatchingBenchmarkViewBase {
        public TreeSearchView() {
            InitializeComponent();
        }
        protected override StringMatchingBenchmarkViewControllerBase CreateControllerCore() {
            return new TreeSearchViewController();
        }
        protected override async Task Measure(int taskSize) {
            string word;
            string[] strings = StringHelper.NewStrings(taskSize);

            if(Controller.OperationResult == OperationResult.Success)
                word = StringHelper.GetWord(strings);
            else
                word = StringHelper.UniqueString();

            long time = await Controller.MeasureTrie(taskSize, strings, word);
            seriesTrie.PointList.Add(new ChartPoint(taskSize, time));
            time = await Controller.MeasureTST(taskSize, strings, word);
            seriesTST.PointList.Add(new ChartPoint(taskSize, time));
            time = await Controller.MeasureST(taskSize, strings, word);
            seriesST.PointList.Add(new ChartPoint(taskSize, time));
        }
        internal new TreeSearchViewController Controller { get { return (TreeSearchViewController)base.Controller; } }
    }


    public class TreeSearchViewController : StringMatchingBenchmarkViewControllerBase {
        public TreeSearchViewController() {
        }
        public async Task<long> MeasureTrie(int taskSize, string[] strings, string word) {
            Trie<int> trie = new Trie<int>();
            for(int n = 0; n < strings.Length; n++) {
                trie.Insert(strings[n], n);
            }
            return await MeasureTicks(taskSize, () => trie.Contains(word));
        }
        public async Task<long> MeasureTST(int taskSize, string[] strings, string word) {
            TernarySearchTree<int> tst = new TernarySearchTree<int>();
            for(int n = 0; n < strings.Length; n++) {
                tst.Insert(strings[n], n);
            }
            return await MeasureTicks(taskSize, () => tst.Contains(word));
        }
        public async Task<long> MeasureST(int taskSize, string[] strings, string word) {
            string @string = string.Join(";", strings);
            SuffixTree suffixTree = new SuffixTree((char)5000, @string);
            return await MeasureTicks(taskSize, () => suffixTree.Contains(word));
        }
        public override bool SupportsDifferentOperationResults { get { return true; } }
    }
}
