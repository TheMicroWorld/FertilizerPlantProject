using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_SerialIO
{
    public class SerialIO
    {
        private SerialPort com;
        private StringBuilder msgBuff;

        private string ComID;
        private int baudRate;

        public SerialIO(string ComID, int baudRate)
        {
            this.ComID = ComID;
            this.baudRate = baudRate;
            msgBuff = new StringBuilder();
        }

        private void OnDataReceived(object sender, SerialDataReceivedEventArgs ar)
        {
            int msgLen = com.BytesToRead;
            byte[] buf = new byte[msgLen];
            lock (msgBuff)
            {
                com.Read(buf, 0, msgLen);
                msgBuff.AppendFormat("{0}|", Encoding.ASCII.GetString(buf));
            }
        }

        public bool Open()
        {
            try
            {
                com = new SerialPort(ComID, baudRate, Parity.None, 8, StopBits.One);
                com.DataReceived += OnDataReceived;
                com.Open();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Close()
        {
            try
            {
                com.DataReceived -= OnDataReceived;
                com.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public string Read()
        {
            string read = string.Empty;
            lock (msgBuff)
            {
                if (msgBuff.Length > 0)
                {
                    read = msgBuff.ToString();
                    msgBuff.Clear();
                }
            }
            return read;
        }

    }
}
