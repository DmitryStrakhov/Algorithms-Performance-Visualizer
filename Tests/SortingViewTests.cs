#if DEBUG

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms_Performance_Visualizer.Services;
using Algorithms_Performance_Visualizer.Views;
using Data_Structures_and_Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms_Performance_Visualizer.Tests {
    #region TestSortingView

    [ToolboxItem(false)]
    class TestSortingView : SortingView {
        readonly CheckBox bubbleSortCheckBoxCore;
        readonly CheckBox selectionSortCheckBoxCore;
        readonly CheckBox insertionSortCheckBoxCore;
        readonly CheckBox shellSortCheckBoxCore;
        readonly CheckBox mergeSortCheckBoxCore;
        readonly CheckBox heapSortCheckBoxCore;
        readonly CheckBox quickSortCheckBoxCore;
        readonly CheckBox treeSortCheckBoxCore;
        readonly CheckBox countingSortCheckBoxCore;
        readonly CheckBox bucketSortCheckBoxCore;
        readonly CheckBox radixSortCheckBoxCore;
        readonly Label progressLabelCore;
        readonly Button btnStartCore;

        public TestSortingView() {
            this.bubbleSortCheckBoxCore = this.GetControl<CheckBox>("bubbleSortCheckBox");
            this.selectionSortCheckBoxCore = this.GetControl<CheckBox>("selectionSortCheckBox");
            this.insertionSortCheckBoxCore = this.GetControl<CheckBox>("insertionSortCheckBox");
            this.shellSortCheckBoxCore = this.GetControl<CheckBox>("shellSortCheckBox");
            this.mergeSortCheckBoxCore = this.GetControl<CheckBox>("mergeSortCheckBox");
            this.heapSortCheckBoxCore = this.GetControl<CheckBox>("heapSortCheckBox");
            this.quickSortCheckBoxCore = this.GetControl<CheckBox>("quickSortCheckBox");
            this.treeSortCheckBoxCore = this.GetControl<CheckBox>("treeSortCheckBox");
            this.countingSortCheckBoxCore = this.GetControl<CheckBox>("countingSortCheckBox");
            this.bucketSortCheckBoxCore = this.GetControl<CheckBox>("bucketSortCheckBox");
            this.radixSortCheckBoxCore = this.GetControl<CheckBox>("radixSortCheckBox");
            this.progressLabelCore = this.GetControl<Label>("progressLabel");
            this.btnStartCore = this.GetControl<Button>("btnStart");
        }
        public CheckBox BubbleSortCheckBox { get { return bubbleSortCheckBoxCore; } }
        public CheckBox SelectionSortCheckBox { get { return selectionSortCheckBoxCore; } }
        public CheckBox InsertionSortCheckBox { get { return insertionSortCheckBoxCore; } }
        public CheckBox ShellSortCheckBox { get { return shellSortCheckBoxCore; } }
        public CheckBox MergeSortCheckBox { get { return mergeSortCheckBoxCore; } }
        public CheckBox HeapSortCheckBox { get { return heapSortCheckBoxCore; } }
        public CheckBox QuickSortCheckBox { get { return quickSortCheckBoxCore; } }
        public CheckBox TreeSortCheckBox { get { return treeSortCheckBoxCore; } }
        public CheckBox CountingSortCheckBox { get { return countingSortCheckBoxCore; } }
        public CheckBox BucketSortCheckBox { get { return bucketSortCheckBoxCore; } }
        public CheckBox RadixSortCheckBox { get { return radixSortCheckBoxCore; } }
        public Label ProgressLabel { get { return progressLabelCore; } }
        public Button StartButton {get { return btnStartCore; } }
    }

    #endregion

    #region TestSortingViewForm

    class TestSortingViewForm : BaseTestForm<TestSortingView> {
        public TestSortingViewForm() {
        }
        protected override void InitializeForm() {
            base.InitializeForm();
            Size = new Size(1226, 646);
        }
        protected override void InitializeTestControl(TestSortingView control) {
            control.Dock = DockStyle.Fill;
        }
    }

    #endregion

    #region TestISorter

    class TestISorter : ISorter {
        readonly int delay;

        public TestISorter(int delay = 10) {
            this.delay = delay;
        }
        public void Sort(SortDataItem[] data) {
            Thread.Sleep(this.delay);
        }
    }

    #endregion

    [TestClass]
    public class SortingViewTests {
        TestSortingViewForm form;
        TestSortingView view;
        SortingViewController controller;

        [TestInitialize]
        public void SetUp() {
            this.form = new TestSortingViewForm();
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
        TestSortingView View { get { return view; } }
        SortingViewController Controller { get { return controller; } }

        [TestMethod, Ignore]
        public void ShowUpTest() {
            while(this.form.Visible) {
                Application.DoEvents();
            }
        }
        [TestMethod]
        public void ControllerDefaultsTest() {
            Assert.IsTrue(Controller.AllowBubbleSort);
            Assert.IsTrue(Controller.AllowSelectionSort);
            Assert.IsTrue(Controller.AllowInsertionSort);
            Assert.IsTrue(Controller.AllowShellSort);
            Assert.IsTrue(Controller.AllowMergeSort);
            Assert.IsTrue(Controller.AllowHeapSort);
            Assert.IsTrue(Controller.AllowQuickSort);
            Assert.IsTrue(Controller.AllowTreeSort);
            Assert.IsTrue(Controller.AllowCountingSort);
            Assert.IsTrue(Controller.AllowBubbleSort);
            Assert.IsTrue(Controller.AllowRadixSort);
            Assert.IsTrue(string.IsNullOrEmpty(Controller.Progress));
            Assert.AreEqual(SortingViewControllerState.Wait, Controller.State);
        }
        [TestMethod]
        public void ControllerToViewBindingsTest() {
            Controller.AllowBubbleSort = true;
            Controller.AllowSelectionSort = false;
            Controller.AllowInsertionSort = true;
            Controller.AllowShellSort = false;
            Controller.AllowMergeSort = true;
            Controller.AllowHeapSort = false;
            Controller.AllowQuickSort = true;
            Controller.AllowTreeSort = false;
            Controller.AllowCountingSort = true;
            Controller.AllowBucketSort = false;
            Controller.AllowRadixSort = true;
            Controller.Progress = "phase #1";
            Assert.IsTrue(View.BubbleSortCheckBox.Checked);
            Assert.IsFalse(View.SelectionSortCheckBox.Checked);
            Assert.IsTrue(View.InsertionSortCheckBox.Checked);
            Assert.IsFalse(View.ShellSortCheckBox.Checked);
            Assert.IsTrue(View.MergeSortCheckBox.Checked);
            Assert.IsFalse(View.HeapSortCheckBox.Checked);
            Assert.IsTrue(View.QuickSortCheckBox.Checked);
            Assert.IsFalse(View.TreeSortCheckBox.Checked);
            Assert.IsTrue(View.CountingSortCheckBox.Checked);
            Assert.IsFalse(View.BucketSortCheckBox.Checked);
            Assert.IsTrue(View.RadixSortCheckBox.Checked);
            Assert.AreEqual("phase #1", View.ProgressLabel.Text);
        }
        [TestMethod]
        public void ViewToControllerBindingsTest() {
            View.BubbleSortCheckBox.Checked = false;
            View.SelectionSortCheckBox.Checked = true;
            View.InsertionSortCheckBox.Checked = false;
            View.ShellSortCheckBox.Checked = true;
            View.MergeSortCheckBox.Checked = false;
            View.HeapSortCheckBox.Checked = true;
            View.QuickSortCheckBox.Checked = false;
            View.TreeSortCheckBox.Checked = true;
            View.CountingSortCheckBox.Checked = false;
            View.BucketSortCheckBox.Checked = true;
            View.RadixSortCheckBox.Checked = false;
            View.ProgressLabel.Text = "phase #2";
            Assert.IsFalse(Controller.AllowBubbleSort);
            Assert.IsTrue(Controller.AllowSelectionSort);
            Assert.IsFalse(Controller.AllowInsertionSort);
            Assert.IsTrue(Controller.AllowShellSort);
            Assert.IsFalse(Controller.AllowMergeSort);
            Assert.IsTrue(Controller.AllowHeapSort);
            Assert.IsFalse(Controller.AllowQuickSort);
            Assert.IsTrue(Controller.AllowTreeSort);
            Assert.IsFalse(Controller.AllowCountingSort);
            Assert.IsTrue(Controller.AllowBucketSort);
            Assert.IsFalse(Controller.AllowRadixSort);
            Assert.AreEqual("phase #2", Controller.Progress);
        }
        [TestMethod]
        public void ViewStartStopButtonTextTest() {
            Controller.State = SortingViewControllerState.Wait;
            Assert.AreEqual("Start", View.StartButton.Text);
            Controller.State = SortingViewControllerState.Active;
            Assert.AreEqual("Stop", View.StartButton.Text);
            Controller.State = SortingViewControllerState.Wait;
            Assert.AreEqual("Start", View.StartButton.Text);
        }
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void SortGuardCase1Test() {
            Controller.Sort(null, new SortDataItem[0]);
        }
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void SortGuardCase2Test() {
            Controller.Sort(new TestISorter(), null);
        }
        [TestMethod]
        public void SortTest() {
            Task<long> task = Controller.Sort(new TestISorter(), new SortDataItem[] { new SortDataItem(1) });
            Assert.IsTrue(task.Result > 0);
        }
    }
}
#endif