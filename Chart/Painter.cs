using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms_Performance_Visualizer.Base;

namespace Algorithms_Performance_Visualizer.Controls {
    public class ChartControlPainter : BasePainter {
        public ChartControlPainter() {
        }
        protected override void DrawContent(DrawArgs drawArgs) {
            DrawGrid(drawArgs);
            DrawAxes(drawArgs);
            DrawChart(drawArgs);
            DrawLegend(drawArgs);
        }
        void DrawChart(DrawArgs drawArgs) {
            ((ChartControlViewInfo)drawArgs.ViewInfo).SeriesViewInfoList.ForEach(x => DrawSeries(drawArgs, x));
        }
        void DrawSeries(DrawArgs drawArgs, SeriesViewInfo series) {
            ChartControlViewInfo viewInfo = (ChartControlViewInfo)drawArgs.ViewInfo;
            using(Pen pointPen = new Pen(series.Color)) {
                foreach(SeriesItemViewInfo seriesItem in series) {
                    drawArgs.Cache.DrawPoint(pointPen, seriesItem.Point, viewInfo.PointSize);
                }
            }
        }
        void DrawLegend(DrawArgs drawArgs) {
            ChartControlViewInfo viewInfo = (ChartControlViewInfo)drawArgs.ViewInfo;
            Rectangle legendBounds = viewInfo.LegendBounds;
            PaintCache cache = drawArgs.Cache;
            cache.DrawLine(Pens.LightGray, legendBounds.Location, legendBounds.Location.OffsetWith(0, legendBounds.Height));
            foreach(LegendItemViewInfo legendItem in viewInfo.LegendViewInfo) {
                cache.FillRectangle(cache.GetSolidBrush(legendItem.Color), legendItem.ColorRect);
                using(StringFormat labelFormat = new StringFormat()) {
                    labelFormat.Trimming = StringTrimming.EllipsisCharacter;
                    cache.DrawText(legendItem.Label, viewInfo.LegendLabelFont, cache.GetSolidBrush(viewInfo.LegendLabelForeColor), legendItem.LabelRect, labelFormat);
                }
            }
        }
        void DrawAxes(DrawArgs drawArgs) {
            ChartControlViewInfo viewInfo = (ChartControlViewInfo)drawArgs.ViewInfo;
            drawArgs.Cache.DrawLine(Pens.Black, viewInfo.Origin, viewInfo.AxesAbscissa);
            drawArgs.Cache.DrawLine(Pens.Black, viewInfo.Origin, viewInfo.AxesOrdinate);
        }
        void DrawGrid(DrawArgs drawArgs) {
            ChartControlViewInfo viewInfo = (ChartControlViewInfo)drawArgs.ViewInfo;
            PaintCache cache = drawArgs.Cache;
            foreach(ChartGridItem gridItem in viewInfo.GridInfo) {
                cache.DrawLine(Pens.LightGray, gridItem.Line.StartPoint, gridItem.Line.EndPoint);
                if(gridItem.ShouldDrawLabel) {
                    cache.DrawText(gridItem.Label.Text, viewInfo.AxisLabelFont, cache.GetSolidBrush(viewInfo.AxisLabelForeColor), gridItem.Label.TextBounds);
                }
            }
        }
        protected override Color BorderColor { get { return Color.Gray; } }
    }
}
