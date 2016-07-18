using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD_FileStream;

namespace CD_LogicForCodeInfo
{

    /// <summary>
    /// 用于处理串口上报数据关系
    /// </summary>
    public class LogicForCodeInfo
    {
        string configFilePath;

        public LogicForCodeInfo()
        {
            configFilePath = "D:\\RecordInfo.txt";
        }

        public LogicForCodeInfo(string path)
        {
            configFilePath = path;
        }

        /// <summary>
        /// 当不能连接数据库时调用,备份数据
        /// </summary>
        /// <param name="code"></param>
        /// <param name="dealer"></param>
        /// <param name="products"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AppendRecordInfo(string code, string dealer, string products, ref string error)
        {
            if(string.IsNullOrEmpty(code) || string.IsNullOrEmpty(dealer) || string.IsNullOrEmpty(products))
            {
                return false;
            }

            string record = string.Format("{0},{1},{2}\r\n", code, dealer, products);   //生成关系表,后续考虑直接保存SQL语句？

            lock (configFilePath)
            {
                FileStream.SetFilePath(configFilePath);
                if (!FileStream.Append(record, ref error))
                {
                    return false;
                }
            }

            return true;
        }
        

        /// <summary>
        /// 核查数据,定时触发或者连接数据库时触发
        /// </summary>
        /// <returns></returns>
        public bool CheckRecordInfo(ref string recordInfo)
        {
            string error = string.Empty;

            lock (configFilePath)
            {
                FileStream.SetFilePath(configFilePath);
                if (!FileStream.Read(ref recordInfo, ref error))
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}
