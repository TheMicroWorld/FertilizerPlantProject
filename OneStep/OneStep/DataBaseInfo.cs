using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OneStep
{
    class DataBaseInfo
    {
        public string ComID { get; set; }

        public SolidColorBrush FillColor { get; set; }
        public bool StartBind { get; set; }
        public bool StopBind { get; set; }

        public DataTable Product { get; set; }

        public DataTable Dealer { get; set; }
    }
}
