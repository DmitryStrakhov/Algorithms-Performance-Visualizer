using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms_Performance_Visualizer.Base;

namespace Algorithms_Performance_Visualizer.Controls {
    public class ChartControl : BaseControl {
        readonly ChartSeriesCollection series;
        int originOffset;
        int legendWidth;
        int legendSpacing;
        int legendLabelIndent;
        bool showGrid;
        Size pointSize;
        Padding legendContentPadding;
        ChartGridDensity gridDensity;
        static readonly Padding DefaultLegendContentPadding = new Padding(4);
        static readonly Size DefaultPointSize = new Size(2, 2);

        public ChartControl() {
            this.originOffset = 25;
            this.legendWidth = 95;
            this.legendSpacing = 4;
            this.legendLabelIndent = 4;
            this.showGrid = true;
            this.pointSize = DefaultPointSize;
            this.legendContentPadding = DefaultLegendContentPadding;
            this.gridDensity = ChartGridDensity.Normal;
            this.series = new ChartSeriesCollection();
            this.series.CollectionChanged += OnSeriesListChanged;
        }
        [DefaultValue(25), ChartLayoutCategory]
        public int OriginOffset {
            get { return originOffset; }
            set {
                if(value < 0) value = 0;
                if(OriginOffset == value)
                    return;
                originOffset = value;
                LayoutChanged();
            }
        }
        [DefaultValue(95), ChartLayoutCategory]
        public int LegendWidth {
            get { return legendWidth; }
            set {
                if(value < 0) value = 0;
                if(LegendWidth == value)
                    return;
                legendWidth = value;
                LayoutChanged();
            }
        }
        [DefaultValue(4), ChartLayoutCategory]
        public int LegendSpacing {
            get { return legendSpacing; }
            set {
                if(LegendSpacing == value)
                    return;
                legendSpacing = value;
                LayoutChanged();
            }
        }
        [DefaultValue(4), ChartLayoutCategory]
        public int LegendLabelIndent {
            get { return legendLabelIndent; }
            set {
                value = Math.Max(0, value);
                if(LegendLabelIndent == value)
                    return;
                legendLabelIndent = value;
                LayoutChanged();
            }
        }
        [ChartLayoutCategory]
        public Padding LegendContentPadding {
            get { return legendContentPadding; }
            set {
                value = value.CheckPadding();
                if(LegendContentPadding == value)
                    return;
                legendContentPadding = value;
                LayoutChanged();
            }
        }

        bool ShouldSerializeLegendContentPadding() {
            return LegendContentPadding != DefaultLegendContentPadding;
        }
        void ResetLegendContentPadding() {
            LegendContentPadding = DefaultLegendContentPadding;
        }
        [ChartViewCategory]
        public Size PointSize {
            get { return pointSize; }
            set {
                value.Width = Math.Max(1, value.Width);
                value.Height = Math.Max(1, value.Height);
                if(PointSize == value)
                    return;
                pointSize = value;
                LayoutChanged();
            }
        }
        bool ShouldSerializePointSize() {
            return PointSize != DefaultPointSize;
        }
        void ResetPointSize() {
            PointSize = DefaultPointSize;
        }
        [ChartViewCategory, DefaultValue(true)]
        public bool ShowGrid {
            get { return showGrid; }
            set {
                if(ShowGrid == value)
                    return;
                showGrid = value;
                LayoutChanged();
            }
        }
        [ChartViewCategory, DefaultValue(ChartGridDensity.Normal)]
        public ChartGridDensity GridDensity {
            get { return gridDensity; }
            set {
                if(!Enum.IsDefined(typeof(ChartGridDensity), value)) {
                    throw new InvalidEnumArgumentException();
                }
                if(GridDensity == value)
                    return;
                gridDensity = value;
                LayoutChanged();
            }
        }

