using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Signaler.Library.Data.Core
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
