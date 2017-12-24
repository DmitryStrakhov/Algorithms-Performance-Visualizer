using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms_Performance_Visualizer.Base;

namespace Algorithms_Performance_Visualizer.Controls {
    public class ChartControlViewInfo : BaseViewInfo {
        Point origin;
        Rectangle chartBounds;
        Rectangle legendBounds;

        Point axesAbscissa;
        Point axesOrdinate;
        ChartSeriesBounds seriesBounds;

        ChartGridInfo gridInfo;
        LegendViewInfo legendViewInfo;
        SeriesViewInfoList seriesViewInfo;

        public ChartControlViewInfo(ChartControl control)
            : base(control) {
        }
        protected override void CalcContent() {
            CalcAxes();
        }
        void CalcAxes() {
            this.chartBounds = CalcChartBounds();
            this.legendBounds = CalcLegendBounds();
            this.origin = CalcOrigin();
            this.axesAbscissa = CalcAxesAbscissa();
            this.axesOrdinate = CalcAxesOrdinate();
            this.seriesBounds = CalcSeriesBounds();
            this.gridInfo = CalcGrid();
            this.legendViewInfo = CalcLegend();
            this.seriesViewInfo = CalcSeries();
        }
        Rectangle CalcChartBounds() {
            Rectangle chartRect = new Rectangle();
            chartRect.Location = Bounds.Location.OffsetWith(OriginOffset);
            chartRect.Width = Bounds.Width - LegendWidth - 2 * OriginOffset;
            chartRect.Height = Bounds.Height - 2 * OriginOffset;
            return chartRect.CheckRect();
        }
        Rectangle CalcLegendBounds() {
            Rectangle legendRect = new Rectangle();
            legendRect.X = Bounds.Right - 1 - LegendWidth;
            legendRect.Y = Bounds.Y;
            legendRect.Width = LegendWidth;
            legendRect.Height = Bounds.Height;
            return legendRect;
        }
        Point CalcOrigin() {
            return new Point(ChartBounds.X, ChartBounds.Bottom - 1);
        }
        Point CalcAxesAbscissa() {
            return new Point(ChartBounds.Right - 1, Origin.Y);
        }
        Point CalcAxesOrdinate() {
            return new Point(Origin.X, ChartBounds.Top);
        }
        ChartSeriesBounds CalcSeriesBounds() {
            ChartSeriesBounds seriesBounds = new ChartSeriesBounds();
            foreach(ChartSeries series in Control.Series) {
                seriesBounds.CheckBounds(series.Bounds);
            }
            return seriesBounds;
        }
        SeriesViewInfoList CalcSeries() {
            SeriesViewInfoList seriesList = new SeriesViewInfoList();
            if(Control.Series.Count == 0 || ChartBounds.HasZeroDimension())
                return seriesList;
            foreach(ChartSeries series in Control.Series) {
                seriesList.Add(CreateSeries(series));
            }
            return seriesList;
        }
        SeriesViewInfo CreateSeries(ChartSeries series) {
            SeriesViewInfo seriesViewInfo = new SeriesViewInfo(series.Color);
            foreach(ChartPoint chartPoint in series.PointList) {
                Point plysicalPoint = CalcPhysicalPoint(chartPoint);
                seriesViewInfo.Add(new SeriesItemViewInfo(plysicalPoint));
            }
            return seriesViewInfo;
        }
        Point CalcPhysicalPoint(ChartPoint chartPoint) {
            Point physicalPoint = new Point();
            if(SeriesBounds.Width != 0) {
                physicalPoint.X = MathUtils.Round((chartPoint.X - SeriesBounds.Left) * ChartBounds.Width / SeriesBounds.Width);
            }
            else {
                physicalPoint.X = ChartBounds.Width / 2;
            }
            if(SeriesBounds.Height != 0) {
                physicalPoint.Y = MathUtils.Round((chartPoint.Y - SeriesBounds.Bottom) * ChartBounds.Height / SeriesBounds.Height);
            }
            else {
                physicalPoint.Y = ChartBounds.Height / 2;
            }
            return Origin.OffsetWith(physicalPoint.X, -physicalPoint.Y);
        }
        ChartGridInfo CalcGrid() {
            ChartGridInfo gridInfo = new ChartGridInfo();
            if(Control.ShowGrid) {
                FillVertGrid(gridInfo);
                FillHorzGrid(gridInfo);
            }
            return gridInfo;
        }
        void FillHorzGrid(ChartGridInfo gridInfo) {
            int[] ticks = BuildTickMarks(ChartBounds.Top, ChartBounds.Bottom);
            for(int n = 0; n < ticks.Length; n++) {
                gridInfo.Add(CreateHorzGridItem(ticks[n]));
            }
        }
        void FillVertGrid(ChartGridInfo gridInfo) {
            int[] ticks = BuildTickMarks(ChartBounds.Left, ChartBounds.Right);
            for(int n = 0; n < ticks.Length; n++) {
                gridInfo.Add(CreateVertGridItem(ticks[n]));
            }
        }
        int[] BuildTickMarks(int minValue, int maxValue) {
            int[] ticks = new int[CalcAxisTickCount()];
            ticks[0] = minValue;
            ticks[1] = maxValue;
            int index = 2;
            FillTickMarks(ticks, ref index, minValue, maxValue, 0, (int)GridDensity);
            return ticks;
        }
        int CalcAxisTickCount() {
            int maxLevel = (int)GridDensity;
            return (1 << maxLevel) + 1;
        }
        void FillTickMarks(int[] ticks, ref int index, int minValue, int maxValue, int level, int maxLevel) {
            if(level == maxLevel) return;
            int pivot = minValue + (maxValue - minValue) / 2;
            ticks[index++] = pivot;
            FillTickMarks(ticks, ref index, minValue, pivot, level + 1, maxLevel);
            FillTickMarks(ticks, ref index, pivot, maxValue, level + 1, maxLevel);
        }
        static readonly int LabelToAxisIndent = 3;

