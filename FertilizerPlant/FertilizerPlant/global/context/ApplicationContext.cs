using Core.Persistence.Generic.UnitOfWork;
using Core.Persistence.NHibernate.UnitOfWork.Factories;
using Core.utils.httpclient;
using Newtonsoft.Json.Linq;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using ProductManagementService.entities.product;
using QrCodeManagementService.entities.qrcode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserManagementService.entities.distributors;

namespace FertilizerPlant.global.context
{
    /// <summary>
    /// This class contains the global setting of the applcation,including the
    /// global configuration of the windows application
    /// </summary>
    public static class ApplicationContext
    {
        public static string SERVER_IP = ConfigurationManager.AppSettings["SERVER_IP"];
        public static string SERVER_PORT = ConfigurationManager.AppSettings["SERVER_PORT"];
        public static string PROTOCOL = "http";
        public static string PRODUCT_SYNC_URL = PROTOCOL+ "//" + SERVER_IP + ":" + SERVER_PORT + "/synchronization/products";
        public static string QRCODE_SYNC_URL = PROTOCOL + "//" + SERVER_IP + ":" + SERVER_PORT + "/synchronization/qrcodes";
        public static string DISTRIBUTOR_SYNC_URL = PROTOCOL + "//" + SERVER_IP + ":" + SERVER_PORT + "/synchronization/distributors";

        public static void ConfigureHibernateMapping()
        {
            NHibernate.Cfg.Configuration hibernateConfig = (UnitOfWork.UnitOfWorkFactory as NHibernateUnitOfWorkFactory).Configuration;
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(ProductModelMap).Assembly.GetExportedTypes());
            mapper.AddMappings(typeof(DistributorModelMap).Assembly.GetExportedTypes());
            mapper.AddMappings(typeof(QrCodeModelMap).Assembly.GetExportedTypes());

            hibernateConfig.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(),"FertilizerPlantScheme");
            SchemaExport schema = new SchemaExport(hibernateConfig);
            schema.Create(false, true);
        }
        public static void SynchronizeRemoteToLocalDatabase()
        {
            SynchronizeProducts();
        }

        private static async void SynchronizeProducts()
        {
            Console.WriteLine("Thread id is {0}", Thread.CurrentThread.ManagedThreadId);
            
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(PRODUCT_SYNC_URL))
            using (HttpContent content = response.Content)
            {
                string result = await HttpConetentExtension.ReadAsJsonAsync(content, Encoding.UTF8);
                JArray array = JArray.Parse(result);
                foreach (JObject o in array.Children<JObject>())
                {
                    foreach (JProperty p in o.Properties())
                    {
                        var name = p.Name;
                        var value = p.Value;
                        Console.WriteLine(name + " -- " + value);
                    }
                }

                if (result != null)
                {
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                    Console.WriteLine(result);
                    Console.Out.Flush();
                }
            }


        }

        public static  void SynchronizeLocalToRemoteDatabase()
        {
            return;
        }

        public static IList<string> GetConfiguredComPorts()
        {
            return ConfigurationManager.AppSettings["PORTS"].Split(',').ToList<string>();
        }
    }
}
