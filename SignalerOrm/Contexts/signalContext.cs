using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Signaler.Data.Core;

namespace Signaler.Data.Contexts
{
    public class signalContext : DbContext, IDbContext
    {
        public signalContext(DbContextOptions options) : base(options)
        {
        }

        public signalContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=.;Initial Catalog=signalpro;Persist Security Info=True;User ID=signalpro;Password=1234567890;Encrypt=False;ApplicationIntent=ReadWrite;",
                    opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(30).TotalSeconds)
                    );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                //Create Dynamically configuration object for each entity and inject modelbuilder to this configuration
                dynamic configurationInstance = Activator.CreateInstance(type,modelBuilder);

                //Apply all the configuration into the inejected model builder
                //modelBuilder.ApplyConfiguration(configurationInstance);
            }

            //Apply all the configuration object for entities
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
    }


}
