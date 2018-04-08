#if DEBUG

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms_Performance_Visualizer.Base;
using Algorithms_Performance_Visualizer.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms_Performance_Visualizer.Tests {

    #region TestHashMapView

    class TestHashMapView : HashMapView {
        readonly Label progressLabelCore;
        readonly Button btnStartCore;
        readonly RadioButton rbAddCore;
        readonly RadioButton rbContainsKeyCore;

        public TestHashMapView() {
            this.progressLabelCore = this.GetControl<Label>("progressLabel");
            this.btnStartCore = this.GetControl<Button>("btnStart");
            this.rbAddCore = this.GetControl<RadioButton>("rbAdd");
            this.rbContainsKeyCore = this.GetControl<RadioButton>("rbContainsKey");
        }
        public Label ProgressLabel { get { return progressLabelCore; } }
        public Button StartButton { get { return btnStartCore; } }
        public RadioButton RbAdd { get { return rbAddCore; } }
        public RadioButton RbContainsKey { get { return rbContainsKeyCore; } }
    }

    #endregion

    class TestHashMapForm : BaseTestForm<TestHashMapView> {
        public TestHashMapForm() {
        }
        protected override void InitializeForm() {
            base.InitializeForm();
            Size = new Size(1226, 646);
        }
        protected override void InitializeTestControl(TestHashMapView control) {
            control.Dock = DockStyle.Fill;
        }
    }

    [TestClass]
    public class HashMapViewTests {
        TestHashMapForm form;
        TestHashMapView view;
        HashMapViewController controller;

        [TestInitialize]
        public void SetUp() {
            this.form = new TestHashMapForm();
            this.view = this.form.Control;
            this.controller = View.Controller;
            this.form.Show();
            this.form.Visible = true;
            this.form.Update();
        }
        [TestCleanup]
        public void TearDown() {
            this.form.Dispose();
            this.form = null;
            this.view = null;
            this.controller = null;
        }
        TestHashMapForm Form { get { return form; } }
        TestHashMapView View { get { return view; } }
        HashMapViewController Controller { get { return controller; } }

        [TestMethod, Ignore]
        public void ShowUpTest() {
            while(this.form.Visible) {
                Application.DoEvents();
            }
        }
        [TestMethod]
        public void ControllerDefaultsTest() {
            Assert.AreEqual(string.Empty, Controller.Progress);
            Assert.AreEqual(ControllerState.Wait, Controller.State);
            Assert.AreEqual(HashMapOperation.Add, Controller.Operation);
        }
        [TestMethod]
        public void ViewDefaultsTest() {
            Assert.IsTrue(View.RbAdd.Checked);
            Assert.IsFalse(View.RbContainsKey.Checked);
        }
        [TestMethod]
        public void ControllerToViewBindingsTest() {
            Assert.AreEqual(string.Empty, View.ProgressLabel.Text);
            Controller.Progress = "stage #1";
            Assert.AreEqual("stage #1", View.ProgressLabel.Text);
            Controller.Progress = "stage #2";
            Assert.AreEqual("stage #2", View.ProgressLabel.Text);
            Controller.Progress = string.Empty;
            Assert.AreEqual(string.Empty, View.ProgressLabel.Text);
        }
        [TestMethod]
        public void ViewStartStopButtonTextTest() {
            Controller.State = ControllerState.Wait;
            Assert.AreEqual("Start", View.StartButton.Text);
            Controller.State = ControllerState.Active;
            Assert.AreEqual("Stop", View.StartButton.Text);
            Controller.State = ControllerState.Wait;
            Assert.AreEqual("Start", View.StartButton.Text);
        }
        [TestMethod]
        public void ControllerOperationTypeTest() {
            Controller.Operation = HashMapOperation.Add;
            Assert.IsTrue(View.RbAdd.Checked);
            Assert.IsFalse(View.RbContainsKey.Checked);
            Controller.Operation = HashMapOperation.ContainsKey;
            Assert.IsFalse(View.RbAdd.Checked);
            Assert.IsTrue(View.RbContainsKey.Checked);
            Controller.Operation = HashMapOperation.Add;
            Assert.IsTrue(View.RbAdd.Checked);
            Assert.IsFalse(View.RbContainsKey.Checked);
        }
        [TestMethod]
        public void ViewOperationTypeTest() {
            View.RbAdd.Checked = true;
            Assert.AreEqual(HashMapOperation.Add, Controller.Operation);
            View.RbContainsKey.Checked = true;
            Assert.AreEqual(HashMapOperation.ContainsKey, Controller.Operation);
            View.RbAdd.Checked = true;
            Assert.AreEqual(HashMapOperation.Add, Controller.Operation);
        }
    }
}
#endif