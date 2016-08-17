using ProductManagementService.entities.stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementService.services.stock
{
    public interface StockLevelService
    {
        void Add(StockLevelModel stockLevel);
    }
}
