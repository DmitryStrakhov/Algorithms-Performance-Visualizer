using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithms_Performance_Visualizer.Base {
    public class BaseForm : Form {
        BaseController controller;

        public BaseForm() {
            this.controller = null;
        }
        protected BaseController Controller {
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
