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
    public abstract class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        protected readonly SitewareDbContext context;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(SitewareDbContext context)
        {
            this.context = context;
            this.DbSet = context.Set<TEntity>();
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose

        // To detect redundant calls
        private bool _disposed = false;

        // Instantiate a SafeHandle instance.
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose() => Dispose(true);
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed state (managed objects).
                _safeHandle?.Dispose();
            }

            _disposed = true;
        }

        public async Task Insert(TEntity Entity)
        {
            await DbSet.AddAsync(Entity);
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
        #endregion
    }
}