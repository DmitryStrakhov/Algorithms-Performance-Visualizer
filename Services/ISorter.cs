using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms_Performance_Visualizer.Data;
using Data_Structures_and_Algorithms;

namespace Algorithms_Performance_Visualizer.Services {
    public interface ISorter {
        void Sort(SortDataItem[] data);
    }

    [DebuggerDisplay("SortDataItem({Key})")]
    public class SortDataItem : DataItem, ICountingSortItem, IBucketSortItem, IRadixSortItem {
        public SortDataItem(int key)
            : base(key) {
        }
        #region IRadixSortItem

        uint IRadixSortItem.Key {
            get { return (uint)Key; }
        }

        #endregion
    }
}
