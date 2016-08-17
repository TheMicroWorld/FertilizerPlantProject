using Core.Persistence.Generic.Repositories;
using Core.Persistence.Generic.UnitOfWork;
using Core.Persistence.NHibernate.Repositories;
using Core.Persistence.NHibernate.UnitOfWork;
using QrCodeManagementService.entities.qrcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCodeManagementService.services.qrcode
{
    public class DefaultQrCodeService : QrCodeService
    {
        public void Add(QrCodeModel qrCode)
        {
            NHibernateUnitOfWork unitOfWork = (NHibernateUnitOfWork)UnitOfWork.Start();
            IRepository<QrCodeModel, int> qrCodeRepository = new NHibernateRepository<QrCodeModel, int>(unitOfWork);
            qrCodeRepository.Add(qrCode);
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
        }
    }
}
