using System;
using System.Collections.Generic;
using static SerialIO.utils.SerialUtils;
using System.ComponentModel;
using FertilizerPlant.viewmodel.command.radiobutton;
using System.IO.Ports;
using System.Windows;
using QrCodeManagementService.utils.binding;
using System.Threading;
using QrCodeManagementService.services.binding;
using System.Threading.Tasks;
using System.Text;

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
        private int bindedCount = 0 ;
        private void IncreaseTheBindedCount(int bindedCount)
        {
            BindedCount = bindedCount;
        }
        /// <summary>
        /// this represent the radio button to be used to start the binding
        /// </summary>
        private bool startedBinding;
        
        private string selectedProduct;
        private string selectedDistributor;

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
                this.OnPropertyChanged("BindedCount");
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
                ///this part of code is really messy
                if (startedBinding == false)
                {
                    if (startedBinding != value)
                    {
                        if(!CanStartPort())
                        {
                            startedBinding = false;
                            return;
                        }
                        startedBinding = true;
                        StartMonitoringPort();
                    }
                }
                else
                {
                    if (startedBinding != value)
                    {
                        startedBinding = false;
                        StopMonitoringPort();
                    }
                }
            }
        }

        public string SelectedProduct
        {
            get
            {
                if (selectedProduct == null)
                {
                    selectedProduct = productNames[0];           
                }
                return selectedProduct;
            }

            set
            {
                selectedProduct = value;
            }
        }

        public string SelectedDistributor
        {
            get
            {
                if(selectedDistributor==null)
                {
                    selectedDistributor = distributorNames[0];
                }
                return selectedDistributor;
            }

            set
            {
                selectedDistributor = value;
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
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Binding Logic
        /// <summary>
        /// If each row has its own collectedQrCodes.Then we will have 
        /// we will start thread for each row.This sounds better
        /// </summary>
        private List<string> collectedQrCodes = new List<string>();

        private void DataReceivedHandler(
                             object sender,
                             SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string portName = sp.PortName;
            string indata = sp.ReadLine();
            lock (collectedQrCodes)
            {
                collectedQrCodes.Add(indata);
                //when call monitor pulse,then the lock is released.This thread can be terminated
                Monitor.PulseAll(collectedQrCodes);
            }
        }

        #region Start Port Command     
        /// <summary>
        /// first i have to check if the port can be opened or not.
        /// If i can not be opened,I need actually give a message box
        /// indicating some error
        /// </summary>
        /// <returns></returns>
        public bool CanStartPort()
        {
            if (!CheckIfDeviceOnline())
            {
                MessageBox.Show("设备不能打开,请确保设备运行正常?");
                //we have to set twice to make sure the UI is synced with under lying data
                return false;
            }
            return true;
        }
        #endregion

        /// <summary>
        /// WHen this method is executed,that means the port is already opened.
        /// In this thread,all we need to do is bind the data received event to the port
        /// </summary>
        public void StartMonitoringPort()
        {
            serialPort.DataReceived += DataReceivedHandler;
            Thread thread = new Thread(() => StartBinding());
            thread.Start();
        }

        private SerialPort serialPort;
        public bool CheckIfDeviceOnline()
        {
            serialPort = new SerialPort(portId, 9600,Parity.None,8,StopBits.One);
            try
            {
                serialPort.Open();
            }
            catch (Exception e)
            {
                serialPort = null;
                Console.Write(e.StackTrace);
                return false;
            }
            return true;
        }

        /// <summary>
        /// This is the binding function
        /// </summary>
        private BindingService bindingService = new DefaultBindingService();
        private void StartBinding()
        {
            StringBuilder builder = new StringBuilder();
            lock (collectedQrCodes)
            {
                while (startedBinding)
                {
                    int count = collectedQrCodes.Count;
                    while (count != 0)
                    {        
                        Console.Write(collectedQrCodes[count - 1]);
                        bindingService.BindProductWithDistributor(collectedQrCodes[count - 1], selectedProduct, selectedDistributor);
                        collectedQrCodes.RemoveAt(count - 1);
                        count = collectedQrCodes.Count;
                        BindedCount = BindedCount + 1;
                    }
                    Monitor.Wait(collectedQrCodes);
                }
                Console.WriteLine("out of current task");
            }
        }

        /// <summary>
        /// stop binding will set started binding as false
        /// and unregister and stop the port
        /// </summary>
        public void StopMonitoringPort()
        {
            ///Is it possible that i can not aquire the lock?Not very possible
            lock (collectedQrCodes)
            {
                serialPort.DataReceived -= DataReceivedHandler;
                Monitor.PulseAll(collectedQrCodes);
            }        
            try
            {
                serialPort.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("关闭端口出错");
            }
            return;
        }
        #endregion
    }
}