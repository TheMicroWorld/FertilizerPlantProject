using ProductManagementService.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.services.distributors;
using static SerialIO.utils.SerialUtils;
using SerialIO.utils;

namespace FertilizerPlant.viewmodel.bindingpage
{
    /// <summary>
    /// This is the row view data model of qr binding page
    /// </summary>
    public class BindingPageRowDataViewModel
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

        public string PortId
        {
            get
            {
                return portId;
            }

            set
            {
                portId = value;
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
    }
}
