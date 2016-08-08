using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Generic.UnitOfWork.Factories
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
