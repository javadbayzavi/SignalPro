using System;
using System.Collections.Generic;
using System.Text;

namespace Signaler.Library.Services
{
    public interface IOperationPreparable
    {
        void PrepareForDelete();
        void PrepareForInsert();
        void PrepareForUpdate();
        void PrepareForGet();

        void AfterDelete();
        void AfterInsert();
        void AfterUpdate();
        void AfterGet();
    }
}
