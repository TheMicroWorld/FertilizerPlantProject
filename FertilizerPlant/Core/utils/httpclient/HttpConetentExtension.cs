using Core.utils.httpclient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.utils.httpclient
{
    public static class HttpConetentExtension
    {
        public static async Task<string> ReadAsJsonAsync(HttpContent content, Encoding encoding)
        {
            Byte[] byteArray = await content.ReadAsByteArrayAsync();
            string jsonResponse = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            Console.WriteLine(jsonResponse);
            return jsonResponse;
            
        }
    }
}
