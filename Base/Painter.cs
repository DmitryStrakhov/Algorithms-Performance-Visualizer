using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Performance_Visualizer.Base {
    public abstract class BasePainter {
        public void Paint(DrawArgs drawArgs) {
            DrawContent(drawArgs);
            if(drawArgs.ViewInfo.DrawBorder) DrawBorder(drawArgs);
        }

        protected abstract void DrawContent(DrawArgs drawArgs);

        protected virtual void DrawBorder(DrawArgs drawArgs) {
            using(Pen borderPen = new Pen(BorderColor)) {
                drawArgs.Cache.DrawRectangle(borderPen, drawArgs.ViewInfo.Bounds);
            }
        }
        protected virtual Color BorderColor { get { return Color.Black; } }
    }
}
