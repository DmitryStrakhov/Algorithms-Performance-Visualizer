#if DEBUG

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms_Performance_Visualizer.Base;

namespace Algorithms_Performance_Visualizer.Tests {
    public class BaseTestForm<TControl> : Form where TControl : Control, new() {
        TControl control;
        public BaseTestForm() {
            InitializeForm();
            this.control = new TControl();
            InitializeTestControl(Control);
            Controls.Add(Control);
        }
        protected virtual void InitializeForm() {
            Size = new Size(350, 200);
        }
        protected virtual void InitializeTestControl(TControl control) {
            control.Location = new Point(10, 10);
            control.Size = new Size(250, 100);
        }
        public TControl Control { get { return control; } }
    }
}
#endif