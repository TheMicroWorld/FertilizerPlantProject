using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerialIO.utils;
using static SerialIO.utils.SerialUtils;
using ProductManagementService.services;
using UserManagementService.services.distributors;
using FertilizerPlant.global.context;
using ProductManagementService.services.product;

namespace FertilizerPlant.viewmodel.bindingpage
{
    /// <summary>
    /// The view model of the binding page
    /// </summary>
    public class BindingPageViewModel
    {
        private IList<BindingPageRowDataViewModel> bindingPageData;
        /// <summary>
        /// product service to get the products
        /// </summary>
        private  ProductService productService;
        /// <summary>
        /// distributor service to get distributors
        /// </summary>
        private  DistributorService distributorService;
        public BindingPageViewModel()
        {
            ProductService = new DefaultProductService();
            DistributorService = new DefaultDistributorService();
        }
        public IList<BindingPageRowDataViewModel> BindingPageData
        {
            get
            {
                return bindingPageData;
            }

            set
            {
                bindingPageData = value;
            }
        }

        public ProductService ProductService
        {
            get
            {
                return productService;
            }

            set
            {
                productService = value;
            }
        }

        public DistributorService DistributorService
        {
            get
            {
                return distributorService;
            }

            set
            {
                distributorService = value;
            }
        }

        private void SetBindingPageViewData()
        {
            IList<string> ports = ApplicationContext.GetConfiguredComPorts();
            foreach(string port in ports)
            {
                BindingPageRowDataViewModel rowData = new BindingPageRowDataViewModel();
                rowData.PortId = port;
                rowData.DeviceStatus = DeviceStatus.DISCONNECTED;
                rowData.ProductNames = ProductService.GetAllProductNames();
                rowData.DistributorNames = DistributorService.GetAllDistributorNames();
                rowData.coun
            }
        }
    }
}
