using Microsoft.EntityFrameworkCore;
using Signaler.Library.Data.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace Signaler.Library.Data.Repositories
{
    public class Repository<T_Entity> : IRepository<T_Entity> where T_Entity : BaseEntity
    {
        private readonly IDbContext _context;
        private DbSet<T_Entity> _entities;

        public Repository(IDbContext context)
        {
            this._context = context;
        }

        public T_Entity GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public T_Entity Insert(T_Entity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Add(entity);
                this._context.SaveChanges();
                return entity;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public T_Entity Update(T_Entity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this._context.SaveChanges();
                return entity;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public bool Delete(T_Entity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Remove(entity);
                this._context.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }


        public async Task<T_Entity> GetByIdAsync(object id)
        {
            return await this.Entities.FindAsync(id);
        }

        public async Task<T_Entity> InsertAsync(T_Entity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                await this.Entities.AddAsync(entity);
                await this._context.SaveChangesAsync(System.Threading.CancellationToken.None);
                return entity;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public async Task<T_Entity> UpdateAsync(T_Entity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                await this._context.SaveChangesAsync(System.Threading.CancellationToken.None);
                return entity;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public async Task<bool> DeleteAsync(T_Entity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Remove(entity);
                await this._context.SaveChangesAsync(System.Threading.CancellationToken.None);
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public virtual IQueryable<T_Entity> Table
        {
            get
            {
                return this.Entities;
            }
        }

        private DbSet<T_Entity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T_Entity>();
                }
                return _entities;
            }
        }
    }
}