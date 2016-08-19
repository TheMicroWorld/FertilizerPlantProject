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

        private string selectedProduct;
        private string selectedDistributor;

        private IList<string> collectedQrCodes = new List<string>();

        /// <summary>
        /// this method start the real binding
        /// </summary>
        private void StartBinding()
        {
            lock(lock_object)
            {
                if(collectedQrCodes.Count == 0)
                {
                    Monitor.Wait(lock_object);
                }              
            }
        }

        /// <summary>
        /// we start the binding thread
        /// </summary>
        private void StartBindingProductWithDistributor()
        {
            Thread thread = new Thread(() => StartBindingThread());
            thread.Start();
        }
        /// <summary>
        /// data received event handler of the serial port
        /// </summary>
        private readonly object lock_object;
        private void DataReceivedEventHandler(object sender,SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            lock(lock_object)
            {
                collectedQrCodes.Add(indata);
            }
        }

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
                GenerateProductAndDistributorSampleData();
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
            IList<string> ports = ApplicationContext.GetConfiguredComPorts();
            foreach(string port in ports)
            {
                BindingPageRowDataViewModel rowData = new BindingPageRowDataViewModel();
                rowData.PortId = port;
                rowData.DeviceStatus = DeviceStatus.DISCONNECTED;
                rowData.ProductNames = ProductService.GetAllProductNames();
                rowData.DistributorNames = DistributorService.GetAllDistributorNames();
                rowData.StartMonitoringCommand = new command.radiobutton.StartMonitoringCommand(rowData.CanStartPort, rowData.StartMonitoringPort);
                rowData.BindedCount = 10;
                bindingPageData.Add(rowData);
            }
            Console.Write("THe number of row data is " + bindingPageData.Count);
        }

        private void GenerateProductAndDistributorSampleData()
        {
            StockLevelService stockLevelService = new DefaultStockLevelService();
            WarehouseService warehouseService = new DefaultWarehouseService();
            ProductModel product = new ProductModel();
            product.ProductName = "可口可乐";

            ProductModel product1 = new ProductModel();
            product1.ProductName = "黄老吉";

            ProductModel product2 = new ProductModel();
            product2.ProductName = "涨价玩";

            ProductModel product3 = new ProductModel();
            product3.ProductName = "直至牛肉";

            productService.Add(product);
            productService.Add(product1);
            productService.Add(product2);
            productService.Add(product3);

            IList<string> productNames = productService.GetAllProductNames();
            Console.WriteLine(productNames);

            DistributorModel distributor = new DistributorModel();
            distributor.Name = "黄凯";
            DistributorModel distributor1 = new DistributorModel();

            distributor1.Name = "德阳";
            DistributorModel distributor2 = new DistributorModel();

            distributor2.Name = "黄芪";

            distributorService.Add(distributor);
            distributorService.Add(distributor1);
            distributorService.Add(distributor2);
        }
    }
}
