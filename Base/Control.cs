using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithms_Performance_Visualizer.Base {
    public abstract class BaseControl : Control {
        readonly BasePainter painter;
        readonly BaseViewInfo viewInfo;

        public BaseControl() {
            this.painter = CreatePainter();
            this.viewInfo = CreateViewInfo();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            using(PaintCache cache = new PaintCache(e.Graphics)) {
                ViewInfo.CalcViewInfo();
                Painter.Paint(new DrawArgs(cache, ViewInfo));
            }
        }

        public BasePainter Painter { get { return painter; } }
        public BaseViewInfo ViewInfo { get { return viewInfo; } }

        protected abstract BaseViewInfo CreateViewInfo();
        protected abstract BasePainter CreatePainter();
    }
}
