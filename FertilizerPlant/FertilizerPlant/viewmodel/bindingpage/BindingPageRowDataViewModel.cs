using System;
using System.Collections.Generic;
using static SerialIO.utils.SerialUtils;
using System.ComponentModel;
using FertilizerPlant.viewmodel.command.radiobutton;
using System.IO.Ports;
using System.Windows;
using QrCodeManagementService.utils.binding;

namespace FertilizerPlant.viewmodel.bindingpage
{
    /// <summary>
    /// This is the row view data model of qr binding page
    /// </summary>
    public class BindingPageRowDataViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// COM Id
        /// </summary>
        private string portId;
        /// <summary>
        /// The status of the device.Disconnected or OnMonitor ...
        /// </summary>
        private DeviceStatus deviceStatus;
        /// <summary>
        /// product names
        /// </summary>
        private IList<string> productNames;
        /// <summary>
        /// distributor names
        /// </summary>
        private IList<string> distributorNames;
        /// <summary>
        /// the number that has already been binded
        /// </summary>
        private int bindedCount;

        /// <summary>
        /// this represent the radio button to be used to start the binding
        /// </summary>
        private bool startedBinding=false;

        private StartMonitoringCommand startMonitoringCommand;
        
        private string selectedProduct;
        private string selectedDistributor;

        private SerialPort comPort;

        #region Start Port Command     
        /// <summary>
        /// first i have to check if the port can be opened or not.
        /// If i can not be opened,I need actually give a message box
        /// indicating some error
        /// </summary>
        /// <returns></returns>
        public bool CanStartPort()
        {
            if (!QrCodeBindingUtil.CheckIfDeviceOnline(portId))
            {
                MessageBox.Show("设备不能打开,请确保设备运行正常?");
                return false;
            }
            StartedBinding = true;
            return true;
        }

        /// <summary>
        /// WHen this method is executed,that means the port is already opened.
        /// In this thread,all we need to do is bind the data received event to the port
        /// </summary>
        public void StartMonitoringPort()
        {
            QrCodeBindingUtil.StartBindingProductToDistributorOnPort(portId, selectedProduct, selectedDistributor);
        }
        #endregion

        #region Stop Port Command
        public bool CanStopPort()
        {
            return true;
        }

        /// <summary>
        /// WHen this method is executed,that means the port is already opened.
        /// In this thread,all we need to do is bind the data received event to the port
        /// </summary>
        public void StopMonitoringPort()
        {
            QrCodeBindingUtil.StopBindingOnPort(portId);
            StartedBinding = false;
        }
        #endregion
        /// <summary>
        /// I should start a read and bind thread
        /// </summary>

        public string PortId
        {
            get
            {
                return portId;
            }

            set
            {
                if (portId != value)
                {
                    this.portId = value;
                    this.OnPropertyChanged("PortId");
                }
            }
        }

        public IList<string> ProductNames
        {
            get
            {
                return productNames;
            }

            set
            {
                productNames = value;
            }
        }

        public IList<string> DistributorNames
        {
            get
            {
                return distributorNames;
            }

            set
            {
                distributorNames = value;
            }
        }

        public DeviceStatus DeviceStatus
        {
            get
            {
                return deviceStatus;
            }

            set
            {
                deviceStatus = value;
            }
        }

        public int BindedCount
        {
            get
            {
                return bindedCount;
            }

            set
            {
                bindedCount = value;
            }
        }

        public bool StartedBinding
        {
            get
            {
                return startedBinding;
            }

            set
            {
                if (startedBinding != value)
                {
                    //when i try to set the value of start binding.We should 
                    this.startedBinding = value;
                    this.OnPropertyChanged("StartedBinding");
                }
            }
        }

        public StartMonitoringCommand StartMonitoringCommand
        {
            get
            {
                return startMonitoringCommand;
            }

            set
            {
                startMonitoringCommand = value;
            }
        }

        #region INotifyPropertyChanged Members
        /// <summary>
        /// this function will get called when property changed
        /// </summary>
        /// <param name="v"></param>
        private void OnPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                Console.WriteLine("v property changed to " + v);
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}