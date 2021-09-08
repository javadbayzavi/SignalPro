using Signaler.Data.Models.assets;
using Signaler.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Signaler.Services.assets
{
    public interface IassetService : IService<asset>
    {
        IQueryable<asset> GetAssets();
        asset GetAsset(long id);
        void InsertAsset(asset asset);
        void UpdateAsset(asset asset);
        void DeleteAsset(asset asset);
    }
}
