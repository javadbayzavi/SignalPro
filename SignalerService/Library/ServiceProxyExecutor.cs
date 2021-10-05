using AutoMapper;
using Signaler.Library.Data.Core;
using Signaler.Library.Services;
using System;
using System.Linq;

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
            //Business related operation on data before delete
            this.service.PrepareForDelete();            
            
            //Mapping Process
            T_Entity _entity = this._doMapping(entry);

            return this.service.Repository.Delete(_entity);
        }

        
        //Template method for Update
        public T_Entity doUpdate(ref T_ServiceModel entry)
        {
            //Business related operation on data before update
            this.service.PrepareForUpdate();

            //Mapping Process
            T_Entity _entity = this._doMapping(entry);

            return this.service.Repository.Update(_entity);
        }

        //Template method for Insert
        public T_Entity doInsert(ref T_ServiceModel entry)
        {
            //Business related operation on data before insert
            this.service.PrepareForInsert();

            //Mapping Process
            T_Entity _entity = this._doMapping(entry);

            return this.service.Repository.Insert(_entity);
        }

        public IQueryable<T_ServiceModel> doGet(long id)
        {
            //Business related operation on data before Get
            this.service.PrepareForGet();
            if (id > 0)
            {
                IQueryable<T_ServiceModel> items = (IQueryable<T_ServiceModel>)this.service.Repository.GetById(id);

                return items;
            }
            else
                return this._doReverseMapping(this.service.Repository.Table.ToList().AsQueryable());
        }
        

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

            this.Mapper = new Mapper(configuration);

            return (IQueryable<T_ServiceModel>)Mapper.Map(entry, typeof(T_Entity), typeof(T_ServiceModel));
        }
    }
}
