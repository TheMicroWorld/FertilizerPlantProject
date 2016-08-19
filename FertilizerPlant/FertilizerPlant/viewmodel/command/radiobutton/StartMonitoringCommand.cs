using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FertilizerPlant.viewmodel.command.radiobutton
{
    public class StartMonitoringCommand : ICommand
    {
        /// <summary>
        /// this action is used to start monitoring the port 
        /// </summary>
        private Action StartMonitoringPort;
        /// <summary>
        /// this funcion will be passed in from view model,meaning that if the port can be opened
        /// </summary>
        private Func<bool> CanStartPort;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return CanStartPort();
        }

        public void Execute(object parameter)
        {
            StartMonitoringPort();
        }
        public StartMonitoringCommand(Func<bool> CanStartPort,Action StartMonitoringPort)
        {
            this.StartMonitoringPort = StartMonitoringPort;
            this.CanStartPort = CanStartPort;
        }
    }
}
