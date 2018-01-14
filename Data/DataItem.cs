using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Performance_Visualizer.Data {
    [DebuggerDisplay("DataItem({Key})")]
    public class DataItem : IComparable {
        readonly int key;

        public DataItem(int key) {
            if(key < 0) {
                throw new ArgumentException(nameof(key));
            }
            this.key = key;
        }
        public int Key { get { return key; } }

        #region IComparable

        int IComparable.CompareTo(object obj) {
            DataItem other = obj as DataItem;
            if(other == null) {
                throw new ArgumentException();
            }
            return Key.CompareTo(other.Key);
        }

        #endregion

    }
}
