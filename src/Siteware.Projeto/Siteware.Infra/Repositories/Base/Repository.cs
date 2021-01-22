﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Siteware.Domain.Repositories.Base;
using Siteware.Infra.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Siteware.Infra.Repositories.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SitewareDbContext context;
        private readonly DbSet<TEntity> DbSet;
        public Repository(SitewareDbContext context)
        {
            this.context = context;
            this.DbSet = context.Set<TEntity>();
        }



        public async Task Insert(TEntity Entity)
        {
            await context.Set<TEntity>().AddAsync(Entity);
        }

        public async Task Update(TEntity Entity)
        {
            await Task.Run(() => DbSet.Update(Entity));
        }

        public async Task Remove(TEntity Entity)
        {
            await Task.Run(() => DbSet.Remove(Entity));
        }

        public async Task<TEntity> GetById(int Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public async Task<List<TEntity>> Get()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetEnumerable(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }
    }
}
