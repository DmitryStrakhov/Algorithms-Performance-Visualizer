using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Performance_Visualizer.Base {
    public class BaseCollection<T> : Collection<T> {
        public BaseCollection() {
        }

        protected sealed override void InsertItem(int index, T item) {
            base.InsertItem(index, item);
            OnItemAdded(item);
            RaiseListChanged(new CollectionChangedEventArgs(CollectionChangeType.Insert, index));
        }
        protected sealed override void SetItem(int index, T item) {
            base.SetItem(index, item);
            RaiseListChanged(new CollectionChangedEventArgs(CollectionChangeType.SetItem));
        }
        protected sealed override void RemoveItem(int index) {
            T item = this[index];
            base.RemoveItem(index);
            OnItemRemoved(item);
            RaiseListChanged(new CollectionChangedEventArgs(CollectionChangeType.Remove));
        }
        protected sealed override void ClearItems() {
            this.ForEach(x => OnItemRemoved(x));
            base.ClearItems();
            RaiseListChanged(new CollectionChangedEventArgs(CollectionChangeType.Clear));
        }
        protected virtual void OnItemAdded(T item) { }
        protected virtual void OnItemRemoved(T item) { }

        protected void RaiseListChanged(CollectionChangedEventArgs e) {
            if(CollectionChanged != null) CollectionChanged(this, e);
        }
        public event CollectionChangedEventHandler CollectionChanged;
    }

    public delegate void CollectionChangedEventHandler(object sender, CollectionChangedEventArgs e);

    public enum CollectionChangeType {
        Insert, SetItem, Remove, Clear, ItemChanged
    }

    public class CollectionChangedEventArgs : EventArgs {
        readonly CollectionChangeType changeType;
        readonly int index;

        public CollectionChangedEventArgs(CollectionChangeType changeType)
            : this(changeType, -1) {
        }
        public CollectionChangedEventArgs(CollectionChangeType changeType, int index) {
            this.changeType = changeType;
            this.index = index;
        }
        public int Index { get { return index; } }
        public CollectionChangeType ChangeType { get { return changeType; } }
    }
}
