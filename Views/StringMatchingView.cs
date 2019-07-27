using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Algorithms_Performance_Visualizer.Base;
using Algorithms_Performance_Visualizer.Data;

namespace Algorithms_Performance_Visualizer.Views {
    public partial class StringMatchingView : BaseUserControl {
        StringMatchingBenchmarkViewBase benchmarkView;

        public StringMatchingView() {
            this.benchmarkView = null;
            InitializeComponent();
            OnBenchmarkViewChanged();
        }
        protected override BaseController CreateController() {
            return new StringMatchingViewController();
        }

        void OnSuccessButtonParseOperationResult(object sender, ConvertEventArgs e) {
            if(e.DesiredType != typeof(OperationResult)) return;
            e.Value = e.Value.CastTo<bool>() ? OperationResult.Success : OperationResult.Fail;
        }
        void OnSuccessButtonFormatOperationResult(object sender, ConvertEventArgs e) {
            if(e.DesiredType != typeof(bool)) return;
            e.Value = e.Value.CastTo<OperationResult>() == OperationResult.Success;
        }
        void OnFailButtonParseOperationResult(object sender, ConvertEventArgs e) {
            if(e.DesiredType != typeof(OperationResult)) return;
            e.Value = e.Value.CastTo<bool>() ? OperationResult.Fail : OperationResult.Success;
        }
        void OnFailButtonFormatOperationResult(object sender, ConvertEventArgs e) {
            if(e.DesiredType != typeof(bool)) return;
            e.Value = e.Value.CastTo<OperationResult>() == OperationResult.Fail;
        }
        void OnControllerStateToStringConvertHandler(object sender, ConvertEventArgs e) {
            if(e.DesiredType != typeof(string)) return;
            e.Value = (e.Value.CastTo<ControllerState>() == ControllerState.Wait ? "Start" : "Stop");
        }

        #region Handlers

        void OnStartButtonClick(object sender, EventArgs e) {
            Debug.Assert(benchmarkView != null);

            if(BenchmarkController.State == ControllerState.Wait) {
                BenchmarkController.State = ControllerState.Active;
                benchmarkView.Start();
            }
            else {
                BenchmarkController.State = ControllerState.Wait;
            }
        }
        void OnClearButtonClick(object sender, EventArgs e) {
            benchmarkView?.ClearChart();
        }
        void OnTabControlSelectedIndexChanged(object sender, EventArgs e) {
            OnBenchmarkViewChanged();
        }

        #endregion

        private void OnBenchmarkViewChanged() {
            benchmarkView = tabControl.SelectedTab.SingleChild<StringMatchingBenchmarkViewBase>();
            UpdateBindings();
        }
        private void UpdateBindings() {
            if(benchmarkView == null) return;
            progressLabel.Bind(nameof(Label.Text), BenchmarkController, nameof(BenchmarkController.Progress), clearBindings: true);
            btnStart.Bind(nameof(Button.Text), BenchmarkController, nameof(BenchmarkController.State), formatDelegate: OnControllerStateToStringConvertHandler, clearBindings: true, readValue: true);
            rbSuccess.Bind(nameof(RadioButton.Enabled), BenchmarkController, nameof(BenchmarkController.SupportsDifferentOperationResults), clearBindings: true);
            rbFail.Bind(nameof(RadioButton.Enabled), BenchmarkController, nameof(BenchmarkController.SupportsDifferentOperationResults), clearBindings: true);
            rbSuccess.Bind(nameof(RadioButton.Checked), BenchmarkController, nameof(BenchmarkController.OperationResult), formatDelegate: OnSuccessButtonFormatOperationResult, parseDelegate: OnSuccessButtonParseOperationResult, readValue: true);
            rbFail.Bind(nameof(RadioButton.Checked), BenchmarkController, nameof(BenchmarkController.OperationResult), formatDelegate: OnFailButtonFormatOperationResult, parseDelegate: OnFailButtonParseOperationResult, readValue: true);
        }
        internal StringMatchingBenchmarkViewControllerBase BenchmarkController { get { return benchmarkView?.Controller; } }
    }


    public sealed class StringMatchingViewController : BaseController {
        public StringMatchingViewController() {
        }
    }
}
