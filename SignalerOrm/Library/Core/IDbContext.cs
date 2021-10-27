using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Signaler.Library.Data.Core
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync(System.Threading.CancellationToken token);
    }
}