        ChartGridItem CreateVertGridItem(int tick) {
            return new ChartGridItem(CreateVertGridLine(tick), CreateVertGridLabel(tick));
        }
        ChartGridLine CreateVertGridLine(int tick) {
            return new ChartGridLine(new Point(tick, ChartBounds.Bottom), new Point(tick, ChartBounds.Top));
        }
        ChartGridLabel CreateVertGridLabel(int tick) {
            if(Control.Series.Count == 0) return ChartGridLabel.Empty;
            string label = FormatTickLabel(CalcVertGridLabelValue(tick));
            Size labelSz = CalcTextSize(label);
            Rectangle labelRect = new Rectangle(new Point(tick, ChartBounds.Bottom), labelSz).OffsetWith(-labelSz.Width / 2, LabelToAxisIndent);
            return new ChartGridLabel(label, labelRect);
        }
        double CalcVertGridLabelValue(int tick) {
            return SeriesBounds.Left + (tick - ChartBounds.Left) * SeriesBounds.Width / ChartBounds.Width;
        }
        ChartGridItem CreateHorzGridItem(int tick) {
            return new ChartGridItem(CreateHorzGridLine(tick), CreateHorzGridLabel(tick));
        }
        ChartGridLine CreateHorzGridLine(int tick) {
            return new ChartGridLine(new Point(ChartBounds.Left, tick), new Point(ChartBounds.Right, tick));
        }
        ChartGridLabel CreateHorzGridLabel(int tick) {
            if(Control.Series.Count == 0) return ChartGridLabel.Empty;
            string label = FormatTickLabel(CalcHorzGridLabelValue(tick));
            Size labelSz = CalcTextSize(label);
            Rectangle labelRect = new Rectangle(new Point(ChartBounds.Left, tick), labelSz).OffsetWith(-labelSz.Width - LabelToAxisIndent, -labelSz.Height / 2);
            return new ChartGridLabel(label, labelRect);
        }
        double CalcHorzGridLabelValue(int tick) {
            return SeriesBounds.Bottom +  (ChartBounds.Bottom - tick) * SeriesBounds.Height / ChartBounds.Height;
        }
        internal string FormatTickLabel(double value) {
            return MathUtils.Round(value).ToString();
        }

        LegendViewInfo CalcLegend() {
            LegendViewInfo legend = new LegendViewInfo();
            if(Control.Series.Count == 0)
                return legend;
            int ceiling = LegendContentRect.Top;
            foreach(ChartSeries series in Control.Series) {
                LegendItemViewInfo legendItem = CreateLegendItem(series, ceiling);
                legend.Add(legendItem);
                ceiling = legendItem.ColorRect.Bottom + Control.LegendSpacing;
            }
            return legend;
        }
        static readonly Size LegendColorRectSize = new Size(16, 16);

        LegendItemViewInfo CreateLegendItem(ChartSeries series, int ceiling) {
            Rectangle colorRect = new Rectangle();
            colorRect.X = LegendContentRect.Left;
            colorRect.Y = ceiling;
            colorRect.Size = LegendColorRectSize;
            Rectangle labelRect = new Rectangle();
            labelRect.X = colorRect.Right + LegendLabelIndent;
            Size labelSize = CalcTextSize(series.Label);
            labelRect.Y = colorRect.Y + (colorRect.Height - labelSize.Height) / 2;
            labelRect.Width = Math.Min(labelSize.Width, LegendContentRect.Right - labelRect.X);
            labelRect.Height = labelSize.Height;
            return new LegendItemViewInfo(series.Color, series.Label, colorRect.CheckRect(), labelRect.CheckRect());
        }

        public Rectangle ChartBounds { get { return chartBounds; } }
        public Rectangle LegendBounds { get { return legendBounds; } }

