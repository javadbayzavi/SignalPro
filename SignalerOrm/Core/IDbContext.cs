using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Signaler.Data.Core
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
