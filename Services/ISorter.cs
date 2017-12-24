using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms_Performance_Visualizer.Views;
using Data_Structures_and_Algorithms;

namespace Algorithms_Performance_Visualizer.Services {
    public interface ISorter {
        void Sort(SortDataItem[] data);
    }

    [DebuggerDisplay("SortDataItem({Key})")]
    public class SortDataItem : IComparable, ICountingSortItem, IBucketSortItem, IRadixSortItem {
        readonly int key;

        public SortDataItem(int key) {
            if(key < 0) {
                throw new ArgumentException(nameof(key));
            }
            this.key = key;
        }
        public int Key { get { return key; } }

        #region IComparable

        int IComparable.CompareTo(object obj) {
            SortDataItem other = obj as SortDataItem;
            if(other == null) {
                throw new ArgumentException();
            }
            return Key.CompareTo(other.Key);
        }

        #endregion

        #region IRadixSortItem

        uint IRadixSortItem.Key {
            get { return (uint)Key; }
        }

        #endregion
    }
}
