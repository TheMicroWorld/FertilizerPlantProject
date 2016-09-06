using Core.Persistence.Generic.Repositories;
using Core.Persistence.Generic.UnitOfWork;
using Core.Persistence.NHibernate.Repositories;
using Core.Persistence.NHibernate.UnitOfWork;
using ProductManagementService.entities.produt;
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
        private IRepository<QrCodeModel, string> qrCodeRepository;
        private NHibernateUnitOfWork unitOfWork;

        private void StartNewUnitOfWork()
        {
            unitOfWork = (NHibernateUnitOfWork)UnitOfWork.Start();
            qrCodeRepository = new NHibernateRepository<QrCodeModel, string>(unitOfWork);
        }
        private void EndUnitOfWork()
        {
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
        }
        public void Add(QrCodeModel qrCode)
        {
            StartNewUnitOfWork();
            qrCodeRepository.Add(qrCode);
            EndUnitOfWork();
        }
        public QrCodeModel FindById(string qrCodeId)
        {
            StartNewUnitOfWork();
            QrCodeModel qrCodeModel = qrCodeRepository.Get(qrCodeId);
            EndUnitOfWork();
            return qrCodeModel;
        }

        public void Update(QrCodeModel qrCode)
        {
            StartNewUnitOfWork();
            qrCodeRepository.Add(qrCode);
            EndUnitOfWork();
        }


        public void BulkSave(IList<QrCodeModel> qrcodes)
        {
            StartNewUnitOfWork();
            qrCodeRepository.BulkSave(qrcodes);
            EndUnitOfWork();
        }

        public List<QrCodeModel> FindAllUnsynchedBindedQrCodes()
        {
            List<QrCodeModel> qrcodes = null;
            StartNewUnitOfWork();
            qrcodes = qrCodeRepository.FilterBy(code => code.SyncStatus == false && code.Distributor != null && code.Product != null).ToList();
            EndUnitOfWork();
            return qrcodes;
        }
    }
}
