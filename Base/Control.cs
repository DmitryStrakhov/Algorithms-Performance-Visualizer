using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithms_Performance_Visualizer.Base {
    public abstract class BaseControl : Control {
        bool drawBorder;
        readonly BasePainter painter;
        readonly BaseViewInfo viewInfo;

        public BaseControl() {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.drawBorder = true;
            this.painter = CreatePainter();
            this.viewInfo = CreateViewInfo();
        }
        [DefaultValue(true), Category("Appearance")]
        public bool DrawBorder {
            get { return drawBorder; }
            set {
                if(DrawBorder == value)
                    return;
                drawBorder = value;
                LayoutChanged();
            }
        }
        protected sealed override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            PaintCache cache = new PaintCache(e.Graphics);
            try {
                ViewInfo.SetGraphics(e.Graphics);
                ViewInfo.CalcViewInfo();
                Painter.Paint(new DrawArgs(cache, ViewInfo));
            }
            finally {
                cache.Dispose();
                ViewInfo.ReleaseGraphics();
            }
        }
        protected void UpdateViewInfo() {
            if(!IsHandleCreated)
                return;
            Graphics graphics = Graphics.FromHwnd(Handle);
            try {
                ViewInfo.SetGraphics(graphics);
                ViewInfo.CalcViewInfo();
            }
            finally {
                ViewInfo.ReleaseGraphics();
                graphics.Dispose();
            }
        }

        protected void LayoutChanged() {
            Invalidate();
        }

        public BasePainter Painter { get { return painter; } }
        public BaseViewInfo ViewInfo { get { return viewInfo; } }

        protected abstract BaseViewInfo CreateViewInfo();
        protected abstract BasePainter CreatePainter();
    }
}
