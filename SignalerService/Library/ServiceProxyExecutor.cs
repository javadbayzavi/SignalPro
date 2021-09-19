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
            //this.Mapper = new Mapper(new C)
        }

        public bool doDelete(ref T_ServiceModel entry)
        {
            //Mapping Process
            T_Entity _entity = this._doMapping(entry);

            return this.service.Repository.Delete(_entity);
        }

        public T_Entity doUpdate(ref T_ServiceModel entry)
        {
            //Mapping Process
            T_Entity _entity = this._doMapping(entry);

            return this.service.Repository.Update(_entity);
        }

        public T_Entity doInsert(ref T_ServiceModel entry)
        {
            //Mapping Process
            T_Entity _entity = this._doMapping(entry);

            return this.service.Repository.Insert(_entity);
        }

        public IQueryable<T_ServiceModel> doGet(long id)
        {
            IQueryable<T_ServiceModel> items = (IQueryable<T_ServiceModel>) this.service.Repository.GetById(id);

            return items;
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
    }
}
