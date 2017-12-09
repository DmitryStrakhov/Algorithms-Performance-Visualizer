using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Performance_Visualizer.Base {
    public abstract class BaseViewInfo {
        readonly BaseControl control;

        public BaseViewInfo(BaseControl control) {
            this.control = control;
        }
        public void CalcViewInfo() {
        }
        public Rectangle Bounds { get { return new Rectangle(Point.Empty, Control.Size); } }
        public BaseControl Control { get { return control; } }
    }
}
