using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FertilizerPlant.viewmodel.command.radiobutton
{
    public class StopMonitoringCommand : ICommand
    {
        /// <summary>
        /// this action is used to start monitoring the port 
        /// </summary>
        private Action stopMonitoringPort;
        /// <summary>
        /// this funcion will be passed in from view model,meaning that if the port can be opened
        /// </summary>
        private Func<bool> canStopPort;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canStopPort();
        }

        public void Execute(object parameter)
        {
            stopMonitoringPort();
        }
        public StopMonitoringCommand(Func<bool> canStopPort, Action stopMonitoringPort)
        {
            this.stopMonitoringPort = stopMonitoringPort;
            this.canStopPort = canStopPort;
        }
    }
}
