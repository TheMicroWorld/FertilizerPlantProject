using ProductManagementService.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.services.distributors;
using static SerialIO.utils.SerialUtils;
using SerialIO.utils;
using FertilizerPlant.viewmodel;
using System.ComponentModel;
using FertilizerPlant.viewmodel.command.radiobutton;
using System.IO.Ports;
using System.Windows;
using System.Threading;

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
        /// <summary>
        /// first i have to check if the port can be opened or not.
        /// If i can not be opened,I need actually give a message box
        /// indicating some error
        /// </summary>
        /// <returns></returns>
        public bool CanStartPort()
        {
            try
            {
                SerialPort port = SerialUtils.Open(portId, 9600);
            }
            catch(Exception e)
            {
                MessageBox.Show("设备不能打开,设备插入啦吗?");
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

        }
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

        #region Processing Binding Logic
        private static IList<string> collectedQrCodes = new List<string>();

        private string selectedProduct;
        private string selectedDistributor;
        /// <summary>
        /// this method start the real binding
        /// </summary>
      
        /// <summary>
        /// data received event handler of the serial port
        /// </summary>
        private readonly object lock_object;
        private void DataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            lock (lock_object)
            {
                collectedQrCodes.Add(indata);
            }
        }
        #endregion
    }
}