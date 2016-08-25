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
    }
}
