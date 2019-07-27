using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Performance_Visualizer.Base {
    public abstract class BaseViewInfo {
        readonly BaseControl control;
        Graphics graphics;

        public BaseViewInfo(BaseControl control) {
            this.control = control;
        }
        public virtual void CalcViewInfo() {
            CalcContent();
        }
        protected virtual void CalcContent() {
        }

        internal void SetGraphics(Graphics graphics) {
            this.graphics = graphics;
        }
        internal void ReleaseGraphics() {
            graphics = null;
        }
        protected Size CalcTextSize(string text) {
            Debug.Assert(graphics != null);
            SizeF size = graphics.MeasureString(text, Control.Font, 0);
            return new Size((int)size.Width + 1, (int)size.Height + 1);
        }
        public bool DrawBorder {
            get { return control.DrawBorder; }
        }
        public Rectangle Bounds { get { return new Rectangle(Point.Empty, Control.Size); } }
        public BaseControl Control { get { return control; } }
    }
}
