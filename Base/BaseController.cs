using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Performance_Visualizer.Base {
    public class BaseController : INotifyPropertyChanged {
        ControllerState state;

        public BaseController() {
            this.state = ControllerState.Wait;
        }
        public ControllerState State {
            get { return state; }
            set {
                if(State == value)
                    return;
                state = value;
                OnPropertyChanged("State");
            }
        }
        public bool IsActive {
            get { return State == ControllerState.Active; }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {
            if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum ControllerState {
        Wait, Active
    }
}