        [ChartDataCategory, DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ChartSeriesCollection Series { get { return series; } }

        void OnSeriesListChanged(object sender, EventArgs e) {
            Invalidate();
        }

        protected override Size DefaultSize {
            get { return new Size(250, 150); }
        }

        protected override BasePainter CreatePainter() {
            return new ChartControlPainter();
        }
        protected override BaseViewInfo CreateViewInfo() {
            return new ChartControlViewInfo(this);
        }
        [Browsable(false)]
        public new ChartControlPainter Painter { get { return (ChartControlPainter)base.Painter; } }

        [Browsable(false)]
        public new ChartControlViewInfo ViewInfo { get { return (ChartControlViewInfo)base.ViewInfo; } }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    sealed class ChartLayoutCategoryAttribute : CategoryAttribute {
        public ChartLayoutCategoryAttribute() : base("Chart Layout") { }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    sealed class ChartViewCategoryAttribute : CategoryAttribute {
        public ChartViewCategoryAttribute() : base("Chart View") { }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    sealed class ChartDataCategoryAttribute : CategoryAttribute {
        public ChartDataCategoryAttribute() : base("Chart Data") { }
    }

    [DebuggerDisplay("ChartPoint(X={x},Y={Y})")]
    public struct ChartPoint {
        readonly double x;
        readonly double y;

        public ChartPoint(double x, double y) {
            this.x = x;
            this.y = y;
        }
        public double X { get { return x; } }
        public double Y { get { return y; } }
    }

    public class ChartSeries : Component {
        string label;
        Color color;
        ChartSeriesBounds bounds;
        ChartPointCollection pointList;

        public ChartSeries() {
            this.label = string.Empty;
            this.color = Color.Empty;
            this.bounds = new ChartSeriesBounds();
            this.pointList = new ChartPointCollection();
            this.pointList.CollectionChanged += OnPointListChanged;
        }
        public string Label {
            get { return label; }
            set {
                if(Label == value)
                    return;
                label = value;
                RaiseChanged(EventArgs.Empty);
            }
        }
        bool ShouldSerializeLabel() {
            if(string.IsNullOrEmpty(Label)) return false;
            return true;
        }
        void ResetLabel() {
            Label = string.Empty;
        }
        public ChartPointCollection PointList { get { return pointList; } }

        public Color Color {
            get { return color; }
            set {
                if(Color == value)
                    return;
                color = value;
                RaiseChanged(EventArgs.Empty);
            }
        }
        bool ShouldSerializeColor() {
            return Color != Color.Empty;
        }
        void ResetColor() {
            Color = Color.Empty;
        }
        
        public event EventHandler Changed;

        void RaiseChanged(EventArgs e) {
            if(Changed != null) Changed(this, e);
        }

        void OnPointListChanged(object sender, CollectionChangedEventArgs e) {
            switch(e.ChangeType) {
                case CollectionChangeType.Insert:
                    Bounds.CheckBounds(PointList[e.Index]);
                    break;
                case CollectionChangeType.SetItem:
                case CollectionChangeType.Remove:
                    Bounds.Clear();
                    PointList.ForEach(x => Bounds.CheckBounds(x));
                    break;
                case CollectionChangeType.Clear:
                    Bounds.Clear();
                    break;
            }
            RaiseChanged(EventArgs.Empty);
        }
        internal ChartSeriesBounds Bounds { get { return bounds; } }
    }

    public class ChartPointCollection : BaseCollection<ChartPoint> {
        public ChartPointCollection() { }
    }

    [DebuggerDisplay("ChartSeriesBounds(Left={Left},Right={Right},Top={Top},Bottom={Bottom})")]
    public class ChartSeriesBounds : EquatableObject<ChartSeriesBounds> {
        public ChartSeriesBounds()
            : this(double.NaN, double.NaN, double.NaN, double.NaN) {
        }
        public ChartSeriesBounds(double left, double right, double top, double bottom) {
            this.Left = left;
            this.Right = right;
            this.Top = top;
            this.Bottom = bottom;
        }
        public double Left {
            get;
            set;
        }
        public double Right {
            get;
            set;
        }
        public double Bottom {
            get;
            set;
        }
        public double Top {
            get;
            set;
        }
        public double Width {
            get {
                if(double.IsNaN(Right) || double.IsNaN(Left)) return double.NaN;
                return Right - Left;
            }
        }
        public double Height {
            get {
                if(double.IsNaN(Top) || double.IsNaN(Bottom)) return double.NaN;
                return Top - Bottom;
            }
        }
        public void CheckBounds(ChartPoint other) {
            CheckBounds(other.X, other.X, other.Y, other.Y);
        }
        public void CheckBounds(ChartSeriesBounds other) {
            CheckBounds(other.Left, other.Right, other.Top, other.Bottom);
        }
        public void CheckBounds(double left, double right, double top, double bottom) {
            if(double.IsNaN(Left) || left < Left) {
                Left = left;
            }
            if(double.IsNaN(Right) || right > Right) {
                Right = right;
            }
            if(double.IsNaN(Top) || top > Top) {
                Top = top;
            }
            if(double.IsNaN(Bottom) || bottom < Bottom) {
                Bottom = bottom;
            }
        }

        public bool IsNaN() {
            return double.IsNaN(Left) && double.IsNaN(Right) && double.IsNaN(Top) && double.IsNaN(Bottom);
        }
        public void Clear() {
            Left = Right = Top = Bottom = double.NaN;
        }

        #region Equals & GetHashCode

        protected override bool EqualsTo(ChartSeriesBounds other) {
            return Left == other.Left && Right == other.Right && Bottom == other.Bottom && Top == other.Top;
        }

        #endregion
    }

    public enum ChartGridDensity {
        Sparse = 1, Normal = 2, Dense = 3
    }

    public class ChartSeriesCollection : BaseCollection<ChartSeries> {
        public ChartSeriesCollection() {
        }
        protected override void OnItemAdded(ChartSeries item) {
            item.Changed += OnItemChanged;
        }
        protected override void OnItemRemoved(ChartSeries item) {
            item.Changed -= OnItemChanged;
        }
        void OnItemChanged(object sender, EventArgs e) {
            RaiseListChanged(new CollectionChangedEventArgs(CollectionChangeType.ItemChanged));
        }
    }
}
