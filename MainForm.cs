using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms_Performance_Visualizer.Base;

namespace Algorithms_Performance_Visualizer {
    public partial class MainForm : BaseForm {
        public MainForm() {
            InitializeComponent();
        }
        protected override BaseController CreateController() {
            return new MainFormController();
        }


        protected new MainFormController Controller { get { return (MainFormController)base.Controller; } }
    }

    public class MainFormController : BaseController {
        public MainFormController() {
        }
    }
}
