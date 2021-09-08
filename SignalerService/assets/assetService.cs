using Signaler.Data.Models.assets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Signaler.Data.Repositories;
using Signaler.Services.Core;

namespace Signaler.Services.assets
{
    public class assetService : Service<asset>, IassetService
    {
        public assetService(IRepository<asset> _repository) : base(_repository)
        {
            this.repository = _repository;
        }
        public void DeleteAsset(asset asset)
        {
            this.repository.Delete(asset);
        }

        public asset GetAsset(long id)
        {
            return this.repository.GetById(id);
        }

        public IQueryable<asset> GetAssets()
        {
            return this.repository.Table;
        }

        public void InsertAsset(asset asset)
        {
            this.repository.Insert(asset);
        }

        public void UpdateAsset(asset asset)
        {
            this.repository.Update(asset);
        }
    }
}
