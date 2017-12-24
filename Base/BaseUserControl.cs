using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithms_Performance_Visualizer.Base {
    public class BaseUserControl : UserControl {
        BaseController controller;

        public BaseUserControl() {
            this.controller = null;
        }

        protected internal BaseController Controller {
            get {
                if(this.controller == null) {
                    this.controller = CreateController();
                }
                return this.controller;
            }
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if(!DesignMode) {
                Bind();
            }
        }

        protected virtual BaseController CreateController() {
            return null;
        }
        protected virtual void Bind() {
        }
    }
}
