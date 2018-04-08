using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Performance_Visualizer.Data {
    [DebuggerDisplay("Pair(First={First},Second={Second})")]
    public class Pair<TF, TS> {
        readonly TF first;
        readonly TS second;

        public Pair(TF first, TS second) {
            this.first = first;
            this.second = second;
        }
        public TF First { get { return first; } }
        public TS Second { get { return second; } }
    }
}