        public int OriginOffset {
            get { return Control.OriginOffset; }
        }
        public int LegendWidth {
            get { return Control.LegendWidth; }
        }
        public int LegendSpacing {
            get { return Control.LegendSpacing; }
        }
        public int LegendLabelIndent {
            get { return Control.LegendLabelIndent; }
        }
        public Font LegendLabelFont {
            get { return Control.Font; }
        }
        public Font AxisLabelFont {
            get { return Control.Font; }
        }
        public Color LegendLabelForeColor {
            get { return Control.ForeColor; }
        }
        public Color AxisLabelForeColor {
            get { return Control.ForeColor; }
        }
        public Size PointSize {
            get { return Control.PointSize; }
        }
        public ChartGridDensity GridDensity {
            get { return Control.GridDensity; }
        }

        public Point Origin { get { return origin; } }
        public Point AxesAbscissa { get { return axesAbscissa; } }
        public Point AxesOrdinate { get { return axesOrdinate; } }

        public ChartGridInfo GridInfo {
            get { return gridInfo; }
        }
        public ChartSeriesBounds SeriesBounds {
            get { return seriesBounds; }
        }
        public Rectangle LegendContentRect {
            get { return LegendBounds.ApplyPadding(Control.LegendContentPadding); }
        }
        public LegendViewInfo LegendViewInfo {
            get { return legendViewInfo; }
        }
        public SeriesViewInfoList SeriesViewInfoList {
            get { return seriesViewInfo; }
        }
        public new ChartControl Control { get { return (ChartControl)base.Control; } }
    }

    [DebuggerDisplay("LegendItemViewInfo(Label={Label}, ColorRect={ColorRect}, LabelRect={LabelRect})")]
    public class LegendItemViewInfo {
        readonly Rectangle colorRect;
        readonly Rectangle labelRect;
        readonly string label;
        readonly Color color;

        public LegendItemViewInfo(Color color, string label, Rectangle colorRect, Rectangle labelRect) {
            this.color = color;
            this.label = label;
            this.colorRect = colorRect;
            this.labelRect = labelRect;
        }
        public Color Color { get { return color; } }
        public string Label { get { return label; } }
        public Rectangle ColorRect { get { return colorRect; } }
        public Rectangle LabelRect { get { return labelRect; } }
    }

    public class LegendViewInfo : Collection<LegendItemViewInfo> {
        public LegendViewInfo() {
        }
    }

    [DebuggerDisplay("SeriesItemViewInfo(Point={Point})")]
    public class SeriesItemViewInfo {
        readonly Point point;

        public SeriesItemViewInfo(Point point) {
            this.point = point;
        }
        public Point Point { get { return point; } }
    }

    public class SeriesViewInfo : Collection<SeriesItemViewInfo> {
        readonly Color color;

        public SeriesViewInfo(Color color) {
            this.color = color;
        }
        public Color Color { get { return color; } }
    }

    public class SeriesViewInfoList : Collection<SeriesViewInfo> {
        public SeriesViewInfoList() {
        }
    }

    public class ChartGridInfo : Collection<ChartGridItem> {
        public ChartGridInfo() { }
    }

    [DebuggerDisplay("ChartGridItem(Label={Label.Text},Point={Line.StartPoint})")]
    public class ChartGridItem {
        readonly ChartGridLine line;
        readonly ChartGridLabel label;

        public ChartGridItem(ChartGridLine gridLine, ChartGridLabel gridLabel) {
            this.line = gridLine;
            this.label = gridLabel;
        }
        public bool ShouldDrawLabel {
            get {
                if(Label.IsEmpty) return false;
                return true;
            }
        }
        public ChartGridLine Line { get { return line; } }
        public ChartGridLabel Label { get { return label; } }
    }

    [DebuggerDisplay("ChartGridLine(StartPoint={StartPoint},EndPoint={EndPoint})")]
    public class ChartGridLine {
        readonly Point startPoint;
        readonly Point endPoint;

        public ChartGridLine(Point startPoint, Point endPoint) {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }
        public Point StartPoint { get { return startPoint; } }
        public Point EndPoint { get { return endPoint; } }
    }

    [DebuggerDisplay("ChartGridLabel(Text={Text})")]
    public class ChartGridLabel : EquatableObject<ChartGridLabel> {
        readonly string text;
        readonly Rectangle textBounds;

        public ChartGridLabel(string text, Rectangle textBounds) {
            this.text = text;
            this.textBounds = textBounds;
        }
        public static readonly ChartGridLabel Empty = new ChartGridLabel(string.Empty, Rectangle.Empty);

        #region Equals & GetHashCode

        protected override bool EqualsTo(ChartGridLabel other) {
            return Text.Equals(other.Text) && TextBounds == other.TextBounds;
        }

        #endregion
        
        public bool IsEmpty {
            get { return Equals(Empty, this); }
        }
        public string Text { get { return text; } }
        public Rectangle TextBounds { get { return textBounds; } }
    }
}
