using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Insert.Entities;

namespace Insert.Repositories.Interfaces
{
    public interface IRateRepository<TEntity> where TEntity : BaseTableEntity, new()
    {
        Task AddRates(TEntity rateTable);
    }
}