using Core.Persistence.Generic.UnitOfWork;
using Core.Persistence.NHibernate.UnitOfWork.Factories;
using Core.utils.httpclient;
using DatabaseSynchronizationService.service;
using DatabaseSynchronizationService.util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using ProductManagementService.entities.product;
using ProductManagementService.entities.produt;
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
    public class ApplicationContext
    {
        public void Init()
        {
            ConfigureHibernateMapping();
            SynchronizeRemoteToLocalDatabase();
        }

        private void SynchronizeRemoteToLocalDatabase()
        {
            DBSynchronizationService synchronizationService = new DefaultDBSynchronizationService();
            synchronizationService.SynchronizeRemoteToLocalDatabase();
            synchronizationService.SynchronizeLocalToRemoteDatabase();
        }
        public void ConfigureHibernateMapping()
        {
            NHibernate.Cfg.Configuration hibernateConfig = (UnitOfWork.UnitOfWorkFactory as NHibernateUnitOfWorkFactory).Configuration;
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(ProductModelMap).Assembly.GetExportedTypes());
            mapper.AddMappings(typeof(DistributorModelMap).Assembly.GetExportedTypes());
            mapper.AddMappings(typeof(QrCodeModelMap).Assembly.GetExportedTypes());

            hibernateConfig.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(),"FertilizerPlantScheme");
            SchemaUpdate schema = new SchemaUpdate(hibernateConfig);
            schema.Execute(true, true);
        }
    }
}
