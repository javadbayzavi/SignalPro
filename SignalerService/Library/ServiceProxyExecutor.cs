using AutoMapper;
using Signaler.Library.Data.Core;
using Signaler.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Signaler.Services.Library
{
    public sealed class ServiceProxyExecutor<T_Entity,T_ServiceModel> : IServiceOperationProxy<T_Entity, T_ServiceModel> 
        where T_Entity : BaseEntity where T_ServiceModel : ServiceModelBase
    {
        public Service<T_Entity,T_ServiceModel> service { get; set; }
        public Mapper Mapper { get; set; }
        public ServiceProxyExecutor(Service<T_Entity, T_ServiceModel> _service)
        {
            this.service = _service;
        }

        //Template method for Delete
        public bool doDelete(ref T_ServiceModel entry)
        {
            //Mapping Process
            T_Entity _entity = this._doMapping(entry);

            return this.service.Repository.Delete(_entity);
        }

        
        //Template method for Update
        public T_Entity doUpdate(ref T_ServiceModel entry)
        {
            //Mapping Process
            T_Entity _entity = this._doMapping(entry);

            return this.service.Repository.Update(_entity);
        }

        //Template method for Insert
        public T_Entity doInsert(ref T_ServiceModel entry)
        {
            //Mapping Process
            T_Entity _entity = this._doMapping(entry);

            return this.service.Repository.Insert(_entity);
        }

        //Template method for Get
        public IQueryable<T_ServiceModel> doGet(long id)
        {
            if (id > 0)
            {
                IQueryable<T_ServiceModel> items = (IQueryable<T_ServiceModel>)this.service.Repository.GetById(id);

                return items;
            }
            else
                return this._doReverseMapping(this.service.Repository.Table.ToList().AsQueryable());
        }


        //Template method for Delete
        public async Task<bool> doDeleteAsync(T_ServiceModel entry)
        {
            //Mapping Process
            T_Entity _entity = this._doMapping(entry);

            return await this.service.Repository.DeleteAsync(_entity);
        }


        //Template method for Update
        public async Task<T_Entity> doUpdateAsync(T_ServiceModel entry)
        {
            //Mapping Process
            T_Entity _entity = this._doMapping(entry);

            return await this.service.Repository.UpdateAsync(_entity);
        }

        //Template method for Insert
        public async Task<T_Entity> doInsertAsync(T_ServiceModel entry)
        {
            //Mapping Process
            T_Entity _entity = this._doMapping(entry);

            return await this.service.Repository.InsertAsync(_entity);
        }

        //Template method for Get
        public async Task<IQueryable<T_ServiceModel>> doGetAsync(long id)
        {
            if (id > 0)
            {
                T_Entity items = await this.service.Repository.GetByIdAsync(id);

                var mappedItem = this._doReverseMapping(items);
                List<T_ServiceModel> item = new List<T_ServiceModel>();
                item.Add(mappedItem);
                return item.AsQueryable();
            }
            else
            {
                return this._doReverseMapping(this.service.Repository.Table.ToList().AsQueryable());
            }
        }


        //Private memebers
        private T_Entity _doMapping(T_ServiceModel entry)
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<T_ServiceModel, T_Entity>();
            });

            this.Mapper = new Mapper(configuration);

            return (T_Entity)Mapper.Map(entry, typeof(T_ServiceModel), typeof(T_Entity));
        }

        private IQueryable<T_ServiceModel> _doReverseMapping(IQueryable<T_Entity> entry)
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<T_Entity, T_ServiceModel>();
            });

            // Create map engine
            this.Mapper = new Mapper(configuration);
            var mappedCOllection = Mapper.Map(entry, typeof(IQueryable<T_Entity>), typeof(IQueryable<T_ServiceModel>));
            
            return ((IList<T_ServiceModel>)mappedCOllection).AsQueryable<T_ServiceModel>();
        }
        private T_ServiceModel _doReverseMapping(T_Entity entry)
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<T_Entity, T_ServiceModel>();
            });

            // Create map engine
            this.Mapper = new Mapper(configuration);
            var mappedCOllection = Mapper.Map(entry, typeof(T_Entity), typeof(T_ServiceModel));

            return (T_ServiceModel) mappedCOllection;
        }
    }
}
