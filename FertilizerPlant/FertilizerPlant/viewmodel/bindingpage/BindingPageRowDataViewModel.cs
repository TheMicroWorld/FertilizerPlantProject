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
