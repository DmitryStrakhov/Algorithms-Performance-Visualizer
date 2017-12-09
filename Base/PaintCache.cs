using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Performance_Visualizer.Base {
    public class PaintCache : IDisposable {
        Graphics graphics;

        public PaintCache(Graphics graphics) {
            this.graphics = graphics;
        }

        public void DrawRectangle(Pen pen, Rectangle rect) {
            rect.Width--;
            rect.Height--;
            graphics.DrawRectangle(pen, rect);
        }

        #region IDisposable

        public void Dispose() {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing) {
            if(disposing) {
            }
            this.graphics = null;
        }

        #endregion
    }
}
