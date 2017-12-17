using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms_Performance_Visualizer.Controls;

namespace Algorithms_Performance_Visualizer.Base {
    public class PaintCache : IDisposable {
        Graphics graphics;
        Dictionary<Color, SolidBrush> solidBrushCache;

        public PaintCache(Graphics graphics) {
            this.graphics = graphics;
            this.solidBrushCache = new Dictionary<Color, SolidBrush>();
        }
        public void DrawRectangle(Pen pen, Rectangle rect) {
            rect.Width--;
            rect.Height--;
            graphics.DrawRectangle(pen, rect);
        }
        public void FillRectangle(Brush brush, Rectangle rect) {
            rect.Width--;
            rect.Height--;
            graphics.FillRectangle(brush, rect);
        }
        public void DrawLine(Pen pen, Point pt1, Point pt2) {
            graphics.DrawLine(pen, pt1, pt2);
        }
        public void DrawText(string text, Font font, Brush brush, Rectangle rect) {
            graphics.DrawString(text, font, brush, rect);
        }
        public void DrawPoint(Pen pen, Point point, Size sz) {
            graphics.DrawEllipse(pen, point.CreateRect(sz));
        }
        public void DrawText(string text, Font font, Brush brush, Rectangle rect, StringFormat format) {
            graphics.DrawString(text, font, brush, rect, format);
        }
        public SolidBrush GetSolidBrush(Color color) {
            SolidBrush brush;
            if(!this.solidBrushCache.TryGetValue(color, out brush)) {
                this.solidBrushCache.Add(color, brush = new SolidBrush(color));
            }
            return brush;
        }

        #region IDisposable

        public void Dispose() {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing) {
            if(disposing) {
                if(this.solidBrushCache != null && this.solidBrushCache.Count != 0) {
                    this.solidBrushCache.ForEach(x => x.Value.Dispose());
                    this.solidBrushCache.Clear();
                }
            }
            this.solidBrushCache = null;
            this.graphics = null;
        }
        
        #endregion
    }
}
