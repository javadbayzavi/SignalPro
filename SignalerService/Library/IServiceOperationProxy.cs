using Signaler.Library.Data.Core;
using Signaler.Data.Models.assets;
using Signaler.Library.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Signaler.Services.Library;

namespace Signaler.Library.Services
{
    public interface IServiceOperationProxy<T_Entity , T_ServiceModel> where T_Entity : BaseEntity where T_ServiceModel : ServiceModelBase
    {
        //Do Delete operation through the proxy on data layer
        public bool doDelete(ref T_ServiceModel entry);


        //Do Update operation through the proxy on data layer
        public T_Entity doUpdate(ref T_ServiceModel entry);


        //Do Insert operation through the proxy on data layer
        public T_Entity doInsert(ref T_ServiceModel entry);


        //Do Get operation through the proxy on data layer
        public IQueryable<T_ServiceModel> doGet(long id);
    }
}
