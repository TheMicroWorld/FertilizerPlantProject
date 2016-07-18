using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD_FileStream;

namespace CD_LogicForConfigInfo
{
    /// <summary>
    /// 用于处理配置文件关系
    /// </summary>
    public class LogicForConfigInfo
    {
        string configFilePath;
        public Dictionary<string, string> configLst = new Dictionary<string, string>();

        public LogicForConfigInfo()
        {
            configFilePath = "D:\\Config.txt";
        }

        public LogicForConfigInfo(string path)
        {
            configFilePath = path;
        }

        /// <summary>
        /// 从数据库读取数据写入配置文件,configInfo由外部按指定格式传入 经销商名称,商品名称 以|间隔,备注需确认经销商是否唯一
        /// </summary>
        /// <returns></returns>
        public bool WriteConfigInfo(string configInfo, ref string error)
        {
            lock(configLst)
            {
                configLst.Clear();

                foreach (var info in configInfo.Split('|'))
                {
                    string[] config = info.Split(',');
                    if (2 != config.Length)
                    {
                        continue;
                    }

                    if (configLst.ContainsKey(config[0]))
                    {
                        configLst[config[0]] = config[1];
                        continue;
                    }

                    configLst.Add(config[0], config[1]);
                }
            }

            lock(configFilePath)
            {
                FileStream.SetFilePath(configFilePath);
                if (!FileStream.Write(configInfo, ref error))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 用于当服务器连接断开时,从本地读取数据备用
        /// </summary>
        /// <returns></returns>
        public bool LoadConfigInfo()
        {
            string configInfo = string.Empty;
            string error = string.Empty;

            lock(configFilePath)
            {
                FileStream.SetFilePath(configFilePath);
                if (!FileStream.Read(ref configInfo, ref error))
                {
                    return false;
                }
            }

            lock(configLst)
            {
                foreach (var info in configInfo.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] config = info.Split(',');
                    if (2 != config.Length)
                    {
                        continue;
                    }

                    if (configLst.ContainsKey(config[0]))
                    {
                        configLst[config[0]] = config[1];
                        continue;
                    }

                    configLst.Add(config[0], config[1]);
                }
            }

            return true;
        }
    }
}
