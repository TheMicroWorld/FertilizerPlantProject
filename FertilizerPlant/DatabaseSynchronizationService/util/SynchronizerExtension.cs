using Core.utils.httpclient;
using DatabaseSynchronizationService.synchronizer.syncdata;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductManagementService.entities.produt;
using QrCodeManagementService.entities.qrcode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserManagementService.entities.distributors;

namespace DatabaseSynchronizationService.util
{
    public static class SynchronizerExtension
    {
        private static HttpClient client = new HttpClient();

        /// <summary>
        /// This method will fetch the generic objects from remote
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="requestURL"></param>
        /// <returns></returns>
        public static  List<TEntity> FetchEntitiesFromRemoteSync<TEntity>(string requestURL)
        {
                try
                {
                    using (HttpResponseMessage response = client.GetAsync(requestURL).Result)
                    using (HttpContent content = response.Content)
                    {
                        string result = HttpConetentExtension.ReadAsJsonSync(content, Encoding.UTF8);
                        List<TEntity> jsonResponse = JsonConvert.DeserializeObject<List<TEntity>>(result);
                        return jsonResponse;
                    }
                }
                catch(AggregateException aex)
                {
                    MessageBox.Show("连接服务器出错");
                }
                return new List<TEntity>();       
        }
        /// <summary>
        /// return if the upload is successful
        /// </summary>
        /// <typeparam name="TUpload"></typeparam>
        /// <param name="requestURL"></param>
        /// <param name="uploadData"></param>
        /// <returns></returns>
        public static bool SendSynchStatusOkayToRemote<TUpload>(string requestURL, List<TUpload> uploadData) where TUpload : BaseSyncDataUpStream
        {
            if(uploadData.Count == 0)
            {
                return true;
            }
            try
            {
                string postContent = JsonConvert.SerializeObject(uploadData, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }).ToString();

                Console.WriteLine(postContent);
                using (HttpResponseMessage response = client.PostAsync(requestURL, new StringContent(postContent,
                    Encoding.UTF8, "application/json")).Result)
                using (HttpContent content = response.Content)
                {
                    string result = content.ReadAsStringAsync().Result;
                    Console.WriteLine(result);
                    if (result.Equals("Succeed"))
                    {

                        return true;
                    }
                }
            }
            catch (AggregateException aex)
            {
                MessageBox.Show("网络连接异常");
            }
            return false;
        }
    }
}
