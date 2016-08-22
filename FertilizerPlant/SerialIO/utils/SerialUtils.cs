using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialIO.utils
{
    public static class SerialUtils
    {
        public  enum DeviceStatus
        {
            DISCONNECTED,
            CONNECTED,
            STOPPED,
            MONITORING,
        };
        /// <summary>
        /// Open and return a serial port.If there is no device connected.There will be exception thrown out
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="baudRate"></param>
        /// <returns></returns>
        public static  SerialPort Open(string comId, int baudRate)
        {
            SerialPort port = new SerialPort(comId, baudRate, Parity.None, 8, StopBits.One);
            port.Open();
            return port;
        }

        private void DataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            lock (lock_object)
            {
                collectedQrCodes.Add(indata);
            }
        }
    }
}
