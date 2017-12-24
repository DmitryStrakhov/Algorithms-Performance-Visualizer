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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms_Performance_Visualizer.Tests {
    #region TestControl

    [ToolboxItem(false)]
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
        protected override void DrawContent(DrawArgs drawArgs) { }
    }

    #endregion

    #region TestForm

    class TestBaseControlForm : BaseTestForm<TestControl> {
        public TestBaseControlForm() { }
    }

    #endregion


    [TestClass]
    public class BaseControlTests {
        TestBaseControlForm form;
        TestControl control;

        [TestInitialize]
        public void SetUp() {
            this.form = new TestBaseControlForm();
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
        TestControl Control { get { return control; } }

        [TestMethod, Ignore]
        public void ShowUpTest() {
            while(form.Visible) {
                Application.DoEvents();
            }
        }
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
    }
}
#endif