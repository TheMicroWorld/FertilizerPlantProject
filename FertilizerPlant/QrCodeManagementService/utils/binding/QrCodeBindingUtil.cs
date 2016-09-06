using ProductManagementService.entities.produt;
using ProductManagementService.services;
using ProductManagementService.services.product;
using QrCodeManagementService.entities.qrcode;
using QrCodeManagementService.services.qrcode;
using SerialIO.utils;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserManagementService.entities.distributors;
using UserManagementService.services.distributors;

namespace QrCodeManagementService.utils.binding
{
    public delegate void IncrementPortBindedCount(int bindedCount);
    public static class QrCodeBindingUtil
    {
        public static event IncrementPortBindedCount increasedBindingCount;
        private static readonly object lockObject = new object();
        private static IDictionary<string, SerialPort> portDictionary = new Dictionary<string, SerialPort>();
        private static IDictionary<string, List<string>> portToProdDistDict = new Dictionary<string, List<string>>();
        private static IDictionary<string, List<string>> collectedQrCodes = new Dictionary<string, List<string>>();
        private static IDictionary<string, Thread> threadPool = new Dictionary<string, Thread>();
        private static IDictionary<string, SerialUtils.DeviceStatus> portsStatus = new Dictionary<string, SerialUtils.DeviceStatus>();
        private static ProductService productService = new DefaultProductService();
        private static DistributorService distributorService = new DefaultDistributorService();
        private static QrCodeService qrCodeService = new DefaultQrCodeService();

        public static void BindProductToDistributorWithQrCode(string qrCode, string productName, string distributorName)
        {
            QrCodeModel qrCodeModel = qrCodeService.FindById(qrCode);
            ProductModel product = productService.FindById(productName);
            DistributorModel distributor = distributorService.FindById(distributorName);
            qrCodeModel.Distributor = distributor;
            qrCodeModel.Product = product;
            qrCodeService.Update(qrCodeModel);
        }

        /// <summary>
        /// this method will actually be caused
        /// </summary>
        /// <param name="portId"></param>
        /// <param name="productName"></param>
        /// <param name="distributorName"></param>
        public static void StartBindingProductToDistributorOnPort(string portId, string productName, string distributorName)
        {
            portToProdDistDict.Add(portId, new List<string> { productName, distributorName });
            Thread thread = new Thread(() => StartBinding(portId));
            thread.Start();
            threadPool.Add(portId, null);
            threadPool[portId] = thread;
        }

        /// <summary>
        /// check if device is connected,and can be opened
        /// </summary>
        /// <param name="comPort"></param>
        /// <returns></returns>
        public static bool CheckIfDeviceOnline(string comPort)
        {
            SerialPort port = new SerialPort(comPort, 9600);
            try
            {
                port.Open();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                return false;
            }

            //I have to add this port to a dictionary to make sure that the background thread can get it
            portDictionary.Add(comPort, port);
            portsStatus.Add(comPort, SerialUtils.DeviceStatus.MONITORING);
            collectedQrCodes.Add(comPort, new List<string>());
            port.DataReceived += DataReceivedHandler;
            return true;
        }
        /// <summary>
        /// start binding on port 
        /// </summary>
        /// <param name="portId"></param>
        private static void StartBinding(string portId)
        {
            int bindedCount = 0;
            while (portsStatus[portId] == SerialUtils.DeviceStatus.MONITORING)
            {
                lock (lockObject)
                {
                    List<string> existingQrCodes = collectedQrCodes[portId];
                    int count = existingQrCodes.Count;
                    while (count != 0)
                    {
                        //fetching the product and distributor from prefilled dictionary,and call binding method
                        string qrCode = existingQrCodes[count - 1];
                        existingQrCodes.RemoveAt(count - 1);
                        string productName = portToProdDistDict[portId][0];
                        string distributorName = portToProdDistDict[portId][1];
                        //BindProductToDistributorWithQrCode(qrCode, productName, distributorName);
                        count = existingQrCodes.Count;
                        if(increasedBindingCount != null)
                        {
                            increasedBindingCount(++bindedCount);
                        }
                    }
                    Monitor.Wait(lockObject);
                }
            }
            SerialPort port = portDictionary[portId];
            port.DataReceived -= DataReceivedHandler;
            try
            {
                port.Close();
            }
            catch(Exception e)
            {
            }
        }

        /// <summary>
        /// stop binding on port
        /// </summary>
        /// <param name="portId"></param>
        public static void StopBindingOnPort(string portId)
        {
            portsStatus[portId] = SerialUtils.DeviceStatus.STOPPED;
        }

        /// <summary>
        /// this is the data received event handler.It reads the data from port,and insert the read data into 
        /// the dictionary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DataReceivedHandler(
                               object sender,
                               SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string portName = sp.PortName;
            string indata = sp.ReadExisting();
            lock (lockObject)
            {
                List<string> qrCodesList = collectedQrCodes[portName];
                qrCodesList.Add(indata);
                Monitor.PulseAll(lockObject);
            }
        }
    }
}
