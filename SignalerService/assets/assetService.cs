using Signaler.Data.Models.assets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Signaler.Library.Data.Repositories;
using Signaler.Library.Services;
using Signaler.Services.Models.Assets;
using Signaler.Services.Library;

namespace Signaler.Services.assets
{
    [ServiceTarget(ServiceTargetType.Business)]
    [ServiceHost(ServiceHostType.Web)]
    public class assetService : Service<asset, assetServiceModel>
    //public class assetService<T_ServiceModel> : Service<asset, T_ServiceModel> where T_ServiceModel : assetServiceModel
    {
        public assetService(IRepository<asset> _repository) : base(_repository)
        {
            this.Repository = _repository;
        }
        
        //Hook method to prepare service befor Delete operation
        public override void PrepareForDelete()
        {
        }

        //Hook method to prepare service befor Get operation
        public override void PrepareForGet()
        {
        }

        //Hook method to prepare service befor Update operation
        public override void PrepareForUpdate()
        {
        }

        //Hook method to prepare service befor Insert operation
        public override void PrepareForInsert()
        {
        }
    }
}
