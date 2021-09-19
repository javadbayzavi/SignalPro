using Signaler.Data.Models.assets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Signaler.Library.Data.Repositories;
using Signaler.Library.Services;
using Signaler.Services.Models.Assets;

namespace Signaler.Services.assets
{
    public class assetService : Service<asset, assetServiceModel>
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
