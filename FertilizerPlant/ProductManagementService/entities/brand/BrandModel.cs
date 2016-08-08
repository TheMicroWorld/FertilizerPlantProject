using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementService.entities.brand
{
    public class BrandModel
    {
        private long id;
        private string brandName;

        public virtual long Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public virtual string BrandName
        {
            get
            {
                return brandName;
            }

            set
            {
                brandName = value;
            }
        }
    }
}
