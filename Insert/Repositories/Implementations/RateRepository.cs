using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Insert.Db;
using Insert.Entities;
using Insert.Repositories.Interfaces;
using Insert.Services.Interfaces;

namespace Insert.Repositories.Implementations
{
    public class RateRepository<TEntity> : IRateRepository<TEntity> where TEntity : BaseTableEntity, new()
    {
        private InsertContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public RateRepository(InsertContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task AddRates(TEntity entity)
        {
            var existingRateTable = _dbSet
                                        .SingleOrDefault(rt => rt.EffectiveDate == entity.EffectiveDate && rt.TableType == entity.TableType);

            if(existingRateTable == null)
            {
                _dbSet.Add(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}