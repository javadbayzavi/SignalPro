using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Signaler.Services.Library;

namespace Signaler.Library.Services
{
    public interface IService<ServiceModel> : IServable where ServiceModel: ServiceModelBase
    {
        IQueryable<ServiceModel> GetItems();
        ServiceModel GetItem(long id);
        bool Insert(ServiceModel serviceModel);
        bool Update(ServiceModel serviceModel);
        bool Delete(ServiceModel serviceModel);
        Task<IQueryable<ServiceModel>> GetItemsAsync();
        Task<ServiceModel> GetItemAsync(long id);
        Task<bool> InsertAsync(ServiceModel serviceModel);
        Task<bool> UpdateAsync(ServiceModel serviceModel);
        Task<bool> DeleteAsync(ServiceModel serviceModel);

    }
}
