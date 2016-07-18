using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD_SerialIO;
using CD_LogicForCodeInfo;
using CD_LogicForConfigInfo;

namespace ShowItem
{
    class Program
    {
        static void Main(string[] args)
        {
            //以下代码演示用,单机版,掩饰一直写入数据

            //利用虚拟串口增加COM3
            SerialIO s = new SerialIO("COM8", 9600);

            if(!s.Open())
            {
                
                return;
            }

            
            //配置文件数据处理逻辑
            LogicForCodeInfo recordInfo = new LogicForCodeInfo();

            string error = string.Empty;
            while (true)
            {
                //这里需要利用串口工具不停的下发数据,工具读取数据
                string content = s.Read();
                if (!string.IsNullOrEmpty(content))
                {
                    Console.WriteLine(content);
                    if( !recordInfo.AppendRecordInfo(content, "贵州", "可口可乐",ref error) )
                    {

                    }
                }
            }
            s.Close();
        }
    }
}
