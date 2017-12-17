#if DEBUG

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms_Performance_Visualizer.Base;
using Algorithms_Performance_Visualizer.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms_Performance_Visualizer.Tests {
    #region TestChartControl

    class TestChartControl : ChartControl {
        public TestChartControl() {
        }
        internal new void UpdateViewInfo() {
            base.UpdateViewInfo();
        }
        protected override BasePainter CreatePainter() {
            return new TestChartControlPainter();
        }
        protected override BaseViewInfo CreateViewInfo() {
            return new TestChartControlViewInfo(this);
        }
    }

    class TestChartControlPainter : ChartControlPainter {
    }

    class TestChartControlViewInfo : ChartControlViewInfo {
        public TestChartControlViewInfo(TestChartControl control)
            : base(control) {
        }
    }

    #endregion

    #region TestForm

    class TestChartControlForm : BaseTestForm<TestChartControl> {
        public TestChartControlForm() {
        }
        protected override void InitializeTestControl(TestChartControl control) {
            base.InitializeTestControl(control);
            control.Size = new Size(580, 340);
            control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
        }
        protected override void InitializeForm() {
            Size = new Size(950, 440);
        }
    }

    #endregion

    [TestClass]
    public class ChartControlTests {
        TestChartControlForm form;
        TestChartControl control;

        [TestInitialize]
        public void SetUp() {
            this.form = new TestChartControlForm();
            this.control = this.form.Control;
            this.form.Show();
            this.form.Visible = true;
            this.form.Update();
        }
        [TestCleanup]
        public void TearDown() {
            this.form.Dispose();
            this.form = null;
            this.control = null;
        }
        ChartControlViewInfo ViewInfo { get { return Control.ViewInfo; } }
        TestChartControl Control { get { return control; } }

        [TestMethod, Ignore]
        public void ShowUpTest() {
            List<ChartPoint> pointList = new List<ChartPoint>();
            for(double x = -6.28; x <= 6.28; x += 0.01) {
                pointList.Add(new ChartPoint(x, Math.Sin(x)));
            }
            FillSimpleChartControl(Control, pointList.ToArray());
            this.form.Controls.Add(new PropertyGrid() { Width = 250, Dock = DockStyle.Right, SelectedObject = Control });
            while(this.form.Visible) {
                Application.DoEvents();
            }
        }
        [TestMethod]
        public void DefaultsTest() {
            Assert.IsNotNull(Control.Series);
            Assert.AreEqual(0, Control.Series.Count);
        }
        [TestMethod]
        public void OriginTest() {
            Assert.IsFalse(ViewInfo.Origin.IsEmpty);
            Assert.IsTrue(ViewInfo.Bounds.Contains(ViewInfo.Origin));
        }
        [TestMethod]
        public void AxesTest() {
            Assert.AreEqual(ViewInfo.Origin.Y, ViewInfo.AxesAbscissa.Y);
            Assert.IsTrue(ViewInfo.AxesAbscissa.X > ViewInfo.Bounds.Width / 2);
            Assert.AreEqual(ViewInfo.Origin.X, ViewInfo.AxesOrdinate.X);
            Assert.IsTrue(ViewInfo.AxesOrdinate.Y < ViewInfo.Bounds.Height / 2);
        }
        [TestMethod]
        public void ChartBoundsTest() {
            Assert.IsFalse(ViewInfo.ChartBounds.IsEmpty);
        }
        [TestMethod]
        public void LegendBoundsTest() {
            Assert.IsFalse(ViewInfo.LegendBounds.IsEmpty);
        }
        [TestMethod]
        public void RectsTest() {
            Assert.IsTrue(Rectangle.Intersect(ViewInfo.ChartBounds, ViewInfo.LegendBounds).IsEmpty);
            Assert.IsTrue(ViewInfo.LegendBounds.X > ViewInfo.ChartBounds.X);
        }
        [TestMethod]
        public void SeriesBoundsTest() {
            ChartSeries series = new ChartSeries();
            Assert.IsTrue(series.Bounds.IsNaN());
            series.Add(new ChartPoint(-100, 100));
            Assert.AreEqual(new ChartSeriesBounds(-100, -100, 100, 100), series.Bounds);
            series.Add(new ChartPoint(-200, 300));
            Assert.AreEqual(new ChartSeriesBounds(-200, -100, 300, 100), series.Bounds);
            series.Add(new ChartPoint(0, 40));
            Assert.AreEqual(new ChartSeriesBounds(-200, 0, 300, 40), series.Bounds);
            series.RemoveAt(1);
            Assert.AreEqual(new ChartSeriesBounds(-100, 0, 100, 40), series.Bounds);
            series.Clear();
            Assert.IsTrue(series.Bounds.IsNaN());
        }
        [TestMethod]
        public void ChartSeriesBoundsTest() {
            FillSimpleChartControl(Control, new ChartPoint(100, 100), new ChartPoint(200, 50), new ChartPoint(300, 200));
            FillSimpleChartControl(Control, new ChartPoint(250, 100), new ChartPoint(250, 300), new ChartPoint(400, 300), new ChartPoint(400, 100));
            Assert.AreEqual(new ChartSeriesBounds(100, 400, 300, 50), ViewInfo.SeriesBounds);
        }
        [TestMethod, ExpectedException(typeof(InvalidEnumArgumentException))]
        public void GridDensityGuardCase1Test() {
            Control.GridDensity = 0;
        }
        [TestMethod, ExpectedException(typeof(InvalidEnumArgumentException))]
        public void GridDensityGuardCase2Test() {
            Control.GridDensity = (ChartGridDensity)4;
        }
        [TestMethod]
        public void FormatTickLabelTest() {
            Assert.AreEqual("10", ViewInfo.FormatTickLabel(10));
            Assert.AreEqual("15", ViewInfo.FormatTickLabel(15.296));
            Assert.AreEqual("56", ViewInfo.FormatTickLabel(55.706));
        }
        [TestMethod]
        public void ShowGridTest() {
            Control.ShowGrid = true;
            Assert.AreNotEqual(0, ViewInfo.GridInfo.Count);
            Control.ShowGrid = false;
            Control.UpdateViewInfo();
            Assert.AreEqual(0, ViewInfo.GridInfo.Count);
            Control.ShowGrid = true;
            Control.UpdateViewInfo();
            Assert.AreNotEqual(0, ViewInfo.GridInfo.Count);
        }
        [TestMethod]
        public void GridLabelsSimpleTest() {
            Control.ShowGrid = true;
            Control.Series.Clear();
            Control.UpdateViewInfo();
            Assert.AreNotEqual(0, ViewInfo.GridInfo.Count);
            Assert.IsTrue(ViewInfo.GridInfo.Select(x => x.Label.Text).All(x => string.IsNullOrEmpty(x)));
            ChartPoint[] chartPoints = Enumerable.Range(0, 100).Select(x => new ChartPoint(x, x)).ToArray();
            FillSimpleChartControl(Control, chartPoints);
            Assert.AreNotEqual(0, ViewInfo.GridInfo.Count);
            Assert.IsTrue(ViewInfo.GridInfo.Select(x => x.Label.Text).All(x => !string.IsNullOrEmpty(x)));
        }
        [TestMethod]
        public void GridLabelsTest() {
            Control.ShowGrid = true;
            Control.GridDensity = ChartGridDensity.Normal;
            ChartPoint[] chartPoints = Enumerable.Range(-100, 201).Select(x => new ChartPoint(x, x)).ToArray();
            FillSimpleChartControl(Control, chartPoints);
            var labels = ViewInfo.GridInfo.Select(x => x.Label.Text);
            string[] expected = new string[] {
                "-100", "-50", "0", "50", "100", "-100", "-50", "0", "50", "100"
            };
            CollectionAssert.AreEquivalent(expected, labels.ToArray());
        }
        [TestMethod]
        public void ChartGridTest() {
            ChartPoint[] chartPoints = Enumerable.Range(0, 100).Select(x => new ChartPoint(x, x)).ToArray();
            FillSimpleChartControl(Control, chartPoints);
            Control.GridDensity = ChartGridDensity.Sparse;
            Control.UpdateViewInfo();
            Assert.AreEqual(6, ViewInfo.GridInfo.Count);
            Control.GridDensity = ChartGridDensity.Normal;
            Control.UpdateViewInfo();
            Assert.AreEqual(10, ViewInfo.GridInfo.Count);
            Control.GridDensity = ChartGridDensity.Dense;
            Control.UpdateViewInfo();
            Assert.AreEqual(18, ViewInfo.GridInfo.Count);
            Control.GridDensity = ChartGridDensity.Sparse;
            Control.UpdateViewInfo();
            Assert.AreEqual(6, ViewInfo.GridInfo.Count);
        }
        [TestMethod]
        public void ChartLegendTest() {
            FillChartControl(Control);
            Assert.AreEqual(2, ViewInfo.LegendViewInfo.Count);
            LegendItemViewInfo logLegend = ViewInfo.LegendViewInfo[0];
            LegendItemViewInfo polLegend = ViewInfo.LegendViewInfo[1];

            Assert.AreEqual("Logarithm", logLegend.Label);
            Assert.AreEqual(Color.Red, logLegend.Color);
            Assert.IsFalse(logLegend.ColorRect.IsEmpty);
            Assert.IsFalse(logLegend.LabelRect.IsEmpty);

            Assert.AreEqual("Polynomial", polLegend.Label);
            Assert.AreEqual(Color.Blue, polLegend.Color);
            Assert.IsFalse(polLegend.ColorRect.IsEmpty);
            Assert.IsFalse(polLegend.LabelRect.IsEmpty);

            Assert.AreEqual(logLegend.LabelRect.X, polLegend.LabelRect.X);
            Assert.AreEqual(logLegend.ColorRect.X, polLegend.ColorRect.X);
            Assert.IsTrue(logLegend.LabelRect.Bottom < polLegend.LabelRect.Y);
            Assert.IsTrue(logLegend.ColorRect.Bottom < polLegend.ColorRect.Y);
        }
        [TestMethod]
        public void ChartSeriesTest1() {
            FillSimpleChartControl(Control, new ChartPoint[0]);
            Assert.AreEqual(1, ViewInfo.SeriesViewInfoList.Count);
            Assert.AreEqual(1, ViewInfo.LegendViewInfo.Count);
            SeriesViewInfo series = ViewInfo.SeriesViewInfoList.First();
            Assert.AreEqual(0, series.Count);
        }
        [TestMethod]
        public void ChartSeriesTest2() {
            FillSimpleChartControl(Control, new ChartPoint(10, 10));
            Assert.AreEqual(1, ViewInfo.SeriesViewInfoList.Count);
            SeriesViewInfo series = ViewInfo.SeriesViewInfoList.First();
            Assert.AreEqual(1, series.Count);
            Point physicalPoint = series.First().Point;
            Rectangle pointArea = ViewInfo.ChartBounds.GetPivot().CreateRect(10, 10);
            Assert.IsTrue(pointArea.Contains(physicalPoint));
        }
        [TestMethod]
        public void ChartSeriesTest3() {
            ChartPoint[] chartPoints = Enumerable.Range(0, 100).Select(x => new ChartPoint(x, 2)).ToArray();
            FillSimpleChartControl(Control, chartPoints);
            Assert.AreEqual(1, ViewInfo.SeriesViewInfoList.Count);
            SeriesViewInfo series = ViewInfo.SeriesViewInfoList.First();
            Assert.AreEqual(100, series.Count);
            Rectangle pointArea = new Rectangle(ViewInfo.ChartBounds.X, ViewInfo.ChartBounds.Y + ViewInfo.ChartBounds.Height / 2 - 5, ViewInfo.ChartBounds.Width, 10).InflateWith(1, 1);
            foreach(SeriesItemViewInfo itemInfo in series) {
                Assert.IsTrue(pointArea.Contains(itemInfo.Point));
            }
        }
        [TestMethod]
        public void ChartSeriesTest4() {
            ChartPoint[] chartPoints = Enumerable.Range(0, 100).Select(x => new ChartPoint(2, x)).ToArray();
            FillSimpleChartControl(Control, chartPoints);
            Assert.AreEqual(1, ViewInfo.SeriesViewInfoList.Count);
            SeriesViewInfo series = ViewInfo.SeriesViewInfoList.First();
            Assert.AreEqual(100, series.Count);
            Rectangle pointArea = new Rectangle(ViewInfo.ChartBounds.X + ViewInfo.ChartBounds.Width / 2 - 5, ViewInfo.ChartBounds.Y, 10, ViewInfo.ChartBounds.Height).InflateWith(1, 1);
            foreach(SeriesItemViewInfo itemInfo in series) {
                Assert.IsTrue(pointArea.Contains(itemInfo.Point));
            }
        }
        [TestMethod]
        public void ChartSeriesTest5() {
            FillChartControl(Control);
            Assert.AreEqual(2, ViewInfo.SeriesViewInfoList.Count);
            SeriesViewInfo logSeries = ViewInfo.SeriesViewInfoList[0];
            SeriesViewInfo polSeries = ViewInfo.SeriesViewInfoList[1];

            Assert.AreEqual(100, logSeries.Count);
            Assert.AreEqual(100, polSeries.Count);
            Assert.AreEqual(Color.Red, logSeries.Color);
            Assert.AreEqual(Color.Blue, polSeries.Color);

            for(int i = 0; i < 99; i++) {
                Assert.IsTrue(logSeries[i + 1].Point.X > logSeries[i].Point.X);
                Assert.IsTrue(polSeries[i + 1].Point.X > polSeries[i].Point.X);
                Assert.IsTrue(logSeries[i + 1].Point.Y <= logSeries[i].Point.Y);
                Assert.IsTrue(polSeries[i + 1].Point.Y <= polSeries[i].Point.Y);
            }
            Rectangle pointArea = Rectangle.Inflate(ViewInfo.ChartBounds, 1, 1);
            for(int i = 0; i < 100; i++) {
                Assert.IsTrue(pointArea.Contains(logSeries[i].Point));
                Assert.IsTrue(pointArea.Contains(polSeries[i].Point));
            }
        }

        static void FillSimpleChartControl(TestChartControl chartControl, params ChartPoint[] chartPoints) {
            ChartSeries series = new ChartSeries();
            series.Color = Color.Red;
            series.Label = "Simple Series";
            for(int i = 0; i < chartPoints.Length; i++) {
                series.Add(chartPoints[i]);
            }
            chartControl.Series.Add(series);
            chartControl.UpdateViewInfo();
        }
        static void FillChartControl(TestChartControl chartControl) {
            ChartSeries logSeries = new ChartSeries();
            logSeries.Color = Color.Red;
            logSeries.Label = "Logarithm";
            for(int i = 1; i <= 100; i++) {
                logSeries.Add(new ChartPoint(i, Math.Log(i)));
            }
            ChartSeries polSeries = new ChartSeries();
            polSeries.Label = "Polynomial";
            polSeries.Color = Color.Blue;
            for(int i = 1; i <= 100; i++) {
                polSeries.Add(new ChartPoint(i, i * i));
            }
            chartControl.Series.Add(logSeries);
            chartControl.Series.Add(polSeries);
            chartControl.UpdateViewInfo();
        }
    }
}
#endif