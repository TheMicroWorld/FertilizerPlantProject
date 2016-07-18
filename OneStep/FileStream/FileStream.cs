using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CD_FileStream
{
    /// <summary>
    /// 简单文本实现方案
    /// </summary>
    public class FileStream
    {
        private static string filePath;

        private FileStream()
        { 
        }

        static FileStream()
        {
            filePath = "D:\\Data.txt";
        }

        public static void SetFilePath(string path)
        {
            filePath = path;
        }

        public static bool Write(string content, ref string error)
        {
            try
            {
                lock (filePath)
                {
                    File.WriteAllText(filePath, content);
                }
            }
            catch(Exception ex)
            {
                error = ex.ToString();
                return false;
            }
            return true;
        }

        public static bool Append(string content, ref string error)
        {
            try
            {
                lock (filePath)
                {
                    File.AppendAllText(filePath, content);
                }
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                return false;
            }
            return true;
        }

        public static bool Read(ref string content, ref string error)
        {
            try
            {
                lock(filePath)
                {
                    content = File.ReadAllText(filePath);
                }
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                return false;
            }
            return true;
        }
    }
}