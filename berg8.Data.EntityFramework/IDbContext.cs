using System;
using System.Collections.Generic;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Berg8.Core.Domain;


namespace Berg8.Data.EntityFramework
{
    public interface IDbContext : IDisposable
    {
        ISet<T> Set<T>() where T : BaseEntity;

        void SetAsAdded<T>(T entity) where T : BaseEntity;

        void SetAsModified<T>(T entity) where T : BaseEntity;

        void SetAsDeleted<T>(T entity) where T : BaseEntity;

        int SaveChanges();

        Task<int> SaveChangesAsync();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        void BeginTransaction();

        int Commit();

        Task<int> CommitAsync();

        void Rollback();
    }
}
