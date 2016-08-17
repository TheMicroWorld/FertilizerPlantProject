using Core.Persistence.Generic.UnitOfWork;
using Core.Persistence.NHibernate.UnitOfWork.Factories;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using ProductManagementService.entities.product;
using QrCodeManagementService.entities.qrcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.entities.distributors;

namespace FertilizerPlant.global.context
{
    public class ApplicationContext
    {
        public ApplicationContext()
        {
            ConfigureHibernateMapping();
        }
        public void ConfigureHibernateMapping()
        {
            Configuration hibernateConfig = (UnitOfWork.UnitOfWorkFactory as NHibernateUnitOfWorkFactory).Configuration;
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(ProductModelMap).Assembly.GetExportedTypes());
            mapper.AddMappings(typeof(DistributorModelMap).Assembly.GetExportedTypes());
            mapper.AddMappings(typeof(QrCodeModelMap).Assembly.GetExportedTypes());

            hibernateConfig.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(),"FertilizerPlantScheme");
            SchemaExport schema = new SchemaExport(hibernateConfig);
            schema.Create(false, true);
        }
        public void SynchronizeRemoteToLocalDatabase()
        {
            return;
        }

        public void SynchronizeLocalToRemoteDatabase()
        {
            return;
        }
    }
}
