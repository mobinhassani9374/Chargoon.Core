using Chargoon.DataLayer.Context;
using Chargoon.DomainModels.Entities;
using Chargoon.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chargoon.DataLayer.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public ServiceResult Create(TEntity entity)
        {
            _context.Add(entity);
            return Save();
        }

        public ServiceResult Update(TEntity entity)
        {
            _context.Update(entity);
            return Save();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public ServiceResult Save()
        {
            if (_context.SaveChanges() > 0) return ServiceResult.Okay();
            return ServiceResult.Error();
        }


    }
}
