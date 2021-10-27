using Signaler.Library.Data.Core;
using Signaler.Library.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Signaler.Services.Library;
using System.Threading.Tasks;

namespace Signaler.Library.Services
{
    public class Service<T_Entity, T_ServiceModel> : IService<T_ServiceModel>, IOperationPreparable where T_Entity : BaseEntity where  T_ServiceModel : ServiceModelBase
    {
        public IRepository< T_Entity> Repository { get; set; }
        protected IServiceOperationProxy<T_Entity, T_ServiceModel> executor { get; set; }
        public T_ServiceModel ServiceModel { get; set; }
        protected T_Entity EntityModel { get; set; }

        protected IQueryable<T_ServiceModel> ServiceModels { get; set; }

        public Service(IRepository<T_Entity> repo)
        {
            this.Repository = repo;
            this.executor = new ServiceProxyExecutor<T_Entity, T_ServiceModel>(this);
        }

        public IService<T_ServiceModel> ServiceProxyInterface 
        { 
            get
            {
                return (IService<T_ServiceModel>)this;
            }
        }
        public Service<T_Entity,T_ServiceModel> Super
        {
            get
            {
                return this;
            }
        }
        //Template method for Delete
        public bool Delete(T_ServiceModel serviceModel)
        {
            //Business related operation on data before delete
            this.PrepareForDelete();

           //running delete operation
            var res = this.executor.doDelete(ref serviceModel);

            //Business operation after delete function
            this.AfterDelete();
            return res;
        }


        //Template method for GetItem
        public T_ServiceModel GetItem(long id)
        {
            //Business related operation on data before Get
            this.PrepareForGet();

            //running GetItem operation
            this.ServiceModel =  this.executor.doGet(id).FirstOrDefault();

            //Business operation after GetItem function
            this.AfterGet();

            return this.ServiceModel;
        }

        //Template method for GetItems
        public IQueryable<T_ServiceModel> GetItems()
        {
            //Business related operation on data before Get
            this.PrepareForGet();

            //running GetItems operation
            this.ServiceModels = this.executor.doGet(0);

            //Business operation after GetItems function
            this.AfterGet();

            return this.ServiceModels;
        }

        //Template method for Insert
        public bool Insert(T_ServiceModel serviceModel)
        {
            try
            {
                //Business related operation on data before insert
                this.PrepareForInsert();

                //running Insert operation
                var item = this.executor.doInsert(ref serviceModel);

                //Business operation after Insert function
                this.AfterInsert();

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
                //Business related operation on data before update
                this.PrepareForUpdate();

                //running Update operation
                this.executor.doUpdate(ref serviceModel);

                //Business operation after Update function
                this.AfterUpdate();

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

        public virtual void AfterDelete() { }
        public virtual void AfterInsert() { }
        public virtual void AfterUpdate() { }
        public virtual void AfterGet() { }

        public async Task<IQueryable<T_ServiceModel>> GetItemsAsync()
        {
            //Business related operation on data before Get
            this.PrepareForGet();

            //running GetItems operation
            this.ServiceModels = await this.executor.doGetAsync(0);

            //Business operation after GetItems function
            this.AfterGet();

            return this.ServiceModels;
        }

        public async Task<T_ServiceModel> GetItemAsync(long id)
        {
            //Business related operation on data before Get
            this.PrepareForGet();

            //running GetItem operation
            var res = await this.executor.doGetAsync(id);
            this.ServiceModel = res.FirstOrDefault();

            //Business operation after GetItem function
            this.AfterGet();

            return this.ServiceModel;
        }

        public async Task<bool> InsertAsync(T_ServiceModel serviceModel)
        {
            try
            {
                //Business related operation on data before insert
                this.PrepareForInsert();

                //running Insert operation
                var item = await this.executor.doInsertAsync(serviceModel);

                //Business operation after Insert function
                this.AfterInsert();

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

        public async Task<bool> UpdateAsync(T_ServiceModel serviceModel)
        {
            try
            {
                //Business related operation on data before update
                this.PrepareForUpdate();

                //running Update operation
                await this.executor.doUpdateAsync(serviceModel);

                //Business operation after Update function
                this.AfterUpdate();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(T_ServiceModel serviceModel)
        {
            //Business related operation on data before delete
            this.PrepareForDelete();

            //running delete operation
            var res = await this.executor.doDeleteAsync(serviceModel);

            //Business operation after delete function
            this.AfterDelete();
            return res;
        }
    }
}
