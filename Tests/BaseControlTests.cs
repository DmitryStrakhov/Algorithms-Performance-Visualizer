#if DEBUG

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms_Performance_Visualizer.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms_Performance_Visualizer.Tests {
    #region TestControl

    class TestControl : BaseControl {
        public TestControl() {
        }
        protected override BaseViewInfo CreateViewInfo() {
            return new TestViewInfo(this);
        }
        protected override BasePainter CreatePainter() {
            return new TestPainter();
        }
    }

    class TestViewInfo : BaseViewInfo {
        public TestViewInfo(TestControl control)
            : base(control) {
        }
    }

    class TestPainter : BasePainter {
        public TestPainter() {
        }
        public override void Paint(DrawArgs drawArgs) {
            TestViewInfo viewInfo = (TestViewInfo)drawArgs.ViewInfo;
            drawArgs.Cache.DrawRectangle(Pens.Black, viewInfo.Bounds);
        }
    }

    #endregion

    #region TestForm

    class TestForm : Form {
        TestControl control;

        public TestForm() {
            Size = new Size(350, 200);
            this.control = CreateTestControl();
            InitializeTestControl(this.control);
            Controls.Add(this.control);
        }
        static TestControl CreateTestControl() {
            return new TestControl();
        }
        static void InitializeTestControl(TestControl control) {
            control.Location = new Point(10, 10);
            control.Size = new Size(250, 100);
        }
        public TestControl Control { get { return control; } }
    }

    #endregion


    [TestClass]
    public class BaseControlTests {
        TestForm form;
        TestControl control;

        [TestInitialize]
        public void SetUp() {
            this.form = new TestForm();
            this.control = this.form.Control;
            this.form.Show();
        }
        [TestCleanup]
        public void TearDown() {
            this.form.Dispose();
            this.form = null;
            this.control = null;
        }
        /*
        [TestMethod]
        public void ShowUpTest() {
            this.form.WindowState = FormWindowState.Normal;
            while(form.Visible) {
                Application.DoEvents();
            }
        }
        */
        [TestMethod]
        public void DefaultsTest() {
            Assert.AreSame(typeof(TestPainter), Control.Painter.GetType());
            Assert.AreSame(typeof(TestViewInfo), Control.ViewInfo.GetType());
        }
        [TestMethod]
        public void ViewInfoBoundsTest() {
            Control.Location = new Point(100, 100);
            Control.Size = new Size(300, 200);
            Assert.AreEqual(new Rectangle(0, 0, 300, 200), Control.ViewInfo.Bounds);
            Control.Location = new Point(150, 120);
            Control.Size = new Size(100, 80);
            Assert.AreEqual(new Rectangle(0, 0, 100, 80), Control.ViewInfo.Bounds);
        }

        Form Form { get { return form; } }
        TestControl Control { get { return control; } }
    }
}
#endif