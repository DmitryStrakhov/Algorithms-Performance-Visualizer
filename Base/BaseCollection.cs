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

        protected override void InsertItem(int index, T item) {
            base.InsertItem(index, item);
            RaiseListChanged(EventArgs.Empty);
        }
        protected override void SetItem(int index, T item) {
            base.SetItem(index, item);
            RaiseListChanged(EventArgs.Empty);
        }
        protected override void RemoveItem(int index) {
            base.RemoveItem(index);
            RaiseListChanged(EventArgs.Empty);
        }
        protected override void ClearItems() {
            base.ClearItems();
            RaiseListChanged(EventArgs.Empty);
        }

        void RaiseListChanged(EventArgs e) {
            if(ListChanged != null) ListChanged(this, EventArgs.Empty);
        }
        public event EventHandler ListChanged;
    }
}
