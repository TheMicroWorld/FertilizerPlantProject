using Core.Persistence.Generic.UnitOfWork;
using Core.Persistence.NHibernate.UnitOfWork.Factories;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using ProductManagementService.entities.product;
using QrCodeManagementService.entities.qrcode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
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
            return;
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
