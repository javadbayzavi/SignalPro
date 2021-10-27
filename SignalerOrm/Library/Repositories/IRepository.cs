using Signaler.Library.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signaler.Library.Data.Repositories
{
    public interface IRepository<T_Entity> where T_Entity : BaseEntity
    {
        T_Entity GetById(object id);
        T_Entity Insert(T_Entity entity);
        T_Entity Update(T_Entity entity);
        bool Delete(T_Entity entity); 
        
        Task<T_Entity> GetByIdAsync(object id);
        Task<T_Entity> InsertAsync(T_Entity entity);
        Task<T_Entity> UpdateAsync(T_Entity entity);
        Task<bool> DeleteAsync(T_Entity entity);

        IQueryable<T_Entity> Table { get; }
    }
}
