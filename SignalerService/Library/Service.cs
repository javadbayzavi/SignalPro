using Signaler.Library.Data.Core;
using Signaler.Library.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Signaler.Services.Library;

namespace Signaler.Library.Services
{
    public class Service<T_Entity, T_ServiceModel> : IService<T_ServiceModel>, IOperationPreparable where T_Entity : BaseEntity where  T_ServiceModel : ServiceModelBase
    {
        public IRepository< T_Entity> Repository { get; set; }
        protected IServiceOperationProxy<T_Entity, T_ServiceModel> executor { get; set; }

        public Service(IRepository<T_Entity> repo)
        {
            this.Repository = repo;
            this.executor = new ServiceProxyExecutor<T_Entity, T_ServiceModel>(this);
        }

        public IService<T_ServiceModel> ServiceProxy 
        { 
            get
            {
                return (IService<T_ServiceModel>)this;
            }
        }

        //Template method for Delete
        public bool Delete(T_ServiceModel serviceModel)
        {
            return this.executor.doDelete(ref serviceModel);
        }


        //Template method for GetItem
        public T_ServiceModel GetItem(long id)
        {
            return this.executor.doGet(id).FirstOrDefault();
        }

        //Template method for GetItems
        public IQueryable<T_ServiceModel> GetItems()
        {
            return this.executor.doGet(0);
        }

        //Template method for Insert
        public bool Insert(T_ServiceModel serviceModel)
        {
            try
            {
                var item = this.executor.doInsert(ref serviceModel);
                if (item.Id > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }

        //Template method for Update
        public bool Update(T_ServiceModel serviceModel)
        {
            try
            {
                this.executor.doUpdate(ref serviceModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }

        public virtual void PrepareForDelete() { }
        public virtual void PrepareForInsert() { }
        public virtual void PrepareForUpdate() { }
        public virtual void PrepareForGet() { }
    }
}
