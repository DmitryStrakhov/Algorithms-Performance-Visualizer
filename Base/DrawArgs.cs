using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Performance_Visualizer.Base {
    public class DrawArgs {
        readonly PaintCache cache;
        readonly BaseViewInfo viewInfo;

        public DrawArgs(PaintCache cache, BaseViewInfo viewInfo) {
            this.cache = cache;
            this.viewInfo = viewInfo;
        }
        public BaseViewInfo ViewInfo { get { return viewInfo; } }
        public PaintCache Cache { get { return cache; } }
    }
}
