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
using ProductManagementService.entities.produt;
using UserManagementService.entities.distributors;
using ProductManagementService.entities.stock;
using ProductManagementService.services.stock;
using ProductManagementService.services.warehouse;
using ProductManagementService.entities.warehouse;
using Remotion.Linq.Collections;
using System.IO.Ports;
using System.Threading;
using System.Configuration;

namespace FertilizerPlant.viewmodel.bindingpage
{
    /// <summary>
    /// The view model of the binding page
    /// </summary>
    public class BindingPageViewModel
    {
        private ObservableCollection<BindingPageRowDataViewModel> bindingPageData = new ObservableCollection<BindingPageRowDataViewModel>();
        /// <summary>
        /// product service to get the products
        /// </summary>
        private  ProductService productService;
        /// <summary>
        /// distributor service to get distributors
        /// </summary>
        private  DistributorService distributorService;


        /// <summary>
        /// 
        /// </summary>
        public BindingPageViewModel()
        {
            ProductService = new DefaultProductService();
            DistributorService = new DefaultDistributorService();
        }
        public IList<BindingPageRowDataViewModel> BindingPageData
        {
            get
            {
                //GenerateProductAndDistributorSampleData();
                RetriveBindingPageRowData();
                return bindingPageData;
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

        private void RetriveBindingPageRowData()
        {
            IList<string> ports = ConfigurationManager.AppSettings["PORTS"].Split(',').ToList<string>();
            foreach (string port in ports)
            {
                BindingPageRowDataViewModel rowData = new BindingPageRowDataViewModel();
                rowData.PortId = port;
                rowData.DeviceStatus = DeviceStatus.DISCONNECTED;
                rowData.ProductNames = ProductService.GetAllProductNames();
                rowData.DistributorNames = DistributorService.GetAllDistributorNames();
                bindingPageData.Add(rowData);
            }
        }
    }
}
