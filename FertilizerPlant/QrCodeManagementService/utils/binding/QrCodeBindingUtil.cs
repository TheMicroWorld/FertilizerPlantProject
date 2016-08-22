using ProductManagementService.entities.produt;
using ProductManagementService.services;
using ProductManagementService.services.product;
using QrCodeManagementService.entities.qrcode;
using QrCodeManagementService.services.qrcode;
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
    public static class QrCodeBindingUtil
    {
        private static readonly object lockObject = new object();
        private static IDictionary<string, SerialPort> portDictionary = new Dictionary<string, SerialPort>();
        private static IDictionary<string, List<string>> portToProdDistDict = new Dictionary<string, List<string>>();
        private static IDictionary<string, List<string>> collectedQrCodes = new Dictionary<string, List<string>>();
        private static ProductService productService = new DefaultProductService();
        private static DistributorService distributorService = new DefaultDistributorService();
        private static QrCodeService qrCodeService = new DefaultQrCodeService();

        public static void BindProductToDistributorWithQrCode(string qrCode, string productName, string distributorName)
        {
            QrCodeModel qrCodeModel = qrCodeService.FindById(qrCode);
            ProductModel product = productService.FindByProductName(productName);
            DistributorModel distributor = distributorService.FindDistributorByName(distributorName);
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
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            return true;
        }

        private static void StartBinding(string portId)
        {
            while (true)
            {
                lock (lockObject)
                {
                    List<string> existingQrCodes = collectedQrCodes[portId];
                    int count = existingQrCodes.Count;
                    if (count == 0)
                    {
                        Monitor.Wait(lockObject);
                    }
                    //fetching the product and distributor from prefilled dictionary,and call binding method
                    string qrCode = existingQrCodes[count - 1];
                    existingQrCodes.RemoveAt(count - 1);
                    string productName = portToProdDistDict[portId][0];
                    string distributorName = portToProdDistDict[portId][1];
                    BindProductToDistributorWithQrCode(qrCode, productName, distributorName);
                }
            }
        }

        public void StopBindingOnPort(string portId)
        {
            return;
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
                if (collectedQrCodes.ContainsKey(portName))
                {
                    List<string> qrCodesList = collectedQrCodes[portName];
                    qrCodesList.Add(indata);
                }
                else
                {
                    List<string> qrCodesList = new List<string>();
                    qrCodesList.Add(indata);
                    collectedQrCodes.Add(portName, qrCodesList);
                }
                Monitor.PulseAll(lockObject);
            }
        }
    }
}
