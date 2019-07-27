#if DEBUG

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms_Performance_Visualizer.Base;
using Algorithms_Performance_Visualizer.Data;
using Algorithms_Performance_Visualizer.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms_Performance_Visualizer.Tests {

    #region TestView

    public sealed class TestStringMatchingView : StringMatchingView {
        readonly TabControl tabControlCore;
        readonly Button startButtonCore;
        readonly Label progressLabelCore;
        readonly RadioButton rbSuccessCore;
        readonly RadioButton rbFailCore;

        public TestStringMatchingView() {
            this.startButtonCore = this.GetControl<Button>("btnStart");
            this.tabControlCore = this.GetControl<TabControl>("tabControl");
            this.progressLabelCore = this.GetControl<Label>("progressLabel");
            this.rbSuccessCore = this.GetControl<RadioButton>("rbSuccess");
            this.rbFailCore = this.GetControl<RadioButton>("rbFail");
        }
        public TabControl TabControl { get { return tabControlCore; } }
        public Button StartButton { get { return startButtonCore; } }
        public Label ProgressLabel { get { return progressLabelCore; } }
        public RadioButton RbSuccess { get { return rbSuccessCore; } }
        public RadioButton RbFail { get { return rbFailCore; } }
        public StringMatchingBenchmarkViewBase BenchmarkView { get { return this.GetControl<StringMatchingBenchmarkViewBase>("benchmarkView"); } }
    }

    #endregion

    #region TestForm

    public sealed class TestStringMatchingForm : BaseTestForm<TestStringMatchingView> {
        public TestStringMatchingForm() {
        }
        protected override void InitializeForm() {
            base.InitializeForm();
            Size = new Size(1226, 646);
        }
        protected override void InitializeTestControl(TestStringMatchingView control) {
            control.Dock = DockStyle.Fill;
        }
    }

    #endregion

    [TestClass]
    public class StringMatchingViewTests {
        TestStringMatchingForm form;
        TestStringMatchingView view;
        StringMatchingBenchmarkViewControllerBase controller;

        [TestInitialize]
        public void SetUp() {
            this.form = new TestStringMatchingForm();
            this.view = form.Control;
            this.controller = view.BenchmarkController;
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
        [TestMethod, Ignore]
        public void ShowUpTest() {
            while(form.Visible) {
                Application.DoEvents();
            }
        }
        [TestMethod]
        public void ControllerDefaultsTest() {
            Assert.AreEqual(string.Empty, controller.Progress);
            Assert.AreEqual(ControllerState.Wait, controller.State);
            Assert.AreEqual(OperationResult.Success, controller.OperationResult);
        }
        [TestMethod]
        public void ViewDefaultsTest() {
            Assert.IsNotNull(view.BenchmarkView);
            Assert.AreEqual(5, view.TabControl.TabCount);
            Assert.AreEqual(0, view.TabControl.SelectedIndex);
            Assert.IsTrue(view.RbSuccess.Checked);
            Assert.IsFalse(view.RbFail.Checked);
        }
        [TestMethod]
        public void ViewStartStopButtonTextTest() {
            controller.State = ControllerState.Wait;
            Assert.AreEqual("Start", view.StartButton.Text);
            controller.State = ControllerState.Active;
            Assert.AreEqual("Stop", view.StartButton.Text);
            controller.State = ControllerState.Wait;
            Assert.AreEqual("Start", view.StartButton.Text);
        }
        [TestMethod]
        public void ControllerProgressTest() {
            Assert.AreEqual(string.Empty, view.ProgressLabel.Text);
            controller.Progress = "stage #1";
            Assert.AreEqual("stage #1", view.ProgressLabel.Text);
            controller.Progress = "stage #2";
            Assert.AreEqual("stage #2", view.ProgressLabel.Text);
            controller.Progress = string.Empty;
            Assert.AreEqual(string.Empty, view.ProgressLabel.Text);
        }
        [TestMethod]
        public void BenchmarkViewsTest() {
            int tabCount = view.TabControl.TabCount;
            Assert.AreEqual(5, tabCount);
            Assert.AreEqual(0, view.TabControl.SelectedIndex);

            Type[] benchmarkViewTypes = new Type[tabCount];
            for(int n = tabCount - 1; n >= 0; n--) {
                view.TabControl.SelectedIndex = n;
                benchmarkViewTypes[n] = view.BenchmarkView.GetType();
            }
            Type[] expectedTypes = new Type[] {
                typeof(SmPreprocessingView),
                typeof(SmSearchView),
                typeof(SmSummaryView),
                typeof(TreeBuildingView),
                typeof(TreeSearchView),
            };
            CollectionAssert.AreEqual(expectedTypes, benchmarkViewTypes);
        }
        [TestMethod]
        public void ViewOperationResultTest() {
            Assert.IsTrue(view.RbSuccess.Checked);
            Assert.IsFalse(view.RbFail.Checked);
            Assert.AreEqual(OperationResult.Success, controller.OperationResult);

            controller.OperationResult = OperationResult.Fail;
            Assert.IsFalse(view.RbSuccess.Checked);
            Assert.IsTrue(view.RbFail.Checked);
            Assert.AreEqual(OperationResult.Fail, controller.OperationResult);

            controller.OperationResult = OperationResult.Success;
            Assert.IsTrue(view.RbSuccess.Checked);
            Assert.IsFalse(view.RbFail.Checked);
            Assert.AreEqual(OperationResult.Success, controller.OperationResult);
        }
        [TestMethod]
        public void ControllerOperationResultTest() {
            Assert.IsTrue(view.RbSuccess.Checked);
            Assert.IsFalse(view.RbFail.Checked);
            Assert.AreEqual(OperationResult.Success, controller.OperationResult);

            view.RbFail.Checked = true;
            Assert.IsFalse(view.RbSuccess.Checked);
            Assert.IsTrue(view.RbFail.Checked);
            Assert.AreEqual(OperationResult.Fail, controller.OperationResult);

            view.RbSuccess.Checked = true;
            Assert.IsTrue(view.RbSuccess.Checked);
            Assert.IsFalse(view.RbFail.Checked);
            Assert.AreEqual(OperationResult.Success, controller.OperationResult);
        }
    }
}
#endif