using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms_Performance_Visualizer.Services;
using Data_Structures_and_Algorithms;

namespace Algorithms_Performance_Visualizer.Components {
    class BubbleDataSorter : ISorter {
        public void Sort(SortDataItem[] data) {
            new BubbleSorter().Sort(data);
        }
    }

    class SelectionDataSorter : ISorter {
        public void Sort(SortDataItem[] data) {
            new SelectionSorter().Sort(data);
        }
    }

    class InsertionDataSorter : ISorter {
        public void Sort(SortDataItem[] data) {
            new InsertionSorter().Sort(data);
        }
    }

    class ShellDataSorter : ISorter {
        public void Sort(SortDataItem[] data) {
            new ShellSorter().Sort(data);
        }
    }

    class MergeDataSorter : ISorter {
        public void Sort(SortDataItem[] data) {
            new MergeSorter().Sort(data);
        }
    }

    class HeapDataSorter : ISorter {
        public void Sort(SortDataItem[] data) {
            new HeapSorter().Sort(data);
        }
    }

    class QuickDataSorter : ISorter {
        public void Sort(SortDataItem[] data) {
            new QuickSorter().Sort(data);
        }
    }

    class TreeDataSorter : ISorter {
        public void Sort(SortDataItem[] data) {
            TreeSorter<SortDataItem> coreSorter = new TreeSorter<SortDataItem>();
            coreSorter.AddBlock(data);
            coreSorter.Sort();
        }
    }

    class CountingDataSorter : ISorter {
        readonly int minKey;
        readonly int maxKey;

        public CountingDataSorter(int minKey, int maxKey) {
            this.minKey = minKey;
            this.maxKey = maxKey;
        }
        public void Sort(SortDataItem[] data) {
            var d = new CountingSorter<SortDataItem>().Sort(data, this.minKey, this.maxKey);
        }
    }

    class BucketDataSorter : ISorter {
        readonly int minKey;
        readonly int maxKey;

        public BucketDataSorter(int minKey, int maxKey) {
            this.minKey = minKey;
            this.maxKey = maxKey;
        }

        public void Sort(SortDataItem[] data) {
            new BucketSorter<SortDataItem>().Sort(data, this.minKey, this.maxKey);
        }
    }

    class RadixDataSorter : ISorter {
        public void Sort(SortDataItem[] data) {
            new RadixSorter<SortDataItem>().Sort(data);
        }
    }
}
