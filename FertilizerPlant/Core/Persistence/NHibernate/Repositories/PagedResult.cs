using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Generic.UnitOfWork
{
    public class PagedResult<TEntity>
    {
        IEnumerable<TEntity> items;
        int totalCount;

        public PagedResult(IEnumerable<TEntity> items,int totalCount)
        {
            this.items = items;
            this.totalCount = totalCount; 
        }

        public IEnumerable<TEntity> Items
        {
            get
            {
                return items;
            }
        }

        public int TotalCount
        {
            get
            {
                return totalCount;
            }
        }

    }
}
